using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules.BizTalkConfiguration
{
    public static class BizTalkRegistrySettings
    {
        private const string _BIZTALK_ADMIN_REGISTRY = @"SOFTWARE\Microsoft\BizTalk Server\3.0\Administration";

        private static string _mgmtDBServer;
        private static string _mgmtDBName;
 
        public static string MgmtDBServer
        {
            get
            {
                if (_mgmtDBServer == null)
                {
                    _mgmtDBServer = RegistryHelper.GetRegistryEntry(_BIZTALK_ADMIN_REGISTRY, "MgmtDBServer");
                }
                return _mgmtDBServer;
            }
        }

        public static string MgmtDBName
        {
            get
            {
                if (_mgmtDBName == null)
                {
                    _mgmtDBName = RegistryHelper.GetRegistryEntry(_BIZTALK_ADMIN_REGISTRY, "MgmtDBName");
                }
                return _mgmtDBName;
            }
        }
    }
}
