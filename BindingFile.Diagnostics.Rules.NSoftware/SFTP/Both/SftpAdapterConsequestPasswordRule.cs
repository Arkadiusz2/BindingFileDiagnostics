using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Diagnostics.Rules.NSoftware;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftware
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpAdapterConsequentPasswordRule : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string SSHAuthMode;
            public string SSHUser;
            public string SSHHost;
            public string SSHPort;
            public string SSHPassword;
            public string ArtefactTypeName;
            public string ArtefactName;

            public string GetKey()
            {
                return string.Format("{0}@{1}:{2}", SSHUser, SSHHost, SSHPort);
            }
        }

        Dictionary<string, ComparisonStruct> _passwordsComparisonDictionary = new Dictionary<string, ComparisonStruct>();

        public SftpAdapterConsequentPasswordRule()
            : base("Validate SFTP adapter consequent password")
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

            throw new Exception("Unhandled attribute");
        }

        private void ValidateReceiveLocationPassword(ReceiveLocation receiveLocation, List<Message> messages)
        {
            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.SSHAuthMode = customConfig.SSHAuthMode;
            cs.SSHUser = customConfig.SSHUser;
            cs.SSHHost = customConfig.SSHHost;
            cs.SSHPort = customConfig.SSHPort;
            cs.SSHPassword = customConfig.SSHPassword;
            cs.ArtefactTypeName = "Receive Location";
            cs.ArtefactName = receiveLocation.Name;

            ValidatePassword(cs, messages);
        }

        private void ValidateSendPortPassword(TransportInfo sendPortTransport, List<Message> messages)
        {
            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.SSHAuthMode = customConfig.SSHAuthMode;
            cs.SSHUser = customConfig.SSHUser;
            cs.SSHHost = customConfig.SSHHost;
            cs.SSHPort = customConfig.SSHPort;
            cs.SSHPassword = customConfig.SSHPassword;
            cs.ArtefactTypeName = (sendPortTransport.IsPrimary ? "primary" : "secondary") + " transport of Send Port";
            cs.ArtefactName = sendPortTransport.SendPort.Name;

            ValidatePassword(cs, messages);           
        }

        private void ValidatePassword(ComparisonStruct currentCs, List<Message> messages)
        {
            if (currentCs.SSHAuthMode == "2")
            {
                string key = currentCs.GetKey();

                if (!_passwordsComparisonDictionary.ContainsKey(key))
                {
                    _passwordsComparisonDictionary.Add(key, currentCs);
                }

                ComparisonStruct previousCs = _passwordsComparisonDictionary[key];
                if (previousCs.SSHPassword != currentCs.SSHPassword)
                {
                    string text = string.Format("Password <SSHPassword> '{0}' is different from <SSHPassword> '{1}' in {2} '{3}'.", currentCs.SSHPassword, previousCs.SSHPassword, previousCs.ArtefactTypeName, previousCs.ArtefactName);
                    messages.Add(new Message(text));
                }
            }
        }

    }
}
