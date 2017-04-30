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
    public partial class Frm_Manifiesto : Form
    {

        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        #region Constuctor de la Forma Frm_Manifiesto
        public Frm_Manifiesto()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsManifiesto";
            sql = @" SELECT tbm.idmanifiesto, tbm.idvuelo, cta.matricula, tbv.numerovuelo, ctj.nombre,tbm.idjumptype, tbv.Capacity, tbv.Loaded, tbv.fechaabrevuelo [date]
  FROM bd_skydivecuautla.dbo.TB_MANIFIESTO  tbm INNER JOIN bd_skydivecuautla.dbo.TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo and tbv.idvuelo = " + misglobales.id1 + @"
 INNER JOIN bd_skydivecuautla.dbo.CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
 INNER JOIN bd_skydivecuautla.dbo.CT_JUMPER ctj on ctj.idjumper = tbm.idjumper AND CTJ.codigo <> '9999-Tandem'
 UNION ALL
SELECT tbm.idmanifiesto, tbm.idvuelo, cta.matricula, tbv.numerovuelo, ctj.nombre,tbm.idjumptype, tbv.Capacity, tbv.Loaded, tbv.fechaabrevuelo [date]
  FROM bd_skydivecuautla.dbo.TB_MANIFIESTO  tbm INNER JOIN bd_skydivecuautla.dbo.TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo and tbv.idvuelo = " + misglobales.id1 + @"
 INNER JOIN bd_skydivecuautla.dbo.CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
 INNER JOIN bd_skydivecuautla.dbo.CT_JUMPER ctj on ctj.idjumper = tbm.idjumper AND CTJ.codigo = '9999-Tandem'";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_MANIFIESTO");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_manifiesto.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_manifiesto.xlm");
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
//            sql = @"
//                 SELECT tbm.idmanifiesto, tbm.idvuelo, cta.matricula, tbv.numerovuelo, ctj.nombre,tbm.idjumptype, tbv.Capacity, tbv.Loaded, convert(varchar(10),tbv.fechacierrevuelo,23) [date]
//                  FROM bd_skydivecuautla.dbo.TB_MANIFIESTO  tbm INNER JOIN bd_skydivecuautla.dbo.TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo and tbv.idvuelo = " + misglobales.id1 + @"
//                 INNER JOIN bd_skydivecuautla.dbo.CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
//                 INNER JOIN bd_skydivecuautla.dbo.CT_JUMPER ctj on ctj.idjumper = tbm.idjumper AND CTJ.codigo <> '9999-Tandem'
//                 UNION ALL
//                SELECT tbm.idmanifiesto, tbm.idvuelo, cta.matricula, tbv.numerovuelo, ctj.name as nombre,tbm.idjumptype, tbv.Capacity, tbv.Loaded, convert(varchar(10),tbv.fechacierrevuelo,23) [date]
//                  FROM bd_skydivecuautla.dbo.TB_MANIFIESTO  tbm INNER JOIN bd_skydivecuautla.dbo.TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo and tbv.idvuelo = " + misglobales.id1 + @"
//                 INNER JOIN bd_skydivecuautla.dbo.CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
//                 INNER JOIN bd_skydivecuautla.dbo.TB_TANDEMUP ctj on ctj.idtandemup = tbm.idtandem";
            sql = @"
SELECT TB_MANIFIESTO.IDMANIFIESTO,
       TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
       TB_MANIFIESTO.IDJUMPER,  CT_JUMPER.nombre   as JUMPER_NAME,
       JUMPTYPE.idjumptype, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, TB_VUELOS.numerovuelo, TB_VUELOS.Capacity, TB_VUELOS.Loaded, TB_VUELOS.fechaabrevuelo
  into #MANIFIESTO
  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
 INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem + @"
 INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.id1 + @"
UNION ALL 
SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
       TB_MANIFIESTO.idtandem, CT_JUMPER.lastname + ' ' + CT_JUMPER.name  as JUMPER_NAME,
       JUMPTYPE.idjumptype, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, TB_VUELOS.numerovuelo, TB_VUELOS.Capacity, TB_VUELOS.Loaded,  TB_VUELOS.fechaabrevuelo
  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
 INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
 INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.id1 + @"


update tandemup 
   set tandemup.video = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices = 1
   
   update tandemup 
   set tandemup.handvideo = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices = 2
  
   
SELECT idmanifiesto, idvuelo,  matricula, numerovuelo, case when idjumper in(select idjumper
   from tb_instructors_activity
  where CONVERT(varchar(10), registertime,23) = CONVERT(varchar(10), getdate(),23))  then  JUMPER_NAME else jumper_name end as nombre, 
  idjumptype, Capacity, Loaded, fechaabrevuelo as [date]
  FROM #MANIFIESTO
  ORDER BY idmanifiesto
";
            condicion = " ";
            tabla = "TB_MANIFIESTO";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_manifiesto.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);


            //this.rv_history_jumper.LocalReport.ReportPath = (strAppDir+ "\\Reports\\Rpt_History_Jumper.rdlc");
            this.rv_manifiesto.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_manifiesto.rdlc");
            //this.rv_tandemdue.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_Tandem_Due.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("ds_manifiesto", getdata());
                this.rv_manifiesto.LocalReport.DataSources.Clear();
                this.rv_manifiesto.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_manifiesto.LocalReport.Refresh();
                this.rv_manifiesto.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion


        #region Load de la forma  Frm_Manifiesto
        private void Frm_Manifiesto_Load(object sender, EventArgs e)
        {
           // rptGetDataset();
            RunRptViewer();

        }
        #endregion 


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
