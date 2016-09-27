using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public partial class FtpReceiveAdapterConfig : AdapterConfig
    {
        public string ConstructUri()
        {
            return ConstructUri(this.ServerAddress, this.ServerPort, this.TargetFolder, this.FileMask);
        }

        public static string ConstructUri(string serverAddress, string serverPort, string targetFolder, string fileMask)
        {
            return string.Format("ftp://{0}:{1}{2}{3}/{4}", serverAddress, serverPort, (!string.IsNullOrEmpty(targetFolder) ? "/" : ""), targetFolder, fileMask);
        }
    }
}
