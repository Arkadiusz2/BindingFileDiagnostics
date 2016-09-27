using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.Standard
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(FtpAdapterInfo))]
    public class FtpReceiveAdapterValidatePasswordRule : RuleTemplate
    {
        #region Constructors
        public FtpReceiveAdapterValidatePasswordRule()
            : base("Validate FTP receive adapter password")
        {
        }
        #endregion

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            FtpReceiveAdapterConfig customConfig = new FtpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            if (!customConfig.UserName.Exists || string.IsNullOrWhiteSpace(customConfig.UserName.Value))
            {
                string userName = customConfig.UserName.Exists ? customConfig.UserName.Value : "<null>";
                messages.Add(new Message(string.Format("FTP UserName is not defined in <UserName> element, current value '{0}'.", userName)));
            }
            
            // When mode is set, password must exist and password must be defined, when password consists of asterisks '*' only it means it is not defined
            if (!customConfig.Password.Exists || customConfig.Password.Value.TrimEnd('*') == string.Empty)
            {
                string password = customConfig.Password.Exists ? customConfig.Password.Value : "<null>";
                messages.Add(new Message(string.Format("FTP Password is not defined in <Password> element, current value '{0}'.", password)));
            }
        }
    }
}
