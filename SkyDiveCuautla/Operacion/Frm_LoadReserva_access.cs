using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
//using System.DateTime;
//using System.IFormatProvider;
using System.Globalization;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_LoadReserva_access : Form
    {

        OleDbConnection conn = new
        OleDbConnection();
        String campos, tabla, valores, sql, condicion;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        string referencia = "";


        public Frm_LoadReserva_access()
        {
            InitializeComponent();
        }

        #region Evento click del btn_browse
        private void btn_browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Add File";
            openFileDialog.Filter = "Reservation Files (*.mdb)|*.mdb";
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string sFilePath;
            sFilePath = openFileDialog.FileName;
            if (sFilePath == "")
                return;

            // make sure the file exists before adding
            // its path to the list of files to be
            // compressed
            if (System.IO.File.Exists(sFilePath) == false)
                return;
            else
                txb_pathfile.Text = sFilePath;
        }
        #endregion 

        #region Metodo Conexion Access
        public void ConectaAccess()
        {
            DateTime startdt = DateTime.MinValue;
            DateTime enddt = DateTime.MinValue;
            String str; Int32 Organizador = 0;
            Int32 CantidadRegistros = 0;
            Int32 Reservas = 0;


            sql = " truncate table TB_RESERVA ";
            condicion = "";
            tabla = "TB_RESERVA";
            conexion.ConsultaUniversal(sql, condicion, tabla);


                // TODO: Modify the connection string and include any
                // additional required properties for your database.
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                    @"Data source= " + txb_pathfile.Text;
                try
                {
                    conn.Open();
                    //OleDbCommand cmd = new OleDbCommand(@"Select ID_reserv, Fecha_resev, IIf(IsNull(Nombre),'',Nombre), IIf(IsNull(Apellido),'',Apellido), IIf(IsNull(email),'',email), IIf(IsNull(Telefono), '', telefono), IIf(IsNull(Telefono2),'',Telefono2), IIf(IsNull(Celular),'',Celular), IIf(IsNull(No_tarjeta),'',No_tarjeta), IIf(IsNull(Deposito),0,Deposito), IIf(IsNull(Metodo),'',Metodo), IIf(IsNull(fecha_salto),now(),fecha_salto), IIf(IsNull(Horario),null,Horario), IIf(IsNull(precioorg),0,precioorg)    from movimientos ", conn);
                    OleDbCommand cmd = new OleDbCommand(@"Select ID_reserv, Fecha_resev, IIf(IsNull(Nombre),'',Nombre), IIf(IsNull(Apellido),'',Apellido), IIf(IsNull(email),'',email), IIf(IsNull(Telefono), '', telefono), IIf(IsNull(Telefono2),'',Telefono2), IIf(IsNull(Celular),'',Celular), IIf(IsNull(No_tarjeta),'',No_tarjeta), IIf(IsNull(Deposito),0,Deposito), IIf(IsNull(Metodo),'',Metodo), IIf(IsNull(fecha_salto),now(),fecha_salto), IIf(IsNull(Horario),null,Horario), IIf(IsNull(precioorg),0,precioorg) , IIf(IsNull(preciogru),0,preciogru), personas, videos, confirmar, realizado, IIf(IsNull(vendedor),'',vendedor), IIf(IsNull(observaciones), '', observaciones), IIf(IsNull(fecha_seguimiento),now(), fecha_seguimiento), IIf(IsNull(AFF),0,AFF) from movimientos where fecha_salto BETWEEN  format('" + dp_dateini.Text + "','dd/mm/yyyy') and  format('" + dp_datefin.Text + "','dd/mm/yyyy') ", conn);
                    //where Fecha_resev between '" + dp_dateini.Value.Date.ToShortDateString() + "' and '" + dp_datefin.Value.Date.ToShortDateString() + "'", conn);
                    referencia = "";
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {

                        CantidadRegistros = cmd.CommandText.Count();
                        pb_UpLoad.Maximum = CantidadRegistros;
                        campos = @"code, fecha_reserva, nombre, apellido, email, telefono, Telefono2, celular, no_tarjeta, deposito, metodo, fecha_salto, horario, precio ,
                                   video, confirmacion, 
                                   realizado, vendedor, observaciones, fecha_seguimiento, AFF, personas, videos, referencia";
                        tabla = "tb_reserva";

                        Decimal numreg = 1;
                        while (rdr.Read())
                        {
                            pb_UpLoad.Value = Convert.ToInt32(numreg);


                            Int32 codigo = rdr.GetInt32(0);
                            DateTime fecha_reserva = rdr.GetDateTime(1);
                            string nombre = rdr.GetString(2);
                            string apellido = rdr.GetString(3);
                            string email = rdr.GetString(4);
                            string telefono = rdr.GetString(5);
                            string telefono2 = rdr.GetString(6);
                            string celular = rdr.GetString(7);
                            string Notarjeta = rdr.GetString(8);
                            decimal deposito = rdr.GetDecimal(9);
                            string metodo = rdr.GetString(10);
                            DateTime fecha_salto = rdr.GetDateTime(11);
                            DateTime horario = Convert.ToDateTime( rdr.GetDateTime(12).ToString());
                            //horario = Convert.ToString(horario.ToString()).Substring(12,13);
                            decimal precio_organizador = rdr.GetDecimal(13);
                            decimal precio_grupo = rdr.GetDecimal(14);
                            Int32 personas = rdr.GetInt32(15);
                            Int32 videos = rdr.GetInt32(16);
                            bool confirmar = rdr.GetBoolean(17);
                            bool realizado = rdr.GetBoolean(18);
                            string vendedor = rdr.GetString(19);
                            string observaciones = rdr.GetString(20);
                        
                            //DateTime fecha_seguimineto = rdr.GetDateTime(19);
                            //string aff = rdr.GetString(20);
                            //Int32 video = rdr.GetInt32(21);
                            str = nombre; str = str.Replace("'", "''"); nombre = str;
                            str = apellido; str = str.Replace("'", "''"); apellido = str;
                            str = email; str = str.Replace("'", "''"); email = str;
                            str = telefono; str = str.Replace("'", "''"); telefono = str;
                            str = telefono2; str = str.Replace("'", "''"); telefono2 = str;
                            str = celular; str = str.Replace("'", "''"); celular = str;
                            str = Notarjeta; str = str.Replace("'", "''"); Notarjeta = str;
                            str = metodo; str = str.Replace("'", "''"); metodo = str;
                            str = vendedor; str = str.Replace("'", "''"); vendedor = str;
                            str = observaciones; str = str.Replace("'", "''"); observaciones = str;
                           

                            

                            //String str = valores;
                            //str = str.Replace("'", "''");
                            //if (codigo == 14396) { MessageBox.Show(" Query: " + valores); }
                            Reservas = personas;
                            for (int a = 0; a < Reservas; a++)
                            {
                                if (Organizador == 0)
                                {
                                    referencia = rdr.GetString(2) + ' ' + rdr.GetString(3);
                                    //valores = @"'" + codigo + "', Convert(char(10),'" + fecha_reserva + "'), '" + nombre + "', '" + apellido + "', '" + email + "', '" + telefono + "', '" + telefono2 + "', '" +
                                    //      celular + "', '" + Notarjeta + "', " + deposito + ", '" + metodo + "', Convert(char(10),'" + fecha_salto + "'), substring('" + horario + "',12,13), " + precio_organizador +  ", 0, " + Convert.ToByte(confirmar) + ", " +
                                    //      Convert.ToByte(realizado) + ", '" + vendedor + "', '" + observaciones + "', getdate(), 0, " + personas + ", " + videos + ", '" + referencia + "'";
                                    valores = @"'" + codigo + "', Convert(char(10),'" + fecha_reserva + "'), '" + nombre + "', '" + apellido + "', '" + email + "', '" + telefono + "', '" + telefono2 + "', '" +
                                            celular + "', '" + Notarjeta + "', " + deposito + ", '" + metodo + "', Convert(char(10),'" + fecha_salto + "'), convert(varchar(8), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',114), " + precio_organizador + ", 0, " + Convert.ToByte(confirmar) + ", " +
                                            Convert.ToByte(realizado) + ", '" + vendedor + "', '" + observaciones + "', getdate(), 0, " + personas + ", " + videos + ", '" + referencia + "'";
                                }
                                else
                                {
                                    valores = @"'" + codigo + "', Convert(char(10),'" + fecha_reserva + "'), '" + nombre + "', '" + apellido + "', '', '', '', '', '" + Notarjeta + "', " + deposito + ", '" + metodo + "', Convert(char(10),'" + fecha_salto + "'),  convert(varchar(8), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',114), " + precio_grupo + ", 0, " + Convert.ToByte(confirmar) + ", " +
                                             Convert.ToByte(realizado) + ", '" + vendedor + "', '" + observaciones + "', getdate(), 0, " + personas + ", " + videos + ", '" + referencia + "'";
                                }
                                Organizador += 1;
                                conexion.InsertTabla(campos, tabla, valores);
                            }
                            numreg += 1;
                            Organizador = 0;
                        }
                    }

                }
                // Insert code to process data.

                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to data source access " + ex.Message);

                }
                conn.Close();

        }
        #endregion 


        #region LeerArchivo
        public void LeerArchivo()
        {
            ConectaAccess();
        }
        #endregion 


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            pb_UpLoad.Visible = true;
            pb_UpLoad.Minimum = 0;
 
            pb_UpLoad.Value = 1;
            try
            {
                LeerArchivo();
                MessageBox.Show(" Load successfully " + pb_UpLoad.Value);
                pb_UpLoad.Visible = false;
                misglobales._Importing = 0;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try Upload Reservations, " + ex.Message);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            
            misglobales._Importing = 0;
            this.Close();
        }

    }
}
