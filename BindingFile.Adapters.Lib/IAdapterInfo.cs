using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Adapters
{
    public interface IAdapterInfo
    {
        string Name { get; }
        Guid ConfigurationClsid { get; }
    }
}
