using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class WcfWsHttpSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ALGORITHMSUITE = "AlgorithmSuite";
        /*  2 */
        private const string _CLOSETIMEOUT = "CloseTimeout";
        /*  3 */
        private const string _ENABLETRANSACTION = "EnableTransaction";
        /*  4 */
        private const string _ESTABLISHSECURITYCONTEXT = "EstablishSecurityContext";
        /*  5 */
        private const string _INBOUNDBODYLOCATION = "InboundBodyLocation";
        /*  6 */
        private const string _INBOUNDNODEENCODING = "InboundNodeEncoding";
        /*  7 */
        private const string _MAXRECEIVEDMESSAGESIZE = "MaxReceivedMessageSize";
        /*  8 */
        private const string _MESSAGECLIENTCREDENTIALTYPE = "MessageClientCredentialType";
        /*  9 */
        private const string _MESSAGEENCODING = "MessageEncoding";
        /* 10 */
        private const string _NEGOTIATESERVICECREDENTIAL = "NegotiateServiceCredential";
        /* 11 */
        private const string _OPENTIMEOUT = "OpenTimeout";
        /* 12 */
        private const string _OUTBOUNDBODYLOCATION = "OutboundBodyLocation";
        /* 13 */
        private const string _OUTBOUNDXMLTEMPLATE = "OutboundXmlTemplate";
        /* 14 */
        private const string _PROPAGATEFAULTMESSAGE = "PropagateFaultMessage";
        /* 15 */
        private const string _PROXYTOUSE = "ProxyToUse";
        /* 16 */
        private const string _SECURITYMODE = "SecurityMode";
        /* 17 */
        private const string _SENDTIMEOUT = "SendTimeout";
        /* 18 */
        private const string _STATICACTION = "StaticAction";
        /* 19 */
        private const string _TEXTENCODING = "TextEncoding";
        /* 20 */
        private const string _TRANSPORTCLIENTCREDENTIALTYPE = "TransportClientCredentialType";
        /* 21 */
        private const string _USESSO = "UseSSO";
        #endregion

        #region Constructors
        public WcfWsHttpSendAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.AlgorithmSuite = this.AddProperty(_ALGORITHMSUITE);
            /*  2 */
            this.CloseTimeout = this.AddProperty(_CLOSETIMEOUT);
            /*  3 */
            this.EnableTransaction = this.AddProperty(_ENABLETRANSACTION);
            /*  4 */
            this.EstablishSecurityContext = this.AddProperty(_ESTABLISHSECURITYCONTEXT);
            /*  5 */
            this.InboundBodyLocation = this.AddProperty(_INBOUNDBODYLOCATION);
            /*  6 */
            this.InboundNodeEncoding = this.AddProperty(_INBOUNDNODEENCODING);
            /*  7 */
            this.MaxReceivedMessageSize = this.AddProperty(_MAXRECEIVEDMESSAGESIZE);
            /*  8 */
            this.MessageClientCredentialType = this.AddProperty(_MESSAGECLIENTCREDENTIALTYPE);
            /*  9 */
            this.MessageEncoding = this.AddProperty(_MESSAGEENCODING);
            /* 10 */
            this.NegotiateServiceCredential = this.AddProperty(_NEGOTIATESERVICECREDENTIAL);
            /* 11 */
            this.OpenTimeout = this.AddProperty(_OPENTIMEOUT);
            /* 12 */
            this.OutboundBodyLocation = this.AddProperty(_OUTBOUNDBODYLOCATION);
            /* 13 */
            this.OutboundXmlTemplate = this.AddProperty(_OUTBOUNDXMLTEMPLATE);
            /* 14 */
            this.PropagateFaultMessage = this.AddProperty(_PROPAGATEFAULTMESSAGE);
            /* 15 */
            this.ProxyToUse = this.AddProperty(_PROXYTOUSE);
            /* 16 */
            this.SecurityMode = this.AddProperty(_SECURITYMODE);
            /* 17 */
            this.SendTimeout = this.AddProperty(_SENDTIMEOUT);
            /* 18 */
            this.StaticAction = this.AddProperty(_STATICACTION);
            /* 19 */
            this.TextEncoding = this.AddProperty(_TEXTENCODING);
            /* 20 */
            this.TransportClientCredentialType = this.AddProperty(_TRANSPORTCLIENTCREDENTIALTYPE);
            /* 21 */
            this.UseSSO = this.AddProperty(_USESSO);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AlgorithmSuite;
        /*  2 */
        public readonly AdapterProperty CloseTimeout;
        /*  3 */
        public readonly AdapterProperty EnableTransaction;
        /*  4 */
        public readonly AdapterProperty EstablishSecurityContext;
        /*  5 */
        public readonly AdapterProperty InboundBodyLocation;
        /*  6 */
        public readonly AdapterProperty InboundNodeEncoding;
        /*  7 */
        public readonly AdapterProperty MaxReceivedMessageSize;
        /*  8 */
        public readonly AdapterProperty MessageClientCredentialType;
        /*  9 */
        public readonly AdapterProperty MessageEncoding;
        /* 10 */
        public readonly AdapterProperty NegotiateServiceCredential;
        /* 11 */
        public readonly AdapterProperty OpenTimeout;
        /* 12 */
        public readonly AdapterProperty OutboundBodyLocation;
        /* 13 */
        public readonly AdapterProperty OutboundXmlTemplate;
        /* 14 */
        public readonly AdapterProperty PropagateFaultMessage;
        /* 15 */
        public readonly AdapterProperty ProxyToUse;
        /* 16 */
        public readonly AdapterProperty SecurityMode;
        /* 17 */
        public readonly AdapterProperty SendTimeout;
        /* 18 */
        public readonly AdapterProperty StaticAction;
        /* 19 */
        public readonly AdapterProperty TextEncoding;
        /* 20 */
        public readonly AdapterProperty TransportClientCredentialType;
        /* 21 */
        public readonly AdapterProperty UseSSO;
        #endregion
    }
}
