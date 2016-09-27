using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BindingFile.Diagnostics.Engine
{
    public static class AssemblyResolver
    {
        //private static Dictionary<string, Assembly> _resolvedAssemblies { get; set; }

        static AssemblyResolver()
        {
            //_resolvedAssemblies = new Dictionary<string, Assembly>();
        }

        public static Assembly Resolve(AppDomain sender, ResolveEventArgs args)
        {        
            Assembly resolvedAssembly = null;
            string assemblyName = args.Name;
                
            if ((new AssemblyName(args.Name).Name).Contains(".resources"))
            {
                return null;
            }

            //if (_resolvedAssemblies.ContainsKey(assemblyName))
            //{
            //    return _resolvedAssemblies[assemblyName];
            //}

            resolvedAssembly = Assembly.Load(assemblyName);
 
            //_resolvedAssemblies.Add(assemblyName, resolvedAssembly);
            
            return resolvedAssembly;
        }
    }
}
