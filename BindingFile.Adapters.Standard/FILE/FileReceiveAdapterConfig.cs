using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class FileReceiveAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _BATCHSIZE = "BatchSize";
        /*  2 */
        private const string _BATCHSIZEINBYTES = "BatchSizeInBytes";
        /*  3 */
        private const string _FILEMASK = "FileMask";
        /*  4 */
        private const string _FILENETFAILRETRYCOUNT = "FileNetFailRetryCount";
        /*  5 */
        private const string _FILENETFAILRETRYINT = "FileNetFailRetryInt";
        /*  6 */
        private const string _POLLINGINTERVAL = "PollingInterval";
        /*  7 */
        private const string _REMOVERECEIVEDFILEDELAY = "RemoveReceivedFileDelay";
        /*  8 */
        private const string _REMOVERECEIVEDFILEMAXINTERVAL = "RemoveReceivedFileMaxInterval";
        /*  9 */
        private const string _REMOVERECEIVEDFILERETRYCOUNT = "RemoveReceivedFileRetryCount";
        /* 10 */
        private const string _RENAMERECEIVEDFILES = "RenameReceivedFiles";
        #endregion

        #region Constructors
        public FileReceiveAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.BatchSize = this.AddProperty(_BATCHSIZE);
            /*  2 */
            this.BatchSizeInBytes = this.AddProperty(_BATCHSIZEINBYTES);
            /*  3 */
            this.FileMask = this.AddProperty(_FILEMASK);
            /*  4 */
            this.FileNetFailRetryCount = this.AddProperty(_FILENETFAILRETRYCOUNT);
            /*  5 */
            this.FileNetFailRetryInt = this.AddProperty(_FILENETFAILRETRYINT);
            /*  6 */
            this.PollingInterval = this.AddProperty(_POLLINGINTERVAL);
            /*  7 */
            this.RemoveReceivedFileDelay = this.AddProperty(_REMOVERECEIVEDFILEDELAY);
            /*  8 */
            this.RemoveReceivedFileMaxInterval = this.AddProperty(_REMOVERECEIVEDFILEMAXINTERVAL);
            /*  9 */
            this.RemoveReceivedFileRetryCount = this.AddProperty(_REMOVERECEIVEDFILERETRYCOUNT);
            /* 10 */
            this.RenameReceivedFiles = this.AddProperty(_RENAMERECEIVEDFILES);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty BatchSize;
        /*  2 */
        public readonly AdapterProperty BatchSizeInBytes;
        /*  3 */
        public readonly AdapterProperty FileMask;
        /*  4 */
        public readonly AdapterProperty FileNetFailRetryCount;
        /*  5 */
        public readonly AdapterProperty FileNetFailRetryInt;
        /*  6 */
        public readonly AdapterProperty PollingInterval;
        /*  7 */
        public readonly AdapterProperty RemoveReceivedFileDelay;
        /*  8 */
        public readonly AdapterProperty RemoveReceivedFileMaxInterval;
        /*  9 */
        public readonly AdapterProperty RemoveReceivedFileRetryCount;
        /* 10 */
        public readonly AdapterProperty RenameReceivedFiles;
        #endregion
    }
}
