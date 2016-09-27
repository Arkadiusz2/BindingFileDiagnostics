using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;

using BindingFile;
using System.ComponentModel;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
{
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpSendAdapterVaildateAddressRule : RuleTemplate
    {
        public SftpSendAdapterVaildateAddressRule()
            : base("Validate SFTP send adapter address")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(transportInfo.TransportTypeData);

            if (transportInfo.Address != customConfig.Uri.Value)
            {
                string transportOrder = transportInfo.IsPrimary ? "primary" : "secondary";
                string text = string.Format("<Address> element '{0}' is not equal to <uri> element '{1}' in custom configuration of {2} transport", transportInfo.Address, customConfig.Uri, transportOrder);
                messages.Add(new Message(text));
            }
        }
    }
}
