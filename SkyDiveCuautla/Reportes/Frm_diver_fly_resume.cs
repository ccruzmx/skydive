using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Reflection;


namespace SkyDiveCuautla.Reportes
{
    public partial class Frm_diver_fly_resume : Form
    {

        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion


        public Frm_diver_fly_resume()
        {
            InitializeComponent();
        }

        #region LoadAutoComplete
        public static AutoCompleteStringCollection LoadAutoComplete(DataSet ds, string campo)
        {

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                stringCol.Add(Convert.ToString(row[campo]));
            }
            return stringCol;
        }
        #endregion

        #region Load de la forma Reporte Dier for fly
        private void Frm_diver_fly_resume_Load(object sender, EventArgs e)
        {
            DataSet dsoffice = conexion.ConsultaOficina("");
            cmb_office.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_office.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            //cmb_office.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_office.DisplayMember = "OFICINA";
            cmb_office.ValueMember = "ID";
            cmb_office.SelectedValue = misglobales.oficina_id_oficina;

            //rptGetDataset();
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;

            RunRptViewer();


        }
        #endregion

        #region Metodo para cargar los datos
        private DataTable getdata()
        {
            DataTable dt;
            DataSet dshistory;
            String StrOficina = "";

            if (cmb_office.SelectedValue.ToString() != "1")
            {
                StrOficina = " AND OFICINA = '" + cmb_office.Text +"' ";
            }


            sql = @"   SELECT NUMEROVUELO, PILOTO, convert(varchar(10), fecha, 23) as fecha, vuelo1 as [1], vuelo2 as [2], vuelo3 as [3], vuelo4 as [4], vuelo5 as [5], vuelo6 as [6], vuelo7 as [7], 
                              vuelo8 as [8], vuelo9 as [9], vuelo10 as [10], vuelo11 as [11], vuelo12 as [12], vuelo13 as [13], vuelo14 as [14], vuelo15 as [15], 
                              vuelo16 as [16], vuelo17 as [17] , vuelo18 as [18]
                         FROM dbo.RPT_PARACAIDISTAS_VUELO
                        WHERE CONVERT(varchar(10),fecha ,23)  between convert(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and convert(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)" +
                        StrOficina + @"
                        ORDER BY NUMEROVUELO, CONVERT(varchar(10),FECHA,23) ";

            condicion = " ";
            tabla = "RPT_PARACAIDISTAS_VUELO";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion



        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_diver_fly_resume.Reset();
            
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            this.rv_diver_fly_resume.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_diver_fly_resume.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_diver_fly_resume", getdata());
                this.rv_diver_fly_resume.LocalReport.DataSources.Clear();
                this.rv_diver_fly_resume.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_diver_fly_resume.LocalReport.Refresh();
                this.rv_diver_fly_resume.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion



        private void btn_generate_Click(object sender, EventArgs e)
        {
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
            RunRptViewer();
        }

    }
}
