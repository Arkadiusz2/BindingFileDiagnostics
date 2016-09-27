using BindingFile.Diagnostics.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BfDiagUI
{
    public class ControlledRule
    {
        public IBindingRule BindingRule { get; private set; }
        public ControlledRuleSettings Settings { get; private set; }

        public ControlledRule(IBindingRule bindingRule)
        {
            this.BindingRule = bindingRule;
            this.Settings = new ControlledRuleSettings();
        }
    }
}
