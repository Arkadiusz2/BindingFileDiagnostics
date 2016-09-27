using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public class WcfOracleDbAdapterInfo : AdapterInfo
    {
        /// <summary>
        /// Transport type identification of HTTP BizTalk adapter
        /// </summary>
        public WcfOracleDbAdapterInfo()
            : base("WCF-OracleDB", new Guid("d7127586-e851-412e-8a8a-2428aeddc219"))
        {
        }
    }
}
