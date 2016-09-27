using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of POP3 BizTalk adapter
    /// </summary>
    public class Pop3AdapterInfo : AdapterInfo
    {
        public Pop3AdapterInfo()
            : base("POP3", new Guid("1787fcc1-9aaa-4bbd-9096-7eb77e3d9d9b"))
        {
        }
    }
}
