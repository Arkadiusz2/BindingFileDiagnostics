using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Engine
{
    public class RuleExecutionResult
    {
        public readonly IBindingRule BindingRule;
        public readonly bool Success;
        public readonly IEnumerable<Message> Messages;

        public RuleExecutionResult(IBindingRule bindingRule, bool success, IEnumerable<Message> messages)
        {
            this.BindingRule = bindingRule;
            this.Success = success;
            this.Messages = messages;
        }
    }
}
