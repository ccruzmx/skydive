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
    public partial class Frm_diver_fly_detail : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        public Frm_diver_fly_detail()
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


        #region Metodo para cargar los datos
        private DataTable getdata()
        {
            DataTable dt;
            DataSet dshistory;
            String StrOficina = " ";

            if (cmb_office.SelectedValue.ToString() != "1")
            {
                StrOficina = " AND IDOFICINA = '" + cmb_office.SelectedValue + "' ";
            }

            sql = @"
                     SELECT idoficina, matricula, piloto, fecha, numerovuelo, Ocupantes, nombre
                       FROM [v_diver_fly_detail] 
                      WHERE CONVERT(varchar(10),fecha ,23)  between convert(varchar(10), '" + misglobales._DateIni + "',23) and convert(varchar(10), '" + misglobales._DateFin + @"',23) 
                   " + StrOficina;
            condicion = " ORDER BY fecha, matricula";
            tabla = "RPT_PARACAIDISTAS_VUELO";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion


        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_diver_fly_detail.Reset();

            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            this.rv_diver_fly_detail.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_diver_fly_detail.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_diver_fly_detail", getdata());
                this.rv_diver_fly_detail.LocalReport.DataSources.Clear();
                this.rv_diver_fly_detail.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_diver_fly_detail.LocalReport.Refresh();
                this.rv_diver_fly_detail.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


        private void Frm_diver_fly_detail_Load(object sender, EventArgs e)
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

        private void btn_generate_Click(object sender, EventArgs e)
        {
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
            RunRptViewer();
        }
    }
}
