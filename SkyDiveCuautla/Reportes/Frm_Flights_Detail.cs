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
    public partial class Frm_Flights_Detail : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_HistoryJumper
        public Frm_Flights_Detail()
        {
            InitializeComponent();
        }
        #endregion 

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsNewDataSet";
            sql = @"SELECT tbv.fechaabrevuelo as [Date], cta.matricula, tbv.numerovuelo as Flight, tbv.Loaded Slots, sum(tbl.charge) as [Total_Charges]
                      FROM TB_VUELOS tbv inner join CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
                     INNER JOIN TB_MANIFIESTO tbm on tbm.idvuelo = tbv.idvuelo
                      LEFT OUTER JOIN TB_LEDGER TBL ON TBL.idledger = tbm.idleadger
                     WHERE CONVERT(varchar(10),tbv.fechaabrevuelo,23)  between '" + misglobales._DateIni + "' and '" + misglobales._DateFin + @"'
                     GROUP BY tbv.fechaabrevuelo, cta.matricula, tbv.numerovuelo, tbv.Loaded 
                     ORDER BY CONVERT(varchar(10),tbv.fechaabrevuelo,23), cta.matricula, tbv.numerovuelo  ";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_Flight_Detail");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_flight_detail.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_flight_detail.xlm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try construct xsd and xml files " + ex.Message);
            }
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
                StrOficina =  " AND TBV.IDOFICINA = " + cmb_office.SelectedValue;
            }

            sql = @"SELECT tbv.fechaabrevuelo as [Date], cta.matricula, tbv.numerovuelo as Flight, tbv.Loaded Slots, sum(tbl.charge) as [Total_Charges]
                      FROM TB_VUELOS tbv inner join CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
                     INNER JOIN TB_MANIFIESTO tbm on tbm.idvuelo = tbv.idvuelo
                      LEFT OUTER JOIN TB_LEDGER TBL ON TBL.idledger = tbm.idleadger 
                     WHERE CONVERT(varchar(10),tbv.fechaabrevuelo,23)  between convert(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and convert(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)" +
                     StrOficina + @"
                     GROUP BY tbv.fechaabrevuelo, cta.matricula, tbv.numerovuelo, tbv.Loaded 
                     ORDER BY CONVERT(varchar(10),tbv.fechaabrevuelo,23), cta.matricula, tbv.numerovuelo  ";
            condicion = " ";
            tabla = "TB_Flight_Detail";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_flight_detail.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_flight_detail.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_flight_detail.rdlc");
            //this.rv_charges_summary.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_charges_summary.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_flight_detail", getdata());
                this.rv_flight_detail.LocalReport.DataSources.Clear();
                this.rv_flight_detail.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_flight_detail.LocalReport.Refresh();
                this.rv_flight_detail.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


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


        #region Load de la forma  Frm_HistoryJumper
        private void Frm_Flights_Detail_Load(object sender, EventArgs e)
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


        //    this.rv_flight_detail.RefreshReport();
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
