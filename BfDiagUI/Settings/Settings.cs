using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BfDiagUI.Settings
{
    static class Settings
    {
        #region Settings
        // Get current assembly path
        private static string CurrentAssemblyPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        // Get rules location
        public static string RulesPath
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["RulesPath"];
            }
            set
            {
                ConfigurationManager.AppSettings["RulesPath"] = value;
            }
        }

        // Get rules location
        public static string RulesAbsolutePath
        {
            get
            {
                return GetRulesAbsolutePath(Settings.RulesPath);
            }
        }

        public static string GetRulesAbsolutePath(string subdirectory)
        {
            return Path.Combine(Settings.CurrentAssemblyPath, subdirectory);
        }

        public static string ExternalEditorPath
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["ExternalEditorPath"];                
            }
            set
            {
                ConfigurationManager.AppSettings["ExternalEditorPath"] = value;
            }
        }

        public static string ExternalEditorParameters
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["ExternalEditorParameters"];
            }
            set
            {
                ConfigurationManager.AppSettings["ExternalEditorParameters"] = value;
            }
        }


        public static void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings;
        }
        #endregion
    }
}
