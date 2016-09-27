using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Engine
{
    public class RuleLoadedEventArgs : EventArgs
    {
        public readonly IBindingRule BindingRule;        
        public readonly Type BindingRuleType;
        public readonly Exception Exception;

        public RuleLoadedEventArgs(IBindingRule bindingRule, Type bindingRuleType, Exception exception)
        {
            this.BindingRule = bindingRule;
            this.BindingRuleType = bindingRuleType;
            this.Exception = exception;
        }
    }
}
