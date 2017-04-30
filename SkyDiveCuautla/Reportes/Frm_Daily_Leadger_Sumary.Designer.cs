namespace SkyDiveCuautla.Reportes
{
    partial class Frm_Daily_Leadger_Sumary
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
            this.rv_daily_ledger_summary = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rv_daily_ledger_summary
            // 
            this.rv_daily_ledger_summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rv_daily_ledger_summary.Location = new System.Drawing.Point(0, 0);
            this.rv_daily_ledger_summary.Name = "rv_daily_ledger_summary";
            this.rv_daily_ledger_summary.Size = new System.Drawing.Size(747, 633);
            this.rv_daily_ledger_summary.TabIndex = 0;
            // 
            // Frm_Daily_Leadger_Sumary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(747, 633);
            this.Controls.Add(this.rv_daily_ledger_summary);
            this.Name = "Frm_Daily_Leadger_Sumary";
            this.Text = "Daily Leadger Sumary";
            this.Load += new System.EventHandler(this.Frm_Daily_Leadger_Sumary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv_daily_ledger_summary;
    }
}