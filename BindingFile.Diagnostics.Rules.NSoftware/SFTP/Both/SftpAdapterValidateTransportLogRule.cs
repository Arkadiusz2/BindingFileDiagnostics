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
    public class SftpAdapterValidateTransportLogRule : RuleTemplate
    {
        private struct ComparisonStruct
        {
            public string TransportLog_Location;
            public string TransportLog_LogMode;
            public string TransportLog_LogType;
        }

        Dictionary<string, ComparisonStruct> _passwordsComparisonDictionary = new Dictionary<string, ComparisonStruct>();

        public SftpAdapterValidateTransportLogRule()
            : base("Validate SFTP adapter logging")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                ValidateReceiveLocationLogging(receiveLocation, messages);
                return;
            }

            TransportInfo sendPortTransport = item as TransportInfo;
            if (sendPortTransport != null)
            {
                ValidateSendPortLogging(sendPortTransport, messages);
                return;
            }

            throw new Exception("Unhandled attribute");
        }

        private void ValidateReceiveLocationLogging(ReceiveLocation receiveLocation, List<Message> messages)
        {
            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.TransportLog_Location = customConfig.TransportLog_Location;
            cs.TransportLog_LogMode = customConfig.TransportLog_LogMode;
            cs.TransportLog_LogType = customConfig.TransportLog_LogType;

            ValidateLogging(cs, messages);
        }

        private void ValidateSendPortLogging(TransportInfo sendPortTransport, List<Message> messages)
        {
            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(sendPortTransport.TransportTypeData);

            ComparisonStruct cs = new ComparisonStruct();
            cs.TransportLog_Location = customConfig.TransportLog_Location;
            cs.TransportLog_LogMode = customConfig.TransportLog_LogMode;
            cs.TransportLog_LogType = customConfig.TransportLog_LogType;

            ValidateLogging(cs, messages);
        }

        private void ValidateLogging(ComparisonStruct currentCs, List<Message> messages)
        {
            string text;
            if (!currentCs.TransportLog_LogType.Equals("1", StringComparison.InvariantCulture))
            {
                text = string.Format("TransportLog\\LogType '{0}' is not equal to '1' (Event Log)", currentCs.TransportLog_LogType);
                messages.Add(new Message(text));
            }

            if (!currentCs.TransportLog_LogMode.Equals("3", StringComparison.InvariantCulture))
            {
                text = string.Format("TransportLog\\LogMode '{0}' is not equal to '3' (Error)", currentCs.TransportLog_LogMode);
                messages.Add(new Message(text));
            }
            
            if (!currentCs.TransportLog_Location.Equals("Application", StringComparison.InvariantCulture))
            {
                text = string.Format("TransportLog\\Location '{0}' is not equal to 'Application'", currentCs.TransportLog_Location);
                messages.Add(new Message(text));
            }
        }

    }
}
