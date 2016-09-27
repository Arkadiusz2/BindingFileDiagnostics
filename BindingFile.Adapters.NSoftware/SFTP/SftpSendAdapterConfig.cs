using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class SftpSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _AFTERCONNECT = "AfterConnect";
        /*  2 */
        private const string _AFTERPUT = "AfterPut";
        /*  3 */
        private const string _APPEND = "Append";
        /*  4 */
        private const string _BEFOREPUT = "BeforePut";
        /*  5 */
        private const string _CONNECTIONLIFETIME = "ConnectionLifetime";
        /*  6 */
        private const string _FIREWALL_AUTODETECT = "Firewall/AutoDetect";
        /*  7 */
        private const string _FIREWALL_FIREWALLTYPE = "Firewall/FirewallType";
        /*  8 */
        private const string _FIREWALL_HOST = "Firewall/Host";
        /*  9 */
        private const string _FIREWALL_PASSWORD = "Firewall/Password";
        /* 10 */
        private const string _FIREWALL_PORT = "Firewall/Port";
        /* 11 */
        private const string _FIREWALL_USER = "Firewall/User";
        /* 12 */
        private const string _LOCALFILE = "LocalFile";
        /* 13 */
        private const string _OTHER = "Other";
        /* 14 */
        private const string _OVERWRITE = "Overwrite";
        /* 15 */
        private const string _REMOTEFILE = "RemoteFile";
        /* 16 */
        private const string _REMOTEPATH = "RemotePath";
        /* 17 */
        private const string _REMOTETEMPPATH = "RemoteTempPath";
        /* 18 */
        private const string _SSHACCEPTSERVERHOSTKEY_ACCEPTANY = "SSHAcceptServerHostKey/AcceptAny";
        /* 19 */
        private const string _SSHACCEPTSERVERHOSTKEY_STORE = "SSHAcceptServerHostKey/Store";
        /* 20 */
        private const string _SSHACCEPTSERVERHOSTKEY_STOREPASSWORD = "SSHAcceptServerHostKey/StorePassword";
        /* 21 */
        private const string _SSHACCEPTSERVERHOSTKEY_STORETYPE = "SSHAcceptServerHostKey/StoreType";
        /* 22 */
        private const string _SSHACCEPTSERVERHOSTKEY_SUBJECT = "SSHAcceptServerHostKey/Subject";
        /* 23 */
        private const string _SSHAUTHMODE = "SSHAuthMode";
        /* 24 */
        private const string _SSHCERT_STORE = "SSHCert/Store";
        /* 25 */
        private const string _SSHCERT_STOREPASSWORD = "SSHCert/StorePassword";
        /* 26 */
        private const string _SSHCERT_STORETYPE = "SSHCert/StoreType";
        /* 27 */
        private const string _SSHCERT_SUBJECT = "SSHCert/Subject";
        /* 28 */
        private const string _SSHCOMPRESSIONALGORITHMS = "SSHCompressionAlgorithms";
        /* 29 */
        private const string _SSHHOST = "SSHHost";
        /* 30 */
        private const string _SSHPASSWORD = "SSHPassword";
        /* 31 */
        private const string _SSHPORT = "SSHPort";
        /* 32 */
        private const string _SSHUSER = "SSHUser";
        /* 33 */
        private const string _SSOAFFILIATE = "SSOAffiliate";
        /* 34 */
        private const string _TIMEOUT = "Timeout";
        /* 35 */
        private const string _TRANSPORTLOG_LOCATION = "TransportLog/Location";
        /* 36 */
        private const string _TRANSPORTLOG_LOGMODE = "TransportLog/LogMode";
        /* 37 */
        private const string _TRANSPORTLOG_LOGTYPE = "TransportLog/LogType";
        /* 38 */
        private const string _URI = "uri";
        #endregion

        #region Constructors
        public SftpSendAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.AfterConnect = this.AddProperty(_AFTERCONNECT);
            /*  2 */
            this.AfterPut = this.AddProperty(_AFTERPUT);
            /*  3 */
            this.Append = this.AddProperty(_APPEND);
            /*  4 */
            this.BeforePut = this.AddProperty(_BEFOREPUT);
            /*  5 */
            this.ConnectionLifetime = this.AddProperty(_CONNECTIONLIFETIME);
            /*  6 */
            this.Firewall_AutoDetect = this.AddProperty(_FIREWALL_AUTODETECT);
            /*  7 */
            this.Firewall_FirewallType = this.AddProperty(_FIREWALL_FIREWALLTYPE);
            /*  8 */
            this.Firewall_Host = this.AddProperty(_FIREWALL_HOST);
            /*  9 */
            this.Firewall_Password = this.AddProperty(_FIREWALL_PASSWORD);
            /* 10 */
            this.Firewall_Port = this.AddProperty(_FIREWALL_PORT);
            /* 11 */
            this.Firewall_User = this.AddProperty(_FIREWALL_USER);
            /* 12 */
            this.LocalFile = this.AddProperty(_LOCALFILE);
            /* 13 */
            this.Other = this.AddProperty(_OTHER);
            /* 14 */
            this.Overwrite = this.AddProperty(_OVERWRITE);
            /* 15 */
            this.RemoteFile = this.AddProperty(_REMOTEFILE);
            /* 16 */
            this.RemotePath = this.AddProperty(_REMOTEPATH);
            /* 17 */
            this.RemoteTempPath = this.AddProperty(_REMOTETEMPPATH);
            /* 18 */
            this.SSHAcceptServerHostKey_AcceptAny = this.AddProperty(_SSHACCEPTSERVERHOSTKEY_ACCEPTANY);
            /* 19 */
            this.SSHAcceptServerHostKey_Store = this.AddProperty(_SSHACCEPTSERVERHOSTKEY_STORE);
            /* 20 */
            this.SSHAcceptServerHostKey_StorePassword = this.AddProperty(_SSHACCEPTSERVERHOSTKEY_STOREPASSWORD);
            /* 21 */
            this.SSHAcceptServerHostKey_StoreType = this.AddProperty(_SSHACCEPTSERVERHOSTKEY_STORETYPE);
            /* 22 */
            this.SSHAcceptServerHostKey_Subject = this.AddProperty(_SSHACCEPTSERVERHOSTKEY_SUBJECT);
            /* 23 */
            this.SSHAuthMode = this.AddProperty(_SSHAUTHMODE);
            /* 24 */
            this.SSHCert_Store = this.AddProperty(_SSHCERT_STORE);
            /* 25 */
            this.SSHCert_StorePassword = this.AddProperty(_SSHCERT_STOREPASSWORD);
            /* 26 */
            this.SSHCert_StoreType = this.AddProperty(_SSHCERT_STORETYPE);
            /* 27 */
            this.SSHCert_Subject = this.AddProperty(_SSHCERT_SUBJECT);
            /* 28 */
            this.SSHCompressionAlgorithms = this.AddProperty(_SSHCOMPRESSIONALGORITHMS);
            /* 29 */
            this.SSHHost = this.AddProperty(_SSHHOST);
            /* 30 */
            this.SSHPassword = this.AddProperty(_SSHPASSWORD);
            /* 31 */
            this.SSHPort = this.AddProperty(_SSHPORT);
            /* 32 */
            this.SSHUser = this.AddProperty(_SSHUSER);
            /* 33 */
            this.SSOAffiliate = this.AddProperty(_SSOAFFILIATE);
            /* 34 */
            this.Timeout = this.AddProperty(_TIMEOUT);
            /* 35 */
            this.TransportLog_Location = this.AddProperty(_TRANSPORTLOG_LOCATION);
            /* 36 */
            this.TransportLog_LogMode = this.AddProperty(_TRANSPORTLOG_LOGMODE);
            /* 37 */
            this.TransportLog_LogType = this.AddProperty(_TRANSPORTLOG_LOGTYPE);
            /* 38 */
            this.Uri = this.AddProperty(_URI);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AfterConnect;
        /*  2 */
        public readonly AdapterProperty AfterPut;
        /*  3 */
        public readonly AdapterProperty Append;
        /*  4 */
        public readonly AdapterProperty BeforePut;
        /*  5 */
        public readonly AdapterProperty ConnectionLifetime;
        /*  6 */
        public readonly AdapterProperty Firewall_AutoDetect;
        /*  7 */
        public readonly AdapterProperty Firewall_FirewallType;
        /*  8 */
        public readonly AdapterProperty Firewall_Host;
        /*  9 */
        public readonly AdapterProperty Firewall_Password;
        /* 10 */
        public readonly AdapterProperty Firewall_Port;
        /* 11 */
        public readonly AdapterProperty Firewall_User;
        /* 12 */
        public readonly AdapterProperty LocalFile;
        /* 13 */
        public readonly AdapterProperty Other;
        /* 14 */
        public readonly AdapterProperty Overwrite;
        /* 15 */
        public readonly AdapterProperty RemoteFile;
        /* 16 */
        public readonly AdapterProperty RemotePath;
        /* 17 */
        public readonly AdapterProperty RemoteTempPath;
        /* 18 */
        public readonly AdapterProperty SSHAcceptServerHostKey_AcceptAny;
        /* 19 */
        public readonly AdapterProperty SSHAcceptServerHostKey_Store;
        /* 20 */
        public readonly AdapterProperty SSHAcceptServerHostKey_StorePassword;
        /* 21 */
        public readonly AdapterProperty SSHAcceptServerHostKey_StoreType;
        /* 22 */
        public readonly AdapterProperty SSHAcceptServerHostKey_Subject;
        /* 23 */
        public readonly AdapterProperty SSHAuthMode;
        /* 24 */
        public readonly AdapterProperty SSHCert_Store;
        /* 25 */
        public readonly AdapterProperty SSHCert_StorePassword;
        /* 26 */
        public readonly AdapterProperty SSHCert_StoreType;
        /* 27 */
        public readonly AdapterProperty SSHCert_Subject;
        /* 28 */
        public readonly AdapterProperty SSHCompressionAlgorithms;
        /* 29 */
        public readonly AdapterProperty SSHHost;
        /* 30 */
        public readonly AdapterProperty SSHPassword;
        /* 31 */
        public readonly AdapterProperty SSHPort;
        /* 32 */
        public readonly AdapterProperty SSHUser;
        /* 33 */
        public readonly AdapterProperty SSOAffiliate;
        /* 34 */
        public readonly AdapterProperty Timeout;
        /* 35 */
        public readonly AdapterProperty TransportLog_Location;
        /* 36 */
        public readonly AdapterProperty TransportLog_LogMode;
        /* 37 */
        public readonly AdapterProperty TransportLog_LogType;
        /* 38 */
        public readonly AdapterProperty Uri;
        #endregion
    }
}
