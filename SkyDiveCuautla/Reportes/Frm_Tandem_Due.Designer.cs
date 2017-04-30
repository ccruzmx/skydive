namespace SkyDiveCuautla.Reportes
{
    partial class Frm_Tandem_Due
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
            this.rv_tandemdue = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rv_tandemdue
            // 
            this.rv_tandemdue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rv_tandemdue.LocalReport.ReportEmbeddedResource = "SkyDiveCuautla.Reportes.Rpt_Tandem_Due.rdlc";
            this.rv_tandemdue.Location = new System.Drawing.Point(0, 0);
            this.rv_tandemdue.Name = "rv_tandemdue";
            this.rv_tandemdue.Size = new System.Drawing.Size(1161, 608);
            this.rv_tandemdue.TabIndex = 0;
            // 
            // Frm_Tandem_Due
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1161, 608);
            this.Controls.Add(this.rv_tandemdue);
            this.Name = "Frm_Tandem_Due";
            this.Text = "Tandem Due Detail";
            this.Load += new System.EventHandler(this.Frm_Tandem_Due_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv_tandemdue;
    }
}