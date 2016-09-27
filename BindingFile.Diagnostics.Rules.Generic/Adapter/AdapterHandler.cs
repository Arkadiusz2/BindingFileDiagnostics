using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo)]
    public class AdapterHandler : RuleTemplate
    {
        public AdapterHandler()
            : base("Validate adapter handlers")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                if (receiveLocation.ReceiveLocationTransportType != null && receiveLocation.ReceiveHandler != null && receiveLocation.ReceiveHandler.TransportType != null)
                {
                    if (receiveLocation.ReceiveLocationTransportType.Name != receiveLocation.ReceiveHandler.TransportType.Name)
                    {
                        string text = string.Format("/ReceiveLocationTransportType/@Name '{0}' is different from /ReceiveHandler/TransportType/@Name '{1}'", receiveLocation.ReceiveLocationTransportType.Name, receiveLocation.ReceiveHandler.TransportType.Name);
                        messages.Add(new Message(text));
                    }

                    if (receiveLocation.ReceiveLocationTransportType.Capabilities != receiveLocation.ReceiveHandler.TransportType.Capabilities)
                    {
                        string text = string.Format("/ReceiveLocationTransportType/@Capabilities '{0}' is different from /ReceiveHandler/TransportType/@Capabilities '{1}'", receiveLocation.ReceiveLocationTransportType.Capabilities, receiveLocation.ReceiveHandler.TransportType.Capabilities);
                        messages.Add(new Message(text));
                    }

                    if (receiveLocation.ReceiveLocationTransportType.ConfigurationClsid != receiveLocation.ReceiveHandler.TransportType.ConfigurationClsid)
                    {
                        string text = string.Format("/ReceiveLocationTransportType/@ConfigurationClsid '{0}' is different from /ReceiveHandler/TransportType/@ConfigurationClsid '{1}'", receiveLocation.ReceiveLocationTransportType.ConfigurationClsid, receiveLocation.ReceiveLocationTransportType.ConfigurationClsid);
                        messages.Add(new Message(text));
                    }
                }                
                return; 
            }
            
            TransportInfo transport = item as TransportInfo;
            if (transport != null)
            {
                if (transport.TransportType != null && transport.SendHandler != null && transport.SendHandler.TransportType != null)
                {
                    if (transport.TransportType.Name != transport.SendHandler.TransportType.Name)
                    {
                        string text = string.Format("/TransportType/@Name '{0}' is different from /SendHandler/TransportType/@Name '{1}'", transport.TransportType.Name, transport.SendHandler.TransportType.Name);
                        messages.Add(new Message(text));
                    }

                    if (transport.TransportType.Capabilities != transport.SendHandler.TransportType.Capabilities)
                    {
                        string text = string.Format("/TransportType/@Capabilities '{0}' is different from /SendHandler/TransportType/@Capabilities '{1}'", transport.TransportType.Capabilities, transport.SendHandler.TransportType.Capabilities);
                        messages.Add(new Message(text));
                    }

                    if (transport.TransportType.ConfigurationClsid != transport.SendHandler.TransportType.ConfigurationClsid)
                    {
                        string text = string.Format("/TransportType/@ConfigurationClsid '{0}' is different from /SendHandler/TransportType/@ConfigurationClsid '{1}'", transport.TransportType.ConfigurationClsid, transport.SendHandler.TransportType.ConfigurationClsid);
                        messages.Add(new Message(text));
                    }
                }
                return;
            }            

            throw new NotImplementedException(string.Format("Rule cannot handle object type {0}", item.GetType().FullName));
        }
    }
}
