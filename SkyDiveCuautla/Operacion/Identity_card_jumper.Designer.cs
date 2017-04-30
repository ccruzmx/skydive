namespace SkyDiveCuautla.Operacion
{
    partial class Identity_card_jumper
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
            this.tb_Identity = new System.Windows.Forms.TabControl();
            this.tb_print = new System.Windows.Forms.TabPage();
            this.tb_read_identity = new System.Windows.Forms.TabPage();
            this.tb_Identity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Identity
            // 
            this.tb_Identity.Controls.Add(this.tb_print);
            this.tb_Identity.Controls.Add(this.tb_read_identity);
            this.tb_Identity.Location = new System.Drawing.Point(12, 12);
            this.tb_Identity.Name = "tb_Identity";
            this.tb_Identity.SelectedIndex = 0;
            this.tb_Identity.Size = new System.Drawing.Size(826, 370);
            this.tb_Identity.TabIndex = 0;
            // 
            // tb_print
            // 
            this.tb_print.Location = new System.Drawing.Point(4, 22);
            this.tb_print.Name = "tb_print";
            this.tb_print.Padding = new System.Windows.Forms.Padding(3);
            this.tb_print.Size = new System.Drawing.Size(818, 344);
            this.tb_print.TabIndex = 1;
            this.tb_print.Text = "Print Identity";
            this.tb_print.UseVisualStyleBackColor = true;
            // 
            // tb_read_identity
            // 
            this.tb_read_identity.Location = new System.Drawing.Point(4, 22);
            this.tb_read_identity.Name = "tb_read_identity";
            this.tb_read_identity.Size = new System.Drawing.Size(818, 344);
            this.tb_read_identity.TabIndex = 2;
            this.tb_read_identity.Text = "Pre-Register Jumper";
            this.tb_read_identity.UseVisualStyleBackColor = true;
            // 
            // Identity_card_jumper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(850, 394);
            this.Controls.Add(this.tb_Identity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Identity_card_jumper";
            this.Text = "Identity Card Jumper";
            this.tb_Identity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tb_Identity;
        private System.Windows.Forms.TabPage tb_print;
        private System.Windows.Forms.TabPage tb_read_identity;
    }
}