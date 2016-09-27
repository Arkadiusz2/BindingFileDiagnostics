using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{ 
    public class ReferencedPipeline : ReferencedItem
    {
        public ReferencedPipeline(ReferencedAssembly referencedAssembly, string fullyQualifiedName)
            : base(referencedAssembly, fullyQualifiedName)
        {
            this.ReceiveLocations = new List<ReceiveLocation>();
            this.SendPorts = new List<SendPort>();
        }

        public List<ReceiveLocation> ReceiveLocations { get; private set; }
        public List<SendPort> SendPorts { get; private set; }
    }
}
