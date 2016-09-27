using BindingFile.Diagnostics.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BfDiagUI
{
    public class RulesView
    {
        public RulesView(IEnumerable<IBindingRule> bindingRules)
        {
            foreach (var bindingRule in bindingRules)
            {
                object o = bindingRule;
            }
        }
    }
}
