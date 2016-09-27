using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class SftpReceiveAdapterConfig : AdapterConfig
    {
        #region Constants   
        /*  1 */ 
        private const string _AFTER_CONNECT = "AfterConnect";
        /*  2 */ 
        private const string _AFTER_GET = "AfterGet";
        /*  3 */ 
        private const string _BEFORE_GET = "BeforeGet";
        /*  4 */ 
        private const string _DELETE_MODE = "DeleteMode";
        /*  5 */ 
        private const string _ERROR_THRESHOLD = "ErrorThreshold";
        /*  6 */ 
        private const string _FILE_MASK = "FileMask";
        /*  7 */ 
        private const string _FIREWALL_AUTO_DETECT = "Firewall/AutoDetect";
        /*  8 */ 
        private const string _FIREWALL_FIREWALL_TYPE = "Firewall/FirewallType";
        /*  9 */ 
        private const string _FIREWALL_HOST = "Firewall/Host";
        /* 10 */ 
        private const string _FIREWALL_PASSWORD = "Firewall/Password";
        /* 11 */ 
        private const string _FIREWALL_PORT = "Firewall/Port";
        /* 12 */ 
        private const string _FIREWALL_USER = "Firewall/User";
        /* 13 */ 
        private const string _MAX_BATCH_SIZE = "MaxBatchSize";
        /* 14 */ 
        private const string _MAX_FILE_COUNT = "MaxFileCount";
        /* 15 */ 
        private const string _MAX_FILE_SIZE = "MaxFileSize";
        /* 16 */ 
        private const string _OTHER = "Other";
        /* 17 */ 
        private const string _PERSISTENT_CONNECTION = "PersistentConnection";
        /* 18 */ 
        private const string _POLLING_INTERVAL = "PollingInterval";
        /* 19 */ 
        private const string _REMOTE_PATH = "RemotePath";
        /* 20 */ 
        private const string _SSH_ACCEPT_SERVER_HOST_KEY_STORE = "SSHAcceptServerHostKey/Store";
        /* 21 */ 
        private const string _SSH_ACCEPT_SERVER_HOST_KEY_STORE_PASSWORD = "SSHAcceptServerHostKey/StorePassword";
        /* 22 */ 
        private const string _SSH_ACCEPT_SERVER_HOST_KEY_STORE_TYPE = "SSHAcceptServerHostKey/StoreType";
        /* 23 */ 
        private const string _SSH_ACCEPT_SERVER_HOST_KEY_SUBJECT = "SSHAcceptServerHostKey/Subject";
        /* 24 */ 
        private const string _SSH_ACCEPT_SERVER_HOST_KEY_ACCEPT_ANY = "SSHAcceptServerHostKey/AcceptAny";
        /* 25 */ 
        private const string _SSH_AUTH_MODE = "SSHAuthMode";
        /* 26 */ 
        private const string _SSH_CERT_STORE = "SSHCert/Store";
        /* 27 */ 
        private const string _SSH_CERT_STORE_PASSWORD = "SSHCert/StorePassword";
        /* 28 */ 
        private const string _SSH_CERT_STORE_TYPE = "SSHCert/StoreType";
        /* 29 */ 
        private const string _SSH_CERT_SUBJECT = "SSHCert/Subject";
        /* 30 */ 
        private const string _SSH_COMPRESSION_ALGORITHMS = "SSHCompressionAlgorithms";        
        /* 31 */ 
        private const string _SSH_HOST = "SSHHost";
        /* 32 */ 
        private const string _SSH_PASSWORD = "SSHPassword";
        /* 33 */ 
        private const string _SSH_PORT = "SSHPort";
        /* 34 */ 
        private const string _SSH_USER = "SSHUser";
        /* 35 */ 
        private const string _SSO_AFFILIATE = "SSOAffiliate";
        /* 36 */ 
        private const string _SUSPEND_ON_ERROR = "SuspendOnError";
        /* 37 */ 
        private const string _TEMP_FILE_NAME = "TempFileName";
        /* 38 */ 
        private const string _TEMP_PATH = "TempPath";
        /* 39 */ 
        private const string _TIMEOUT = "Timeout";
        /* 40 */ 
        private const string _TRANSPORT_LOG_LOCATION = "TransportLog/Location";
        /* 41 */ 
        private const string _TRANSPORT_LOG_LOG_MODE= "TransportLog/LogMode";
        /* 42 */ 
        private const string _TRANSPORT_LOG_LOG_TYPE = "TransportLog/LogType";
        /* 43 */ private const string _URI = "uri";
        #endregion

        #region Constructors
        public SftpReceiveAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.AfterConnect = this.AddProperty(_AFTER_CONNECT);
            /*  2 */
            this.AfterGet = this.AddProperty(_AFTER_GET);
            /*  3 */
            this.BeforeGet = this.AddProperty(_BEFORE_GET);
            /*  4 */
            this.DeleteMode = this.AddProperty(_DELETE_MODE);
            /*  5 */
            this.ErrorThreshold = this.AddProperty(_ERROR_THRESHOLD);
            /*  6 */
            this.FileMask = this.AddProperty(_FILE_MASK);
            /*  7 */
            this.Firewall_AutoDetect = this.AddProperty(_FIREWALL_AUTO_DETECT);
            /*  8 */
            this.Firewall_FirewallType = this.AddProperty(_FIREWALL_FIREWALL_TYPE);
            /*  9 */
            this.Firewall_Host = this.AddProperty(_FIREWALL_HOST);
            /* 10 */
            this.Firewall_Password = this.AddProperty(_FIREWALL_PASSWORD);
            /* 11 */
            this.Firewall_Port = this.AddProperty(_FIREWALL_PORT);
            /* 12 */
            this.Firewall_User = this.AddProperty(_FIREWALL_USER);
            /* 13 */
            this.MaxBatchSize = this.AddProperty(_MAX_BATCH_SIZE);
            /* 14 */
            this.MaxFileCount = this.AddProperty(_MAX_FILE_COUNT);
            /* 15 */
            this.MaxFileSize = this.AddProperty(_MAX_FILE_SIZE);
            /* 16 */
            this.Other = this.AddProperty(_OTHER);
            /* 17 */
            this.PersistentConnection = this.AddProperty(_PERSISTENT_CONNECTION);
            /* 18 */
            this.PollingInterval = this.AddProperty(_POLLING_INTERVAL);
            /* 19 */
            this.RemotePath = this.AddProperty(_REMOTE_PATH);
            /* 20 */
            this.SSHAcceptServerHostKey_Store = this.AddProperty(_SSH_ACCEPT_SERVER_HOST_KEY_STORE);
            /* 21 */
            this.SSHAcceptServerHostKey_StorePassword = this.AddProperty(_SSH_ACCEPT_SERVER_HOST_KEY_STORE_PASSWORD);
            /* 22 */
            this.SSHAcceptServerHostKey_StoreType = this.AddProperty(_SSH_ACCEPT_SERVER_HOST_KEY_STORE_TYPE);
            /* 23 */
            this.SSHAcceptServerHostKey_Subject = this.AddProperty(_SSH_ACCEPT_SERVER_HOST_KEY_SUBJECT);
            /* 24 */
            this.SSHAcceptServerHostKey_AcceptAny = this.AddProperty(_SSH_ACCEPT_SERVER_HOST_KEY_ACCEPT_ANY);
            /* 25 */
            this.SSHAuthMode = this.AddProperty(_SSH_AUTH_MODE);
            /* 26 */
            this.SSHCert_Store = this.AddProperty(_SSH_CERT_STORE);
            /* 27 */
            this.SSHCert_StorePassword = this.AddProperty(_SSH_CERT_STORE_PASSWORD);
            /* 28 */
            this.SSHCert_StoreType = this.AddProperty(_SSH_CERT_STORE_TYPE);
            /* 29 */
            this.SSHCert_Subject = this.AddProperty(_SSH_CERT_SUBJECT);
            /* 30 */
            this.SSHCompressionAlgorithms = this.AddProperty(_SSH_COMPRESSION_ALGORITHMS);
            /* 31 */
            this.SSHHost = this.AddProperty(_SSH_HOST);
            /* 32 */
            this.SSHPassword = this.AddProperty(_SSH_PASSWORD);
            /* 33 */
            this.SSHPort = this.AddProperty(_SSH_PORT);
            /* 34 */
            this.SSHUser = this.AddProperty(_SSH_USER);
            /* 35 */
            this.SSOAffiliate = this.AddProperty(_SSO_AFFILIATE);
            /* 36 */
            this.SuspendOnError = this.AddProperty(_SUSPEND_ON_ERROR);
            /* 37 */
            this.TempFileName = this.AddProperty(_TEMP_FILE_NAME);
            /* 38 */
            this.TempPath = this.AddProperty(_TEMP_PATH);
            /* 39 */
            this.Timeout = this.AddProperty(_TIMEOUT);
            /* 40 */
            this.TransportLog_Location = this.AddProperty(_TRANSPORT_LOG_LOCATION);
            /* 41 */
            this.TransportLog_LogMode = this.AddProperty(_TRANSPORT_LOG_LOG_MODE);
            /* 42 */
            this.TransportLog_LogType = this.AddProperty(_TRANSPORT_LOG_LOG_TYPE);
            /* 43 */
            this.Uri = this.AddProperty(_URI);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AfterConnect;
        /*  2 */
        public readonly AdapterProperty AfterGet;        
        /*  3 */
        public readonly AdapterProperty BeforeGet;        
        /*  4 */
        public readonly AdapterProperty DeleteMode;        
        /*  5 */
        public readonly AdapterProperty ErrorThreshold;
        /*  6 */
        public readonly AdapterProperty FileMask;
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
        public readonly AdapterProperty MaxBatchSize;
        /* 14 */
        public readonly AdapterProperty MaxFileCount;
        /* 15 */
        public readonly AdapterProperty MaxFileSize;
        /* 16 */
        public readonly AdapterProperty Other;
        /* 17 */
        public readonly AdapterProperty PersistentConnection;
        /* 18 */
        public readonly AdapterProperty PollingInterval;
        /* 19 */
        public readonly AdapterProperty RemotePath;
        /* 20 */
        public readonly AdapterProperty SSHAcceptServerHostKey_Store;

        /* 21 */
        public readonly AdapterProperty SSHAcceptServerHostKey_StorePassword;
        /* 22 */
        public readonly AdapterProperty SSHAcceptServerHostKey_StoreType;
        /* 23 */
        public readonly AdapterProperty SSHAcceptServerHostKey_Subject;
        /* 24 */
        public readonly AdapterProperty SSHAcceptServerHostKey_AcceptAny;
        /* 25 */
        public readonly AdapterProperty SSHAuthMode;
        /* 26 */
        public readonly AdapterProperty SSHCert_Store;
        /* 27 */
        public readonly AdapterProperty SSHCert_StorePassword;
        /* 28 */
        public readonly AdapterProperty SSHCert_StoreType;
        /* 29 */
        public readonly AdapterProperty SSHCert_Subject;
        /* 30 */
        public readonly AdapterProperty SSHCompressionAlgorithms;

        /* 31 */
        public readonly AdapterProperty SSHHost;
        /* 32 */
        public readonly AdapterProperty SSHPassword;
        /* 33 */
        public readonly AdapterProperty SSHPort;
        /* 34 */
        public readonly AdapterProperty SSHUser;
        /* 35 */
        public readonly AdapterProperty SSOAffiliate;
        /* 36 */
        public readonly AdapterProperty SuspendOnError;
        /* 37 */
        public readonly AdapterProperty TempFileName;
        /* 38 */
        public readonly AdapterProperty TempPath;
        /* 39 */
        public readonly AdapterProperty Timeout;
        /* 40 */
        public readonly AdapterProperty TransportLog_Location;        

        /* 41 */
        public readonly AdapterProperty TransportLog_LogMode;
        /* 42 */
        public readonly AdapterProperty TransportLog_LogType;
        /* 43 */
        public readonly AdapterProperty Uri;
        #endregion
    }
}
