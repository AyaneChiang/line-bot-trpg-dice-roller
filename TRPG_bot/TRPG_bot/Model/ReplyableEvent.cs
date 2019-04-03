using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{
    public abstract class ReplyableEvent : WebhookEvent
    {
        public string ReplyToken { get; }

        public ReplyableEvent(WebhookEventType eventType, WebhookEventSource source, long timestamp, string replyToken)
            : base(eventType, source, timestamp)
        {
            ReplyToken = replyToken;
        }
    }
}
