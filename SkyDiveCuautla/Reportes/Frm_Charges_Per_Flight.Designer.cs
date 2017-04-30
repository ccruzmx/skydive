namespace SkyDiveCuautla.Reportes
{
    partial class Frm_Charges_Per_Flight
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
            this.rv_charges_per_flight = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rv_charges_per_flight
            // 
            this.rv_charges_per_flight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rv_charges_per_flight.Location = new System.Drawing.Point(0, 0);
            this.rv_charges_per_flight.Name = "rv_charges_per_flight";
            this.rv_charges_per_flight.Size = new System.Drawing.Size(745, 576);
            this.rv_charges_per_flight.TabIndex = 0;
            // 
            // Frm_Charges_Per_Flight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(745, 576);
            this.Controls.Add(this.rv_charges_per_flight);
            this.Name = "Frm_Charges_Per_Flight";
            this.Text = "Charges Per Flight Report";
            this.Load += new System.EventHandler(this.Frm_Charges_Per_Flight_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv_charges_per_flight;
    }
}