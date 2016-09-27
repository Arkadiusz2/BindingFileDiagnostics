using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Views
{
    public class Dependencies
    {
        public BindingInfo BindingInfo { get; private set; }
        private BidirectionalCollection<ReceivePort, ReferencedMap> _receivePortsToMaps = null;
        private BidirectionalCollection<SendPort, ReferencedMap> _sendPortsToMaps = null;

        public Dependencies(BindingInfo bindingInfo)
        {
            this.BindingInfo = bindingInfo;
        }

        internal BidirectionalCollection<ReceivePort, ReferencedMap> ReceivePortsToMaps
        {
            get
            {
                if (_receivePortsToMaps == null)
                {
                    foreach (ReceivePort receivePort in this.BindingInfo.ReceivePortCollection)
                    {
                        if (receivePort.Transforms != null && receivePort.Transforms.Any())
                        {
                            //_receivePortsToMaps.Add(receivePort, new ReferencedMap())
                        }
                    }
                }
                return _receivePortsToMaps;
            }
        }

    }
}
