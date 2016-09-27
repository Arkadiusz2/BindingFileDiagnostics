using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ReferencedAssembly
    {
        #region Public Properties
        /// <summary>
        /// Fully qualified name of the assembly
        /// </summary>
        public string FullyQualifiedName { get; private set; }
        
        /// <summary>
        /// Pipelines referenced by the assembly
        /// </summary>
        public ReferencedPipelineCollection PipelineCollection { get; private set; }

        /// <summary>
        /// Maps referenced by the assembly
        /// </summary>
        public ReferencedMapCollection MapCollection { get; private set; }
        #endregion

        #region Public constructors
        public ReferencedAssembly(string fullyQualifiedName)
        {
            this.FullyQualifiedName = fullyQualifiedName;
            this.MapCollection = new ReferencedMapCollection();
            this.PipelineCollection = new ReferencedPipelineCollection();
        }
        #endregion
    }
}
