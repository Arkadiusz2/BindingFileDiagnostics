using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules
{
    public class Message
    {
        public MessageTypeEnum Type { get; private set; }
        public string Text { get; private set; }

        public Message(string text)
            : this(MessageTypeEnum.Error, text)
        {            
        }
        
        public Message(MessageTypeEnum type, string text)
        {
            this.Type = type;
            this.Text = text;
        }
    }
}
