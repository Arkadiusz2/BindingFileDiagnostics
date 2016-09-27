using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class WssReceiveAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ADAPTERWSPORT = "AdapterWSPort";
        /*  2 */
        private const string _ARCHIVEFILENAME = "ArchiveFileName";
        /*  3 */
        private const string _ARCHIVELOCATION = "ArchiveLocation";
        /*  4 */
        private const string _BATCHSIZE = "BatchSize";
        /*  5 */
        private const string _ERRORTHRESHOLD = "ErrorThreshold";
        /*  6 */
        private const string _NAMESPACEALIASES = "NamespaceAliases";
        /*  7 */
        private const string _OFFICEINTEGRATION = "OfficeIntegration";
        /*  8 */
        private const string _OVERWRITE = "Overwrite";
        /*  9 */
        private const string _POLLINGINTERVAL = "PollingInterval";
        /* 10 */
        private const string _SITEURL = "SiteUrl";
        /* 11 */
        private const string _TIMEOUT = "Timeout";
        /* 12 */
        private const string _URI = "uri";
        /* 13 */
        private const string _VIEWNAME = "ViewName";
        /* 14 */
        private const string _WSSLOCATION = "WssLocation";
        #endregion

        #region Constructors
        public WssReceiveAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.AdapterWSPort = this.AddProperty(_ADAPTERWSPORT);
            /*  2 */
            this.ArchiveFileName = this.AddProperty(_ARCHIVEFILENAME);
            /*  3 */
            this.ArchiveLocation = this.AddProperty(_ARCHIVELOCATION);
            /*  4 */
            this.BatchSize = this.AddProperty(_BATCHSIZE);
            /*  5 */
            this.ErrorThreshold = this.AddProperty(_ERRORTHRESHOLD);
            /*  6 */
            this.NamespaceAliases = this.AddProperty(_NAMESPACEALIASES);
            /*  7 */
            this.OfficeIntegration = this.AddProperty(_OFFICEINTEGRATION);
            /*  8 */
            this.Overwrite = this.AddProperty(_OVERWRITE);
            /*  9 */
            this.PollingInterval = this.AddProperty(_POLLINGINTERVAL);
            /* 10 */
            this.SiteUrl = this.AddProperty(_SITEURL);
            /* 11 */
            this.Timeout = this.AddProperty(_TIMEOUT);
            /* 12 */
            this.Uri = this.AddProperty(_URI);
            /* 13 */
            this.ViewName = this.AddProperty(_VIEWNAME);
            /* 14 */
            this.WssLocation = this.AddProperty(_WSSLOCATION);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AdapterWSPort;
        /*  2 */
        public readonly AdapterProperty ArchiveFileName;
        /*  3 */
        public readonly AdapterProperty ArchiveLocation;
        /*  4 */
        public readonly AdapterProperty BatchSize;
        /*  5 */
        public readonly AdapterProperty ErrorThreshold;
        /*  6 */
        public readonly AdapterProperty NamespaceAliases;
        /*  7 */
        public readonly AdapterProperty OfficeIntegration;
        /*  8 */
        public readonly AdapterProperty Overwrite;
        /*  9 */
        public readonly AdapterProperty PollingInterval;
        /* 10 */
        public readonly AdapterProperty SiteUrl;
        /* 11 */
        public readonly AdapterProperty Timeout;
        /* 12 */
        public readonly AdapterProperty Uri;
        /* 13 */
        public readonly AdapterProperty ViewName;
        /* 14 */
        public readonly AdapterProperty WssLocation;
        #endregion
    }
}
