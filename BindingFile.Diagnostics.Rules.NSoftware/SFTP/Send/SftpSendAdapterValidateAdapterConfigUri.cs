using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;
using BindingFile.Diagnostics.Rules.NSoftwareAdapters;
using BindingFile;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
{
    [RuleTargets(RuleTargetsEnum.TransportInfo, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpSendAdapterValidateAdapterConfigUri : RuleTemplate
    {
        public SftpSendAdapterValidateAdapterConfigUri()
            : base("Validate SFTP send adapter config <uri>")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            TransportInfo transportInfo = (TransportInfo)item;
            SftpSendAdapterConfig customConfig = new SftpSendAdapterConfig(transportInfo.TransportTypeData);

            string remotePath = "";
            if (!customConfig.RemotePath.IsNullOrEmpty())
            {
                if (customConfig.RemotePath.Value.StartsWith("/"))
                {
                    remotePath = customConfig.RemotePath;
                }
                else
                {
                    remotePath = "/" + customConfig.RemotePath;
                }
            }

            string remoteFile = "";
            if (remotePath.EndsWith("/"))
            {
                remoteFile = customConfig.RemoteFile;
            }
            else
            {
                remoteFile = "/" + customConfig.RemoteFile;
            }

            string expectedUri = string.Format("SFTP://{0}@{1}:{2}{3}{4}", customConfig.SSHUser, customConfig.SSHHost, customConfig.SSHPort, remotePath, remoteFile);

            if (expectedUri != customConfig.Uri)
            {
                string text = string.Format("Custom config <uri> element '{0}' is different from expected value '{1}'. <SSHUser> is '{2}', <SSHHost> is '{3}', <SSHPort> is '{4}', <RemotePath> is '{5}' and <FileMask> is '{5}'", customConfig.Uri, expectedUri, customConfig.SSHUser, customConfig.SSHHost, customConfig.SSHPort, customConfig.RemotePath ?? "", customConfig.RemoteFile);
                messages.Add(new Message(text));
            }
        }
    }
}
