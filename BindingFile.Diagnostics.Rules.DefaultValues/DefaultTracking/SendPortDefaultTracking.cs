using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.DefalutValues
{
    [RuleTargets(RuleTargetsEnum.SendPort)]
    public class SendPortDefaultTracking : RuleTemplate
    {
        public SendPortDefaultTracking()
            : base("Send port default tracking")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            SendPort sendPort = (SendPort)item;

            int defaultTrackingValue = 0;

            if (sendPort.Tracking != defaultTrackingValue)
            {
                string text = string.Format("Tracking '{0}' not equal to default value '{1}'", sendPort.Tracking, defaultTrackingValue);
                messages.Add(new Message(MessageTypeEnum.Warning, text));
            }
        }
    }
}
