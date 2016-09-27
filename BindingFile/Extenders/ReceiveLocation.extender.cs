using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace BindingFile
{
    public partial class ReceiveLocation : IElementInfo
    {
        [XmlIgnore()]
        public ReceivePort ReceivePort
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

        public bool ShouldSerializeEncryptionCert()
        {
            return (this.EncryptionCert.UsageType != 0);
        }
    }
}
