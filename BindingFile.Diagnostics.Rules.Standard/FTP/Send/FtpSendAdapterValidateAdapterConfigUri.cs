using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile.Diagnostics.Rules;
using BindingFile;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(FtpAdapterInfo))]
    public class FtpSendAdapterValidateAdapterConfigUri : RuleTemplate
    {
        public FtpSendAdapterValidateAdapterConfigUri()
            : base("Validate FTP send adapter config <uri>")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            FtpSendAdapterConfig customConfig = new FtpSendAdapterConfig(transportInfo.TransportTypeData);

            string expectedUri = customConfig.ConstructUri();

            if (expectedUri != customConfig.Uri)
            {
                string text = string.Format("Custom config <uri> element '{0}' is different from expected value '{1}'. <serverAddress> is '{2}', <serverPort> is '{3}', <targetFolder> is '{4}' and <targetFileName> is '{5}'", customConfig.Uri.Value, expectedUri, customConfig.ServerAddress.Value, customConfig.ServerPort.Value, customConfig.TargetFolder.Value, customConfig.TargetFileName.Value);
                messages.Add(new Message(text));
            }
        }
    }
}
