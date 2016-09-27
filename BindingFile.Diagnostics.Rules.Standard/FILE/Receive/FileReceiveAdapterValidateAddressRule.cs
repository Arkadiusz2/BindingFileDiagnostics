using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(FileAdapterInfo))]
    public class FileReceiveAdapterValidateAddressRule : RuleTemplate
    {
        #region Constructors
        public FileReceiveAdapterValidateAddressRule()
            : base("Validate FILE receive adapter address")
        {
        }
        #endregion

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            FileReceiveAdapterConfig customConfig = new FileReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            if (!receiveLocation.Address.EndsWith(customConfig.FileMask, StringComparison.InvariantCultureIgnoreCase))
            {
                string text = string.Format("<Address> element '{0}' does not end with <FileName> '{1} 'in custom configuration", receiveLocation.Address, customConfig.FileMask);
                messages.Add(new Message(text));
            }
        }
    }
}
