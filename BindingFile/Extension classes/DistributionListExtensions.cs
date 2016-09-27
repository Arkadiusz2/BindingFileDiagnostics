using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class DistributionListExtensions
    {
        /// <summary>
        /// Returns orchestrations that reference a send port
        /// </summary>
        /// <param name="sendPortGroup"></param>
        /// <returns></returns>
        public static IEnumerable<ServiceRef> BoundOrchestrations(this DistributionList sendPortGroup)
        {
            BindingInfo bindingInfo = sendPortGroup.Application.BindingInfo;
            foreach (ServiceRef orchestration in bindingInfo.ServiceRefCollection)
            {
                foreach (ServicePortRef orchestrationPorts in orchestration.Ports)
                {
                    if (orchestrationPorts.DistributionListRef != null && orchestrationPorts.DistributionListRef.DistributionList == sendPortGroup)
                    {
                        yield return orchestration;                        
                    }
                }
            }
        }

        public static IEnumerable<string> FilteringOnReceivePortNames(this DistributionList sendPortGroup)
        {
            if (sendPortGroup.FilterObject != null)
            {
                return sendPortGroup.FilterObject.GetPropertyValues("BTS.ReceivePortName")
                    .Union(sendPortGroup.FilterObject.GetPropertyValues("ErrorReport.ReceivePortName")).Distinct();
            }
            return Enumerable.Empty<string>();
        }

        public static IEnumerable<string> FilteringOnSendPortNames(this DistributionList sendPortGroup)
        {
            if (sendPortGroup.FilterObject != null)
            {
                return sendPortGroup.FilterObject.GetPropertyValues("BTS.SPName")
                   .Union(sendPortGroup.FilterObject.GetPropertyValues("ErrorReport.SendPortName")).Distinct();
            }
            return Enumerable.Empty<string>();
        }
    }
}
