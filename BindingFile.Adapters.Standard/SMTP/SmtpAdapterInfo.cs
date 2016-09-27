using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of SMTP BizTalk adapter
    /// </summary>
    public class SmtpAdapterInfo : AdapterInfo
    {
        public SmtpAdapterInfo()
            : base("SMTP", new Guid("8f36b311-b670-4cf6-aaec-04ebb80ed48d"))
        {
        }
    }
}
