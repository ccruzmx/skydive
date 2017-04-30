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
    public partial class Frm_Jumper_Due : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_Tandem
        public Frm_Jumper_Due()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsNewDataSet";
            sql = @" SELECT ctj.nombre as name,case when ctj.Balance>0 then ctj.Balance else '0.00' end BalanceDue,
       case when ctj.Balance < 0 then ctj.Balance else '0.00' end BalanceOwed, ctj.Fecha_ultimo_salto, ctj.home_phone
  FROM dbo.CT_JUMPER ctj 
 where ctj.Balance <>0 and (ctj.lastname + ' ' + ctj.name) <> ' ' 
  group by ctj.nombre,  ctj.Balance , ctj.Fecha_ultimo_salto, ctj.home_phone 
  order by nombre";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\ds_jumperdue.xsd");
                ds.WriteXml("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\ds_jumperdue.xlm");
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
            sql = @" SELECT ctj.nombre as Name,case when ctj.Balance>0 then ctj.Balance else '0.00' end BalanceDue,
       case when ctj.Balance < 0 then ctj.Balance else '0.00' end BalanceOwed, ctj.Fecha_ultimo_salto, ctj.home_phone
  FROM dbo.CT_JUMPER ctj 
 where ctj.Balance <>0 and (ctj.lastname + ' ' + ctj.name) <> ' ' 
  group by ctj.nombre,  ctj.Balance , ctj.Fecha_ultimo_salto, ctj.home_phone 
  order by nombre";
            condicion = " ";
            tabla = "CT_JUMPER";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_jumper_due.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_jumper_due.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_Jumper_Due.rdlc");
            //this.rv_jumper_due.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_Jumper_Due.rdlc");

            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_jumperdue", getdata());
                this.rv_jumper_due.LocalReport.DataSources.Clear();
                this.rv_jumper_due.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_jumper_due.LocalReport.Refresh();
                this.rv_jumper_due.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


        #region Load de la forma  Frm_HistoryJumper
        private void Frm_Jumper_Due_Load(object sender, EventArgs e)
        {

            //rptGetDataset();
            RunRptViewer();
        }
        #endregion

    }
}
