using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(WssAdapterInfo))]
    public class WssReceiveAdapterValidateAddress : RuleTemplate
    {
        public WssReceiveAdapterValidateAddress()
            : base("SharePoint Adapter receive validate address")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            WssReceiveAdapterConfig customConfiguration = new WssReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            if (receiveLocation.Address != customConfiguration.Uri)
            {
                string text = string.Format("<Address> element '{0}' is different from <uri> '{1}' in custom configuration", receiveLocation.Address, customConfiguration.Uri);
                messages.Add(new Message(text));
            }
        }
    }
}
