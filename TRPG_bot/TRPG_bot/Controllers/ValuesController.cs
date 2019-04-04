using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TRPG_bot.Model;
using TRPG_bot.Service;

namespace TRPG_bot.Controllers
{
    [Route("line")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ValuesController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK!");
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]JObject json)
        {
            //if (!VaridateSignature(json.ToString(Formatting.None)))
            //    return Unauthorized();
            WebhookEvent webhookEvent;
            try
            {
                webhookEvent = WebhookEventParser.Parse(json.ToString(Formatting.None)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            if (webhookEvent == null)
                return BadRequest(json);


            switch (webhookEvent.Type)
            {
                case WebhookEventType.Message:
                    MessageEvent message = (MessageEvent)webhookEvent;
                    string token = message.ReplyToken;
                    
                    switch (message.Message.Type)
                    {
                        /// 文字訊息
                        case EventMessageType.Text:
                            List<string> result = MessageParser.Parse((TextEventMessage)message.Message);
                            if(result.Count > 0)
                                await ReplyMessageAsync(token, result);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return Ok();
        }
        
        private async Task ReplyMessageAsync(string replyToken, List<string> message)
        {
            var jsonSetting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, Global.LINE_API_URL_REPLY);
            var content = JsonConvert.SerializeObject(new ReplyTextMessage(replyToken, message), jsonSetting);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["Custom:Line:CHANNEL_ACCESS_TOKEN"]);

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// 驗證來源為Line
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool VaridateSignature(string body)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_config["Custom:Line:CHANNEL_ACCESS_TOKEN"]));
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(body));
            var contentHash = Convert.ToBase64String(computeHash);
            var headerHash = Request.Headers["X-Line-Signature"];

            return contentHash == headerHash;
        }
    }
}
