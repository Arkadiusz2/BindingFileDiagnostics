using OM = Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BindingFile.Diagnostics.Rules.BizTalkConfiguration
{
    public static class BtsCatalogExplorerExtensions
    {
        public static OM.ProtocolType Adapter(this OM.BtsCatalogExplorer explorer, string adapterName)
        {
            return Adapters(explorer).First(x => x.Name == adapterName);
        }
        
        /// <summary>
        /// Gets list of all configured adapters
        /// </summary>
        /// <param name="explorer"></param>
        /// <returns></returns>
        public static IEnumerable<OM.ProtocolType> Adapters(this OM.BtsCatalogExplorer explorer)
        {
            return (from OM.SendHandler sh in explorer.SendHandlers
                    select sh.TransportType).Union(
                    from OM.ReceiveHandler rh in explorer.ReceiveHandlers
                    select rh.TransportType).Distinct().OrderBy(x => x.Name);
        }

        public static bool IsTrusted(this OM.Host host)
        {
            return (bool)GetPropertyFieldValue(typeof(OM.Host), host, "IsTrusted");
        }

        /// <summary>
        /// Uses reflection to get the field value from an object.
        /// </summary>
        ///
        /// <param name="type">The instance type.</param>
        /// <param name="instance">The instance object.</param>
        /// <param name="propertyName">The field's name which is to be fetched.</param>
        ///
        /// <returns>The field value from the object.</returns>
        internal static object GetPropertyFieldValue(Type type, object instance, string propertyName)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic /*| BindingFlags.Static*/ | BindingFlags.GetProperty;
            PropertyInfo propertyInfo = type.GetProperty(propertyName, bindingFlags);                       
            
            return propertyInfo.GetValue(instance, null);
        }
    }
}
