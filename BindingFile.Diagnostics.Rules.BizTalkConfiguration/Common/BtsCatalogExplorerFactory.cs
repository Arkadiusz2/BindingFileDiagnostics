using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules.BizTalkConfiguration
{
    public static class BtsCatalogExplorerFactory
    {
        private const string _DB_CONN_STRING = "server={0};database={1};Integrated Security=SSPI";

        public static BtsCatalogExplorer Create()
        {
            BtsCatalogExplorer catalogExploerer = new BtsCatalogExplorer();
            catalogExploerer.ConnectionString = String.Format(_DB_CONN_STRING, BizTalkRegistrySettings.MgmtDBServer, BizTalkRegistrySettings.MgmtDBName);
            return catalogExploerer;
        }
    }
}
