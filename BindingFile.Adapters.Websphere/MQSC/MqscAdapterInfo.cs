using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    /// <summary>
    /// Transport type identification of MQSC BizTalk adapter (from WebSphere)
    /// </summary>
    public class MqscAdapterInfo : AdapterInfo
    {
        public MqscAdapterInfo()
            : base("MQSC", new Guid("cf8b4d15-5d2b-4c62-90db-16804d2454b9"))
        {
        }
    }
}
