using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{
    public class WebhookEvent
    {
        public WebhookEventType Type { get; set; }
        public long Timestamp { get; set; }
        public WebhookEventSource Source { get; set; }

        public WebhookEvent(WebhookEventType type, WebhookEventSource source, long timestamp)
        {
            Type = type;
            Source = source;
            Timestamp = timestamp;
        }

        internal static WebhookEvent CreateFrom(dynamic dynamicObject)
        {
            if (dynamicObject == null) { throw new ArgumentNullException(nameof(dynamicObject)); }

            var eventSource = WebhookEventSource.CreateFrom(dynamicObject?.source);

            if (eventSource == null)
            {
                return null;
            }
            if (!Enum.TryParse((string)dynamicObject.type, true, out WebhookEventType eventType))
            {
                return null;
            }

            switch (eventType)
            {
                case WebhookEventType.Message:
                    EventMessage eventMessage = EventMessage.CreateFrom(dynamicObject);
                    if (eventMessage == null) { return null; }
                    return new MessageEvent(eventSource, (long)dynamicObject.timestamp, eventMessage, (string)dynamicObject.replyToken);                
                default:
                    return null;
            }
        }
    }
}
