using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class MqscSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _CHANNELNAME = "channelName";
        /*  2 */
        private const string _CONNECTIONNAME = "connectionName";
        /*  3 */
        private const string _HEARTBEAT = "heartBeat";
        /*  4 */
        private const string _QUEUE = "queue";
        /*  5 */
        private const string _QUEUEMANAGER = "queueManager";
        /*  6 */
        private const string _SEGMENTATIONALLOWED = "segmentationAllowed";
        /*  7 */
        private const string _TRANSACTIONSUPPORTED = "transactionSupported";
        /*  8 */
        private const string _TRANSPORTTYPE = "transportType";
        /*  9 */
        private const string _URI = "uri";
        #endregion

        #region Constructors
        public MqscSendAdapterConfig(string config)
            : base(config)
        {
            /*  1 */
            this.ChannelName = this.AddProperty(_CHANNELNAME);
            /*  2 */
            this.ConnectionName = this.AddProperty(_CONNECTIONNAME);
            /*  3 */
            this.HeartBeat = this.AddProperty(_HEARTBEAT);
            /*  4 */
            this.Queue = this.AddProperty(_QUEUE);
            /*  5 */
            this.QueueManager = this.AddProperty(_QUEUEMANAGER);
            /*  6 */
            this.SegmentationAllowed = this.AddProperty(_SEGMENTATIONALLOWED);
            /*  7 */
            this.TransactionSupported = this.AddProperty(_TRANSACTIONSUPPORTED);
            /*  8 */
            this.TransportType = this.AddProperty(_TRANSPORTTYPE);
            /*  9 */
            this.Uri = this.AddProperty(_URI);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty ChannelName;
        /*  2 */
        public readonly AdapterProperty ConnectionName;
        /*  3 */
        public readonly AdapterProperty HeartBeat;
        /*  4 */
        public readonly AdapterProperty Queue;
        /*  5 */
        public readonly AdapterProperty QueueManager;
        /*  6 */
        public readonly AdapterProperty SegmentationAllowed;
        /*  7 */
        public readonly AdapterProperty TransactionSupported;
        /*  8 */
        public readonly AdapterProperty TransportType;
        /*  9 */
        public readonly AdapterProperty Uri;
        #endregion
    }
}
