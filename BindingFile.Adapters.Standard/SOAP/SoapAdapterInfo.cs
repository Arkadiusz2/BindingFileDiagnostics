using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of SOAP BizTalk adapter
    /// </summary>
    public class SoapAdapterInfo : AdapterInfo
    {
        public SoapAdapterInfo()
            : base("SOAP", new Guid("7e104b2f-003c-4d9f-a6a5-168f727289f0"))
        {
        }
    }
}
