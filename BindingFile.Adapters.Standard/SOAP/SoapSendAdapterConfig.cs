using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class SoapSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _AUTHENTICATIONSCHEME = "AuthenticationScheme";
        /*  2 */
        private const string _PROXYPORT = "ProxyPort";
        /*  3 */
        private const string _USEHANDLERSETTING = "UseHandlerSetting";
        /*  4 */
        private const string _USEPROXY = "UseProxy";
        /*  5 */
        private const string _USESOAP12 = "UseSoap12";
        /*  6 */
        private const string _USINGORCHESTRATION = "UsingOrchestration";
        #endregion

        #region Constructors
        public SoapSendAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.AuthenticationScheme = this.AddProperty(_AUTHENTICATIONSCHEME);
            /*  2 */
            this.ProxyPort = this.AddProperty(_PROXYPORT);
            /*  3 */
            this.UseHandlerSetting = this.AddProperty(_USEHANDLERSETTING);
            /*  4 */
            this.UseProxy = this.AddProperty(_USEPROXY);
            /*  5 */
            this.UseSoap12 = this.AddProperty(_USESOAP12);
            /*  6 */
            this.UsingOrchestration = this.AddProperty(_USINGORCHESTRATION);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AuthenticationScheme;
        /*  2 */
        public readonly AdapterProperty ProxyPort;
        /*  3 */
        public readonly AdapterProperty UseHandlerSetting;
        /*  4 */
        public readonly AdapterProperty UseProxy;
        /*  5 */
        public readonly AdapterProperty UseSoap12;
        /*  6 */
        public readonly AdapterProperty UsingOrchestration;
        #endregion
    }
}
