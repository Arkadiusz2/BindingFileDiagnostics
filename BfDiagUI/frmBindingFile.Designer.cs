namespace BfDiagUI
{
    partial class frmBindingFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBindingFile));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.richTextBoxBindingFileContent = new System.Windows.Forms.RichTextBox();
            this.bindingFileContentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingFileStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.tabPageBindingFileErrorList = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtefactType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtefactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.bindingFileContentContextMenuStrip.SuspendLayout();
            this.bindingFileStatusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPageBindingFileErrorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.bindingFileStatusStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1133, 731);
            this.splitContainer1.SplitterDistance = 485;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxBindingFileContent);
            this.splitContainer2.Size = new System.Drawing.Size(1133, 463);
            this.splitContainer2.SplitterDistance = 376;
            this.splitContainer2.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageKey = "Folder open";
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageKey = "Folder open";
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(376, 463);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Artifact");
            this.imageList1.Images.SetKeyName(1, "Folder open");
            this.imageList1.Images.SetKeyName(2, "Folder closed");
            this.imageList1.Images.SetKeyName(3, "Process wheels");
            this.imageList1.Images.SetKeyName(4, "Orchestration");
            this.imageList1.Images.SetKeyName(5, "Map");
            this.imageList1.Images.SetKeyName(6, "Business rule");
            this.imageList1.Images.SetKeyName(7, "Pipeline");
            this.imageList1.Images.SetKeyName(8, "Schema");
            this.imageList1.Images.SetKeyName(9, "Host");
            this.imageList1.Images.SetKeyName(10, "Group");
            this.imageList1.Images.SetKeyName(11, "Network map");
            this.imageList1.Images.SetKeyName(12, "Swimming pool");
            this.imageList1.Images.SetKeyName(13, "Network_Internet.ico");
            this.imageList1.Images.SetKeyName(14, "Green plus");
            this.imageList1.Images.SetKeyName(15, "Application started");
            this.imageList1.Images.SetKeyName(16, "Application partially started");
            this.imageList1.Images.SetKeyName(17, "Application stopped");
            this.imageList1.Images.SetKeyName(18, "sitesuntitled.png");
            this.imageList1.Images.SetKeyName(19, "Busy");
            this.imageList1.Images.SetKeyName(20, "BTDB.png");
            this.imageList1.Images.SetKeyName(21, "IISserver_earth.png");
            this.imageList1.Images.SetKeyName(22, "Goto next");
            this.imageList1.Images.SetKeyName(23, "Goto source code");
            this.imageList1.Images.SetKeyName(24, "Goto previous");
            this.imageList1.Images.SetKeyName(25, "Error");
            this.imageList1.Images.SetKeyName(26, "Information");
            this.imageList1.Images.SetKeyName(27, "Warning");
            // 
            // richTextBoxBindingFileContent
            // 
            this.richTextBoxBindingFileContent.ContextMenuStrip = this.bindingFileContentContextMenuStrip;
            this.richTextBoxBindingFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxBindingFileContent.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxBindingFileContent.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxBindingFileContent.Name = "richTextBoxBindingFileContent";
            this.richTextBoxBindingFileContent.Size = new System.Drawing.Size(753, 463);
            this.richTextBoxBindingFileContent.TabIndex = 3;
            this.richTextBoxBindingFileContent.Text = "";
            this.richTextBoxBindingFileContent.WordWrap = false;
            this.richTextBoxBindingFileContent.SelectionChanged += new System.EventHandler(this.richTextBoxBindingFileContent_SelectionChanged);
            // 
            // bindingFileContentContextMenuStrip
            // 
            this.bindingFileContentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.openInNotepadToolStripMenuItem});
            this.bindingFileContentContextMenuStrip.Name = "contextMenuStrip1";
            this.bindingFileContentContextMenuStrip.Size = new System.Drawing.Size(186, 132);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem3.Text = "&Refresh views";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem4.Text = "Re&paint XML content";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.refreshToolStripMenuItem.Text = "Re&load binding file";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // openInNotepadToolStripMenuItem
            // 
            this.openInNotepadToolStripMenuItem.Name = "openInNotepadToolStripMenuItem";
            this.openInNotepadToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openInNotepadToolStripMenuItem.Text = "Open in Notepad++";
            this.openInNotepadToolStripMenuItem.Click += new System.EventHandler(this.openInNotepadToolStripMenuItem_Click);
            // 
            // bindingFileStatusStrip
            // 
            this.bindingFileStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripSplitButton1});
            this.bindingFileStatusStrip.Location = new System.Drawing.Point(0, 463);
            this.bindingFileStatusStrip.Name = "bindingFileStatusStrip";
            this.bindingFileStatusStrip.Size = new System.Drawing.Size(1133, 22);
            this.bindingFileStatusStrip.TabIndex = 2;
            this.bindingFileStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.IsLink = true;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(127, 17);
            this.toolStripSplitButton1.Text = "&Open in external editor";
            this.toolStripSplitButton1.Click += new System.EventHandler(this.toolStripSplitButton1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPageBindingFileErrorList);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1133, 242);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1125, 216);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Dependencies";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.ImageKey = "Folder open";
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            this.treeView2.SelectedImageKey = "Folder open";
            this.treeView2.Size = new System.Drawing.Size(1119, 210);
            this.treeView2.TabIndex = 0;
            // 
            // tabPageBindingFileErrorList
            // 
            this.tabPageBindingFileErrorList.Controls.Add(this.dataGridView1);
            this.tabPageBindingFileErrorList.Location = new System.Drawing.Point(4, 22);
            this.tabPageBindingFileErrorList.Name = "tabPageBindingFileErrorList";
            this.tabPageBindingFileErrorList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBindingFileErrorList.Size = new System.Drawing.Size(1125, 216);
            this.tabPageBindingFileErrorList.TabIndex = 0;
            this.tabPageBindingFileErrorList.Text = "Error list";
            this.tabPageBindingFileErrorList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.No,
            this.Column1,
            this.ArtefactType,
            this.ArtefactName,
            this.Description,
            this.RuleName,
            this.LineNumber});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1119, 210);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Icon
            // 
            this.Icon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Icon.HeaderText = "";
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Width = 5;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 44;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ArtefactType
            // 
            this.ArtefactType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ArtefactType.HeaderText = "Artefact Type";
            this.ArtefactType.Name = "ArtefactType";
            this.ArtefactType.ReadOnly = true;
            this.ArtefactType.Width = 5;
            // 
            // ArtefactName
            // 
            this.ArtefactName.HeaderText = "Artefact Name";
            this.ArtefactName.Name = "ArtefactName";
            this.ArtefactName.ReadOnly = true;
            this.ArtefactName.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // RuleName
            // 
            this.RuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RuleName.HeaderText = "Rule Name";
            this.RuleName.Name = "RuleName";
            this.RuleName.ReadOnly = true;
            this.RuleName.Width = 76;
            // 
            // LineNumber
            // 
            this.LineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LineNumber.HeaderText = "Line number";
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.ReadOnly = true;
            this.LineNumber.Width = 81;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // frmBindingFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 731);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmBindingFile";
            this.Text = "frmBindingFile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBindingFile_FormClosed);
            this.Load += new System.EventHandler(this.frmBindingFile_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.bindingFileContentContextMenuStrip.ResumeLayout(false);
            this.bindingFileStatusStrip.ResumeLayout(false);
            this.bindingFileStatusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPageBindingFileErrorList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip bindingFileStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBindingFileErrorList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBoxBindingFileContent;
        private System.Windows.Forms.ContextMenuStrip bindingFileContentContextMenuStrip;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ToolStripMenuItem openInNotepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtefactType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtefactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumber;
    }
}