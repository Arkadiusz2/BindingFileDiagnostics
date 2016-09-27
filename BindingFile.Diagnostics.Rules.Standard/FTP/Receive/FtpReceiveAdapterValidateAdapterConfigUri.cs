using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile.Diagnostics.Rules;

using BindingFile;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(FtpAdapterInfo))]
    public class FtpReceiveAdapterValidateAdapterConfigUri : RuleTemplate
    {
        public FtpReceiveAdapterValidateAdapterConfigUri()
            : base("Validate FTP receive adapter config <uri>")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            FtpReceiveAdapterConfig customConfig = new FtpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            string expectedUri = customConfig.ConstructUri();
                
            if (expectedUri != customConfig.Uri)
            {
                string text = string.Format("Custom config <uri> element '{0}' is different from expected value '{1}'. <serverAddress> is '{2}', <serverPort> is '{3}', <targetFolder> is '{4}' and <fileMask> is '{5}'", customConfig.Uri, expectedUri, customConfig.ServerAddress, customConfig.ServerPort, customConfig.TargetFolder, customConfig.FileMask);
                messages.Add(new Message(MessageTypeEnum.Error, text));
            }
        }
    }
}
