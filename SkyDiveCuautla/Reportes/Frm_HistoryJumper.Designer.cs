namespace SkyDiveCuautla.Reportes
{
    partial class Frm_HistoryJumper
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
            this.rv_history_jumper = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rv_history_jumper
            // 
            this.rv_history_jumper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rv_history_jumper.LocalReport.ReportEmbeddedResource = "SkyDiveCuautla.Reportes.Rpt_History_Jumper.rdlc";
            this.rv_history_jumper.Location = new System.Drawing.Point(0, 0);
            this.rv_history_jumper.Name = "rv_history_jumper";
            this.rv_history_jumper.Size = new System.Drawing.Size(1143, 634);
            this.rv_history_jumper.TabIndex = 0;
            // 
            // Frm_HistoryJumper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1143, 634);
            this.Controls.Add(this.rv_history_jumper);
            this.Name = "Frm_HistoryJumper";
            this.Text = "History Jumper Report";
            this.Load += new System.EventHandler(this.Frm_HistoryJumper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv_history_jumper;
    }
}