using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class Pop3ReceiveAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _APPLYMIME = "applyMIME";
        /*  2 */
        private const string _AUTHENTICATIONSCHEME = "authenticationScheme";
        /*  3 */
        private const string _BODYPARTINDEX = "bodyPartIndex";
        /*  4 */
        private const string _ERRORTHRESHOLD = "errorThreshold";
        /*  5 */
        private const string _MAILSERVER = "mailServer";
        /*  6 */
        private const string _PASSWORD = "password";
        /*  7 */
        private const string _POLLINGINTERVAL = "pollingInterval";
        /*  8 */
        private const string _POLLINGUNITOFMEASURE = "pollingUnitOfMeasure";
        /*  9 */
        private const string _SERVERPORT = "serverPort";
        /* 10 */
        private const string _SSLREQUIRED = "sslRequired";
        /* 11 */
        private const string _URI = "uri";
        /* 12 */
        private const string _USERNAME = "userName";
        #endregion

        #region Constructors
        public Pop3ReceiveAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.ApplyMIME = this.AddProperty(_APPLYMIME);
            /*  2 */
            this.AuthenticationScheme = this.AddProperty(_AUTHENTICATIONSCHEME);
            /*  3 */
            this.BodyPartIndex = this.AddProperty(_BODYPARTINDEX);
            /*  4 */
            this.ErrorThreshold = this.AddProperty(_ERRORTHRESHOLD);
            /*  5 */
            this.MailServer = this.AddProperty(_MAILSERVER);
            /*  6 */
            this.Password = this.AddProperty(_PASSWORD);
            /*  7 */
            this.PollingInterval = this.AddProperty(_POLLINGINTERVAL);
            /*  8 */
            this.PollingUnitOfMeasure = this.AddProperty(_POLLINGUNITOFMEASURE);
            /*  9 */
            this.ServerPort = this.AddProperty(_SERVERPORT);
            /* 10 */
            this.SslRequired = this.AddProperty(_SSLREQUIRED);
            /* 11 */
            this.Uri = this.AddProperty(_URI);
            /* 12 */
            this.UserName = this.AddProperty(_USERNAME);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty ApplyMIME;
        /*  2 */
        public readonly AdapterProperty AuthenticationScheme;
        /*  3 */
        public readonly AdapterProperty BodyPartIndex;
        /*  4 */
        public readonly AdapterProperty ErrorThreshold;
        /*  5 */
        public readonly AdapterProperty MailServer;
        /*  6 */
        public readonly AdapterProperty Password;
        /*  7 */
        public readonly AdapterProperty PollingInterval;
        /*  8 */
        public readonly AdapterProperty PollingUnitOfMeasure;
        /*  9 */
        public readonly AdapterProperty ServerPort;
        /* 10 */
        public readonly AdapterProperty SslRequired;
        /* 11 */
        public readonly AdapterProperty Uri;
        /* 12 */
        public readonly AdapterProperty UserName;
        #endregion
    }
}
