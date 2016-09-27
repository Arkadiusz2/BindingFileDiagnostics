using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace BindingFile.Diagnostics.Rules
{
    public interface   IBindingRule
    {
        //#region Events
        // Event executed after rule is executed
        event EventHandler<BindingRuleValidationEventArgs> Validated;
        //#endregion

        #region Properties
        // Rule name
        string Name { get; }
        bool IsConfigurable { get; }
        Stream Configuration { get; set; }
        #endregion
        //void LoadConfiguration(string configuration);

        #region Methods
        bool Validate(BindingInfo bindingInfo);
        #endregion
    }
}
