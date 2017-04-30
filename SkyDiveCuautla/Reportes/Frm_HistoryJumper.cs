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
    public partial class Frm_HistoryJumper : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion 

        #region Constuctor de la Forma Frm_HistoryJumper
        public Frm_HistoryJumper()
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
                        SELECT  CTJ.codigo, ctj.nombre, TBV.fechaabrevuelo, TBV.numerovuelo, CTA.matricula, CTJT.jump_type
                        FROM         dbo.CT_JUMPER AS CTJ INNER JOIN
                                              dbo.TB_MANIFIESTO AS TBM ON TBM.idjumper = CTJ.idjumper and CTJ.codigo = '"+ misglobales.jumper_code+ @"' INNER JOIN
                                              dbo.TB_VUELOS AS TBV ON TBV.idvuelo = TBM.idvuelo INNER JOIN  
                                              dbo.CT_AERONAVE AS CTA ON CTA.idaeronave = TBV.idaeronave INNER JOIN
                                              dbo.CT_JUMP_TYPE AS CTJT ON CTJT.idjumptype = TBM.idjumptype
                        WHERE TBV.fechaabrevuelo BETWEEN CONVERT(VARCHAR(26),'"+misglobales._DateIni + @"',23) 
                         AND CONVERT(VARCHAR(26),'"+misglobales._DateFin + "',23) ";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_historyjumper.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_historyjumper.xlm");
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
            sql = @"
                        SELECT  CTJ.codigo,  ctj.nombre, CONVERT(VARCHAR(26),TBV.fechaabrevuelo,23) as fechaabrevuelo, TBV.numerovuelo, CTA.matricula, CTJT.jump_type
                        FROM         dbo.CT_JUMPER AS CTJ INNER JOIN
                                              dbo.TB_MANIFIESTO AS TBM ON TBM.idjumper = CTJ.idjumper and CTJ.codigo = '" + misglobales.jumper_code + @"' INNER JOIN
                                              dbo.TB_VUELOS AS TBV ON TBV.idvuelo = TBM.idvuelo INNER JOIN  
                                              dbo.CT_AERONAVE AS CTA ON CTA.idaeronave = TBV.idaeronave INNER JOIN
                                              dbo.CT_JUMP_TYPE AS CTJT ON CTJT.idjumptype = TBM.idjumptype
                        WHERE CONVERT(varchar(10),TBV.fechaabrevuelo,23) BETWEEN CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + @"'),23) 
                         AND CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + "'),23)"; // SE QUITA EL ORDER BY
            condicion =" ";
            tabla = "CT_JUMPER";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt; 
        }
        #endregion 

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_history_jumper.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_history_jumper.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_History_Jumper.rdlc");
            //this.rv_history_jumper.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_History_Jumper.rdlc");
            try
            {
               // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("DSHistoryJumper", getdata());
                this.rv_history_jumper.LocalReport.DataSources.Clear();
                this.rv_history_jumper.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_history_jumper.LocalReport.Refresh();
                this.rv_history_jumper.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }
            
        }
        #endregion 


        #region Load de la forma  Frm_HistoryJumper
        private void Frm_HistoryJumper_Load(object sender, EventArgs e)
        {
            //rptGetDataset();
            RunRptViewer();
            //this.rv_history_jumper.RefreshReport();
        }
        #endregion 

    }
}
