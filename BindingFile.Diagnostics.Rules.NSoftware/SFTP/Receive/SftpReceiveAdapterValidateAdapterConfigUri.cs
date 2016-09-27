using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;
using BindingFile;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules.NSoftwareAdapters
{
    [RuleTargets(RuleTargetsEnum.ReceiveLocation, typeof(SftpV3AdapterInfo), typeof(SftpV4AdapterInfo))]
    public class SftpReceiveAdapterValidateAdapterConfigUri : RuleTemplate
    {
        public SftpReceiveAdapterValidateAdapterConfigUri()
            : base("Validate SFTP receive adapter config <uri>")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            ReceiveLocation receiveLocation = (ReceiveLocation)item;
            SftpReceiveAdapterConfig customConfig = new SftpReceiveAdapterConfig(receiveLocation.ReceiveLocationTransportTypeData);
            
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

            string fileMask = "";
            if (remotePath.EndsWith("/"))
            {
                fileMask = customConfig.FileMask;
            }
            else
            {
                fileMask = "/" + customConfig.FileMask;
            }

            string expectedUri = string.Format("SFTP://{0}@{1}:{2}{3}{4}", customConfig.SSHUser, customConfig.SSHHost, customConfig.SSHPort, remotePath , fileMask);

            if (expectedUri != customConfig.Uri)
            {
                string text = string.Format("Custom config <uri> element '{0}' is different from expected value '{1}'. <SSHUser> is '{2}' <SSHHost> is '{3}', <SSHPort> is '{4}', <SSHRemotePath> is '{5}' and <FileMask> is '{6}'",customConfig.Uri, expectedUri, customConfig.SSHUser, customConfig.SSHHost, customConfig.SSHPort, customConfig.RemotePath, customConfig.FileMask);
                messages.Add(new Message(text));
            }
        }
    }
}
