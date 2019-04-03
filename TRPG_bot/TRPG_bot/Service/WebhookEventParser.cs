using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRPG_bot.Model;

namespace TRPG_bot.Service
{
    public static class WebhookEventParser
    {
        public static IEnumerable<WebhookEvent> Parse(string webhookContent)
        {
            dynamic dynamicObject = JsonConvert.DeserializeObject(webhookContent);
            if (dynamicObject == null) { yield break; }

            foreach (var ev in dynamicObject.events)
            {
                var webhookEvent = WebhookEvent.CreateFrom(ev);
                if (webhookEvent == null) { continue; }
                yield return webhookEvent;
            }
        }

        public static IEnumerable<WebhookEvent> ParseEvents(dynamic events)
        {
            foreach (var ev in events)
            {
                var webhookEvent = WebhookEvent.CreateFrom(ev);
                if (webhookEvent == null) { continue; }
                yield return webhookEvent;
            }
        }

    }
}

