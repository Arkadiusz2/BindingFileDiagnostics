using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules
{
    public class BindingRuleValidationEventArgs 
        : EventArgs
    {
        public readonly object Item;
        public readonly IEnumerable<Message> Messages;    
        public readonly bool Success;
        public readonly Exception Exception;

        public BindingRuleValidationEventArgs(object item, IEnumerable<Message> messages, bool success, Exception exception)
        {
            this.Item = item;
            this.Messages = messages;
            this.Success = success;
            this.Exception = exception;
        }
    
    }
}
