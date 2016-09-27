using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules
{
    public abstract class RuleTemplate : BaseBindingRule, IBindingRule
    {
        private bool _exceptionRaised = false;

        public RuleTemplate(string name)
            : this(name, false)
        {            
        }

        public RuleTemplate(string name, bool isConfigurable)
            : base(name, isConfigurable)
        {
            InitializeClassAttributes();
            this.BreakOnException = true;
        }

        /// <summary>
        /// Checks if receive location or send port transport should be validated
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns></returns>
        private bool CanValidate(ProtocolType protocol)
        {
            if (this.Adapters == null)
            {
                return true;
            }

            Guid guid; 
            if (!Guid.TryParseExact(protocol.ConfigurationClsid, "D", out guid))
            {
                return false;
            }

            return this.Adapters.Any(adapter => adapter.Name == protocol.Name && adapter.ConfigurationClsid == guid);
        }

        #region Properties
        public BindingInfo ValidatedBindingInfo
        {
            get;
            private set;
        }

        public bool BreakOnException
        {
            get;
            private set;
        }

        private bool MustBreak
        {
            get
            {
                return this.BreakOnException && _exceptionRaised;
            }
        }
        #endregion

        #region Read attributes that decorate the class
        private void InitializeClassAttributes()
        {
            this.ValidatedBindingInfo = null;
            this.Targets = this.GetTargets();
            this.Adapters = this.GetAdapters();
        }

        public RuleTargetsEnum Targets
        {
            get;
            private set;
        }
        protected IEnumerable<IAdapterInfo> Adapters
        {
            get;
            private set;            
        }
        #endregion

        public override bool Validate(BindingFile.BindingInfo bindingInfo/*, List<BindingRuleValidationEventArgs> validationResults*/)
        {            
            bool result = true;
            _exceptionRaised = false;
            List<BindingRuleValidationEventArgs> ruleValidationResults = new List<BindingRuleValidationEventArgs>();
            try
            {
                this.ValidatedBindingInfo = bindingInfo;

                BindingRuleValidationEventArgs e;

                // Orchestrations
                if (this.Targets.HasFlag(RuleTargetsEnum.ModuleRef) || this.Targets.HasFlag(RuleTargetsEnum.ServiceRef))
                {
                    foreach (ModuleRef moduleRef in bindingInfo.ModuleRefCollection)
                    {
                        if (this.Targets.HasFlag(RuleTargetsEnum.ModuleRef))
                        {
                            result &= InnerValidate(moduleRef, out e);
                            if (this.MustBreak)
                            {
                                return result;
                            }
                        }

                        if (this.Targets.HasFlag(RuleTargetsEnum.ServiceRef))
                        {
                            foreach (ServiceRef service in moduleRef.Services)
                            {
                                result &= InnerValidate(service, out e);
                                if (this.MustBreak)
                                {
                                    return result;
                                }
                            }
                        }
                    }
                }

                // Send ports
                if (this.Targets.HasFlag(RuleTargetsEnum.SendPort) || this.Targets.HasFlag(RuleTargetsEnum.TransportInfo))
                {
                    foreach (SendPort sendPort in bindingInfo.SendPortCollection)
                    {
                        if (this.Targets.HasFlag(RuleTargetsEnum.SendPort))
                        {
                            result &= InnerValidate(sendPort, out e);
                            if (this.MustBreak)
                            {
                                return result;
                            }
                        }

                        if (this.Targets.HasFlag(RuleTargetsEnum.TransportInfo))
                        {
                            if (CanValidate(sendPort.PrimaryTransport.TransportType))
                            {
                                // Primary transport of send port
                                result &= InnerValidate(sendPort.PrimaryTransport, out e);
                                if (this.MustBreak)
                                {
                                    return result;
                                }
                            }

                            // Secondary transport of send port
                            if (sendPort.SecondaryTransport.IsDefined())
                            {
                                if (CanValidate(sendPort.SecondaryTransport.TransportType))
                                {
                                    result &= InnerValidate(sendPort.SecondaryTransport, out e);
                                    if (this.MustBreak)
                                    {
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }

                // Send port groups
                if (this.Targets.HasFlag(RuleTargetsEnum.DistributionList))
                {
                    foreach (DistributionList sendPortGroup in bindingInfo.DistributionListCollection)
                    {
                        result &= InnerValidate(sendPortGroup, out e);
                        if (this.MustBreak)
                        {
                            return result;
                        }
                    }
                }

                // Receive ports
                if (this.Targets.HasFlag(RuleTargetsEnum.ReceivePort) || this.Targets.HasFlag(RuleTargetsEnum.ReceiveLocation))
                {
                    foreach (ReceivePort receivePort in bindingInfo.ReceivePortCollection)
                    {
                        if (this.Targets.HasFlag(RuleTargetsEnum.ReceivePort))
                        {
                            result &= InnerValidate(receivePort, out e);
                            if (this.MustBreak)
                            {
                                return result;
                            }
                        }

                        // Receive locations
                        if (this.Targets.HasFlag(RuleTargetsEnum.ReceiveLocation))
                        {
                            foreach (ReceiveLocation receiveLocation in receivePort.ReceiveLocations)
                            {
                                if (CanValidate(receiveLocation.ReceiveLocationTransportType))
                                {
                                    result &= InnerValidate(receiveLocation, out e);
                                    if (this.MustBreak)
                                    {
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            finally
            {
                this.ValidatedBindingInfo = null;
            }

            return result;
        }

        protected bool InnerValidate(object item, out BindingRuleValidationEventArgs e/*List<BindingRuleValidationEventArgs> ruleValidationResults*/)
        {
            List<Message> messages = new List<Message>();
            bool validationResult;
            Exception validationException = null;
            try
            {                
                Validate(item, messages);
                validationResult = (messages.Count == 0);
            }
            catch (Exception ex)
            {
                validationException = ex;
                validationResult = false;
                _exceptionRaised = true;
            }

            e = new BindingRuleValidationEventArgs(item, messages, validationResult, validationException);

            OnValidated(e);
            return validationResult;
        }

        #region Validation functions to override
        //protected abstract bool Validate(object item, out IEnumerable<string> messages);

        protected abstract void Validate(object item, List<Message> messages);
        #endregion

    }
}
