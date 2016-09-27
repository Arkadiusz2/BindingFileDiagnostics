using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.DefalutValues
{
    [RuleTargets(RuleTargetsEnum.ReceivePort)]
    public class ReceivePortDefaultTracking : RuleTemplate
    {
        public ReceivePortDefaultTracking()
            : base("Receive port default tracking")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceivePort receivePort = (ReceivePort)item;

            int defaultTrackingValue = 0;

            if (receivePort.Tracking != defaultTrackingValue)
            {
                string text = string.Format("Tracking '{0}' not equal to default value '{1}'", receivePort.Tracking, defaultTrackingValue);
                messages.Add(new Message(MessageTypeEnum.Warning, text));
            }
        }
    }
}
