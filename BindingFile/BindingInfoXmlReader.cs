using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using BindingFile.Extensions;

namespace BindingFile
{
    public class BindingInfoXmlReader : MarkingXmlReader
    {
        public enum ArtifactType
        {
            Unassigned,
            ModuleRef,
            SendPort,
            SendPortGroup,
            ReceivePort,
            ReceiveLocation,
            Orchestrations,
            Orchestration
        }

        public struct ArtifactKeyStruct
        {
            public ArtifactType Type { get; set; }
            public string Name { get; set; }
        }

        public Dictionary<ArtifactKeyStruct, ElementInfo> ArtifactInfo = new Dictionary<ArtifactKeyStruct, ElementInfo>();

        private const string _MODULE_REF_PATH = "/BindingInfo/ModuleRefCollection/ModuleRef";
        private const string _SEND_PORT_PATH = "/BindingInfo/SendPortCollection/SendPort";
        private const string _SEND_PORT_GROUP_PATH = "/BindingInfo/DistributionListCollection/DistributionList";
        private const string _RECEIVE_PORT_PATH = "/BindingInfo/ReceivePortCollection/ReceivePort";
        private const string _RECEIVE_LOCATION_PATH = "/BindingInfo/ReceivePortCollection/ReceivePort/ReceiveLocations/ReceiveLocation";
        private const string _ORCHESTRATIONS_PATH = "/BindingInfo/ModuleRefCollection/ModuleRef/Services";
        private const string _ORCHESTRATION_PATH = "/BindingInfo/ModuleRefCollection/ModuleRef/Services/Service";

        public BindingInfoXmlReader(XmlReader xmlReader)
            : base(xmlReader)
        {
            this.ElementStack.ElementPushed += ElementStack_ElementPushed;
        }

        private ArtifactType GetArtifactType(string path)
        {
            ArtifactType type = ArtifactType.Unassigned;
            switch (this.ElementStack.Path)
            {
                case _MODULE_REF_PATH:
                    type = ArtifactType.ModuleRef;
                    break;

                case _SEND_PORT_PATH:
                    type = ArtifactType.SendPort;
                    break;

                case _SEND_PORT_GROUP_PATH:
                    type = ArtifactType.SendPortGroup;
                    break;

                case _RECEIVE_PORT_PATH:
                    type = ArtifactType.ReceivePort;
                    break;

                case _RECEIVE_LOCATION_PATH:
                    type = ArtifactType.ReceiveLocation;
                    break;

                case _ORCHESTRATIONS_PATH:
                    type = ArtifactType.Orchestrations;
                    break;

                case _ORCHESTRATION_PATH:
                    type = ArtifactType.Orchestration;
                    break;
            }
            return type;
        }

        void ElementStack_ElementPushed(object sender, EventArgs e)
        {
            if (this.UnderlyingXmlReader.NodeType == System.Xml.XmlNodeType.Element)
            {
                ArtifactType type = GetArtifactType(this.ElementStack.Path);
                if (type != ArtifactType.Unassigned)
                {
                    string name;
                    switch (type)
                    {
                        case ArtifactType.ModuleRef:
                            name = this.UnderlyingXmlReader["FullName"];
                            break;

                        default:
                            name = this.UnderlyingXmlReader["Name"];
                            break;
                    }                                        
                    ArtifactKeyStruct artifactKey = new ArtifactKeyStruct() { Name = name, Type = type };
                    if (!ArtifactInfo.ContainsKey(artifactKey))
                    {
                        ArtifactInfo.Add(artifactKey, this.ElementStack.Current);
                    }
                }
            }
        }
    }
}
