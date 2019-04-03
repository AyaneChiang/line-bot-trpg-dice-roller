using System.Collections.Generic;

namespace TRPG_bot.Model
{
    public class ReplyTextMessage
    {

        public ReplyTextMessage(string token, List<string> list)
        {
            ReplyToken = token;
            Messages = new List<TextMessage>();
            foreach (string msg in list)
                Messages.Add(new TextMessage(msg));
        }

        public string ReplyToken { get; set; }
        public List<TextMessage> Messages { get; set; }
    }

    public class TextMessage
    {
        public TextMessage(string text)
        {
            Type = MessageType.Text;
            Text = text;
        }

        public MessageType Type { get; set; }
        public string Text { get; set; }
    }
}
