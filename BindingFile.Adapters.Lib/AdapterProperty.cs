using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class AdapterProperty
    {
        // Reference to document storing all prpoerties
        private XmlDocument _customConfigDocument;

        // Property name
        private readonly string _propertyXPath;        
        private XmlNode _propertyNode = null;
        private bool _isInitialized = false;

        public AdapterProperty(XmlDocument customConfigDocument, string propertyXPath)
        {
            this._customConfigDocument = customConfigDocument;
            this._propertyXPath = propertyXPath;
        }

        public bool IsNullOrEmpty()
        {
            return this.Node == null || this.Node.InnerText.Length == 0;
        }

        public bool Exists
        {
            get
            {
                return this.Node != null;
            }
        }

        public string Value
        {
            get
            {
                return (this.Node != null ? this.Node.InnerText : null);    
            }
            set
            {
                // TODO: add special handling - like throw and exception if node does not exist, only present values can be saved
                if (!this.Exists)
                {
                    throw new InvalidOperationException(string.Format("Property '{0}' does not exist in adapter's custom configuration. Only values of existing properties can be set."));
                }
                this.Node.InnerText = value;
            }
        }

        protected XmlNode Node
        {
            get
            {
                if (!_isInitialized)
                {
                    _propertyNode = _customConfigDocument.DocumentElement.SelectSingleNode(_propertyXPath);
                    _isInitialized = true;
                }
                return _propertyNode;
            }            
        }

        #region Operators
        public static implicit operator string(AdapterProperty adapterProperty)
        {
            return adapterProperty.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
        #endregion
    }
}
