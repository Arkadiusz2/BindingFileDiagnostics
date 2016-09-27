using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Extensions;
using BindingFile.Diagnostics.Rules;
using System.Reflection;
using BindingFile.Diagnostics.Engine;

namespace BindingFile.Diagnostics.Rules.DeployedArtifacts
{
    //[Serializable]
    //[RuleTargets(RuleTargetsEnum.ServiceRef)]
    public class OrchestrationMustBeInGac : RuleTemplate
    {
        private enum BoundToEnum
        {
            None,
            SendPort,
            SendPortGroup,
            ReceivePort
        }

        SeparateDomainLoader<TypeChecker> _separateDomainLoader = null;

        public OrchestrationMustBeInGac()
            : base("Orchestration must be in GAC")
        {
            _separateDomainLoader = new SeparateDomainLoader<TypeChecker>();

            //_appDomain = AppDomain.CreateDomain("OrchestrationMustBeInGac");
            //_appDomain.ReflectionOnlyAssemblyResolve += _appDomain_ReflectionOnlyAssemblyResolve;
        }

        //Assembly _appDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    return Assembly.ReflectionOnlyLoadFrom(args.Name);
        //}

        public string TypeNameFor(string shorTypeName, string fullAssemblyName)
        {
            return string.Format("{0}, {1}", shorTypeName, fullAssemblyName);
        }
        
        protected override void Validate(object item, List<Message> messages)
        {
            ServiceRef orchestration = (ServiceRef)item;

            if (orchestration.Name != null)
            {
                //try
                //{
                    _separateDomainLoader.Proxy.Load(orchestration.ModuleRef.FullName);
                //}
                //catch (Exception ex)
                //{
                //    throw;
                //}

                //string orchestrationTypeName = this.TypeNameFor(orchestration.Name, orchestration.ModuleRef.FullName);
                //object orchestrationType = _appDomain.CreateInstanceAndUnwrap(orchestration.Name, orchestration.ModuleRef.FullName);
                //Assembly assembly = Assembly.Load(orchestration.ModuleRef.FullName);

                //Type orchestrationType = assembly.GetType(orchestration.Name, false, false);
                //Type orchestrationType = Type.ReflectionOnlyGetType(orchestrationTypeName, false, false);
                //if (assembly == null)
                //{
                //    string text = string.Format("Type '{0}' cannot be found in GAC", orchestration.ModuleRef.FullName);
                //    messages.Add(new Message(text));
                //}
            }  
        }

        //Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    return _assemblyResolver.Resolve(AppDomain.CurrentDomain, args);
        //}
    }
}
