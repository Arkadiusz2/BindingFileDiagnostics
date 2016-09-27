using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.StandardAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(WssAdapterInfo))]
    public class WssAdapterValidateProtocol : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string SiteUrl;
            public string Uri;
            public string ArtefactTypeName;
            public string ArtefactName;
        }

        Dictionary<string, ComparisonStruct> _passwordsComparisonDictionary = new Dictionary<string, ComparisonStruct>();

        public WssAdapterValidateProtocol()
            : base("Validate SharePoint adapter protocol")
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
            WssReceiveAdapterConfig customConfig = new WssReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.SiteUrl = customConfig.SiteUrl;
            cs.Uri = customConfig.Uri;
            cs.ArtefactTypeName = "Receive Location";
            cs.ArtefactName = receiveLocation.Name;

            ValidateProtocol(cs, messages);
        }

        private void ValidateSendPortPassword(TransportInfo sendPortTransport, List<Message> messages)
        {
            WssSendAdapterConfig customConfig = new WssSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.SiteUrl = customConfig.SiteUrl;
            cs.Uri = customConfig.Uri;
            cs.ArtefactTypeName = (sendPortTransport.IsPrimary ? "primary" : "secondary") + " transport of Send Port";
            cs.ArtefactName = sendPortTransport.SendPort.Name;

            ValidateProtocol(cs, messages);           
        }

        private void ValidateProtocol(ComparisonStruct currentCs, List<Message> messages)
        {
            string text;

            if (!currentCs.Uri.StartsWith("wss://", StringComparison.InvariantCultureIgnoreCase) && !currentCs.Uri.StartsWith("wsss://", StringComparison.InvariantCultureIgnoreCase))
            {
                text = string.Format("Invalid prefix is used in <uri> '{0}'. Expected: 'wss://' or 'wsss://'.", currentCs.Uri);
                messages.Add(new Message(text));
            }

            if (!currentCs.SiteUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) && !currentCs.SiteUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            {
                text = string.Format("Invalid prefix is used in <SiteUrl> '{0}'. Expected: 'http://' or 'https://'.", currentCs.Uri);
                messages.Add(new Message(text));
            }

            if (messages.Count == 0)
            {
                if (currentCs.Uri.StartsWith("wss://", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!currentCs.SiteUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
                    {
                        text = string.Format("Prefix used in <uri> '{0}' does not match prefix used in <SiteUrl> '{1}'. For <uri> starting with 'wss://' you need <SiteUrl> that starts with 'http://'.", currentCs.SiteUrl, currentCs.Uri);
                        messages.Add(new Message(text));
                    }
                }
                else if (currentCs.Uri.StartsWith("wsss://", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!currentCs.SiteUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
                    {
                        text = string.Format("Prefix used in <uri> '{0}' does not match prefix used in <SiteUrl> '{1}'. For <uri> starting with 'wsss://' you need <SiteUrl> that starts with 'https://'.", currentCs.SiteUrl, currentCs.Uri);
                        messages.Add(new Message(text));
                    }
                }
            }
        }

    }
}
