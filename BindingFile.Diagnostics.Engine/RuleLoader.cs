using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using BindingFile.Diagnostics.Rules;

using System.Runtime.InteropServices;
using System.Xml;

namespace BindingFile.Diagnostics.Engine
{
    public class RuleLoader
    {
        #region Implement static assembly resolver
        static RuleLoader()
        {
            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        #endregion

        public event EventHandler<RuleLoadedEventArgs> RuleLoaded;

        protected void OnRuleLoaded(RuleLoadedEventArgs e)
        {
            if (this.RuleLoaded != null)
            {
                this.RuleLoaded(this, e);
            }
        }

        private IEnumerable<Type> GetBindingRuleTypes(string path)
        {
            var q = from file in Directory.GetFiles(path, "*.dll")
                    let assembly = Assembly.LoadFrom(file)
                    from t in this.GetBindingRuleTypes(assembly)
                    select t;

            return q;
        }

        private IEnumerable<Type> GetBindingRuleTypes(Assembly assembly)
        {
            var q = from t in assembly.GetLoadableTypes()
                    where t.IsClass && t.IsVisible && !t.IsAbstract && t.HasParameterlessConstructor() && t.Implements<IBindingRule>()
                    select t;

            return q;
        }

        public List<IBindingRule> Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            List<IBindingRule> bindingRules = new List<IBindingRule>();
            ResolveEventHandler resolveEventHandler = new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            try
            {
                AppDomain.CurrentDomain.AssemblyResolve += resolveEventHandler;

                foreach (Type t in GetBindingRuleTypes(path))
                {
                    IBindingRule bindingRule = null;
                    try
                    {
                        bindingRule = (IBindingRule)Activator.CreateInstance(t);
                        bindingRules.Add(bindingRule);

                        OnRuleLoaded(new RuleLoadedEventArgs(bindingRule, t, null));
                    }
                    catch (Exception ex)
                    {
                        OnRuleLoaded(new RuleLoadedEventArgs(bindingRule, t, ex));
                    }
                }
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= resolveEventHandler;
            }

            return bindingRules;
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return AssemblyResolver.Resolve((AppDomain)sender, args);
        }
    }
}
