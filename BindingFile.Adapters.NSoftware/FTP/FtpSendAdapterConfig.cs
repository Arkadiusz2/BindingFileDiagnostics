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
        private const string _ACCOUNT = "Account";
        /*  2 */
        private const string _AFTERCONNECT = "AfterConnect";
        /*  3 */
        private const string _AFTERPUT = "AfterPut";
        /*  4 */
        private const string _APPEND = "Append";
        /*  5 */
        private const string _BEFOREPUT = "BeforePut";
        /*  6 */
        private const string _CONNECTIONLIFETIME = "ConnectionLifetime";
        /*  7 */
        private const string _FIREWALL_AUTODETECT = "Firewall/AutoDetect";
        /*  8 */
        private const string _FIREWALL_FIREWALLTYPE = "Firewall/FirewallType";
        /*  9 */
        private const string _FIREWALL_HOST = "Firewall/Host";
        /* 10 */
        private const string _FIREWALL_PASSWORD = "Firewall/Password";
        /* 11 */
        private const string _FIREWALL_PORT = "Firewall/Port";
        /* 12 */
        private const string _FIREWALL_USER = "Firewall/User";
        /* 13 */
        private const string _FTPPORT = "FTPPort";
        /* 14 */
        private const string _FTPSERVER = "FTPServer";
        /* 15 */
        private const string _OTHER = "Other";
        /* 16 */
        private const string _OVERWRITE = "Overwrite";
        /* 17 */
        private const string _PASSIVE = "Passive";
        /* 18 */
        private const string _PASSWORD = "Password";
        /* 19 */
        private const string _REMOTEFILE = "RemoteFile";
        /* 20 */
        private const string _REMOTEPATH = "RemotePath";
        /* 21 */
        private const string _REMOTETEMPPATH = "RemoteTempPath";
        /* 22 */
        private const string _RUNTIMELICENSE = "RuntimeLicense";
        /* 23 */
        private const string _SSLACCEPTSERVERCERT_ACCEPTANY = "SSLAcceptServerCert/AcceptAny";
        /* 24 */
        private const string _SSLACCEPTSERVERCERT_STORE = "SSLAcceptServerCert/Store";
        /* 25 */
        private const string _SSLACCEPTSERVERCERT_STOREPASSWORD = "SSLAcceptServerCert/StorePassword";
        /* 26 */
        private const string _SSLACCEPTSERVERCERT_STORETYPE = "SSLAcceptServerCert/StoreType";
        /* 27 */
        private const string _SSLACCEPTSERVERCERT_SUBJECT = "SSLAcceptServerCert/Subject";
        /* 28 */
        private const string _SSLCERT_STORE = "SSLCert/Store";
        /* 29 */
        private const string _SSLCERT_STOREPASSWORD = "SSLCert/StorePassword";
        /* 30 */
        private const string _SSLCERT_STORETYPE = "SSLCert/StoreType";
        /* 31 */
        private const string _SSLCERT_SUBJECT = "SSLCert/Subject";
        /* 32 */
        private const string _SSLSTARTMODE = "SSLStartMode";
        /* 33 */
        private const string _SSOAFFILIATE = "SSOAffiliate";
        /* 34 */
        private const string _TIMEOUT = "Timeout";
        /* 35 */
        private const string _TRANSFERMODE = "TransferMode";
        /* 36 */
        private const string _TRANSPORTLOG_LOCATION = "TransportLog/Location";
        /* 37 */
        private const string _TRANSPORTLOG_LOGMODE = "TransportLog/LogMode";
        /* 38 */
        private const string _TRANSPORTLOG_LOGTYPE = "TransportLog/LogType";
        /* 39 */
        private const string _URI = "uri";
        /* 40 */
        private const string _URIIDENTITY = "URIIdentity";
        /* 41 */
        private const string _USER = "User";
        /* 42 */
        private const string _USESIMPLEDIRLIST = "UseSimpleDirList";
        #endregion

        #region Constructors
        public FtpSendAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.Account = this.AddProperty(_ACCOUNT);
            /*  2 */
            this.AfterConnect = this.AddProperty(_AFTERCONNECT);
            /*  3 */
            this.AfterPut = this.AddProperty(_AFTERPUT);
            /*  4 */
            this.Append = this.AddProperty(_APPEND);
            /*  5 */
            this.BeforePut = this.AddProperty(_BEFOREPUT);
            /*  6 */
            this.ConnectionLifetime = this.AddProperty(_CONNECTIONLIFETIME);
            /*  7 */
            this.Firewall_AutoDetect = this.AddProperty(_FIREWALL_AUTODETECT);
            /*  8 */
            this.Firewall_FirewallType = this.AddProperty(_FIREWALL_FIREWALLTYPE);
            /*  9 */
            this.Firewall_Host = this.AddProperty(_FIREWALL_HOST);
            /* 10 */
            this.Firewall_Password = this.AddProperty(_FIREWALL_PASSWORD);
            /* 11 */
            this.Firewall_Port = this.AddProperty(_FIREWALL_PORT);
            /* 12 */
            this.Firewall_User = this.AddProperty(_FIREWALL_USER);
            /* 13 */
            this.FTPPort = this.AddProperty(_FTPPORT);
            /* 14 */
            this.FTPServer = this.AddProperty(_FTPSERVER);
            /* 15 */
            this.Other = this.AddProperty(_OTHER);
            /* 16 */
            this.Overwrite = this.AddProperty(_OVERWRITE);
            /* 17 */
            this.Passive = this.AddProperty(_PASSIVE);
            /* 18 */
            this.Password = this.AddProperty(_PASSWORD);
            /* 19 */
            this.RemoteFile = this.AddProperty(_REMOTEFILE);
            /* 20 */
            this.RemotePath = this.AddProperty(_REMOTEPATH);
            /* 21 */
            this.RemoteTempPath = this.AddProperty(_REMOTETEMPPATH);
            /* 22 */
            this.RuntimeLicense = this.AddProperty(_RUNTIMELICENSE);
            /* 23 */
            this.SSLAcceptServerCert_AcceptAny = this.AddProperty(_SSLACCEPTSERVERCERT_ACCEPTANY);
            /* 24 */
            this.SSLAcceptServerCert_Store = this.AddProperty(_SSLACCEPTSERVERCERT_STORE);
            /* 25 */
            this.SSLAcceptServerCert_StorePassword = this.AddProperty(_SSLACCEPTSERVERCERT_STOREPASSWORD);
            /* 26 */
            this.SSLAcceptServerCert_StoreType = this.AddProperty(_SSLACCEPTSERVERCERT_STORETYPE);
            /* 27 */
            this.SSLAcceptServerCert_Subject = this.AddProperty(_SSLACCEPTSERVERCERT_SUBJECT);
            /* 28 */
            this.SSLCert_Store = this.AddProperty(_SSLCERT_STORE);
            /* 29 */
            this.SSLCert_StorePassword = this.AddProperty(_SSLCERT_STOREPASSWORD);
            /* 30 */
            this.SSLCert_StoreType = this.AddProperty(_SSLCERT_STORETYPE);
            /* 31 */
            this.SSLCert_Subject = this.AddProperty(_SSLCERT_SUBJECT);
            /* 32 */
            this.SSLStartMode = this.AddProperty(_SSLSTARTMODE);
            /* 33 */
            this.SSOAffiliate = this.AddProperty(_SSOAFFILIATE);
            /* 34 */
            this.Timeout = this.AddProperty(_TIMEOUT);
            /* 35 */
            this.TransferMode = this.AddProperty(_TRANSFERMODE);
            /* 36 */
            this.TransportLog_Location = this.AddProperty(_TRANSPORTLOG_LOCATION);
            /* 37 */
            this.TransportLog_LogMode = this.AddProperty(_TRANSPORTLOG_LOGMODE);
            /* 38 */
            this.TransportLog_LogType = this.AddProperty(_TRANSPORTLOG_LOGTYPE);
            /* 39 */
            this.Uri = this.AddProperty(_URI);
            /* 40 */
            this.URIIdentity = this.AddProperty(_URIIDENTITY);
            /* 41 */
            this.User = this.AddProperty(_USER);
            /* 42 */
            this.UseSimpleDirList = this.AddProperty(_USESIMPLEDIRLIST);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty Account;
        /*  2 */
        public readonly AdapterProperty AfterConnect;
        /*  3 */
        public readonly AdapterProperty AfterPut;
        /*  4 */
        public readonly AdapterProperty Append;
        /*  5 */
        public readonly AdapterProperty BeforePut;
        /*  6 */
        public readonly AdapterProperty ConnectionLifetime;
        /*  7 */
        public readonly AdapterProperty Firewall_AutoDetect;
        /*  8 */
        public readonly AdapterProperty Firewall_FirewallType;
        /*  9 */
        public readonly AdapterProperty Firewall_Host;
        /* 10 */
        public readonly AdapterProperty Firewall_Password;
        /* 11 */
        public readonly AdapterProperty Firewall_Port;
        /* 12 */
        public readonly AdapterProperty Firewall_User;
        /* 13 */
        public readonly AdapterProperty FTPPort;
        /* 14 */
        public readonly AdapterProperty FTPServer;
        /* 15 */
        public readonly AdapterProperty Other;
        /* 16 */
        public readonly AdapterProperty Overwrite;
        /* 17 */
        public readonly AdapterProperty Passive;
        /* 18 */
        public readonly AdapterProperty Password;
        /* 19 */
        public readonly AdapterProperty RemoteFile;
        /* 20 */
        public readonly AdapterProperty RemotePath;
        /* 21 */
        public readonly AdapterProperty RemoteTempPath;
        /* 22 */
        public readonly AdapterProperty RuntimeLicense;
        /* 23 */
        public readonly AdapterProperty SSLAcceptServerCert_AcceptAny;
        /* 24 */
        public readonly AdapterProperty SSLAcceptServerCert_Store;
        /* 25 */
        public readonly AdapterProperty SSLAcceptServerCert_StorePassword;
        /* 26 */
        public readonly AdapterProperty SSLAcceptServerCert_StoreType;
        /* 27 */
        public readonly AdapterProperty SSLAcceptServerCert_Subject;
        /* 28 */
        public readonly AdapterProperty SSLCert_Store;
        /* 29 */
        public readonly AdapterProperty SSLCert_StorePassword;
        /* 30 */
        public readonly AdapterProperty SSLCert_StoreType;
        /* 31 */
        public readonly AdapterProperty SSLCert_Subject;
        /* 32 */
        public readonly AdapterProperty SSLStartMode;
        /* 33 */
        public readonly AdapterProperty SSOAffiliate;
        /* 34 */
        public readonly AdapterProperty Timeout;
        /* 35 */
        public readonly AdapterProperty TransferMode;
        /* 36 */
        public readonly AdapterProperty TransportLog_Location;
        /* 37 */
        public readonly AdapterProperty TransportLog_LogMode;
        /* 38 */
        public readonly AdapterProperty TransportLog_LogType;
        /* 39 */
        public readonly AdapterProperty Uri;
        /* 40 */
        public readonly AdapterProperty URIIdentity;
        /* 41 */
        public readonly AdapterProperty User;
        /* 42 */
        public readonly AdapterProperty UseSimpleDirList;
        #endregion
    }
}
