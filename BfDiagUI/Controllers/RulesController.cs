using BindingFile.Diagnostics.Engine;
using BindingFile.Diagnostics.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BfDiagUI
{
    public class RulesController
    {
        private List<ControlledRule> _controlledRules = null;

        public IEnumerable<ControlledRule> BindingRules
        {
            get
            {
                if (_controlledRules == null)
                {
                    _controlledRules = new List<ControlledRule>();
                    LoadRules(Settings.Settings.RulesAbsolutePath);
                }
                return _controlledRules;
            }
        }

        public int RulesCount
        {
            get
            {
                return _controlledRules.Count;
            }
        } 

        private void UnloadRules()
        {
            _controlledRules = null;
        }

        private void LoadRules(string rulesPath)
        {
            RuleLoader ruleLoader = new RuleLoader();
            ruleLoader.RuleLoaded += ruleLoader_RuleLoaded;

            foreach (IBindingRule bindingRule in ruleLoader.Load(rulesPath))
            {
                _controlledRules.Add(new ControlledRule(bindingRule));
            }
        }

        private static void ruleLoader_RuleLoaded(object sender, RuleLoadedEventArgs e)
        {
        }
    }
}
