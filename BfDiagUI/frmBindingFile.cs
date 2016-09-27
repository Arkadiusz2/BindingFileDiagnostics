using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using BindingFile.Diagnostics.Rules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace BfDiagUI
{
    public partial class frmBindingFile : Form
    {
        #region Private fields
        BindingInfo _bindingInfo;
        bool _pendingRefresh = false;
        string _bindingFileName;

        FileStructureViewController FileStructureViewController { get; set; }
        FileContentViewController FileContentViewController { get; set; }
        RuleExecutionResultViewController RuleExecutionResultViewController { get; set; }       
        Dictionary<BindingBaseObject, ArtifactDependenciesViewController> ArtifactDependenciesViewControllers { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets or sets a full path of the Binding file
        /// </summary>
        public string BindingFileName
        {
            get
            {
                return _bindingFileName;
            }
            set
            {
                if (_bindingFileName == null || _bindingFileName != value)
                {
                    _bindingFileName = value;
                    BindingFileNameChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the binding info object that represents binding file
        /// </summary>
        private BindingInfo BindingInfo
        {
            get
            {
                return _bindingInfo;
            }
            set
            {
                if (value != null && _bindingInfo != value)
                {
                    _bindingInfo = value;
                    BindingInfoChanged();
                }
            }
        }

        private string BindingFileContent
        {
            get;
            set;
        }

        /// <summary>
        /// Method called when the name of the binding file is set
        /// </summary>
        private void BindingFileNameChanged()
        {
            // Order of assigning BindingFileContent and BindingInfo parameters is important!
            this.BindingFileContent = File.ReadAllText(this.BindingFileName);
            this.BindingInfo = BindingInfo.LoadFromFileAndInitialize(this.BindingFileName);
        }

        private void ValidationHandler(object sender, ValidationEventArgs e)
        {
        }

        /// <summary>
        /// Method called when BindingInfo object is assigned 
        /// </summary>
        private void BindingInfoChanged()
        {
            BindBindingInfo();
        }

        /// <summary>
        /// Method called when BindinfInfo structure is assigned and data on screen needs to be bound to data source that is the binding file
        /// </summary>
        private void BindBindingInfo()
        {
            // Update form header            
            this.Text = System.IO.Path.GetFileName(this.BindingFileName);

            this.FileStructureViewController.DataSource = this.BindingInfo;
            this.FileStructureViewController.Bind();
            this.FileStructureViewController.ArtifactSelected += FileStructureViewController_ArtifactSelected;

            this.FileContentViewController.DataSource = this.BindingFileContent;
            this.FileContentViewController.Bind();

            List<RuleInError> rulesInError;
            this.RuleExecutionResultViewController.ImageList = imageList1;
            this.RuleExecutionResultViewController.DataSource = ExecuteRules(this.BindingInfo, out rulesInError);
            this.RuleExecutionResultViewController.Bind();

            EnableFileWatcher();
            ReportRulesInError(rulesInError);
        }

        void FileStructureViewController_ArtifactSelected(object sender, ArtifactSelectedEventArgs e)
        {
            if (e.Artifact != null)
            {
                BindingBaseObject artifact = e.Artifact as BindingBaseObject;
                if (artifact != null)
                {
                    TreeView artifactDependenciesTreeView;
                    if (this.ArtifactDependenciesViewControllers.ContainsKey(artifact))
                    {
                        artifactDependenciesTreeView = this.ArtifactDependenciesViewControllers[artifact].Control;
                        
                    }
                    else
                    {
                        artifactDependenciesTreeView = CreateArtifactDependenciesTreeView();                                                                     
                        ArtifactDependenciesViewController artifactDependenciesViewController = new ArtifactDependenciesViewController(artifactDependenciesTreeView);                       
                        artifactDependenciesViewController.DataSource = artifact;
                        artifactDependenciesViewController.Bind();
                                                
                        this.ArtifactDependenciesViewControllers.Add(artifact, artifactDependenciesViewController);
                    }
                    ShowArtifactDependenciesTreeView(artifactDependenciesTreeView);
                }
            }
        }

        private TreeView CreateArtifactDependenciesTreeView()
        {
            TreeView treeView = new TreeView();
            treeView.ImageList = this.imageList1;
            treeView.ImageKey = "Folder open";
            treeView.SelectedImageKey = "Folder open";
            treeView.Dock = DockStyle.Fill;
            treeView.TabIndex = 0;
            treeView.HideSelection = false;

            return treeView;
        }

        private void ShowArtifactDependenciesTreeView(TreeView artifactDependenciesTreeView)
        {
            this.tabPage1.Controls.Clear();
            this.tabPage1.Controls.Add(artifactDependenciesTreeView);
        }

        private void SynchronizeBindingInfoViews()
        {
            // Order of assigning BindingFileContent and BindingInfo parameters is important!            
            this.BindingFileContent = this.richTextBoxBindingFileContent.Text;
            this._bindingInfo = BindingInfo.LoadFromFileContentAndInitialize(this.BindingFileName, this.BindingFileContent, (sender, e) =>
            {
                Exception ex = e.Exception;
            });

            if (this._bindingInfo != null)
            {
                this.FileStructureViewController.DataSource = this.BindingInfo;
                this.FileStructureViewController.Bind();

                List<RuleInError> rulesInError;
                this.RuleExecutionResultViewController.DataSource = ExecuteRules(this.BindingInfo, out rulesInError);
                this.RuleExecutionResultViewController.Bind();

                this.ArtifactDependenciesViewControllers.Clear();
                if (tabPage1.Controls.Count > 0)
                {
                    TreeView treeView = tabPage1.Controls[0] as TreeView;
                    if (treeView != null)
                    {
                        treeView.Nodes.Clear();
                    }
                }
            }
            else
            {
                this.FileStructureViewController.Control.Nodes.Clear();
                this.RuleExecutionResultViewController.Control.Rows.Clear();
                if (this.ArtifactDependenciesViewControllers.Count > 0)
                {
                    this.ArtifactDependenciesViewControllers.First().Value.Control.Nodes.Clear();
                    this.ArtifactDependenciesViewControllers.Clear();
                }
            }
        }

        private void RepaintXmlContent()
        {
            int lineNumber = richTextBoxBindingFileContent.GetFirstVisibleLineNumber();
            int selectinStart = richTextBoxBindingFileContent.SelectionStart;
            int selectionLength = richTextBoxBindingFileContent.SelectionLength;

            this.FileContentViewController.DataSource = richTextBoxBindingFileContent.Text;
            this.FileContentViewController.Bind();

            richTextBoxBindingFileContent.Scroll(lineNumber);
            richTextBoxBindingFileContent.SelectionStart = selectinStart;
            richTextBoxBindingFileContent.SelectionLength = selectionLength;
        }

        private void InitializeControls()
        {
            richTextBoxBindingFileContent.DoubleBuffered(true);

            // Initialize binding controls
            this.FileStructureViewController = new FileStructureViewController(treeView1);
            this.FileContentViewController = new FileContentViewController(richTextBoxBindingFileContent);
            this.RuleExecutionResultViewController = new RuleExecutionResultViewController(dataGridView1);            
            this.ArtifactDependenciesViewControllers = new Dictionary<BindingBaseObject, ArtifactDependenciesViewController>();
        }

        private struct RuleInError
        {
            public IBindingRule BindingRule;
            public Exception Exception;
        }

        private void EnableFileWatcher()
        {
            fileSystemWatcher1.Path = Path.GetDirectoryName(this.BindingFileName);
            fileSystemWatcher1.Filter = Path.GetFileName(this.BindingFileName);
            fileSystemWatcher1.EnableRaisingEvents = true;
        }       

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (e.ChangeType == WatcherChangeTypes.Changed && !_pendingRefresh)
                {
                    _pendingRefresh = true;

                    string message = string.Format("File '{0}' was changed in external editor. Would you like to refresh it?", _bindingFileName);
                    if (Display.AskQuestion(message, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BindingInfoChanged();
                    }

                    _pendingRefresh = false;
                }
            }
            catch (Exception ex)
            {
                Display.ShowException(ex);
            }
        }

        #endregion

        public frmBindingFile()
        {
            InitializeComponent();
            InitializeControls();
        }

        #region Form functions

        private void ReportRulesInError(List<RuleInError> rulesInError)
        {
            if (rulesInError.Count > 0)
            {
                StringBuilder info = new StringBuilder();
                info.AppendLine("Couldn't load the following rules:");
                int i = 1;
                foreach (var v in rulesInError)
                {
                    info.AppendFormat("({0}) '{1}', \r\nType: {2}, \r\nError: {3}\r\n", i++, v.BindingRule.Name, v.BindingRule.GetType().FullName, v.Exception.Message);
                    info.AppendLine();
                }
                info.AppendLine("Those rules were not executed.");

                Display.ShowMessage(info.ToString(), true);
            }
        }

        private List<RuleExecutionEventArgs> ExecuteRules(BindingInfo bindingInfo, out List<RuleInError> rulesInError)
        {
            List<RuleExecutionEventArgs> results = new List<RuleExecutionEventArgs>();                      

            RuleExecutionEngine ruleEngine = new RuleExecutionEngine();           
            ruleEngine.ItemValidated += (sender, e) =>
                {
                    if (!e.Success)
                    {
                        results.Add(e);
                    }
                };

            // Initialize 'Rules Configuration' file
            string environment = BindingInfoExtensions.BindingFileEnvironment(this.BindingFileName);
            //ConfigurationLoader configurationLoader = new ConfigurationLoader(Settings.Settings.RulesConfigurationPath, environment);
            rulesInError = new List<RuleInError>();

            // Load all rules            
            RulesController rulesController = new RulesController();
            foreach (ControlledRule controlledRule in rulesController.BindingRules)
            {
                IBindingRule bindingRule = controlledRule.BindingRule;
                try
                {
                    // Load configuration if rule is configurable
                    if (bindingRule.IsConfigurable)
                    {
                        //bindingRule.Configuration = configurationLoader.LoadConfiguration(bindingRule);
                    }
                    ruleEngine.Add(bindingRule);
                }
                catch (Exception ex)
                {
                    rulesInError.Add(new RuleInError() { BindingRule = bindingRule, Exception = ex });
                }
            }

            ruleEngine.Execute(bindingInfo);
            return results;
        }


        private void ruleLoader_RuleLoaded(object sender, RuleLoadedEventArgs e)
        {
        }
        #endregion

        #region Form methods
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseBindingFile();
            }
            catch (Exception ex)
            {
                Display.ShowException(ex);
            }
        }

        private void CloseBindingFile()
        {
            this.Close();
        }
        #endregion

 
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }

        private void richTextBoxBindingFileContent_SelectionChanged(object sender, EventArgs e)
        {
            string lineNumberLabel = string.Format("Line: {0,4}   Column: {1,4}", richTextBoxBindingFileContent.GetLineNumber(), richTextBoxBindingFileContent.GetColumnNumber());
            toolStripStatusLabel1.Text = lineNumberLabel;
        }

        private void openInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenInExternalEditor();
            }
            catch (Exception ex)
            {
                Display.ShowException(ex);
            }
        }

        private string ReplaceParameters(string externalEditorParameters, string fileName, int lineNumber, int columnNumber)
        {
            string parameters = externalEditorParameters;
                
            parameters = parameters.Replace("%LineNumber%", lineNumber.ToString());
            parameters = parameters.Replace("%ColumnNumber%", columnNumber.ToString());
            parameters = parameters.Replace("%FileName%", fileName);

            return parameters;
        }

        private void OpenInExternalEditor()
        {
            string externalEditorPath = Settings.Settings.ExternalEditorPath;
            string fileName = this.BindingFileName;
            int lineNumber = richTextBoxBindingFileContent.GetLineNumber();
            int columnNumber = richTextBoxBindingFileContent.GetColumnNumber();
            string arguments = ReplaceParameters(Settings.Settings.ExternalEditorParameters, fileName, lineNumber, columnNumber);

            ProcessStartInfo startInfo = new ProcessStartInfo(externalEditorPath);
            startInfo.Arguments = arguments;

            var process = new System.Diagnostics.Process();
            process.StartInfo = startInfo;
            process.Start();
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            OpenInExternalEditor();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string s = (string)dataGridView1.Rows[e.RowIndex].Cells["LineNumber"].Value;

                int lineNumber;
                if (int.TryParse(s, out lineNumber))
                {
                    richTextBoxBindingFileContent.Scroll(lineNumber);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool succeeded = false;
            try
            {
                fileSystemWatcher1.EnableRaisingEvents = false;
                File.WriteAllText(_bindingFileName, richTextBoxBindingFileContent.Text);
                succeeded = true;

            }
            catch (Exception ex)
            {
                Display.ShowException(ex);
            }
            finally
            {
                fileSystemWatcher1.EnableRaisingEvents = true;
            }

            if (succeeded)
            {
                Display.ShowMessage(string.Format("File '{0}' was saved", _bindingFileName));
            }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string message = string.Format("Would you like to refresh the content of the file from disk? Any unsaved changes will be lost.", _bindingFileName);
                if (Display.AskQuestion(message, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    BindingFileNameChanged();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Display.ShowException(ex);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                int lineNumber = (int)e.Node.Tag;
                richTextBoxBindingFileContent.Scroll(lineNumber);                
            }
        }

        private void frmBindingFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
        }

        private void frmBindingFile_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SynchronizeBindingInfoViews();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            bool bHandled = false;
            // switch case is the easy way, a hash or map would be better, 
            // but more work to get set up.
            switch (keyData)
            {
                case Keys.F5:

                    SynchronizeBindingInfoViews();

                    bHandled = true;
                    break;
            }
            return bHandled;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RepaintXmlContent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
