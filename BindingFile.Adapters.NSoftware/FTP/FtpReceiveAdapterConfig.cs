using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class FtpReceiveAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ACCOUNT = "Account";
        /*  2 */
        private const string _AFTERCONNECT = "AfterConnect";
        /*  3 */
        private const string _AFTERGET = "AfterGet";
        /*  4 */
        private const string _BEFOREGET = "BeforeGet";
        /*  5 */
        private const string _DELETEMODE = "DeleteMode";
        /*  6 */
        private const string _ERRORTHRESHOLD = "ErrorThreshold";
        /*  7 */
        private const string _FILEMASK = "FileMask";
        /*  8 */
        private const string _FIREWALL_AUTODETECT = "Firewall/AutoDetect";
        /*  9 */
        private const string _FIREWALL_FIREWALLTYPE = "Firewall/FirewallType";
        /* 10 */
        private const string _FIREWALL_HOST = "Firewall/Host";
        /* 11 */
        private const string _FIREWALL_PASSWORD = "Firewall/Password";
        /* 12 */
        private const string _FIREWALL_PORT = "Firewall/Port";
        /* 13 */
        private const string _FIREWALL_USER = "Firewall/User";
        /* 14 */
        private const string _FTPPORT = "FTPPort";
        /* 15 */
        private const string _FTPSERVER = "FTPServer";
        /* 16 */
        private const string _MAXBATCHSIZE = "MaxBatchSize";
        /* 17 */
        private const string _MAXFILECOUNT = "MaxFileCount";
        /* 18 */
        private const string _MAXFILESIZE = "MaxFileSize";
        /* 19 */
        private const string _OTHER = "Other";
        /* 20 */
        private const string _PASSIVE = "Passive";
        /* 21 */
        private const string _PASSWORD = "Password";
        /* 22 */
        private const string _PERSISTENTCONNECTION = "PersistentConnection";
        /* 23 */
        private const string _POLLINGINTERVAL = "PollingInterval";
        /* 24 */
        private const string _REMOTEPATH = "RemotePath";
        /* 25 */
        private const string _RUNTIMELICENSE = "RuntimeLicense";
        /* 26 */
        private const string _SSLACCEPTSERVERCERT_ACCEPTANY = "SSLAcceptServerCert/AcceptAny";
        /* 27 */
        private const string _SSLACCEPTSERVERCERT_STORE = "SSLAcceptServerCert/Store";
        /* 28 */
        private const string _SSLACCEPTSERVERCERT_STOREPASSWORD = "SSLAcceptServerCert/StorePassword";
        /* 29 */
        private const string _SSLACCEPTSERVERCERT_STORETYPE = "SSLAcceptServerCert/StoreType";
        /* 30 */
        private const string _SSLACCEPTSERVERCERT_SUBJECT = "SSLAcceptServerCert/Subject";
        /* 31 */
        private const string _SSLCERT_STORE = "SSLCert/Store";
        /* 32 */
        private const string _SSLCERT_STOREPASSWORD = "SSLCert/StorePassword";
        /* 33 */
        private const string _SSLCERT_STORETYPE = "SSLCert/StoreType";
        /* 34 */
        private const string _SSLCERT_SUBJECT = "SSLCert/Subject";
        /* 35 */
        private const string _SSLSTARTMODE = "SSLStartMode";
        /* 36 */
        private const string _SSOAFFILIATE = "SSOAffiliate";
        /* 37 */
        private const string _TEMPPATH = "TempPath";
        /* 38 */
        private const string _TIMEOUT = "Timeout";
        /* 39 */
        private const string _TRANSFERMODE = "TransferMode";
        /* 40 */
        private const string _TRANSPORTLOG_LOCATION = "TransportLog/Location";
        /* 41 */
        private const string _TRANSPORTLOG_LOGMODE = "TransportLog/LogMode";
        /* 42 */
        private const string _TRANSPORTLOG_LOGTYPE = "TransportLog/LogType";
        /* 43 */
        private const string _URI = "uri";
        /* 44 */
        private const string _URIIDENTITY = "URIIdentity";
        /* 45 */
        private const string _USER = "User";
        /* 46 */
        private const string _USESIMPLEDIRLIST = "UseSimpleDirList";
        #endregion

        #region Constructors
        public FtpReceiveAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.Account = this.AddProperty(_ACCOUNT);
            /*  2 */
            this.AfterConnect = this.AddProperty(_AFTERCONNECT);
            /*  3 */
            this.AfterGet = this.AddProperty(_AFTERGET);
            /*  4 */
            this.BeforeGet = this.AddProperty(_BEFOREGET);
            /*  5 */
            this.DeleteMode = this.AddProperty(_DELETEMODE);
            /*  6 */
            this.ErrorThreshold = this.AddProperty(_ERRORTHRESHOLD);
            /*  7 */
            this.FileMask = this.AddProperty(_FILEMASK);
            /*  8 */
            this.Firewall_AutoDetect = this.AddProperty(_FIREWALL_AUTODETECT);
            /*  9 */
            this.Firewall_FirewallType = this.AddProperty(_FIREWALL_FIREWALLTYPE);
            /* 10 */
            this.Firewall_Host = this.AddProperty(_FIREWALL_HOST);
            /* 11 */
            this.Firewall_Password = this.AddProperty(_FIREWALL_PASSWORD);
            /* 12 */
            this.Firewall_Port = this.AddProperty(_FIREWALL_PORT);
            /* 13 */
            this.Firewall_User = this.AddProperty(_FIREWALL_USER);
            /* 14 */
            this.FTPPort = this.AddProperty(_FTPPORT);
            /* 15 */
            this.FTPServer = this.AddProperty(_FTPSERVER);
            /* 16 */
            this.MaxBatchSize = this.AddProperty(_MAXBATCHSIZE);
            /* 17 */
            this.MaxFileCount = this.AddProperty(_MAXFILECOUNT);
            /* 18 */
            this.MaxFileSize = this.AddProperty(_MAXFILESIZE);
            /* 19 */
            this.Other = this.AddProperty(_OTHER);
            /* 20 */
            this.Passive = this.AddProperty(_PASSIVE);
            /* 21 */
            this.Password = this.AddProperty(_PASSWORD);
            /* 22 */
            this.PersistentConnection = this.AddProperty(_PERSISTENTCONNECTION);
            /* 23 */
            this.PollingInterval = this.AddProperty(_POLLINGINTERVAL);
            /* 24 */
            this.RemotePath = this.AddProperty(_REMOTEPATH);
            /* 25 */
            this.RuntimeLicense = this.AddProperty(_RUNTIMELICENSE);
            /* 26 */
            this.SSLAcceptServerCert_AcceptAny = this.AddProperty(_SSLACCEPTSERVERCERT_ACCEPTANY);
            /* 27 */
            this.SSLAcceptServerCert_Store = this.AddProperty(_SSLACCEPTSERVERCERT_STORE);
            /* 28 */
            this.SSLAcceptServerCert_StorePassword = this.AddProperty(_SSLACCEPTSERVERCERT_STOREPASSWORD);
            /* 29 */
            this.SSLAcceptServerCert_StoreType = this.AddProperty(_SSLACCEPTSERVERCERT_STORETYPE);
            /* 30 */
            this.SSLAcceptServerCert_Subject = this.AddProperty(_SSLACCEPTSERVERCERT_SUBJECT);
            /* 31 */
            this.SSLCert_Store = this.AddProperty(_SSLCERT_STORE);
            /* 32 */
            this.SSLCert_StorePassword = this.AddProperty(_SSLCERT_STOREPASSWORD);
            /* 33 */
            this.SSLCert_StoreType = this.AddProperty(_SSLCERT_STORETYPE);
            /* 34 */
            this.SSLCert_Subject = this.AddProperty(_SSLCERT_SUBJECT);
            /* 35 */
            this.SSLStartMode = this.AddProperty(_SSLSTARTMODE);
            /* 36 */
            this.SSOAffiliate = this.AddProperty(_SSOAFFILIATE);
            /* 37 */
            this.TempPath = this.AddProperty(_TEMPPATH);
            /* 38 */
            this.Timeout = this.AddProperty(_TIMEOUT);
            /* 39 */
            this.TransferMode = this.AddProperty(_TRANSFERMODE);
            /* 40 */
            this.TransportLog_Location = this.AddProperty(_TRANSPORTLOG_LOCATION);
            /* 41 */
            this.TransportLog_LogMode = this.AddProperty(_TRANSPORTLOG_LOGMODE);
            /* 42 */
            this.TransportLog_LogType = this.AddProperty(_TRANSPORTLOG_LOGTYPE);
            /* 43 */
            this.Uri = this.AddProperty(_URI);
            /* 44 */
            this.URIIdentity = this.AddProperty(_URIIDENTITY);
            /* 45 */
            this.User = this.AddProperty(_USER);
            /* 46 */
            this.UseSimpleDirList = this.AddProperty(_USESIMPLEDIRLIST);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty Account;
        /*  2 */
        public readonly AdapterProperty AfterConnect;
        /*  3 */
        public readonly AdapterProperty AfterGet;
        /*  4 */
        public readonly AdapterProperty BeforeGet;
        /*  5 */
        public readonly AdapterProperty DeleteMode;
        /*  6 */
        public readonly AdapterProperty ErrorThreshold;
        /*  7 */
        public readonly AdapterProperty FileMask;
        /*  8 */
        public readonly AdapterProperty Firewall_AutoDetect;
        /*  9 */
        public readonly AdapterProperty Firewall_FirewallType;
        /* 10 */
        public readonly AdapterProperty Firewall_Host;
        /* 11 */
        public readonly AdapterProperty Firewall_Password;
        /* 12 */
        public readonly AdapterProperty Firewall_Port;
        /* 13 */
        public readonly AdapterProperty Firewall_User;
        /* 14 */
        public readonly AdapterProperty FTPPort;
        /* 15 */
        public readonly AdapterProperty FTPServer;
        /* 16 */
        public readonly AdapterProperty MaxBatchSize;
        /* 17 */
        public readonly AdapterProperty MaxFileCount;
        /* 18 */
        public readonly AdapterProperty MaxFileSize;
        /* 19 */
        public readonly AdapterProperty Other;
        /* 20 */
        public readonly AdapterProperty Passive;
        /* 21 */
        public readonly AdapterProperty Password;
        /* 22 */
        public readonly AdapterProperty PersistentConnection;
        /* 23 */
        public readonly AdapterProperty PollingInterval;
        /* 24 */
        public readonly AdapterProperty RemotePath;
        /* 25 */
        public readonly AdapterProperty RuntimeLicense;
        /* 26 */
        public readonly AdapterProperty SSLAcceptServerCert_AcceptAny;
        /* 27 */
        public readonly AdapterProperty SSLAcceptServerCert_Store;
        /* 28 */
        public readonly AdapterProperty SSLAcceptServerCert_StorePassword;
        /* 29 */
        public readonly AdapterProperty SSLAcceptServerCert_StoreType;
        /* 30 */
        public readonly AdapterProperty SSLAcceptServerCert_Subject;
        /* 31 */
        public readonly AdapterProperty SSLCert_Store;
        /* 32 */
        public readonly AdapterProperty SSLCert_StorePassword;
        /* 33 */
        public readonly AdapterProperty SSLCert_StoreType;
        /* 34 */
        public readonly AdapterProperty SSLCert_Subject;
        /* 35 */
        public readonly AdapterProperty SSLStartMode;
        /* 36 */
        public readonly AdapterProperty SSOAffiliate;
        /* 37 */
        public readonly AdapterProperty TempPath;
        /* 38 */
        public readonly AdapterProperty Timeout;
        /* 39 */
        public readonly AdapterProperty TransferMode;
        /* 40 */
        public readonly AdapterProperty TransportLog_Location;
        /* 41 */
        public readonly AdapterProperty TransportLog_LogMode;
        /* 42 */
        public readonly AdapterProperty TransportLog_LogType;
        /* 43 */
        public readonly AdapterProperty Uri;
        /* 44 */
        public readonly AdapterProperty URIIdentity;
        /* 45 */
        public readonly AdapterProperty User;
        /* 46 */
        public readonly AdapterProperty UseSimpleDirList;
        #endregion
    }

}
