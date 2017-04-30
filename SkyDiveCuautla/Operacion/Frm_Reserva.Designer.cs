namespace SkyDiveCuautla.Operacion
{
    partial class Frm_Reserva
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_contacts = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dp_schedule = new System.Windows.Forms.DateTimePicker();
            this.dp_horario = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dp_reserva = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txb_priceorg = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txb_vendor = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txb_personas = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.dp_jumpdate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txb_metodo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txb_deposit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txb_note = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txb_card = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_mobile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_workphone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_homephone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dp_follow = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_lastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_idreserva = new System.Windows.Forms.TextBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_dropzone = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.txb_filtro_nombre = new System.Windows.Forms.TextBox();
            this.dp_gridinfo = new System.Windows.Forms.DateTimePicker();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.lbl_numreserva = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tmr_import = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dp_fin = new System.Windows.Forms.DateTimePicker();
            this.dp_ini = new System.Windows.Forms.DateTimePicker();
            this.btn_create = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_contacts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dg_contacts);
            this.groupBox3.Location = new System.Drawing.Point(4, 273);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1981, 498);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // dg_contacts
            // 
            this.dg_contacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_contacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_contacts.Location = new System.Drawing.Point(20, 22);
            this.dg_contacts.Margin = new System.Windows.Forms.Padding(4);
            this.dg_contacts.Name = "dg_contacts";
            this.dg_contacts.Size = new System.Drawing.Size(1949, 476);
            this.dg_contacts.TabIndex = 0;
            this.dg_contacts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_contacts_CellDoubleClick);
            this.dg_contacts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_contacts_UserDeletingRow);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.dp_schedule);
            this.groupBox1.Controls.Add(this.dp_horario);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.dp_reserva);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txb_priceorg);
            this.groupBox1.Controls.Add(this.lbl_id);
            this.groupBox1.Controls.Add(this.txb_vendor);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.dp_jumpdate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txb_metodo);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txb_deposit);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txb_note);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txb_card);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txb_email);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txb_mobile);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txb_workphone);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txb_homephone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dp_follow);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txb_lastname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txb_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_idreserva);
            this.groupBox1.Location = new System.Drawing.Point(321, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1319, 258);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Organizator";
            // 
            // dp_schedule
            // 
            this.dp_schedule.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dp_schedule.Location = new System.Drawing.Point(749, 172);
            this.dp_schedule.Margin = new System.Windows.Forms.Padding(4);
            this.dp_schedule.Name = "dp_schedule";
            this.dp_schedule.Size = new System.Drawing.Size(184, 22);
            this.dp_schedule.TabIndex = 12;
            // 
            // dp_horario
            // 
            this.dp_horario.Location = new System.Drawing.Point(949, 128);
            this.dp_horario.Margin = new System.Windows.Forms.Padding(4);
            this.dp_horario.Name = "dp_horario";
            this.dp_horario.Size = new System.Drawing.Size(69, 22);
            this.dp_horario.TabIndex = 44;
            this.dp_horario.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(627, 176);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 17);
            this.label20.TabIndex = 43;
            this.label20.Text = "SCHEDULE:";
            // 
            // dp_reserva
            // 
            this.dp_reserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_reserva.Location = new System.Drawing.Point(749, 31);
            this.dp_reserva.Margin = new System.Windows.Forms.Padding(4);
            this.dp_reserva.Name = "dp_reserva";
            this.dp_reserva.Size = new System.Drawing.Size(184, 22);
            this.dp_reserva.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(625, 224);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 17);
            this.label15.TabIndex = 39;
            this.label15.Text = "PRICE ORGANIZATOR:";
            // 
            // txb_priceorg
            // 
            this.txb_priceorg.Location = new System.Drawing.Point(799, 217);
            this.txb_priceorg.Margin = new System.Windows.Forms.Padding(4);
            this.txb_priceorg.Name = "txb_priceorg";
            this.txb_priceorg.Size = new System.Drawing.Size(135, 22);
            this.txb_priceorg.TabIndex = 13;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(23, 20);
            this.lbl_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(54, 17);
            this.lbl_id.TabIndex = 39;
            this.lbl_id.Text = "label20";
            this.lbl_id.Visible = false;
            // 
            // txb_vendor
            // 
            this.txb_vendor.Location = new System.Drawing.Point(1028, 32);
            this.txb_vendor.Margin = new System.Windows.Forms.Padding(4);
            this.txb_vendor.Name = "txb_vendor";
            this.txb_vendor.Size = new System.Drawing.Size(273, 22);
            this.txb_vendor.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(945, 36);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "VENDOR:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txb_personas);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txb_price);
            this.groupBox4.Location = new System.Drawing.Point(1001, 160);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(301, 87);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            // 
            // txb_personas
            // 
            this.txb_personas.Location = new System.Drawing.Point(216, 17);
            this.txb_personas.Margin = new System.Windows.Forms.Padding(4);
            this.txb_personas.Name = "txb_personas";
            this.txb_personas.Size = new System.Drawing.Size(67, 22);
            this.txb_personas.TabIndex = 16;
            this.txb_personas.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 21);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(191, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "PERSONS ON THE GROUP:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 53);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(131, 17);
            this.label19.TabIndex = 37;
            this.label19.Text = "PRICE TO GROUP:";
            // 
            // txb_price
            // 
            this.txb_price.Location = new System.Drawing.Point(184, 49);
            this.txb_price.Margin = new System.Windows.Forms.Padding(4);
            this.txb_price.Name = "txb_price";
            this.txb_price.Size = new System.Drawing.Size(99, 22);
            this.txb_price.TabIndex = 17;
            // 
            // dp_jumpdate
            // 
            this.dp_jumpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_jumpdate.Location = new System.Drawing.Point(749, 124);
            this.dp_jumpdate.Margin = new System.Windows.Forms.Padding(4);
            this.dp_jumpdate.Name = "dp_jumpdate";
            this.dp_jumpdate.Size = new System.Drawing.Size(184, 22);
            this.dp_jumpdate.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(625, 130);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 17);
            this.label14.TabIndex = 26;
            this.label14.Text = "JUMP DATE:";
            // 
            // txb_metodo
            // 
            this.txb_metodo.Location = new System.Drawing.Point(389, 217);
            this.txb_metodo.Margin = new System.Windows.Forms.Padding(4);
            this.txb_metodo.Name = "txb_metodo";
            this.txb_metodo.Size = new System.Drawing.Size(215, 22);
            this.txb_metodo.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(305, 220);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "METHOD:";
            // 
            // txb_deposit
            // 
            this.txb_deposit.Location = new System.Drawing.Point(107, 217);
            this.txb_deposit.Margin = new System.Windows.Forms.Padding(4);
            this.txb_deposit.Name = "txb_deposit";
            this.txb_deposit.Size = new System.Drawing.Size(191, 22);
            this.txb_deposit.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 220);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "DEPOSIT:";
            // 
            // txb_note
            // 
            this.txb_note.Location = new System.Drawing.Point(1027, 76);
            this.txb_note.Margin = new System.Windows.Forms.Padding(4);
            this.txb_note.Multiline = true;
            this.txb_note.Name = "txb_note";
            this.txb_note.Size = new System.Drawing.Size(275, 72);
            this.txb_note.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(945, 82);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "NOTE:";
            // 
            // txb_card
            // 
            this.txb_card.Location = new System.Drawing.Point(433, 32);
            this.txb_card.Margin = new System.Windows.Forms.Padding(4);
            this.txb_card.Name = "txb_card";
            this.txb_card.Size = new System.Drawing.Size(171, 22);
            this.txb_card.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 37);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "CARD NUMBER:";
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(373, 171);
            this.txb_email.Margin = new System.Windows.Forms.Padding(4);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(231, 22);
            this.txb_email.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 178);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "E-MAIL:";
            // 
            // txb_mobile
            // 
            this.txb_mobile.Location = new System.Drawing.Point(152, 171);
            this.txb_mobile.Margin = new System.Windows.Forms.Padding(4);
            this.txb_mobile.Name = "txb_mobile";
            this.txb_mobile.Size = new System.Drawing.Size(145, 22);
            this.txb_mobile.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 180);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "MOBILE PHONE:";
            // 
            // txb_workphone
            // 
            this.txb_workphone.Location = new System.Drawing.Point(423, 127);
            this.txb_workphone.Margin = new System.Windows.Forms.Padding(4);
            this.txb_workphone.Name = "txb_workphone";
            this.txb_workphone.Size = new System.Drawing.Size(181, 22);
            this.txb_workphone.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 130);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "WORK PHONE:";
            // 
            // txb_homephone
            // 
            this.txb_homephone.Location = new System.Drawing.Point(141, 127);
            this.txb_homephone.Margin = new System.Windows.Forms.Padding(4);
            this.txb_homephone.Name = "txb_homephone";
            this.txb_homephone.Size = new System.Drawing.Size(156, 22);
            this.txb_homephone.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "HOME PHONE:";
            // 
            // dp_follow
            // 
            this.dp_follow.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_follow.Location = new System.Drawing.Point(749, 78);
            this.dp_follow.Margin = new System.Windows.Forms.Padding(4);
            this.dp_follow.Name = "dp_follow";
            this.dp_follow.Size = new System.Drawing.Size(184, 22);
            this.dp_follow.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "FOLLOW:";
            // 
            // txb_lastname
            // 
            this.txb_lastname.Location = new System.Drawing.Point(404, 80);
            this.txb_lastname.Margin = new System.Windows.Forms.Padding(4);
            this.txb_lastname.Name = "txb_lastname";
            this.txb_lastname.Size = new System.Drawing.Size(200, 22);
            this.txb_lastname.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "LAST NAME:";
            // 
            // txb_name
            // 
            this.txb_name.Location = new System.Drawing.Point(87, 80);
            this.txb_name.Margin = new System.Windows.Forms.Padding(4);
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(211, 22);
            this.txb_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "NAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "RESERVATION:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "RESERVATION:";
            // 
            // txb_idreserva
            // 
            this.txb_idreserva.Enabled = false;
            this.txb_idreserva.Location = new System.Drawing.Point(165, 37);
            this.txb_idreserva.Margin = new System.Windows.Forms.Padding(4);
            this.txb_idreserva.Name = "txb_idreserva";
            this.txb_idreserva.Size = new System.Drawing.Size(132, 22);
            this.txb_idreserva.TabIndex = 0;
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(155, 41);
            this.btn_import.Margin = new System.Windows.Forms.Padding(4);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(43, 38);
            this.btn_import.TabIndex = 48;
            this.btn_import.Text = "import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Visible = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(11, 79);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(315, 42);
            this.btn_export.TabIndex = 19;
            this.btn_export.Text = "Send Dropzone";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(216, 18);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(109, 94);
            this.btn_exit.TabIndex = 19;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(127, 27);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 33);
            this.comboBox1.TabIndex = 42;
            this.comboBox1.Visible = false;
            // 
            // lbl_dropzone
            // 
            this.lbl_dropzone.AutoSize = true;
            this.lbl_dropzone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dropzone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_dropzone.Location = new System.Drawing.Point(13, 36);
            this.lbl_dropzone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_dropzone.Name = "lbl_dropzone";
            this.lbl_dropzone.Size = new System.Drawing.Size(91, 17);
            this.lbl_dropzone.TabIndex = 41;
            this.lbl_dropzone.Text = "DROPZONE:";
            this.lbl_dropzone.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gray;
            this.groupBox2.Controls.Add(this.btn_filter);
            this.groupBox2.Controls.Add(this.txb_filtro_nombre);
            this.groupBox2.Controls.Add(this.dp_gridinfo);
            this.groupBox2.Controls.Add(this.btn_reporte);
            this.groupBox2.Controls.Add(this.lbl_numreserva);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.lbl_dropzone);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(312, 258);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // btn_filter
            // 
            this.btn_filter.Location = new System.Drawing.Point(199, 146);
            this.btn_filter.Margin = new System.Windows.Forms.Padding(4);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(83, 39);
            this.btn_filter.TabIndex = 45;
            this.btn_filter.Text = "Find";
            this.btn_filter.UseVisualStyleBackColor = true;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // txb_filtro_nombre
            // 
            this.txb_filtro_nombre.Location = new System.Drawing.Point(17, 150);
            this.txb_filtro_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txb_filtro_nombre.Name = "txb_filtro_nombre";
            this.txb_filtro_nombre.Size = new System.Drawing.Size(172, 30);
            this.txb_filtro_nombre.TabIndex = 44;
            // 
            // dp_gridinfo
            // 
            this.dp_gridinfo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_gridinfo.Location = new System.Drawing.Point(17, 102);
            this.dp_gridinfo.Margin = new System.Windows.Forms.Padding(4);
            this.dp_gridinfo.Name = "dp_gridinfo";
            this.dp_gridinfo.Size = new System.Drawing.Size(172, 30);
            this.dp_gridinfo.TabIndex = 43;
            this.dp_gridinfo.ValueChanged += new System.EventHandler(this.dp_gridinfo_ValueChanged);
            // 
            // btn_reporte
            // 
            this.btn_reporte.BackColor = System.Drawing.Color.Plum;
            this.btn_reporte.Location = new System.Drawing.Point(20, 202);
            this.btn_reporte.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(261, 39);
            this.btn_reporte.TabIndex = 2;
            this.btn_reporte.Text = "Generate Report";
            this.btn_reporte.UseVisualStyleBackColor = false;
            this.btn_reporte.Click += new System.EventHandler(this.btn_reporte_Click);
            // 
            // lbl_numreserva
            // 
            this.lbl_numreserva.AutoSize = true;
            this.lbl_numreserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numreserva.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_numreserva.Location = new System.Drawing.Point(239, 65);
            this.lbl_numreserva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_numreserva.Name = "lbl_numreserva";
            this.lbl_numreserva.Size = new System.Drawing.Size(60, 25);
            this.lbl_numreserva.TabIndex = 1;
            this.lbl_numreserva.Text = "9999";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(15, 65);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Pending reservations:";
            // 
            // tmr_import
            // 
            this.tmr_import.Tick += new System.EventHandler(this.tmr_import_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.dp_fin);
            this.groupBox5.Controls.Add(this.dp_ini);
            this.groupBox5.Controls.Add(this.btn_export);
            this.groupBox5.Location = new System.Drawing.Point(1648, 134);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(337, 132);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Send to dropzone";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(153, 33);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 17);
            this.label21.TabIndex = 51;
            this.label21.Text = "TO";
            // 
            // dp_fin
            // 
            this.dp_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fin.Location = new System.Drawing.Point(216, 30);
            this.dp_fin.Margin = new System.Windows.Forms.Padding(4);
            this.dp_fin.Name = "dp_fin";
            this.dp_fin.Size = new System.Drawing.Size(104, 22);
            this.dp_fin.TabIndex = 50;
            // 
            // dp_ini
            // 
            this.dp_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_ini.Location = new System.Drawing.Point(11, 30);
            this.dp_ini.Margin = new System.Windows.Forms.Padding(4);
            this.dp_ini.Name = "dp_ini";
            this.dp_ini.Size = new System.Drawing.Size(133, 22);
            this.dp_ini.TabIndex = 49;
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_create.Location = new System.Drawing.Point(16, 18);
            this.btn_create.Margin = new System.Windows.Forms.Padding(4);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(157, 94);
            this.btn_create.TabIndex = 19;
            this.btn_create.Text = "Generate Reservation";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_create);
            this.groupBox6.Controls.Add(this.btn_exit);
            this.groupBox6.Controls.Add(this.btn_import);
            this.groupBox6.Location = new System.Drawing.Point(1648, 7);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(337, 119);
            this.groupBox6.TabIndex = 52;
            this.groupBox6.TabStop = false;
            // 
            // Frm_Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1989, 778);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Reserva";
            this.Text = "Reservations";
            this.Load += new System.EventHandler(this.Frm_Reserva_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_contacts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_contacts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.TextBox txb_vendor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dp_jumpdate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txb_metodo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txb_deposit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txb_note;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txb_card;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_mobile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_workphone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_homephone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dp_follow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_lastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_idreserva;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txb_personas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txb_priceorg;
        private System.Windows.Forms.DateTimePicker dp_reserva;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbl_dropzone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_numreserva;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.TextBox dp_horario;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dp_schedule;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Timer tmr_import;
        private System.Windows.Forms.DateTimePicker dp_gridinfo;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.TextBox txb_filtro_nombre;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dp_fin;
        private System.Windows.Forms.DateTimePicker dp_ini;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox6;

    }
}