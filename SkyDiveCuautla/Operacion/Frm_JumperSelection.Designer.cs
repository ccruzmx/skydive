﻿namespace SkyDiveCuautla.Operacion
{
    partial class Frm_JumperSelection
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
            this.lbl_jumperselection = new System.Windows.Forms.Label();
            this.cmb_jumper = new System.Windows.Forms.ComboBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SlateGray;
            this.groupBox1.Controls.Add(this.lbl_jumperselection);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbl_jumperselection
            // 
            this.lbl_jumperselection.AutoSize = true;
            this.lbl_jumperselection.Font = new System.Drawing.Font("Modern No. 20", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_jumperselection.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_jumperselection.Location = new System.Drawing.Point(63, 22);
            this.lbl_jumperselection.Name = "lbl_jumperselection";
            this.lbl_jumperselection.Size = new System.Drawing.Size(277, 41);
            this.lbl_jumperselection.TabIndex = 0;
            this.lbl_jumperselection.Text = "Jumper Selector";
            // 
            // cmb_jumper
            // 
            this.cmb_jumper.FormattingEnabled = true;
            this.cmb_jumper.Location = new System.Drawing.Point(42, 113);
            this.cmb_jumper.Name = "cmb_jumper";
            this.cmb_jumper.Size = new System.Drawing.Size(364, 21);
            this.cmb_jumper.TabIndex = 1;
            this.cmb_jumper.SelectionChangeCommitted += new System.EventHandler(this.cmb_jumper_SelectionChangeCommitted);
            this.cmb_jumper.TextUpdate += new System.EventHandler(this.cmb_jumper_TextUpdate);
            this.cmb_jumper.SelectedValueChanged += new System.EventHandler(this.cmb_jumper_SelectedValueChanged);
            this.cmb_jumper.TextChanged += new System.EventHandler(this.cmb_jumper_TextChanged);
            this.cmb_jumper.Enter += new System.EventHandler(this.cmb_jumper_Enter);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(228, 190);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 30);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(340, 190);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Frm_JumperSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(470, 250);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cmb_jumper);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_JumperSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jumper Selection";
            this.Load += new System.EventHandler(this.Frm_JumperSelection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_jumperselection;
        private System.Windows.Forms.ComboBox cmb_jumper;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}