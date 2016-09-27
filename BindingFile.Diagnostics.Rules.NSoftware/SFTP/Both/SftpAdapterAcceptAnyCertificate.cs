using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Diagnostics.Rules.NSoftwareAdapters;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpAdapterAcceptAnyCertificateRule : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string AcceptAny;
            public string ArtefactTypeName;
            public string ArtefactName;
        }

        public SftpAdapterAcceptAnyCertificateRule()
            : base("Validate SFTP adapter accepts any SSH certificate")
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
            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.AcceptAny = customConfig.SSHAcceptServerHostKey_AcceptAny;
            cs.ArtefactTypeName = "Receive Location";
            cs.ArtefactName = receiveLocation.Name;

            ValidateAnyCertificateIsAccepted(cs, messages);
        }

        private void ValidateSendPortPassword(TransportInfo sendPortTransport, List<Message> messages)
        {
            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.AcceptAny = customConfig.SSHAcceptServerHostKey_AcceptAny;
            cs.ArtefactTypeName = (sendPortTransport.IsPrimary ? "primary" : "secondary") + " transport of Send Port";
            cs.ArtefactName = sendPortTransport.SendPort.Name;

            ValidateAnyCertificateIsAccepted(cs, messages);           
        }

        private void ValidateAnyCertificateIsAccepted(ComparisonStruct currentCs, List<Message> messages)
        {
            if (currentCs.AcceptAny != "True")
            {
                string text = string.Format("{0} {1} is not set up to accept any SSH Certificate. <AcceptAny> element's value should be 'True', but is '{2}'", currentCs.ArtefactTypeName, currentCs.ArtefactName, currentCs.AcceptAny);
                messages.Add(new Message(text));
            }
        }

    }
}
