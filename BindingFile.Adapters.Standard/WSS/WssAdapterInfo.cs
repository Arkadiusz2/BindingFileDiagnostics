using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of Windows Sharepoint Services BizTalk adapter
    /// </summary>
    public class WssAdapterInfo : AdapterInfo
    {
        public WssAdapterInfo()
            : base("Windows SharePoint Services", new Guid("ba7dad66-5fc8-4a24-a27e-d9f68fd67c3a"))
        {
        }
    }
}
