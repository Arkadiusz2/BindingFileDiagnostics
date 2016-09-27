using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Diagnostics.Rules
{
    [Flags()]
    public enum RuleTargetsEnum : byte
    {
        /// <summary>
        /// Validate assembly information containing orchestrations
        /// </summary>
        ModuleRef = 1,
        /// <summary>
        /// Validate Orchestrations
        /// </summary>
        ServiceRef = 2,
        /// <summary>
        /// Validate Send Ports
        /// </summary>
        SendPort = 4,
        /// <summary>
        /// Validate Primary Transport and Secondary Transport of Send Ports
        /// </summary>
        TransportInfo = 8,
        /// <summary>
        /// Validate Send Port Group
        /// </summary>
        DistributionList = 16,
        /// <summary>
        /// Validate Receive Ports
        /// </summary>
        ReceivePort = 32,
        /// <summary>
        /// Validate Receive Locations
        /// </summary>
        ReceiveLocation = 64,
        All = 255
    }
}
