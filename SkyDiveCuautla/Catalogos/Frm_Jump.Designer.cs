namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Jump
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_codey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_altitud = new System.Windows.Forms.TextBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.lbl_altitud = new System.Windows.Forms.Label();
            this.lbl_charge_type = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_sequence = new System.Windows.Forms.Label();
            this.lbl_group = new System.Windows.Forms.Label();
            this.lbl_jumptype = new System.Windows.Forms.Label();
            this.lbl_code = new System.Windows.Forms.Label();
            this.cmb_chargetype = new System.Windows.Forms.ComboBox();
            this.txb_description = new System.Windows.Forms.TextBox();
            this.txb_sequence = new System.Windows.Forms.TextBox();
            this.txb_group = new System.Windows.Forms.TextBox();
            this.txb_jumptype = new System.Windows.Forms.TextBox();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_jumptype = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_jumptype)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(423, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(619, 45);
            this.lbl_titulo.TabIndex = 29;
            this.lbl_titulo.Text = "JUMP TYPE ADMINISTRATION";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_codey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_altitud);
            this.groupBox1.Controls.Add(this.chk_active);
            this.groupBox1.Controls.Add(this.lbl_price);
            this.groupBox1.Controls.Add(this.txb_price);
            this.groupBox1.Controls.Add(this.lbl_altitud);
            this.groupBox1.Controls.Add(this.lbl_charge_type);
            this.groupBox1.Controls.Add(this.lbl_description);
            this.groupBox1.Controls.Add(this.lbl_sequence);
            this.groupBox1.Controls.Add(this.lbl_group);
            this.groupBox1.Controls.Add(this.lbl_jumptype);
            this.groupBox1.Controls.Add(this.lbl_code);
            this.groupBox1.Controls.Add(this.cmb_chargetype);
            this.groupBox1.Controls.Add(this.txb_description);
            this.groupBox1.Controls.Add(this.txb_sequence);
            this.groupBox1.Controls.Add(this.txb_group);
            this.groupBox1.Controls.Add(this.txb_jumptype);
            this.groupBox1.Controls.Add(this.txb_code);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1130, 189);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // txb_codey
            // 
            this.txb_codey.Location = new System.Drawing.Point(414, 123);
            this.txb_codey.Name = "txb_codey";
            this.txb_codey.Size = new System.Drawing.Size(167, 20);
            this.txb_codey.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "CODEY:";
            // 
            // txb_altitud
            // 
            this.txb_altitud.Location = new System.Drawing.Point(414, 80);
            this.txb_altitud.Name = "txb_altitud";
            this.txb_altitud.Size = new System.Drawing.Size(167, 20);
            this.txb_altitud.TabIndex = 4;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_active.Location = new System.Drawing.Point(71, 37);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(73, 17);
            this.chk_active.TabIndex = 44;
            this.chk_active.Text = "ACTIVE : ";
            this.chk_active.UseVisualStyleBackColor = true;
            this.chk_active.CheckedChanged += new System.EventHandler(this.chk_active_CheckedChanged);
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(362, 39);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(45, 13);
            this.lbl_price.TabIndex = 43;
            this.lbl_price.Text = "PRICE: ";
            // 
            // txb_price
            // 
            this.txb_price.Location = new System.Drawing.Point(414, 35);
            this.txb_price.Name = "txb_price";
            this.txb_price.Size = new System.Drawing.Size(167, 20);
            this.txb_price.TabIndex = 3;
            this.txb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_price_KeyPress);
            // 
            // lbl_altitud
            // 
            this.lbl_altitud.AutoSize = true;
            this.lbl_altitud.Location = new System.Drawing.Point(351, 83);
            this.lbl_altitud.Name = "lbl_altitud";
            this.lbl_altitud.Size = new System.Drawing.Size(56, 13);
            this.lbl_altitud.TabIndex = 41;
            this.lbl_altitud.Text = "ALTITUD:";
            // 
            // lbl_charge_type
            // 
            this.lbl_charge_type.AutoSize = true;
            this.lbl_charge_type.Location = new System.Drawing.Point(640, 39);
            this.lbl_charge_type.Name = "lbl_charge_type";
            this.lbl_charge_type.Size = new System.Drawing.Size(89, 13);
            this.lbl_charge_type.TabIndex = 39;
            this.lbl_charge_type.Text = "CHARGE TYPÉ :";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(655, 123);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(83, 13);
            this.lbl_description.TabIndex = 38;
            this.lbl_description.Text = "DESCRIPTION:";
            // 
            // lbl_sequence
            // 
            this.lbl_sequence.AutoSize = true;
            this.lbl_sequence.Location = new System.Drawing.Point(52, 126);
            this.lbl_sequence.Name = "lbl_sequence";
            this.lbl_sequence.Size = new System.Drawing.Size(69, 13);
            this.lbl_sequence.TabIndex = 37;
            this.lbl_sequence.Text = "SEQUENCE:";
            // 
            // lbl_group
            // 
            this.lbl_group.AutoSize = true;
            this.lbl_group.Location = new System.Drawing.Point(677, 83);
            this.lbl_group.Name = "lbl_group";
            this.lbl_group.Size = new System.Drawing.Size(52, 13);
            this.lbl_group.TabIndex = 36;
            this.lbl_group.Text = "GROUP: ";
            // 
            // lbl_jumptype
            // 
            this.lbl_jumptype.AutoSize = true;
            this.lbl_jumptype.Location = new System.Drawing.Point(52, 83);
            this.lbl_jumptype.Name = "lbl_jumptype";
            this.lbl_jumptype.Size = new System.Drawing.Size(73, 13);
            this.lbl_jumptype.TabIndex = 35;
            this.lbl_jumptype.Text = "JUMP TYPE: ";
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Location = new System.Drawing.Point(135, 19);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(40, 13);
            this.lbl_code.TabIndex = 34;
            this.lbl_code.Text = "CODE:";
            this.lbl_code.Visible = false;
            // 
            // cmb_chargetype
            // 
            this.cmb_chargetype.FormattingEnabled = true;
            this.cmb_chargetype.Location = new System.Drawing.Point(748, 36);
            this.cmb_chargetype.Name = "cmb_chargetype";
            this.cmb_chargetype.Size = new System.Drawing.Size(280, 21);
            this.cmb_chargetype.TabIndex = 5;
            // 
            // txb_description
            // 
            this.txb_description.Location = new System.Drawing.Point(748, 93);
            this.txb_description.Multiline = true;
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(280, 52);
            this.txb_description.TabIndex = 7;
            // 
            // txb_sequence
            // 
            this.txb_sequence.Location = new System.Drawing.Point(131, 123);
            this.txb_sequence.Name = "txb_sequence";
            this.txb_sequence.Size = new System.Drawing.Size(61, 20);
            this.txb_sequence.TabIndex = 2;
            this.txb_sequence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_sequence_KeyPress);
            // 
            // txb_group
            // 
            this.txb_group.Location = new System.Drawing.Point(748, 67);
            this.txb_group.Name = "txb_group";
            this.txb_group.Size = new System.Drawing.Size(280, 20);
            this.txb_group.TabIndex = 6;
            // 
            // txb_jumptype
            // 
            this.txb_jumptype.Location = new System.Drawing.Point(131, 80);
            this.txb_jumptype.Name = "txb_jumptype";
            this.txb_jumptype.Size = new System.Drawing.Size(190, 20);
            this.txb_jumptype.TabIndex = 1;
            // 
            // txb_code
            // 
            this.txb_code.Enabled = false;
            this.txb_code.Location = new System.Drawing.Point(163, 35);
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(158, 20);
            this.txb_code.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Location = new System.Drawing.Point(1148, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 189);
            this.groupBox3.TabIndex = 31;
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
            this.btn_limpiar.Location = new System.Drawing.Point(6, 73);
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
            this.btn_guardar.Location = new System.Drawing.Point(6, 22);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(97, 32);
            this.btn_guardar.TabIndex = 24;
            this.btn_guardar.Text = "Save";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dg_jumptype);
            this.groupBox2.Location = new System.Drawing.Point(12, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1245, 430);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // dg_jumptype
            // 
            this.dg_jumptype.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_jumptype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_jumptype.Location = new System.Drawing.Point(5, 13);
            this.dg_jumptype.Name = "dg_jumptype";
            this.dg_jumptype.Size = new System.Drawing.Size(1234, 411);
            this.dg_jumptype.TabIndex = 0;
            this.dg_jumptype.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_jumptype_UserDeletingRow);
            this.dg_jumptype.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_jumptype_MouseClick);
            // 
            // Frm_Jump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1362, 694);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_titulo);
            this.Name = "Frm_Jump";
            this.Text = "Jump Type";
            this.Load += new System.EventHandler(this.Frm_Jump_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_jumptype)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.Label lbl_altitud;
        private System.Windows.Forms.Label lbl_charge_type;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_sequence;
        private System.Windows.Forms.Label lbl_group;
        private System.Windows.Forms.Label lbl_jumptype;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.TextBox txb_description;
        private System.Windows.Forms.TextBox txb_sequence;
        private System.Windows.Forms.TextBox txb_group;
        private System.Windows.Forms.TextBox txb_jumptype;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_jumptype;
        private System.Windows.Forms.ComboBox cmb_chargetype;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.TextBox txb_altitud;
        private System.Windows.Forms.TextBox txb_codey;
        private System.Windows.Forms.Label label1;
    }
}