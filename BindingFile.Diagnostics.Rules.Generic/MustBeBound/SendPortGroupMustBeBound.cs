using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Extensions;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.DistributionList)]
    public class SendPortGroupMustBeBound : RuleTemplate
    {
        public SendPortGroupMustBeBound()
            : base("Send Port Group must be bound")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            DistributionList sendPortGroup = (DistributionList)item;

            if (string.IsNullOrEmpty(sendPortGroup.Filter) && !sendPortGroup.BoundOrchestrations().Any())
            {
                string text = "Send port group has no filter and is not bound to an Orchestration";
                messages.Add(new Message(text));
            }
        }
    }
}
