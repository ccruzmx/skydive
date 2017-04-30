namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Pilots
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_piloto = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.lbl_secondlastname = new System.Windows.Forms.Label();
            this.txb_secondlastname = new System.Windows.Forms.TextBox();
            this.lbl_paterno = new System.Windows.Forms.Label();
            this.txb_lastname = new System.Windows.Forms.TextBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.txb_license = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_license = new System.Windows.Forms.Label();
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.txb_pilotname = new System.Windows.Forms.TextBox();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_piloto)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_piloto);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1090, 426);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // dg_piloto
            // 
            this.dg_piloto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_piloto.Location = new System.Drawing.Point(13, 16);
            this.dg_piloto.Name = "dg_piloto";
            this.dg_piloto.Size = new System.Drawing.Size(1066, 401);
            this.dg_piloto.TabIndex = 0;
            this.dg_piloto.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_piloto_UserDeletingRow);
            this.dg_piloto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_piloto_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Location = new System.Drawing.Point(993, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 169);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Image = global::SkyDiveCuautla.Properties.Resources.Exit;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(6, 129);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(97, 34);
            this.btn_cerrar.TabIndex = 26;
            this.btn_cerrar.Text = "Exit";
            this.btn_cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Image = global::SkyDiveCuautla.Properties.Resources.clean;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(6, 77);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(97, 32);
            this.btn_limpiar.TabIndex = 25;
            this.btn_limpiar.Text = "Clear";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Image = global::SkyDiveCuautla.Properties.Resources.save;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(6, 23);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(97, 32);
            this.btn_guardar.TabIndex = 24;
            this.btn_guardar.Text = "Save";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_code);
            this.groupBox1.Controls.Add(this.lbl_secondlastname);
            this.groupBox1.Controls.Add(this.txb_secondlastname);
            this.groupBox1.Controls.Add(this.lbl_paterno);
            this.groupBox1.Controls.Add(this.txb_lastname);
            this.groupBox1.Controls.Add(this.chk_active);
            this.groupBox1.Controls.Add(this.txb_license);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lbl_license);
            this.groupBox1.Controls.Add(this.lbl_firstname);
            this.groupBox1.Controls.Add(this.txb_pilotname);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 169);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // txb_code
            // 
            this.txb_code.Enabled = false;
            this.txb_code.Location = new System.Drawing.Point(295, 38);
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(146, 20);
            this.txb_code.TabIndex = 51;
            // 
            // lbl_secondlastname
            // 
            this.lbl_secondlastname.AutoSize = true;
            this.lbl_secondlastname.Location = new System.Drawing.Point(464, 42);
            this.lbl_secondlastname.Name = "lbl_secondlastname";
            this.lbl_secondlastname.Size = new System.Drawing.Size(122, 13);
            this.lbl_secondlastname.TabIndex = 50;
            this.lbl_secondlastname.Text = "SECOND LAST NAME: ";
            // 
            // txb_secondlastname
            // 
            this.txb_secondlastname.Location = new System.Drawing.Point(592, 39);
            this.txb_secondlastname.Name = "txb_secondlastname";
            this.txb_secondlastname.Size = new System.Drawing.Size(362, 20);
            this.txb_secondlastname.TabIndex = 3;
            // 
            // lbl_paterno
            // 
            this.lbl_paterno.AutoSize = true;
            this.lbl_paterno.Location = new System.Drawing.Point(169, 118);
            this.lbl_paterno.Name = "lbl_paterno";
            this.lbl_paterno.Size = new System.Drawing.Size(74, 13);
            this.lbl_paterno.TabIndex = 48;
            this.lbl_paterno.Text = "LAST NAME: ";
            // 
            // txb_lastname
            // 
            this.txb_lastname.Location = new System.Drawing.Point(249, 115);
            this.txb_lastname.Name = "txb_lastname";
            this.txb_lastname.Size = new System.Drawing.Size(228, 20);
            this.txb_lastname.TabIndex = 2;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_active.Location = new System.Drawing.Point(187, 41);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(73, 17);
            this.chk_active.TabIndex = 46;
            this.chk_active.Text = "ACTIVE : ";
            this.chk_active.UseVisualStyleBackColor = true;
            this.chk_active.CheckedChanged += new System.EventHandler(this.chk_active_CheckedChanged);
            // 
            // txb_license
            // 
            this.txb_license.Location = new System.Drawing.Point(592, 77);
            this.txb_license.Multiline = true;
            this.txb_license.Name = "txb_license";
            this.txb_license.Size = new System.Drawing.Size(362, 58);
            this.txb_license.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 112);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_license
            // 
            this.lbl_license.AutoSize = true;
            this.lbl_license.Location = new System.Drawing.Point(531, 87);
            this.lbl_license.Name = "lbl_license";
            this.lbl_license.Size = new System.Drawing.Size(55, 13);
            this.lbl_license.TabIndex = 40;
            this.lbl_license.Text = "LICENSE:";
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Location = new System.Drawing.Point(165, 83);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(78, 13);
            this.lbl_firstname.TabIndex = 36;
            this.lbl_firstname.Text = "FIRST NAME: ";
            // 
            // txb_pilotname
            // 
            this.txb_pilotname.Location = new System.Drawing.Point(249, 80);
            this.txb_pilotname.Name = "txb_pilotname";
            this.txb_pilotname.Size = new System.Drawing.Size(228, 20);
            this.txb_pilotname.TabIndex = 1;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(329, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(551, 45);
            this.lbl_titulo.TabIndex = 31;
            this.lbl_titulo.Text = "PILOT\'S ADMINISTRATION";
            // 
            // Frm_Pilots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1456, 653);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Pilots";
            this.Text = "Pilots";
            this.Load += new System.EventHandler(this.Frm_Pilots_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_piloto)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_piloto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_license;
        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.TextBox txb_pilotname;
        private System.Windows.Forms.TextBox txb_license;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Label lbl_secondlastname;
        private System.Windows.Forms.TextBox txb_secondlastname;
        private System.Windows.Forms.Label lbl_paterno;
        private System.Windows.Forms.TextBox txb_lastname;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.Label lbl_titulo;
    }
}