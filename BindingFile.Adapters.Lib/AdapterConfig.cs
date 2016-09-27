using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class AdapterConfig
    {
        // TODO: modify to make it dictionary and add an indexer to retrieve property by xpath, xpath is the key in the dictionary (?)
        // but it would have to be an unsorted dictionary, so if someone lists properties they appear in the order they were created (?)
        // so maybe there is another structure necessary, half list, half dictionary, dictionary to retrieve by name and 
        // list to retrieve in order (?)
        private readonly List<AdapterProperty> _properties = new List<AdapterProperty>();
        private readonly bool _isNestedConfiguration;

        public AdapterConfig(string customConfig)
            : this(customConfig, true)
        {
        }

        public AdapterConfig(string customConfig, bool isNestedConfiguration)
        {
            this._isNestedConfiguration = isNestedConfiguration;

            this.CustomConfigDocument = new XmlDocument();
            this.CustomConfigDocument.LoadXml(customConfig);

            if (this._isNestedConfiguration)
            {
                this.AdapterConfigNode = this.CustomConfigDocument.SelectSingleNode("/CustomProps/AdapterConfig");
                this.Config = new XmlDocument();
                this.Config.LoadXml(this.AdapterConfigNode.InnerText);
            }
            else
            {
                this.Config = this.CustomConfigDocument;
            }
        }

        public override string ToString()
        {
            if (this._isNestedConfiguration)
            {
                this.CustomConfigDocument.SelectSingleNode("/CustomProps/AdapterConfig").InnerText = this.Config.OuterXml;
            }
            return this.CustomConfigDocument.OuterXml;
        }
                
        public AdapterProperty AddProperty(string propertyXPath)
        {
            AdapterProperty property = new AdapterProperty(this.Config, propertyXPath);
            _properties.Add(property);
            return property;
        }

        public IEnumerable<AdapterProperty> Properties
        {
            get
            {
                return _properties;
            }
        }

        private XmlDocument CustomConfigDocument
        {
            get;
            set;
        }

        private XmlNode AdapterConfigNode
        {
            get;
            set;
        }

        protected XmlDocument Config
        {
            get;
            private set;
        }
    }
}
