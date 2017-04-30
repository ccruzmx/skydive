namespace SkyDiveCuautla.Operacion
{
    partial class Frm_ticket
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_jumpername = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.txb_currentbalance = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rb_240 = new System.Windows.Forms.RadioButton();
            this.rb_361 = new System.Windows.Forms.RadioButton();
            this.lbl_ticket = new System.Windows.Forms.Label();
            this.txb_amount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_subtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_payment = new System.Windows.Forms.TextBox();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.lbl_debe = new System.Windows.Forms.Label();
            this.btn_purchase = new System.Windows.Forms.Button();
            this.btn_payment = new System.Windows.Forms.Button();
            this.btn_sale = new System.Windows.Forms.Button();
            this.lbl_price = new System.Windows.Forms.Label();
            this.lbl_defaultjumptype = new System.Windows.Forms.Label();
            this.cmb_defaultjumptype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_name = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_tickets = new System.Windows.Forms.DataGridView();
            this.tmr_payment = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tickets)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.lbl_jumpername);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1484, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbl_jumpername
            // 
            this.lbl_jumpername.AutoSize = true;
            this.lbl_jumpername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_jumpername.Location = new System.Drawing.Point(333, 77);
            this.lbl_jumpername.Name = "lbl_jumpername";
            this.lbl_jumpername.Size = new System.Drawing.Size(303, 31);
            this.lbl_jumpername.TabIndex = 2;
            this.lbl_jumpername.Text = "Jumper Name First Last";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1096, 23);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(167, 51);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket Transaction";
            // 
            // lbl_balance
            // 
            this.lbl_balance.AutoSize = true;
            this.lbl_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_balance.Location = new System.Drawing.Point(38, 91);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(52, 13);
            this.lbl_balance.TabIndex = 7;
            this.lbl_balance.Text = "Balance :";
            // 
            // txb_currentbalance
            // 
            this.txb_currentbalance.BackColor = System.Drawing.Color.OliveDrab;
            this.txb_currentbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_currentbalance.ForeColor = System.Drawing.Color.Yellow;
            this.txb_currentbalance.Location = new System.Drawing.Point(96, 79);
            this.txb_currentbalance.Name = "txb_currentbalance";
            this.txb_currentbalance.ReadOnly = true;
            this.txb_currentbalance.Size = new System.Drawing.Size(181, 32);
            this.txb_currentbalance.TabIndex = 4;
            this.txb_currentbalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.lbl_price);
            this.groupBox2.Controls.Add(this.lbl_balance);
            this.groupBox2.Controls.Add(this.txb_currentbalance);
            this.groupBox2.Controls.Add(this.lbl_defaultjumptype);
            this.groupBox2.Controls.Add(this.cmb_defaultjumptype);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmb_name);
            this.groupBox2.Location = new System.Drawing.Point(7, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1275, 194);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.lbl_ticket);
            this.groupBox4.Controls.Add(this.txb_amount);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txb_price);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lbl_subtotal);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txb_payment);
            this.groupBox4.Controls.Add(this.lbl_amount);
            this.groupBox4.Controls.Add(this.lbl_debe);
            this.groupBox4.Controls.Add(this.btn_purchase);
            this.groupBox4.Controls.Add(this.btn_payment);
            this.groupBox4.Controls.Add(this.btn_sale);
            this.groupBox4.Location = new System.Drawing.Point(454, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(815, 180);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rb_240);
            this.groupBox5.Controls.Add(this.rb_361);
            this.groupBox5.Location = new System.Drawing.Point(641, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(161, 65);
            this.groupBox5.TabIndex = 46;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Height BIXOLON SLP-T400";
            // 
            // rb_240
            // 
            this.rb_240.AutoSize = true;
            this.rb_240.Location = new System.Drawing.Point(15, 18);
            this.rb_240.Name = "rb_240";
            this.rb_240.Size = new System.Drawing.Size(105, 17);
            this.rb_240.TabIndex = 1;
            this.rb_240.TabStop = true;
            this.rb_240.Text = "240 Bixolon vieja";
            this.rb_240.UseVisualStyleBackColor = true;
            this.rb_240.CheckedChanged += new System.EventHandler(this.rb_240_CheckedChanged);
            // 
            // rb_361
            // 
            this.rb_361.AutoSize = true;
            this.rb_361.Location = new System.Drawing.Point(15, 41);
            this.rb_361.Name = "rb_361";
            this.rb_361.Size = new System.Drawing.Size(113, 17);
            this.rb_361.TabIndex = 0;
            this.rb_361.TabStop = true;
            this.rb_361.Text = "361 Bixolon nueva";
            this.rb_361.UseVisualStyleBackColor = true;
            this.rb_361.CheckedChanged += new System.EventHandler(this.rb_361_CheckedChanged);
            // 
            // lbl_ticket
            // 
            this.lbl_ticket.AutoSize = true;
            this.lbl_ticket.Location = new System.Drawing.Point(374, 16);
            this.lbl_ticket.Name = "lbl_ticket";
            this.lbl_ticket.Size = new System.Drawing.Size(52, 13);
            this.lbl_ticket.TabIndex = 45;
            this.lbl_ticket.Text = "folioticket";
            this.lbl_ticket.Visible = false;
            // 
            // txb_amount
            // 
            this.txb_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_amount.Location = new System.Drawing.Point(12, 46);
            this.txb_amount.Name = "txb_amount";
            this.txb_amount.Size = new System.Drawing.Size(127, 26);
            this.txb_amount.TabIndex = 3;
            this.txb_amount.TextChanged += new System.EventHandler(this.txb_amount_TextChanged);
            this.txb_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_amount_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "Amount due:";
            // 
            // txb_price
            // 
            this.txb_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_price.Location = new System.Drawing.Point(159, 46);
            this.txb_price.Name = "txb_price";
            this.txb_price.ReadOnly = true;
            this.txb_price.Size = new System.Drawing.Size(181, 26);
            this.txb_price.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(383, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Subtotal:";
            // 
            // lbl_subtotal
            // 
            this.lbl_subtotal.AutoSize = true;
            this.lbl_subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subtotal.Location = new System.Drawing.Point(497, 49);
            this.lbl_subtotal.Name = "lbl_subtotal";
            this.lbl_subtotal.Size = new System.Drawing.Size(40, 20);
            this.lbl_subtotal.TabIndex = 33;
            this.lbl_subtotal.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Payment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Price";
            // 
            // txb_payment
            // 
            this.txb_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_payment.Location = new System.Drawing.Point(159, 93);
            this.txb_payment.Name = "txb_payment";
            this.txb_payment.ReadOnly = true;
            this.txb_payment.Size = new System.Drawing.Size(181, 26);
            this.txb_payment.TabIndex = 41;
            this.txb_payment.Text = "0.00";
            this.txb_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_amount.Location = new System.Drawing.Point(33, 18);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(65, 20);
            this.lbl_amount.TabIndex = 35;
            this.lbl_amount.Text = "Amount";
            // 
            // lbl_debe
            // 
            this.lbl_debe.AutoSize = true;
            this.lbl_debe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_debe.Location = new System.Drawing.Point(497, 99);
            this.lbl_debe.Name = "lbl_debe";
            this.lbl_debe.Size = new System.Drawing.Size(40, 20);
            this.lbl_debe.TabIndex = 40;
            this.lbl_debe.Text = "0.00";
            // 
            // btn_purchase
            // 
            this.btn_purchase.Enabled = false;
            this.btn_purchase.Location = new System.Drawing.Point(725, 85);
            this.btn_purchase.Name = "btn_purchase";
            this.btn_purchase.Size = new System.Drawing.Size(77, 77);
            this.btn_purchase.TabIndex = 6;
            this.btn_purchase.Text = "Purchase";
            this.btn_purchase.UseVisualStyleBackColor = true;
            this.btn_purchase.Click += new System.EventHandler(this.btn_purchase_Click);
            // 
            // btn_payment
            // 
            this.btn_payment.Location = new System.Drawing.Point(185, 131);
            this.btn_payment.Name = "btn_payment";
            this.btn_payment.Size = new System.Drawing.Size(155, 24);
            this.btn_payment.TabIndex = 4;
            this.btn_payment.Text = "Payment BrakeDown";
            this.btn_payment.UseVisualStyleBackColor = true;
            this.btn_payment.Click += new System.EventHandler(this.btn_payment_Click);
            // 
            // btn_sale
            // 
            this.btn_sale.Enabled = false;
            this.btn_sale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sale.Image = global::SkyDiveCuautla.Properties.Resources.Printer;
            this.btn_sale.Location = new System.Drawing.Point(641, 84);
            this.btn_sale.Name = "btn_sale";
            this.btn_sale.Size = new System.Drawing.Size(78, 79);
            this.btn_sale.TabIndex = 5;
            this.btn_sale.Text = "Sale";
            this.btn_sale.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sale.UseVisualStyleBackColor = true;
            this.btn_sale.Click += new System.EventHandler(this.btn_sale_Click);
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(329, 86);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(0, 13);
            this.lbl_price.TabIndex = 38;
            // 
            // lbl_defaultjumptype
            // 
            this.lbl_defaultjumptype.AutoSize = true;
            this.lbl_defaultjumptype.Location = new System.Drawing.Point(24, 142);
            this.lbl_defaultjumptype.Name = "lbl_defaultjumptype";
            this.lbl_defaultjumptype.Size = new System.Drawing.Size(65, 13);
            this.lbl_defaultjumptype.TabIndex = 30;
            this.lbl_defaultjumptype.Text = "Jump Type :";
            // 
            // cmb_defaultjumptype
            // 
            this.cmb_defaultjumptype.FormattingEnabled = true;
            this.cmb_defaultjumptype.Location = new System.Drawing.Point(96, 139);
            this.cmb_defaultjumptype.Name = "cmb_defaultjumptype";
            this.cmb_defaultjumptype.Size = new System.Drawing.Size(312, 21);
            this.cmb_defaultjumptype.TabIndex = 2;
            this.cmb_defaultjumptype.SelectedIndexChanged += new System.EventHandler(this.cmb_defaultjumptype_SelectedIndexChanged);
            this.cmb_defaultjumptype.SelectionChangeCommitted += new System.EventHandler(this.cmb_defaultjumptype_SelectionChangeCommitted);
            this.cmb_defaultjumptype.TextUpdate += new System.EventHandler(this.cmb_defaultjumptype_TextUpdate);
            this.cmb_defaultjumptype.SelectedValueChanged += new System.EventHandler(this.cmb_defaultjumptype_SelectedValueChanged);
            this.cmb_defaultjumptype.TextChanged += new System.EventHandler(this.cmb_defaultjumptype_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jumper:";
            // 
            // cmb_name
            // 
            this.cmb_name.FormattingEnabled = true;
            this.cmb_name.Location = new System.Drawing.Point(96, 28);
            this.cmb_name.Name = "cmb_name";
            this.cmb_name.Size = new System.Drawing.Size(345, 21);
            this.cmb_name.TabIndex = 1;
            this.cmb_name.SelectedIndexChanged += new System.EventHandler(this.cmb_name_SelectedIndexChanged);
            this.cmb_name.SelectedValueChanged += new System.EventHandler(this.cmb_name_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dg_tickets);
            this.groupBox3.Location = new System.Drawing.Point(7, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1275, 296);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            // 
            // dg_tickets
            // 
            this.dg_tickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_tickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_tickets.Location = new System.Drawing.Point(11, 19);
            this.dg_tickets.Name = "dg_tickets";
            this.dg_tickets.Size = new System.Drawing.Size(1255, 271);
            this.dg_tickets.TabIndex = 0;
            this.dg_tickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_tickets_CellClick);
            this.dg_tickets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_tickets_CellDoubleClick);
            // 
            // tmr_payment
            // 
            this.tmr_payment.Tick += new System.EventHandler(this.tmr_payment_Tick);
            // 
            // Frm_ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 596);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_ticket";
            this.Text = "Ticket Transaction";
            this.Load += new System.EventHandler(this.Frm_ticket_Load);
            this.Enter += new System.EventHandler(this.Frm_ticket_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_tickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_balance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_name;
        private System.Windows.Forms.TextBox txb_currentbalance;
        private System.Windows.Forms.ComboBox cmb_defaultjumptype;
        private System.Windows.Forms.Label lbl_defaultjumptype;
        private System.Windows.Forms.Label lbl_jumpername;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_tickets;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_subtotal;
        private System.Windows.Forms.TextBox txb_amount;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.Button btn_sale;
        private System.Windows.Forms.Button btn_purchase;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Button btn_payment;
        private System.Windows.Forms.Label lbl_debe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_payment;
        private System.Windows.Forms.Timer tmr_payment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_ticket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rb_240;
        private System.Windows.Forms.RadioButton rb_361;
    }
}