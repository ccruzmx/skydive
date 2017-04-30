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
    public partial class Frm_Tandem_Due : Form
    {

        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion 

        #region Constuctor de la Forma Frm_Tandem
        public Frm_Tandem_Due()
        {
            InitializeComponent();
        }
        #endregion 

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsNewDataSet";
            sql = @" SELECT CONVERT(VARCHAR(26),updatedate, 23) as registertime, name,'' as lastname, '' referenceby, charge, payment as paymant, charge-payment as balance, '' as email
                      FROM TB_LEDGER
                     WHERE jumper_code = '9999-Tandem'
                       AND charge > payment order by CONVERT(VARCHAR(26),updatedate, 23) desc";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_TANDEMUP");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_tandemdue.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_tandemdue.xlm");
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
            sql = @" SELECT CONVERT(VARCHAR(26),tbl.updatedate, 23) as registertime, tbl.name, '' as lastname, tbt.referenced_by , tbl.charge, tbl.payment as paymant, tbl.charge- tbl.payment as balance, tbt.email as email
                       FROM TB_LEDGER tbl inner join TB_TANDEMUP TBT on tbt.lastname + ', ' +TBT.name   = tbl.name
                      WHERE tbl.jumper_code = '9999-Tandem'
                        AND tbl.charge > tbl.payment 
                      order by CONVERT(VARCHAR(26),tbl.updatedate, 23) desc";
            condicion = " ";
            tabla = "TB_LEDGER";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_tandemdue.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_tandemdue.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_Tandem_Due.rdlc");
            //this.rv_tandemdue.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_Tandem_Due.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_tandemupdue", getdata());
                this.rv_tandemdue.LocalReport.DataSources.Clear();
                this.rv_tandemdue.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_tandemdue.LocalReport.Refresh();
                this.rv_tandemdue.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


        #region Load de la forma  Frm_HistoryJumper
        private void Frm_Tandem_Due_Load(object sender, EventArgs e)
        {
            //rptGetDataset();
            RunRptViewer();
        }
        #endregion 
    }
}
