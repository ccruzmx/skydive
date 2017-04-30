namespace SkyDiveCuautla.Catalogos
{
    partial class Frm_Jumper
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.lbl_sequence = new System.Windows.Forms.Label();
            this.lbl_jumpertype = new System.Windows.Forms.Label();
            this.txb_sequence = new System.Windows.Forms.TextBox();
            this.txb_jumpertype = new System.Windows.Forms.TextBox();
            this.txb_code = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_jumpertype = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_jumpertype)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_titulo.Location = new System.Drawing.Point(12, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(677, 45);
            this.lbl_titulo.TabIndex = 30;
            this.lbl_titulo.Text = "JUMPER TYPE ADMINISTRATION";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cerrar);
            this.groupBox3.Controls.Add(this.btn_limpiar);
            this.groupBox3.Controls.Add(this.btn_guardar);
            this.groupBox3.Location = new System.Drawing.Point(569, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 169);
            this.groupBox3.TabIndex = 33;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_active);
            this.groupBox1.Controls.Add(this.lbl_sequence);
            this.groupBox1.Controls.Add(this.lbl_jumpertype);
            this.groupBox1.Controls.Add(this.txb_sequence);
            this.groupBox1.Controls.Add(this.txb_jumpertype);
            this.groupBox1.Controls.Add(this.txb_code);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 169);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_active.Location = new System.Drawing.Point(82, 37);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(73, 17);
            this.chk_active.TabIndex = 44;
            this.chk_active.Text = "ACTIVE : ";
            this.chk_active.UseVisualStyleBackColor = true;
            this.chk_active.CheckedChanged += new System.EventHandler(this.chk_active_CheckedChanged);
            // 
            // lbl_sequence
            // 
            this.lbl_sequence.AutoSize = true;
            this.lbl_sequence.Location = new System.Drawing.Point(68, 126);
            this.lbl_sequence.Name = "lbl_sequence";
            this.lbl_sequence.Size = new System.Drawing.Size(69, 13);
            this.lbl_sequence.TabIndex = 37;
            this.lbl_sequence.Text = "SEQUENCE:";
            // 
            // lbl_jumpertype
            // 
            this.lbl_jumpertype.AutoSize = true;
            this.lbl_jumpertype.Location = new System.Drawing.Point(52, 83);
            this.lbl_jumpertype.Name = "lbl_jumpertype";
            this.lbl_jumpertype.Size = new System.Drawing.Size(88, 13);
            this.lbl_jumpertype.TabIndex = 35;
            this.lbl_jumpertype.Text = "JUMPER TYPE: ";
            // 
            // txb_sequence
            // 
            this.txb_sequence.Location = new System.Drawing.Point(146, 123);
            this.txb_sequence.Name = "txb_sequence";
            this.txb_sequence.Size = new System.Drawing.Size(91, 20);
            this.txb_sequence.TabIndex = 2;
            this.txb_sequence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_sequence_KeyPress);
            // 
            // txb_jumpertype
            // 
            this.txb_jumpertype.Location = new System.Drawing.Point(146, 80);
            this.txb_jumpertype.Name = "txb_jumpertype";
            this.txb_jumpertype.Size = new System.Drawing.Size(276, 20);
            this.txb_jumpertype.TabIndex = 1;
            // 
            // txb_code
            // 
            this.txb_code.Enabled = false;
            this.txb_code.Location = new System.Drawing.Point(178, 35);
            this.txb_code.Name = "txb_code";
            this.txb_code.Size = new System.Drawing.Size(244, 20);
            this.txb_code.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_jumpertype);
            this.groupBox2.Location = new System.Drawing.Point(12, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(666, 398);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // dg_jumpertype
            // 
            this.dg_jumpertype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_jumpertype.Location = new System.Drawing.Point(5, 13);
            this.dg_jumpertype.Name = "dg_jumpertype";
            this.dg_jumpertype.Size = new System.Drawing.Size(655, 379);
            this.dg_jumpertype.TabIndex = 0;
            this.dg_jumpertype.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_jumpertype_UserDeletingRow);
            this.dg_jumpertype.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_jumpertype_MouseClick);
            // 
            // Frm_Jumper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 647);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_titulo);
            this.Name = "Frm_Jumper";
            this.Text = "Jumper Type";
            this.Load += new System.EventHandler(this.Frm_Jumper_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_jumpertype)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Label lbl_sequence;
        private System.Windows.Forms.Label lbl_jumpertype;
        private System.Windows.Forms.TextBox txb_sequence;
        private System.Windows.Forms.TextBox txb_jumpertype;
        private System.Windows.Forms.TextBox txb_code;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_jumpertype;
    }
}