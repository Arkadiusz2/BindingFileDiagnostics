using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using System.ComponentModel;
using BindingFile.Diagnostics.Rules;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpReceiveAdapterVaildateAddressRule : RuleTemplate
    {
        public SftpReceiveAdapterVaildateAddressRule()
            : base("Validate SFTP receive adapter address")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            if (receiveLocation.Address != customConfig.Uri.Value)
            {
                string text = string.Format("<Address> element '{0}' is not equal to <uri> element '{1}' in custom configuration", receiveLocation.Address, customConfig.Uri);
                messages.Add(new Message(text));
            }
        }
    }
}
