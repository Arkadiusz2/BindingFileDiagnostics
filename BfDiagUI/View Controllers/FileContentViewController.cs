using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BfDiagUI
{
     public class FileContentViewController : BaseViewController<RichTextBox, string>
    {
        public FileContentViewController(RichTextBox control)
            : base(control)
        {
        }

        public override void Bind()
        {
            Cursor savedCursor = this.Control.Cursor;
            int savedSelectionStart = this.Control.SelectionStart;
            int savedSelectionLength = this.Control.SelectionLength;

            try
            {
                this.Control.Cursor = Cursors.WaitCursor;

                User32.LockWindowUpdate(this.Control.Handle);
                this.Control.Text = this.DataSource;
                this.Control.HighlightRTF();
                this.Control.SelectionStart = savedSelectionStart;
                this.Control.SelectionLength = savedSelectionLength;
                this.Control.ScrollToCaret();
            }
            finally
            {
                User32.LockWindowUpdate(IntPtr.Zero);
                this.Control.Cursor = savedCursor;
            }
        }
    }

}
