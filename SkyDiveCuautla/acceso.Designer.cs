namespace SkyDiveCuautla
{
    partial class acceso
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(acceso));
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.txb_usuario = new System.Windows.Forms.TextBox();
            this.txb_contraseña = new System.Windows.Forms.TextBox();
            this.btn_acceso = new System.Windows.Forms.Button();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lblerrorlogin = new System.Windows.Forms.Label();
            this.btn_recupera = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.SteelBlue;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(24, 12);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(311, 69);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            // 
            // txb_usuario
            // 
            this.txb_usuario.Location = new System.Drawing.Point(179, 116);
            this.txb_usuario.Name = "txb_usuario";
            this.txb_usuario.Size = new System.Drawing.Size(148, 20);
            this.txb_usuario.TabIndex = 1;
            this.txb_usuario.TextChanged += new System.EventHandler(this.txb_usuario_TextChanged);
            // 
            // txb_contraseña
            // 
            this.txb_contraseña.Location = new System.Drawing.Point(179, 160);
            this.txb_contraseña.Name = "txb_contraseña";
            this.txb_contraseña.Size = new System.Drawing.Size(148, 20);
            this.txb_contraseña.TabIndex = 2;
            this.txb_contraseña.UseSystemPasswordChar = true;
            // 
            // btn_acceso
            // 
            this.btn_acceso.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_acceso.Location = new System.Drawing.Point(371, 126);
            this.btn_acceso.Name = "btn_acceso";
            this.btn_acceso.Size = new System.Drawing.Size(82, 45);
            this.btn_acceso.TabIndex = 3;
            this.btn_acceso.Text = " Ingresar";
            this.btn_acceso.UseVisualStyleBackColor = true;
            this.btn_acceso.Click += new System.EventHandler(this.btn_acceso_Click);
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuario.ForeColor = System.Drawing.Color.White;
            this.lbl_usuario.Location = new System.Drawing.Point(53, 117);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(79, 19);
            this.lbl_usuario.TabIndex = 4;
            this.lbl_usuario.Text = "USUARIO:";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.ForeColor = System.Drawing.Color.White;
            this.lbl_password.Location = new System.Drawing.Point(23, 161);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(109, 19);
            this.lbl_password.TabIndex = 5;
            this.lbl_password.Text = "CONTRASEÑA:";
            // 
            // lblerrorlogin
            // 
            this.lblerrorlogin.AutoEllipsis = true;
            this.lblerrorlogin.AutoSize = true;
            this.lblerrorlogin.ForeColor = System.Drawing.Color.Gold;
            this.lblerrorlogin.Location = new System.Drawing.Point(12, 213);
            this.lblerrorlogin.Name = "lblerrorlogin";
            this.lblerrorlogin.Size = new System.Drawing.Size(86, 13);
            this.lblerrorlogin.TabIndex = 6;
            this.lblerrorlogin.Text = "Mensaje de error";
            this.lblerrorlogin.Visible = false;
            // 
            // btn_recupera
            // 
            this.btn_recupera.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_recupera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recupera.ForeColor = System.Drawing.Color.LawnGreen;
            this.btn_recupera.Location = new System.Drawing.Point(179, 187);
            this.btn_recupera.Name = "btn_recupera";
            this.btn_recupera.Size = new System.Drawing.Size(147, 23);
            this.btn_recupera.TabIndex = 7;
            this.btn_recupera.Text = "Olvido su contraseña ?";
            this.btn_recupera.UseVisualStyleBackColor = true;
            this.btn_recupera.Visible = false;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_version.Location = new System.Drawing.Point(24, 84);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(141, 17);
            this.lbl_version.TabIndex = 8;
            this.lbl_version.Text = "Versión: 2 Build(139)";
            this.lbl_version.Click += new System.EventHandler(this.lbl_version_Click);
            // 
            // acceso
            // 
            this.AcceptButton = this.btn_acceso;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(477, 235);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btn_recupera);
            this.Controls.Add(this.lblerrorlogin);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.btn_acceso);
            this.Controls.Add(this.txb_contraseña);
            this.Controls.Add(this.txb_usuario);
            this.Controls.Add(this.pb_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "acceso";
            this.Text = "Acceso";
            this.Activated += new System.EventHandler(this.acceso_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acceso_FormClosing);
            this.Load += new System.EventHandler(this.acceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.TextBox txb_usuario;
        private System.Windows.Forms.TextBox txb_contraseña;
        private System.Windows.Forms.Button btn_acceso;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lblerrorlogin;
        private System.Windows.Forms.Button btn_recupera;
        private System.Windows.Forms.Label lbl_version;
    }
}

