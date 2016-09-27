using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;
using BindingFile;
using System.Threading.Tasks;

namespace BindingFile.Diagnostics.Engine
{
    public class RuleExecutionEngine
    {
        List<IBindingRule> _rules = new List<IBindingRule>();
        Dictionary<object, List<RuleExecutionResult>> _results;

        public event EventHandler<RuleExecutionEventArgs> ItemValidated;

        protected virtual void OnItemValidated(RuleExecutionEventArgs e)
        {
            if (this.ItemValidated != null)
            {
                this.ItemValidated(this, e);
            }
        }
        
        public void Add(IBindingRule rule)
        {
            rule.Validated += new EventHandler<BindingRuleValidationEventArgs>(rule_ItemValidated);
            _rules.Add(rule);
        }

        void rule_ItemValidated(object sender, BindingRuleValidationEventArgs e)
        {
            IBindingRule bindingRule = (IBindingRule)sender;
            if (!e.Success)
            {
                if (!_results.ContainsKey(e.Item))
                {
                    _results.Add(e.Item, new List<RuleExecutionResult>());                    
                }
                _results[e.Item].Add(new RuleExecutionResult(bindingRule, e.Success, e.Messages));
            }
            RuleExecutionEventArgs rea = new RuleExecutionEventArgs(bindingRule, e.Item, e.Success, e.Messages, e.Exception);
            OnItemValidated(rea);
        }

        public void Clear()
        {
            _rules.Clear();
        }
        
        public bool Execute(BindingInfo bindingInfo)
        {
            bool result = true;
            _results = new Dictionary<object, List<RuleExecutionResult>>();

            ParallelLoopResult loopResult = Parallel.ForEach<IBindingRule>(_rules, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (rule, loopState) =>
                {
                    result &= rule.Validate(bindingInfo);
                });

            //foreach (IBindingRule rule in _rules)
            //{                
            //    result &= rule.Validate(bindingInfo);
            //}
            return result;            
        }    
    }
}
