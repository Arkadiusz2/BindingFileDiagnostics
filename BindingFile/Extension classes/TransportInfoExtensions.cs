using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public static class TransportInfoExtensions
    {
        public static bool IsDefined(this TransportInfo transportInfo)
        {
            return transportInfo.TransportType.Capabilities != 0;
        }
    }
}
