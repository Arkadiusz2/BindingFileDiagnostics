using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class MqscReceiveAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _CHARACTERSET = "characterSet";
        /*  2 */
        private const string _CONNECTIONNAME = "connectionName";
        /*  3 */
        private const string _DATAOFFSETFORHEADERS = "dataOffsetForHeaders";
        /*  4 */
        private const string _ERRORTHRESHOLD = "errorThreshold";
        /*  5 */
        private const string _HEARTBEAT = "heartBeat";
        /*  6 */
        private const string _MAXIMUMBATCHSIZE = "maximumBatchSize";
        /*  7 */
        private const string _MAXIMUMMESSAGELENGTH = "maximumMessageLength";
        /*  8 */
        private const string _MAXIMUMNUMBEROFMESSAGES = "maximumNumberOfMessages";
        /*  9 */
        private const string _ORDERED = "ordered";
        /* 10 */
        private const string _POLLINGINTERVAL = "pollingInterval";
        /* 11 */
        private const string _QUEUE = "queue";
        /* 12 */
        private const string _QUEUEMANAGER = "queueManager";
        /* 13 */
        private const string _SEGMENTATION = "segmentation";
        /* 14 */
        private const string _STOPONERROR = "stopOnError";
        /* 15 */
        private const string _SUSPENDASNONRESUMABLE = "suspendAsNonResumable";
        /* 16 */
        private const string _THREADCOUNT = "threadCount";
        /* 17 */
        private const string _TRANSACTIONSUPPORTED = "transactionSupported";
        /* 18 */
        private const string _TRANSPORTTYPE = "transportType";
        /* 19 */
        private const string _URI = "uri";
        /* 20 */
        private const string _WAITINTERVAL = "waitInterval";
        #endregion

        #region Constructors
        public MqscReceiveAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.CharacterSet = this.AddProperty(_CHARACTERSET);
            /*  2 */
            this.ConnectionName = this.AddProperty(_CONNECTIONNAME);
            /*  3 */
            this.DataOffsetForHeaders = this.AddProperty(_DATAOFFSETFORHEADERS);
            /*  4 */
            this.ErrorThreshold = this.AddProperty(_ERRORTHRESHOLD);
            /*  5 */
            this.HeartBeat = this.AddProperty(_HEARTBEAT);
            /*  6 */
            this.MaximumBatchSize = this.AddProperty(_MAXIMUMBATCHSIZE);
            /*  7 */
            this.MaximumMessageLength = this.AddProperty(_MAXIMUMMESSAGELENGTH);
            /*  8 */
            this.MaximumNumberOfMessages = this.AddProperty(_MAXIMUMNUMBEROFMESSAGES);
            /*  9 */
            this.Ordered = this.AddProperty(_ORDERED);
            /* 10 */
            this.PollingInterval = this.AddProperty(_POLLINGINTERVAL);
            /* 11 */
            this.Queue = this.AddProperty(_QUEUE);
            /* 12 */
            this.QueueManager = this.AddProperty(_QUEUEMANAGER);
            /* 13 */
            this.Segmentation = this.AddProperty(_SEGMENTATION);
            /* 14 */
            this.StopOnError = this.AddProperty(_STOPONERROR);
            /* 15 */
            this.SuspendAsNonResumable = this.AddProperty(_SUSPENDASNONRESUMABLE);
            /* 16 */
            this.ThreadCount = this.AddProperty(_THREADCOUNT);
            /* 17 */
            this.TransactionSupported = this.AddProperty(_TRANSACTIONSUPPORTED);
            /* 18 */
            this.TransportType = this.AddProperty(_TRANSPORTTYPE);
            /* 19 */
            this.Uri = this.AddProperty(_URI);
            /* 20 */
            this.WaitInterval = this.AddProperty(_WAITINTERVAL);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty CharacterSet;
        /*  2 */
        public readonly AdapterProperty ConnectionName;
        /*  3 */
        public readonly AdapterProperty DataOffsetForHeaders;
        /*  4 */
        public readonly AdapterProperty ErrorThreshold;
        /*  5 */
        public readonly AdapterProperty HeartBeat;
        /*  6 */
        public readonly AdapterProperty MaximumBatchSize;
        /*  7 */
        public readonly AdapterProperty MaximumMessageLength;
        /*  8 */
        public readonly AdapterProperty MaximumNumberOfMessages;
        /*  9 */
        public readonly AdapterProperty Ordered;
        /* 10 */
        public readonly AdapterProperty PollingInterval;
        /* 11 */
        public readonly AdapterProperty Queue;
        /* 12 */
        public readonly AdapterProperty QueueManager;
        /* 13 */
        public readonly AdapterProperty Segmentation;
        /* 14 */
        public readonly AdapterProperty StopOnError;
        /* 15 */
        public readonly AdapterProperty SuspendAsNonResumable;
        /* 16 */
        public readonly AdapterProperty ThreadCount;
        /* 17 */
        public readonly AdapterProperty TransactionSupported;
        /* 18 */
        public readonly AdapterProperty TransportType;
        /* 19 */
        public readonly AdapterProperty Uri;
        /* 20 */
        public readonly AdapterProperty WaitInterval;
        #endregion
    }
}
