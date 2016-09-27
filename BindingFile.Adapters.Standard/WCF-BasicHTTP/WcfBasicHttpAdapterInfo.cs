using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{     
    /// <summary>
    /// Transport type identification of WCF-BasicHttp BizTalk adapter
    /// </summary>
    public class WcfBasicHttpAdapterInfo : AdapterInfo
    {
        public WcfBasicHttpAdapterInfo()
            : base("WCF-BasicHttp", new Guid("467c1a52-373f-4f09-9008-27af6b985f14"))
        {
        }
    }
}
