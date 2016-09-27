using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Diagnostics.Rules;
using BindingFile.Extensions;

namespace BindingFile.Diagnostics.Rules.DefalutValues
{
    [RuleTargets(RuleTargetsEnum.SendPort | RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.ReceivePort)]
    public class PipelineDefaultTracking : RuleTemplate
    {
        public PipelineDefaultTracking()
            : base("Pipeline default tracking")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            PipelineTrackingTypes defaultTrackingOption = PipelineTrackingTypes.ServiceStartEnd | PipelineTrackingTypes.MessageSendReceive | PipelineTrackingTypes.PipelineEvents;
            
            string text;            
            
            SendPort sendPort = item as SendPort;
            if (sendPort != null)
            {
                if (sendPort.TransmitPipeline.TrackingOption != defaultTrackingOption)
                {
                    text = string.Format("Transmit pipeline's '{0}' tracking option '{1}' is not equal to default value '{2}'", sendPort.TransmitPipeline.Name, sendPort.TransmitPipeline.TrackingOption.ToString().Replace(",", ""), defaultTrackingOption.ToString().Replace(",", ""));
                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                }
                
                if (sendPort.ReceivePipeline.Name != null && sendPort.ReceivePipeline.TrackingOption != defaultTrackingOption)
                {
                    text = string.Format("Receive pipeline's '{0}' tracking option '{1}' is not equal to default value '{2}'", sendPort.ReceivePipeline.Name, sendPort.ReceivePipeline.TrackingOption.ToString().Replace(",", ""), defaultTrackingOption.ToString().Replace(",", ""));
                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                }
                return;
            }

            ReceiveLocation receiveLocation = item as ReceiveLocation;
            if (receiveLocation != null)
            {
                if (receiveLocation.ReceivePipeline.TrackingOption != defaultTrackingOption)
                {
                    text = string.Format("Receive pipeline's '{0}' tracking option '{1}' is not equal to default value '{2}'", receiveLocation.ReceivePipeline.Name, receiveLocation.ReceivePipeline.TrackingOption.ToString().Replace(",", ""), defaultTrackingOption.ToString().Replace(",", ""));
                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                }

                if (!receiveLocation.SendPipeline.IsNil() && receiveLocation.SendPipeline.TrackingOption != defaultTrackingOption)
                {
                    text = string.Format("Send pipeline's '{0}' tracking option '{1}' is not equal to default value '{2}'", receiveLocation.SendPipeline.Name, receiveLocation.SendPipeline.TrackingOption.ToString().Replace(",", ""), defaultTrackingOption.ToString().Replace(",", ""));
                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                }
                return;
            }

            ReceivePort receivePort = item as ReceivePort;
            if (receivePort != null)
            {
                if (receivePort.TransmitPipeline != null && receivePort.TransmitPipeline.Name != null && receivePort.TransmitPipeline.TrackingOption != defaultTrackingOption)
                {
                    text = string.Format("Transmit pipeline's '{0}' tracking option '{1}' is not equal to default value '{2}'", receivePort.TransmitPipeline.Name, receivePort.TransmitPipeline.TrackingOption.ToString().Replace(",", ""), defaultTrackingOption.ToString().Replace(",", ""));
                    messages.Add(new Message(MessageTypeEnum.Warning, text));
                }
                return;
            }   

            throw new Exception(string.Format("Unhandled type {0}", item.GetType().FullName));
        }
    }
}
