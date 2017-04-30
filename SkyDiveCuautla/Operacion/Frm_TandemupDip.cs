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
using System.Data.SqlClient;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_TandemupDip : Form
    {

        #region Zona de Variables
        ConectaBD conexion = new ConectaBD();
        string condicion, campos, sql, tabla;
        int _idtandemup = 0;
        Int32 DioClickGrid = 0;
        utilerias u = new utilerias();
        #endregion
        public Frm_TandemupDip()
        {
            InitializeComponent();
        }

            #region Inicializa objetos
        private void InicializaObjetos()
        {
            txb_name.Text = "";
            txb_lastname.Text = "";
            txb_instructor.Text = "";
            btn_imprimir.Enabled = false;
            btn_imprimir.BackColor = Color.Gray;
        }
        #endregion

        #region Inicializa Datagridview de vuelos
        private void inicializagridvuelos()
        {
            condicion = " WHERE  CONVERT(VARCHAR(10), VUELOS.fechaabrevuelo, 23) = CONVERT(VARCHAR(10),getdate(),23)";
            dg_flights.EnableHeadersVisualStyles = false;
            dg_flights.DataSource = conexion.ConsultaVuelos(condicion);   //getdata(fuente;
            dg_flights.Columns[0].Width = 10; //IDVUELO
            dg_flights.Columns[0].Visible = false;
            dg_flights.Columns[1].Width = 10; //IDAERONAVE
            dg_flights.Columns[1].Visible = false;
            dg_flights.Columns[2].Width = 50; //NUMERO DE VUELO
            dg_flights.Columns[3].Width = 110; //MATRICULA
            dg_flights.Columns[4].Width = 70;  //CODIGO DEL AVION
            dg_flights.Columns[2].HeaderText = "#";
            dg_flights.Columns[3].HeaderText = "AIRCRAFT REGISTRATION NUMBER";
            dg_flights.Columns[4].HeaderText = "PLANE CODE";
            u.Formatodgv(dg_flights);


        }
        #endregion


        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview( string vuelo)
        {
            condicion = @" where convert(varchar(10), tbt.registertime,23) = convert(varchar(10), GETDATE(),23) and tbmc.idvuelo = " + vuelo + " ORDER BY tbt.lastname + ' ' + tbt.name asc ";
            misglobales.TandemSelection = 0;
            dg_tandemup.EnableHeadersVisualStyles = false;
            dg_tandemup.DataSource = conexion.ConsultaCertificados(condicion);  //getdata(fuente;
            dg_tandemup.Columns[0].Width = 100; //codegroup
            dg_tandemup.Columns[0].Visible = false;
            dg_tandemup.Columns[1].Width = 100; //idtandem
            dg_tandemup.Columns[1].Visible = false;
            dg_tandemup.Columns[2].Width = 135; //lastname
            dg_tandemup.Columns[2].Visible = true;
            dg_tandemup.Columns[3].Width = 135; //name
            dg_tandemup.Columns[3].Visible = true;
            dg_tandemup.Columns[4].Width = 135; //name
            dg_tandemup.Columns[4].Visible = false;            
            u.Formatodgv(dg_tandemup);

        }
        #endregion


        #region Ejecuta script
        public void ExecScript(String script)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" " + script;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();


//            SqlConnection conn = null;
//            conn = new SqlConnection(misglobales.cadenaconexionSQL);
//            conn.Open();
//            string strSQLCommand = @"
//                ALTER view v_tandem_certificate AS 
//                SELECT tbmc.idtandem, tbt.lastname ,  tbt.name tandemup,
//                       (Select ctj.idjumper from  bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE tbmc2 INNER JOIN bd_skydivecuautla.dbo.CT_JUMPER ctj on ctj.idjumper = tbmc2.idjumper and tbmc.codegroup = tbmc2.codegroup and tbmc2.idjumper <> 1207) idjumper, 
//                       (Select ctj.aliasjumper from  bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE tbmc3 INNER JOIN bd_skydivecuautla.dbo.CT_JUMPER ctj on ctj.idjumper = tbmc3.idjumper and tbmc.codegroup = tbmc3.codegroup and tbmc3.idjumper <> 1207) instructor, 
//	                   tbmc.codegroup
//                  FROM bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE tbmc
//                 INNER JOIN bd_skydivecuautla.dbo.TB_TANDEMUP tbt on tbt.idtandemup = tbmc.idtandem ";
//            SqlCommand command = new SqlCommand(strSQLCommand, conn);
//            string returnvalue = (string)command.ExecuteScalar();
//            conn.Close();


        }
        #endregion 



        #region Load del Frm_TandemupDip
        private void Frm_TandemupDip_Load(object sender, EventArgs e)
        {

            String Script = @"
                alter view [dbo].[v_tandem_certificate]
as
SELECT tbmc.idtandem, tbt.lastname ,  tbt.name tandemup, (Select top 1  ctj.idjumper from  dbo.TB_MANIFIESTO_CERTIFICATE tbmc2 INNER JOIN dbo.CT_JUMPER ctj on ctj.idjumper = tbmc2.idjumper and tbmc.codegroup = tbmc2.codegroup and tbmc2.idjumper <> 1207) idjumper, 
       (Select  top 1 case when ctj.aliasjumper = '' then ctj.nombre else ctj.aliasjumper end aliasjumper from  dbo.TB_MANIFIESTO_CERTIFICATE tbmc3 INNER JOIN dbo.CT_JUMPER ctj on ctj.idjumper = tbmc3.idjumper and tbmc.codegroup = tbmc3.codegroup and tbmc3.idjumper <> 1207) instructor, 
	   tbmc.codegroup
  FROM dbo.TB_MANIFIESTO_CERTIFICATE tbmc
 INNER JOIN dbo.TB_TANDEMUP tbt on tbt.idtandemup = tbmc.idtandem ";
            ExecScript(Script);
            InicializaObjetos();
            inicializagridvuelos();
            //inicializagridview();
            this.rpv_diploma.RefreshReport();
        }
        #endregion

        #region Evento CellClick del grid tandemup
        private void dg_tandemup_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            sql = @"SELECT tbmc.idtandem, tbt.lastname ,  tbt.name , 99999 idjumper, 'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx' instructor, tbmc.codegroup
                      INTO #diploma 
                      FROM dbo.TB_MANIFIESTO_CERTIFICATE tbmc
                     INNER JOIN dbo.TB_TANDEMUP tbt on tbt.idtandemup = tbmc.idtandem
                     WHERE codegroup = "+ Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value) + @" 

                    UPDATE d
                       SET d.idjumper = ctj.idjumper,
                           d.instructor = ctj.aliasjumper
                      FROM #diploma d
                      INNER JOIN dbo.TB_MANIFIESTO_CERTIFICATE tbmc on tbmc.codegroup = " + Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value) + @" AND d.codegroup = tbmc.codegroup
                      INNER JOIN dbo.CT_JUMPER ctj on ctj.idjumper = TBMC.idjumper

                      SELECT idtandem, name, lastname , idjumper, instructor, codegroup FROM #diploma";
            tabla = "TB_MANIFIESTO_CERTIFICATE";
            condicion = " " ;
            DataSet dspremanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);

            txb_name.Text = dspremanifiesto.Tables[0].Rows[0].ItemArray[1].ToString();
            txb_lastname.Text = dspremanifiesto.Tables[0].Rows[0].ItemArray[2].ToString();
            txb_instructor.Text = dspremanifiesto.Tables[0].Rows[0].ItemArray[4].ToString();
            _idtandemup = Convert.ToInt32( dspremanifiesto.Tables[0].Rows[0].ItemArray[0].ToString());
            DioClickGrid = 1;
            //misglobales._tandemupcode = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[20].Value); //+ "-TANDEM-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
            btn_imprimir.Enabled = true;
            btn_imprimir.BackColor = Color.Green;
            btn_imprimir.ForeColor = Color.Yellow;

    

                    btn_save2.Enabled = true;
                    RunRptViewer();

            }
        #endregion

        #region
        private void btn_save2_Click(object sender, EventArgs e)
        {
            DioClickGrid = 0;

            tabla = "TB_TANDEMUP";
            campos = @" name = '" + txb_name.Text + "', " +
                      " lastname = '" + txb_lastname.Text + "'";
            condicion = " where idtandemup = " + _idtandemup.ToString();
            conexion.UpdateTabla(campos, tabla, condicion);
     
            InicializaObjetos();
            //inicializagridview();
            inicializagridvuelos();
            btn_save2.Enabled = false;
            MessageBox.Show(" Save tandem name successfully !");
            RunRptViewer();
        }
        #endregion



        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "ds_tandem_certificated";
            sql = @"select idtandem,	lastname, tandemup, idjumper, instructor, codegroup from [v_tandem_certificate]
