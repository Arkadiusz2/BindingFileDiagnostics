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
//    public class SftpAdapterReportDeprecatedServer : RuleTemplate
//    {
//        private struct ComparisonStruct
//        {
//            public string SSHHost; 
//        }

//        public SftpAdapterReportDeprecatedServer()
//            : base("Report deprecated server name", true)
//        {
//        }

//        protected override void Validate(object item, List<Message> messages)
//        {
//            ReceiveLocation receiveLocation = item as ReceiveLocation;
//            if (receiveLocation != null)
//            {
//                ValidateReceiveLocation(receiveLocation, messages);
//                return;
//            }

//            TransportInfo sendPortTransport = item as TransportInfo;
//            if (sendPortTransport != null)
//            {
//                ValidateSendPort(sendPortTransport, messages);
//                return;
//            }

//            throw new Exception("Unhandled attribute");
//        }

//        private void ValidateReceiveLocation(ReceiveLocation receiveLocation, List<Message> messages)
//        {
//            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

//            ComparisonStruct cs = new ComparisonStruct();
//            cs.SSHHost = customConfig.SSHHost;

//            Validate(cs, messages);
//        }

//        private void ValidateSendPort(TransportInfo sendPortTransport, List<Message> messages)
//        {
//            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(sendPortTransport.TransportTypeData);

//            ComparisonStruct cs = new ComparisonStruct();
//            cs.SSHHost = customConfig.SSHHost;

//            Validate(cs, messages);
//        }

//        private void Validate(ComparisonStruct currentCs, List<Message> messages)
//        {
//            XDocument configuration = (XDocument)this.ConfigurationAs(typeof(XDocument));

//            // Validate server name
//            var deprecatedServer = (from s in configuration.Root.Elements("Server")
//                                     where s.Element("SSHHost").Value.Equals(currentCs.SSHHost, StringComparison.InvariantCultureIgnoreCase)
//                                     select s).FirstOrDefault();

//            if (deprecatedServer != null)
//            {
//                string text = string.Format("SSHHost '{0}' is deprecated, use '{1}'. Reason: {2}", currentCs.SSHHost, deprecatedServer.Element("NewSSHHost").Value, deprecatedServer.Element("Reason").Value);
//                messages.Add(new Message(MessageTypeEnum.Information, text));
//            }
//        }

//    }
//}
