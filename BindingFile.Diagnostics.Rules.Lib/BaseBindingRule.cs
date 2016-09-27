using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace BindingFile.Diagnostics.Rules
{
    public abstract class BaseBindingRule : IBindingRule
    {
        #region Private fields
        private string _name;
        private bool _isConfigurable;
        #endregion

        #region Constructors
        protected BaseBindingRule(string name, bool isConfigurable)
        {
            this._name = name;
            this._isConfigurable = isConfigurable;
        }
        #endregion

        #region Events
        public event EventHandler<BindingRuleValidationEventArgs> Validated;

        protected virtual void OnValidated(BindingRuleValidationEventArgs e)
        {
            if (this.Validated != null)
            {
                this.Validated(this, e);
            }
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
        }
        #endregion

        public abstract bool Validate(BindingInfo bindingInfo/*, List<BindingRuleValidationEventArgs> validationResults*/);

        public Stream Configuration
        {
            get;
            set;
        }
       
        public object ConfigurationAs(Type type)
        {
            if (type == null)
            {
                throw new NullReferenceException("type");
            }            

            if (type == typeof(XDocument))
            {
                XDocument xDocument = XDocument.Load(this.Configuration);
                this.Configuration.Seek(0, SeekOrigin.Begin);
                
                return xDocument;
            } 
            else if (type == typeof(XmlDocument))
            {
                XmlDocument xmlDocumentConfiguration = new XmlDocument();
                xmlDocumentConfiguration.PreserveWhitespace = true;
                xmlDocumentConfiguration.Load(this.Configuration);
                this.Configuration.Seek(0, SeekOrigin.Begin);

                return xmlDocumentConfiguration;
            }
            else if (type == typeof(Stream))
            {
                return this.Configuration;
            }

            throw new Exception(string.Format("Cannot get configuration as {0}", type.Name));                       
        }

        bool IBindingRule.IsConfigurable
        {
            get
            {
                return _isConfigurable;
            }
        }
    }
}
