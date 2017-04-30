namespace SkyDiveCuautla.Operacion
{
    partial class Frm_SistemaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SistemaControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_state = new System.Windows.Forms.Label();
            this.lbl_backup2 = new System.Windows.Forms.Label();
            this.lbl_backup = new System.Windows.Forms.Label();
            this.pb_backup = new System.Windows.Forms.PictureBox();
            this.txb_server = new System.Windows.Forms.TextBox();
            this.btn_backup = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_backups = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmb_office = new System.Windows.Forms.ComboBox();
            this.lbl_mensaje2 = new System.Windows.Forms.Label();
            this.lbl_mensaje1 = new System.Windows.Forms.Label();
            this.pb_sync = new System.Windows.Forms.PictureBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.lbl_mensaje = new System.Windows.Forms.Label();
            this.btn_sincronize = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.txb_pathfile = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_backup)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_backups)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sync)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1361, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "System Controls And Sync";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_state);
            this.groupBox2.Controls.Add(this.lbl_backup2);
            this.groupBox2.Controls.Add(this.lbl_backup);
            this.groupBox2.Controls.Add(this.pb_backup);
            this.groupBox2.Controls.Add(this.txb_server);
            this.groupBox2.Controls.Add(this.btn_backup);
            this.groupBox2.Location = new System.Drawing.Point(0, 80);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(480, 173);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backups";
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Location = new System.Drawing.Point(312, 110);
            this.lbl_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(42, 13);
            this.lbl_state.TabIndex = 11;
            this.lbl_state.Text = "Estatus";
            // 
            // lbl_backup2
            // 
            this.lbl_backup2.AutoSize = true;
            this.lbl_backup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_backup2.Location = new System.Drawing.Point(133, 109);
            this.lbl_backup2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_backup2.Name = "lbl_backup2";
            this.lbl_backup2.Size = new System.Drawing.Size(181, 15);
            this.lbl_backup2.TabIndex = 10;
            this.lbl_backup2.Text = "Backup DataBase in progress ...";
            this.lbl_backup2.Visible = false;
            // 
            // lbl_backup
            // 
            this.lbl_backup.AutoSize = true;
            this.lbl_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_backup.Location = new System.Drawing.Point(131, 76);
            this.lbl_backup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_backup.Name = "lbl_backup";
            this.lbl_backup.Size = new System.Drawing.Size(104, 24);
            this.lbl_backup.TabIndex = 9;
            this.lbl_backup.Text = "Please wait";
            this.lbl_backup.Visible = false;
            // 
            // pb_backup
            // 
            this.pb_backup.Image = global::SkyDiveCuautla.Properties.Resources.ajax_loader;
            this.pb_backup.Location = new System.Drawing.Point(11, 76);
            this.pb_backup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_backup.Name = "pb_backup";
            this.pb_backup.Size = new System.Drawing.Size(114, 65);
            this.pb_backup.TabIndex = 7;
            this.pb_backup.TabStop = false;
            this.pb_backup.Visible = false;
            // 
            // txb_server
            // 
            this.txb_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_server.Location = new System.Drawing.Point(11, 35);
            this.txb_server.Margin = new System.Windows.Forms.Padding(2);
            this.txb_server.Name = "txb_server";
            this.txb_server.ReadOnly = true;
            this.txb_server.Size = new System.Drawing.Size(311, 29);
            this.txb_server.TabIndex = 1;
            // 
            // btn_backup
            // 
            this.btn_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backup.Image = ((System.Drawing.Image)(resources.GetObject("btn_backup.Image")));
            this.btn_backup.Location = new System.Drawing.Point(358, 18);
            this.btn_backup.Margin = new System.Windows.Forms.Padding(2);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(116, 123);
            this.btn_backup.TabIndex = 0;
            this.btn_backup.Text = "Backup";
            this.btn_backup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dg_backups);
            this.groupBox3.Location = new System.Drawing.Point(0, 257);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1361, 398);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dg_backups
            // 
            this.dg_backups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_backups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_backups.Location = new System.Drawing.Point(11, 19);
            this.dg_backups.Margin = new System.Windows.Forms.Padding(2);
            this.dg_backups.Name = "dg_backups";
            this.dg_backups.Size = new System.Drawing.Size(1343, 371);
            this.dg_backups.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cmb_office);
            this.groupBox5.Controls.Add(this.lbl_mensaje2);
            this.groupBox5.Controls.Add(this.lbl_mensaje1);
            this.groupBox5.Controls.Add(this.pb_sync);
            this.groupBox5.Controls.Add(this.btn_download);
            this.groupBox5.Controls.Add(this.lbl_mensaje);
            this.groupBox5.Controls.Add(this.btn_sincronize);
            this.groupBox5.Controls.Add(this.btn_browse);
            this.groupBox5.Controls.Add(this.btn_upload);
            this.groupBox5.Controls.Add(this.txb_pathfile);
            this.groupBox5.Location = new System.Drawing.Point(484, 80);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(877, 173);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DataBase Administrator";
            // 
            // cmb_office
            // 
            this.cmb_office.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_office.FormattingEnabled = true;
            this.cmb_office.Location = new System.Drawing.Point(450, 19);
            this.cmb_office.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_office.Name = "cmb_office";
            this.cmb_office.Size = new System.Drawing.Size(416, 21);
            this.cmb_office.TabIndex = 53;
            this.cmb_office.SelectedIndexChanged += new System.EventHandler(this.cmb_office_SelectedIndexChanged);
            // 
            // lbl_mensaje2
            // 
            this.lbl_mensaje2.AutoSize = true;
            this.lbl_mensaje2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensaje2.Location = new System.Drawing.Point(140, 106);
            this.lbl_mensaje2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mensaje2.Name = "lbl_mensaje2";
            this.lbl_mensaje2.Size = new System.Drawing.Size(130, 15);
            this.lbl_mensaje2.TabIndex = 8;
            this.lbl_mensaje2.Text = "Connecting to server ...";
            this.lbl_mensaje2.Visible = false;
            // 
            // lbl_mensaje1
            // 
            this.lbl_mensaje1.AutoSize = true;
            this.lbl_mensaje1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensaje1.Location = new System.Drawing.Point(139, 82);
            this.lbl_mensaje1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mensaje1.Name = "lbl_mensaje1";
            this.lbl_mensaje1.Size = new System.Drawing.Size(104, 24);
            this.lbl_mensaje1.TabIndex = 7;
            this.lbl_mensaje1.Text = "Please wait";
            this.lbl_mensaje1.Visible = false;
            // 
            // pb_sync
            // 
            this.pb_sync.Image = global::SkyDiveCuautla.Properties.Resources.ajax_loader;
            this.pb_sync.Location = new System.Drawing.Point(19, 77);
            this.pb_sync.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_sync.Name = "pb_sync";
            this.pb_sync.Size = new System.Drawing.Size(114, 64);
            this.pb_sync.TabIndex = 6;
            this.pb_sync.TabStop = false;
            this.pb_sync.Visible = false;
            // 
            // btn_download
            // 
            this.btn_download.Image = ((System.Drawing.Image)(resources.GetObject("btn_download.Image")));
            this.btn_download.Location = new System.Drawing.Point(771, 51);
            this.btn_download.Margin = new System.Windows.Forms.Padding(2);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(95, 106);
            this.btn_download.TabIndex = 5;
            this.btn_download.Text = "Dropzone DB";
            this.btn_download.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // lbl_mensaje
            // 
            this.lbl_mensaje.AutoSize = true;
            this.lbl_mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.lbl_mensaje.Location = new System.Drawing.Point(14, 15);
            this.lbl_mensaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mensaje.Name = "lbl_mensaje";
            this.lbl_mensaje.Size = new System.Drawing.Size(397, 15);
            this.lbl_mensaje.TabIndex = 4;
            this.lbl_mensaje.Text = "IMPORTANT:  This functions will use bisade database server ";
            // 
            // btn_sincronize
            // 
            this.btn_sincronize.Image = ((System.Drawing.Image)(resources.GetObject("btn_sincronize.Image")));
            this.btn_sincronize.Location = new System.Drawing.Point(450, 51);
            this.btn_sincronize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_sincronize.Name = "btn_sincronize";
            this.btn_sincronize.Size = new System.Drawing.Size(97, 106);
            this.btn_sincronize.TabIndex = 0;
            this.btn_sincronize.Text = "Load Zone";
            this.btn_sincronize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sincronize.UseVisualStyleBackColor = true;
            this.btn_sincronize.Click += new System.EventHandler(this.btn_sincronize_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(310, 49);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(74, 23);
            this.btn_browse.TabIndex = 3;
            this.btn_browse.Text = "Browser";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Image = ((System.Drawing.Image)(resources.GetObject("btn_upload.Image")));
            this.btn_upload.Location = new System.Drawing.Point(611, 51);
            this.btn_upload.Margin = new System.Windows.Forms.Padding(2);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(98, 106);
            this.btn_upload.TabIndex = 3;
            this.btn_upload.Text = "Restore";
            this.btn_upload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // txb_pathfile
            // 
            this.txb_pathfile.Location = new System.Drawing.Point(19, 51);
            this.txb_pathfile.Margin = new System.Windows.Forms.Padding(2);
            this.txb_pathfile.Name = "txb_pathfile";
            this.txb_pathfile.Size = new System.Drawing.Size(287, 20);
            this.txb_pathfile.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Frm_SistemaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1361, 660);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_SistemaControl";
            this.Text = "Control System";
            this.Load += new System.EventHandler(this.Frm_SistemaControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_backup)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_backups)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sync)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_backups;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_sincronize;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txb_pathfile;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txb_server;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label lbl_mensaje;
        private System.Windows.Forms.Label lbl_backup2;
        private System.Windows.Forms.Label lbl_backup;
        private System.Windows.Forms.PictureBox pb_backup;
        private System.Windows.Forms.Label lbl_mensaje2;
        private System.Windows.Forms.Label lbl_mensaje1;
        private System.Windows.Forms.PictureBox pb_sync;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.ComboBox cmb_office;
    }
}