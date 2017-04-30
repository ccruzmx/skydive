namespace SkyDiveCuautla.Operacion
{
    partial class Frm_Processing
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
            this.pb_estatus = new System.Windows.Forms.PictureBox();
            this.lbl_mensaje1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_estatus
            // 
            this.pb_estatus.Image = global::SkyDiveCuautla.Properties.Resources.ajax_loader;
            this.pb_estatus.Location = new System.Drawing.Point(28, 46);
            this.pb_estatus.Margin = new System.Windows.Forms.Padding(4);
            this.pb_estatus.Name = "pb_estatus";
            this.pb_estatus.Size = new System.Drawing.Size(133, 62);
            this.pb_estatus.TabIndex = 0;
            this.pb_estatus.TabStop = false;
            // 
            // lbl_mensaje1
            // 
            this.lbl_mensaje1.AutoSize = true;
            this.lbl_mensaje1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensaje1.Location = new System.Drawing.Point(168, 46);
            this.lbl_mensaje1.Name = "lbl_mensaje1";
            this.lbl_mensaje1.Size = new System.Drawing.Size(137, 29);
            this.lbl_mensaje1.TabIndex = 1;
            this.lbl_mensaje1.Text = "Please wait";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connecting to server ...";
            // 
            // Frm_Processing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(450, 149);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_mensaje1);
            this.Controls.Add(this.pb_estatus);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Processing";
            this.Opacity = 0.1D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress...";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.Frm_Processing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_estatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_estatus;
        private System.Windows.Forms.Label lbl_mensaje1;
        private System.Windows.Forms.Label label2;
    }
}