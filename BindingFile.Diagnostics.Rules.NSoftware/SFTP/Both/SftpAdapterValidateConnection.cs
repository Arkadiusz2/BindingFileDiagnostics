//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using BindingFile;
//using BindingFile.Diagnostics.Rules;
//using BindingFile.Diagnostics.Rules.NSoftwareAdapters;
//using BindingFile.Adapters;
//using System.Xml;
//using System.Xml.Linq;

//namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
//{
//    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
//    public class SftpAdapterValidateConnection : RuleTemplate
//    {
//        private struct ComparisonStruct
//        {
//            public string SSHAuthMode;
//            public string SSHUser;
//            public string SSHHost;
//            public string SSHPort;
//            public string SSHPassword;
//        }

//        public SftpAdapterValidateConnection()
//            : base("Validate nSoftware SFTP connection using configuration", true)
//        {
//        }

//        protected override void Validate(object item, List<Message> messages)
//        {
//            ReceiveLocation receiveLocation = item as ReceiveLocation;
//            if (receiveLocation != null)
//            {
//                ValidateReceiveLocationConnection(receiveLocation, messages);
//                return;
//            }

//            TransportInfo sendPortTransport = item as TransportInfo;
//            if (sendPortTransport != null)
//            {
//                ValidateSendPortConnection(sendPortTransport, messages);
//                return;
//            }

//            throw new Exception("Unhandled attribute");
//        }

//        private void ValidateReceiveLocationConnection(ReceiveLocation receiveLocation, List<Message> messages)
//        {
//            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

//            ComparisonStruct cs = new ComparisonStruct();
//            cs.SSHAuthMode = customConfig.SSHAuthMode;
//            cs.SSHUser = customConfig.SSHUser;
//            cs.SSHHost = customConfig.SSHHost;
//            cs.SSHPort = customConfig.SSHPort;
//            cs.SSHPassword = customConfig.SSHPassword;

//            ValidateConnection(cs, messages);
//        }

//        private void ValidateSendPortConnection(TransportInfo sendPortTransport, List<Message> messages)
//        {
//            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(sendPortTransport.TransportTypeData);

//            ComparisonStruct cs = new ComparisonStruct();
//            cs.SSHAuthMode = customConfig.SSHAuthMode;
//            cs.SSHUser = customConfig.SSHUser;
//            cs.SSHHost = customConfig.SSHHost;
//            cs.SSHPort = customConfig.SSHPort;
//            cs.SSHPassword = customConfig.SSHPassword;

//            ValidateConnection(cs, messages);
//        }

//        private void ValidateConnection(ComparisonStruct currentCs, List<Message> messages)
//        {
//            XDocument configuration = (XDocument)this.ConfigurationAs(typeof(XDocument));

//            // Validate server name
//            var serversWithValidName = (from s in configuration.Root.Elements("Server")
//                                        where s.Element("SSHHost").Value.Equals(currentCs.SSHHost, StringComparison.InvariantCultureIgnoreCase)
//                                        select s).ToList();

//            if (serversWithValidName.Count == 0)
//            {
//                messages.Add(new Message(MessageTypeEnum.Warning, string.Format("Not configured SSHHost: '{0}'", currentCs.SSHHost)));
//                messages.Add(new Message(MessageTypeEnum.Information, "You can copy and paste the following section to the configuration file\r\n" + this.GetConfigurationItem(currentCs)));
//                return;
//            }

//            // Validate authorization mode
//            var serversWithValidPort = (from s in serversWithValidName
//                                            where s.Element("SSHPort").Value == currentCs.SSHPort
//                                            select s).ToList();

//            if (serversWithValidPort.Count == 0)
//            {
//                messages.Add(new Message(string.Format("Invalid SSHPort: '{0}'", currentCs.SSHPort)));
//                return;
//            }

//            // Validate authorization mode
//            var serversWithValidAuthMode = (from s in serversWithValidPort
//                                            where s.Element("SSHAuthMode").Value == currentCs.SSHAuthMode
//                                            select s).ToList();

//            if (serversWithValidAuthMode.Count == 0)
//            {
//                messages.Add(new Message(string.Format("Invalid SSHAuthMode: '{0}'", currentCs.SSHAuthMode)));
//                return;
//            }

//            // Validate user name
//            var serverWithValidUser = (from s in serversWithValidAuthMode
//                                       where s.Element("SSHUser").Value == currentCs.SSHUser
//                                       select s).FirstOrDefault();

//            if (serverWithValidUser == null)
//            {
//                messages.Add(new Message(string.Format("Invalid SSHUser: {0}", currentCs.SSHUser)));
//                return;
//            }

//            if (currentCs.SSHAuthMode == "2")
//            {
//                var isPasswordValid = (serverWithValidUser.Element("SSHPassword").Attribute("Hash").Value == currentCs.SSHPassword.GetHashCode().ToString());

//                if (!isPasswordValid)
//                {
//                    messages.Add(new Message(string.Format("Invalid SSHPassword: '{0}' (and PassowordHash='{1}')", currentCs.SSHPassword, currentCs.SSHPassword.GetHashCode().ToString())));
//                    return;
//                }
//            }
//        }

//        private string GetConfigurationItem(ComparisonStruct currentCs)
//        { 

//            XDocument configurationItem = new XDocument(
//                new XElement("Server",
//                    new XAttribute("Description", ""),
//                    new XElement("SSHHost", currentCs.SSHHost),
//                    new XElement("SSHPort", currentCs.SSHPort),
//                    new XElement("SSHAuthMode", currentCs.SSHAuthMode),
//                    new XElement("SSHUser", currentCs.SSHUser),
//                    new XElement("SSHPassword",
//                        new XAttribute("Hash", currentCs.SSHPassword.GetHashCode())
//                        )
//                        )
//                        );

//            return configurationItem.ToString();
//        }

//    }
//}
