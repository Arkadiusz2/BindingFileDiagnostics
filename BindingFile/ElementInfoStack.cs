using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile
{
    public class ElementInfoStack
    {
        Stack<ElementInfo> _elementStack;
        private ElementInfo _previousElement;
        
        public event EventHandler<EventArgs> ElementPushed;
        public event EventHandler<EventArgs> ElementPopped;

        public ElementInfoStack()
        {
            _elementStack = new Stack<ElementInfo>();
            _previousElement = null;
        }

        protected void OnPushed()
        {
            if (this.ElementPushed != null)
            {
                this.ElementPushed(this, new EventArgs());
            }
        }

        protected void OnPopped()
        {
            if (this.ElementPopped != null)
            {
                this.ElementPopped(this, new EventArgs());
            }
        }

        public ElementInfo Current
        {
            get
            {
                return _elementStack.Peek();
            }
        }

        public string Path
        {
            get
            {
                var q = from i in _elementStack.ToArray().Reverse()
                        select i.LocalName;

                string joinedLocalNames = string.Join(@"/", q);
                string path = joinedLocalNames.Length > 0 ? @"/" + joinedLocalNames : "";

                return path;
            }
        }

        public void Update(XmlReader xmlReader)
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                int position = 1;
                if (_previousElement != null && _previousElement.LocalName != null)
                {
                    if (_previousElement.LocalName.Equals(xmlReader.LocalName, StringComparison.InvariantCulture))
                    {
                        position = _previousElement.Position + 1;
                    }
                }                
                
                int lineNumber = 0;
                int linePosition = 0;
                IXmlLineInfo xmlLineInfo = (IXmlLineInfo)xmlReader;
                bool hasLineInfo = xmlLineInfo.HasLineInfo();
                if (hasLineInfo)
                {
                    lineNumber = xmlLineInfo.LineNumber;
                    linePosition = xmlLineInfo.LinePosition;
                }
                
                ElementInfo elementScope = new ElementInfo(xmlReader.LocalName, position, hasLineInfo, lineNumber, linePosition);
                _elementStack.Push(elementScope);
                OnPushed();


                if (xmlReader.IsEmptyElement)
                {
                    _previousElement = _elementStack.Pop();
                    OnPopped();
                }

            }
            else if (xmlReader.NodeType == XmlNodeType.EndElement)
            {
                _previousElement = _elementStack.Pop();
                OnPopped();
            }        
        }
    }
}
