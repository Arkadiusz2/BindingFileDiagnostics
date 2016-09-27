using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Extensions;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.ReceivePort)]
    public class ReceivePortMustBeBound : RuleTemplate
    {
        public ReceivePortMustBeBound()
            : base("Receive Port must be bound")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceivePort receivePort = (ReceivePort)item;

            if (!receivePort.BoundOrchestrations().Any() && !receivePort.FilteredBySendPorts().Any() && !receivePort.FilteredBySendPortGroups().Any())                
            {
                string text = "Receive port is not bound to an orchestration and is not filtred by a send port or send port group.";
                messages.Add(new Message(MessageTypeEnum.Warning, text));
            }
        }
    }
}
