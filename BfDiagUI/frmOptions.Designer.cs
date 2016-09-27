namespace BfDiagUI
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiagnosticRulesAbsolutePath = new System.Windows.Forms.TextBox();
            this.lblRulesAbsolutePath = new System.Windows.Forms.Label();
            this.lblDiagnosticRulesPath = new System.Windows.Forms.Label();
            this.txtDiagnosticRulesPath = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblExternalEditorPath = new System.Windows.Forms.Label();
            this.txtExternalEditorPath = new System.Windows.Forms.TextBox();
            this.lblExternalEditorParameters = new System.Windows.Forms.Label();
            this.txtExternalEditorParameters = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControlOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOptions.Controls.Add(this.tabPage1);
            this.tabControlOptions.Controls.Add(this.tabPage2);
            this.tabControlOptions.Location = new System.Drawing.Point(12, 12);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(771, 435);
            this.tabControlOptions.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(763, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Diagnostic rules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(757, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIcon,
            this.columnHeaderName,
            this.columnHeaderType});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(757, 381);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeaderIcon
            // 
            this.columnHeaderIcon.Text = "";
            this.columnHeaderIcon.Width = 50;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 280;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 407;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Configurable");
            this.imageList1.Images.SetKeyName(1, "Nonconfigurable");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(693, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDiagnosticRulesAbsolutePath);
            this.groupBox1.Controls.Add(this.lblRulesAbsolutePath);
            this.groupBox1.Controls.Add(this.lblDiagnosticRulesPath);
            this.groupBox1.Controls.Add(this.txtDiagnosticRulesPath);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diagnostic rules";
            // 
            // txtDiagnosticRulesAbsolutePath
            // 
            this.txtDiagnosticRulesAbsolutePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnosticRulesAbsolutePath.Location = new System.Drawing.Point(96, 50);
            this.txtDiagnosticRulesAbsolutePath.Name = "txtDiagnosticRulesAbsolutePath";
            this.txtDiagnosticRulesAbsolutePath.ReadOnly = true;
            this.txtDiagnosticRulesAbsolutePath.Size = new System.Drawing.Size(576, 20);
            this.txtDiagnosticRulesAbsolutePath.TabIndex = 4;
            // 
            // lblRulesAbsolutePath
            // 
            this.lblRulesAbsolutePath.AutoSize = true;
            this.lblRulesAbsolutePath.Location = new System.Drawing.Point(15, 53);
            this.lblRulesAbsolutePath.Name = "lblRulesAbsolutePath";
            this.lblRulesAbsolutePath.Size = new System.Drawing.Size(75, 13);
            this.lblRulesAbsolutePath.TabIndex = 3;
            this.lblRulesAbsolutePath.Text = "Absolute path:";
            this.lblRulesAbsolutePath.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDiagnosticRulesPath
            // 
            this.lblDiagnosticRulesPath.AutoSize = true;
            this.lblDiagnosticRulesPath.Location = new System.Drawing.Point(21, 26);
            this.lblDiagnosticRulesPath.Name = "lblDiagnosticRulesPath";
            this.lblDiagnosticRulesPath.Size = new System.Drawing.Size(69, 13);
            this.lblDiagnosticRulesPath.TabIndex = 1;
            this.lblDiagnosticRulesPath.Text = "Subdirectory:";
            // 
            // txtDiagnosticRulesPath
            // 
            this.txtDiagnosticRulesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnosticRulesPath.Location = new System.Drawing.Point(96, 23);
            this.txtDiagnosticRulesPath.Name = "txtDiagnosticRulesPath";
            this.txtDiagnosticRulesPath.ReadOnly = true;
            this.txtDiagnosticRulesPath.Size = new System.Drawing.Size(576, 20);
            this.txtDiagnosticRulesPath.TabIndex = 0;
            this.txtDiagnosticRulesPath.TextChanged += new System.EventHandler(this.txtDiagnosticRulesPath_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(708, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(627, 460);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblExternalEditorPath
            // 
            this.lblExternalEditorPath.AutoSize = true;
            this.lblExternalEditorPath.Location = new System.Drawing.Point(48, 28);
            this.lblExternalEditorPath.Name = "lblExternalEditorPath";
            this.lblExternalEditorPath.Size = new System.Drawing.Size(32, 13);
            this.lblExternalEditorPath.TabIndex = 0;
            this.lblExternalEditorPath.Text = "&Path:";
            // 
            // txtExternalEditorPath
            // 
            this.txtExternalEditorPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalEditorPath.Location = new System.Drawing.Point(96, 25);
            this.txtExternalEditorPath.Name = "txtExternalEditorPath";
            this.txtExternalEditorPath.ReadOnly = true;
            this.txtExternalEditorPath.Size = new System.Drawing.Size(576, 20);
            this.txtExternalEditorPath.TabIndex = 1;
            // 
            // lblExternalEditorParameters
            // 
            this.lblExternalEditorParameters.AutoSize = true;
            this.lblExternalEditorParameters.Location = new System.Drawing.Point(17, 58);
            this.lblExternalEditorParameters.Name = "lblExternalEditorParameters";
            this.lblExternalEditorParameters.Size = new System.Drawing.Size(63, 13);
            this.lblExternalEditorParameters.TabIndex = 2;
            this.lblExternalEditorParameters.Text = "Pa&rameters:";
            // 
            // txtExternalEditorParameters
            // 
            this.txtExternalEditorParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalEditorParameters.Location = new System.Drawing.Point(96, 55);
            this.txtExternalEditorParameters.Name = "txtExternalEditorParameters";
            this.txtExternalEditorParameters.ReadOnly = true;
            this.txtExternalEditorParameters.Size = new System.Drawing.Size(576, 20);
            this.txtExternalEditorParameters.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtExternalEditorParameters);
            this.groupBox2.Controls.Add(this.lblExternalEditorParameters);
            this.groupBox2.Controls.Add(this.txtExternalEditorPath);
            this.groupBox2.Controls.Add(this.lblExternalEditorPath);
            this.groupBox2.Location = new System.Drawing.Point(3, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 291);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "External editor";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(795, 495);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControlOptions);
            this.Name = "frmOptions";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderIcon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiagnosticRulesPath;
        private System.Windows.Forms.Label lblDiagnosticRulesPath;
        private System.Windows.Forms.Label lblRulesAbsolutePath;
        private System.Windows.Forms.TextBox txtDiagnosticRulesAbsolutePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtExternalEditorParameters;
        private System.Windows.Forms.Label lblExternalEditorParameters;
        private System.Windows.Forms.TextBox txtExternalEditorPath;
        private System.Windows.Forms.Label lblExternalEditorPath;
    }
}