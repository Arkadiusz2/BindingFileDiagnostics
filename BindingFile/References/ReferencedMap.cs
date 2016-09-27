using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ReferencedMap : ReferencedItem
    {
        public ReferencedMap(ReferencedAssembly referencedAssembly, string fullyQualifiedName)
            : base(referencedAssembly, fullyQualifiedName)
        {
            this.ReceivePorts = new List<ReceivePort>();
            this.SendPorts = new List<SendPort>();
        }

        public List<ReceivePort> ReceivePorts { get; private set; }
        public List<SendPort> SendPorts { get; private set; }

        private string _fullName = null;
        
        public string FullName
        {
            get
            {
                if (_fullName == null)
                {
                    ClassQualifiedName qn = new ClassQualifiedName(this.FullyQualifiedName);
                    _fullName = qn.FullName;
                }
                return _fullName;
            }
        }
    }
}
