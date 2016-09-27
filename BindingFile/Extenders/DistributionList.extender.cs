using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BindingFile
{
    public partial class DistributionList : IElementInfo
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

        private bool _filterInitialized = false;
        private Filter _filter = null;

        [XmlIgnore()]
        public Filter FilterObject
        {
            get
            {
                if (!_filterInitialized)
                {
                    this.PropertyChanged += DistributionList_PropertyChanged;

                    BindingFile.Filter.TryParse(this.Filter, out _filter);
                    _filterInitialized = true;
                }
                return _filter;
            }
        }

        void DistributionList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Filter")
            {
                _filterInitialized = false;
                _filter = null;
            }
        }
    }
}
