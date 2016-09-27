using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of WCF-WSHttp BizTalk adapter
    /// </summary>
    public class WcfWsHttpAdapterInfo : AdapterInfo
    {
        public WcfWsHttpAdapterInfo()
            : base("WCF-WSHttp", new Guid("2b219014-ba04-4b70-a66b-a8c418b109fd"))
        {
        }
    }
}
