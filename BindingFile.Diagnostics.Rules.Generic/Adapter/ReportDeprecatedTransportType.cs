//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using BindingFile;
//using BindingFile.Diagnostics.Rules;
//using System.Xml.Linq;

//namespace BindingFile.Diagnostics.Rules.Generic
//{
//    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo)]
//    public class ReportDeprecatedTransportType : RuleTemplate
//    {
//        public ReportDeprecatedTransportType()
//            : base("Report deprecated transport type", true)
//        {
//        }

//        private struct ComparisonStruct
//        {
//            public string AdapterName;
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

//            ComparisonStruct cs = new ComparisonStruct();
//            cs.AdapterName = receiveLocation.ReceiveLocationTransportType.Name;

//            Validate(cs, messages);
//        }

//        private void ValidateSendPort(TransportInfo sendPortTransport, List<Message> messages)
//        {
//            ComparisonStruct cs = new ComparisonStruct();
//            cs.AdapterName = sendPortTransport.TransportType.Name;

//            Validate(cs, messages);
//        }

//        private void Validate(ComparisonStruct currentCs, List<Message> messages)
//        {
//            XDocument configuration = (XDocument)this.ConfigurationAs(typeof(XDocument));

//            // Validate server name
//            var deprecatedServer = (from s in configuration.Root.Elements("TransportType")
//                                    where s.Attribute("Name").Value.Equals(currentCs.AdapterName, StringComparison.InvariantCultureIgnoreCase)
//                                    select s).FirstOrDefault();

//            if (deprecatedServer != null)
//            {
//                string text = string.Format("Transport type '{0}' is deprecated", currentCs.AdapterName);
//                messages.Add(new Message(MessageTypeEnum.Information, text));
//            }
//        }
//    }
//}
