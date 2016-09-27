using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile;

namespace BindingFile.Extensions
{
    public static class ReceivePortExtensions
    {
        public static IEnumerable<SendPort> FilteredBySendPorts(this ReceivePort receivePort)
        {
            BindingInfo bindingInfo = receivePort.Application.BindingInfo;
            foreach (SendPort sendPort in bindingInfo.SendPortCollection)
            {
                if (sendPort.FilteringOnReceivePortNames().Where(x => x == receivePort.Name).Any())
                {
                    yield return sendPort;
                }
            }
        }

        public static IEnumerable<DistributionList> FilteredBySendPortGroups(this ReceivePort receivePort)
        {
            BindingInfo bindingInfo = receivePort.Application.BindingInfo;

            foreach (DistributionList sendPortGroup in bindingInfo.DistributionListCollection)
            {
                if (sendPortGroup.FilteringOnReceivePortNames().Where(x => x == receivePort.Name).Any())
                {
                    yield return sendPortGroup;
                }
            }
        }

        /// <summary>
        /// Returns orchestrations that reference a send port
        /// </summary>
        /// <param name="receivePort"></param>
        /// <returns></returns>
        public static IEnumerable<ServiceRef> BoundOrchestrations(this ReceivePort receivePort)
        {
            BindingInfo bindingInfo = receivePort.Application.BindingInfo;
            foreach (ServiceRef orchestration in bindingInfo.ServiceRefCollection)
            {
                foreach (ServicePortRef orchestrationPorts in orchestration.Ports)
                {
                    if (orchestrationPorts.ReceivePortRef != null && orchestrationPorts.ReceivePortRef.ReceivePort == receivePort)
                    {
                        yield return orchestration;                       
                    }
                }
            }
        }
    }
}
