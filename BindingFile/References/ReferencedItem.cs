using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ReferencedItem
    {
        public string FullyQualifiedName { get; internal set; }
        public ReferencedAssembly ReferencedAssembly { get; internal set; }             
        
        public ReferencedItem(ReferencedAssembly referencedAssembly, string fullyQualifiedName)
        {
            this.ReferencedAssembly = referencedAssembly;
            this.FullyQualifiedName = fullyQualifiedName;
        }        
    }
}
