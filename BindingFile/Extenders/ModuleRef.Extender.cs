﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BindingFile
{
    public partial class ModuleRef : IElementInfo
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

        [XmlIgnore()]
        public bool IsAssemblyDefinition
        {
            get;
            set;
        }
    }
}
