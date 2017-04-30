namespace SkyDiveCuautla.Reportes
{
    partial class Frm_FiltroReportes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_datefin = new System.Windows.Forms.Label();
            this.lbl_dateini = new System.Windows.Forms.Label();
            this.dtp_datefin = new System.Windows.Forms.DateTimePicker();
            this.dtp_dateini = new System.Windows.Forms.DateTimePicker();
            this.btn_ok = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Iskoola Pota", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report filter";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_datefin);
            this.groupBox2.Controls.Add(this.lbl_dateini);
            this.groupBox2.Controls.Add(this.dtp_datefin);
            this.groupBox2.Controls.Add(this.dtp_dateini);
            this.groupBox2.Location = new System.Drawing.Point(3, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lbl_datefin
            // 
            this.lbl_datefin.AutoSize = true;
            this.lbl_datefin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datefin.Location = new System.Drawing.Point(21, 94);
            this.lbl_datefin.Name = "lbl_datefin";
            this.lbl_datefin.Size = new System.Drawing.Size(91, 24);
            this.lbl_datefin.TabIndex = 3;
            this.lbl_datefin.Text = "End date:";
            // 
            // lbl_dateini
            // 
            this.lbl_dateini.AutoSize = true;
            this.lbl_dateini.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateini.Location = new System.Drawing.Point(21, 34);
            this.lbl_dateini.Name = "lbl_dateini";
            this.lbl_dateini.Size = new System.Drawing.Size(97, 24);
            this.lbl_dateini.TabIndex = 2;
            this.lbl_dateini.Text = "Initial date:";
            // 
            // dtp_datefin
            // 
            this.dtp_datefin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_datefin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_datefin.Location = new System.Drawing.Point(124, 94);
            this.dtp_datefin.Name = "dtp_datefin";
            this.dtp_datefin.Size = new System.Drawing.Size(152, 29);
            this.dtp_datefin.TabIndex = 1;
            // 
            // dtp_dateini
            // 
            this.dtp_dateini.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_dateini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_dateini.Location = new System.Drawing.Point(124, 29);
            this.dtp_dateini.Name = "dtp_dateini";
            this.dtp_dateini.Size = new System.Drawing.Size(152, 29);
            this.dtp_dateini.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(108, 255);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 36);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Generate";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Frm_FiltroReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(300, 319);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FiltroReportes";
            this.Text = "Report filter";
            this.Load += new System.EventHandler(this.Frm_FiltroReportes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_datefin;
        private System.Windows.Forms.Label lbl_dateini;
        private System.Windows.Forms.DateTimePicker dtp_datefin;
        private System.Windows.Forms.DateTimePicker dtp_dateini;
        private System.Windows.Forms.Label label1;
    }
}