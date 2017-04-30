using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_Reserva_detail : Form
    {
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String campos, tabla, sql, condicion, valores;

        #region constructor de la forma Frm_reserva
        public Frm_Reserva_detail()
        {
            InitializeComponent();
        }
        #endregion 

        #region Load de la forma Frm_reserva
        private void Frm_Reserva_Load(object sender, EventArgs e)
        {
            InicializaObjetos();
            inicializagridview();
        }
        #endregion 

        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview()
        {
            condicion = @" WHERE code = " + misglobales.NumeroReservacion + " order by organizador DESC";
            dg_contacts.EnableHeadersVisualStyles = false;
            dg_contacts.DataSource = conexion.ConsultaReserva(condicion);  //getdata(fuente;
            dg_contacts.Columns[0].Width = 50; //code reserva
            dg_contacts.Columns[0].Visible = true;
            dg_contacts.Columns[1].Width = 80; //Jump Date
            dg_contacts.Columns[1].Visible = true;
            dg_contacts.Columns[2].Width = 70; //Schedule
            dg_contacts.Columns[2].Visible = true;
            dg_contacts.Columns[3].Width = 50; //People Group
            dg_contacts.Columns[3].Visible = true;
            dg_contacts.Columns[4].Width = 130; //name
            dg_contacts.Columns[4].Visible = true;
            dg_contacts.Columns[5].Width = 130; //lastname
            dg_contacts.Columns[5].Visible = true;
            dg_contacts.Columns[6].Width = 150; //email
            dg_contacts.Columns[6].Visible = true;
            dg_contacts.Columns[7].Width = 100; //phone
            dg_contacts.Columns[7].Visible = true;
            dg_contacts.Columns[8].Width = 100; //phone2
            dg_contacts.Columns[8].Visible = false;
            dg_contacts.Columns[9].Width = 100; //movil
            dg_contacts.Columns[9].Visible = true;
            dg_contacts.Columns[10].Width = 80; //price
            dg_contacts.Columns[10].Visible = true;
            dg_contacts.Columns[11].Width = 80; //Deposit
            dg_contacts.Columns[11].Visible = true;
            dg_contacts.Columns[12].Width = 90; //Method
            dg_contacts.Columns[12].Visible = true;
            dg_contacts.Columns[13].Width = 90; //Card number 
            dg_contacts.Columns[13].Visible = true;
            dg_contacts.Columns[14].Width = 70; //Confirmation
            dg_contacts.Columns[14].Visible = true;
            dg_contacts.Columns[15].Width = 100; //Jumped
            dg_contacts.Columns[15].Visible = true;
            dg_contacts.Columns[16].Width = 100; //Vendor
            dg_contacts.Columns[16].Visible = true;
            dg_contacts.Columns[17].Width = 100; //comments
            dg_contacts.Columns[17].Visible = true;
            dg_contacts.Columns[18].Width = 300; //follow date
            dg_contacts.Columns[18].Visible = true;
            dg_contacts.Columns[19].Width = 200; //aff
            dg_contacts.Columns[19].Visible = false;
            dg_contacts.Columns[20].Width = 200; //video
            dg_contacts.Columns[20].Visible = false;
            dg_contacts.Columns[21].Width = 100; //videos
            dg_contacts.Columns[21].Visible = true;
            dg_contacts.Columns[22].Width = 200; //reference
            dg_contacts.Columns[22].Visible = true;
            dg_contacts.Columns[23].Width = 100; //reservation date
            dg_contacts.Columns[23].Visible = true;
            dg_contacts.Columns[24].Width = 100; //id
            dg_contacts.Columns[24].Visible = true;


            u.Formatodgv(dg_contacts);


        }
        #endregion

        #region Evento clik del boton btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Inicializa objetos
        private void InicializaObjetos()
        {
            txb_idreserva.Text = misglobales.NumeroReservacion.ToString();
            txb_idreserva.Enabled = false;
            txb_datereserva.Text = "";
            txb_datereserva.Enabled = false;
            dp_jumpdate.Text = DateTime.Now.ToShortDateString();
            txb_name.Text = "";
            txb_lastname.Text = "";
            txb_homephone.Text = "";
            txb_workphone.Text = "";
            txb_mobile.Text = "";
            txb_email.Text = "";
            txb_deposit.Text = "0";
            txb_metodo.Text = "13Mil";
            txb_card.Text = "";
            chk_confirm.Checked = false;
            //chk_student.Checked = false;
            //chk_video.Checked = false;
            //chk_realizado.Checked = false;
            //dp_horario2.Text= "8:30";
            txb_note.Text = "";
            //txb_personas.Text = "";
            //txb_videos.Text = "";
            txb_vendor.Text = misglobales.usuario_nombre + " " + misglobales.usuario_paterno;
            lbl_id.Text = "0";
            txb_price.Text = "0";
            dp_horario.Text = "08:00";

        }
        #endregion 

        #region Evento click en la celda del grid dg_contacts
        private void dg_contacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #endregion

        #region Evento borrar en un renglon del grid dg_contacts
        private void dg_contacts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                BorraRegistro();
            }
  


        }
        #endregion 

        #region Metodo Borra registro
        private void BorraRegistro()
        {
            tabla = "tb_reserva";
            condicion = "  code = '" + Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[0].Value) + "' and id = " + Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[24].Value) + " and organizador <> 1";  
            conexion.BorraRegistro(condicion, tabla);

        }
        #endregion 

        #region Metodo recontabiliza la reservacion
        private void ActualizaContadorReservacion()
        {
            try
            {
                campos = " personas = ( select count(*) From tb_reserva where code =  " + misglobales.NumeroReservacion.ToString() + ")";
                tabla = "tb_reserva";
                condicion = " where code = " + misglobales.NumeroReservacion.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);

                campos = " referencia  = (Select referencia From tb_reserva where code = " + misglobales.NumeroReservacion.ToString() + " and  id = ( select min(id) from  tb_reserva where code = " + misglobales.NumeroReservacion.ToString() + " ))  ";
                tabla = "tb_reserva";
                condicion = " where code = " + misglobales.NumeroReservacion.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);

                InicializaObjetos();
                inicializagridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try update reservation " + misglobales.NumeroReservacion + " please contact system administrator " + ex.Message);
            }
        }
        #endregion 

        #region Evento click del boton Save
        private void btn_save_Click(object sender, EventArgs e)
        {
            DateTime horario = Convert.ToDateTime(dp_horario.Text);

            if (InserUpdate(condicion) == "insert")
            {
                //insert
                DataSet dscode = new DataSet();
                tabla = "tb_reserva";
                condicion = "";
                sql = "SELECT MAX(CONVERT(INT,CODE))+1 AS CODE FROM dbo.tb_reserva";
                dscode = conexion.ConsultaUniversal(sql, condicion, tabla);
                txb_idreserva.Text = misglobales.NumeroReservacion.ToString(); // dscode.Tables[0].Rows[0].ItemArray[0].ToString();
                conexion.CloseDB();
                txb_datereserva.Text = Convert.ToString(DateTime.Now);

                

                tabla = "tb_reserva";
                campos = @"code, fecha_reserva, nombre, apellido, email, telefono, telefono2, celular, no_tarjeta, deposito, metodo, fecha_salto, 
                           horario,  vendedor, observaciones, fecha_seguimiento, precio, confirmacion ";
                valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + txb_datereserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                           txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ", '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "', '" +
                           txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103) , " + txb_price.Text + ", " + Convert.ToByte(chk_confirm.Checked)
                           ;

                try
                {
                    conexion.InsertTabla(campos, tabla, valores);
                    MessageBox.Show("Save Successfully");
                    InicializaObjetos();
                    inicializagridview();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try save new reservation" + ex.Message);
                }

            }
            else
            {
                //Update

                tabla = "tb_reserva";
                campos = @" nombre = '"+ txb_name.Text + "', " +
                         @" apellido = '"+txb_lastname.Text  +"', " +
                         @" email = '" + txb_email.Text + "', " +
                         @" telefono = '" + txb_homephone.Text + "', " +
                         @" telefono2 = '" + txb_workphone.Text + " ', " +
                         @" celular = '" + txb_mobile.Text + "', " +
                         @" no_tarjeta = '" + txb_card.Text + "', " +
                         @" deposito = " + txb_deposit.Text + ", " +
                         @" metodo = '" + txb_metodo.Text + "', " +
                         @" fecha_salto =  convert(varchar(10),'" + dp_jumpdate.Value + "',103), " +
                         @" horario = '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "', " +
                         //@" video = " + Convert.ToByte(chk_video.Checked) + ", " +
                         @" confirmacion = " + Convert.ToByte(chk_confirm.Checked) + ", " +
                         //@" realizado = " + Convert.ToByte(chk_realizado.Checked) + " ," +
                         @" vendedor = '" + txb_vendor.Text  + "', " +
                         @" observaciones = '" + txb_note.Text  + "', " +
                         @" fecha_seguimiento = convert(varchar(10),'" + dp_follow.Value + "',103), " +
                         //@" personas = " + txb_personas.Text + "," +
                         //@" videos = " + txb_videos.Text + ", " +
                         @" precio = " + txb_price.Text;
                condicion = " where code = '" + txb_idreserva.Text + "' and id = " + lbl_id.Text  ;
                try
                {
                    conexion.UpdateTabla(campos, tabla, condicion);
                    InicializaObjetos();
                    inicializagridview();
                }
                catch (Exception
                     ex)
                {

                    MessageBox.Show("Error try update Reservation" + ex.Message);
                }
            }

            ActualizaContadorReservacion();

        }
        #endregion

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            sql = @"select * from tb_reserva ";
            condicion = " where code = '" + txb_idreserva.Text + "' and id = " + lbl_id.Text;
            ds = conexion.ConsultaUniversal(sql, condicion, "tb_reserva");

            if (ds.Tables[0].Rows.Count == 0)
            {
                return "insert";
            }
            else
            {
                return "update";
            }
        }
        #endregion

        #region Evento click del boton Exportar
        private void btn_export_Click(object sender, EventArgs e)
        {

            condicion = @" order by CONVERT(datetime, fecha_reserva, 103)";
            DataSet ds = new DataSet();
            tabla = "tb_reserva";
            sql = @"SELECT code, CONVERT(VARCHAR(10), fecha_reserva, 103) as fecha_reserva, nombre, apellido, email, deposito, 
                                   fecha_salto, horario , precio,  video, personas, videos, referencia 
                              FROM dbo.tb_reserva";
            ds = conexion.ConsultaUniversal(sql, condicion, tabla);

            String path = "C:\\reservaciones\\";
            String cronometro = DateTime.Now.ToString("HHmmss");

            String[] texto;
            texto = new String[ds.Tables[0].Rows.Count + 1];
            //Rellenamos la cabecera del fichero
            texto[0] = String.Empty;
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                texto[0] += ds.Tables[0].Columns[i].ColumnName + "|";
            }
            //Rellenamos el detalle del fichero
            String linea;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                linea = String.Empty;
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    linea += ds.Tables[0].Rows[i][j].ToString() + "|";
                }
                texto[i + 1] = linea;
            }
            try
            {
                File.WriteAllLines(path + "reservacion_" + misglobales.usuario_usuario + "_" + cronometro + ".csv", texto);
                MessageBox.Show("Export reservations successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try export reservations to file in " + path + " : " + ex.Message);
            }
        }
        #endregion 

        #region Evento Click del btn_import
        private void btn_import_Click(object sender, EventArgs e)
        {
            tmr_import.Start();
            misglobales._Importing = 1;
            Frm_LoadReserva_access LoadReservations = new Frm_LoadReserva_access();
            LoadReservations.Show();
        }
        #endregion 

        #region Evento Tick del tm_import
        private void tmr_import_Tick(object sender, EventArgs e)
        {
            if (misglobales._Importing == 0) { tmr_import.Stop(); inicializagridview(); }
        }
        #endregion 

        #region Evento CellDoubleClick del grid dg_contacts
        private void dg_contacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txb_idreserva.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[0].Value);
                txb_datereserva.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[23].Value);
                txb_name.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[4].Value);
                txb_lastname.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[5].Value);
                txb_email.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[6].Value);
                txb_homephone.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[7].Value);
                txb_workphone.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[8].Value);
                txb_mobile.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[9].Value);
                txb_card.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[13].Value);
                txb_deposit.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[11].Value);
                txb_metodo.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[12].Value);
                dp_jumpdate.Value = Convert.ToDateTime(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[1].Value);
                if (dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[2].Value.ToString() != "")
                {
                    dp_horario2.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[2].Value);
                    dp_horario.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[2].Value);
                }
  
                chk_confirm.Checked = Convert.ToBoolean(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[14].Value);
               
                txb_vendor.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[16].Value);
                txb_note.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[17].Value);
                if (dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[18].Value.ToString().Length > 0)
                {
                    dp_follow.Value = Convert.ToDateTime(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[18].Value);
                }
                txb_price.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[10].Value);
                lbl_id.Text = Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[24].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to load informacion " + ex.Message);
            }
        }
        #endregion 

        private void dg_contacts_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ActualizaContadorReservacion();
            InicializaObjetos();
            inicializagridview();

        }


    }
}
