//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using BindingFile;
//using BindingFile.Adapters;
//using BindingFile.Diagnostics.Rules;
//using System.Xml.Linq;

//namespace BindingFile.Diagnostics.Rules.StandardAdapters
//{
//    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(WcfBasicHttpAdapterInfo))]
//    public class WcfBasicHttpSendAdapterValidateProxy : RuleTemplate
//    {
//        private struct ConfigurationStruct
//        {
//            public string Host;
//            public string Protocol;
//            public string ProxyToUse;
//        }

//        #region Constructors
//        public WcfBasicHttpSendAdapterValidateProxy()
//            : base("Validate WCF-BasicHTTP send adapter proxy", true)
//        {
//        }
//        #endregion

//        protected override void Validate(object item, List<Message> messages)
//        {

//            TransportInfo transportInfo = (TransportInfo)item;
//            WcfBasicHttpSendAdapterConfig customConfig = new WcfBasicHttpSendAdapterConfig(transportInfo.TransportTypeData);

//            Uri uri = null;
//            try
//            {
//                uri = new Uri(transportInfo.Address);
//            }
//            catch (UriFormatException)
//            {
//            }

//            if (uri == null)
//            {
//                string text = string.Format("Invalid Address URI: {0}", transportInfo.Address);
//                messages.Add(new Message(text));
//                return;
//            }

//            ConfigurationStruct cs = new ConfigurationStruct();
//            cs.Host = uri.Host;
//            cs.Protocol = uri.Scheme;
//            cs.ProxyToUse = customConfig.ProxyToUse.Value;

//            XDocument configuration = (XDocument)this.ConfigurationAs(typeof(XDocument));

//            var serversWithValidName = (from s in configuration.Root.Elements("Server")
//                                        where s.Element("Host").Value.Equals(cs.Host, StringComparison.InvariantCultureIgnoreCase)
//                                        select s).ToList();

//            if (serversWithValidName.Count == 0)
//            {
//                messages.Add(new Message(MessageTypeEnum.Warning, string.Format("Not configured Host: '{0}'", cs.Host)));
//                messages.Add(new Message(MessageTypeEnum.Information, "You can copy and paste the following section to the configuration file\r\n" + this.GetConfigurationItem(cs)));
//                return;
//            }

//            // Validate authorization mode
//            var serverWithValidProtocol = (from s in serversWithValidName
//                                           where s.Element("Protocol").Value == cs.Protocol
//                                           select s).FirstOrDefault();


//            if (serverWithValidProtocol == null)
//            {
//                messages.Add(new Message(string.Format("Invalid Protocol: '{0}'", cs.Protocol)));
//                return;
//            }

//            if (cs.ProxyToUse != serverWithValidProtocol.Element("ProxyToUse").Value)
//            {
//                messages.Add(new Message(string.Format("Invalid ProxyToUse: '{0}', expected: '{1}'", cs.ProxyToUse, serverWithValidProtocol.Element("ProxyToUse").Value)));
//                return;
//            }
//        }

//        private string GetConfigurationItem(ConfigurationStruct cs)
//        {

//            XDocument configurationItem = new XDocument(
//                new XElement("Server",
//                    new XAttribute("Description", ""),
//                    new XElement("Host", cs.Host),
//                    new XElement("Protocol", cs.Protocol),
//                    new XElement("ProxyToUse", cs.ProxyToUse)));

//            return configurationItem.ToString();
//        }
//    }
//}
