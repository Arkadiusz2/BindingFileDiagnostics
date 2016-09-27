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
    public class HostMustBeConfigured : RuleTemplate
    {
        private OM.BtsCatalogExplorer _catalogExplorer;

        #region Constructors
        public HostMustBeConfigured()
            : base("Host must be configured")
        {
            _catalogExplorer = BtsCatalogExplorerFactory.Create();
        }
        #endregion

        private bool IsValidHost(string hostName)
        {
            return _catalogExplorer.Hosts[hostName] != null;
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                if (receiveLocation.ReceiveHandler == null || receiveLocation.ReceiveHandler.Name == null)
                {
                    string text = "/ReceiveHandler/@Name is not configured";
                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                }
                else
                {
                    OM.Host host = _catalogExplorer.Hosts[receiveLocation.ReceiveHandler.Name];
                    if (host == null)
                    {
                        string text = string.Format("/ReceiveHandler/@Name '{0}' is not a valid host in BizTalk configuration", receiveLocation.ReceiveHandler.Name);
                        messages.Add(new Message(MessageTypeEnum.Warning, text));
                    }
                    else
                    {
                        bool isTrusted = host.IsTrusted();
                        if (receiveLocation.ReceiveHandler.HostTrusted != isTrusted)
                        {
                            string text = string.Format("/ReceiveHandler/@HostTrusted value '{0}' is not valid for host '{1}', expected value '{2}'", receiveLocation.ReceiveHandler.HostTrusted.ToString().ToLower(), receiveLocation.ReceiveHandler.Name, isTrusted.ToString().ToLower());
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                    }
                }
            }             
            else
            {
                TransportInfo transportInfo = item as TransportInfo;
                if (transportInfo != null && transportInfo.SendPort != null && transportInfo.SendPort.IsStatic && (transportInfo.IsPrimary || transportInfo.Address != null))
                {
                    if (transportInfo.SendHandler == null || transportInfo.SendHandler.Name == null)
                    {
                        string text = "/SendHandler/@Name is not configured";
                        messages.Add(new Message(MessageTypeEnum.Warning, text));
                    }
                    else
                    {
                        OM.Host host = _catalogExplorer.Hosts[transportInfo.SendHandler.Name];
                        if (host == null)
                        {
                            string text = string.Format("/SendHandler/@Name '{0}' is not a valid host in BizTalk configuration", transportInfo.SendHandler.Name);
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                        else
                        {
                            bool isTrusted = host.IsTrusted();
                            if (transportInfo.SendHandler.HostTrusted != isTrusted)
                            {
                                string text = string.Format("/SendHandler/@HostTrusted value '{0}' is not valid for host '{1}', expected value '{2}'", transportInfo.SendHandler.HostTrusted.ToString().ToLower(), transportInfo.SendHandler.Name, isTrusted.ToString().ToLower());
                                messages.Add(new Message(MessageTypeEnum.Warning, text));
                            }
                        }
                    }
                }
            }
        }
    }
}
