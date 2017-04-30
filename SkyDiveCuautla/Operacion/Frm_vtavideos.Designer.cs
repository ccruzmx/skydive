namespace SkyDiveCuautla.Operacion
{
    partial class Frm_vtavideos
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
            this.grp_manifiest = new System.Windows.Forms.GroupBox();
            this.dg_manifiesto = new System.Windows.Forms.DataGridView();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.grp_manifiest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_manifiesto)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_manifiest
            // 
            this.grp_manifiest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp_manifiest.Controls.Add(this.dg_manifiesto);
            this.grp_manifiest.Location = new System.Drawing.Point(12, 12);
            this.grp_manifiest.Name = "grp_manifiest";
            this.grp_manifiest.Size = new System.Drawing.Size(1003, 722);
            this.grp_manifiest.TabIndex = 34;
            this.grp_manifiest.TabStop = false;
            // 
            // dg_manifiesto
            // 
            this.dg_manifiesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_manifiesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_manifiesto.Location = new System.Drawing.Point(12, 19);
            this.dg_manifiesto.Name = "dg_manifiesto";
            this.dg_manifiesto.Size = new System.Drawing.Size(980, 697);
            this.dg_manifiesto.TabIndex = 0;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::SkyDiveCuautla.Properties.Resources.refresh;
            this.btn_refresh.Location = new System.Drawing.Point(1039, 12);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 62);
            this.btn_refresh.TabIndex = 53;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Frm_vtavideos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1349, 739);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.grp_manifiest);
            this.Name = "Frm_vtavideos";
            this.Text = "Video Sales";
            this.Load += new System.EventHandler(this.Frm_vtavideos_Load);
            this.grp_manifiest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_manifiesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_manifiest;
        private System.Windows.Forms.DataGridView dg_manifiesto;
        private System.Windows.Forms.Button btn_refresh;
    }
}