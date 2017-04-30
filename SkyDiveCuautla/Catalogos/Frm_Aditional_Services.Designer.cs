namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Aditional_Services
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
            this.dg_aditionalservices = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmb_office = new System.Windows.Forms.ComboBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.lbl_charge_type = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_code = new System.Windows.Forms.Label();
            this.cmb_chargetype = new System.Windows.Forms.ComboBox();
            this.txb_description = new System.Windows.Forms.TextBox();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_aditionalservices)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dg_aditionalservices);
            this.groupBox2.Location = new System.Drawing.Point(7, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1245, 509);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // dg_aditionalservices
            // 
            this.dg_aditionalservices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_aditionalservices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_aditionalservices.Location = new System.Drawing.Point(5, 13);
            this.dg_aditionalservices.Name = "dg_aditionalservices";
            this.dg_aditionalservices.Size = new System.Drawing.Size(1234, 490);
            this.dg_aditionalservices.TabIndex = 0;
            this.dg_aditionalservices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_aditionalservices_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.cmb_office);
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Location = new System.Drawing.Point(885, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 163);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Location = new System.Drawing.Point(10, 16);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 25);
            this.label22.TabIndex = 55;
            this.label22.Text = "DropZone:";
            // 
            // cmb_office
            // 
            this.cmb_office.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_office.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_office.FormattingEnabled = true;
            this.cmb_office.Location = new System.Drawing.Point(120, 21);
            this.cmb_office.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_office.Name = "cmb_office";
            this.cmb_office.Size = new System.Drawing.Size(228, 21);
            this.cmb_office.TabIndex = 54;
            this.cmb_office.SelectionChangeCommitted += new System.EventHandler(this.cmb_office_SelectionChangeCommitted);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Image = global::SkyDiveCuautla.Properties.Resources.Exit;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(254, 60);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(97, 84);
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
            this.btn_limpiar.Location = new System.Drawing.Point(135, 59);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(97, 85);
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
            this.btn_guardar.Location = new System.Drawing.Point(15, 60);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(97, 84);
            this.btn_guardar.TabIndex = 24;
            this.btn_guardar.Text = "Save";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_active);
            this.groupBox1.Controls.Add(this.lbl_price);
            this.groupBox1.Controls.Add(this.txb_price);
            this.groupBox1.Controls.Add(this.lbl_charge_type);
            this.groupBox1.Controls.Add(this.lbl_description);
            this.groupBox1.Controls.Add(this.lbl_code);
            this.groupBox1.Controls.Add(this.cmb_chargetype);
            this.groupBox1.Controls.Add(this.txb_description);
            this.groupBox1.Controls.Add(this.txb_code);
            this.groupBox1.Location = new System.Drawing.Point(7, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 163);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_active.Location = new System.Drawing.Point(20, 37);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(80, 17);
            this.chk_active.TabIndex = 44;
            this.chk_active.Text = "ACTIVE :  *";
            this.chk_active.UseVisualStyleBackColor = true;
            this.chk_active.CheckedChanged += new System.EventHandler(this.chk_active_CheckedChanged);
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(165, 101);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(52, 13);
            this.lbl_price.TabIndex = 43;
            this.lbl_price.Text = "PRICE:  *";
            // 
            // txb_price
            // 
            this.txb_price.Location = new System.Drawing.Point(228, 98);
            this.txb_price.Name = "txb_price";
            this.txb_price.Size = new System.Drawing.Size(167, 20);
            this.txb_price.TabIndex = 3;
            // 
            // lbl_charge_type
            // 
            this.lbl_charge_type.AutoSize = true;
            this.lbl_charge_type.Location = new System.Drawing.Point(430, 101);
            this.lbl_charge_type.Name = "lbl_charge_type";
            this.lbl_charge_type.Size = new System.Drawing.Size(96, 13);
            this.lbl_charge_type.TabIndex = 39;
            this.lbl_charge_type.Text = "CHARGE TYPE : *";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(438, 42);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(90, 13);
            this.lbl_description.TabIndex = 38;
            this.lbl_description.Text = "DESCRIPTION: *";
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Location = new System.Drawing.Point(170, 42);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(47, 13);
            this.lbl_code.TabIndex = 34;
            this.lbl_code.Text = "CODE: *";
            // 
            // cmb_chargetype
            // 
            this.cmb_chargetype.FormattingEnabled = true;
            this.cmb_chargetype.Location = new System.Drawing.Point(532, 96);
            this.cmb_chargetype.Name = "cmb_chargetype";
            this.cmb_chargetype.Size = new System.Drawing.Size(306, 21);
            this.cmb_chargetype.TabIndex = 5;
            // 
            // txb_description
            // 
            this.txb_description.Location = new System.Drawing.Point(532, 38);
            this.txb_description.Multiline = true;
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(306, 22);
            this.txb_description.TabIndex = 7;
            // 
            // txb_code
            // 
            this.txb_code.Enabled = false;
            this.txb_code.Location = new System.Drawing.Point(228, 38);
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(158, 20);
            this.txb_code.TabIndex = 25;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(202, 21);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(833, 45);
            this.lbl_titulo.TabIndex = 36;
            this.lbl_titulo.Text = "ADITIONAL SERVICES ADMINISTRATION";
            // 
            // Frm_Aditional_Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1260, 764);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Aditional_Services";
            this.Text = "Frm_Aditional_Services";
            this.Load += new System.EventHandler(this.Frm_Aditional_Services_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_aditionalservices)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_aditionalservices;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.Label lbl_charge_type;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.ComboBox cmb_chargetype;
        private System.Windows.Forms.TextBox txb_description;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmb_office;
    }
}