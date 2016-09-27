using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of SFTP BizTalk adapter (from nsoftware)
    /// </summary>
    public class FtpV4AdapterInfo : AdapterInfo
    {
        public FtpV4AdapterInfo()
            : base("nsoftware.FTP v4", new Guid("7142816c-f326-4248-a478-8748270376f7"))
        {
        }
    }
}