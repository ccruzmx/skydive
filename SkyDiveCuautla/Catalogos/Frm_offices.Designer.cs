namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_offices
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
            this.dg_office = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_state = new System.Windows.Forms.Label();
            this.Cmb_State = new System.Windows.Forms.ComboBox();
            this.cmb_responsable = new System.Windows.Forms.ComboBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_geographical = new System.Windows.Forms.Label();
            this.lbl_responsable = new System.Windows.Forms.Label();
            this.lbl_officename = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.txb_geographical = new System.Windows.Forms.TextBox();
            this.txb_officename = new System.Windows.Forms.TextBox();
            this.btn_destroy = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_office)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(404, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(793, 45);
            this.lbl_titulo.TabIndex = 29;
            this.lbl_titulo.Text = "OFFICE & DROPZONE ADMINISTRATION";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_office);
            this.groupBox2.Location = new System.Drawing.Point(21, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1207, 326);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // dg_office
            // 
            this.dg_office.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_office.Location = new System.Drawing.Point(6, 10);
            this.dg_office.Name = "dg_office";
            this.dg_office.Size = new System.Drawing.Size(1195, 312);
            this.dg_office.TabIndex = 0;
            this.dg_office.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_office_CellContentClick_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Controls.Add(this.btn_buscar);
            this.groupBox3.Location = new System.Drawing.Point(1119, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 269);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Image = global::SkyDiveCuautla.Properties.Resources.Exit;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(6, 184);
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
            this.btn_limpiar.Location = new System.Drawing.Point(6, 122);
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
            this.btn_guardar.Location = new System.Drawing.Point(6, 62);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_state);
            this.groupBox1.Controls.Add(this.Cmb_State);
            this.groupBox1.Controls.Add(this.cmb_responsable);
            this.groupBox1.Controls.Add(this.lbl_status);
            this.groupBox1.Controls.Add(this.lbl_geographical);
            this.groupBox1.Controls.Add(this.lbl_responsable);
            this.groupBox1.Controls.Add(this.lbl_officename);
            this.groupBox1.Controls.Add(this.cmb_status);
            this.groupBox1.Controls.Add(this.txb_geographical);
            this.groupBox1.Controls.Add(this.txb_officename);
            this.groupBox1.Location = new System.Drawing.Point(21, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 269);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // Lbl_state
            // 
            this.Lbl_state.AutoSize = true;
            this.Lbl_state.Location = new System.Drawing.Point(25, 172);
            this.Lbl_state.Name = "Lbl_state";
            this.Lbl_state.Size = new System.Drawing.Size(45, 13);
            this.Lbl_state.TabIndex = 43;
            this.Lbl_state.Text = "STATE:";
            // 
            // Cmb_State
            // 
            this.Cmb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_State.FormattingEnabled = true;
            this.Cmb_State.Location = new System.Drawing.Point(123, 169);
            this.Cmb_State.Name = "Cmb_State";
            this.Cmb_State.Size = new System.Drawing.Size(507, 21);
            this.Cmb_State.TabIndex = 4;
            // 
            // cmb_responsable
            // 
            this.cmb_responsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_responsable.FormattingEnabled = true;
            this.cmb_responsable.Location = new System.Drawing.Point(123, 70);
            this.cmb_responsable.Name = "cmb_responsable";
            this.cmb_responsable.Size = new System.Drawing.Size(507, 21);
            this.cmb_responsable.TabIndex = 2;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(25, 222);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(53, 13);
            this.lbl_status.TabIndex = 41;
            this.lbl_status.Text = "STATUS:";
            // 
            // lbl_geographical
            // 
            this.lbl_geographical.AutoSize = true;
            this.lbl_geographical.Location = new System.Drawing.Point(25, 123);
            this.lbl_geographical.Name = "lbl_geographical";
            this.lbl_geographical.Size = new System.Drawing.Size(88, 13);
            this.lbl_geographical.TabIndex = 37;
            this.lbl_geographical.Text = "COORDINATES:";
            // 
            // lbl_responsable
            // 
            this.lbl_responsable.AutoSize = true;
            this.lbl_responsable.Location = new System.Drawing.Point(25, 73);
            this.lbl_responsable.Name = "lbl_responsable";
            this.lbl_responsable.Size = new System.Drawing.Size(92, 13);
            this.lbl_responsable.TabIndex = 36;
            this.lbl_responsable.Text = "RESPONSABLE: ";
            // 
            // lbl_officename
            // 
            this.lbl_officename.AutoSize = true;
            this.lbl_officename.Location = new System.Drawing.Point(25, 29);
            this.lbl_officename.Name = "lbl_officename";
            this.lbl_officename.Size = new System.Drawing.Size(81, 13);
            this.lbl_officename.TabIndex = 34;
            this.lbl_officename.Text = "OFFICE NAME:";
            // 
            // cmb_status
            // 
            this.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Location = new System.Drawing.Point(123, 219);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(507, 21);
            this.cmb_status.TabIndex = 5;
            // 
            // txb_geographical
            // 
            this.txb_geographical.Location = new System.Drawing.Point(123, 120);
            this.txb_geographical.Name = "txb_geographical";
            this.txb_geographical.Size = new System.Drawing.Size(507, 20);
            this.txb_geographical.TabIndex = 3;
            // 
            // txb_officename
            // 
            this.txb_officename.Location = new System.Drawing.Point(123, 22);
            this.txb_officename.Name = "txb_officename";
            this.txb_officename.Size = new System.Drawing.Size(507, 20);
            this.txb_officename.TabIndex = 1;
            // 
            // btn_destroy
            // 
            this.btn_destroy.Location = new System.Drawing.Point(1268, 635);
            this.btn_destroy.Name = "btn_destroy";
            this.btn_destroy.Size = new System.Drawing.Size(75, 23);
            this.btn_destroy.TabIndex = 34;
            this.btn_destroy.Text = "BorrarSistema";
            this.btn_destroy.UseVisualStyleBackColor = true;
            // 
            // Frm_offices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1365, 669);
            this.Controls.Add(this.btn_destroy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_titulo);
            this.Name = "Frm_offices";
            this.Text = "Office Administration";
            this.Load += new System.EventHandler(this.Frm_offices_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_office)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_office;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_geographical;
        private System.Windows.Forms.Label lbl_responsable;
        private System.Windows.Forms.Label lbl_officename;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.TextBox txb_geographical;
        private System.Windows.Forms.TextBox txb_officename;
        private System.Windows.Forms.ComboBox cmb_responsable;
        private System.Windows.Forms.Button btn_destroy;
        private System.Windows.Forms.Label Lbl_state;
        private System.Windows.Forms.ComboBox Cmb_State;
    }
}