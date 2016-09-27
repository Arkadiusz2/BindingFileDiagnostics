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
    public class HandlerMustBeConfigured : RuleTemplate
    {
        private OM.BtsCatalogExplorer _catalogExplorer;
        private IEnumerable<OM.SendHandler> _sendHandlers;
        private IEnumerable<OM.ReceiveHandler> _receiveHandlers;
        private IEnumerable<OM.Host> _hosts;

        #region Constructors
        public HandlerMustBeConfigured()
            : base("Handler must be configured")
        {
            _catalogExplorer = BtsCatalogExplorerFactory.Create();
            _sendHandlers = _catalogExplorer.SendHandlers.Cast<OM.SendHandler>();
            _receiveHandlers = _catalogExplorer.ReceiveHandlers.Cast<OM.ReceiveHandler>();
        }
        #endregion

        private bool IsValidReceiveHandler(string adapterName, string hostName)
        {
            return (from rh in _receiveHandlers
                    where rh.Host.Name == hostName && rh.TransportType.Name == adapterName
                    select rh).Any();
                            
        }

        private bool IsValidSendHandler(string adapterName, string hostName)
        {
            return (from sh in _sendHandlers
                    where sh.Host.Name == hostName && sh.TransportType.Name == adapterName
                    select sh).Any();
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                if (receiveLocation.ReceiveHandler != null && receiveLocation.ReceiveHandler.TransportType != null)
                {
                    if (!IsValidReceiveHandler(receiveLocation.ReceiveHandler.TransportType.Name, receiveLocation.ReceiveHandler.Name))
                    {
                        string text = string.Format("/ReceiveHandler/@Name host '{0}' is not configured for adapter /ReceiveHandler/TransportType/@Name '{1}'", receiveLocation.ReceiveHandler.Name, receiveLocation.ReceiveHandler.TransportType.Name);
                        messages.Add(new Message(MessageTypeEnum.Warning, text));
                    }
                }
            }
            else
            {
                TransportInfo transportInfo = item as TransportInfo;
                if (transportInfo != null && transportInfo.SendPort != null && transportInfo.SendPort.IsStatic && (transportInfo.IsPrimary || transportInfo.Address != null))
                {
                    if (transportInfo.SendHandler != null && transportInfo.SendHandler.TransportType != null)
                    {
                        if (!IsValidSendHandler(transportInfo.SendHandler.TransportType.Name, transportInfo.SendHandler.Name))
                        {
                            string text = string.Format("/SendHandler/@Name host '{0}' is not configured for adapter /SendHandler/TransportType/@Name '{1}'", transportInfo.SendHandler.Name, transportInfo.SendHandler.TransportType.Name);
                            messages.Add(new Message(MessageTypeEnum.Warning, text));
                        }
                    }

                }
            }
        }
    }
}
