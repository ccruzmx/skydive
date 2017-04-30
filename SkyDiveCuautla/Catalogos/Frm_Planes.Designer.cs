namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Planes
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
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_plane = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_codey = new System.Windows.Forms.TextBox();
            this.lbl_codey = new System.Windows.Forms.Label();
            this.txb_altitud = new System.Windows.Forms.TextBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.lbl_altitud = new System.Windows.Forms.Label();
            this.lbl_pilot = new System.Windows.Forms.Label();
            this.lbl_capacity = new System.Windows.Forms.Label();
            this.lbl_aircraift = new System.Windows.Forms.Label();
            this.lbl_code = new System.Windows.Forms.Label();
            this.cmb_pilot = new System.Windows.Forms.ComboBox();
            this.txb_capacity = new System.Windows.Forms.TextBox();
            this.txb_aircraft = new System.Windows.Forms.TextBox();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_plane)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(452, 11);
            this.lbl_titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(686, 57);
            this.lbl_titulo.TabIndex = 30;
            this.lbl_titulo.Text = "PLANE\'s ADMINISTRATION";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_plane);
            this.groupBox2.Location = new System.Drawing.Point(9, 285);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1660, 490);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // dg_plane
            // 
            this.dg_plane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_plane.Location = new System.Drawing.Point(7, 16);
            this.dg_plane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dg_plane.Name = "dg_plane";
            this.dg_plane.Size = new System.Drawing.Size(1645, 466);
            this.dg_plane.TabIndex = 0;
            this.dg_plane.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_plane_UserDeletingRow);
            this.dg_plane.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_plane_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Location = new System.Drawing.Point(1524, 76);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(145, 208);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Image = global::SkyDiveCuautla.Properties.Resources.Exit;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(8, 159);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(129, 42);
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
            this.btn_limpiar.Location = new System.Drawing.Point(8, 90);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(129, 39);
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
            this.btn_guardar.Location = new System.Drawing.Point(8, 27);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(129, 39);
            this.btn_guardar.TabIndex = 24;
            this.btn_guardar.Text = "Save";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_codey);
            this.groupBox1.Controls.Add(this.lbl_codey);
            this.groupBox1.Controls.Add(this.txb_altitud);
            this.groupBox1.Controls.Add(this.chk_active);
            this.groupBox1.Controls.Add(this.lbl_altitud);
            this.groupBox1.Controls.Add(this.lbl_pilot);
            this.groupBox1.Controls.Add(this.lbl_capacity);
            this.groupBox1.Controls.Add(this.lbl_aircraift);
            this.groupBox1.Controls.Add(this.lbl_code);
            this.groupBox1.Controls.Add(this.cmb_pilot);
            this.groupBox1.Controls.Add(this.txb_capacity);
            this.groupBox1.Controls.Add(this.txb_aircraft);
            this.groupBox1.Controls.Add(this.txb_code);
            this.groupBox1.Location = new System.Drawing.Point(9, 76);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1507, 208);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // txb_codey
            // 
            this.txb_codey.Location = new System.Drawing.Point(680, 154);
            this.txb_codey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_codey.Name = "txb_codey";
            this.txb_codey.Size = new System.Drawing.Size(221, 22);
            this.txb_codey.TabIndex = 46;
            // 
            // lbl_codey
            // 
            this.lbl_codey.AutoSize = true;
            this.lbl_codey.Location = new System.Drawing.Point(584, 155);
            this.lbl_codey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_codey.Name = "lbl_codey";
            this.lbl_codey.Size = new System.Drawing.Size(60, 17);
            this.lbl_codey.TabIndex = 45;
            this.lbl_codey.Text = "CODEY:";
            // 
            // txb_altitud
            // 
            this.txb_altitud.Location = new System.Drawing.Point(680, 98);
            this.txb_altitud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_altitud.Name = "txb_altitud";
            this.txb_altitud.Size = new System.Drawing.Size(221, 22);
            this.txb_altitud.TabIndex = 4;
            this.txb_altitud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_altitud_KeyPress);
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_active.Location = new System.Drawing.Point(95, 46);
            this.chk_active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(90, 21);
            this.chk_active.TabIndex = 44;
            this.chk_active.Text = "ACTIVE : ";
            this.chk_active.UseVisualStyleBackColor = true;
            this.chk_active.CheckedChanged += new System.EventHandler(this.chk_active_CheckedChanged);
            // 
            // lbl_altitud
            // 
            this.lbl_altitud.AutoSize = true;
            this.lbl_altitud.Location = new System.Drawing.Point(573, 102);
            this.lbl_altitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_altitud.Name = "lbl_altitud";
            this.lbl_altitud.Size = new System.Drawing.Size(70, 17);
            this.lbl_altitud.TabIndex = 41;
            this.lbl_altitud.Text = "ALTITUD:";
            // 
            // lbl_pilot
            // 
            this.lbl_pilot.AutoSize = true;
            this.lbl_pilot.Location = new System.Drawing.Point(588, 47);
            this.lbl_pilot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pilot.Name = "lbl_pilot";
            this.lbl_pilot.Size = new System.Drawing.Size(56, 17);
            this.lbl_pilot.TabIndex = 39;
            this.lbl_pilot.Text = "PILOT :";
            // 
            // lbl_capacity
            // 
            this.lbl_capacity.AutoSize = true;
            this.lbl_capacity.Location = new System.Drawing.Point(180, 158);
            this.lbl_capacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_capacity.Name = "lbl_capacity";
            this.lbl_capacity.Size = new System.Drawing.Size(82, 17);
            this.lbl_capacity.TabIndex = 37;
            this.lbl_capacity.Text = "CAPACITY :";
            // 
            // lbl_aircraift
            // 
            this.lbl_aircraift.AutoSize = true;
            this.lbl_aircraift.Location = new System.Drawing.Point(69, 102);
            this.lbl_aircraift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_aircraift.Name = "lbl_aircraift";
            this.lbl_aircraift.Size = new System.Drawing.Size(194, 17);
            this.lbl_aircraift.TabIndex = 35;
            this.lbl_aircraift.Text = "AIR CRAFT REGISTRATION: ";
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Location = new System.Drawing.Point(213, 20);
            this.lbl_code.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(51, 17);
            this.lbl_code.TabIndex = 34;
            this.lbl_code.Text = "CODE:";
            this.lbl_code.Visible = false;
            // 
            // cmb_pilot
            // 
            this.cmb_pilot.FormattingEnabled = true;
            this.cmb_pilot.Location = new System.Drawing.Point(680, 43);
            this.cmb_pilot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_pilot.Name = "cmb_pilot";
            this.cmb_pilot.Size = new System.Drawing.Size(385, 24);
            this.cmb_pilot.TabIndex = 3;
            // 
            // txb_capacity
            // 
            this.txb_capacity.Location = new System.Drawing.Point(275, 151);
            this.txb_capacity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_capacity.Name = "txb_capacity";
            this.txb_capacity.Size = new System.Drawing.Size(91, 22);
            this.txb_capacity.TabIndex = 2;
            this.txb_capacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_capacity_KeyPress);
            // 
            // txb_aircraft
            // 
            this.txb_aircraft.Location = new System.Drawing.Point(275, 98);
            this.txb_aircraft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_aircraft.Name = "txb_aircraft";
            this.txb_aircraft.Size = new System.Drawing.Size(187, 22);
            this.txb_aircraft.TabIndex = 1;
            // 
            // txb_code
            // 
            this.txb_code.Enabled = false;
            this.txb_code.Location = new System.Drawing.Point(217, 43);
            this.txb_code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(244, 22);
            this.txb_code.TabIndex = 25;
            // 
            // Frm_Planes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1805, 786);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_titulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Planes";
            this.Text = "Planes";
            this.Load += new System.EventHandler(this.Frm_Planes_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_plane)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_plane;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_altitud;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Label lbl_altitud;
        private System.Windows.Forms.Label lbl_pilot;
        private System.Windows.Forms.Label lbl_capacity;
        private System.Windows.Forms.Label lbl_aircraift;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.ComboBox cmb_pilot;
        private System.Windows.Forms.TextBox txb_capacity;
        private System.Windows.Forms.TextBox txb_aircraft;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.TextBox txb_codey;
        private System.Windows.Forms.Label lbl_codey;
    }
}