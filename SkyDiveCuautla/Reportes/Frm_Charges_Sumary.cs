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
    public partial class Frm_Charges_Sumary : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_HistoryJumper
        public Frm_Charges_Sumary()
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
SELECT ct.Grupo, ct.charge_type, 99999999.99 AS CHARGE, 99999999.99 AS CREDIT, SUM( TBL.charge) as	TOTAL
  INTO #SUMMARY
  FROM dbo.TB_LEDGER TBL INNER JOIN dbo.CT_CHARGE_TYPE ct on tbl.idchargetype = ct.codigo
 WHERE TBL.updatedate BETWEEN CONVERT(VARCHAR(26),'" + misglobales._DateIni + "',23) AND CONVERT(VARCHAR(26),'" + misglobales._DateFin + @"',23)
 group by ct.Grupo, ct.charge_type
 
UPDATE #SUMMARY
   SET CHARGE = 0, CREDIT = 0
   
SELECT ct.Grupo, ct.charge_type, SUM( TBL.charge)*-1 AS CREDIT
  INTO #CREDIT
  FROM dbo.TB_LEDGER TBL INNER JOIN dbo.CT_CHARGE_TYPE ct on tbl.idchargetype = ct.codigo 
 WHERE TBL.updatedate BETWEEN CONVERT(VARCHAR(26),'" + misglobales._DateIni + "',23) AND CONVERT(VARCHAR(26),'" + misglobales._DateFin + @"',23)
   AND TBL.charge < 0
 GROUP BY ct.Grupo, ct.charge_type
 
SELECT ct.Grupo, ct.charge_type, SUM( TBL.charge) AS CHARGE
  INTO #CHARGE
  FROM dbo.TB_LEDGER TBL INNER JOIN dbo.CT_CHARGE_TYPE ct on tbl.idchargetype = ct.codigo 
 WHERE TBL.updatedate BETWEEN CONVERT(VARCHAR(26),'" + misglobales._DateIni + "',23) AND CONVERT(VARCHAR(26),'" + misglobales._DateFin + @"',23)
   AND TBL.charge > 0
 GROUP BY ct.Grupo, ct.charge_type 
   
UPDATE S
   SET S.CHARGE = CHARGE.CHARGE
  FROM #SUMMARY S 
 INNER JOIN #CHARGE AS CHARGE ON CHARGE.GRUPO = S.GRUPO 
   AND CHARGE.CHARGE_TYPE = S.CHARGE_TYPE
   
UPDATE S
   SET S.CREDIT = CHARGE.CREDIT
  FROM #SUMMARY S 
 INNER JOIN #CREDIT AS CHARGE ON CHARGE.GRUPO = S.GRUPO 
   AND CHARGE.CHARGE_TYPE = S.CHARGE_TYPE   

SELECT *
 FROM #SUMMARY                   
";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_Charges_Summary");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_charges_summary.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_charges_summary.xlm");
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
                StrOficina = " AND TBL.idoficina = " + cmb_office.SelectedValue;
            }


            sql = @"
SELECT ct.Grupo, ct.charge_type, 99999999.99 AS CHARGE, 99999999.99 AS CREDIT, SUM( TBL.charge) as	TOTAL
  INTO #SUMMARY
  FROM dbo.TB_LEDGER TBL INNER JOIN dbo.CT_CHARGE_TYPE ct on tbl.idchargetype = ct.codigo
 WHERE CONVERT(VARCHAR(10),TBL.updatedate,23) BETWEEN CONVERT(VARCHAR(10), convert(date,'" + misglobales._DateIni + "'),23) AND CONVERT(VARCHAR(10), convert(date,'" + misglobales._DateFin + @"'),23) " +
                                                     StrOficina + @"

 group by ct.Grupo, ct.charge_type
 
UPDATE #SUMMARY
   SET CHARGE = 0, CREDIT = 0
   
SELECT ct.Grupo, ct.charge_type, SUM( TBL.charge)*-1 AS CREDIT
  INTO #CREDIT
  FROM dbo.TB_LEDGER TBL INNER JOIN dbo.CT_CHARGE_TYPE ct on tbl.idchargetype = ct.codigo 
 WHERE CONVERT(VARCHAR(10),TBL.updatedate,23) BETWEEN CONVERT(VARCHAR(10), convert(date,'" + misglobales._DateIni + "'),23) AND CONVERT(VARCHAR(10), convert(date,'" + misglobales._DateFin + @"'),23)
   AND TBL.charge < 0" +
                                                     StrOficina + @"
 GROUP BY ct.Grupo, ct.charge_type
 
SELECT ct.Grupo, ct.charge_type, SUM( TBL.charge) AS CHARGE
  INTO #CHARGE
  FROM dbo.TB_LEDGER TBL INNER JOIN dbo.CT_CHARGE_TYPE ct on tbl.idchargetype = ct.codigo 
 WHERE CONVERT(VARCHAR(10),TBL.updatedate,23) BETWEEN CONVERT(VARCHAR(10), convert(date,'" + misglobales._DateIni + "'),23) AND CONVERT(VARCHAR(10), convert(date,'" + misglobales._DateFin + @"'),23)
   AND TBL.charge > 0" +
                                                     StrOficina + @"
 GROUP BY ct.Grupo, ct.charge_type 
   
UPDATE S
   SET S.CHARGE = CHARGE.CHARGE
  FROM #SUMMARY S 
 INNER JOIN #CHARGE AS CHARGE ON CHARGE.GRUPO = S.GRUPO 
   AND CHARGE.CHARGE_TYPE = S.CHARGE_TYPE
   
UPDATE S
   SET S.CREDIT = CHARGE.CREDIT
  FROM #SUMMARY S 
 INNER JOIN #CREDIT AS CHARGE ON CHARGE.GRUPO = S.GRUPO 
   AND CHARGE.CHARGE_TYPE = S.CHARGE_TYPE   

SELECT *
 FROM #SUMMARY                   
";


            condicion = " ";
            tabla = "TB_Charges_Summary";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_charges_summary.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_charges_summary.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_charges_summary.rdlc");
            //this.rv_charges_summary.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_charges_summary.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_charges_summary", getdata());
                this.rv_charges_summary.LocalReport.DataSources.Clear();
                this.rv_charges_summary.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_charges_summary.LocalReport.Refresh();
                this.rv_charges_summary.RefreshReport();
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
        private void Frm_Charges_Sumary_Load(object sender, EventArgs e)
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

        private void btn_generate_Click(object sender, EventArgs e)
        {
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
            RunRptViewer();
        }

    }
}
