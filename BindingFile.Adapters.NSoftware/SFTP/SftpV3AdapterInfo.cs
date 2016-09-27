using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of SFTP BizTalk adapter (from nsoftware)
    /// </summary>
    public class SftpV3AdapterInfo : AdapterInfo
    {
        public SftpV3AdapterInfo()
            : base("nsoftware.SFTP v3", new Guid("7107127c-f326-4248-a478-8748270376f7"))
        {
        }
    }
}