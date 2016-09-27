using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace BindingFile
{
    public partial class TransportInfo
    {
        public bool ShouldSerializeTransportType()
        {
            return (this.TransportType.Capabilities != 0);
        }

        [XmlIgnore()]
        public SendPort SendPort
        {
            get;
            set;
        }

        /// <summary>
        /// Checks if TransportInfo is defined for primary or secondary transport
        /// </summary>
        public bool IsPrimary
        {
            get
            {
                if (this.SendPort == null)
                {
                    throw new InvalidOperationException("'IsPrimary' property cannot be used. TransportInfo object is not bound to a SendPort.");
                }
                else if (this.SendPort.PrimaryTransport == this)
                {
                    return true;
                }
                else if (this.SendPort.SecondaryTransport == this)
                {
                    return false;
                }
                throw new InvalidOperationException("'IsPrimary' property mismatch. TransportInfo object is linked to wrong SendPort");                
            }
        }
    }
}
