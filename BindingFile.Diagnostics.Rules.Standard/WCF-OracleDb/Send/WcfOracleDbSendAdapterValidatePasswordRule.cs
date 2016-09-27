using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(WcfOracleDbAdapterInfo))]
    public class WcfOracleDbSendAdapterValidatePasswordRule : RuleTemplate
    {
        #region Constructors
        public WcfOracleDbSendAdapterValidatePasswordRule()
            : base("Validate WCF-OracleDb send adapter password")
        {
        }
        #endregion

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            WcfOracleDbSendAdapterConfig customConfig = new WcfOracleDbSendAdapterConfig(transportInfo.TransportTypeData);
            
            string text;

            if (!customConfig.UserName.Exists || string.IsNullOrWhiteSpace(customConfig.UserName.Value))
            {                
                string userName = customConfig.UserName.Exists ? customConfig.UserName.Value : "<null>";
                text = string.Format("UserName is not defined in <UserName> element, current value '{0}'.", userName);
                messages.Add(new Message(text));
            }

            // When mode is set, password must exist and password must be defined, when password consists of asterisks '*' only it means it is not defined
            if (!customConfig.Password.Exists || customConfig.Password.Value.TrimEnd('*') == string.Empty)
            {
                string password = customConfig.Password.Exists ? customConfig.Password.Value : "<null>";
                text = string.Format("Password is not defined in <Password> element, current value '{0}'.", password);
                messages.Add(new Message(text));
            }
        }
    }
}
