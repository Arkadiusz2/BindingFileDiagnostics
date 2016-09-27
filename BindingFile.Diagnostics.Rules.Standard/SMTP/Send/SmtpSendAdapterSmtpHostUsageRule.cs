using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(SmtpAdapterInfo))]
    public class SmtpSendAdapterSmtpHostUsageRule : RuleTemplate
    {
        #region Constructors
        public SmtpSendAdapterSmtpHostUsageRule()
            : base("Discourage SMTP host on send port level")
        {
        }
        #endregion

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            SmtpSendAdapterConfig customConfig = new SmtpSendAdapterConfig(transportInfo.TransportTypeData);

            if (!string.IsNullOrEmpty(customConfig.SMTPHost.Value))
            {
                string text = string.Format("<SMTPhost> element '{0}' is defined on port level. Clear this value to use SMTP host defined for SMTP adapter.", customConfig.SMTPHost);
                messages.Add(new Message(text));
            }
        }
    }
}