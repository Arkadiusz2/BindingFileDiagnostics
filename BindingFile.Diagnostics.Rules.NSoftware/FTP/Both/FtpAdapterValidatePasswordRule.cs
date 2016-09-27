using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Diagnostics.Rules.NSoftwareAdapters;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(FtpV4AdapterInfo), typeof(FtpV3AdapterInfo))]
    public class FtpAdapterValidatePasswordRule : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string UserName;
            public string Password;
        }

        Dictionary<string, ComparisonStruct> _passwordsComparisonDictionary = new Dictionary<string, ComparisonStruct>();

        public FtpAdapterValidatePasswordRule()
            : base("Validate nsfotware FTP password")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                ValidateReceiveLocationPassword(receiveLocation, messages);
                return;
            }

            TransportInfo sendPortTransport = item as TransportInfo;
            if (sendPortTransport != null)
            {
                ValidateSendPortPassword(sendPortTransport, messages);
                return;
            }

            throw new NotImplementedException(string.Format("Rule cannot handle object type {0}", item.GetType().FullName));
        }

        private void ValidateReceiveLocationPassword(ReceiveLocation receiveLocation, List<Message> messages)
        {
            FtpReceiveAdapterConfig customConfig = new FtpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.UserName = customConfig.User;
            cs.Password = customConfig.Password;

            ValidatePassword(cs, messages);
        }

        private void ValidateSendPortPassword(TransportInfo sendPortTransport, List<Message> messages)
        {
            FtpSendAdapterConfig customConfig = new FtpSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.UserName = customConfig.User;
            cs.Password = customConfig.Password;

            ValidatePassword(cs, messages);
        }

        private void ValidatePassword(ComparisonStruct currentCs, List<Message> messages)
        {
            if (currentCs.UserName == "")
            {
                string text = string.Format("FTP User is not defined in <User> element, current value '{0}'.", currentCs.UserName);
                messages.Add(new Message(text));
            }

            // When mode is set, password must exist and password must be defined, when password consists of asterisks '*' only it means it is not defined
            if (currentCs.Password == "" || currentCs.Password.TrimEnd('*') == string.Empty)
            {
                string text = string.Format("FTP Password is not defined in <Password> element, current value '{0}'.", currentCs.Password);
                messages.Add(new Message(text));
            }
        }

    }
}
