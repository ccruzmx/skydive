namespace SkyDiveCuautla.Operacion
{
    partial class Frm_Instructors
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
            this.btn_blackboard = new System.Windows.Forms.Button();
            this.lbl_registertime = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_videorent = new System.Windows.Forms.CheckBox();
            this.txb_seq = new System.Windows.Forms.TextBox();
            this.lbl_jumpsrejected = new System.Windows.Forms.Label();
            this.txb_jumpsrejected = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.chk_tandem = new System.Windows.Forms.CheckBox();
            this.chk_videomano = new System.Windows.Forms.CheckBox();
            this.chk_video = new System.Windows.Forms.CheckBox();
            this.lbl_instructor = new System.Windows.Forms.Label();
            this.cmb_instructor = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_instructors = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_instructors)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.btn_blackboard);
            this.groupBox1.Controls.Add(this.lbl_registertime);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1219, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_blackboard
            // 
            this.btn_blackboard.Location = new System.Drawing.Point(716, 19);
            this.btn_blackboard.Name = "btn_blackboard";
            this.btn_blackboard.Size = new System.Drawing.Size(75, 67);
            this.btn_blackboard.TabIndex = 6;
            this.btn_blackboard.Text = "Blackboard";
            this.btn_blackboard.UseVisualStyleBackColor = true;
            this.btn_blackboard.Click += new System.EventHandler(this.btn_blackboard_Click);
            // 
            // lbl_registertime
            // 
            this.lbl_registertime.AutoSize = true;
            this.lbl_registertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_registertime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_registertime.Location = new System.Drawing.Point(569, 19);
            this.lbl_registertime.Name = "lbl_registertime";
            this.lbl_registertime.Size = new System.Drawing.Size(117, 24);
            this.lbl_registertime.TabIndex = 2;
            this.lbl_registertime.Text = "RegisterDate";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(813, 19);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 67);
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
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instructors Registry";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chk_videorent);
            this.groupBox2.Controls.Add(this.txb_seq);
            this.groupBox2.Controls.Add(this.lbl_jumpsrejected);
            this.groupBox2.Controls.Add(this.txb_jumpsrejected);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.chk_tandem);
            this.groupBox2.Controls.Add(this.chk_videomano);
            this.groupBox2.Controls.Add(this.chk_video);
            this.groupBox2.Controls.Add(this.lbl_instructor);
            this.groupBox2.Controls.Add(this.cmb_instructor);
            this.groupBox2.Location = new System.Drawing.Point(-1, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1219, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // chk_videorent
            // 
            this.chk_videorent.AutoSize = true;
            this.chk_videorent.Location = new System.Drawing.Point(550, 26);
            this.chk_videorent.Name = "chk_videorent";
            this.chk_videorent.Size = new System.Drawing.Size(79, 17);
            this.chk_videorent.TabIndex = 9;
            this.chk_videorent.Text = "Video Rent";
            this.chk_videorent.UseVisualStyleBackColor = true;
            this.chk_videorent.CheckedChanged += new System.EventHandler(this.chk_videorent_CheckedChanged);
            // 
            // txb_seq
            // 
            this.txb_seq.Location = new System.Drawing.Point(14, 27);
            this.txb_seq.Name = "txb_seq";
            this.txb_seq.Size = new System.Drawing.Size(44, 20);
            this.txb_seq.TabIndex = 8;
            this.txb_seq.Visible = false;
            // 
            // lbl_jumpsrejected
            // 
            this.lbl_jumpsrejected.AutoSize = true;
            this.lbl_jumpsrejected.Location = new System.Drawing.Point(731, 27);
            this.lbl_jumpsrejected.Name = "lbl_jumpsrejected";
            this.lbl_jumpsrejected.Size = new System.Drawing.Size(81, 13);
            this.lbl_jumpsrejected.TabIndex = 7;
            this.lbl_jumpsrejected.Text = "Jumps rejected:";
            // 
            // txb_jumpsrejected
            // 
            this.txb_jumpsrejected.Location = new System.Drawing.Point(818, 25);
            this.txb_jumpsrejected.Name = "txb_jumpsrejected";
            this.txb_jumpsrejected.Size = new System.Drawing.Size(44, 20);
            this.txb_jumpsrejected.TabIndex = 6;
            this.txb_jumpsrejected.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_jumpsrejected_KeyPress);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(881, 10);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 46);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "&Registry";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // chk_tandem
            // 
            this.chk_tandem.AutoSize = true;
            this.chk_tandem.Location = new System.Drawing.Point(635, 27);
            this.chk_tandem.Name = "chk_tandem";
            this.chk_tandem.Size = new System.Drawing.Size(65, 17);
            this.chk_tandem.TabIndex = 4;
            this.chk_tandem.Text = "Tandem";
            this.chk_tandem.UseVisualStyleBackColor = true;
            // 
            // chk_videomano
            // 
            this.chk_videomano.AutoSize = true;
            this.chk_videomano.Location = new System.Drawing.Point(462, 25);
            this.chk_videomano.Name = "chk_videomano";
            this.chk_videomano.Size = new System.Drawing.Size(82, 17);
            this.chk_videomano.TabIndex = 3;
            this.chk_videomano.Text = "Hand Video";
            this.chk_videomano.UseVisualStyleBackColor = true;
            this.chk_videomano.CheckedChanged += new System.EventHandler(this.chk_videomano_CheckedChanged);
            // 
            // chk_video
            // 
            this.chk_video.AutoSize = true;
            this.chk_video.Location = new System.Drawing.Point(391, 26);
            this.chk_video.Name = "chk_video";
            this.chk_video.Size = new System.Drawing.Size(53, 17);
            this.chk_video.TabIndex = 2;
            this.chk_video.Text = "Video";
            this.chk_video.UseVisualStyleBackColor = true;
            // 
            // lbl_instructor
            // 
            this.lbl_instructor.AutoSize = true;
            this.lbl_instructor.Location = new System.Drawing.Point(64, 27);
            this.lbl_instructor.Name = "lbl_instructor";
            this.lbl_instructor.Size = new System.Drawing.Size(60, 13);
            this.lbl_instructor.TabIndex = 1;
            this.lbl_instructor.Text = "Instructor : ";
            // 
            // cmb_instructor
            // 
            this.cmb_instructor.FormattingEnabled = true;
            this.cmb_instructor.Location = new System.Drawing.Point(130, 23);
            this.cmb_instructor.Name = "cmb_instructor";
            this.cmb_instructor.Size = new System.Drawing.Size(242, 21);
            this.cmb_instructor.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dg_instructors);
            this.groupBox3.Location = new System.Drawing.Point(-1, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1219, 450);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dg_instructors
            // 
            this.dg_instructors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_instructors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_instructors.Location = new System.Drawing.Point(6, 19);
            this.dg_instructors.Name = "dg_instructors";
            this.dg_instructors.Size = new System.Drawing.Size(1207, 422);
            this.dg_instructors.TabIndex = 0;
            this.dg_instructors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_instructors_CellClick);
            this.dg_instructors.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dg_instructors_UserDeletedRow);
            this.dg_instructors.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_instructors_UserDeletingRow);
            // 
            // Frm_Instructors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1220, 634);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Instructors";
            this.Text = "Frm_Instructors";
            this.Load += new System.EventHandler(this.Frm_Instructors_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_instructors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_instructors;
        private System.Windows.Forms.CheckBox chk_tandem;
        private System.Windows.Forms.CheckBox chk_videomano;
        private System.Windows.Forms.CheckBox chk_video;
        private System.Windows.Forms.Label lbl_instructor;
        private System.Windows.Forms.ComboBox cmb_instructor;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_registertime;
        private System.Windows.Forms.Button btn_blackboard;
        private System.Windows.Forms.TextBox txb_jumpsrejected;
        private System.Windows.Forms.Label lbl_jumpsrejected;
        private System.Windows.Forms.TextBox txb_seq;
        private System.Windows.Forms.CheckBox chk_videorent;
    }
}