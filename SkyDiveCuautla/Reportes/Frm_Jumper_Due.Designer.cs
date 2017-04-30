namespace SkyDiveCuautla.Reportes
{
    partial class Frm_Jumper_Due
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
            this.rv_jumper_due = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rv_jumper_due
            // 
            this.rv_jumper_due.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rv_jumper_due.LocalReport.ReportEmbeddedResource = "SkyDiveCuautla.Reportes.Rpt_Jumper_Due.rdlc";
            this.rv_jumper_due.Location = new System.Drawing.Point(0, 0);
            this.rv_jumper_due.Name = "rv_jumper_due";
            this.rv_jumper_due.Size = new System.Drawing.Size(864, 605);
            this.rv_jumper_due.TabIndex = 0;
            // 
            // Frm_Jumper_Due
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(864, 605);
            this.Controls.Add(this.rv_jumper_due);
            this.Name = "Frm_Jumper_Due";
            this.Text = "Jumper Due Report";
            this.Load += new System.EventHandler(this.Frm_Jumper_Due_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv_jumper_due;
    }
}