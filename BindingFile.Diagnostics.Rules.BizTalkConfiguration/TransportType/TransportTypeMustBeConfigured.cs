using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Adapters;
using BindingFile.Diagnostics.Rules;
using OM = Microsoft.BizTalk.ExplorerOM;

namespace BindingFile.Diagnostics.Rules.BizTalkConfiguration
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo)]
    public class TransportTypeMustBeConfigured : RuleTemplate
    {
        private OM.BtsCatalogExplorer _catalogExplorer;
        private IEnumerable<OM.ProtocolType> _adapters;

        #region Constructors
        public TransportTypeMustBeConfigured()
            : base("TransportType must be configured")
        {
            _catalogExplorer = BtsCatalogExplorerFactory.Create();
            _adapters = _catalogExplorer.Adapters();
        }
        #endregion

        private bool IsValidAdapter(string adapterName)
        {
            return _adapters.Where(x => x.Name == adapterName).Any();
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                ProtocolType transportType = receiveLocation.ReceiveLocationTransportType;
                if (transportType != null && transportType.Name != null)
                {
                    if (!IsValidAdapter(transportType.Name))
                    {
                        string text = string.Format("/ReceiveLocationTransportType/@Name '{0}' is not a valid adapter in BizTalk configuration", transportType.Name);
                        messages.Add(new Message(MessageTypeEnum.Warning, text));
                    }
                    else
                    {
                        OM.ProtocolType host = _adapters.First(x => x.Name == transportType.Name);
                        if (transportType.Capabilities != null && transportType.Capabilities != (int)host.Capabilities)
                        {
                            string text = string.Format("/ReceiveLocationTransportType/@Capabilities value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.Capabilities, transportType.Name, (int)host.Capabilities);
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                        if (transportType.ConfigurationClsid != null && transportType.ConfigurationClsid != host.ConfigurationGuid.ToString("D"))
                        {
                            string text = string.Format("/ReceiveLocationTransportType/@ConfigurationClsid value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.ConfigurationClsid, transportType.Name, host.ConfigurationGuid.ToString("D"));
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                    }
                }

                if (receiveLocation.ReceiveHandler != null)
                {
                    transportType = receiveLocation.ReceiveHandler.TransportType;
                    if (transportType != null && transportType.Name != null)
                    {
                        if (!IsValidAdapter(transportType.Name))
                        {
                            string text = string.Format("/ReceiveHandler/TransportType/@Name '{0}' is not a valid adapter in BizTalk configuration", transportType.Name);
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                        else
                        {
                            OM.ProtocolType host = _adapters.First(x => x.Name == transportType.Name);
                            if (transportType.Capabilities != null && transportType.Capabilities != (int)host.Capabilities)
                            {
                                string text = string.Format("/ReceiveHandler/TrasportType/@Capabilities value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.Capabilities, transportType.Name, (int)host.Capabilities);
                                messages.Add(new Message(MessageTypeEnum.Warning, text));
                            }
                            if (transportType.ConfigurationClsid != null && transportType.ConfigurationClsid != host.ConfigurationGuid.ToString("D"))
                            {
                                string text = string.Format("/ReceiveHandler/TransportType/@ConfigurationClsid value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.ConfigurationClsid, transportType.Name, host.ConfigurationGuid.ToString("D"));
                                messages.Add(new Message(MessageTypeEnum.Warning, text));
                            }
                        }
                    }
                }
            }
            else
            {
                TransportInfo transportInfo = item as TransportInfo;
                if (transportInfo != null)
                {
                    ProtocolType transportType = transportInfo.TransportType;
                    if (transportType != null && transportType.Name != null)
                    {
                        if (!IsValidAdapter(transportType.Name))
                        {
                            string text = string.Format("/TransportType/@Name '{0}' is not a valid adapter in BizTalk configuration", transportType.Name);
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                        else
                        {
                            OM.ProtocolType host = _adapters.First(x => x.Name == transportType.Name);
                            if (transportType.Capabilities != null && transportType.Capabilities != (int)host.Capabilities)
                            {
                                string text = string.Format("/TransportType/@Capabilities value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.Capabilities, transportType.Name, (int)host.Capabilities);
                                messages.Add(new Message(MessageTypeEnum.Warning, text));
                            }
                            if (transportType.ConfigurationClsid != null && transportType.ConfigurationClsid != host.ConfigurationGuid.ToString("D"))
                            {
                                string text = string.Format("/TransportType/@ConfigurationClsid value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.Capabilities, transportType.Name, host.ConfigurationGuid.ToString("D"));
                                messages.Add(new Message(MessageTypeEnum.Warning, text));
                            }
                        }
                    }

                    if (transportInfo.SendHandler != null)
                    {
                        transportType = transportInfo.SendHandler.TransportType;
                        if (transportType != null && transportType.Name != null)
                        {
                            if (!IsValidAdapter(transportType.Name))
                            {
                                string text = string.Format("/SendHandler/TransportType/@Name '{0}' is not a valid adapter in BizTalk configuration", transportType.Name);
                                messages.Add(new Message(MessageTypeEnum.Warning, text));
                            }
                            else
                            {
                                OM.ProtocolType host = _adapters.First(x => x.Name == transportType.Name);
                                if (transportType.Capabilities != null && transportType.Capabilities != (int)host.Capabilities)
                                {
                                    string text = string.Format("/SendHandler/TransportType/@Capabilities value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.Capabilities, transportType.Name, (int)host.Capabilities);
                                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                                }
                                if (transportType.ConfigurationClsid != null && transportType.ConfigurationClsid != host.ConfigurationGuid.ToString("D"))
                                {
                                    string text = string.Format("/SendHandler/TransportType/@ConfigurationClsid value '{0}' is not a valid for '{1}' adapter , expected value '{2}'", transportType.Capabilities, transportType.Name, host.ConfigurationGuid.ToString("D"));
                                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
