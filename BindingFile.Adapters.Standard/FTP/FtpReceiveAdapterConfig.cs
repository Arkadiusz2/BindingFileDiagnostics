using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public partial class FtpReceiveAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ERRORTHRESHOLD = "errorThreshold";
        /*  2 */
        private const string _FILEMASK = "fileMask";
        /*  3 */
        private const string _FIREWALLPORT = "firewallPort";
        /*  4 */
        private const string _FIREWALLTYPE = "firewallType";
        /*  5 */
        private const string _MAXFILESIZE = "maxFileSize";
        /*  6 */
        private const string _MAXIMUMBATCHSIZE = "maximumBatchSize";
        /*  7 */
        private const string _MAXIMUMNUMBEROFFILES = "maximumNumberOfFiles";
        /*  8 */
        private const string _PASSIVEMODE = "passiveMode";
        /*  9 */
        private const string _PASSWORD = "password";
        /* 10 */
        private const string _POLLINGINTERVAL = "pollingInterval";
        /* 11 */
        private const string _POLLINGUNITOFMEASURE = "pollingUnitOfMeasure";
        /* 12 */
        private const string _REPRESENTATIONTYPE = "representationType";
        /* 13 */
        private const string _SERVERADDRESS = "serverAddress";
        /* 14 */
        private const string _SERVERPORT = "serverPort";
        /* 15 */
        private const string _TARGETFOLDER = "targetFolder";
        /* 16 */
        private const string _URI = "uri";
        /* 17 */
        private const string _USERNAME = "userName";
        #endregion

        #region Constructors
        public FtpReceiveAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.ErrorThreshold = this.AddProperty(_ERRORTHRESHOLD);
            /*  2 */
            this.FileMask = this.AddProperty(_FILEMASK);
            /*  3 */
            this.FirewallPort = this.AddProperty(_FIREWALLPORT);
            /*  4 */
            this.FirewallType = this.AddProperty(_FIREWALLTYPE);
            /*  5 */
            this.MaxFileSize = this.AddProperty(_MAXFILESIZE);
            /*  6 */
            this.MaximumBatchSize = this.AddProperty(_MAXIMUMBATCHSIZE);
            /*  7 */
            this.MaximumNumberOfFiles = this.AddProperty(_MAXIMUMNUMBEROFFILES);
            /*  8 */
            this.PassiveMode = this.AddProperty(_PASSIVEMODE);
            /*  9 */
            this.Password = this.AddProperty(_PASSWORD);
            /* 10 */
            this.PollingInterval = this.AddProperty(_POLLINGINTERVAL);
            /* 11 */
            this.PollingUnitOfMeasure = this.AddProperty(_POLLINGUNITOFMEASURE);
            /* 12 */
            this.RepresentationType = this.AddProperty(_REPRESENTATIONTYPE);
            /* 13 */
            this.ServerAddress = this.AddProperty(_SERVERADDRESS);
            /* 14 */
            this.ServerPort = this.AddProperty(_SERVERPORT);
            /* 15 */
            this.TargetFolder = this.AddProperty(_TARGETFOLDER);
            /* 16 */
            this.Uri = this.AddProperty(_URI);
            /* 17 */
            this.UserName = this.AddProperty(_USERNAME);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty ErrorThreshold;
        /*  2 */
        public readonly AdapterProperty FileMask;
        /*  3 */
        public readonly AdapterProperty FirewallPort;
        /*  4 */
        public readonly AdapterProperty FirewallType;
        /*  5 */
        public readonly AdapterProperty MaxFileSize;
        /*  6 */
        public readonly AdapterProperty MaximumBatchSize;
        /*  7 */
        public readonly AdapterProperty MaximumNumberOfFiles;
        /*  8 */
        public readonly AdapterProperty PassiveMode;
        /*  9 */
        public readonly AdapterProperty Password;
        /* 10 */
        public readonly AdapterProperty PollingInterval;
        /* 11 */
        public readonly AdapterProperty PollingUnitOfMeasure;
        /* 12 */
        public readonly AdapterProperty RepresentationType;
        /* 13 */
        public readonly AdapterProperty ServerAddress;
        /* 14 */
        public readonly AdapterProperty ServerPort;
        /* 15 */
        public readonly AdapterProperty TargetFolder;
        /* 16 */
        public readonly AdapterProperty Uri;
        /* 17 */
        public readonly AdapterProperty UserName;
        #endregion
    }
}
