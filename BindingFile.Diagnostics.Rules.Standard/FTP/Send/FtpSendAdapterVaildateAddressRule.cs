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
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(FtpAdapterInfo))]
    public class FtpSendAdapterVaildateAddressRule : RuleTemplate
    {
        public FtpSendAdapterVaildateAddressRule()
            : base("Validate FTP send adapter address")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            FtpReceiveAdapterConfig customConfig = new FtpReceiveAdapterConfig(transportInfo.TransportTypeData);

            if (transportInfo.Address != customConfig.Uri.Value)
            {               
                string text = string.Format("<Address> element '{0}' is not equal to <uri> element '{1}' in custom configuration", transportInfo.Address, customConfig.Uri);
                messages.Add(new Message(text));
            }
        }
    }
}
