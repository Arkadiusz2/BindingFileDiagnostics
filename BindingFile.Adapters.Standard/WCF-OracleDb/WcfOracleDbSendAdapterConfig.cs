using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class WcfOracleDbSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _AFFILIATEAPPLICATIONNAME = "AffiliateApplicationName";
        /*  2 */
        private const string _BINDINGCONFIGURATION = "BindingConfiguration";
        /*  3 */
        private const string _BINDINGTYPE = "BindingType";
        /*  4 */
        private const string _ENABLETRANSACTION = "EnableTransaction";
        /*  5 */
        private const string _ENDPOINTBEHAVIORCONFIGURATION = "EndpointBehaviorConfiguration";
        /*  6 */
        private const string _IDENTITY = "Identity";
        /*  7 */
        private const string _INBOUNDBODYLOCATION = "InboundBodyLocation";
        /*  8 */
        private const string _INBOUNDBODYPATHEXPRESSION = "InboundBodyPathExpression";
        /*  9 */
        private const string _INBOUNDNODEENCODING = "InboundNodeEncoding";
        /* 10 */
        private const string _ISOLATIONLEVEL = "IsolationLevel";
        /* 11 */
        private const string _OUTBOUNDBODYLOCATION = "OutboundBodyLocation";
        /* 12 */
        private const string _OUTBOUNDXMLTEMPLATE = "OutboundXmlTemplate";
        /* 13 */
        private const string _PASSWORD = "Password";
        /* 14 */
        private const string _PROPAGATEFAULTMESSAGE = "PropagateFaultMessage";
        /* 15 */
        private const string _PROXYADDRESS = "ProxyAddress";
        /* 16 */
        private const string _PROXYUSERNAME = "ProxyUserName";
        /* 17 */
        private const string _STATICACTION = "StaticAction";
        /* 18 */
        private const string _USERNAME = "UserName";
        /* 19 */
        private const string _USESSO = "UseSSO";
        #endregion

        #region Constructors
        public WcfOracleDbSendAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.AffiliateApplicationName = this.AddProperty(_AFFILIATEAPPLICATIONNAME);
            /*  2 */
            this.BindingConfiguration = this.AddProperty(_BINDINGCONFIGURATION);
            /*  3 */
            this.BindingType = this.AddProperty(_BINDINGTYPE);
            /*  4 */
            this.EnableTransaction = this.AddProperty(_ENABLETRANSACTION);
            /*  5 */
            this.EndpointBehaviorConfiguration = this.AddProperty(_ENDPOINTBEHAVIORCONFIGURATION);
            /*  6 */
            this.Identity = this.AddProperty(_IDENTITY);
            /*  7 */
            this.InboundBodyLocation = this.AddProperty(_INBOUNDBODYLOCATION);
            /*  8 */
            this.InboundBodyPathExpression = this.AddProperty(_INBOUNDBODYPATHEXPRESSION);
            /*  9 */
            this.InboundNodeEncoding = this.AddProperty(_INBOUNDNODEENCODING);
            /* 10 */
            this.IsolationLevel = this.AddProperty(_ISOLATIONLEVEL);
            /* 11 */
            this.OutboundBodyLocation = this.AddProperty(_OUTBOUNDBODYLOCATION);
            /* 12 */
            this.OutboundXmlTemplate = this.AddProperty(_OUTBOUNDXMLTEMPLATE);
            /* 13 */
            this.Password = this.AddProperty(_PASSWORD);
            /* 14 */
            this.PropagateFaultMessage = this.AddProperty(_PROPAGATEFAULTMESSAGE);
            /* 15 */
            this.ProxyAddress = this.AddProperty(_PROXYADDRESS);
            /* 16 */
            this.ProxyUserName = this.AddProperty(_PROXYUSERNAME);
            /* 17 */
            this.StaticAction = this.AddProperty(_STATICACTION);
            /* 18 */
            this.UserName = this.AddProperty(_USERNAME);
            /* 19 */
            this.UseSSO = this.AddProperty(_USESSO);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AffiliateApplicationName;
        /*  2 */
        public readonly AdapterProperty BindingConfiguration;
        /*  3 */
        public readonly AdapterProperty BindingType;
        /*  4 */
        public readonly AdapterProperty EnableTransaction;
        /*  5 */
        public readonly AdapterProperty EndpointBehaviorConfiguration;
        /*  6 */
        public readonly AdapterProperty Identity;
        /*  7 */
        public readonly AdapterProperty InboundBodyLocation;
        /*  8 */
        public readonly AdapterProperty InboundBodyPathExpression;
        /*  9 */
        public readonly AdapterProperty InboundNodeEncoding;
        /* 10 */
        public readonly AdapterProperty IsolationLevel;
        /* 11 */
        public readonly AdapterProperty OutboundBodyLocation;
        /* 12 */
        public readonly AdapterProperty OutboundXmlTemplate;
        /* 13 */
        public readonly AdapterProperty Password;
        /* 14 */
        public readonly AdapterProperty PropagateFaultMessage;
        /* 15 */
        public readonly AdapterProperty ProxyAddress;
        /* 16 */
        public readonly AdapterProperty ProxyUserName;
        /* 17 */
        public readonly AdapterProperty StaticAction;
        /* 18 */
        public readonly AdapterProperty UserName;
        /* 19 */
        public readonly AdapterProperty UseSSO;
        #endregion
    }
}
