using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Extensions;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.SendPort)]
    public class SendPortMustBeBound : RuleTemplate
    {
        public SendPortMustBeBound()
            : base("Send Port must be bound")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            SendPort sendPort = (SendPort)item;

            if (string.IsNullOrEmpty(sendPort.Filter) && !sendPort.BoundOrchestrations().Any() && !sendPort.BoundSendPortGroups().Any())
            {
                string text = "Send port has no filter and is not bound to an Orchestration or a Send Port Group";
                messages.Add(new Message(text));
            }
        }
    }
}
