using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of SFTP BizTalk adapter (from nsoftware)
    /// </summary>
    public class SftpV4AdapterInfo : AdapterInfo
    {
        public SftpV4AdapterInfo()
            : base("nsoftware.SFTP v4", new Guid("7142827c-f326-4248-a478-8748270376f7"))
        {
        }
    }
}
