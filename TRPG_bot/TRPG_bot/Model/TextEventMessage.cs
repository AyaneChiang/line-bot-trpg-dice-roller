using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{
    /// <summary>
    /// Message object which contains the text sent from the source.
    /// </summary>
    public class TextEventMessage : EventMessage
    {
        public string Text { get; }

        public TextEventMessage(string id, string text) : base(EventMessageType.Text, id)
        {
            Text = text;
        }
    }
}
