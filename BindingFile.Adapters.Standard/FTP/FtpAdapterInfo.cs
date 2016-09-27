using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of FTP BizTalk adapter
    /// </summary>
    public class FtpAdapterInfo : AdapterInfo
    {
        public FtpAdapterInfo()
            : base("FTP", new Guid("3979ffed-0067-4cc6-9f5a-859a5db6e9bb"))
        {
        }
    }
}
