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
    public partial class Frm_Reservaciones : Form
    {


        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla;
        #endregion

        public Frm_Reservaciones()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            misglobales._DateIni = dtp_inicial.Text;
            misglobales._DateFin = dtp_final.Text;
           // rptGetDataset();
            RunRptViewer();
        }


        #region Metodo para cargar los datos
        private DataTable getdata()
        {
            DataTable dt;
            DataSet dshistory;
            sql = @"Select   horario, CONVERT(varchar(10), fecha_salto, 23) as fecha_salto, code, fecha_reserva, nombre + ' ' + apellido as name, telefono, telefono2, celular, deposito, metodo, personas as tandem, videos, convert(bit, confirmacion) confirmacion
                      From dbo.tb_reserva
                     Where CONVERT(varchar(10), fecha_salto, 23) between CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)  
                       and organizador = 1
                       and iddropzone = " + misglobales.dropzone + 
                     " order by CONVERT(varchar(10), fecha_salto, 23), convert(varchar(13), horario, 114), code";
            condicion = " ";
            tabla = "TB_reserva";
            dshistory = conexion.ConsultaUniversal(sql, condicion, tabla);
            dt = dshistory.Tables[0];
            return dt;
        }
        #endregion

        #region Metodo para Carga un Dataset del Reporte
        private void rptGetDataset()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "dsReserva";
            sql = @"Select   horario, fecha_salto, code, fecha_reserva, nombre + ' ' + apellido, telefono, telefono2, celular, deposito, metodo, personas as tandem, videos, convert(bit, confirmacion) confirmacion
                      From dbo.tb_reserva
                     Where CONVERT(varchar(10), fecha_salto, 23) between CONVERT(varchar(10), convert(date,'" + misglobales._DateIni + "'),23) and CONVERT(varchar(10), convert(date,'" + misglobales._DateFin + @"'),23)  
                       and organizador = 1
                       and iddropzone = " + misglobales.dropzone + 
                   "  order by CONVERT(varchar(10), fecha_salto, 23), convert(varchar(13), horario, 114), code";
            try
            {
                ds = conexion.ConsultaUniversal(sql, "", "TB_reserva");
                ds.GetXmlSchema();
                ds.WriteXmlSchema("/SkyDiveCuautla/BaseDatos/ds_reserva.xsd");
                ds.WriteXml("/SkyDiveCuautla/BaseDatos/ds_reserva.xlm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try construct xsd and xml files " + ex.Message);
            }



        }
        #endregion

        #region RunRptViewer
        private void RunRptViewer()
        {
            this.rv_reserva.Reset();
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            //this.rv_reserva.LocalReport.ReportPath = (strAppDir + "\\Reports\\Rpt_Reservaciones.rdlc");
            if (misglobales.dropzone == 2)
            {
                this.rv_reserva.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_Reservaciones_cuautla.rdlc");
            } else if (misglobales.dropzone == 4)
            {
                this.rv_reserva.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_Reservaciones_puebla.rdlc");
            } else if (misglobales.dropzone == 3)
            {
                this.rv_reserva.LocalReport.ReportPath = ("C:\\SkyDiveCuautla\\Reportes\\Rpt_Reservaciones_puertoescondido.rdlc");
            } 
            
            //this.rv_reserva.LocalReport.ReportPath = ("C:\\Users\\ccruzr\\Google Drive\\WHTMX\\Clientes\\SkyDiveCuautla\\DESARROLLO\\SkyDiveCuautla\\SkyDiveCuautla\\Reportes\\Rpt_charges_summary.rdlc");
            try
            {
                // ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getdata());
                ReportDataSource rds = new ReportDataSource("dsReserva", getdata());
                this.rv_reserva.LocalReport.DataSources.Clear();
                this.rv_reserva.LocalReport.DataSources.Add(rds);
                //this.rv_history_jumper.DataBind();
                this.rv_reserva.LocalReport.Refresh();
                this.rv_reserva.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try generate this report" + ex.Message);
                return;
            }

        }
        #endregion

        private void Frm_Reservaciones_Load(object sender, EventArgs e)
        {
           dtp_inicial.Value = misglobales.Rangoini;
           dtp_final.Value =  misglobales.Rangofin;
           btn_generate.Focus();
           btn_generate_Click(sender, e);
        }

    }
}
