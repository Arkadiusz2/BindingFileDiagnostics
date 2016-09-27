using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BindingFile.Diagnostics.Rules.DeployedArtifacts
{
    public static class AppDomainExtensions
    {
        #region Private Methods
        /// <summary>
        /// Creates a new AppDomain based on the parent AppDomains 
        /// Evidence and AppDomainSetup
        /// </summary>
        /// <param name="parentDomain">The parent AppDomain</param>
        /// <returns>A newly created AppDomain</returns>
        public static AppDomain CreateChildDomain(this AppDomain parentDomain, string name)
        {
            //Evidence evidence = new Evidence(parentDomain.Evidence);
            //AppDomainSetup setup = parentDomain.SetupInformation;
            //return AppDomain.CreateDomain(name, evidence, setup);
            AppDomainSetup setup = new AppDomainSetup()
            {
                PrivateBinPath = parentDomain.SetupInformation.PrivateBinPath
            };

            return AppDomain.CreateDomain(name, null, setup);
        }
        #endregion
    }
}
