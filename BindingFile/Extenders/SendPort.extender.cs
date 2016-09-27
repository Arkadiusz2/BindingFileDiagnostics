using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BindingFile
{
    public partial class SendPort : IElementInfo
    {       
        [XmlIgnore()]
        public BtsApplication Application
        {
            get;
            set;
        }

        [XmlIgnore()]
        public DistributionList DistributionList
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

        private bool _filterInitialized = false;
        private Filter _filter = null;
        
        [XmlIgnore()]
        public Filter FilterObject
        {
            get
            {
                if (!_filterInitialized)
                {
                    this.PropertyChanged += SendPort_PropertyChanged;

                    BindingFile.Filter.TryParse(this.Filter, out _filter);
                    _filterInitialized = true;
                }
                return _filter;
            }
        }

        void SendPort_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Filter")
            {
                _filterInitialized = false;
                _filter = null;
            }
        }

        public bool ShouldSerializeEncryptionCert()
        {
            return (this.EncryptionCert.UsageType != 0);
        }

        public bool ShouldSerializeReceivePipeline()
        {
            return (this.IsTwoWay);
        }

        public bool ShouldSerializeInboundTransforms()
        {
            return (this.IsTwoWay);
        }

        public bool ShouldSerializePrimaryTransport()
        {
            return (this.IsStatic);
        }

        public bool ShouldSerializeSecondaryTransport()
        {
            return (this.IsStatic);
        }
    }
}
