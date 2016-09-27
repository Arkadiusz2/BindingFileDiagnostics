using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public class HttpAdapterInfo : AdapterInfo
    {
        /// <summary>
        /// Transport type identification of HTTP BizTalk adapter
        /// </summary>
        public HttpAdapterInfo()
            : base("HTTP", new Guid("1c56d157-0553-4345-8a1f-55d2d1a3ffb6"))
        {
        }
    }
}
