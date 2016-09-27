using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BindingFile
{
    public partial class SendPortRef
    {
        [XmlIgnore()]
        public SendPort SendPort
        {
            get;
            set;
        }
    }
}
