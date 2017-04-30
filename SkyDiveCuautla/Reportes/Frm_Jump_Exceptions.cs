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
    public partial class Frm_Jump_Exceptions : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_Tandem
        public Frm_Jump_Exceptions()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsNewDataSet";
            sql = @"
  select  CTJ.lastname + ' ' + CTJ.name as name,  JT.jump_type,  JE.charge
    from dbo.CT_JUMPER_EXCEPTIONS JE  INNER JOIN dbo.CT_JUMPER CTJ ON CTJ.idjumper = JE.idjumper 
    INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.idjumptype = JE.idjumptype
    ORDER BY CTJ.lastname + ' ' + CTJ.name, JE.idjumptype
";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "CT_JUMPER_EXCEPTIONS");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\ds_jumper_exception.xsd");
                ds.WriteXml("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\ds_jumper_exception.xlm");
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
            sql = @"   select  CTJ.lastname + ' ' + CTJ.name as name,  JT.jump_type,  JE.charge
    from dbo.CT_JUMPER_EXCEPTIONS JE  INNER JOIN dbo.CT_JUMPER CTJ ON CTJ.idjumper = JE.idjumper 
    INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.idjumptype = JE.idjumptype
    ORDER BY CTJ.lastname + ' ' + CTJ.name, JE.idjumptype";
            condicion = " ";
            tabla = "CT_JUMPER_EXCEPTIONS";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_jumper_exception.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_jumper_exception.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_jumper_exception.rdlc");
            //this.rv_jumper_exception.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_jumper_exception.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_jumper_exceptions", getdata());
                this.rv_jumper_exception.LocalReport.DataSources.Clear();
                this.rv_jumper_exception.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_jumper_exception.LocalReport.Refresh();
                this.rv_jumper_exception.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


        #region Load de la forma  Frm_HistoryJumper
        private void Frm_Jump_Exceptions_Load(object sender, EventArgs e)
        {

            //rptGetDataset();
            RunRptViewer();
        }
        #endregion

    }
}
