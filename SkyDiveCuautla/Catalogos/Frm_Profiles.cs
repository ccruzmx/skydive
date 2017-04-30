using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyDiveCuautla.Catalogos
{
    public partial class Frm_Profiles : Form
    {
        public Frm_Profiles()
        {
            InitializeComponent();
        }

        private void Frm_Profiles_Load(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
            this.WindowState = FormWindowState.Normal;

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }
    }
}
