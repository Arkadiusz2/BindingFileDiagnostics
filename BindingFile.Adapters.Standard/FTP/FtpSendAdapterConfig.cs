using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{    
    public class FtpSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ALLOCATESTORAGE = "allocateStorage";
        /*  2 */
        private const string _CONNECTIONLIMIT = "connectionLimit";
        /*  3 */
        private const string _FIREWALLPORT = "firewallPort";
        /*  4 */
        private const string _FIREWALLTYPE = "firewallType";
        /*  5 */
        private const string _PASSIVEMODE = "passiveMode";
        /*  6 */
        private const string _PASSWORD = "password";
        /*  7 */
        private const string _REPRESENTATIONTYPE = "representationType";
        /*  8 */
        private const string _SERVERADDRESS = "serverAddress";
        /*  9 */
        private const string _SERVERPORT = "serverPort";
        /* 10 */
        private const string _TARGETFILENAME = "targetFileName";
        /* 11 */
        private const string _TARGETFOLDER = "targetFolder";
        /* 12 */
        private const string _URI = "uri";
        /* 13 */
        private const string _USERNAME = "userName";
        #endregion

        #region Constructors
        public FtpSendAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.AllocateStorage = this.AddProperty(_ALLOCATESTORAGE);
            /*  2 */
            this.ConnectionLimit = this.AddProperty(_CONNECTIONLIMIT);
            /*  3 */
            this.FirewallPort = this.AddProperty(_FIREWALLPORT);
            /*  4 */
            this.FirewallType = this.AddProperty(_FIREWALLTYPE);
            /*  5 */
            this.PassiveMode = this.AddProperty(_PASSIVEMODE);
            /*  6 */
            this.Password = this.AddProperty(_PASSWORD);
            /*  7 */
            this.RepresentationType = this.AddProperty(_REPRESENTATIONTYPE);
            /*  8 */
            this.ServerAddress = this.AddProperty(_SERVERADDRESS);
            /*  9 */
            this.ServerPort = this.AddProperty(_SERVERPORT);
            /* 10 */
            this.TargetFileName = this.AddProperty(_TARGETFILENAME);
            /* 11 */
            this.TargetFolder = this.AddProperty(_TARGETFOLDER);
            /* 12 */
            this.Uri = this.AddProperty(_URI);
            /* 13 */
            this.UserName = this.AddProperty(_USERNAME);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AllocateStorage;
        /*  2 */
        public readonly AdapterProperty ConnectionLimit;
        /*  3 */
        public readonly AdapterProperty FirewallPort;
        /*  4 */
        public readonly AdapterProperty FirewallType;
        /*  5 */
        public readonly AdapterProperty PassiveMode;
        /*  6 */
        public readonly AdapterProperty Password;
        /*  7 */
        public readonly AdapterProperty RepresentationType;
        /*  8 */
        public readonly AdapterProperty ServerAddress;
        /*  9 */
        public readonly AdapterProperty ServerPort;
        /* 10 */
        public readonly AdapterProperty TargetFileName;
        /* 11 */
        public readonly AdapterProperty TargetFolder;
        /* 12 */
        public readonly AdapterProperty Uri;
        /* 13 */
        public readonly AdapterProperty UserName;
        #endregion
    }
}
