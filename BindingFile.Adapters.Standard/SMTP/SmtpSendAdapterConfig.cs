using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class SmtpSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _DELIVERYRECEIPT = "DeliveryReceipt";
        /*  2 */
        private const string _EMAILBODYFILECHARSET = "EmailBodyFileCharset";
        /*  3 */
        private const string _EMAILBODYTEXT = "EmailBodyText";
        /*  4 */
        private const string _EMAILBODYTEXTCHARSET = "EmailBodyTextCharset";
        /*  5 */
        private const string _FROM = "From";
        /*  6 */
        private const string _MESSAGEPARTSATTACHMENTS = "MessagePartsAttachments";
        /*  7 */
        private const string _READRECEIPT = "ReadReceipt";
        /*  8 */
        private const string _SMTPHOST = "SMTPHost";
        /*  9 */
        private const string _SUBJECT = "Subject";
        /* 10 */
        private const string _TO = "To";
        /* 11 */
        private const string _USERNAME = "Username";
        #endregion

        #region Constructors
        public SmtpSendAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.DeliveryReceipt = this.AddProperty(_DELIVERYRECEIPT);
            /*  2 */
            this.EmailBodyFileCharset = this.AddProperty(_EMAILBODYFILECHARSET);
            /*  3 */
            this.EmailBodyText = this.AddProperty(_EMAILBODYTEXT);
            /*  4 */
            this.EmailBodyTextCharset = this.AddProperty(_EMAILBODYTEXTCHARSET);
            /*  5 */
            this.From = this.AddProperty(_FROM);
            /*  6 */
            this.MessagePartsAttachments = this.AddProperty(_MESSAGEPARTSATTACHMENTS);
            /*  7 */
            this.ReadReceipt = this.AddProperty(_READRECEIPT);
            /*  8 */
            this.SMTPHost = this.AddProperty(_SMTPHOST);
            /*  9 */
            this.Subject = this.AddProperty(_SUBJECT);
            /* 10 */
            this.To = this.AddProperty(_TO);
            /* 11 */
            this.Username = this.AddProperty(_USERNAME);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty DeliveryReceipt;
        /*  2 */
        public readonly AdapterProperty EmailBodyFileCharset;
        /*  3 */
        public readonly AdapterProperty EmailBodyText;
        /*  4 */
        public readonly AdapterProperty EmailBodyTextCharset;
        /*  5 */
        public readonly AdapterProperty From;
        /*  6 */
        public readonly AdapterProperty MessagePartsAttachments;
        /*  7 */
        public readonly AdapterProperty ReadReceipt;
        /*  8 */
        public readonly AdapterProperty SMTPHost;
        /*  9 */
        public readonly AdapterProperty Subject;
        /* 10 */
        public readonly AdapterProperty To;
        /* 11 */
        public readonly AdapterProperty Username;
        #endregion
    }
}
