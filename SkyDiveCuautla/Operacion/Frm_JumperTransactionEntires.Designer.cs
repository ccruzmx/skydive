namespace SkyDiveCuautla.Operacion
{
    partial class Frm_JumperTransactionEntires
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
            this.components = new System.ComponentModel.Container();
            this.btn_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_jumpercode = new System.Windows.Forms.Label();
            this.txb_currentbalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txb_nota = new System.Windows.Forms.TextBox();
            this.lbl_note = new System.Windows.Forms.Label();
            this.cmb_transferto = new System.Windows.Forms.ComboBox();
            this.lbl_transferto = new System.Windows.Forms.Label();
            this.txb_transfer = new System.Windows.Forms.TextBox();
            this.lbl_transfer = new System.Windows.Forms.Label();
            this.txb_staff = new System.Windows.Forms.TextBox();
            this.lbl_staff = new System.Windows.Forms.Label();
            this.btn_payment = new System.Windows.Forms.Button();
            this.txb_payment = new System.Windows.Forms.TextBox();
            this.lbl_payment = new System.Windows.Forms.Label();
            this.cmb_charge = new System.Windows.Forms.ComboBox();
            this.txb_charge = new System.Windows.Forms.TextBox();
            this.lbl_charge = new System.Windows.Forms.Label();
            this.cmb_name = new System.Windows.Forms.ComboBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tmr_payment = new System.Windows.Forms.Timer(this.components);
            this.tmr_currentbalance = new System.Windows.Forms.Timer(this.components);
            this.cmb_oficina = new System.Windows.Forms.ComboBox();
            this.txb_variables = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(397, 410);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(48, 31);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "&Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.lbl_jumpercode);
            this.groupBox1.Controls.Add(this.txb_currentbalance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl_titulo);
            this.groupBox1.Location = new System.Drawing.Point(-1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbl_jumpercode
            // 
            this.lbl_jumpercode.AutoSize = true;
            this.lbl_jumpercode.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_jumpercode.Location = new System.Drawing.Point(165, 13);
            this.lbl_jumpercode.Name = "lbl_jumpercode";
            this.lbl_jumpercode.Size = new System.Drawing.Size(59, 13);
            this.lbl_jumpercode.TabIndex = 4;
            this.lbl_jumpercode.Text = "Tran_Manf";
            // 
            // txb_currentbalance
            // 
            this.txb_currentbalance.Location = new System.Drawing.Point(323, 38);
            this.txb_currentbalance.Name = "txb_currentbalance";
            this.txb_currentbalance.Size = new System.Drawing.Size(107, 20);
            this.txb_currentbalance.TabIndex = 3;
            this.txb_currentbalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(320, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Balance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transactions";
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_titulo.Location = new System.Drawing.Point(14, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(78, 24);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Jumper";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txb_nota);
            this.groupBox2.Controls.Add(this.lbl_note);
            this.groupBox2.Controls.Add(this.cmb_transferto);
            this.groupBox2.Controls.Add(this.lbl_transferto);
            this.groupBox2.Controls.Add(this.txb_transfer);
            this.groupBox2.Controls.Add(this.lbl_transfer);
            this.groupBox2.Controls.Add(this.txb_staff);
            this.groupBox2.Controls.Add(this.lbl_staff);
            this.groupBox2.Controls.Add(this.btn_payment);
            this.groupBox2.Controls.Add(this.txb_payment);
            this.groupBox2.Controls.Add(this.lbl_payment);
            this.groupBox2.Controls.Add(this.cmb_charge);
            this.groupBox2.Controls.Add(this.txb_charge);
            this.groupBox2.Controls.Add(this.lbl_charge);
            this.groupBox2.Controls.Add(this.cmb_name);
            this.groupBox2.Controls.Add(this.lbl_name);
            this.groupBox2.Location = new System.Drawing.Point(8, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 309);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txb_nota
            // 
            this.txb_nota.Location = new System.Drawing.Point(45, 215);
            this.txb_nota.Multiline = true;
            this.txb_nota.Name = "txb_nota";
            this.txb_nota.Size = new System.Drawing.Size(376, 75);
            this.txb_nota.TabIndex = 15;
            // 
            // lbl_note
            // 
            this.lbl_note.AutoSize = true;
            this.lbl_note.Location = new System.Drawing.Point(12, 223);
            this.lbl_note.Name = "lbl_note";
            this.lbl_note.Size = new System.Drawing.Size(33, 13);
            this.lbl_note.TabIndex = 14;
            this.lbl_note.Text = "Note:";
            // 
            // cmb_transferto
            // 
            this.cmb_transferto.Enabled = false;
            this.cmb_transferto.FormattingEnabled = true;
            this.cmb_transferto.Location = new System.Drawing.Point(122, 187);
            this.cmb_transferto.Name = "cmb_transferto";
            this.cmb_transferto.Size = new System.Drawing.Size(299, 21);
            this.cmb_transferto.TabIndex = 13;
            // 
            // lbl_transferto
            // 
            this.lbl_transferto.AutoSize = true;
            this.lbl_transferto.Location = new System.Drawing.Point(45, 187);
            this.lbl_transferto.Name = "lbl_transferto";
            this.lbl_transferto.Size = new System.Drawing.Size(61, 13);
            this.lbl_transferto.TabIndex = 12;
            this.lbl_transferto.Text = "Transfer to:";
            // 
            // txb_transfer
            // 
            this.txb_transfer.Location = new System.Drawing.Point(122, 158);
            this.txb_transfer.Name = "txb_transfer";
            this.txb_transfer.Size = new System.Drawing.Size(128, 20);
            this.txb_transfer.TabIndex = 11;
            this.txb_transfer.Text = "0.00";
            this.txb_transfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_transfer.Click += new System.EventHandler(this.txb_transfer_Click);
            this.txb_transfer.TextChanged += new System.EventHandler(this.txb_transfer_TextChanged);
            this.txb_transfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_transfer_KeyPress);
            this.txb_transfer.LostFocus += new System.EventHandler(this.txb_transfer_LostFocus);
            // 
            // lbl_transfer
            // 
            this.lbl_transfer.AutoSize = true;
            this.lbl_transfer.Location = new System.Drawing.Point(42, 158);
            this.lbl_transfer.Name = "lbl_transfer";
            this.lbl_transfer.Size = new System.Drawing.Size(49, 13);
            this.lbl_transfer.TabIndex = 10;
            this.lbl_transfer.Text = "Transfer:";
            // 
            // txb_staff
            // 
            this.txb_staff.Location = new System.Drawing.Point(122, 124);
            this.txb_staff.Name = "txb_staff";
            this.txb_staff.Size = new System.Drawing.Size(128, 20);
            this.txb_staff.TabIndex = 9;
            this.txb_staff.Text = "0.00";
            this.txb_staff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_staff.Click += new System.EventHandler(this.txb_staff_Click);
            this.txb_staff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_staff_KeyPress);
            this.txb_staff.LostFocus += new System.EventHandler(this.txb_staff_LostFocus);
            // 
            // lbl_staff
            // 
            this.lbl_staff.AutoSize = true;
            this.lbl_staff.Location = new System.Drawing.Point(42, 125);
            this.lbl_staff.Name = "lbl_staff";
            this.lbl_staff.Size = new System.Drawing.Size(76, 13);
            this.lbl_staff.TabIndex = 8;
            this.lbl_staff.Text = "Staff Payment:";
            // 
            // btn_payment
            // 
            this.btn_payment.Location = new System.Drawing.Point(266, 87);
            this.btn_payment.Name = "btn_payment";
            this.btn_payment.Size = new System.Drawing.Size(155, 23);
            this.btn_payment.TabIndex = 7;
            this.btn_payment.Text = "Payment BrakeDown";
            this.btn_payment.UseVisualStyleBackColor = true;
            this.btn_payment.Click += new System.EventHandler(this.btn_payment_Click);
            // 
            // txb_payment
            // 
            this.txb_payment.Enabled = false;
            this.txb_payment.Location = new System.Drawing.Point(122, 88);
            this.txb_payment.Name = "txb_payment";
            this.txb_payment.Size = new System.Drawing.Size(128, 20);
            this.txb_payment.TabIndex = 6;
            this.txb_payment.Text = "0.00";
            this.txb_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_payment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_payment_KeyPress);
            this.txb_payment.LostFocus += new System.EventHandler(this.txb_payment_LostFocus);
            // 
            // lbl_payment
            // 
            this.lbl_payment.AutoSize = true;
            this.lbl_payment.Location = new System.Drawing.Point(42, 90);
            this.lbl_payment.Name = "lbl_payment";
            this.lbl_payment.Size = new System.Drawing.Size(51, 13);
            this.lbl_payment.TabIndex = 5;
            this.lbl_payment.Text = "Payment:";
            // 
            // cmb_charge
            // 
            this.cmb_charge.Enabled = false;
            this.cmb_charge.FormattingEnabled = true;
            this.cmb_charge.Location = new System.Drawing.Point(266, 51);
            this.cmb_charge.Name = "cmb_charge";
            this.cmb_charge.Size = new System.Drawing.Size(155, 21);
            this.cmb_charge.TabIndex = 4;
            // 
            // txb_charge
            // 
            this.txb_charge.Location = new System.Drawing.Point(122, 52);
            this.txb_charge.Name = "txb_charge";
            this.txb_charge.Size = new System.Drawing.Size(128, 20);
            this.txb_charge.TabIndex = 3;
            this.txb_charge.Text = "0.00";
            this.txb_charge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_charge.Click += new System.EventHandler(this.txb_charge_Click);
            this.txb_charge.TextChanged += new System.EventHandler(this.txb_charge_TextChanged);
            this.txb_charge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_charge_KeyPress);
            this.txb_charge.LostFocus += new System.EventHandler(this.txb_charge_LostFocus);
            // 
            // lbl_charge
            // 
            this.lbl_charge.AutoSize = true;
            this.lbl_charge.Location = new System.Drawing.Point(42, 60);
            this.lbl_charge.Name = "lbl_charge";
            this.lbl_charge.Size = new System.Drawing.Size(47, 13);
            this.lbl_charge.TabIndex = 2;
            this.lbl_charge.Text = "Charge: ";
            // 
            // cmb_name
            // 
            this.cmb_name.FormattingEnabled = true;
            this.cmb_name.Location = new System.Drawing.Point(78, 19);
            this.cmb_name.Name = "cmb_name";
            this.cmb_name.Size = new System.Drawing.Size(343, 21);
            this.cmb_name.TabIndex = 1;
            this.cmb_name.SelectedIndexChanged += new System.EventHandler(this.cmb_name_SelectedIndexChanged);
            this.cmb_name.SelectionChangeCommitted += new System.EventHandler(this.cmb_name_SelectionChangeCommitted);
            this.cmb_name.TextUpdate += new System.EventHandler(this.cmb_name_TextUpdate);
            this.cmb_name.ValueMemberChanged += new System.EventHandler(this.cmb_name_ValueMemberChanged);
            this.cmb_name.SelectedValueChanged += new System.EventHandler(this.cmb_name_SelectedValueChanged);
            this.cmb_name.TabIndexChanged += new System.EventHandler(this.cmb_name_TabIndexChanged);
            this.cmb_name.TextChanged += new System.EventHandler(this.cmb_name_TextChanged);
            this.cmb_name.VisibleChanged += new System.EventHandler(this.cmb_name_VisibleChanged);
            this.cmb_name.Enter += new System.EventHandler(this.cmb_name_Enter);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(9, 20);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(41, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name: ";
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(8, 410);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(50, 31);
            this.btn_new.TabIndex = 3;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(69, 410);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(45, 31);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tmr_payment
            // 
            this.tmr_payment.Tick += new System.EventHandler(this.tmr_payment_Tick);
            // 
            // tmr_currentbalance
            // 
            this.tmr_currentbalance.Tick += new System.EventHandler(this.tmr_currentbalance_Tick);
            // 
            // cmb_oficina
            // 
            this.cmb_oficina.FormattingEnabled = true;
            this.cmb_oficina.Location = new System.Drawing.Point(136, 414);
            this.cmb_oficina.Name = "cmb_oficina";
            this.cmb_oficina.Size = new System.Drawing.Size(248, 21);
            this.cmb_oficina.TabIndex = 5;
            // 
            // txb_variables
            // 
            this.txb_variables.Location = new System.Drawing.Point(465, 108);
            this.txb_variables.Multiline = true;
            this.txb_variables.Name = "txb_variables";
            this.txb_variables.Size = new System.Drawing.Size(112, 327);
            this.txb_variables.TabIndex = 6;
            // 
            // Frm_JumperTransactionEntires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(589, 445);
            this.Controls.Add(this.txb_variables);
            this.Controls.Add(this.cmb_oficina);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_exit);
            this.MaximizeBox = false;
            this.Name = "Frm_JumperTransactionEntires";
            this.Text = "Frm_JumperTransactionEntires";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_JumperTransactionEntires_FormClosing);
            this.Load += new System.EventHandler(this.Frm_JumperTransactionEntires_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_currentbalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txb_nota;
        private System.Windows.Forms.Label lbl_note;
        private System.Windows.Forms.ComboBox cmb_transferto;
        private System.Windows.Forms.Label lbl_transferto;
        private System.Windows.Forms.TextBox txb_transfer;
        private System.Windows.Forms.Label lbl_transfer;
        private System.Windows.Forms.TextBox txb_staff;
        private System.Windows.Forms.Label lbl_staff;
        private System.Windows.Forms.Button btn_payment;
        private System.Windows.Forms.TextBox txb_payment;
        private System.Windows.Forms.Label lbl_payment;
        private System.Windows.Forms.ComboBox cmb_charge;
        private System.Windows.Forms.TextBox txb_charge;
        private System.Windows.Forms.Label lbl_charge;
        private System.Windows.Forms.ComboBox cmb_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Timer tmr_payment;
        private System.Windows.Forms.Timer tmr_currentbalance;
        private System.Windows.Forms.Label lbl_jumpercode;
        private System.Windows.Forms.ComboBox cmb_oficina;
        private System.Windows.Forms.TextBox txb_variables;
    }
}