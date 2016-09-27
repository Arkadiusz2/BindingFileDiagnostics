using BindingFile.Diagnostics.Rules;
using CustomUIComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BfDiagUI
{
    public partial class frmOptions : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        
        public frmOptions()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void HideForm()
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            HideForm();
        }    

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HideForm();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            LoadRules();
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtDiagnosticRulesPath.Text = Settings.Settings.RulesPath;
            txtDiagnosticRulesAbsolutePath.Text = Settings.Settings.RulesAbsolutePath;
            txtExternalEditorPath.Text = Settings.Settings.ExternalEditorPath;
            txtExternalEditorParameters.Text = Settings.Settings.ExternalEditorParameters;
        }

        private void SaveSettings()
        {
            Settings.Settings.RulesPath = txtDiagnosticRulesPath.Text;
            Settings.Settings.ExternalEditorPath = txtExternalEditorPath.Text;
            Settings.Settings.ExternalEditorParameters = txtExternalEditorParameters.Text;
        }

        private void LoadRules()
        {

            RulesController rulesController = new RulesController();

            foreach (ControlledRule controlledRule in rulesController.BindingRules)
            {
                ListViewItem item = listView1.Items.Add("");
                item.ImageIndex = controlledRule.BindingRule.IsConfigurable ? 0 : 1;
                item.SubItems.Add(controlledRule.BindingRule.Name);
                item.SubItems.Add(controlledRule.BindingRule.GetType().FullName);                
            }

            // Presort by rule name
            lvwColumnSorter.SortColumn = 2;
            lvwColumnSorter.Order = SortOrder.Ascending;            
            this.listView1.Sort();

            toolStripStatusLabel1.Text = string.Format("{0} rules", rulesController.RulesCount);
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDiagnosticRulesPath_TextChanged(object sender, EventArgs e)
        {
            txtDiagnosticRulesAbsolutePath.Text = Settings.Settings.GetRulesAbsolutePath(txtDiagnosticRulesPath.Text);
        }
    }
}
