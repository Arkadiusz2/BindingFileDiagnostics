using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.DefalutValues
{
    [RuleTargets(RuleTargetsEnum.ServiceRef)]
    public class OrchestrationDefaultTracking : RuleTemplate
    {
        public OrchestrationDefaultTracking()
            : base("Orchestration default tracking")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ServiceRef orchestration = (ServiceRef)item;

            OrchestrationTrackingTypes defaultTrackingOption = OrchestrationTrackingTypes.ServiceStartEnd | OrchestrationTrackingTypes.MessageSendReceive | OrchestrationTrackingTypes.OrchestrationEvents;

            if (orchestration.TrackingOption != defaultTrackingOption)
            {
                string text = string.Format("Tracking option '{0}' is not equal to default option '{1}'", orchestration.TrackingOption.ToString().Replace(",", ""), defaultTrackingOption.ToString().Replace(",", ""));
                messages.Add(new Message(MessageTypeEnum.Warning, text));
            }
        }
    }
}
