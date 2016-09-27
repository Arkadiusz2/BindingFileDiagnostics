using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using BindingFile.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BfDiagUI
{
    public class ArtifactDependenciesViewController : BaseViewController<TreeView, BindingBaseObject>
    {
        private class DependencyNodeType
        {
            public bool Expanded { get; set; }
            public BindingBaseObject Artifact { get; private set; }

            public DependencyNodeType(BindingBaseObject artifact)
            {
                this.Expanded = false;
                this.Artifact = artifact;
            }
        }

        #region Private constants
        // Node names
        const string _FILE_NODE_NAME = "[File: {0}]";
        const string _APPLICATIONS_NODE_NAME = "Applications";
        const string _ASSEMBLIES_NODE_NAME = "Assemblies";
        const string _ORCHESTRATIONS_NODE_NAME = "Orchestrations";
        const string _SEND_PORT_GROUPS_NODE_NAME = "Send Port Groups";
        const string _SEND_PORTS_NODE_NAME = "Send Ports";
        const string _RECEIVE_PORT_NODE_NAME = "Receive Port";
        const string _RECEIVE_PORTS_NODE_NAME = "Receive Ports";
        const string _RECEIVE_LOCATIONS_NODE_NAME = "Receive Locations";
        const string _INBOUND_MAPS_NODE_NAME = "Inbound maps";
        const string _OUTBOUND_MAPS_NODE_NAME = "Outbound maps";
        // Node images
        const string _ASSEMBLIES_NODE_IMAGE_KEY = "Process wheels";
        const string _RECEIVE_PORT_NODE_IMAGE_KEY = "Goto previous";
        const string _RECEIVE_LOCATION_NODE_IMAGE_KEY = "Goto previous";
        const string _SEND_PORT_NODE_IMAGE_KEY = "Goto next";
        const string _SEND_PORT_GROUP_NODE_IMAGE_KEY = "Goto next";
        const string _SEND_PORT_GROUPS_NODE_IMAGE_KEY = "Goto next";
        const string _PROPERTY_NODE_IMAGE_KEY = "Schema";
        const string _ORCHESTRATION_NODE_IMAGE_KEY = "Orchestration";
        const string _MAP_NODE_IMAGE_KEY = "Map";

        #endregion

        public ArtifactDependenciesViewController(TreeView control)
            : base(control)
        {
            control.BeforeExpand += control_BeforeExpand;
            control.MouseDown += control_MouseDown;
        }

        private TreeViewHitTestInfo _hitTestInfo = null;

        void control_MouseDown(object sender, MouseEventArgs e)
        {
            _hitTestInfo = this.Control.HitTest(e.Location);
        }

        void control_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (sender is TreeView)
            {
                DependencyNodeType dependencyNode = e.Node.Tag as DependencyNodeType;
                if (dependencyNode != null)
                {
                    if (dependencyNode.Expanded == false)
                    {
                        TreeView treeView = (TreeView)sender;
                        TreeNode selectedNode = treeView.SelectedNode;

                        if (_hitTestInfo != null && _hitTestInfo.Node == e.Node)
                        {
                            dependencyNode.Expanded = true;

                            e.Node.Nodes.Clear();
                            BindDependencies(e.Node.Nodes, dependencyNode.Artifact);
                            e.Node.Nodes.ExpandToLevel(1);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        #region Refresh View functions

        public override void Bind()
        {
            this.Control.Nodes.Clear();
            if (this.DataSource != null)
            {
                Bind(this.Control.Nodes, this.DataSource);
            }
            this.Control.Nodes.ExpandToLevel(3);
        }

        private void Bind(TreeNodeCollection collection, BindingBaseObject artifact)
        {
            ServiceRef orchestration = artifact as ServiceRef;
            if (orchestration != null)
            {
                BindOrchestration(collection, orchestration);
            }
            else
            {
                DistributionList sendPortGroup = artifact as DistributionList;
                if (sendPortGroup != null)
                {
                    BindSendPortGroup(collection, sendPortGroup);
                }
                else
                {
                    SendPort sendPort = artifact as SendPort;
                    if (sendPort != null)
                    {
                        BindSendPort(collection, sendPort);
                    }
                    else
                    {
                        ReceivePort receivePort = artifact as ReceivePort;
                        if (receivePort != null)
                        {
                            BindReceivePort(collection, receivePort);
                        }
                        else
                        {
                            ReceiveLocation receiveLocation = artifact as ReceiveLocation;
                            if (receiveLocation != null)
                            {
                                BindReceiveLocation(collection, receiveLocation);
                            }
                        }
                    }
                }
            }
        }

        private void BindDependencies(TreeNodeCollection collection, BindingBaseObject artifact)
        {
            ServiceRef orchestration = artifact as ServiceRef;
            if (orchestration != null)
            {
                //AddOrchestrationDependencies(collection, orchestration);
            }
            else
            {
                DistributionList sendPortGroup = artifact as DistributionList;
                if (sendPortGroup != null)
                {
                    AddSendPortGroupDependencies(collection, sendPortGroup);
                }
                else
                {
                    SendPort sendPort = artifact as SendPort;
                    if (sendPort != null)
                    {
                        AddSendPortDependencies(collection, sendPort);
                    }
                    else
                    {
                        ReceivePort receivePort = artifact as ReceivePort;
                        if (receivePort != null)
                        {
                            AddReceivePortDependencies(collection, receivePort);
                        }
                        else
                        {
                            ReceiveLocation receiveLocation = artifact as ReceiveLocation;
                            if (receiveLocation != null)
                            {
                                AddReceiveLocationDependencies(collection, receiveLocation);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Bind Receive Port
        private void BindReceivePort(TreeNodeCollection collection, ReceivePort receivePort)
        {
            AddReceivePortNode(collection, receivePort.Name, receivePort);
        }

        private void AddReceivePortNode(TreeNodeCollection collection, string receivePortName, ReceivePort receivePort)
        {
            TreeNode receivePortNode = AddReceivePortName(collection, receivePortName);
            if (receivePort != null)
            {
                AddReceivePortContents(receivePortNode.Nodes, receivePort);
            }
        }

        private void AddReceivePortContents(TreeNodeCollection collection, ReceivePort receivePort)
        {
            if (receivePort.ReceiveLocations.Count > 0)
            {
                TreeNode usingNode = AddUsesNode(collection);

                TreeNode receiveLocationsNode = AddReceiveLocationsName(usingNode.Nodes);
                foreach (ReceiveLocation receiveLocation in receivePort.ReceiveLocations.OrderBy(x => x.Name))
                {
                    BindReceiveLocation(receiveLocationsNode.Nodes, receiveLocation);
                }

                if (receivePort.Transforms != null && receivePort.Transforms.Count > 0)
                {
                    TreeNode mapsNode = AddNode(usingNode.Nodes, _INBOUND_MAPS_NODE_NAME);

                    foreach (Transform transform in receivePort.Transforms)
                    {
                        BindMap(mapsNode.Nodes, transform);
                    }
                }

                if (receivePort.OutboundTransforms != null && receivePort.OutboundTransforms.Count > 0)
                {
                    TreeNode mapsNode = AddNode(usingNode.Nodes, _OUTBOUND_MAPS_NODE_NAME);

                    foreach (Transform transform in receivePort.OutboundTransforms)
                    {
                        BindMap(mapsNode.Nodes, transform);
                    }
                }
            }

            if (ReceivePortHasDependencies(receivePort))
            {
                TreeNode usedByNode = AddDependenciesNode(collection);
                usedByNode.Tag = new DependencyNodeType(receivePort);
            }
        }

        private bool ReceivePortHasDependencies(ReceivePort receivePort)
        {
            return receivePort.BoundOrchestrations().Any() || receivePort.FilteredBySendPortGroups().Any() || receivePort.FilteredBySendPorts().Any();
        }

        private void AddReceivePortDependencies(TreeNodeCollection collection, ReceivePort receivePort)
        {
            List<ServiceRef> orchestrations = receivePort.BoundOrchestrations().ToList();
            if (orchestrations.Count > 0)
            {
                TreeNode orchestrationsNode = AddOrchestrationsName(collection);
                foreach (ServiceRef orchestration in orchestrations.OrderBy(x => x.Name))
                {
                    AddOrchestrationNode(orchestrationsNode.Nodes, orchestration);
                }
            }

            List<DistributionList> sendPortGroups = receivePort.FilteredBySendPortGroups().ToList();
            if (sendPortGroups.Count > 0)
            {
                TreeNode sendPortGroupNode = AddNode(collection, "Send Port Groups (Filter expression)");
                foreach (DistributionList sendPortGroup in sendPortGroups.OrderBy(x => x.Name))
                {
                    AddSendPortGroupNode(sendPortGroupNode.Nodes, sendPortGroup.Name, sendPortGroup);
                }
            }

            List<SendPort> sendPorts = receivePort.FilteredBySendPorts().ToList();
            if (sendPorts.Count > 0)
            {
                TreeNode sendPortNode = AddNode(collection, "Send Ports (Filter expression)");
                foreach (SendPort sendPort in sendPorts.OrderBy(x => x.Name))
                {
                    AddSendPortNode(sendPortNode.Nodes, sendPort.Name, sendPort);
                }
            }
        }
        #endregion

        #region Bind Receive Location
        private void BindReceiveLocation(TreeNodeCollection collection, ReceiveLocation receiveLocation)
        {
            TreeNode receiveLocationNode = AddReceiveLocationNode(collection, receiveLocation);

            TreeNode usedByNode = AddDependenciesNode(receiveLocationNode.Nodes);
            usedByNode.Tag = new DependencyNodeType(receiveLocation);
        }

        private void AddReceiveLocationDependencies(TreeNodeCollection collection, ReceiveLocation receiveLocation)
        {
            TreeNode receivePortNode = AddReceivePortNodeName(collection);
            AddReceivePortNode(receivePortNode.Nodes, receiveLocation.ReceivePort.Name, receiveLocation.ReceivePort);
        }

        // Add receive location node including properties
        private TreeNode AddReceiveLocationNode(TreeNodeCollection collection, ReceiveLocation receiveLocation)
        {
            TreeNode receiveLocationNode = AddReceiveLocationName(collection, receiveLocation.Name);

            string address = receiveLocation.Address;
            if (address != null)
            {
                AddPropertyNode(receiveLocationNode.Nodes, address);
            }

            return receiveLocationNode;
        }
        #endregion

        #region Bind Send Port
        private void BindSendPort(TreeNodeCollection collection, SendPort sendPort)
        {
            AddSendPortNode(collection, sendPort.Name, sendPort);
        }

        private void AddSendPortNode(TreeNodeCollection collection, string sendPortName, SendPort sendPort)
        {
            TreeNode sendPortNode = AddSendPortName(collection, sendPortName);
            if (sendPort != null)
            {
                AddSendPortContents(sendPortNode.Nodes, sendPort);
            }

        }

        private void AddSendPortContents(TreeNodeCollection collection, SendPort sendPort)
        {
            // Add primary address
            string primaryAddress = null;
            if (sendPort.PrimaryTransport != null)
            {
                primaryAddress = sendPort.PrimaryTransport.Address;
            }

            if (primaryAddress != null)
            {
                AddPropertyNode(collection, primaryAddress);
            }

            // Add secondary address
            string secondaryAddress = null;
            if (sendPort.SecondaryTransport != null)
            {
                secondaryAddress = sendPort.SecondaryTransport.Address;
            }

            if (!string.IsNullOrEmpty(secondaryAddress))
            {
                AddPropertyNode(collection, secondaryAddress);
            }

            if (sendPort.Transforms != null && sendPort.Transforms.Count > 0)
            {
                TreeNode mapsNode = AddNode(collection, _OUTBOUND_MAPS_NODE_NAME);

                foreach (Transform transform in sendPort.Transforms)
                {
                    BindMap(mapsNode.Nodes, transform);
                }
            }

            if (sendPort.InboundTransforms != null && sendPort.InboundTransforms.Count > 0)
            {
                TreeNode mapsNode = AddNode(collection, _INBOUND_MAPS_NODE_NAME);

                foreach (Transform transform in sendPort.InboundTransforms)
                {
                    BindMap(mapsNode.Nodes, transform);
                }
            }

            //if (!string.IsNullOrEmpty(sendPort.Filter))
            //{
            //    TreeNode filterNode = AddPropertyNode(collection, "Filter");
            //    Filter filter;

            //    if (Filter.TryParse(sendPort.Filter, out filter))
            //    {
            //        int i = 1;
            //        foreach(FilterGroup filterGroup in filter.FilterGroups)
            //        {
            //            TreeNode groupNode = AddPropertyNode(filterNode.Nodes, "Group " + i++.ToString());

            //            foreach (FilterStatement filterStatement in filterGroup.FilterStatements)
            //            {
            //                AddPropertyNode(groupNode.Nodes, filterStatement.ToString());
            //            }
            //        }
            //    }                
            //}
                        
            List<string> sendPortNames = sendPort.FilteringOnSendPortNames().Distinct().OrderBy(x => x).ToList();
            List<string> receivePortNames = sendPort.FilteringOnReceivePortNames().Distinct().OrderBy(x => x).ToList();

            if (sendPortNames.Count > 0 || receivePortNames.Count > 0)
            {
                TreeNode usingNode = AddUsesNode(collection);
                
                // Display send ports
                if (sendPortNames.Count > 0)
                {
                    TreeNode sendPortsNode = AddNode(usingNode.Nodes, "Send Ports (Filter expression)");
                    foreach (string sendPortName in sendPortNames)
                    {
                        SendPort filteringOnSendPort = sendPort.Application.BindingInfo.GetSendPort(sendPortName);
                        AddSendPortNode(sendPortsNode.Nodes, sendPortName, filteringOnSendPort);
                    }
                }

                // Display receive ports            
                if (receivePortNames.Count > 0)
                {
                    TreeNode receivePortsNode = AddNode(usingNode.Nodes, "Receive Ports (Filter expression)");

                    foreach (string receivePortName in receivePortNames)
                    {
                        ReceivePort filteringOnReceivePort = sendPort.Application.BindingInfo.GetReceivePort(receivePortName);
                        AddReceivePortNode(receivePortsNode.Nodes, receivePortName, filteringOnReceivePort);
                    }
                }
            }

            if (SendPortHasDependencies(sendPort))
            {
                TreeNode usedByNode = AddDependenciesNode(collection);
                usedByNode.Tag = new DependencyNodeType(sendPort);
            }
        }

        private bool SendPortHasDependencies(SendPort sendPort)
        {
            return sendPort.BoundOrchestrations().Any() || sendPort.BoundSendPortGroups().Any() || sendPort.FilteredBySendPortGroups().Any() || sendPort.FilteredBySendPorts().Any();
        }

        private void AddSendPortDependencies(TreeNodeCollection collection, SendPort sendPort)
        {
            List<ServiceRef> orchestrations = sendPort.BoundOrchestrations().Distinct().OrderBy(x => x.Name).ToList();
            if (orchestrations.Count > 0)
            {
                TreeNode orchestrationsNode = AddOrchestrationsName(collection);
                foreach (ServiceRef orchestration in orchestrations)
                {
                    AddOrchestrationNode(orchestrationsNode.Nodes, orchestration);
                }
            }

            List<DistributionList> sendPortGroups = sendPort.BoundSendPortGroups().Distinct().OrderBy(x => x.Name).ToList();
            if (sendPortGroups.Count > 0)
            {
                TreeNode sendPortGroupNode = AddSendPortGroupsName(collection);
                foreach (DistributionList sendPortGroup in sendPortGroups)
                {
                    AddSendPortGroupNode(sendPortGroupNode.Nodes, sendPortGroup.Name, sendPortGroup);
                }
            }

            List<DistributionList> filteringSendPortGroups = sendPort.FilteredBySendPortGroups().Distinct().OrderBy(x => x.Name).ToList();
            if (filteringSendPortGroups.Count > 0)
            {
                TreeNode filteringSendPortGroupsNode = AddNode(collection, "Send Port Groups (Filter expression)");
                foreach (DistributionList filteringSendPortGroup in filteringSendPortGroups)
                {
                    AddSendPortGroupNode(filteringSendPortGroupsNode.Nodes, filteringSendPortGroup.Name, filteringSendPortGroup);
                }
            }

            List<SendPort> filteringSendPorts = sendPort.FilteredBySendPorts().Distinct().OrderBy(x => x.Name).ToList();
            if (filteringSendPorts.Count > 0)
            {
                TreeNode sendPortsNode = AddNode(collection, "Send Ports (Filter expression)");
                foreach (SendPort filteringSendPort in filteringSendPorts)
                {
                    AddSendPortNode(sendPortsNode.Nodes, filteringSendPort.Name, filteringSendPort);
                }
            }
        }
        #endregion

        #region Bind Send Port Group
        private void BindSendPortGroup(TreeNodeCollection collection, DistributionList sendPortGroup)
        {
            AddSendPortGroupNode(collection, sendPortGroup.Name, sendPortGroup);
        }

        private void AddSendPortGroupNode(TreeNodeCollection collection, string sendPortGroupName, DistributionList sendPortGroup)
        {
            TreeNode sendPortGroupNode = AddSendPortGroupName(collection, sendPortGroupName);
            if (sendPortGroup != null)
            {
                AddSendPortGroupContents(sendPortGroupNode.Nodes, sendPortGroup);
            }
        }

        private void AddSendPortGroupContents(TreeNodeCollection collection, DistributionList sendPortGroup)
        {
            TreeNode usingNode = AddUsesNode(collection);            
            TreeNode sendPortsNode = AddSendPortsName(usingNode.Nodes);

            if (sendPortGroup.SendPorts.Count > 0 || sendPortGroup.FilteringOnReceivePortNames().Any() || sendPortGroup.FilteringOnReceivePortNames().Any())
            {
                // Dispaly send ports
                foreach (SendPortRef sendPortInfo in sendPortGroup.SendPorts.Distinct().OrderBy(x => x.Name))
                {
                    AddSendPortNode(sendPortsNode.Nodes, sendPortInfo.Name, sendPortInfo.SendPort);
                }

                List<string> filteringOnSendPortNames = sendPortGroup.FilteringOnSendPortNames().Distinct().OrderBy(x => x).ToList();
                if (filteringOnSendPortNames.Count > 0)
                {
                    TreeNode filteringOnSendPortsNode = AddNode(usingNode.Nodes, "Send Ports (Filter expression)");

                    foreach (string sendPortName in filteringOnSendPortNames)
                    {
                        AddSendPortNode(filteringOnSendPortsNode.Nodes, sendPortName, sendPortGroup.Application.BindingInfo.GetSendPort(sendPortName));
                    }
                }

                // Display receive ports
                List<string> receivePortNames = sendPortGroup.FilteringOnReceivePortNames().Distinct().OrderBy(x => x).ToList();
                if (receivePortNames.Count > 0)
                {
                    TreeNode receivePortsNode = AddNode(usingNode.Nodes, "Receive Ports (Filter expression)");

                    foreach (string receivePortName in receivePortNames)
                    {
                        ReceivePort receivePort = sendPortGroup.Application.BindingInfo.GetReceivePort(receivePortName);
                        AddReceivePortNode(receivePortsNode.Nodes, receivePortName, receivePort);
                    }
                }
            }

            if (SendPortGroupHasDependencies(sendPortGroup))
            {
                TreeNode usedByNode = AddDependenciesNode(collection);
                usedByNode.Tag = new DependencyNodeType(sendPortGroup);
            }
        }

        private bool SendPortGroupHasDependencies(DistributionList sendPortGroup)
        {
            return sendPortGroup.BoundOrchestrations().Any();
        }

        private void AddSendPortGroupDependencies(TreeNodeCollection collection, DistributionList sendPortGroup)
        {
            List<ServiceRef> orchestrations = sendPortGroup.BoundOrchestrations().ToList();
            if (orchestrations.Count > 0)
            {
                TreeNode orchestrationsNode = AddOrchestrationsName(collection);
                foreach (ServiceRef orchestration in orchestrations.OrderBy(x => x.Name))
                {
                    AddOrchestrationNode(orchestrationsNode.Nodes, orchestration);
                }
            }
        }


        #endregion

        #region Bind Orchestration
        private void BindOrchestration(TreeNodeCollection collection, ServiceRef orchestration)
        {
            AddOrchestrationNode(collection, orchestration);
        }

        private void AddOrchestrationNode(TreeNodeCollection collection, ServiceRef orchestration)
        {
            TreeNode orchestrationNode = AddOrchestrationName(collection, orchestration.Name);

            List<ServicePortRef> boundReceivePorts = orchestration.Ports.Where(x => x.ReceivePortRef != null).OrderBy(x => x.Name).ToList();
            List<ServicePortRef> boundSendPortGroups = orchestration.Ports.Where(x => x.DistributionListRef != null).OrderBy(x => x.Name).ToList();
            List<ServicePortRef> boundSendPorts = orchestration.Ports.Where(x => x.SendPortRef != null).OrderBy(x => x.Name).ToList();

            if (boundReceivePorts.Count > 0 || boundSendPortGroups.Count > 0 || boundSendPorts.Count > 0)
            {
                TreeNode usingNode = AddUsesNode(orchestrationNode.Nodes);

                if (boundReceivePorts.Count > 0)
                {
                    TreeNode receivePortsNode = AddReceivePortsName(usingNode.Nodes);
                    
                    // Display receive ports
                    foreach (ServicePortRef boundReceivePort in boundReceivePorts)
                    {
                        string receivePortName = boundReceivePort.ReceivePortRef.Name;
                        ReceivePort receivePort = orchestration.Application.BindingInfo.GetReceivePort(receivePortName);

                        AddReceivePortNode(receivePortsNode.Nodes, receivePortName, receivePort);
                    }
                }

                // Display send port groups
                if (boundSendPortGroups.Count > 0)
                {
                    TreeNode sendPortGroupsNode = AddSendPortGroupsName(usingNode.Nodes);

                    foreach (ServicePortRef boundSendPortGroup in boundSendPortGroups)
                    {
                        string sendPortGroupName = boundSendPortGroup.DistributionListRef.Name;
                        DistributionList sendPortGroup = boundSendPortGroup.DistributionListRef.DistributionList;

                        AddSendPortGroupNode(sendPortGroupsNode.Nodes, sendPortGroupName, sendPortGroup);
                    }
                }

                // Display send ports
                if (boundSendPorts.Count > 0)
                {
                    TreeNode sendPortsNode = AddSendPortsName(usingNode.Nodes);

                    foreach (ServicePortRef boundSendPort in boundSendPorts)
                    {
                        string sendPortName = boundSendPort.SendPortRef.Name;
                        SendPort sendPort = orchestration.Application.BindingInfo.GetSendPort(sendPortName);

                        AddSendPortNode(sendPortsNode.Nodes, sendPortName, sendPort);
                    }
                }
            }
        }
        #endregion

        #region Bind Maps

        private void BindMap(TreeNodeCollection collection, Transform map)
        {
            AddNode(collection, map.FullName, _MAP_NODE_IMAGE_KEY);
        }



        #endregion

        private TreeNode AddPropertyNode(TreeNodeCollection collection, string propertyValue)
        {
            return AddNode(collection, propertyValue, _PROPERTY_NODE_IMAGE_KEY);
        }

        private TreeNode AddNode(TreeNodeCollection collection, string text)
        {
            return this.AddNode(collection, text, null);
        }

        private TreeNode AddNode(TreeNodeCollection collection, string text, string imageKey)
        {
            TreeNode node = collection.Add(text);
            if (imageKey != null)
            {
                node.ImageKey = imageKey;
                node.SelectedImageKey = imageKey;
            }

            return node;
        }

        private TreeNode AddOrchestrationsName(TreeNodeCollection collection)
        {
            return AddNode(collection, _ORCHESTRATIONS_NODE_NAME);
        }

        private TreeNode AddOrchestrationName(TreeNodeCollection collection, string name)
        {
            return AddNode(collection, name, _ORCHESTRATION_NODE_IMAGE_KEY);
        }

        private TreeNode AddReceivePortName(TreeNodeCollection collection, string name)
        {
            return AddNode(collection, name, _RECEIVE_PORT_NODE_IMAGE_KEY);
        }

        private TreeNode AddReceiveLocationName(TreeNodeCollection collection, string name)
        {
            return AddNode(collection, name, _RECEIVE_LOCATION_NODE_IMAGE_KEY);
        }

        private TreeNode AddSendPortGroupsName(TreeNodeCollection collection)
        {
            return AddNode(collection, _SEND_PORT_GROUPS_NODE_NAME);
        }

        private TreeNode AddSendPortGroupName(TreeNodeCollection collection, string name)
        {
            return AddNode(collection, name, _SEND_PORT_GROUP_NODE_IMAGE_KEY);
        }

        private TreeNode AddSendPortsName(TreeNodeCollection collection)
        {
            return AddNode(collection, _SEND_PORTS_NODE_NAME);
        }

        private TreeNode AddSendPortName(TreeNodeCollection collection, string name)
        {
            return AddNode(collection, name, _SEND_PORT_NODE_IMAGE_KEY);
        }

        private TreeNode AddReceivePortNodeName(TreeNodeCollection collection)
        {
            return AddNode(collection, _RECEIVE_PORT_NODE_NAME);
        }

        private TreeNode AddReceivePortsName(TreeNodeCollection collection)
        {
            return AddNode(collection, _RECEIVE_PORTS_NODE_NAME);
        }

        private TreeNode AddReceiveLocationsName(TreeNodeCollection collection)
        {
            return AddNode(collection, _RECEIVE_LOCATIONS_NODE_NAME);
        }

        private TreeNode AddUsesNode(TreeNodeCollection collection)
        {
            TreeNode node = AddNode(collection, "Uses");
            return node;
        }

        private TreeNode AddDependenciesNode(TreeNodeCollection collection)
        {
            TreeNode node = AddNode(collection, "Used by");
            node.Nodes.Add("");

            return node;
        }
    }
}
