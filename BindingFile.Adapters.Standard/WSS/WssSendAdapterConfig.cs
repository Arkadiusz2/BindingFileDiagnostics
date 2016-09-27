using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class WssSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ADAPTERWSPORT = "AdapterWSPort";
        /*  2 */
        private const string _CUSTOMTEMPLATESDOCLIB = "CustomTemplatesDocLib";
        /*  3 */
        private const string _CUSTOMTEMPLATESNAMESPACECOL = "CustomTemplatesNamespaceCol";
        /*  4 */
        private const string _FILENAME = "FileName";
        /*  5 */
        private const string _NAMESPACEALIASES = "NamespaceAliases";
        /*  6 */
        private const string _OFFICEINTEGRATION = "OfficeIntegration";
        /*  7 */
        private const string _OVERWRITE = "Overwrite";
        /*  8 */
        private const string _PROPERTYNAME1 = "PropertyName1";
        /*  9 */
        private const string _PROPERTYNAME10 = "PropertyName10";
        /* 10 */
        private const string _PROPERTYNAME11 = "PropertyName11";
        /* 11 */
        private const string _PROPERTYNAME12 = "PropertyName12";
        /* 12 */
        private const string _PROPERTYNAME13 = "PropertyName13";
        /* 13 */
        private const string _PROPERTYNAME14 = "PropertyName14";
        /* 14 */
        private const string _PROPERTYNAME15 = "PropertyName15";
        /* 15 */
        private const string _PROPERTYNAME16 = "PropertyName16";
        /* 16 */
        private const string _PROPERTYNAME2 = "PropertyName2";
        /* 17 */
        private const string _PROPERTYNAME3 = "PropertyName3";
        /* 18 */
        private const string _PROPERTYNAME4 = "PropertyName4";
        /* 19 */
        private const string _PROPERTYNAME5 = "PropertyName5";
        /* 20 */
        private const string _PROPERTYNAME6 = "PropertyName6";
        /* 21 */
        private const string _PROPERTYNAME7 = "PropertyName7";
        /* 22 */
        private const string _PROPERTYNAME8 = "PropertyName8";
        /* 23 */
        private const string _PROPERTYNAME9 = "PropertyName9";
        /* 24 */
        private const string _PROPERTYSOURCE1 = "PropertySource1";
        /* 25 */
        private const string _PROPERTYSOURCE10 = "PropertySource10";
        /* 26 */
        private const string _PROPERTYSOURCE11 = "PropertySource11";
        /* 27 */
        private const string _PROPERTYSOURCE12 = "PropertySource12";
        /* 28 */
        private const string _PROPERTYSOURCE13 = "PropertySource13";
        /* 29 */
        private const string _PROPERTYSOURCE14 = "PropertySource14";
        /* 30 */
        private const string _PROPERTYSOURCE15 = "PropertySource15";
        /* 31 */
        private const string _PROPERTYSOURCE16 = "PropertySource16";
        /* 32 */
        private const string _PROPERTYSOURCE2 = "PropertySource2";
        /* 33 */
        private const string _PROPERTYSOURCE3 = "PropertySource3";
        /* 34 */
        private const string _PROPERTYSOURCE4 = "PropertySource4";
        /* 35 */
        private const string _PROPERTYSOURCE5 = "PropertySource5";
        /* 36 */
        private const string _PROPERTYSOURCE6 = "PropertySource6";
        /* 37 */
        private const string _PROPERTYSOURCE7 = "PropertySource7";
        /* 38 */
        private const string _PROPERTYSOURCE8 = "PropertySource8";
        /* 39 */
        private const string _PROPERTYSOURCE9 = "PropertySource9";
        /* 40 */
        private const string _SITEURL = "SiteUrl";
        /* 41 */
        private const string _TEMPLATESDOCLIB = "TemplatesDocLib";
        /* 42 */
        private const string _TEMPLATESNAMESPACECOL = "TemplatesNamespaceCol";
        /* 43 */
        private const string _TIMEOUT = "Timeout";
        /* 44 */
        private const string _URI = "uri";
        /* 45 */
        private const string _WSSLOCATION = "WssLocation";
        #endregion

        #region Constructors
        public WssSendAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.AdapterWSPort = this.AddProperty(_ADAPTERWSPORT);
            /*  2 */
            this.CustomTemplatesDocLib = this.AddProperty(_CUSTOMTEMPLATESDOCLIB);
            /*  3 */
            this.CustomTemplatesNamespaceCol = this.AddProperty(_CUSTOMTEMPLATESNAMESPACECOL);
            /*  4 */
            this.FileName = this.AddProperty(_FILENAME);
            /*  5 */
            this.NamespaceAliases = this.AddProperty(_NAMESPACEALIASES);
            /*  6 */
            this.OfficeIntegration = this.AddProperty(_OFFICEINTEGRATION);
            /*  7 */
            this.Overwrite = this.AddProperty(_OVERWRITE);
            /*  8 */
            this.PropertyName1 = this.AddProperty(_PROPERTYNAME1);
            /*  9 */
            this.PropertyName10 = this.AddProperty(_PROPERTYNAME10);
            /* 10 */
            this.PropertyName11 = this.AddProperty(_PROPERTYNAME11);
            /* 11 */
            this.PropertyName12 = this.AddProperty(_PROPERTYNAME12);
            /* 12 */
            this.PropertyName13 = this.AddProperty(_PROPERTYNAME13);
            /* 13 */
            this.PropertyName14 = this.AddProperty(_PROPERTYNAME14);
            /* 14 */
            this.PropertyName15 = this.AddProperty(_PROPERTYNAME15);
            /* 15 */
            this.PropertyName16 = this.AddProperty(_PROPERTYNAME16);
            /* 16 */
            this.PropertyName2 = this.AddProperty(_PROPERTYNAME2);
            /* 17 */
            this.PropertyName3 = this.AddProperty(_PROPERTYNAME3);
            /* 18 */
            this.PropertyName4 = this.AddProperty(_PROPERTYNAME4);
            /* 19 */
            this.PropertyName5 = this.AddProperty(_PROPERTYNAME5);
            /* 20 */
            this.PropertyName6 = this.AddProperty(_PROPERTYNAME6);
            /* 21 */
            this.PropertyName7 = this.AddProperty(_PROPERTYNAME7);
            /* 22 */
            this.PropertyName8 = this.AddProperty(_PROPERTYNAME8);
            /* 23 */
            this.PropertyName9 = this.AddProperty(_PROPERTYNAME9);
            /* 24 */
            this.PropertySource1 = this.AddProperty(_PROPERTYSOURCE1);
            /* 25 */
            this.PropertySource10 = this.AddProperty(_PROPERTYSOURCE10);
            /* 26 */
            this.PropertySource11 = this.AddProperty(_PROPERTYSOURCE11);
            /* 27 */
            this.PropertySource12 = this.AddProperty(_PROPERTYSOURCE12);
            /* 28 */
            this.PropertySource13 = this.AddProperty(_PROPERTYSOURCE13);
            /* 29 */
            this.PropertySource14 = this.AddProperty(_PROPERTYSOURCE14);
            /* 30 */
            this.PropertySource15 = this.AddProperty(_PROPERTYSOURCE15);
            /* 31 */
            this.PropertySource16 = this.AddProperty(_PROPERTYSOURCE16);
            /* 32 */
            this.PropertySource2 = this.AddProperty(_PROPERTYSOURCE2);
            /* 33 */
            this.PropertySource3 = this.AddProperty(_PROPERTYSOURCE3);
            /* 34 */
            this.PropertySource4 = this.AddProperty(_PROPERTYSOURCE4);
            /* 35 */
            this.PropertySource5 = this.AddProperty(_PROPERTYSOURCE5);
            /* 36 */
            this.PropertySource6 = this.AddProperty(_PROPERTYSOURCE6);
            /* 37 */
            this.PropertySource7 = this.AddProperty(_PROPERTYSOURCE7);
            /* 38 */
            this.PropertySource8 = this.AddProperty(_PROPERTYSOURCE8);
            /* 39 */
            this.PropertySource9 = this.AddProperty(_PROPERTYSOURCE9);
            /* 40 */
            this.SiteUrl = this.AddProperty(_SITEURL);
            /* 41 */
            this.TemplatesDocLib = this.AddProperty(_TEMPLATESDOCLIB);
            /* 42 */
            this.TemplatesNamespaceCol = this.AddProperty(_TEMPLATESNAMESPACECOL);
            /* 43 */
            this.Timeout = this.AddProperty(_TIMEOUT);
            /* 44 */
            this.Uri = this.AddProperty(_URI);
            /* 45 */
            this.WssLocation = this.AddProperty(_WSSLOCATION);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AdapterWSPort;
        /*  2 */
        public readonly AdapterProperty CustomTemplatesDocLib;
        /*  3 */
        public readonly AdapterProperty CustomTemplatesNamespaceCol;
        /*  4 */
        public readonly AdapterProperty FileName;
        /*  5 */
        public readonly AdapterProperty NamespaceAliases;
        /*  6 */
        public readonly AdapterProperty OfficeIntegration;
        /*  7 */
        public readonly AdapterProperty Overwrite;
        /*  8 */
        public readonly AdapterProperty PropertyName1;
        /*  9 */
        public readonly AdapterProperty PropertyName10;
        /* 10 */
        public readonly AdapterProperty PropertyName11;
        /* 11 */
        public readonly AdapterProperty PropertyName12;
        /* 12 */
        public readonly AdapterProperty PropertyName13;
        /* 13 */
        public readonly AdapterProperty PropertyName14;
        /* 14 */
        public readonly AdapterProperty PropertyName15;
        /* 15 */
        public readonly AdapterProperty PropertyName16;
        /* 16 */
        public readonly AdapterProperty PropertyName2;
        /* 17 */
        public readonly AdapterProperty PropertyName3;
        /* 18 */
        public readonly AdapterProperty PropertyName4;
        /* 19 */
        public readonly AdapterProperty PropertyName5;
        /* 20 */
        public readonly AdapterProperty PropertyName6;
        /* 21 */
        public readonly AdapterProperty PropertyName7;
        /* 22 */
        public readonly AdapterProperty PropertyName8;
        /* 23 */
        public readonly AdapterProperty PropertyName9;
        /* 24 */
        public readonly AdapterProperty PropertySource1;
        /* 25 */
        public readonly AdapterProperty PropertySource10;
        /* 26 */
        public readonly AdapterProperty PropertySource11;
        /* 27 */
        public readonly AdapterProperty PropertySource12;
        /* 28 */
        public readonly AdapterProperty PropertySource13;
        /* 29 */
        public readonly AdapterProperty PropertySource14;
        /* 30 */
        public readonly AdapterProperty PropertySource15;
        /* 31 */
        public readonly AdapterProperty PropertySource16;
        /* 32 */
        public readonly AdapterProperty PropertySource2;
        /* 33 */
        public readonly AdapterProperty PropertySource3;
        /* 34 */
        public readonly AdapterProperty PropertySource4;
        /* 35 */
        public readonly AdapterProperty PropertySource5;
        /* 36 */
        public readonly AdapterProperty PropertySource6;
        /* 37 */
        public readonly AdapterProperty PropertySource7;
        /* 38 */
        public readonly AdapterProperty PropertySource8;
        /* 39 */
        public readonly AdapterProperty PropertySource9;
        /* 40 */
        public readonly AdapterProperty SiteUrl;
        /* 41 */
        public readonly AdapterProperty TemplatesDocLib;
        /* 42 */
        public readonly AdapterProperty TemplatesNamespaceCol;
        /* 43 */
        public readonly AdapterProperty Timeout;
        /* 44 */
        public readonly AdapterProperty Uri;
        /* 45 */
        public readonly AdapterProperty WssLocation;
        #endregion
    }
}
