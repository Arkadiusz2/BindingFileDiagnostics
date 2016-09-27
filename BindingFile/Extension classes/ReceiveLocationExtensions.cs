using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ReceiveLocationExtensions
    {
        public static ReceiveLocation Clone(this ReceiveLocation receiveLocation)
        {
            return ReceiveLocation.Deserialize(receiveLocation.Serialize());
        }
    }
}
