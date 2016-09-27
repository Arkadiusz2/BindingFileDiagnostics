using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BfDiagUI
{
    public class ArtifactSelectedEventArgs : EventArgs
    {
        public object Artifact { get; private set; }

        public ArtifactSelectedEventArgs(object artifact)
        {
            this.Artifact = artifact;
        }
    }
}
