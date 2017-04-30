namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Users
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
            this.btn_destroy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_confirmpwd = new System.Windows.Forms.Label();
            this.txb_pwdconfirm = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_office = new System.Windows.Forms.Label();
            this.lbl_userrole = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_lastnames = new System.Windows.Forms.Label();
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.cmb_office = new System.Windows.Forms.ComboBox();
            this.cmb_role = new System.Windows.Forms.ComboBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.txb_lastname2 = new System.Windows.Forms.TextBox();
            this.txb_lastname1 = new System.Windows.Forms.TextBox();
            this.txb_firstname = new System.Windows.Forms.TextBox();
            this.txb_pwd = new System.Windows.Forms.TextBox();
            this.txb_user = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_usuarios = new System.Windows.Forms.DataGridView();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.chb_activos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_destroy
            // 
            this.btn_destroy.Location = new System.Drawing.Point(1268, 630);
            this.btn_destroy.Name = "btn_destroy";
            this.btn_destroy.Size = new System.Drawing.Size(75, 23);
            this.btn_destroy.TabIndex = 0;
            this.btn_destroy.Text = "BorrarSistema";
            this.btn_destroy.UseVisualStyleBackColor = true;
            this.btn_destroy.Click += new System.EventHandler(this.btn_destroy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lbl_confirmpwd);
            this.groupBox1.Controls.Add(this.txb_pwdconfirm);
            this.groupBox1.Controls.Add(this.lbl_status);
            this.groupBox1.Controls.Add(this.lbl_office);
            this.groupBox1.Controls.Add(this.lbl_userrole);
            this.groupBox1.Controls.Add(this.lbl_email);
            this.groupBox1.Controls.Add(this.lbl_lastnames);
            this.groupBox1.Controls.Add(this.lbl_firstname);
            this.groupBox1.Controls.Add(this.lbl_password);
            this.groupBox1.Controls.Add(this.lbl_user);
            this.groupBox1.Controls.Add(this.cmb_status);
            this.groupBox1.Controls.Add(this.cmb_office);
            this.groupBox1.Controls.Add(this.cmb_role);
            this.groupBox1.Controls.Add(this.txb_email);
            this.groupBox1.Controls.Add(this.txb_lastname2);
            this.groupBox1.Controls.Add(this.txb_lastname1);
            this.groupBox1.Controls.Add(this.txb_firstname);
            this.groupBox1.Controls.Add(this.txb_pwd);
            this.groupBox1.Controls.Add(this.txb_user);
            this.groupBox1.Location = new System.Drawing.Point(5, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1173, 169);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 112);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_confirmpwd
            // 
            this.lbl_confirmpwd.AutoSize = true;
            this.lbl_confirmpwd.Location = new System.Drawing.Point(132, 134);
            this.lbl_confirmpwd.Name = "lbl_confirmpwd";
            this.lbl_confirmpwd.Size = new System.Drawing.Size(62, 13);
            this.lbl_confirmpwd.TabIndex = 43;
            this.lbl_confirmpwd.Text = "CONFIRM: ";
            // 
            // txb_pwdconfirm
            // 
            this.txb_pwdconfirm.Location = new System.Drawing.Point(218, 127);
            this.txb_pwdconfirm.Name = "txb_pwdconfirm";
            this.txb_pwdconfirm.PasswordChar = '*';
            this.txb_pwdconfirm.Size = new System.Drawing.Size(149, 20);
            this.txb_pwdconfirm.TabIndex = 34;
            this.txb_pwdconfirm.LostFocus += new System.EventHandler(this.txb_pwdconfirm_LostFocus);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(376, 130);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(53, 13);
            this.lbl_status.TabIndex = 41;
            this.lbl_status.Text = "STATUS:";
            // 
            // lbl_office
            // 
            this.lbl_office.AutoSize = true;
            this.lbl_office.Location = new System.Drawing.Point(683, 122);
            this.lbl_office.Name = "lbl_office";
            this.lbl_office.Size = new System.Drawing.Size(47, 13);
            this.lbl_office.TabIndex = 40;
            this.lbl_office.Text = "OFFICE:";
            // 
            // lbl_userrole
            // 
            this.lbl_userrole.AutoSize = true;
            this.lbl_userrole.Location = new System.Drawing.Point(683, 82);
            this.lbl_userrole.Name = "lbl_userrole";
            this.lbl_userrole.Size = new System.Drawing.Size(75, 13);
            this.lbl_userrole.TabIndex = 39;
            this.lbl_userrole.Text = "USER ROLE :";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(376, 87);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(45, 13);
            this.lbl_email.TabIndex = 38;
            this.lbl_email.Text = "E-MAIL:";
            // 
            // lbl_lastnames
            // 
            this.lbl_lastnames.AutoSize = true;
            this.lbl_lastnames.Location = new System.Drawing.Point(683, 42);
            this.lbl_lastnames.Name = "lbl_lastnames";
            this.lbl_lastnames.Size = new System.Drawing.Size(78, 13);
            this.lbl_lastnames.TabIndex = 37;
            this.lbl_lastnames.Text = "LAST NAMES:";
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Location = new System.Drawing.Point(376, 42);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(78, 13);
            this.lbl_firstname.TabIndex = 36;
            this.lbl_firstname.Text = "FIRST NAME: ";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(132, 91);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(76, 13);
            this.lbl_password.TabIndex = 35;
            this.lbl_password.Text = "PASSWORD: ";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(132, 46);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(40, 13);
            this.lbl_user.TabIndex = 34;
            this.lbl_user.Text = "USER:";
            // 
            // cmb_status
            // 
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Location = new System.Drawing.Point(460, 122);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(215, 21);
            this.cmb_status.TabIndex = 31;
            // 
            // cmb_office
            // 
            this.cmb_office.FormattingEnabled = true;
            this.cmb_office.Location = new System.Drawing.Point(767, 119);
            this.cmb_office.Name = "cmb_office";
            this.cmb_office.Size = new System.Drawing.Size(387, 21);
            this.cmb_office.TabIndex = 32;
            // 
            // cmb_role
            // 
            this.cmb_role.FormattingEnabled = true;
            this.cmb_role.Location = new System.Drawing.Point(767, 79);
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Size = new System.Drawing.Size(387, 21);
            this.cmb_role.TabIndex = 30;
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(460, 80);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(215, 20);
            this.txb_email.TabIndex = 29;
            this.txb_email.LostFocus += new System.EventHandler(this.txb_email_LostFocus);
            // 
            // txb_lastname2
            // 
            this.txb_lastname2.Location = new System.Drawing.Point(965, 39);
            this.txb_lastname2.Name = "txb_lastname2";
            this.txb_lastname2.Size = new System.Drawing.Size(189, 20);
            this.txb_lastname2.TabIndex = 28;
            // 
            // txb_lastname1
            // 
            this.txb_lastname1.Location = new System.Drawing.Point(767, 39);
            this.txb_lastname1.Name = "txb_lastname1";
            this.txb_lastname1.Size = new System.Drawing.Size(176, 20);
            this.txb_lastname1.TabIndex = 27;
            // 
            // txb_firstname
            // 
            this.txb_firstname.Location = new System.Drawing.Point(460, 35);
            this.txb_firstname.Name = "txb_firstname";
            this.txb_firstname.Size = new System.Drawing.Size(215, 20);
            this.txb_firstname.TabIndex = 26;
            // 
            // txb_pwd
            // 
            this.txb_pwd.Location = new System.Drawing.Point(218, 84);
            this.txb_pwd.Name = "txb_pwd";
            this.txb_pwd.PasswordChar = '*';
            this.txb_pwd.Size = new System.Drawing.Size(149, 20);
            this.txb_pwd.TabIndex = 33;
            this.txb_pwd.TextChanged += new System.EventHandler(this.txb_pwd_TextChanged);
            // 
            // txb_user
            // 
            this.txb_user.Location = new System.Drawing.Point(218, 39);
            this.txb_user.Name = "txb_user";
            this.txb_user.Size = new System.Drawing.Size(149, 20);
            this.txb_user.TabIndex = 25;
            this.txb_user.LostFocus += new System.EventHandler(this.txb_user_LostFocus);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chb_activos);
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Controls.Add(this.btn_buscar);
            this.groupBox3.Location = new System.Drawing.Point(1183, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 209);
            this.groupBox3.TabIndex = 26;
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
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click_1);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Image = global::SkyDiveCuautla.Properties.Resources.clean;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(6, 87);
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
            this.btn_guardar.Location = new System.Drawing.Point(6, 48);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(97, 32);
            this.btn_guardar.TabIndex = 24;
            this.btn_guardar.Text = "Save";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Image = global::SkyDiveCuautla.Properties.Resources.find;
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.Location = new System.Drawing.Point(6, 11);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(97, 31);
            this.btn_buscar.TabIndex = 23;
            this.btn_buscar.Text = "Search";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dg_usuarios);
            this.groupBox2.Location = new System.Drawing.Point(5, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1288, 426);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // dg_usuarios
            // 
            this.dg_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_usuarios.Location = new System.Drawing.Point(18, 19);
            this.dg_usuarios.Name = "dg_usuarios";
            this.dg_usuarios.Size = new System.Drawing.Size(1264, 401);
            this.dg_usuarios.TabIndex = 0;
            this.dg_usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_usuarios_CellContentClick);
            this.dg_usuarios.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_usuarios_UserDeletingRow);
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(421, 4);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(521, 45);
            this.lbl_titulo.TabIndex = 28;
            this.lbl_titulo.Text = "USERS ADMINISTRATION";
            // 
            // chb_activos
            // 
            this.chb_activos.AutoSize = true;
            this.chb_activos.Location = new System.Drawing.Point(6, 174);
            this.chb_activos.Name = "chb_activos";
            this.chb_activos.Size = new System.Drawing.Size(89, 17);
            this.chb_activos.TabIndex = 0;
            this.chb_activos.Text = "Actives users";
            this.chb_activos.UseVisualStyleBackColor = true;
            this.chb_activos.CheckedChanged += new System.EventHandler(this.chb_activos_CheckedChanged);
            // 
            // Frm_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1301, 665);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_destroy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Frm_Users";
            this.Text = "System users Administration";
            this.Load += new System.EventHandler(this.Frm_Users_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_destroy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_confirmpwd;
        private System.Windows.Forms.TextBox txb_pwdconfirm;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_office;
        private System.Windows.Forms.Label lbl_userrole;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_lastnames;
        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.ComboBox cmb_office;
        private System.Windows.Forms.ComboBox cmb_role;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.TextBox txb_lastname2;
        private System.Windows.Forms.TextBox txb_lastname1;
        private System.Windows.Forms.TextBox txb_firstname;
        private System.Windows.Forms.TextBox txb_pwd;
        private System.Windows.Forms.TextBox txb_user;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_usuarios;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.CheckBox chb_activos;
    }
}