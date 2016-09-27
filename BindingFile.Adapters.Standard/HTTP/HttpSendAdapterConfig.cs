using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class HttpAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _AFFILIATEAPPLICATIONNAME = "AffiliateApplicationName";
        /*  2 */
        private const string _AUTHENTICATIONSCHEME = "AuthenticationScheme";
        /*  3 */
        private const string _ENABLECHUNKEDENCODING = "EnableChunkedEncoding";
        /*  4 */
        private const string _PASSWORD = "Password";
        /*  5 */
        private const string _PROXYNAME = "ProxyName";
        /*  6 */
        private const string _PROXYPORT = "ProxyPort";
        /*  7 */
        private const string _PROXYUSERNAME = "ProxyUsername";
        /*  8 */
        private const string _USEHANDLERSETTING = "UseHandlerSetting";
        /*  9 */
        private const string _USEPROXY = "UseProxy";
        /* 10 */
        private const string _USERNAME = "Username";
        /* 11 */
        private const string _USESSO = "UseSSO";
        #endregion

        #region Constructors
        public HttpAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.AffiliateApplicationName = this.AddProperty(_AFFILIATEAPPLICATIONNAME);
            /*  2 */
            this.AuthenticationScheme = this.AddProperty(_AUTHENTICATIONSCHEME);
            /*  3 */
            this.EnableChunkedEncoding = this.AddProperty(_ENABLECHUNKEDENCODING);
            /*  4 */
            this.Password = this.AddProperty(_PASSWORD);
            /*  5 */
            this.ProxyName = this.AddProperty(_PROXYNAME);
            /*  6 */
            this.ProxyPort = this.AddProperty(_PROXYPORT);
            /*  7 */
            this.ProxyUsername = this.AddProperty(_PROXYUSERNAME);
            /*  8 */
            this.UseHandlerSetting = this.AddProperty(_USEHANDLERSETTING);
            /*  9 */
            this.UseProxy = this.AddProperty(_USEPROXY);
            /* 10 */
            this.Username = this.AddProperty(_USERNAME);
            /* 11 */
            this.UseSSO = this.AddProperty(_USESSO);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AffiliateApplicationName;
        /*  2 */
        public readonly AdapterProperty AuthenticationScheme;
        /*  3 */
        public readonly AdapterProperty EnableChunkedEncoding;
        /*  4 */
        public readonly AdapterProperty Password;
        /*  5 */
        public readonly AdapterProperty ProxyName;
        /*  6 */
        public readonly AdapterProperty ProxyPort;
        /*  7 */
        public readonly AdapterProperty ProxyUsername;
        /*  8 */
        public readonly AdapterProperty UseHandlerSetting;
        /*  9 */
        public readonly AdapterProperty UseProxy;
        /* 10 */
        public readonly AdapterProperty Username;
        /* 11 */
        public readonly AdapterProperty UseSSO;
        #endregion
    }
}
