using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BindingFile.Diagnostics.Rules.DeployedArtifacts
{
    public class TypeChecker : MarshalByRefObject
    {
        public Assembly Load(string assemblyString)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load(assemblyString);
            }
            catch (Exception ex)
            {
                throw;
            }
            return assembly;
        }
    }
}
