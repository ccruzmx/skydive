namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Preferences
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
            this.dg_plane = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.txb_short = new System.Windows.Forms.TextBox();
            this.lbl_code = new System.Windows.Forms.Label();
            this.lbl_short = new System.Windows.Forms.Label();
            this.lbl_type = new System.Windows.Forms.Label();
            this.lbl_long = new System.Windows.Forms.Label();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.txb_altitud = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_type = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_plane)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_plane);
            this.groupBox2.Location = new System.Drawing.Point(3, 330);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1660, 490);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            // 
            // dg_plane
            // 
            this.dg_plane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_plane.Location = new System.Drawing.Point(7, 16);
            this.dg_plane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dg_plane.Name = "dg_plane";
            this.dg_plane.Size = new System.Drawing.Size(1644, 465);
            this.dg_plane.TabIndex = 0;
            this.dg_plane.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_plane_CellContentClick);
            this.dg_plane.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dg_plane_UserDeletedRow);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Location = new System.Drawing.Point(1519, 121);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(144, 208);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Image = global::SkyDiveCuautla.Properties.Resources.Exit;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(8, 159);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(128, 42);
            this.btn_cerrar.TabIndex = 8;
            this.btn_cerrar.Text = "Exit";
            this.btn_cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Image = global::SkyDiveCuautla.Properties.Resources.clean;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(8, 90);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(128, 38);
            this.btn_limpiar.TabIndex = 7;
            this.btn_limpiar.Text = "Clear";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Image = global::SkyDiveCuautla.Properties.Resources.save;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(8, 26);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(128, 38);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "Save";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(647, 28);
            this.lbl_titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(389, 57);
            this.lbl_titulo.TabIndex = 36;
            this.lbl_titulo.Text = "PREFERENCES";
            // 
            // txb_code
            // 
            this.txb_code.Location = new System.Drawing.Point(275, 43);
            this.txb_code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(244, 22);
            this.txb_code.TabIndex = 1;
            // 
            // txb_short
            // 
            this.txb_short.Location = new System.Drawing.Point(275, 150);
            this.txb_short.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_short.Name = "txb_short";
            this.txb_short.Size = new System.Drawing.Size(187, 22);
            this.txb_short.TabIndex = 3;
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_code.Location = new System.Drawing.Point(184, 47);
            this.lbl_code.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(56, 17);
            this.lbl_code.TabIndex = 34;
            this.lbl_code.Text = "CODE:";
            // 
            // lbl_short
            // 
            this.lbl_short.AutoSize = true;
            this.lbl_short.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_short.Location = new System.Drawing.Point(68, 154);
            this.lbl_short.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_short.Name = "lbl_short";
            this.lbl_short.Size = new System.Drawing.Size(180, 17);
            this.lbl_short.TabIndex = 35;
            this.lbl_short.Text = "SHORT DESCRIPTION: ";
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_type.Location = new System.Drawing.Point(584, 46);
            this.lbl_type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(58, 17);
            this.lbl_type.TabIndex = 39;
            this.lbl_type.Text = "TYPE :";
            // 
            // lbl_long
            // 
            this.lbl_long.AutoSize = true;
            this.lbl_long.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_long.Location = new System.Drawing.Point(488, 154);
            this.lbl_long.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_long.Name = "lbl_long";
            this.lbl_long.Size = new System.Drawing.Size(165, 17);
            this.lbl_long.TabIndex = 41;
            this.lbl_long.Text = "LONG DESCRIPTION:";
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_active.Location = new System.Drawing.Point(1288, 46);
            this.chk_active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(90, 21);
            this.chk_active.TabIndex = 5;
            this.chk_active.Text = "ACTIVE : ";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // txb_altitud
            // 
            this.txb_altitud.Location = new System.Drawing.Point(680, 150);
            this.txb_altitud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_altitud.Name = "txb_altitud";
            this.txb_altitud.Size = new System.Drawing.Size(795, 22);
            this.txb_altitud.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_type);
            this.groupBox1.Controls.Add(this.txb_altitud);
            this.groupBox1.Controls.Add(this.chk_active);
            this.groupBox1.Controls.Add(this.lbl_long);
            this.groupBox1.Controls.Add(this.lbl_type);
            this.groupBox1.Controls.Add(this.lbl_short);
            this.groupBox1.Controls.Add(this.lbl_code);
            this.groupBox1.Controls.Add(this.txb_short);
            this.groupBox1.Controls.Add(this.txb_code);
            this.groupBox1.Location = new System.Drawing.Point(3, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1507, 208);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // cmb_type
            // 
            this.cmb_type.Location = new System.Drawing.Point(680, 47);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(361, 22);
            this.cmb_type.TabIndex = 2;
            // 
            // Frm_Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1677, 831);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_titulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Preferences";
            this.Text = "Frm_Preferences";
            this.Load += new System.EventHandler(this.Frm_Preferences_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_plane)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_plane;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.TextBox txb_short;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.Label lbl_short;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_long;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.TextBox txb_altitud;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox cmb_type;
    }
}