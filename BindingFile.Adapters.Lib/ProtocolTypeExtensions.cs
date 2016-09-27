using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public static class ProtocolTypeExtensions
    {        
        public static bool UsesAdapter(this ProtocolType protocol, IAdapterInfo adapterInfo)
        {
            if (protocol == null || adapterInfo == null)
            {
                return false;
            }

            return (adapterInfo.Name == protocol.Name && adapterInfo.ConfigurationClsid == Guid.Parse(protocol.ConfigurationClsid));
        }

        public static bool UsesAdapter<I>(this ProtocolType protocol)
            where I: IAdapterInfo, new()
        {
            I adapterInfo = new I();
            return UsesAdapter(protocol, adapterInfo);
        }
    }
}
