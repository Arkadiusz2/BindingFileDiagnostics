using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using System.ComponentModel;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{    
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(FtpAdapterInfo))]
    public class FtpReceiveAdapterVaildateAddressRule : RuleTemplate
    {
        public FtpReceiveAdapterVaildateAddressRule()
            : base("Validate FTP receive adapter address")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            FtpReceiveAdapterConfig customConfig = new FtpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            if (receiveLocation.Address != customConfig.Uri.Value)
            {
                string text = string.Format("<Address> element '{0}' is not equal to <uri> element '{1}' in custom configuration", receiveLocation.Address, customConfig.Uri);
                messages.Add(new Message(MessageTypeEnum.Error, text));
            }
        }
    }
}
