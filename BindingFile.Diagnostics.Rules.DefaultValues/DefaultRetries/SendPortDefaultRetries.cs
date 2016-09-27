using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.DefalutValues
{
    [RuleTargets(RuleTargetsEnum.TransportInfo)]
    public class SendPortDefaultRetries : RuleTemplate
    {
        public SendPortDefaultRetries()
            : base("Send port default retries")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transport = (TransportInfo)item;

            if (transport.SendPort.IsStatic)
            {
                int defaultRetryCountValue = 3;
                if (transport.RetryCount != defaultRetryCountValue)
                {
                    messages.Add(new Message(MessageTypeEnum.Warning, string.Format("Retry count '{0}' not equal to default value '{1}'", transport.RetryCount, defaultRetryCountValue)));
                }

                int defaultRetryIntervalValue = 5;
                if (transport.RetryInterval != defaultRetryIntervalValue)
                {
                    messages.Add(new Message(MessageTypeEnum.Warning, string.Format("Retry interval '{0}' not equal to default value '{1}'", transport.RetryInterval, defaultRetryIntervalValue)));
                }
            }
        }
    }
}
