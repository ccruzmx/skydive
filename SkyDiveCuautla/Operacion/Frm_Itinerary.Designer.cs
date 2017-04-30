namespace SkyDiveCuautla.Operacion
{
    partial class Frm_Itinerary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_itinerario1 = new System.Windows.Forms.DataGridView();
            this.lbl_ontime1 = new System.Windows.Forms.Label();
            this.cronometro_local = new System.Windows.Forms.Timer(this.components);
            this.tmr_ontime = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dg_itinerario2 = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dg_itinerario3 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_monvuelo1 = new System.Windows.Forms.Label();
            this.lbl_crono1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_monvuelo2 = new System.Windows.Forms.Label();
            this.lbl_ontime2 = new System.Windows.Forms.Label();
            this.lbl_crono2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_monvuelo3 = new System.Windows.Forms.Label();
            this.lbl_ontime3 = new System.Windows.Forms.Label();
            this.lbl_crono3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_itinerario1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_itinerario2)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_itinerario3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dg_itinerario1);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 656);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // dg_itinerario1
            // 
            this.dg_itinerario1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_itinerario1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_itinerario1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_itinerario1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_itinerario1.Location = new System.Drawing.Point(9, 19);
            this.dg_itinerario1.Name = "dg_itinerario1";
            this.dg_itinerario1.Size = new System.Drawing.Size(513, 628);
            this.dg_itinerario1.TabIndex = 2;
            // 
            // lbl_ontime1
            // 
            this.lbl_ontime1.BackColor = System.Drawing.Color.YellowGreen;
            this.lbl_ontime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ontime1.Location = new System.Drawing.Point(294, 49);
            this.lbl_ontime1.Name = "lbl_ontime1";
            this.lbl_ontime1.Size = new System.Drawing.Size(228, 37);
            this.lbl_ontime1.TabIndex = 38;
            this.lbl_ontime1.Text = "ON TIME";
            // 
            // tmr_ontime
            // 
            this.tmr_ontime.Tick += new System.EventHandler(this.tmr_ontime_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dg_itinerario2);
            this.groupBox5.Location = new System.Drawing.Point(546, 123);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(491, 656);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            // 
            // dg_itinerario2
            // 
            this.dg_itinerario2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_itinerario2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_itinerario2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_itinerario2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_itinerario2.Location = new System.Drawing.Point(6, 19);
            this.dg_itinerario2.Name = "dg_itinerario2";
            this.dg_itinerario2.Size = new System.Drawing.Size(475, 628);
            this.dg_itinerario2.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.dg_itinerario3);
            this.groupBox6.Location = new System.Drawing.Point(1050, 166);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(313, 613);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            this.groupBox6.Visible = false;
            // 
            // dg_itinerario3
            // 
            this.dg_itinerario3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_itinerario3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dg_itinerario3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_itinerario3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dg_itinerario3.Location = new System.Drawing.Point(8, 19);
            this.dg_itinerario3.Name = "dg_itinerario3";
            this.dg_itinerario3.Size = new System.Drawing.Size(416, 585);
            this.dg_itinerario3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_monvuelo1);
            this.groupBox1.Controls.Add(this.lbl_ontime1);
            this.groupBox1.Controls.Add(this.lbl_crono1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 104);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // lbl_monvuelo1
            // 
            this.lbl_monvuelo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_monvuelo1.ForeColor = System.Drawing.Color.Black;
            this.lbl_monvuelo1.Location = new System.Drawing.Point(287, 12);
            this.lbl_monvuelo1.Name = "lbl_monvuelo1";
            this.lbl_monvuelo1.Size = new System.Drawing.Size(235, 37);
            this.lbl_monvuelo1.TabIndex = 39;
            this.lbl_monvuelo1.Text = "BUILDING FLIGHT";
            this.lbl_monvuelo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_crono1
            // 
            this.lbl_crono1.AutoSize = true;
            this.lbl_crono1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_crono1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_crono1.Font = new System.Drawing.Font("Microsoft Sans Serif", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_crono1.Location = new System.Drawing.Point(11, 12);
            this.lbl_crono1.Name = "lbl_crono1";
            this.lbl_crono1.Size = new System.Drawing.Size(270, 73);
            this.lbl_crono1.TabIndex = 38;
            this.lbl_crono1.Text = "00:00:00";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbl_monvuelo2);
            this.groupBox3.Controls.Add(this.lbl_ontime2);
            this.groupBox3.Controls.Add(this.lbl_crono2);
            this.groupBox3.Location = new System.Drawing.Point(546, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 105);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // lbl_monvuelo2
            // 
            this.lbl_monvuelo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_monvuelo2.ForeColor = System.Drawing.Color.Black;
            this.lbl_monvuelo2.Location = new System.Drawing.Point(280, 17);
            this.lbl_monvuelo2.Name = "lbl_monvuelo2";
            this.lbl_monvuelo2.Size = new System.Drawing.Size(212, 37);
            this.lbl_monvuelo2.TabIndex = 40;
            this.lbl_monvuelo2.Text = "BUILDING FLIGHT";
            this.lbl_monvuelo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ontime2
            // 
            this.lbl_ontime2.BackColor = System.Drawing.Color.YellowGreen;
            this.lbl_ontime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ontime2.Location = new System.Drawing.Point(282, 50);
            this.lbl_ontime2.Name = "lbl_ontime2";
            this.lbl_ontime2.Size = new System.Drawing.Size(210, 37);
            this.lbl_ontime2.TabIndex = 39;
            this.lbl_ontime2.Text = "ON TIME";
            // 
            // lbl_crono2
            // 
            this.lbl_crono2.AutoSize = true;
            this.lbl_crono2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_crono2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_crono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_crono2.Location = new System.Drawing.Point(6, 14);
            this.lbl_crono2.Name = "lbl_crono2";
            this.lbl_crono2.Size = new System.Drawing.Size(270, 73);
            this.lbl_crono2.TabIndex = 38;
            this.lbl_crono2.Text = "00:00:00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_monvuelo3);
            this.groupBox4.Controls.Add(this.lbl_ontime3);
            this.groupBox4.Controls.Add(this.lbl_crono3);
            this.groupBox4.Location = new System.Drawing.Point(1050, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 147);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // lbl_monvuelo3
            // 
            this.lbl_monvuelo3.AutoSize = true;
            this.lbl_monvuelo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_monvuelo3.ForeColor = System.Drawing.Color.Black;
            this.lbl_monvuelo3.Location = new System.Drawing.Point(7, 16);
            this.lbl_monvuelo3.Name = "lbl_monvuelo3";
            this.lbl_monvuelo3.Size = new System.Drawing.Size(305, 37);
            this.lbl_monvuelo3.TabIndex = 41;
            this.lbl_monvuelo3.Text = "BUILDING FLIGHT";
            // 
            // lbl_ontime3
            // 
            this.lbl_ontime3.AutoSize = true;
            this.lbl_ontime3.BackColor = System.Drawing.Color.YellowGreen;
            this.lbl_ontime3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ontime3.Location = new System.Drawing.Point(284, 16);
            this.lbl_ontime3.Name = "lbl_ontime3";
            this.lbl_ontime3.Size = new System.Drawing.Size(150, 37);
            this.lbl_ontime3.TabIndex = 40;
            this.lbl_ontime3.Text = "ON TIME";
            // 
            // lbl_crono3
            // 
            this.lbl_crono3.AutoSize = true;
            this.lbl_crono3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_crono3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_crono3.Font = new System.Drawing.Font("Microsoft Sans Serif", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_crono3.Location = new System.Drawing.Point(8, 63);
            this.lbl_crono3.Name = "lbl_crono3";
            this.lbl_crono3.Size = new System.Drawing.Size(270, 73);
            this.lbl_crono3.TabIndex = 39;
            this.lbl_crono3.Text = "00:00:00";
            // 
            // Frm_Itinerary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1047, 782);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.MinimizeBox = false;
            this.Name = "Frm_Itinerary";
            this.Text = "Flight Itinerary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Frm_Itinerary_Activated);
            this.Load += new System.EventHandler(this.Frm_Itinerary_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_itinerario1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_itinerario2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_itinerario3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_itinerario1;
        private System.Windows.Forms.Timer cronometro_local;
        private System.Windows.Forms.Timer tmr_ontime;
        private System.Windows.Forms.Label lbl_ontime1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dg_itinerario2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dg_itinerario3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_crono1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_ontime2;
        private System.Windows.Forms.Label lbl_crono2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_ontime3;
        private System.Windows.Forms.Label lbl_crono3;
        private System.Windows.Forms.Label lbl_monvuelo1;
        private System.Windows.Forms.Label lbl_monvuelo2;
        private System.Windows.Forms.Label lbl_monvuelo3;

    }
}