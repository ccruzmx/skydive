namespace BIXOLON_Sample_program
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrtList = new System.Windows.Forms.ComboBox();
            this.btnResearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDllVersion = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtP_Height = new System.Windows.Forms.TextBox();
            this.txtP_Width = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMargin_Y = new System.Windows.Forms.TextBox();
            this.txtMargin_X = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDensity = new System.Windows.Forms.ComboBox();
            this.chkCutter = new System.Windows.Forms.CheckBox();
            this.chkRevFeeding = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoTt = new System.Windows.Forms.RadioButton();
            this.rdoDt = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoContinuous = new System.Windows.Forms.RadioButton();
            this.rdoBmark = new System.Windows.Forms.RadioButton();
            this.rdoGap = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIXOLON Printer list";
            // 
            // cmbPrtList
            // 
            this.cmbPrtList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrtList.FormattingEnabled = true;
            this.cmbPrtList.ItemHeight = 16;
            this.cmbPrtList.Location = new System.Drawing.Point(166, 49);
            this.cmbPrtList.Name = "cmbPrtList";
            this.cmbPrtList.Size = new System.Drawing.Size(222, 24);
            this.cmbPrtList.TabIndex = 1;
            // 
            // btnResearch
            // 
            this.btnResearch.Location = new System.Drawing.Point(403, 47);
            this.btnResearch.Name = "btnResearch";
            this.btnResearch.Size = new System.Drawing.Size(211, 28);
            this.btnResearch.TabIndex = 2;
            this.btnResearch.Text = "Search-Installed Printer";
            this.btnResearch.UseVisualStyleBackColor = true;
            this.btnResearch.Click += new System.EventHandler(this.btnResearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "DLL Version : ";
            // 
            // lblDllVersion
            // 
            this.lblDllVersion.Location = new System.Drawing.Point(121, 18);
            this.lblDllVersion.Name = "lblDllVersion";
            this.lblDllVersion.Size = new System.Drawing.Size(222, 20);
            this.lblDllVersion.TabIndex = 4;
            this.lblDllVersion.Text = "Version ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(174, 316);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(288, 51);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print Ticket";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Density";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Height";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtP_Height);
            this.groupBox1.Controls.Add(this.txtP_Width);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(13, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 97);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paper Size ( Unit : mm )";
            // 
            // txtP_Height
            // 
            this.txtP_Height.Location = new System.Drawing.Point(99, 63);
            this.txtP_Height.Name = "txtP_Height";
            this.txtP_Height.Size = new System.Drawing.Size(82, 23);
            this.txtP_Height.TabIndex = 11;
            this.txtP_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_Height_KeyPress);
            // 
            // txtP_Width
            // 
            this.txtP_Width.Location = new System.Drawing.Point(99, 29);
            this.txtP_Width.Name = "txtP_Width";
            this.txtP_Width.Size = new System.Drawing.Size(82, 23);
            this.txtP_Width.TabIndex = 10;
            this.txtP_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_Width_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMargin_Y);
            this.groupBox2.Controls.Add(this.txtMargin_X);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(223, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 97);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Margins ( Unit : mm )";
            // 
            // txtMargin_Y
            // 
            this.txtMargin_Y.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMargin_Y.Location = new System.Drawing.Point(99, 63);
            this.txtMargin_Y.Name = "txtMargin_Y";
            this.txtMargin_Y.Size = new System.Drawing.Size(82, 23);
            this.txtMargin_Y.TabIndex = 11;
            this.txtMargin_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_Y_KeyPress);
            // 
            // txtMargin_X
            // 
            this.txtMargin_X.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMargin_X.Location = new System.Drawing.Point(99, 29);
            this.txtMargin_X.Name = "txtMargin_X";
            this.txtMargin_X.Size = new System.Drawing.Size(82, 23);
            this.txtMargin_X.TabIndex = 10;
            this.txtMargin_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_X_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Y margin";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "X margin";
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "2.5",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbSpeed.Location = new System.Drawing.Point(90, 27);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(63, 24);
            this.cmbSpeed.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "ips";
            // 
            // cmbDensity
            // 
            this.cmbDensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDensity.FormattingEnabled = true;
            this.cmbDensity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbDensity.Location = new System.Drawing.Point(90, 62);
            this.cmbDensity.Name = "cmbDensity";
            this.cmbDensity.Size = new System.Drawing.Size(63, 24);
            this.cmbDensity.TabIndex = 15;
            // 
            // chkCutter
            // 
            this.chkCutter.AutoSize = true;
            this.chkCutter.Location = new System.Drawing.Point(18, 31);
            this.chkCutter.Name = "chkCutter";
            this.chkCutter.Size = new System.Drawing.Size(69, 20);
            this.chkCutter.TabIndex = 16;
            this.chkCutter.Text = "Cutter";
            this.chkCutter.UseVisualStyleBackColor = true;
            // 
            // chkRevFeeding
            // 
            this.chkRevFeeding.AutoSize = true;
            this.chkRevFeeding.Checked = true;
            this.chkRevFeeding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRevFeeding.Location = new System.Drawing.Point(18, 61);
            this.chkRevFeeding.Name = "chkRevFeeding";
            this.chkRevFeeding.Size = new System.Drawing.Size(134, 20);
            this.chkRevFeeding.TabIndex = 17;
            this.chkRevFeeding.Text = "Reverse-feeding";
            this.chkRevFeeding.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbDensity);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cmbSpeed);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(435, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 97);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Speed / Density";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkRevFeeding);
            this.groupBox4.Controls.Add(this.chkCutter);
            this.groupBox4.Location = new System.Drawing.Point(435, 200);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 103);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Etc";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoTt);
            this.groupBox5.Controls.Add(this.rdoDt);
            this.groupBox5.Location = new System.Drawing.Point(13, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(206, 103);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Media type";
            // 
            // rdoTt
            // 
            this.rdoTt.AutoSize = true;
            this.rdoTt.Location = new System.Drawing.Point(18, 61);
            this.rdoTt.Name = "rdoTt";
            this.rdoTt.Size = new System.Drawing.Size(135, 20);
            this.rdoTt.TabIndex = 1;
            this.rdoTt.Text = "Thermal transfer";
            this.rdoTt.UseVisualStyleBackColor = true;
            // 
            // rdoDt
            // 
            this.rdoDt.AutoSize = true;
            this.rdoDt.Checked = true;
            this.rdoDt.Location = new System.Drawing.Point(18, 31);
            this.rdoDt.Name = "rdoDt";
            this.rdoDt.Size = new System.Drawing.Size(119, 20);
            this.rdoDt.TabIndex = 0;
            this.rdoDt.TabStop = true;
            this.rdoDt.Text = "Direct thermal";
            this.rdoDt.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoContinuous);
            this.groupBox6.Controls.Add(this.rdoBmark);
            this.groupBox6.Controls.Add(this.rdoGap);
            this.groupBox6.Location = new System.Drawing.Point(223, 200);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(206, 103);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sensor type";
            // 
            // rdoContinuous
            // 
            this.rdoContinuous.AutoSize = true;
            this.rdoContinuous.Location = new System.Drawing.Point(21, 73);
            this.rdoContinuous.Name = "rdoContinuous";
            this.rdoContinuous.Size = new System.Drawing.Size(99, 20);
            this.rdoContinuous.TabIndex = 2;
            this.rdoContinuous.Text = "Continuous";
            this.rdoContinuous.UseVisualStyleBackColor = true;
            // 
            // rdoBmark
            // 
            this.rdoBmark.AutoSize = true;
            this.rdoBmark.Location = new System.Drawing.Point(21, 48);
            this.rdoBmark.Name = "rdoBmark";
            this.rdoBmark.Size = new System.Drawing.Size(96, 20);
            this.rdoBmark.TabIndex = 1;
            this.rdoBmark.Text = "Black mark";
            this.rdoBmark.UseVisualStyleBackColor = true;
            // 
            // rdoGap
            // 
            this.rdoGap.AutoSize = true;
            this.rdoGap.Checked = true;
            this.rdoGap.Location = new System.Drawing.Point(22, 22);
            this.rdoGap.Name = "rdoGap";
            this.rdoGap.Size = new System.Drawing.Size(51, 20);
            this.rdoGap.TabIndex = 0;
            this.rdoGap.TabStop = true;
            this.rdoGap.Text = "Gap";
            this.rdoGap.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(637, 376);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblDllVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnResearch);
            this.Controls.Add(this.cmbPrtList);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skydive Cuautla Print Tickets";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPrtList;
        private System.Windows.Forms.Button btnResearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDllVersion;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtP_Height;
        private System.Windows.Forms.TextBox txtP_Width;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMargin_Y;
        private System.Windows.Forms.TextBox txtMargin_X;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDensity;
        private System.Windows.Forms.CheckBox chkCutter;
        private System.Windows.Forms.CheckBox chkRevFeeding;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoTt;
        private System.Windows.Forms.RadioButton rdoDt;
        private System.Windows.Forms.RadioButton rdoContinuous;
        private System.Windows.Forms.RadioButton rdoBmark;
        private System.Windows.Forms.RadioButton rdoGap;
    }
}

