using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ElementInfo
    {
        public string LocalName { get; private set; }
        public int Position { get; private set; }
        public bool HasLineInfo { get; private set; }
        public int LineNumber { get; private set; }
        public int LinePosition { get; private set; }

        public ElementInfo(string localName, int position, bool hasLineInfo, int lineNumber, int linePosition)
        {
            this.LocalName = localName;
            this.Position = position;
            this.HasLineInfo = hasLineInfo;
            this.LineNumber = lineNumber;
            this.LinePosition = linePosition;
        }
    }
}