";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "v_tandem_certificate");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("D:\\Proyectos\\Skydivecuautla\\Skydive\\SkyDiveCuautla\\Datos\\ds_tandem_certificated.xsd");
                ds.WriteXml("D:\\Proyectos\\Skydivecuautla\\Skydive\\SkyDiveCuautla\\Datos\\ds_tandem_certificated.xlm");
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
            sql = @"SELECT idtandem,	lastname, tandemup, idjumper, instructor, codegroup FROM v_tandem_certificate";

            if (txb_name.Text != "" && txb_instructor.Text != "")
            {
                sql = sql + " where tandemup = '" + txb_name.Text + "' and instructor = '" + txb_instructor.Text + "'";
            }
            

            condicion = " ";
            tabla = "v_tandem_certificate";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion


        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rpv_diploma.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                        
            this.rpv_diploma.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_TandemCertificate.rdlc");
            
            try
            {
            
                ReportDataSource rds = new ReportDataSource("ds_tandem_certificated", getdata());
                this.rpv_diploma.LocalReport.DataSources.Clear();
                this.rpv_diploma.LocalReport.DataSources.Add(rds);
                this.rpv_diploma.LocalReport.Refresh();
                this.rpv_diploma.RefreshReport();
                this.rpv_diploma.SetDisplayMode(DisplayMode.PrintLayout);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            //rptGetDataset();
            RunRptViewer();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_flights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            inicializagridview(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[0].Value.ToString());

        }




    }
}
