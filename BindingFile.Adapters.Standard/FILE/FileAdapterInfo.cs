using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of FILE BizTalk adapter
    /// </summary>
    public class FileAdapterInfo : AdapterInfo
    {
        public FileAdapterInfo()
            : base("FILE", new Guid("5e49e3a6-b4fc-4077-b44c-22f34a242fdb"))
        {
        }
    }
}
