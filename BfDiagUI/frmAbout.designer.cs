namespace BfDiagUI
{
    partial class frmAbout
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
            this.txtAbout = new System.Windows.Forms.RichTextBox();
            this.txtCredits = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtAbout
            // 
            this.txtAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAbout.Location = new System.Drawing.Point(35, 24);
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ReadOnly = true;
            this.txtAbout.Size = new System.Drawing.Size(323, 54);
            this.txtAbout.TabIndex = 0;
            this.txtAbout.Text = "Binding File Diagnostics for BizTalk Server 2013R2\nVersion 1.0";
            // 
            // txtCredits
            // 
            this.txtCredits.BackColor = System.Drawing.SystemColors.Control;
            this.txtCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCredits.Location = new System.Drawing.Point(35, 148);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.ReadOnly = true;
            this.txtCredits.Size = new System.Drawing.Size(391, 102);
            this.txtCredits.TabIndex = 2;
            this.txtCredits.Text = "Credits:\n\nArkadiusz Krynski : https://nl.linkedin.com/in/arkadiuszkrynski\n\nRitu R" +
    "aj : https://nl.linkedin.com/in/riturajsoa";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 264);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.txtAbout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtAbout;
        private System.Windows.Forms.RichTextBox txtCredits;
    }
}