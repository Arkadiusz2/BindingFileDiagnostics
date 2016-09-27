using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class SendPortExtensions
    {
        public static SendPort Clone(this SendPort sendPort)
        {
            return SendPort.Deserialize(sendPort.Serialize());
        }

        public static IEnumerable<DistributionList> BoundSendPortGroups(this SendPort sendPort)
        {
            BindingInfo bindingInfo = sendPort.Application.BindingInfo;

            foreach (DistributionList sendPortGroup in bindingInfo.DistributionListCollection)
            {
                foreach (SendPortRef sendPortRef in sendPortGroup.SendPorts)
                {
                    if (sendPortRef.SendPort == sendPort)
                    {
                        yield return sendPortGroup;
                        break;
                    }
                }
            }
        }

        public static IEnumerable<DistributionList> FilteredBySendPortGroups(this SendPort sendPort)
        {
            BindingInfo bindingInfo = sendPort.Application.BindingInfo;

            foreach (DistributionList sendPortGroup in bindingInfo.DistributionListCollection)
            {
                if (sendPortGroup.FilteringOnSendPortNames().Any(x => x == sendPort.Name))
                {
                    yield return sendPortGroup;
                    break;
                }
            }
        }

        public static IEnumerable<SendPort> FilteredBySendPorts(this SendPort sendPort)
        {
            BindingInfo bindingInfo = sendPort.Application.BindingInfo;

            foreach (SendPort filteringSendPort in bindingInfo.SendPortCollection)
            {
                if (filteringSendPort.FilteringOnSendPortNames().Any(x => x == sendPort.Name))
                {
                    yield return filteringSendPort;
                    break;
                }
            }
        }

        /// <summary>
        /// Returns orchestrations that reference a send port
        /// </summary>
        /// <param name="sendPort"></param>
        /// <returns></returns>
        public static IEnumerable<ServiceRef> BoundOrchestrations(this SendPort sendPort)
        {
            BindingInfo bindingInfo = sendPort.Application.BindingInfo;
            foreach (ServiceRef orchestration in bindingInfo.ServiceRefCollection)
            {
                foreach (ServicePortRef orchestrationPorts in orchestration.Ports)
                {
                    if (orchestrationPorts.SendPortRef != null && orchestrationPorts.SendPortRef != null && orchestrationPorts.SendPortRef.Name.Equals(sendPort.Name))
                    {
                        yield return orchestration;
                        break; // don't return orchestration twice if send port is referenced by it twice
                    }
                }
            }
        }

        public static IEnumerable<string> FilteringOnReceivePortNames(this SendPort sendPort)
        {
            if (sendPort.FilterObject != null)
            {
                return sendPort.FilterObject.GetPropertyValues("BTS.ReceivePortName")
                    .Union(sendPort.FilterObject.GetPropertyValues("ErrorReport.ReceivePortName")).Distinct();
            }
            return Enumerable.Empty<string>();
        }

        public static IEnumerable<string> FilteringOnSendPortNames(this SendPort sendPort)
        {
            if (sendPort.FilterObject != null)
            {
                return sendPort.FilterObject.GetPropertyValues("BTS.SPName")
                   .Union(sendPort.FilterObject.GetPropertyValues("ErrorReport.SendPortName")).Distinct();
            }
            return Enumerable.Empty<string>();
        }
    }
}
