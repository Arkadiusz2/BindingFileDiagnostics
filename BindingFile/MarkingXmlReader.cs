using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile
{
    public class MarkingXmlReader : XmlReader
    {
        protected XmlReader UnderlyingXmlReader { get; private set; }
        protected ElementInfoStack ElementStack { get; private set; }

        public MarkingXmlReader(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException("xmlReader");
            }
            this.UnderlyingXmlReader = xmlReader;
            Initialize();
        }

        private void Initialize()
        {
            ElementStack = new ElementInfoStack();
        }

        #region Underlying XmlReader wrapping functions
        public override int AttributeCount
        {
            get
            {
                return this.UnderlyingXmlReader.AttributeCount;
            }
        }

        public override string BaseURI
        {
            get
            {
                return this.UnderlyingXmlReader.BaseURI;
            }
        }

        public override void Close()
        {
            this.UnderlyingXmlReader.Close();
        }

        public override int Depth
        {
            get
            {
                return this.UnderlyingXmlReader.Depth;
            }
        }

        public override bool EOF
        {
            get
            {
                return this.UnderlyingXmlReader.EOF;
            }
        }

        public override string GetAttribute(int i)
        {
            return this.UnderlyingXmlReader.GetAttribute(i);
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            return this.UnderlyingXmlReader.GetAttribute(name, namespaceURI);
        }

        public override string GetAttribute(string name)
        {
            return this.UnderlyingXmlReader.GetAttribute(name);
        }

        public override bool IsEmptyElement
        {
            get
            {
                return this.UnderlyingXmlReader.IsEmptyElement;
            }
        }

        public override string LocalName
        {
            get
            {
                return this.UnderlyingXmlReader.LocalName;
            }
        }

        public override string LookupNamespace(string prefix)
        {
            return this.UnderlyingXmlReader.LookupNamespace(prefix);
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            return this.UnderlyingXmlReader.MoveToAttribute(name, ns);
        }

        public override bool MoveToAttribute(string name)
        {
            return this.UnderlyingXmlReader.MoveToAttribute(name);
        }

        public override bool MoveToElement()
        {
            return this.UnderlyingXmlReader.MoveToElement();
        }

        public override bool MoveToFirstAttribute()
        {
            return this.UnderlyingXmlReader.MoveToFirstAttribute();
        }

        public override bool MoveToNextAttribute()
        {
            return this.UnderlyingXmlReader.MoveToNextAttribute();
        }

        public override XmlNameTable NameTable
        {
            get
            {
                return this.UnderlyingXmlReader.NameTable;
            }
        }

        public override string NamespaceURI
        {
            get
            {
                return this.UnderlyingXmlReader.NamespaceURI;
            }
        }

        public override XmlNodeType NodeType
        {
            get
            {
                return this.UnderlyingXmlReader.NodeType;
            }
        }

        public override string Prefix
        {
            get
            {
                return this.UnderlyingXmlReader.Prefix;
            }
        }

        public override bool Read()
        {
            bool readSuccessfull = this.UnderlyingXmlReader.Read();
            if (readSuccessfull)
            {
                ElementStack.Update(this.UnderlyingXmlReader);
            }

            return readSuccessfull;
        }

        public override bool ReadAttributeValue()
        {
            return this.UnderlyingXmlReader.ReadAttributeValue();
        }

        public override ReadState ReadState
        {
            get
            {
                return this.UnderlyingXmlReader.ReadState;
            }
        }

        public override void ResolveEntity()
        {
            this.UnderlyingXmlReader.ResolveEntity();
        }

        public override string Value
        {
            get
            {
                return this.UnderlyingXmlReader.Value;
            }
        }
        #endregion
    }
}
