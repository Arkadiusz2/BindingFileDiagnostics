using BindingFile.Diagnostics.Rules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Diagnostics.Engine
{
    public interface IConfigurationLoader
    {
        Stream LoadConfiguration(IBindingRule bindingRule);
    }
}
