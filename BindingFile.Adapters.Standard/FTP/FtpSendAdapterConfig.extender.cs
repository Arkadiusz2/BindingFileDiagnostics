using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public static class FtpSendAdapterConfigExtensions
    {
        public static string ConstructUri(this FtpSendAdapterConfig config)
        {
            return ConstructUri(config.ServerAddress, config.ServerPort, config.TargetFolder.IsNullOrEmpty() ? "" : config.TargetFolder.Value, config.TargetFileName);
        }

        public static string ConstructUri(string serverAddress, string serverPort, string targetFolder, string targetFileName)
        {
            return string.Format("ftp://{0}:{1}{2}{3}/{4}", serverAddress, serverPort, (!string.IsNullOrEmpty(targetFolder) ? "/" : ""), targetFolder, targetFileName);
        }
    }
}
