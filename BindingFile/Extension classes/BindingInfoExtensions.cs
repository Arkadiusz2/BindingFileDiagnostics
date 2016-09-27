using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class BindingInfoExtensions
    {
        public static List<ReceiveLocation> GetReceiveLocationsByReceivePortName(this BindingInfo bindingInfo, string receivePortName)
        {
            return bindingInfo.ReceiveLocationCollection.FindAll(x => x.Name == receivePortName);
        }

        public static bool SendPortExists(this BindingInfo bindingInfo, string sendPortName)
        {
            return bindingInfo.SendPortCollection.Exists(x => x.Name.Equals(sendPortName));
        }

        public static bool SendPortGroupExists(this BindingInfo bindingInfo, string sendPortGroupName)
        {
            return bindingInfo.DistributionListCollection.Exists(x => x.Name.Equals(sendPortGroupName));
        }

        public static bool ReceivePortExists(this BindingInfo bindingInfo, string receivePortName)
        {
            return bindingInfo.ReceivePortCollection.Exists(x => x.Name.Equals(receivePortName));
        }

        public static SendPort GetSendPort(this BindingInfo bindingInfo, string sendPortName)
        {
            return bindingInfo.SendPortCollection.FirstOrDefault(x => x.Name.Equals(sendPortName));
        }
        public static DistributionList GetDistributionList(this BindingInfo bindingInfo, string sendPortGroupName)
        {
            return bindingInfo.DistributionListCollection.FirstOrDefault(x => x.Name.Equals(sendPortGroupName));
        }
        public static ReceivePort GetReceivePort(this BindingInfo bindingInfo, string receivePortName)
        {
            return bindingInfo.ReceivePortCollection.FirstOrDefault(x => x.Name.Equals(receivePortName));
        }
        public static ReceiveLocation GetReceiveLocation(this BindingInfo bindingInfo, string receiveLocationName)
        {
            return bindingInfo.ReceiveLocationCollection.FirstOrDefault(x => x.Name.Equals(receiveLocationName));
        }
        public static ServiceRef GetServiceRef(this BindingInfo bindingInfo, string orchestrationName)
        {
            var q = from module in bindingInfo.ModuleRefCollection
                    from service in module.Services
                    select service;
            
            return q.FirstOrDefault(x => x.Name.Equals(orchestrationName));
        }

        public static ModuleRef GetModuleRef(this BindingInfo bindingInfo, string moduleRefFullName)
        {
            return bindingInfo.ModuleRefCollection.FirstOrDefault(x => x.FullName == moduleRefFullName);
        }
    }
}
