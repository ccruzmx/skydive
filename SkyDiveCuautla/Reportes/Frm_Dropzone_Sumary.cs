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
    public partial class Frm_Dropzone_Sumary : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_HistoryJumper
        public Frm_Dropzone_Sumary()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsNewDataSet";
            sql = @"SELECT cta.matricula , COUNT(*) as loads, SUM(TBV.Loaded) as Jumpers, SUM(TBV.Capacity-TBV.Loaded) OpenSlots 
                      FROM TB_VUELOS TBV INNER JOIN CT_AERONAVE CTA ON CTA.idaeronave = TBV.idaeronave
                     WHERE CONVERT(varchar(10), TBV.fechaabrevuelo, 23) between '" + misglobales._DateIni + "' and '" + misglobales._DateFin + @"'
                     GROUP BY  cta.matricula ";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_dropzone_summary1");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_dropzone_summary1.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_dropzone_summary1.xlm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try construct xsd and xml files " + ex.Message);
            }


            ds.DataSetName = "dsNewDataSet2";
            sql = @" SELECT ctjt.[group], ctjt.JUMP_TYPE, COUNT(*) AS Jumps 
                       FROM TB_MANIFIESTO tbm inner join TB_VUELOS TBV on tbv.idvuelo = tbm.idvuelo
                      inner join CT_JUMP_TYPE ctjt on ctjt.idjumptype = tbm.idjumptype
                      where CONVERT(varchar(10), TBV.fechaabrevuelo, 23) between '" + misglobales._DateIni + "' and '" + misglobales._DateFin + @"'
                      group by ctjt.[group], ctjt.JUMP_TYPE,  ctjt.orden
                      order by ctjt.[group], ctjt.orden";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_dropzone_summary2");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_dropzone_summary2.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_dropzone_summary2.xlm");
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
            sql = @"SELECT cta.matricula , COUNT(*) as loads, SUM(TBV.Loaded) as Jumpers, SUM(TBV.Capacity-TBV.Loaded) OpenSlots 
                      FROM TB_VUELOS TBV INNER JOIN CT_AERONAVE CTA ON CTA.idaeronave = TBV.idaeronave
                     WHERE CONVERT(varchar(10), TBV.fechaabrevuelo, 23) between CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + @"'),23)
                       and CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23) ";
            if ( cmb_office.SelectedValue.ToString() != "1") 
            {
                  sql = sql + " AND TBV.IDOFICINA = " +  cmb_office.SelectedValue ;
            }
            
            condicion = " GROUP BY  cta.matricula  ";
            tabla = "TB_dropzone_summary1";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region Metodo para cargar los datos
        private DataTable getdata2()
        {
            DataTable dt;
            DataSet dshistory;
            sql = @" SELECT ctjt.[group], ctjt.JUMP_TYPE, COUNT(*) AS Jumps 
                       FROM TB_MANIFIESTO tbm inner join TB_VUELOS TBV on tbv.idvuelo = tbm.idvuelo
                      inner join CT_JUMP_TYPE ctjt on ctjt.idjumptype = tbm.idjumptype
                      where CONVERT(varchar(10), TBV.fechaabrevuelo, 23) between CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)
                        ";
            if (cmb_office.SelectedValue.ToString() != "1")
            {
                sql = sql + " AND TBV.IDOFICINA = " + cmb_office.SelectedValue;
            }

            condicion = @" group by ctjt.[group], ctjt.JUMP_TYPE,  ctjt.orden
                      order by ctjt.[group], ctjt.orden";
            tabla = "TB_dropzone_summary2";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion



        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_drop_zone_summary.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_drop_zone_summary.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_dropzone_summary.rdlc");
            //this.rv_charges_summary.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_charges_summary.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_dropzone_summary1", getdata());
                this.rv_drop_zone_summary.LocalReport.DataSources.Clear();
                this.rv_drop_zone_summary.LocalReport.DataSources.Add(rds);

                ReportDataSource rds2 = new ReportDataSource("ds_dropzone_summary2", getdata2());
                //this.rv_drop_zone_summary.LocalReport.DataSources.Clear();
                this.rv_drop_zone_summary.LocalReport.DataSources.Add(rds2);

                //this.rv_history_jumper.DataBind();
                this.rv_drop_zone_summary.LocalReport.Refresh();
                this.rv_drop_zone_summary.RefreshReport();
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
        private void Frm_Dropzone_Sumary_Load(object sender, EventArgs e)
        {

            DataSet dsoffice = conexion.ConsultaOficina("");
            cmb_office.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_office.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            //cmb_office.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_office.DisplayMember = "OFICINA";
            cmb_office.ValueMember = "ID";
            cmb_office.SelectedValue = misglobales.oficina_id_oficina;
            
            // rptGetDataset();
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
            RunRptViewer();

//            this.rv_drop_zone_summary.RefreshReport();
        }
        #endregion

        #region Evento click del btn_generate
        private void btn_generate_Click(object sender, EventArgs e)
        {


        }
        #endregion 

        private void btn_generate_Click_1(object sender, EventArgs e)
        {
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
            RunRptViewer();
        }

        private void dtp_inicial_ValueChanged(object sender, EventArgs e)
        {

        }




    }
}
