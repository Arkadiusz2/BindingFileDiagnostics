using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RuleTargetsAttribute : System.Attribute
    {
        private RuleTargetsEnum _targets;
        private IEnumerable<IAdapterInfo> _adapterInfo = null;

        public RuleTargetsAttribute(RuleTargetsEnum targets)
            : this(targets, null)
        {
        }

        //public RuleTargetsAttribute(RuleTargetsEnum targets, string adapterName, string adapterConfigurationClsid)
        //{
        //    if (adapterName == null)
        //    {
        //        throw new ArgumentNullException("adapterName");
        //    }
        //    if (adapterConfigurationClsid == null)
        //    {
        //        throw new ArgumentNullException("adapterConfigurationClsid");
        //    }

        //    Initalize(targets, new AdapterInfo(adapterName, Guid.Parse(adapterConfigurationClsid)));
        //}       

        /// <summary>
        /// Defines binding file rule for selected adapter for specific category.
        /// TransportType for target other than ReceiveLocation or SendPort is ignored
        /// </summary>
        /// <param name="target">Artifact target</param>
        /// <param name="transportType">Transport type</param>
        public RuleTargetsAttribute(RuleTargetsEnum targets, params Type[] adapterInfoType)
        {
            List<IAdapterInfo> adapterInfo = new List<IAdapterInfo>();
            
            if (adapterInfoType != null && adapterInfoType.Length > 0)
            {
                foreach (Type t in adapterInfoType)
                {

                    if (!t.Implements<IAdapterInfo>())
                    {
                        throw new Exception(string.Format("Type {0} does not implement IAdapterInfo interface", t.FullName));
                    }

                    if (!t.HasParameterlessConstructor())
                    {
                        throw new Exception(string.Format("Type {0} must implement a parameterless constructor", t.FullName));
                    }

                    adapterInfo.Add((IAdapterInfo)Activator.CreateInstance(t));
                }
            }

            Initalize(targets, adapterInfo);
        }

        protected void Initalize(RuleTargetsEnum targets, IEnumerable<IAdapterInfo> adapterInfo)
        {
            if (adapterInfo != null)
            {
                // Validate artefact type in combination with adapter
                int a = (int)_targets;
                int b = (int)(RuleTargetsEnum.ReceiveLocation | RuleTargetsEnum.TransportInfo);

                if (a.BitwiseAndNot(b) > 0)
                {
                    throw new InvalidOperationException("Adapter specific rule may only be defined for RuleTargetsEnum.ReceiveLocation and/or RuleTargetsEnum.TransportInfo.");
                }
            }
            
            this._targets = targets;
            this._adapterInfo = adapterInfo;
        }


        public IEnumerable<IAdapterInfo> AdapterInfo
        {
            get
            {
                return this._adapterInfo;
            }
        }

        public RuleTargetsEnum Targets
        {
            get
            {
                return this._targets;
            }
        }
    }
}


