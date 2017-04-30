namespace SkyDiveCuautla.Operacion
{
    partial class Frm_TandemupDip
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_tandemup = new System.Windows.Forms.DataGridView();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txb_name = new System.Windows.Forms.TextBox();
            this.txb_instructor = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.btn_save2 = new System.Windows.Forms.Button();
            this.gpb_tandemdata = new System.Windows.Forms.GroupBox();
            this.lbl_last = new System.Windows.Forms.Label();
            this.txb_lastname = new System.Windows.Forms.TextBox();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.gb_diploma = new System.Windows.Forms.GroupBox();
            this.rpv_diploma = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_flights = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tandemup)).BeginInit();
            this.gpb_tandemdata.SuspendLayout();
            this.gb_diploma.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_flights)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.dg_tandemup);
            this.groupBox3.Location = new System.Drawing.Point(292, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 494);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // dg_tandemup
            // 
            this.dg_tandemup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_tandemup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_tandemup.Location = new System.Drawing.Point(6, 13);
            this.dg_tandemup.Name = "dg_tandemup";
            this.dg_tandemup.Size = new System.Drawing.Size(266, 475);
            this.dg_tandemup.TabIndex = 7;
            this.dg_tandemup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_tandemup_CellClick);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(26, 84);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "Name";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(26, 143);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(51, 13);
            this.lbl_email.TabIndex = 3;
            this.lbl_email.Text = "Instructor";
            // 
            // txb_name
            // 
            this.txb_name.Location = new System.Drawing.Point(29, 110);
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(164, 20);
            this.txb_name.TabIndex = 1;
            // 
            // txb_instructor
            // 
            this.txb_instructor.Location = new System.Drawing.Point(29, 168);
            this.txb_instructor.Name = "txb_instructor";
            this.txb_instructor.Size = new System.Drawing.Size(293, 20);
            this.txb_instructor.TabIndex = 3;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(552, 93);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(99, 95);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(359, 16);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(483, 45);
            this.lbl_titulo.TabIndex = 30;
            this.lbl_titulo.Text = "TANDEM CERTIFICATE";
            // 
            // btn_save2
            // 
            this.btn_save2.Enabled = false;
            this.btn_save2.Location = new System.Drawing.Point(342, 93);
            this.btn_save2.Name = "btn_save2";
            this.btn_save2.Size = new System.Drawing.Size(100, 95);
            this.btn_save2.TabIndex = 4;
            this.btn_save2.Text = "Save";
            this.btn_save2.UseVisualStyleBackColor = true;
            this.btn_save2.Click += new System.EventHandler(this.btn_save2_Click);
            // 
            // gpb_tandemdata
            // 
            this.gpb_tandemdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpb_tandemdata.Controls.Add(this.lbl_last);
            this.gpb_tandemdata.Controls.Add(this.txb_lastname);
            this.gpb_tandemdata.Controls.Add(this.btn_imprimir);
            this.gpb_tandemdata.Controls.Add(this.btn_save2);
            this.gpb_tandemdata.Controls.Add(this.lbl_titulo);
            this.gpb_tandemdata.Controls.Add(this.btn_exit);
            this.gpb_tandemdata.Controls.Add(this.txb_instructor);
            this.gpb_tandemdata.Controls.Add(this.txb_name);
            this.gpb_tandemdata.Controls.Add(this.lbl_email);
            this.gpb_tandemdata.Controls.Add(this.lbl_name);
            this.gpb_tandemdata.Location = new System.Drawing.Point(9, 6);
            this.gpb_tandemdata.Name = "gpb_tandemdata";
            this.gpb_tandemdata.Size = new System.Drawing.Size(1348, 232);
            this.gpb_tandemdata.TabIndex = 34;
            this.gpb_tandemdata.TabStop = false;
            this.gpb_tandemdata.Text = "Tandem Data";
            // 
            // lbl_last
            // 
            this.lbl_last.AutoSize = true;
            this.lbl_last.Location = new System.Drawing.Point(199, 84);
            this.lbl_last.Name = "lbl_last";
            this.lbl_last.Size = new System.Drawing.Size(53, 13);
            this.lbl_last.TabIndex = 42;
            this.lbl_last.Text = "Lastname";
            // 
            // txb_lastname
            // 
            this.txb_lastname.Location = new System.Drawing.Point(199, 110);
            this.txb_lastname.Name = "txb_lastname";
            this.txb_lastname.Size = new System.Drawing.Size(123, 20);
            this.txb_lastname.TabIndex = 2;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_imprimir.Location = new System.Drawing.Point(448, 93);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(98, 95);
            this.btn_imprimir.TabIndex = 5;
            this.btn_imprimir.Text = "Preview";
            this.btn_imprimir.UseVisualStyleBackColor = false;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // gb_diploma
            // 
            this.gb_diploma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_diploma.Controls.Add(this.rpv_diploma);
            this.gb_diploma.Location = new System.Drawing.Point(576, 244);
            this.gb_diploma.Name = "gb_diploma";
            this.gb_diploma.Size = new System.Drawing.Size(781, 494);
            this.gb_diploma.TabIndex = 36;
            this.gb_diploma.TabStop = false;
            // 
            // rpv_diploma
            // 
            this.rpv_diploma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpv_diploma.LocalReport.ReportEmbeddedResource = "SkyDiveCuautla.Reportes.Rpt_TandemCertificate.rdlc";
            this.rpv_diploma.Location = new System.Drawing.Point(6, 13);
            this.rpv_diploma.Name = "rpv_diploma";
            this.rpv_diploma.ShowBackButton = false;
            this.rpv_diploma.ShowExportButton = false;
            this.rpv_diploma.ShowFindControls = false;
            this.rpv_diploma.Size = new System.Drawing.Size(768, 469);
            this.rpv_diploma.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dg_flights);
            this.groupBox1.Location = new System.Drawing.Point(9, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 494);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // dg_flights
            // 
            this.dg_flights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_flights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_flights.Location = new System.Drawing.Point(5, 13);
            this.dg_flights.Name = "dg_flights";
            this.dg_flights.Size = new System.Drawing.Size(266, 472);
            this.dg_flights.TabIndex = 8;
            this.dg_flights.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_flights_CellContentClick);
            // 
            // Frm_TandemupDip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1361, 741);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_diploma);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gpb_tandemdata);
            this.Name = "Frm_TandemupDip";
            this.Text = "Tandem Certificate";
            this.Load += new System.EventHandler(this.Frm_TandemupDip_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_tandemup)).EndInit();
            this.gpb_tandemdata.ResumeLayout(false);
            this.gpb_tandemdata.PerformLayout();
            this.gb_diploma.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_flights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_tandemup;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txb_name;
        private System.Windows.Forms.TextBox txb_instructor;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Button btn_save2;
        private System.Windows.Forms.GroupBox gpb_tandemdata;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.TextBox txb_lastname;
        private System.Windows.Forms.Label lbl_last;
        private System.Windows.Forms.GroupBox gb_diploma;
        private Microsoft.Reporting.WinForms.ReportViewer rpv_diploma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_flights;
    }
}