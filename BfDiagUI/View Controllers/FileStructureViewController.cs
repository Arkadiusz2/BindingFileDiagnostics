using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BfDiagUI
{
    public class FileStructureViewController : BaseViewController<TreeView, BindingInfo>
    {
        #region Private constants
        
        /// <summary>
        /// Tree node names
        /// </summary>
        const string _FILE_NODE_NAME = "[File: {0}]";
        const string _APPLICATIONS_NODE_NAME = "Applications";
        const string _ASSEMBLIES_NODE_NAME = "Assemblies";
        const string _ORCHESTRATIONS_NODE_NAME = "Orchestrations";
        const string _SENDPORTGROUPS_NODE_NAME = "Send Port Groups";
        const string _SENDPORTS_NODE_NAME = "Send Ports";
        const string _RECEIVEPORTS_NODE_NAME = "Receive Ports";
        const string _RECEIVELOCATIONS_NODE_NAME = "Receive Locations";
        const string _PIPELINES_NODE_NAME = "Pipelines";
        
        /// <summary>
        /// Tree node images
        /// </summary>
        const string _ASSEMBLIES_NODE_IMAGE_KEY = "Process wheels";
        const string _ARTIFACT_IMAGE_KEY = "Artifact";
        const string _FOLDER_OPEN_IMAGE_KEY = "Folder open";
        const string _ORCHESTRATION_IMAGE_KEY = "Orchestration";
        const string _SEND_GROUP_NODE_IMAGE_KEY = "Goto source code";
        const string _SEND_NODE_IMAGE_KEY = "Goto next";
        const string _RECEIVE_NODE_IMAGE_KEY = "Goto previous";
        #endregion

        private Dictionary<TreeNode, object> _treeToArtifactDictionary = new Dictionary<TreeNode, object>();

        /// <summary>
        /// Event fired when an artifact in the tree is selected
        /// </summary>
        public event EventHandler<ArtifactSelectedEventArgs> ArtifactSelected;

        public FileStructureViewController(TreeView control)
            : base(control)
        {
            control.AfterSelect += control_AfterSelect;
        }

        void control_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_treeToArtifactDictionary.ContainsKey(e.Node))
            {
                object _artifact = _treeToArtifactDictionary[e.Node];
                if (_artifact != null)
                {
                    OnArtifactSeleced(_artifact);
                }
            }
        }

        private void OnArtifactSeleced(object artifact)
        {
            if (this.ArtifactSelected != null)
            {
                this.ArtifactSelected(this, new ArtifactSelectedEventArgs(artifact));
            }
        }

        #region Refresh View functions

        /// <summary>
        /// Reference to the binding file information
        /// </summary>
        private BindingInfo BindingInfo
        {
            get
            {
                return this.DataSource;
            }
        }

        #region Some old code from the Bind method:
        //TreeNode referencedAssembliesNode = fileNode.Nodes.Add("Referenced Assemblies");
        //referencedAssembliesNode.ImageKey = _ASSEMBLIES_NODE_IMAGE_KEY;
        //referencedAssembliesNode.SelectedImageKey = _ASSEMBLIES_NODE_IMAGE_KEY;

        //foreach (ReferencedAssembly referencedAssembly in this.BindingInfo.ReferencedAssemblyCollection.Items.OrderBy(x => x.FullyQualifiedName))
        //{
        //    TreeNode referencedAssemblyNode = referencedAssembliesNode.Nodes.Add(referencedAssembly.FullyQualifiedName);
        //    referencedAssemblyNode.ImageKey = _ASSEMBLIES_NODE_IMAGE_KEY;
        //    referencedAssemblyNode.SelectedImageKey = _ASSEMBLIES_NODE_IMAGE_KEY;

        //    if (referencedAssembly.MapCollection.Items.Any())
        //    {
        //        TreeNode mapCollectionNode = referencedAssemblyNode.Nodes.Add("Maps");

        //        foreach (ReferencedMap referencedMap in referencedAssembly.MapCollection.Items.OrderBy(x => x.FullyQualifiedName))
        //        {
        //            TreeNode referencedMapNode = mapCollectionNode.Nodes.Add(referencedMap.FullName);
        //            referencedMapNode.ImageKey = "Map";
        //            referencedMapNode.SelectedImageKey = "Map";
        //        }
        //    }
        //}
        #endregion

        /// <summary>
        /// Gets list of applications in a binding file
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BtsApplication> GetApplications(BindingInfo bindingInfo)
        {
            // Always order applications by name
            return bindingInfo.ApplicationCollection.OrderBy(x => x.Name);
        }

        bool _orderArtifacts = true;

        private IEnumerable<ModuleRef> GetOrchestrations(BtsApplication application)
        {
            if (_orderArtifacts)
            {
                return application.ModuleRefCollection.Where(x => x.IsAssemblyDefinition).OrderBy(x => x.Name);
            }
            else
            {
                return application.ModuleRefCollection.Where(x => x.IsAssemblyDefinition);
            }
        }
        
        /// <summary>
        /// Displays treeview contents
        /// </summary>
        public override void Bind()
        {
            if (this.BindingInfo == null)
            {
                throw new ArgumentNullException("bindingInfo");
            }

            this.Control.Nodes.Clear();

            string fileName = Path.GetFileName(this.DataSource.FileName);

            // Create file node
            TreeNode fileNode = this.Control.Nodes.AddWithImage(string.Format(_FILE_NODE_NAME, this.DataSource.FileName), _ARTIFACT_IMAGE_KEY);

            // Create applicattions node
            TreeNode applicationsNode = fileNode.Nodes.AddWithImage(_APPLICATIONS_NODE_NAME, _ARTIFACT_IMAGE_KEY);

            // Iterate over all applications
            foreach (var application in this.GetApplications(this.BindingInfo))
            {
                TreeNode applicationNode = applicationsNode.Nodes.AddWithImage(application.Name, _ARTIFACT_IMAGE_KEY);
                _treeToArtifactDictionary.Add(applicationNode, application);

                IEnumerable<ModuleRef> orchestrations = this.GetOrchestrations(application);

                // Check if there are assemblies to display
                if (orchestrations.Any())
                {
                    // Create assemblies node
                    TreeNode assembliesNode = applicationNode.Nodes.AddWithImage(_ASSEMBLIES_NODE_NAME, _ASSEMBLIES_NODE_IMAGE_KEY);
                    _treeToArtifactDictionary.Add(assembliesNode, application.ModuleRefCollection);

                    // Iterate over all assemblies within an applicaiton
                    foreach (ModuleRef moduleRef in orchestrations)
                    {
                        // Create assembly node
                        TreeNode moduleRefNode = assembliesNode.Nodes.AddWithImage(moduleRef.FullName, _ASSEMBLIES_NODE_IMAGE_KEY);
                        _treeToArtifactDictionary.Add(moduleRefNode, moduleRef);

                        if (moduleRef.ElementInfo != null && moduleRef.ElementInfo.HasLineInfo)
                        {
                            moduleRefNode.Tag = moduleRef.ElementInfo.LineNumber;
                        }

                        // Check if there are orchestrations in an assembly
                        if (moduleRef.Services.Count > 0)
                        {
                            // Create orchestrations node
                            TreeNode orchestrationsNode = moduleRefNode.Nodes.AddWithImage(_ORCHESTRATIONS_NODE_NAME, _FOLDER_OPEN_IMAGE_KEY);

                            // Get list of orchestrations
                            var q1 = from s in moduleRef.Services
                                     orderby s.Name ascending
                                     select s;

                            // Iterate over all orchestrations
                            foreach (var orchestration in q1)
                            {
                                // Create orchestration node
                                TreeNode serviceNode = orchestrationsNode.Nodes.AddWithImage(orchestration.Name, _ORCHESTRATION_IMAGE_KEY);
                                _treeToArtifactDictionary.Add(serviceNode, orchestration);

                                if (orchestration.ElementInfo != null && orchestration.ElementInfo.HasLineInfo)
                                {
                                    serviceNode.Tag = orchestration.ElementInfo.LineNumber;
                                }
                            }
                        }
                    }
                }

                // Check if there are send port groups
                if (application.DistributionListCollection.Count > 0)
                {
                    // Create send port groups node
                    TreeNode sendPortGroupsNode = applicationNode.Nodes.Add(_SENDPORTGROUPS_NODE_NAME);

                    // Iterate over all send port groups within an applicaion
                    foreach (var sendPortGroup in application.DistributionListCollection.OrderBy(x => x.Name))
                    {
                        // Create send port group node
                        TreeNode sendPortGroupNode = sendPortGroupsNode.Nodes.AddWithImage(sendPortGroup.Name, _SEND_NODE_IMAGE_KEY);
                        _treeToArtifactDictionary.Add(sendPortGroupNode, sendPortGroup);

                        if (sendPortGroup.ElementInfo != null && sendPortGroup.ElementInfo.HasLineInfo)
                        {
                            sendPortGroupNode.Tag = sendPortGroup.ElementInfo.LineNumber;                            
                        }
                    }
                }

                // Check if there are send ports
                if (application.SendPortCollection.Count > 0)
                {
                    // Create send ports node
                    TreeNode sendPortsNode = applicationNode.Nodes.Add(_SENDPORTS_NODE_NAME);

                    // Iterate over all send ports in within an application
                    foreach (var sendPort in application.SendPortCollection.OrderBy(x => x.Name))
                    {
                        // Create send port group node
                        TreeNode sendPortNode = sendPortsNode.Nodes.AddWithImage(sendPort.Name, _SEND_NODE_IMAGE_KEY);
                        _treeToArtifactDictionary.Add(sendPortNode, sendPort);

                        if (sendPort.ElementInfo != null && sendPort.ElementInfo.HasLineInfo)
                        {
                            sendPortNode.Tag = sendPort.ElementInfo.LineNumber;                            
                        }
                    }
                }

                // Check if there are receive ports
                if (application.ReceivePortCollection.Count > 0)
                {
                    // Create receive ports node
                    TreeNode receivePortsNode = applicationNode.Nodes.Add(_RECEIVEPORTS_NODE_NAME);

                    // Iterate over all receive ports within an application
                    foreach (var receivePort in application.ReceivePortCollection.OrderBy(x => x.Name))
                    {
                        // Create receive port node
                        TreeNode receivePortNode = receivePortsNode.Nodes.AddWithImage(receivePort.Name, _RECEIVE_NODE_IMAGE_KEY);
                        _treeToArtifactDictionary.Add(receivePortNode, receivePort);

                        if (receivePort.ElementInfo != null && receivePort.ElementInfo.HasLineInfo)
                        {
                            receivePortNode.Tag = receivePort.ElementInfo.LineNumber;                            
                        }
                    }
                }

                // Check if there are receive locations
                if (application.ReceiveLocationCollection.Count > 0)
                {
                    // Create receive locations node
                    TreeNode receiveLocationsNode = applicationNode.Nodes.Add(_RECEIVELOCATIONS_NODE_NAME);

                    // Iterate over receive locations within an application
                    foreach (var receiveLocation in application.ReceiveLocationCollection.OrderBy(x => x.Name))
                    {
                        // Create receive location node
                        TreeNode receiveLocationNode = receiveLocationsNode.Nodes.AddWithImage(receiveLocation.Name, _RECEIVE_NODE_IMAGE_KEY);
                        _treeToArtifactDictionary.Add(receiveLocationNode, receiveLocation);

                        if (receiveLocation.ElementInfo != null && receiveLocation.ElementInfo.HasLineInfo)
                        {
                            receiveLocationNode.Tag = receiveLocation.ElementInfo.LineNumber;
                        }
                    }
                }

            }
            this.Control.ExpandAll();
        }

        #endregion
    }
    
}
