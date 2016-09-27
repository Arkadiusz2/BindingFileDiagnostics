using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BindingFile.Diagnostics.Rules.DeployedArtifacts
{
    /// <summary>
    /// Checks if a type exists in an assembly
    /// The check is performed in a separate application domain
    /// Then all the assemblies are unloaded when checking is finished
    /// </summary>
    [Serializable]
    public class SeparateDomainLoader<T>
        where T : MarshalByRefObject
    {
        /// <summary>
        /// Name of separate domain
        /// </summary>
        public string SeparateAppDomainName { get; private set; }

        /// <summary>
        /// Separate application domain where assemblies will be loaded
        /// </summary>        
        private AppDomain _separateAppDomain = null;
        private object[] _proxyActivationAttributes = null;
        private T _proxy = null;


        #region Constructors and destructor
        /// <summary>
        /// Initializes instance of SeparateDomainLoader class with default domain name
        /// </summary>
        public SeparateDomainLoader()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes instance of SeparateDomainLoader class
        /// </summary>
        /// <param name="separateAppDomainName">Separate domain name, set value to null to use default domain name (new Guid)</param>
        /// <param name="proxyActivationAttributes">Parameters to intialize the Proxy class of type T, set value to null to use parameterless constructor</param>
        public SeparateDomainLoader(string separateAppDomainName, object[] proxyActivationAttributes)
        {
            if (string.IsNullOrEmpty(separateAppDomainName))
            {
                this.SeparateAppDomainName = Guid.NewGuid().ToString("B");
            }
            else
            {
                this.SeparateAppDomainName = separateAppDomainName;
            }
            _proxyActivationAttributes = proxyActivationAttributes;
        }

        #endregion

        /// <summary>
        /// Gets existing or creates new child application domain
        /// </summary>
        public AppDomain SeparateAppDomain
        {
            get
            {
                if (_separateAppDomain == null)
                {
                    _separateAppDomain = AppDomain.CurrentDomain.CreateChildDomain(this.SeparateAppDomainName);
                    //_separateAppDomain.AssemblyResolve += Resolver.AssemblyResolve;
                }
                return _separateAppDomain;
            }
        }

        /// <summary>
        /// Gets the initialized proxy object that is initialized inside separate application domain
        /// </summary>
        public T Proxy
        {
            get
            {
                if (_proxy == null)
                {
                    Type proxyType = typeof(T);
                    //try
                    //{
                    string pathToDll = Assembly.GetExecutingAssembly().Location;
                    AppDomainSetup domainSetup = new AppDomainSetup
                    {
                        PrivateBinPath = pathToDll
                    };
                    AppDomain domain = AppDomain.CreateDomain("TempDomain", null, domainSetup);

                    string s = AppDomain.CurrentDomain.FriendlyName; ;
                    domain.SetData("FriendlyName", "ABC");

                    CrossDomainCode crossDomainCode = new CrossDomainCode();
                    
                    //crossDomainCode.Name = AppDomain.CurrentDomain.FriendlyName;
                    domain.AssemblyResolve += domain_AssemblyResolve;
                    domain.DoCallBack(crossDomainCode.ChangeName);

                    string friendlyName = (string)domain.GetData("FriendlyName");
                    
                    dynamic typeChecker = domain.CreateInstanceFromAndUnwrap(pathToDll, typeof(TypeChecker).FullName);
                    typeChecker.Load("abc");
                    //dynamic handle = this.SeparateAppDomain.CreateInstanceFromAndUnwrap(proxyType.Assembly.Location, proxyType.FullName) as T;
                     //dynamic unwrapped = handle.Unwrap();
                    
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw;
                    //}
                }
                return _proxy;
            }
        }

        Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return null;
        }

        /// <summary>
        /// Cleans up SeparateDomainLoader object
        /// </summary>
        public void Unload()
        {
            if (_proxy != null)
            {
                _proxy = null;
            }
            if (_separateAppDomain != null)
            {
                //_separateAppDomain.AssemblyResolve -= Resolver.AssemblyResolve;
                AppDomain.Unload(_separateAppDomain);
                _separateAppDomain = null;
            }
        }

        //internal static class Resolver
        //{
        //    public static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        //    {
        //        return Assembly.LoadFrom(args.Name);
        //    }
        //}

        [Serializable]
        internal class CrossDomainCode : MarshalByRefObject
        {
            //public string Name { get; set; }

            public void ChangeName()
            {
                AppDomain.CurrentDomain.SetData("FriendlyName", AppDomain.CurrentDomain.FriendlyName);
            }

        }
    }
}
