namespace SkyDiveCuautla.Operacion
{
    partial class Frm_PreManifest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_instructor = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_premanifest = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_instructores = new System.Windows.Forms.DataGridView();
            this.grb_edit = new System.Windows.Forms.GroupBox();
            this.chb_videorent = new System.Windows.Forms.CheckBox();
            this.txb_height = new System.Windows.Forms.TextBox();
            this.lbl_height = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_weight = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_jumptype2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_jumptype2 = new System.Windows.Forms.ComboBox();
            this.cmb_jumptype1 = new System.Windows.Forms.ComboBox();
            this.chk_handvideo = new System.Windows.Forms.CheckBox();
            this.chk_video = new System.Windows.Forms.CheckBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.txb_sequence = new System.Windows.Forms.TextBox();
            this.lbl_sequence = new System.Windows.Forms.Label();
            this.btn_premanifested = new System.Windows.Forms.Button();
            this.lbl_idjumper2 = new System.Windows.Forms.Label();
            this.lbl_idjumper1 = new System.Windows.Forms.Label();
            this.cmb_instructor2 = new System.Windows.Forms.ComboBox();
            this.cmb_instructor1 = new System.Windows.Forms.ComboBox();
            this.lbl_instructor2 = new System.Windows.Forms.Label();
            this.lbl_instructor1 = new System.Windows.Forms.Label();
            this.lbl_idjumptype = new System.Windows.Forms.Label();
            this.lbl_Jumptype = new System.Windows.Forms.Label();
            this.txb_jumptype = new System.Windows.Forms.TextBox();
            this.txb_flight = new System.Windows.Forms.TextBox();
            this.lbl_flight = new System.Windows.Forms.Label();
            this.txb_tandemname = new System.Windows.Forms.TextBox();
            this.lbl_idtandem = new System.Windows.Forms.Label();
            this.lbl_tandemname = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dg_premanifestdetail = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_premanifest)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_instructores)).BeginInit();
            this.grb_edit.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_premanifestdetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.btn_refresh);
            this.groupBox1.Controls.Add(this.btn_instructor);
            this.groupBox1.Controls.Add(this.btn_import);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1248, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::SkyDiveCuautla.Properties.Resources.parachute_silver;
            this.btn_refresh.Location = new System.Drawing.Point(708, 9);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(52, 36);
            this.btn_refresh.TabIndex = 53;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_instructor
            // 
            this.btn_instructor.Location = new System.Drawing.Point(1079, 13);
            this.btn_instructor.Name = "btn_instructor";
            this.btn_instructor.Size = new System.Drawing.Size(134, 32);
            this.btn_instructor.TabIndex = 3;
            this.btn_instructor.Text = "Instructors Blackboard";
            this.btn_instructor.UseVisualStyleBackColor = true;
            this.btn_instructor.Visible = false;
            this.btn_instructor.Click += new System.EventHandler(this.btn_instructor_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(825, 19);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(147, 24);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "Import Selection";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Visible = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1232, 13);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 32);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pre Manifest";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_premanifest);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 291);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TandemUp";
            // 
            // dg_premanifest
            // 
            this.dg_premanifest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_premanifest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_premanifest.Location = new System.Drawing.Point(10, 19);
            this.dg_premanifest.Name = "dg_premanifest";
            this.dg_premanifest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_premanifest.Size = new System.Drawing.Size(749, 266);
            this.dg_premanifest.TabIndex = 0;
            this.dg_premanifest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_premanifest_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dg_instructores);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(770, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 310);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instructors";
            // 
            // dg_instructores
            // 
            this.dg_instructores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_instructores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_instructores.Location = new System.Drawing.Point(6, 19);
            this.dg_instructores.Name = "dg_instructores";
            this.dg_instructores.Size = new System.Drawing.Size(460, 285);
            this.dg_instructores.TabIndex = 0;
            // 
            // grb_edit
            // 
            this.grb_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_edit.Controls.Add(this.chb_videorent);
            this.grb_edit.Controls.Add(this.txb_height);
            this.grb_edit.Controls.Add(this.lbl_height);
            this.grb_edit.Controls.Add(this.label3);
            this.grb_edit.Controls.Add(this.txb_weight);
            this.grb_edit.Controls.Add(this.btn_clear);
            this.grb_edit.Controls.Add(this.lbl_jumptype2);
            this.grb_edit.Controls.Add(this.label2);
            this.grb_edit.Controls.Add(this.cmb_jumptype2);
            this.grb_edit.Controls.Add(this.cmb_jumptype1);
            this.grb_edit.Controls.Add(this.chk_handvideo);
            this.grb_edit.Controls.Add(this.chk_video);
            this.grb_edit.Controls.Add(this.btn_save);
            this.grb_edit.Controls.Add(this.txb_sequence);
            this.grb_edit.Controls.Add(this.lbl_sequence);
            this.grb_edit.Controls.Add(this.btn_premanifested);
            this.grb_edit.Controls.Add(this.lbl_idjumper2);
            this.grb_edit.Controls.Add(this.lbl_idjumper1);
            this.grb_edit.Controls.Add(this.cmb_instructor2);
            this.grb_edit.Controls.Add(this.cmb_instructor1);
            this.grb_edit.Controls.Add(this.lbl_instructor2);
            this.grb_edit.Controls.Add(this.lbl_instructor1);
            this.grb_edit.Controls.Add(this.lbl_idjumptype);
            this.grb_edit.Controls.Add(this.lbl_Jumptype);
            this.grb_edit.Controls.Add(this.txb_jumptype);
            this.grb_edit.Controls.Add(this.txb_flight);
            this.grb_edit.Controls.Add(this.lbl_flight);
            this.grb_edit.Controls.Add(this.txb_tandemname);
            this.grb_edit.Controls.Add(this.lbl_idtandem);
            this.grb_edit.Controls.Add(this.lbl_tandemname);
            this.grb_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_edit.Location = new System.Drawing.Point(770, 366);
            this.grb_edit.Name = "grb_edit";
            this.grb_edit.Size = new System.Drawing.Size(472, 257);
            this.grb_edit.TabIndex = 3;
            this.grb_edit.TabStop = false;
            this.grb_edit.Text = "TandemUp to PreManifest";
            // 
            // chb_videorent
            // 
            this.chb_videorent.AutoSize = true;
            this.chb_videorent.Location = new System.Drawing.Point(393, 85);
            this.chb_videorent.Name = "chb_videorent";
            this.chb_videorent.Size = new System.Drawing.Size(79, 17);
            this.chb_videorent.TabIndex = 29;
            this.chb_videorent.Text = "Video Rent";
            this.chb_videorent.UseVisualStyleBackColor = true;
            // 
            // txb_height
            // 
            this.txb_height.Location = new System.Drawing.Point(491, 22);
            this.txb_height.Name = "txb_height";
            this.txb_height.ReadOnly = true;
            this.txb_height.Size = new System.Drawing.Size(76, 20);
            this.txb_height.TabIndex = 28;
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(425, 25);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(39, 13);
            this.lbl_height.TabIndex = 27;
            this.lbl_height.Text = "Altitud:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Weight :";
            // 
            // txb_weight
            // 
            this.txb_weight.Location = new System.Drawing.Point(508, 48);
            this.txb_weight.Name = "txb_weight";
            this.txb_weight.ReadOnly = true;
            this.txb_weight.Size = new System.Drawing.Size(58, 20);
            this.txb_weight.TabIndex = 25;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(491, 178);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 47);
            this.btn_clear.TabIndex = 24;
            this.btn_clear.Text = "Clear Fields";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lbl_jumptype2
            // 
            this.lbl_jumptype2.AutoSize = true;
            this.lbl_jumptype2.Location = new System.Drawing.Point(354, 148);
            this.lbl_jumptype2.Name = "lbl_jumptype2";
            this.lbl_jumptype2.Size = new System.Drawing.Size(62, 13);
            this.lbl_jumptype2.TabIndex = 23;
            this.lbl_jumptype2.Text = "Jump Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Jump Type:";
            // 
            // cmb_jumptype2
            // 
            this.cmb_jumptype2.FormattingEnabled = true;
            this.cmb_jumptype2.Location = new System.Drawing.Point(422, 145);
            this.cmb_jumptype2.Name = "cmb_jumptype2";
            this.cmb_jumptype2.Size = new System.Drawing.Size(145, 21);
            this.cmb_jumptype2.TabIndex = 5;
            // 
            // cmb_jumptype1
            // 
            this.cmb_jumptype1.FormattingEnabled = true;
            this.cmb_jumptype1.Location = new System.Drawing.Point(422, 112);
            this.cmb_jumptype1.Name = "cmb_jumptype1";
            this.cmb_jumptype1.Size = new System.Drawing.Size(145, 21);
            this.cmb_jumptype1.TabIndex = 3;
            // 
            // chk_handvideo
            // 
            this.chk_handvideo.AutoSize = true;
            this.chk_handvideo.Enabled = false;
            this.chk_handvideo.Location = new System.Drawing.Point(305, 85);
            this.chk_handvideo.Name = "chk_handvideo";
            this.chk_handvideo.Size = new System.Drawing.Size(82, 17);
            this.chk_handvideo.TabIndex = 19;
            this.chk_handvideo.Text = "Hand Video";
            this.chk_handvideo.UseVisualStyleBackColor = true;
            // 
            // chk_video
            // 
            this.chk_video.AutoSize = true;
            this.chk_video.Enabled = false;
            this.chk_video.Location = new System.Drawing.Point(246, 85);
            this.chk_video.Name = "chk_video";
            this.chk_video.Size = new System.Drawing.Size(53, 17);
            this.chk_video.TabIndex = 18;
            this.chk_video.Text = "Video";
            this.chk_video.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(121, 184);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(98, 41);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txb_sequence
            // 
            this.txb_sequence.Location = new System.Drawing.Point(95, 19);
            this.txb_sequence.Name = "txb_sequence";
            this.txb_sequence.ReadOnly = true;
            this.txb_sequence.Size = new System.Drawing.Size(84, 20);
            this.txb_sequence.TabIndex = 16;
            // 
            // lbl_sequence
            // 
            this.lbl_sequence.AutoSize = true;
            this.lbl_sequence.Location = new System.Drawing.Point(19, 22);
            this.lbl_sequence.Name = "lbl_sequence";
            this.lbl_sequence.Size = new System.Drawing.Size(59, 13);
            this.lbl_sequence.TabIndex = 15;
            this.lbl_sequence.Text = "Sequence:";
            // 
            // btn_premanifested
            // 
            this.btn_premanifested.Location = new System.Drawing.Point(7, 184);
            this.btn_premanifested.Name = "btn_premanifested";
            this.btn_premanifested.Size = new System.Drawing.Size(98, 41);
            this.btn_premanifested.TabIndex = 14;
            this.btn_premanifested.Text = "<-- Pre Manifest";
            this.btn_premanifested.UseVisualStyleBackColor = true;
            this.btn_premanifested.Click += new System.EventHandler(this.btn_premanifested_Click);
            // 
            // lbl_idjumper2
            // 
            this.lbl_idjumper2.AutoSize = true;
            this.lbl_idjumper2.Location = new System.Drawing.Point(14, 161);
            this.lbl_idjumper2.Name = "lbl_idjumper2";
            this.lbl_idjumper2.Size = new System.Drawing.Size(52, 13);
            this.lbl_idjumper2.TabIndex = 13;
            this.lbl_idjumper2.Text = "idjumper2";
            this.lbl_idjumper2.Visible = false;
            // 
            // lbl_idjumper1
            // 
            this.lbl_idjumper1.AutoSize = true;
            this.lbl_idjumper1.Location = new System.Drawing.Point(14, 128);
            this.lbl_idjumper1.Name = "lbl_idjumper1";
            this.lbl_idjumper1.Size = new System.Drawing.Size(52, 13);
            this.lbl_idjumper1.TabIndex = 12;
            this.lbl_idjumper1.Text = "idjumper1";
            this.lbl_idjumper1.Visible = false;
            // 
            // cmb_instructor2
            // 
            this.cmb_instructor2.FormattingEnabled = true;
            this.cmb_instructor2.Location = new System.Drawing.Point(95, 145);
            this.cmb_instructor2.Name = "cmb_instructor2";
            this.cmb_instructor2.Size = new System.Drawing.Size(247, 21);
            this.cmb_instructor2.TabIndex = 4;
            this.cmb_instructor2.SelectionChangeCommitted += new System.EventHandler(this.cmb_instructor2_SelectionChangeCommitted);
            // 
            // cmb_instructor1
            // 
            this.cmb_instructor1.FormattingEnabled = true;
            this.cmb_instructor1.Location = new System.Drawing.Point(95, 112);
            this.cmb_instructor1.Name = "cmb_instructor1";
            this.cmb_instructor1.Size = new System.Drawing.Size(247, 21);
            this.cmb_instructor1.TabIndex = 2;
            this.cmb_instructor1.SelectedIndexChanged += new System.EventHandler(this.cmb_instructor1_SelectedIndexChanged);
            this.cmb_instructor1.SelectionChangeCommitted += new System.EventHandler(this.cmb_instructor1_SelectionChangeCommitted);
            // 
            // lbl_instructor2
            // 
            this.lbl_instructor2.AutoSize = true;
            this.lbl_instructor2.Location = new System.Drawing.Point(14, 148);
            this.lbl_instructor2.Name = "lbl_instructor2";
            this.lbl_instructor2.Size = new System.Drawing.Size(64, 13);
            this.lbl_instructor2.TabIndex = 9;
            this.lbl_instructor2.Text = "Instructor B:";
            // 
            // lbl_instructor1
            // 
            this.lbl_instructor1.AutoSize = true;
            this.lbl_instructor1.Location = new System.Drawing.Point(14, 115);
            this.lbl_instructor1.Name = "lbl_instructor1";
            this.lbl_instructor1.Size = new System.Drawing.Size(64, 13);
            this.lbl_instructor1.TabIndex = 8;
            this.lbl_instructor1.Text = "Instructor A:";
            // 
            // lbl_idjumptype
            // 
            this.lbl_idjumptype.AutoSize = true;
            this.lbl_idjumptype.Location = new System.Drawing.Point(201, 86);
            this.lbl_idjumptype.Name = "lbl_idjumptype";
            this.lbl_idjumptype.Size = new System.Drawing.Size(63, 13);
            this.lbl_idjumptype.TabIndex = 7;
            this.lbl_idjumptype.Text = "id_jumptype";
            this.lbl_idjumptype.Visible = false;
            // 
            // lbl_Jumptype
            // 
            this.lbl_Jumptype.AutoSize = true;
            this.lbl_Jumptype.Location = new System.Drawing.Point(14, 86);
            this.lbl_Jumptype.Name = "lbl_Jumptype";
            this.lbl_Jumptype.Size = new System.Drawing.Size(62, 13);
            this.lbl_Jumptype.TabIndex = 6;
            this.lbl_Jumptype.Text = "Jump Type:";
            // 
            // txb_jumptype
            // 
            this.txb_jumptype.Location = new System.Drawing.Point(95, 83);
            this.txb_jumptype.Name = "txb_jumptype";
            this.txb_jumptype.ReadOnly = true;
            this.txb_jumptype.Size = new System.Drawing.Size(100, 20);
            this.txb_jumptype.TabIndex = 5;
            // 
            // txb_flight
            // 
            this.txb_flight.Location = new System.Drawing.Point(245, 19);
            this.txb_flight.Name = "txb_flight";
            this.txb_flight.Size = new System.Drawing.Size(142, 20);
            this.txb_flight.TabIndex = 1;
            // 
            // lbl_flight
            // 
            this.lbl_flight.AutoSize = true;
            this.lbl_flight.Location = new System.Drawing.Point(200, 22);
            this.lbl_flight.Name = "lbl_flight";
            this.lbl_flight.Size = new System.Drawing.Size(39, 13);
            this.lbl_flight.TabIndex = 3;
            this.lbl_flight.Text = "Group:";
            // 
            // txb_tandemname
            // 
            this.txb_tandemname.Location = new System.Drawing.Point(95, 52);
            this.txb_tandemname.Name = "txb_tandemname";
            this.txb_tandemname.ReadOnly = true;
            this.txb_tandemname.Size = new System.Drawing.Size(247, 20);
            this.txb_tandemname.TabIndex = 2;
            // 
            // lbl_idtandem
            // 
            this.lbl_idtandem.AutoSize = true;
            this.lbl_idtandem.Location = new System.Drawing.Point(488, 83);
            this.lbl_idtandem.Name = "lbl_idtandem";
            this.lbl_idtandem.Size = new System.Drawing.Size(50, 13);
            this.lbl_idtandem.TabIndex = 1;
            this.lbl_idtandem.Text = "idtandem";
            this.lbl_idtandem.Visible = false;
            // 
            // lbl_tandemname
            // 
            this.lbl_tandemname.AutoSize = true;
            this.lbl_tandemname.Location = new System.Drawing.Point(11, 55);
            this.lbl_tandemname.Name = "lbl_tandemname";
            this.lbl_tandemname.Size = new System.Drawing.Size(78, 13);
            this.lbl_tandemname.TabIndex = 0;
            this.lbl_tandemname.Text = "Tandem name:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.dg_premanifestdetail);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(2, 352);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(764, 271);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PreManifest";
            // 
            // dg_premanifestdetail
            // 
            this.dg_premanifestdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_premanifestdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_premanifestdetail.Location = new System.Drawing.Point(7, 18);
            this.dg_premanifestdetail.Name = "dg_premanifestdetail";
            this.dg_premanifestdetail.Size = new System.Drawing.Size(751, 245);
            this.dg_premanifestdetail.TabIndex = 0;
            this.dg_premanifestdetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_premanifestdetail_CellClick);
            // 
            // Frm_PreManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1248, 631);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grb_edit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_PreManifest";
            this.Text = "Pre Manifest";
            this.Load += new System.EventHandler(this.Frm_PreManifest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_premanifest)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_instructores)).EndInit();
            this.grb_edit.ResumeLayout(false);
            this.grb_edit.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_premanifestdetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_premanifest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_instructores;
        private System.Windows.Forms.GroupBox grb_edit;
        private System.Windows.Forms.Label lbl_idtandem;
        private System.Windows.Forms.Label lbl_tandemname;
        private System.Windows.Forms.TextBox txb_tandemname;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txb_jumptype;
        private System.Windows.Forms.TextBox txb_flight;
        private System.Windows.Forms.Label lbl_flight;
        private System.Windows.Forms.Label lbl_idjumptype;
        private System.Windows.Forms.Label lbl_Jumptype;
        private System.Windows.Forms.ComboBox cmb_instructor2;
        private System.Windows.Forms.ComboBox cmb_instructor1;
        private System.Windows.Forms.Label lbl_instructor2;
        private System.Windows.Forms.Label lbl_instructor1;
        private System.Windows.Forms.Label lbl_idjumper2;
        private System.Windows.Forms.Label lbl_idjumper1;
        private System.Windows.Forms.Button btn_premanifested;
        private System.Windows.Forms.DataGridView dg_premanifestdetail;
        private System.Windows.Forms.Button btn_instructor;
        private System.Windows.Forms.TextBox txb_sequence;
        private System.Windows.Forms.Label lbl_sequence;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_jumptype2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_jumptype2;
        private System.Windows.Forms.ComboBox cmb_jumptype1;
        private System.Windows.Forms.CheckBox chk_handvideo;
        private System.Windows.Forms.CheckBox chk_video;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_weight;
        private System.Windows.Forms.TextBox txb_height;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.CheckBox chb_videorent;
        private System.Windows.Forms.Button btn_refresh;
    }
}