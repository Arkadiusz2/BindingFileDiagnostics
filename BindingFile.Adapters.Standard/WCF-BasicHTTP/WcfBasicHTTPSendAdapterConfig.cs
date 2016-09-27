using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class WcfBasicHttpSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ALGORITHMSUITE = "AlgorithmSuite";
        /*  2 */
        private const string _CLIENTCERTIFICATE = "ClientCertificate";
        /*  3 */
        private const string _CLOSETIMEOUT = "CloseTimeout";
        /*  4 */
        private const string _INBOUNDBODYLOCATION = "InboundBodyLocation";
        /*  5 */
        private const string _INBOUNDBODYPATHEXPRESSION = "InboundBodyPathExpression";
        /*  6 */
        private const string _INBOUNDNODEENCODING = "InboundNodeEncoding";
        /*  7 */
        private const string _MAXRECEIVEDMESSAGESIZE = "MaxReceivedMessageSize";
        /*  8 */
        private const string _MESSAGECLIENTCREDENTIALTYPE = "MessageClientCredentialType";
        /*  9 */
        private const string _MESSAGEENCODING = "MessageEncoding";
        /* 10 */
        private const string _OPENTIMEOUT = "OpenTimeout";
        /* 11 */
        private const string _OUTBOUNDBODYLOCATION = "OutboundBodyLocation";
        /* 12 */
        private const string _OUTBOUNDXMLTEMPLATE = "OutboundXmlTemplate";
        /* 13 */
        private const string _PROPAGATEFAULTMESSAGE = "PropagateFaultMessage";
        /* 14 */
        private const string _PROXYADDRESS = "ProxyAddress";
        /* 15 */
        private const string _PROXYTOUSE = "ProxyToUse";
        /* 16 */
        private const string _PROXYUSERNAME = "ProxyUserName";
        /* 17 */
        private const string _SECURITYMODE = "SecurityMode";
        /* 18 */
        private const string _SENDTIMEOUT = "SendTimeout";
        /* 19 */
        private const string _SERVICECERTIFICATE = "ServiceCertificate";
        /* 20 */
        private const string _STATICACTION = "StaticAction";
        /* 21 */
        private const string _TEXTENCODING = "TextEncoding";
        /* 22 */
        private const string _TRANSPORTCLIENTCREDENTIALTYPE = "TransportClientCredentialType";
        /* 23 */
        private const string _USESSO = "UseSSO";
        #endregion

        #region Constructors
        public WcfBasicHttpSendAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.AlgorithmSuite = this.AddProperty(_ALGORITHMSUITE);
            /*  2 */
            this.ClientCertificate = this.AddProperty(_CLIENTCERTIFICATE);
            /*  3 */
            this.CloseTimeout = this.AddProperty(_CLOSETIMEOUT);
            /*  4 */
            this.InboundBodyLocation = this.AddProperty(_INBOUNDBODYLOCATION);
            /*  5 */
            this.InboundBodyPathExpression = this.AddProperty(_INBOUNDBODYPATHEXPRESSION);
            /*  6 */
            this.InboundNodeEncoding = this.AddProperty(_INBOUNDNODEENCODING);
            /*  7 */
            this.MaxReceivedMessageSize = this.AddProperty(_MAXRECEIVEDMESSAGESIZE);
            /*  8 */
            this.MessageClientCredentialType = this.AddProperty(_MESSAGECLIENTCREDENTIALTYPE);
            /*  9 */
            this.MessageEncoding = this.AddProperty(_MESSAGEENCODING);
            /* 10 */
            this.OpenTimeout = this.AddProperty(_OPENTIMEOUT);
            /* 11 */
            this.OutboundBodyLocation = this.AddProperty(_OUTBOUNDBODYLOCATION);
            /* 12 */
            this.OutboundXmlTemplate = this.AddProperty(_OUTBOUNDXMLTEMPLATE);
            /* 13 */
            this.PropagateFaultMessage = this.AddProperty(_PROPAGATEFAULTMESSAGE);
            /* 14 */
            this.ProxyAddress = this.AddProperty(_PROXYADDRESS);
            /* 15 */
            this.ProxyToUse = this.AddProperty(_PROXYTOUSE);
            /* 16 */
            this.ProxyUserName = this.AddProperty(_PROXYUSERNAME);
            /* 17 */
            this.SecurityMode = this.AddProperty(_SECURITYMODE);
            /* 18 */
            this.SendTimeout = this.AddProperty(_SENDTIMEOUT);
            /* 19 */
            this.ServiceCertificate = this.AddProperty(_SERVICECERTIFICATE);
            /* 20 */
            this.StaticAction = this.AddProperty(_STATICACTION);
            /* 21 */
            this.TextEncoding = this.AddProperty(_TEXTENCODING);
            /* 22 */
            this.TransportClientCredentialType = this.AddProperty(_TRANSPORTCLIENTCREDENTIALTYPE);
            /* 23 */
            this.UseSSO = this.AddProperty(_USESSO);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AlgorithmSuite;
        /*  2 */
        public readonly AdapterProperty ClientCertificate;
        /*  3 */
        public readonly AdapterProperty CloseTimeout;
        /*  4 */
        public readonly AdapterProperty InboundBodyLocation;
        /*  5 */
        public readonly AdapterProperty InboundBodyPathExpression;
        /*  6 */
        public readonly AdapterProperty InboundNodeEncoding;
        /*  7 */
        public readonly AdapterProperty MaxReceivedMessageSize;
        /*  8 */
        public readonly AdapterProperty MessageClientCredentialType;
        /*  9 */
        public readonly AdapterProperty MessageEncoding;
        /* 10 */
        public readonly AdapterProperty OpenTimeout;
        /* 11 */
        public readonly AdapterProperty OutboundBodyLocation;
        /* 12 */
        public readonly AdapterProperty OutboundXmlTemplate;
        /* 13 */
        public readonly AdapterProperty PropagateFaultMessage;
        /* 14 */
        public readonly AdapterProperty ProxyAddress;
        /* 15 */
        public readonly AdapterProperty ProxyToUse;
        /* 16 */
        public readonly AdapterProperty ProxyUserName;
        /* 17 */
        public readonly AdapterProperty SecurityMode;
        /* 18 */
        public readonly AdapterProperty SendTimeout;
        /* 19 */
        public readonly AdapterProperty ServiceCertificate;
        /* 20 */
        public readonly AdapterProperty StaticAction;
        /* 21 */
        public readonly AdapterProperty TextEncoding;
        /* 22 */
        public readonly AdapterProperty TransportClientCredentialType;
        /* 23 */
        public readonly AdapterProperty UseSSO;
        #endregion
    }
}
