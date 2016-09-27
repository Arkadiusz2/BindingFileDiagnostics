using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Extensions;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.ServiceRef)]
    public class OrchestrationMustBeConfigured : RuleTemplate
    {
        private enum BoundToEnum
        {
            None,
            SendPort,
            SendPortGroup,
            ReceivePort
        }

        public OrchestrationMustBeConfigured()
            : base("Orchestration must be configured")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ServiceRef orchestration = (ServiceRef)item;

            if (orchestration.Host == null || string.IsNullOrEmpty(orchestration.Host.Name))
            {
                string text = "Host is not configured";
                messages.Add(new Message(text));
            }

            foreach (ServicePortRef portRef in orchestration.Ports)
            {
                BoundToEnum boundTo = BoundToEnum.None;

                if (portRef.SendPortRef != null && !string.IsNullOrEmpty(portRef.SendPortRef.Name))
                {
                    boundTo = BoundToEnum.SendPort;
                }
                else if (portRef.DistributionListRef != null && !string.IsNullOrEmpty(portRef.DistributionListRef.Name))
                {
                    boundTo = BoundToEnum.SendPortGroup;
                }
                else if (portRef.ReceivePortRef != null && !string.IsNullOrEmpty(portRef.ReceivePortRef.Name))
                {
                    boundTo = BoundToEnum.ReceivePort;
                }

                string text;
                switch (boundTo)
                {
                    case BoundToEnum.None:
                        text = string.Format("Port '{0}' is not configured", portRef.Name);
                        messages.Add(new Message(text));
                        break;

                    case BoundToEnum.ReceivePort:
                        if (!orchestration.Application.BindingInfo.ReceivePortExists(portRef.ReceivePortRef.Name))
                        {
                            text = string.Format("Port '{0}' is bound to undefined receive port '{1}'", portRef.Name, portRef.ReceivePortRef.Name);
                            messages.Add(new Message(text));
                        }
                        break;

                    case BoundToEnum.SendPort:
                        if (!orchestration.Application.BindingInfo.SendPortExists(portRef.SendPortRef.Name))
                        {
                            text = string.Format("Port '{0}' is bound to undefined send port '{1}'", portRef.Name, portRef.SendPortRef.Name);
                            messages.Add(new Message(text));
                        }
                        break;

                    case BoundToEnum.SendPortGroup:
                        if (!orchestration.Application.BindingInfo.SendPortGroupExists(portRef.DistributionListRef.Name))
                        {
                            text = string.Format("Port '{0}' is bound to undefined send port group '{1}'", portRef.Name, portRef.DistributionListRef.Name);
                            messages.Add(new Message(text));
                        }
                        break;
                }
            }
        }
    }
}
