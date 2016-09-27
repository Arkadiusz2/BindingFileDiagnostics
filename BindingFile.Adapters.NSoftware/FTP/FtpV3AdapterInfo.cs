using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of SFTP BizTalk adapter (from nsoftware)
    /// </summary>
    public class FtpV3AdapterInfo : AdapterInfo
    {
        public FtpV3AdapterInfo()
            : base("nsoftware.FTP v3", new Guid("7107116c-f326-4248-a478-8748270376f7"))
        {
        }
    }
}