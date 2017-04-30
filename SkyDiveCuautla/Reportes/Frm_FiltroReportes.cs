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
    public partial class Frm_FiltroReportes : Form
    {
        public Frm_FiltroReportes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (misglobales._HistoryJumper == "Frm_HistoryJumper")
            {

                Reportes.Frm_HistoryJumper _FrmReportHistoryJumper = new Reportes.Frm_HistoryJumper();
                misglobales._DateIni = dtp_dateini.Text;
                misglobales._DateFin = dtp_datefin.Text;
                this.Close();
                _FrmReportHistoryJumper.Show();
            }
            else
            {
                Reportes.Frm_HistoryJumper_resume _FrmReportHistoryJumper = new Reportes.Frm_HistoryJumper_resume();
                misglobales._DateIni = dtp_dateini.Text;
                misglobales._DateFin = dtp_datefin.Text;
                this.Close();
                _FrmReportHistoryJumper.Show();
            }

        }

        private void Frm_FiltroReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
