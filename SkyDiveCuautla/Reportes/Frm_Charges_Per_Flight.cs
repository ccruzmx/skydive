using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyDiveCuautla.Reportes
{
    public partial class Frm_Charges_Per_Flight : Form
    {
        public Frm_Charges_Per_Flight()
        {
            InitializeComponent();
        }

        private void Frm_Charges_Per_Flight_Load(object sender, EventArgs e)
        {
           
            this.rv_charges_per_flight.RefreshReport();
        }
    }
}
