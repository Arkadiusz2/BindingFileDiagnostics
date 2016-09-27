using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BindingFile
{
    public partial class ReceivePort : IElementInfo
    {
        [XmlIgnore()]
        public BtsApplication Application
        {
            get;
            set;
        }

        [XmlIgnore()]
        public ElementInfo ElementInfo
        {
            get;
            set;
        }

        public bool ShouldSerializeTransmitPipeline()
        {
            return (this.IsTwoWay);
        }

        public bool ShouldSerializeOutboundTransforms()
        {
            return (this.IsTwoWay);
        }
    }
}
