namespace SkyDiveCuautla.Reportes
{
    partial class Frm_Jump_Exceptions
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
            this.rv_jumper_exception = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rv_jumper_exception
            // 
            this.rv_jumper_exception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rv_jumper_exception.LocalReport.ReportEmbeddedResource = "SkyDiveCuautla.Reportes.Rpt_jumper_exception.rdlc";
            this.rv_jumper_exception.Location = new System.Drawing.Point(0, 0);
            this.rv_jumper_exception.Name = "rv_jumper_exception";
            this.rv_jumper_exception.Size = new System.Drawing.Size(819, 626);
            this.rv_jumper_exception.TabIndex = 0;
            // 
            // Frm_Jump_Exceptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(819, 626);
            this.Controls.Add(this.rv_jumper_exception);
            this.Name = "Frm_Jump_Exceptions";
            this.Text = "Jump Exceptions Report";
            this.Load += new System.EventHandler(this.Frm_Jump_Exceptions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv_jumper_exception;
    }
}