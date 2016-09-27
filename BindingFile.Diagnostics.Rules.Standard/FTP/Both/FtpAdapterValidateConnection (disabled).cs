using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Diagnostics.Rules.Standard;
using BindingFile.Adapters;
using System.Xml;
using System.Xml.Linq;

namespace BindingFile.Diagnostics.Rules.Standard
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(FtpAdapterInfo))]
    public class FtpAdapterValidateConnection : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string UserName;
            public string ServerAddress;
            public string ServerPort;
            public string Password;
        }

        public FtpAdapterValidateConnection()
            : base("Validate FTP connection using configuration", true)
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                ValidateReceiveLocationConnection(receiveLocation, messages);
                return;
            }

            TransportInfo sendPortTransport = item as TransportInfo;
            if (sendPortTransport != null)
            {
                ValidateSendPortConnection(sendPortTransport, messages);
                return;
            }

            throw new Exception("Unhandled attribute");
        }

        private void ValidateReceiveLocationConnection(ReceiveLocation receiveLocation, List<Message> messages)
        {
            FtpReceiveAdapterConfig customConfig = new FtpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.ServerAddress = customConfig.ServerAddress;
            cs.ServerPort = customConfig.ServerPort;
            cs.UserName = customConfig.UserName;
            cs.Password = customConfig.Password;

            ValidateConnection(cs, messages);
        }

        private void ValidateSendPortConnection(TransportInfo sendPortTransport, List<Message> messages)
        {
            FtpSendAdapterConfig customConfig = new FtpSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.ServerAddress = customConfig.ServerAddress;
            cs.ServerPort = customConfig.ServerPort;
            cs.UserName = customConfig.UserName;
            cs.Password = customConfig.Password;

            ValidateConnection(cs, messages);
        }

        private void ValidateConnection(ComparisonStruct currentCs, List<Message> messages)
        {
            XDocument configuration = (XDocument)this.ConfigurationAs(typeof(XDocument));

            // Validate server name
            var serversWithValidName = (from s in configuration.Root.Elements("Server")
                                        where s.Element("serverAddress").Value.Equals(currentCs.ServerAddress, StringComparison.InvariantCultureIgnoreCase)
                                        select s).ToList();

            if (serversWithValidName.Count == 0)
            {
                messages.Add(new Message(MessageTypeEnum.Warning, string.Format("Not configured serverAddress: '{0}'", currentCs.ServerAddress)));
                messages.Add(new Message(MessageTypeEnum.Information, "You can copy and paste the following section to the configuration file\r\n" + this.GetConfigurationItem(currentCs)));
                return;
            }

            // Validate authorization mode
            var serversWithValidPort = (from s in serversWithValidName
                                        where s.Element("serverPort").Value == currentCs.ServerPort
                                        select s).ToList();

            if (serversWithValidPort.Count == 0)
            {
                messages.Add(new Message(string.Format("Invalid serverPort: '{0}'", currentCs.ServerPort)));
                return;
            }

            // Validate user name
            var serverWithValidUser = (from s in serversWithValidPort
                                       where s.Element("userName").Value.Equals(currentCs.UserName, StringComparison.InvariantCultureIgnoreCase)
                                       select s).FirstOrDefault();

            if (serverWithValidUser == null)
            {
                messages.Add(new Message(string.Format("Invalid userName: {0}", currentCs.UserName)));
                return;
            }

            var isPasswordValid = (serverWithValidUser.Element("password").Attribute("Hash").Value == currentCs.Password.GetHashCode().ToString());

            if (!isPasswordValid)
            {
                messages.Add(new Message(string.Format("Invalid password: '{0}' (and PassowordHash='{1}')", currentCs.Password, currentCs.Password.GetHashCode().ToString())));
                return;
            }
        }

        private string GetConfigurationItem(ComparisonStruct currentCs)
        {
            XDocument configurationItem = new XDocument(
                new XElement("Server",
                    new XAttribute("Description", ""),
                    new XElement("serverAddress", currentCs.ServerAddress),
                    new XElement("serverPort", currentCs.ServerPort),
                    new XElement("userName", currentCs.UserName),
                    new XElement("password",
                        new XAttribute("Hash", currentCs.Password.GetHashCode())
                        )
                        )
                        );

            return configurationItem.ToString();
        }


    }
}
