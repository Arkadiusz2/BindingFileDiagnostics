using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.SsoAffiliates
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpAdapterSSOAffiliateMustExist : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string SSOAffiliate;
            public string HostInstance;
        }

        private IEnumerable<SSOAffiliateApplication> _ssoApplications;

        public SftpAdapterSSOAffiliateMustExist()
            : base("SSOAffiliate Application for SFTP adapter must exist")
        {
            _ssoApplications = (new SSOAffiliateApplications()).Appliations;
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                ValidateReceiveLocation(receiveLocation, messages);
                return;
            }

            TransportInfo sendPortTransport = item as TransportInfo;
            if (sendPortTransport != null)
            {
                ValidateSendPort(sendPortTransport, messages);
                return;
            }

            throw new Exception("Unhandled attribute");
        }

        private void ValidateReceiveLocation(ReceiveLocation receiveLocation, List<Message> messages)
        {
            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.SSOAffiliate = customConfig.SSOAffiliate;
            cs.HostInstance = receiveLocation.ReceiveHandler.Name;

            Validate(cs, messages);
        }

        private void ValidateSendPort(TransportInfo sendPortTransport, List<Message> messages)
        {
            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.SSOAffiliate = customConfig.SSOAffiliate;
            cs.HostInstance = sendPortTransport.SendHandler.Name;

            Validate(cs, messages);
        }

        private void Validate(ComparisonStruct currentCs, List<Message> messages)
        {
            if (_ssoApplications.FirstOrDefault(x => x.Application.Equals(currentCs.SSOAffiliate)) == null)
            {
                string text = string.Format("SSO Affiliate application '{0}' is not configured in SSO", currentCs.SSOAffiliate);
                messages.Add(new Message(MessageTypeEnum.Warning, text));
            }
            //else
            //{

            //}
        }

    }
}
