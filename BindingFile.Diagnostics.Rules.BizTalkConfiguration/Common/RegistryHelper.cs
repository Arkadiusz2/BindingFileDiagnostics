using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules.BizTalkConfiguration
{
    public static class RegistryHelper
    {
        /// <summary>
        /// Reads registry values.
        /// </summary>
        /// <param name="keyName">Registry Key.</param>
        /// <param name="valueName">Value which needs to be read from the Key.</param>
        /// <returns>Returns Value which needs to be read from the Key..</returns>  
        public static string GetRegistryEntry(string keyName, string valueName)
        {
            RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            regKey = regKey.OpenSubKey(keyName);
            Object val = regKey.GetValue(valueName);
            return val.ToString();
        }
    }
}
