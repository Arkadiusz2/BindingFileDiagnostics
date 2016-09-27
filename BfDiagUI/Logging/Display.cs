using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BfDiagUI
{
    public static class Display
    {
        private const string _APPLICATION_NAME = "Binding File Diagnostics";

        public static void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, _APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowException(Exception ex)
        {
            string message = ex.ToString();
            MessageBox.Show(message, _APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, _APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessage(string message, bool customForm)
        {
            if (!customForm)
            {
                ShowMessage(message);
            }
            else
            {
                frmShowMessage messageForm = new frmShowMessage();
                messageForm.Header = _APPLICATION_NAME;
                messageForm.Message = message;
                messageForm.ShowDialog();
            }
        }

        public static DialogResult AskQuestion(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, _APPLICATION_NAME, buttons, MessageBoxIcon.Question);
        }
    }
}
