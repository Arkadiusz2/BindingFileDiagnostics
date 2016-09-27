using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class ModuleRefExtensions
    {
        public static ModuleRef Clone(this ModuleRef moduleRef)
        {
            return ModuleRef.Deserialize(moduleRef.Serialize());
        }
    }
}
