using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Engine
{
    public class RuleExecutionEventArgs : EventArgs
    {
        public readonly IBindingRule BindingRule;
        public readonly object Item;
        public readonly bool Success;
        public readonly IEnumerable<Message> Messages;
        public readonly Exception Exception;

        public RuleExecutionEventArgs(IBindingRule bindingRule, object item, bool success, IEnumerable<Message> messages, Exception exception)
        {
            this.BindingRule = bindingRule;
            this.Item = item;
            this.Success = success;
            this.Messages = messages;
            this.Exception = exception;
        }
    }
}
