using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{
    /// <summary>
    /// Contents of the message
    /// </summary>
    public class EventMessage
    {
        /// <summary>
        /// Message ID
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// EventMessageType
        /// </summary>
        public EventMessageType Type { get; }

        public EventMessage(EventMessageType type, string id)
        {
            Type = type;
            Id = id;
        }

        internal static EventMessage CreateFrom(dynamic dynamicObject)
        {
            var message = dynamicObject?.message;
            if (message == null) { return null; }
            if (!Enum.TryParse((string)message.type, true, out EventMessageType messageType))
            {
                return null;
            }
            switch (messageType)
            {
                case EventMessageType.Text:
                    return new TextEventMessage((string)message.id, (string)message.text);
                default:
                    return null;
            }
        }
    }
}
