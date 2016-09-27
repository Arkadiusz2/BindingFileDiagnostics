using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.Standard
{
    [RuleTargets(RuleTargetsEnum.All)]
    public class ConfiguredRule : RuleTemplate
    {
        #region Constructors
        public ConfiguredRule()
            : base("Configured rule", true)
        {
        }
        #endregion

        protected override void Validate(object item, List<Message> messages)
        {
            messages.Add(new Message(MessageTypeEnum.Information, this.Configuration.OuterXml));
        }
    }
}
