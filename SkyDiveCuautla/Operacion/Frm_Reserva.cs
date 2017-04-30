using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_Reserva : Form
    {

        utilerias u = new utilerias();
        ConectaBD conexion = new ConectaBD();
        String condicion, condicion3, sql, tabla, campos, valores;
        String condicion2 = "";
        DateTime FechaFiltro ;
        Int32 FiltradoPorNombre = 0;

        #region Constructor de la forma Frm_Reserva
        public Frm_Reserva()
        {
            InitializeComponent();
        }
        #endregion

        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview()
        {
            tabla= "tb_reserva";
            FechaFiltro = Convert.ToDateTime(dp_gridinfo.Text);

            sql = @" SELECT code as [# Reservation],  convert(varchar(10),fecha_salto,23) as [Jump Date], horario [Time], nombre as [Name], apellido as [Last Name], personas [People on Group], email , telefono as [Phone], telefono2 as [Phone 2], celular as [Movil], 
                            no_tarjeta as [Card Number], deposito [$ Deposit], metodo [Method],  precio [Price Organizator], video ,  convert(bit,realizado) as [Jump], vendedor [Vendor], observaciones [Comments], 
                            fecha_seguimiento as [Follow Date], AFF,  videos [Count videos], referencia [Refernce by], convert(bit, organizador) [Is Organizator], iddropzone as [Dropzone], convert(varchar(10),fecha_reserva,23) as [Reservation Date]
                        FROM dbo.tb_reserva ";
            if (FiltradoPorNombre == 0)
            {
                condicion = @" WHERE (realizado = 0  and organizador = 1  and convert(varchar(10),fecha_salto,23) >=  convert(varchar(10),'" + FechaFiltro.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "',23) ) ";
            }
            else
            {
                condicion = @" WHERE (realizado = 0  and organizador = 1 ) ";
            }
            condicion3 = " order by fecha_salto, horario ";
            dg_contacts.EnableHeadersVisualStyles = false;
            dg_contacts.DataSource = conexion.ConsultaUniversalDT(sql, condicion + ' ' + condicion2 + ' ' + condicion3 , tabla);  //getdata(fuente;
            lbl_numreserva.Text = misglobales.contador.ToString();
            dg_contacts.Columns[0].Width = 80; //fecha reservaNumero de reservación
            dg_contacts.Columns[0].Visible = true;
            dg_contacts.Columns[1].Width = 70; //Fecha Salto
            dg_contacts.Columns[1].Visible = true;
            dg_contacts.Columns[2].Width = 60; //horario
            dg_contacts.Columns[2].Visible = true;
            dg_contacts.Columns[3].Width = 100; //nombre
            dg_contacts.Columns[3].Visible = true;
            dg_contacts.Columns[4].Width = 100; //apellido
            dg_contacts.Columns[4].Visible = true;
            dg_contacts.Columns[5].Width = 50; //personas
            dg_contacts.Columns[5].Visible = true;
            dg_contacts.Columns[6].Width = 170; //email
            dg_contacts.Columns[6].Visible = true;
            dg_contacts.Columns[7].Width = 100; //telefono
            dg_contacts.Columns[7].Visible = true;
            dg_contacts.Columns[8].Width = 100; //telefono 2
            dg_contacts.Columns[8].Visible = true;
            dg_contacts.Columns[9].Width = 100; //celular
            dg_contacts.Columns[9].Visible = true;
            dg_contacts.Columns[10].Width = 100; //No Tarjeta
            dg_contacts.Columns[10].Visible = true;
            dg_contacts.Columns[11].Width = 100; //deposito
            dg_contacts.Columns[11].Visible = true;
            dg_contacts.Columns[12].Width = 60; //metodo**
            dg_contacts.Columns[12].Visible = true;
            dg_contacts.Columns[13].Width = 80; //Precio Organizador
            dg_contacts.Columns[13].Visible = true;
            dg_contacts.Columns[14].Width = 100; // video
            dg_contacts.Columns[14].Visible = false;
            dg_contacts.Columns[15].Width = 100; //realizado
            dg_contacts.Columns[15].Visible = false;
            dg_contacts.Columns[16].Width = 80; //vendedor
            dg_contacts.Columns[16].Visible = true;
            dg_contacts.Columns[17].Width = 300; //observaciones
            dg_contacts.Columns[17].Visible = true;
            dg_contacts.Columns[18].Width = 200; //fecha seguimiento
            dg_contacts.Columns[18].Visible = true;
            dg_contacts.Columns[19].Width = 200; //AFF
            dg_contacts.Columns[19].Visible = false;
            dg_contacts.Columns[20].Width = 100; //videos
            dg_contacts.Columns[20].Visible = false;
            dg_contacts.Columns[21].Width = 200; //referencia
            dg_contacts.Columns[21].Visible = true;
            dg_contacts.Columns[22].Width = 100; //organizador
            dg_contacts.Columns[22].Visible = false;
            dg_contacts.Columns[23].Width = 100; //iddropzone
            dg_contacts.Columns[23].Visible = false;
            dg_contacts.Columns[24].Width = 100; //FechaReservacion
            dg_contacts.Columns[24].Visible = true;
            u.Formatodgv(dg_contacts);


        }
        #endregion

        #region Evento Load de la forma Frm_Reserva
        private void Frm_Reserva_Load(object sender, EventArgs e)
        {
            inicializagridview();
            InicializaObjetos();

        }
        #endregion 

        #region Evento click del boton btn_click
        private void btn_create_Click(object sender, EventArgs e)
        {
            if (txb_deposit.Text == "")
            {
                txb_deposit.Text = "0";
            }
            
            if (InserUpdate(condicion) == "insert")
            {
                //insert
                DataSet dscode = new DataSet();
                tabla = "tb_reserva";
                condicion = "";
                sql = "SELECT isnull(MAX(CONVERT(INT,CODE))+1,1) AS CODE FROM dbo.tb_reserva";
                dscode = conexion.ConsultaUniversal(sql, condicion, tabla);
                txb_idreserva.Text = dscode.Tables[0].Rows[0].ItemArray[0].ToString();
                conexion.CloseDB();
                dp_reserva.Text = Convert.ToString(DateTime.Now);

                tabla = "tb_reserva";
                campos = @"code, fecha_reserva, nombre, apellido, email, telefono, telefono2, celular, no_tarjeta, deposito, metodo, fecha_salto, 
                           horario,   vendedor, observaciones, fecha_seguimiento, personas, organizador, precio, realizado, referencia, iddropzone, idusuario";
                valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + dp_reserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                           txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ", '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), '" + dp_schedule.Text + "', '" +
                           txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103), " + txb_personas.Text + ", 0, " + txb_price.Text + ", 0, '" + txb_name.Text + " " + txb_lastname.Text + "',  2, " + misglobales.usuario_idusuario;

                Int32 Npersonas = Convert.ToInt32( txb_personas.Text);

                DateTime horario = Convert.ToDateTime( dp_schedule.Text);

                

                try
                {
                    for (int j = 0; j < Npersonas; j++)
                    {
                        campos = @"code, fecha_reserva, nombre, apellido, email, telefono, telefono2, celular, no_tarjeta, deposito, metodo, fecha_salto, 
                           horario,   vendedor, observaciones, fecha_seguimiento, personas, organizador, precio, realizado, referencia, iddropzone, idusuario, confirmacion";
                        if (j == 0) 
                        {
                            
                            valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + dp_reserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                                    txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ", '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), convert(varchar(8),'" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',114) , '" +
                                    txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103), " + txb_personas.Text + ", 1, " + txb_priceorg.Text + ",0, '" + txb_name.Text + " " + txb_lastname.Text + "',  2, " + misglobales.usuario_idusuario+ ", 0";
                        } 
                        else 
                        {
                            valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + dp_reserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                                    txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ", '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), convert(varchar(8), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',14), '" +
                                    txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103), " + txb_personas.Text + ", 0, " + txb_price.Text + ",0, '" + txb_name.Text + " " + txb_lastname.Text + "',  2, " + misglobales.usuario_idusuario + ", 0";
                        }
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    MessageBox.Show("Reservation: " + txb_idreserva.Text + " for " + txb_name.Text + " " + txb_lastname.Text + "  generated successfully ");
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
                campos = @" nombre = '" + txb_name.Text + "', " +
                         @" apellido = '" + txb_lastname.Text + "', " +
                         @" email = '" + txb_email.Text + "', " +
                         @" telefono = '" + txb_homephone.Text + "', " +
                         @" telefono2 = '" + txb_workphone.Text + " ', " +
                         @" celular = '" + txb_mobile.Text + "', " +
                         @" no_tarjeta = '" + txb_card.Text + "', " +
                         @" deposito = " + txb_deposit.Text + ", " +
                         @" metodo = '" + txb_metodo.Text + "', " +
                         @" fecha_salto =  convert(varchar(10),'" + dp_jumpdate.Value + "',103), " +
                         @" horario = '" + dp_horario.Text + "', " +
                         @" vendedor = '" + txb_vendor.Text + "', " +
                         @" observaciones = '" + txb_note.Text + "', " +
                         @" fecha_seguimiento = convert(varchar(10),'" + dp_follow.Value + "',103), " +
                         @" personas = " + txb_personas.Text + "," +
                         @" precio = " + txb_price.Text;
                condicion = " where code = '" + txb_idreserva.Text + "' and id = " + lbl_id.Text;
                try
                {
                    conexion.UpdateTabla(campos, tabla, condicion);
                    InicializaObjetos();
                    inicializagridview();
                }
                catch (Exception
                     ex)
                {

                    MessageBox.Show("Error try save or update this Reservation, please verify the information for each field is correct " + ex.Message);
                }
            }
        }
        #endregion

        #region Inicializa objetos
        private void InicializaObjetos()
        {
            txb_idreserva.Text = "";
            txb_idreserva.Enabled = false;
            dp_reserva.Text = "";
            dp_reserva.Enabled = false;
            txb_name.Text = "";
            txb_lastname.Text = "";
            txb_homephone.Text = "";
            txb_workphone.Text = "";
            txb_mobile.Text = "";
            txb_email.Text = "";
            txb_deposit.Text = "0";
            txb_metodo.Text = "13Mil";
            txb_card.Text = "";
            dp_horario.Text = "8:00";
            dp_schedule.Text = "8:00 AM";
            txb_note.Text = "";
            txb_personas.Text = "";
            txb_vendor.Text = misglobales.usuario_nombre + " " + misglobales.usuario_paterno;
            lbl_id.Text = "0";
            txb_price.Text = "0";
            txb_priceorg.Text = "0";
            txb_personas.Text = "1";
            dp_jumpdate.Text = DateTime.Now.ToShortDateString();
            


        }
        #endregion 

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            sql = @"select * from tb_reserva ";
            condicion = " where code = '" + txb_idreserva.Text + "' and organizador = 1";
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

        private void dg_contacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            misglobales.NumeroReservacion = Convert.ToInt32(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[0].Value.ToString());


            Frm_Reserva_detail frmreserva = new Frm_Reserva_detail();
            frmreserva.MdiParent = MDISkyDiveCuautla.ActiveForm;
            frmreserva.WindowState = FormWindowState.Maximized;
            frmreserva.Show();

        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            tmr_import.Start();
            misglobales._Importing = 1;
            Frm_LoadReserva_access LoadReservations = new Frm_LoadReserva_access();
            LoadReservations.Show();
        }

        private void tmr_import_Tick(object sender, EventArgs e)
        {
            if (misglobales._Importing == 0) { tmr_import.Stop(); inicializagridview(); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Reservaciones ReportaReserva = new Reportes.Frm_Reservaciones();
            ReportaReserva.MdiParent = MDISkyDiveCuautla.ActiveForm;
            ReportaReserva.WindowState = FormWindowState.Maximized;
            ReportaReserva.Show();
        }

        private void dp_gridinfo_ValueChanged(object sender, EventArgs e)
        {
            inicializagridview();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            DateTime St_Inicial = Convert.ToDateTime( dp_ini.Text);
            DateTime St_fin = Convert.ToDateTime(dp_fin.Text);

            condicion = @" where CONVERT(VARCHAR(10), fecha_salto, 23) between '" + St_Inicial.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' and '" + St_fin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + @"'
                           order by CONVERT(datetime, fecha_salto, 103) ";
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

        private void btn_filter_Click(object sender, EventArgs e)
        {
            if (txb_filtro_nombre.Text == "")
            {
                condicion2 = "";
                FiltradoPorNombre = 0;
            }
            else
            {
                FiltradoPorNombre = 1;
                condicion2 = @" and ( nombre + ' ' + apellido like '%" + txb_filtro_nombre.Text + "%') ";
            }
            inicializagridview();

        }

        #region Metodo Borra registro
        private void BorraRegistro()
        {
            tabla = "tb_reserva";
            condicion = "  code = '" + Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[0].Value) + "'";
            conexion.BorraRegistro(condicion, tabla);

        }
        #endregion 



        private void dg_contacts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                BorraRegistro();
            }
        }


    }
}
