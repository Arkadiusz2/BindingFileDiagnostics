using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Adapters
{
    public class FileSendAdapterConfig : AdapterConfig
    {

        #region Constants
        /*  1 */
        private const string _ALLOWCACHEONWRITE = "AllowCacheOnWrite";
        /*  2 */
        private const string _COPYMODE = "CopyMode";
        /*  3 */
        private const string _FILENAME = "FileName";
        /*  4 */
        private const string _USETEMPFILEONWRITE = "UseTempFileOnWrite";
        #endregion

        #region Constructors
        public FileSendAdapterConfig(string config)
            : base(config, false)
        {
            /*  1 */
            this.AllowCacheOnWrite = this.AddProperty(_ALLOWCACHEONWRITE);
            /*  2 */
            this.CopyMode = this.AddProperty(_COPYMODE);
            /*  3 */
            this.FileName = this.AddProperty(_FILENAME);
            /*  4 */
            this.UseTempFileOnWrite = this.AddProperty(_USETEMPFILEONWRITE);
        }
        #endregion

        #region Public Properties
        /*  1 */
        public readonly AdapterProperty AllowCacheOnWrite;
        /*  2 */
        public readonly AdapterProperty CopyMode;
        /*  3 */
        public readonly AdapterProperty FileName;
        /*  4 */
        public readonly AdapterProperty UseTempFileOnWrite;
        #endregion
    }
}
