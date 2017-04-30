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
    public partial class Frm_Daily_Leadger_Detail : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_HistoryJumper
        public Frm_Daily_Leadger_Detail()
        {
            InitializeComponent();
        }
        #endregion 

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "ds_ledger_detail";
            sql = @"select name, convert(varchar(10),updatedate,23) as [Date], idchargetype, case when charge > 0 then charge else 0 end as [Charge],
                           case when charge < 0 then charge * -1 else 0 end Credit, payment, staff_payment, transfer_amt
                      from TB_LEDGER
                     where CONVERT(varchar(10), updatedate, 23) between '" + misglobales._DateIni + "' and '" + misglobales._DateFin + @"'
                     order by name, updatedate";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_ledger_detail");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_ledger_detail.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_ledger_detail.xlm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try construct xsd and xml files " + ex.Message);
            }
        }
        #endregion


        #region Metodo para cargar los datos
        private DataTable getdata2()
        {
            DataTable dt;
            DataSet dshistory;
            String StrOficina = " ";
            String StrUsuario = " ";

            if (cmb_office.SelectedValue.ToString() != "1")
            {
                StrOficina = " AND tbl.IDOFICINA = " + cmb_office.SelectedValue; 
            }
            else
            {
               StrOficina = " ";
            }


            if (cmb_jumper.Text != "")
            {
                StrUsuario = " and tbl.idusuario  = " + cmb_jumper.SelectedValue;
            }
            else
            {
                StrUsuario = " ";
            }


                sql = @"SELECT tbb.code_payment_type, SUM(tbl.payment) as payment, TBL.idusuario 
            into #portipo
            FROM dbo.TB_LEDGER as tbl INNER JOIN TB_BREAKEDOWN tbb on tbb.code_ledger = tbl.code
            WHERE CONVERT(varchar(10), tbl.updatedate, 23) 
            BETWEEN CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + @"'),23) 
            AND CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)                
            AND tbl.idchargetype <> 'HISTORIA' and tbl.jumper_code <> '9999-Tandem'
            " + StrOficina + StrUsuario + @"
            group by  tbb.code_payment_type, TBL.idusuario 
            union all
            SELECT tbbt.code_payment_type, sum(tbbt.payment) as payment, tbbt.idusuario 
            FROM TB_TANDEMUP tbl INNER JOIN TB_BREAKDOWNTANDEM tbbt on tbbt.code_tandem = tbl.code
            WHERE CONVERT(varchar(10), tbl.registertime, 23) 
            BETWEEN CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + @"'),23) 
            AND CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)   
            " + StrOficina + StrUsuario + @"
            group by tbbt.code_payment_type, tbbt.idusuario 
 
            SELECT code_payment_type, SUM(payment) payment FROM #portipo ";
                
 

            condicion = " GROUP BY code_payment_type";
            tabla = "TB_ledger_detail";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion




        #region Metodo para cargar los datos
        private DataTable getdata()
        {
            DataTable dt;
            DataSet dshistory;
            sql = @"select ltrim(rtrim(tbl.name)) as name, convert(varchar(10),tbl.updatedate,23) as [Date], ctct.charge_type as idchargetype, case when tbl.charge > 0 then tbl.charge else 0 end as [Charge],
                    case when tbl.charge < 0 then tbl.charge * -1 else 0 end Credit, tbl.payment, tbl.staff_payment, tbl.transfer_amt
                    from TB_LEDGER tbl left  join CT_CHARGE_TYPE ctct on ctct.codigo = tbl.idchargetype
                                             where CONVERT(varchar(10), tbl.updatedate, 23) between CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)                
                     and tbl.idchargetype <> 'HISTORIA' ";

            if (cmb_jumper.Text != "")
            {
               sql = sql +" AND idusuario  = " + cmb_jumper.SelectedValue;
            }
            if (cmb_office.SelectedValue.ToString() != "1")
            {
                sql = sql + " AND tbl.IDOFICINA = " + cmb_office.SelectedValue;
            }

            condicion = " order by name, convert(varchar(10),tbl.updatedate,23)";
            tabla = "TB_ledger_detail";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_daily_ledger_detail.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_daily_ledger_detail.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_ledger_detail.rdlc");
            //this.rv_charges_summary.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_charges_summary.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_ledger_detail", getdata());
                this.rv_daily_ledger_detail.LocalReport.DataSources.Clear();
                this.rv_daily_ledger_detail.LocalReport.DataSources.Add(rds);

                ReportDataSource rds2 = new ReportDataSource("ds_ledger_detail2", getdata2());
                this.rv_daily_ledger_detail.LocalReport.DataSources.Add(rds2);

                //this.rv_history_jumper.DataBind();
                this.rv_daily_ledger_detail.LocalReport.Refresh();
                this.rv_daily_ledger_detail.RefreshReport();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


        #region Carga Campos
        private void CargaCampos()
        {
            DataTable dt = new DataTable();


            sql = @"SELECT distinct tbl.idusuario, ctu.nombre + ' ' +  ctu.paterno  + ' ' + ctu.materno as name, tbl.updatedate
                      INTO #USUARIOS 
                      FROM TB_LEDGER tbl INNER JOIN CT_USUARIO ctu on ctu.idusuario = tbl.idusuario   
                
                   -- UNION ALL
                   -- SELECT distinct tbb.idusuario, ctu.nombre + ' ' +  ctu.paterno  + ' ' + ctu.materno as name, tbb.updatedate
                   --   FROM TB_BREAKEDOWN tbb    INNER JOIN CT_USUARIO ctu on ctu.idusuario = tbb.idusuario                 
                   -- UNION ALL
                   -- SELECT distinct tbb.idusuario, ctu.nombre + ' ' +  ctu.paterno  + ' ' + ctu.materno as name, tbb.updatedate
                   --   FROM TB_BREAKDOWNTANDEM tbb    INNER JOIN CT_USUARIO ctu on ctu.idusuario = tbb.idusuario                 
                   --  ORDER BY idusuario  
                     
                    SELECT DISTINCT idusuario, name
                      FROM #USUARIOS 
                      WHERE CONVERT(VARCHAR(10), updatedate,23) >=  CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and CONVERT(VARCHAR(10), updatedate,23) <=  CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)
                      ORDER BY name  ";
            DataSet dsjumpertype = conexion.ConsultaUniversal(sql, "", "TB_LEDGER");
            cmb_jumper.DataSource = dsjumpertype.Tables[0].DefaultView;
            cmb_jumper.AutoCompleteCustomSource = u.LoadAutoComplete(dsjumpertype, "name");
            cmb_jumper.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumper.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumper.DisplayMember = "name";
            cmb_jumper.ValueMember = "idusuario";
            cmb_jumper.SelectedItem = null;
            //dsjumpertype.Dispose();
        
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
        private void Frm_Daily_Leadger_Detail_Load(object sender, EventArgs e)
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
            CargaCampos();
            RunRptViewer();
            //this.rv_daily_ledger_detail.RefreshReport();
        }

        #endregion



        private void btn_generate_Click(object sender, EventArgs e)
        {
            
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
            RunRptViewer();
        }

        private void dtp_inicial_ValueChanged(object sender, EventArgs e)
        {
            misglobales._DateIni = dtp_inicial.Text;
            CargaCampos();
        }

        private void dtp_final_ValueChanged(object sender, EventArgs e)
        {
            misglobales._DateFin = dtp_final.Text;
            CargaCampos();
        }


    }
}
