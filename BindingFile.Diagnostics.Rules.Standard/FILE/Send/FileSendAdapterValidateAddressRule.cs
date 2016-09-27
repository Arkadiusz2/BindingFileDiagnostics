using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(FileAdapterInfo))]
    public class FileSendAdapterValidateAddressRule : RuleTemplate
    {
        #region Constructors
        public FileSendAdapterValidateAddressRule()
            : base("Validate FILE send adapter address")
        {
        }
        #endregion

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            FileSendAdapterConfig customConfig = new FileSendAdapterConfig(transportInfo.TransportTypeData);

            if (!transportInfo.Address.EndsWith(customConfig.FileName, StringComparison.InvariantCultureIgnoreCase))
            {
                string text = string.Format("<Address> element '{0}' does not end with <FileName> '{1} 'in custom configuration", transportInfo.Address, customConfig.FileName);
                messages.Add(new Message(MessageTypeEnum.Error, text));                
            }
        }
    }
}
