using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using BindingFile.Diagnostics.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BfDiagUI
{
    public partial class frmMain : Form
    {
        #region Constants
        private const string _APPLICATION_NAME = "Binding File Diagnostics";
        //private BindingFileFormStateEnum _formState = BindingFileFormStateEnum.Unassigned;
        #endregion
        

        #region Child forms
        /// <summary>
        /// Options form handle
        /// </summary>
        private frmOptions _optionsForm = null;

        /// <summary>
        /// Handles to all open binding file forms
        /// </summary>
        private List<frmBindingFile> _bindingFileForms = new List<frmBindingFile>();      
              
        
        /// <summary>
        /// Retrieves existing or initializes new options form
        /// There can be only one options form
        /// </summary>
        private frmOptions OptionsForm
        {
            get
            {
                if (_optionsForm == null)
                {
                    _optionsForm = new frmOptions();
                }
                return _optionsForm;
            }
        }

        public void OpenFileAsync(string bindingFile)
        {
            OpenBindingFile(bindingFile);
        }

        /// <summary>
        /// Prompts for a binding file path and displays selected binding file
        /// </summary>
        private void OpenBindingFiles()
        {
            if (openFileDialogBindingFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialogBindingFile.FileNames)
                {
                    OpenFileAsync(fileName);
                }
            }
        }

        private void OpenBindingFile(string fileName)
        {
            frmBindingFile bindingFileForm = _bindingFileForms.FirstOrDefault(x => x.BindingFileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));

            if (bindingFileForm != null)
            {
                RestoreFormWindowState(bindingFileForm);
            }
            else
            {
                bindingFileForm = new frmBindingFile();
                bindingFileForm.FormClosed += bindingFileForm_FormClosed;
                _bindingFileForms.Add(bindingFileForm);
                
                bindingFileForm.MdiParent = this;
                bindingFileForm.WindowState = FormWindowState.Maximized;                
                bindingFileForm.BindingFileName = fileName;                

                // Add item to the menu
                string bindingFileName = System.IO.Path.GetFileName(fileName);
                int fileNumber = windowToolStripMenuItem.DropDownItems.Count - 1;
                string menuText = string.Format("{0} {1}", fileNumber, bindingFileName);
                
                ToolStripMenuItem bindingFileMenuItem = new ToolStripMenuItem(menuText);
                bindingFileMenuItem.Tag = bindingFileForm;
                bindingFileMenuItem.Click += bindingFileMenuItem_Click;
                
                int itemIndex = windowToolStripMenuItem.DropDownItems.Count - 2;
                windowToolStripMenuItem.DropDownItems.Insert(itemIndex, bindingFileMenuItem);
            }

            bindingFileForm.Show();
        }

        void bindingFileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                frmBindingFile bindingFileForm = (frmBindingFile)sender;
                CloseForm(bindingFileForm);

                //_bindingFileForms.Remove(bindingFileForm);
                
                //var dropDownItem = (from ToolStripDropDownItem item in windowToolStripMenuItem.DropDownItems
                //        where item.Tag.Equals(bindingFileForm)
                //        select item).FirstOrDefault();

                //if (dropDownItem != null)
                //{
                //    windowToolStripMenuItem.DropDownItems.Remove(dropDownItem);
                //}
                //bindingFileForm.Dispose();

                RenumerateFilesInWindowsMenu();
            }
        }

        private void CloseAllWindows()
        {
            if (_bindingFileForms.Count > 0)
            {
                for (int i = _bindingFileForms.Count - 1; i >= 0; i--)
                {
                    CloseForm(_bindingFileForms[i]);
                }
            }
        }

        private void CloseForm(frmBindingFile bindingFileForm)
        {
            _bindingFileForms.Remove(bindingFileForm);

            var dropDownItem = (from ToolStripItem item in windowToolStripMenuItem.DropDownItems
                                where item.Tag.Equals(bindingFileForm)
                                select item).FirstOrDefault();

            if (dropDownItem != null)
            {
                windowToolStripMenuItem.DropDownItems.Remove(dropDownItem);
            }
            bindingFileForm.Dispose();
        }

        private void RenumerateFilesInWindowsMenu()
        {
            // TODO: Renumerate other forms
            int fileNumber = 1;
            foreach (ToolStripItem item in windowToolStripMenuItem.DropDownItems)
            {
                frmBindingFile bindingFileForm = item.Tag as frmBindingFile;                
                if (bindingFileForm != null)
                {
                    string bindingFileName = System.IO.Path.GetFileName(bindingFileForm.BindingFileName);
                    string menuText = string.Format("{0} {1}", fileNumber++, bindingFileName);
                    item.Text = menuText;
                }                
            }
        }

        void RestoreFormWindowState(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;                
            }

            form.BringToFront();
        }

        void bindingFileMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem bindingFileMenuItem = (ToolStripMenuItem)sender;
            frmBindingFile bidningFileForm = (frmBindingFile)bindingFileMenuItem.Tag;

            RestoreFormWindowState(bidningFileForm);
        }

        #endregion

        #region Encapsulated methods
        /// <summary>
        /// Displays options form if it was hidden
        /// </summary>
        private void ShowOptionsForm()
        {
            this.OptionsForm.Show();
            this.OptionsForm.TopLevel = true;
        }        
        #endregion


        public frmMain(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
            {
                foreach (string fileName in args)
                {
                    if (File.Exists(fileName))
                    {
                        OpenFileAsync(fileName);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Exit();
            }
            catch (Exception ex)
            {
                Display.ShowException(ex);
            }
        }

        #region Form methods             

        private void Exit()
        {
            Application.Exit();
        }

        private void ChangeFormState(BindingFileFormStateEnum formState)
        {
        }


        #endregion

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBindingFiles();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }


        private void readerSettings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            string message = string.Format("[Line: {0}, Position: {1}] {2}", e.Exception.LineNumber, e.Exception.LinePosition, e.Message);
            Console.WriteLine(message);
        }  
    

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowOptionsForm();
            }
            catch (Exception ex)
            {
                Display.ShowException(ex);
            }
        }

        private void repaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RepaintBindingFileContent();
        }

        private void mainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                OpenFileAsync(file);
            }
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllWindows();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new frmAbout();
            about.ShowDialog();
        }
        
    }
}
