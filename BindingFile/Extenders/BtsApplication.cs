using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BindingFile
{
    public class BtsApplication
    {
        // Reference to parent
        [XmlIgnore()]
        public BindingInfo BindingInfo
        {
            get;
            set;
        }

        public BtsApplication(string name)
        {
            _sendPortCollection = new List<SendPort>();
            _receivePortCollection = new List<ReceivePort>();
            _distributionListCollection = new List<DistributionList>();
            _moduleRefCollection = new List<ModuleRef>();

            this.Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        #region Collections
        private List<SendPort> _sendPortCollection;
        private List<ReceivePort> _receivePortCollection;
        private List<DistributionList> _distributionListCollection;
        private List<ModuleRef> _moduleRefCollection;

        public List<DistributionList> DistributionListCollection
        {
            get
            {
                return _distributionListCollection;
            }
        }

        public List<SendPort> SendPortCollection
        {
            get
            {
                return _sendPortCollection;
            }
        }

        public List<ReceivePort> ReceivePortCollection
        {
            get
            {
                return _receivePortCollection;
            }
        }

        public List<ModuleRef> ModuleRefCollection
        {
            get
            {
                return _moduleRefCollection;
            }
        }

        public List<ServiceRef> ServiceCollection
        {
            get
            {
                //TODO implement service (orchestration) collection
                return null;
            }
        }

        public List<ReceiveLocation> ReceiveLocationCollection
        {
            get
            {
                var q = from rp in this.ReceivePortCollection 
                        from rl in rp.ReceiveLocations
                        select rl;

                return q.ToList<ReceiveLocation>();
            }
        }

        #endregion
    }
}
