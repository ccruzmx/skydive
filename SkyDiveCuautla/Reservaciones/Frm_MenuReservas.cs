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
using System.Net.Mail;

namespace SkyDiveCuautla.Reservaciones
{
    public partial class Frm_MenuReservas : Form
    {

        utilerias u = new utilerias();
        ConectaBD conexion = new ConectaBD();
        String condicion, condicion3, sql, tabla, campos, valores;
        String condicion2 = "";
        DateTime FechaFiltro, FechafiltroFin;
        Int32 FiltradoPorNombre = 0;
        Int32 iddropzone = 1;
        Int32 IntEsCambio = 0;
        Int32 notconfirm = 0;
        String ZonaAnterior = "";
        String ZonaNueva = "";

        #region Constructor de la forma MenuReservas
        public Frm_MenuReservas()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento click del boton right
        private void btn_right_Click(object sender, EventArgs e)
        {
            tbc_reserve.SelectedIndex = tbc_reserve.TabPages.IndexOf(tbc_reserve.SelectedTab) + 1;
        }
        #endregion

        #region evento click del boton left
        private void btn_left_Click(object sender, EventArgs e)
        {
            if (tbc_reserve.TabPages.IndexOf(tbc_reserve.SelectedTab) > 0)
            {
                tbc_reserve.SelectedIndex = tbc_reserve.TabPages.IndexOf(tbc_reserve.SelectedTab) - 1;
            }
        }
        #endregion

        #region evento click del boton reporte
        private void btn_reporte_Click(object sender, EventArgs e)
        {

            misglobales.Rangoini = Convert.ToDateTime(dp_gridinfo.Text);
            misglobales.Rangofin = Convert.ToDateTime(dp_gridinfo_fin.Text); 
            Reportes.Frm_Reservaciones ReportaReserva = new Reportes.Frm_Reservaciones();
            //ReportaReserva.MdiParent = MDISkyDiveCuautla.ActiveForm;
            ReportaReserva.WindowState = FormWindowState.Maximized;
            ReportaReserva.Show();
        }
        #endregion

        #region Eventoclick del boton export
        private void btn_export_Click(object sender, EventArgs e)
        {
            DateTime St_Inicial = Convert.ToDateTime(dp_gridinfo.Text);
            DateTime St_fin = Convert.ToDateTime(dp_gridinfo_fin.Text);

            condicion = @" where CONVERT(VARCHAR(10), fecha_salto, 23) between '" + St_Inicial.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' and '" + St_fin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + @"'
                          and iddropzone in (Select idoficina from CT_OFICINA where nombre = '" +cmb_office.Text +"' )   order by CONVERT(datetime, fecha_salto, 103) ";
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
                File.WriteAllLines(path + "reservacion_" + cmb_office.Text + "_"+ misglobales.usuario_usuario + "_" + cronometro + ".csv", texto);
                MessageBox.Show("Export reservations successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try export reservations to file in " + path + " : " + ex.Message);
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

        #region Inicializa objetos
        private void InicializaObjetos()
        {

            grp_emailing.Visible = false;

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
            if (cmb_office.Text == "PUEBLA")
            { 
                txb_metodo.Text = "15Mil"; 
            }
            else if (cmb_office.Text == "CUAUTLA")
            {
                txb_metodo.Text = "17Mil";
            }
            else 
            {
                txb_metodo.Text = "13Mil";
            }

            
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
            //sql = "Select idoficina, upper(nombre) From bd_skydivecuautla.dbo.CT_OFICINA";
            DataSet dsoffice = conexion.ConsultaOficina("");
            cmb_office.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_office.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            //cmb_office.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_office.DisplayMember = "OFICINA";
            cmb_office.ValueMember = "ID";
            cmb_office.SelectedValue = iddropzone; // misglobales.oficina_id_oficina;
           

            cmb_dropzone.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_dropzone.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            cmb_dropzone.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_dropzone.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_dropzone.DisplayMember = "OFICINA";
            cmb_dropzone.ValueMember = "ID";
            //cmb_dropzone.SelectedItem = misglobales.oficina_id_oficina;
            cmb_dropzone.SelectedValue = iddropzone; // misglobales.oficina_id_oficina;
            chk_lista.Checked = false;
            dg_contacts.Visible = false;
            gp_palitos.Visible = false;


            /* cargar el combo cmb_budget*/

            DataSet dsbudget = conexion.Consultabudget("");
            cmb_budget.DataSource = dsbudget.Tables[0].DefaultView;
            cmb_budget.AutoCompleteCustomSource = LoadAutoComplete(dsbudget, "DESCRIPCION");
            cmb_budget.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_budget.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_budget.DisplayMember = "DESCRIPCION";
            cmb_budget.ValueMember = "idbudget";
            cmb_budget.SelectedItem = 0;
            //cmb_budget.SelectedValue = 1; // misglobales.oficina_id_oficina;




            btn_create.Visible = true;
            btn_closegroup.Visible = false;
            btn_create.Text = "Generate Reservation";
            lbl_reservations.Text = "General Reservations";



            lbl_titulo_home.Text = cmb_office.Text;

            if (misglobales.dropzone == 2)
            {

                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");

            }
            else if (misglobales.dropzone == 4)
            {
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
            }
            else if (misglobales.dropzone == 3)
            {
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
            }
            else
            {
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");


            }


        }
        #endregion 

        #region Inicializa DataGrid Plane
        private void InicializaGridviewPlane()
        {
            try
            {
                condicion = iddropzone.ToString();


                dg_calendar.EnableHeadersVisualStyles = false;
                dg_calendar.DataSource = conexion.Calendario(condicion);
                // idpaymenttype, code, payment_type, payment
                dg_calendar.Columns[0].Width = 10; //idcalendar
                dg_calendar.Columns[0].Visible = false;
                dg_calendar.Columns[1].Width = 85; //horario
                dg_calendar.Columns[1].Visible = true;
                dg_calendar.Columns[2].Width = 80; //capacidad_lunes
                dg_calendar.Columns[2].Visible = false;
                dg_calendar.Columns[3].Width = 80; //capacidad_martes
                dg_calendar.Columns[3].Visible = false;
                dg_calendar.Columns[4].Width = 80;//capacidad_miercoles
                dg_calendar.Columns[4].Visible = true;
                dg_calendar.Columns[5].Width = 80; //capacidad_jueves
                dg_calendar.Columns[5].Visible = true;
                dg_calendar.Columns[6].Width = 80; //capacidad_viernes
                dg_calendar.Columns[6].Visible = true;
                dg_calendar.Columns[7].Width = 80;//capacidad_sabado
                dg_calendar.Columns[7].Visible = true;
                dg_calendar.Columns[8].Width = 80;//capacidad_domingo
                dg_calendar.Columns[8].Visible = true;
                dg_calendar.Columns[9].Width = 80;//iddropzone
                dg_calendar.Columns[9].Visible = false;
                dg_calendar.Columns[10].Width = 150;//updatedate
                dg_calendar.Columns[10].Visible = true;
                dg_calendar.Columns[11].Width = 80;//idusuario
                dg_calendar.Columns[11].Visible = false;


                dg_calendar.Columns[1].HeaderText = "Horario";
                dg_calendar.Columns[4].HeaderText = "Miercoles";
                dg_calendar.Columns[5].HeaderText = "Jueves";
                dg_calendar.Columns[6].HeaderText = "Viernes";
                dg_calendar.Columns[7].HeaderText = "Sábado";
                dg_calendar.Columns[8].HeaderText = "Domingo";


                u.Formatodgv(dg_calendar);

                dg_calendar.ReadOnly = false;
                dg_calendar.Columns[1].ReadOnly = true;
                dg_calendar.Columns[4].ReadOnly = false;
                dg_calendar.Columns[5].ReadOnly = false;
                dg_calendar.Columns[6].ReadOnly = false;
                dg_calendar.Columns[7].ReadOnly = false;
                dg_calendar.Columns[8].ReadOnly = false;
                dg_calendar.Columns[10].ReadOnly = true;





                dg_exeption.EnableHeadersVisualStyles = false;
                dg_exeption.DataSource = conexion.ExceptionCalendar(condicion);
                // idpaymenttype, code, payment_type, payment
                dg_exeption.Columns[0].Width = 10; //idcalendar
                dg_exeption.Columns[0].Visible = false;
                dg_exeption.Columns[1].Width = 85; //horario
                dg_exeption.Columns[1].Visible = true;
                dg_exeption.Columns[2].Width = 80; //capacidad_lunes
                dg_exeption.Columns[2].Visible = false;
                dg_exeption.Columns[3].Width = 80; //capacidad_martes
                dg_exeption.Columns[3].Visible = false;
                dg_exeption.Columns[4].Width = 80;//capacidad_miercoles
                dg_exeption.Columns[4].Visible = true;
                dg_exeption.Columns[5].Width = 80; //capacidad_jueves
                dg_exeption.Columns[5].Visible = true;
                dg_exeption.Columns[6].Width = 80; //capacidad_viernes
                dg_exeption.Columns[6].Visible = true;
                dg_exeption.Columns[7].Width = 80;//capacidad_sabado
                dg_exeption.Columns[7].Visible = true;
                dg_exeption.Columns[8].Width = 80;//capacidad_domingo
                dg_exeption.Columns[8].Visible = true;
                dg_exeption.Columns[9].Width = 80;//iddropzone
                dg_exeption.Columns[9].Visible = false;
                dg_exeption.Columns[10].Width = 150;//updatedate
                dg_exeption.Columns[10].Visible = true;
                dg_exeption.Columns[11].Width = 80;//idusuario
                dg_exeption.Columns[11].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Load de la forma MenuReservas
        private void Frm_MenuReservas_Load(object sender, EventArgs e)
        {
            txb_url.Text = "http://" + misglobales.servername.ToString() + ":8088/reservaciones";
            

            InicializaObjetos();
            inicializagridviewHome();
            InicializaGridviewPlane();
        }
        #endregion

        #region Evento click del boton exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Inicializa DataGridViewHome
        private void inicializagridviewHome()
        {
            tabla = "tb_reserva";
            FechaFiltro = Convert.ToDateTime(dp_gridinfo.Text);
            FechafiltroFin = Convert.ToDateTime(dp_gridinfo_fin.Text);



            sql = @" SELECT  convert(varchar(10),tbr.fecha_reserva,23) as [Reservation Date], tbr.code as [# Reservation],  convert(varchar(10),tbr.fecha_salto,23) as [Jump Date], tbr.horario [Time], tbr.nombre as [Name], tbr.apellido as [Last Name], tbr.personas [People on Group], tbr.email , tbr.telefono as [Phone], tbr.telefono2 as [Phone 2], tbr.celular as [Movil], 
                    tbr.no_tarjeta as [Card Number], tbr.deposito [$ Deposit], tbr.metodo [Altitude],  tbr.precio [Price Organizator], tbr.video ,  convert(bit,tbr.realizado) as [Jump], tbr.vendedor [Vendor], tbr.observaciones [Comments], 
                    tbr.fecha_seguimiento as [Follow Date], tbr.AFF,  tbr.videos [Count videos], tbr.referencia [Refernce by], convert(bit, tbr.organizador) [Is Organizator], tbr.iddropzone as [Dropzone],  ctb.description as [Budget Category], tbr.confirmacion as CONFIRM,cto.Nombre
                    FROM dbo.tb_reserva  tbr INNER JOIN dbo.CT_OFICINA cto on cto.idoficina = tbr.iddropzone left outer join dbo.ct_budget ctb on ctb.idbudget = tbr.idbudget";
            if (FiltradoPorNombre == 0)
            {
                condicion = @" WHERE (tbr.realizado = 0  and tbr.organizador = 1  and convert(varchar(10),tbr.fecha_salto,23) >=  convert(varchar(10),'" + FechaFiltro.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "',23)  and convert(varchar(10),tbr.fecha_salto,23) <=  convert(varchar(10),'" + FechafiltroFin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "',23) ) and tbr.iddropzone = " + iddropzone;
            }
            else
            {
                //condicion = @" WHERE (realizado = 0  and organizador = 1 ) and iddropzone = " + iddropzone;
                condicion = @" WHERE (tbr.realizado = 0  and tbr.organizador = 1 )";
            }

            if (notconfirm == 1 )
                {
                    condicion2 = condicion2 + " and confirmacion = 0";
                    condicion3 = " order by  tbr.personas desc";
                }
            else
            {
                condicion2 = condicion2 + " and confirmacion in( 0,1)";
                condicion3 = " order by tbr.fecha_salto, tbr.horario, tbr.organizador asc";
            }
            

            dg_contacts.EnableHeadersVisualStyles = false;
            dg_contacts.DataSource = conexion.ConsultaUniversalDT(sql, condicion + ' ' + condicion2 + ' ' + condicion3, tabla);  //getdata(fuente;
            lbl_numreserva.Text = misglobales.contador.ToString();
            dg_contacts.Columns[0].Width = 100; //dropzone
            dg_contacts.Columns[0].Visible = true;
            dg_contacts.Columns[1].Width = 80; //fecha reservaNumero de reservación
            dg_contacts.Columns[1].Visible = true;
            dg_contacts.Columns[2].Width = 100; //Fecha Salto
            dg_contacts.Columns[2].Visible = true;
            dg_contacts.Columns[3].Width = 60; //horario
            dg_contacts.Columns[3].Visible = true;
            dg_contacts.Columns[4].Width = 100; //nombre
            dg_contacts.Columns[4].Visible = true;
            dg_contacts.Columns[5].Width = 100; //apellido
            dg_contacts.Columns[5].Visible = true;
            dg_contacts.Columns[6].Width = 50; //personas
            dg_contacts.Columns[6].Visible = true;
            dg_contacts.Columns[7].Width = 170; //email
            dg_contacts.Columns[7].Visible = true;
            dg_contacts.Columns[8].Width = 100; //telefono
            dg_contacts.Columns[8].Visible = true;
            dg_contacts.Columns[9].Width = 100; //telefono 2
            dg_contacts.Columns[9].Visible = true;
            dg_contacts.Columns[10].Width = 100; //celular
            dg_contacts.Columns[10].Visible = true;
            dg_contacts.Columns[11].Width = 100; //No Tarjeta
            dg_contacts.Columns[11].Visible = true;
            dg_contacts.Columns[12].Width = 100; //deposito
            dg_contacts.Columns[12].Visible = false;
            dg_contacts.Columns[13].Width = 60; //metodo**
            dg_contacts.Columns[13].Visible = true;
            dg_contacts.Columns[14].Width = 80; //Precio Organizador
            dg_contacts.Columns[14].Visible = true;
            dg_contacts.Columns[15].Width = 100; // video
            dg_contacts.Columns[15].Visible = false;
            dg_contacts.Columns[16].Width = 100; //realizado
            dg_contacts.Columns[16].Visible = false;
            dg_contacts.Columns[17].Width = 80; //vendedor
            dg_contacts.Columns[17].Visible = true;
            dg_contacts.Columns[18].Width = 300; //observaciones
            dg_contacts.Columns[18].Visible = true;
            dg_contacts.Columns[19].Width = 200; //fecha seguimiento
            dg_contacts.Columns[19].Visible = true;
            dg_contacts.Columns[20].Width = 200; //AFF
            dg_contacts.Columns[20].Visible = false;
            dg_contacts.Columns[21].Width = 100; //videos
            dg_contacts.Columns[21].Visible = false;
            dg_contacts.Columns[22].Width = 200; //referencia
            dg_contacts.Columns[22].Visible = true;
            dg_contacts.Columns[23].Width = 100; //organizador
            dg_contacts.Columns[23].Visible = false;
            dg_contacts.Columns[24].Width = 100; //iddropzone
            dg_contacts.Columns[24].Visible = false;
            dg_contacts.Columns[25].Width = 100; //FechaReservacion
            dg_contacts.Columns[25].Visible = true;
            dg_contacts.Columns[26].Width = 100; //idbudget
            dg_contacts.Columns[26].Visible = true;
            u.Formatodgv(dg_contacts);


            dg_contactGeneral.EnableHeadersVisualStyles = false;
            dg_contactGeneral.DataSource = conexion.ConsultaUniversalDT(sql, condicion + ' ' + condicion2 + ' ' + condicion3, tabla);  //getdata(fuente;
            lbl_numreserva.Text = misglobales.contador.ToString();
            dg_contactGeneral.Columns[0].Width = 100; //dropzone
            dg_contactGeneral.Columns[0].Visible = true;
            dg_contactGeneral.Columns[1].Width = 80; //fecha reservaNumero de reservación
            dg_contactGeneral.Columns[1].Visible = true;
            dg_contactGeneral.Columns[2].Width = 100; //Fecha Salto
            dg_contactGeneral.Columns[2].Visible = true;
            dg_contactGeneral.Columns[3].Width = 60; //horario
            dg_contactGeneral.Columns[3].Visible = true;
            dg_contactGeneral.Columns[4].Width = 100; //nombre
            dg_contactGeneral.Columns[4].Visible = true;
            dg_contactGeneral.Columns[5].Width = 100; //apellido
            dg_contactGeneral.Columns[5].Visible = true;
            dg_contactGeneral.Columns[6].Width = 50; //personas
            dg_contactGeneral.Columns[6].Visible = true;
            dg_contactGeneral.Columns[7].Width = 170; //email
            dg_contactGeneral.Columns[7].Visible = true;
            dg_contactGeneral.Columns[8].Width = 100; //telefono
            dg_contactGeneral.Columns[8].Visible = true;
            dg_contactGeneral.Columns[9].Width = 100; //telefono 2
            dg_contactGeneral.Columns[9].Visible = true;
            dg_contactGeneral.Columns[10].Width = 100; //celular
            dg_contactGeneral.Columns[10].Visible = true;
            dg_contactGeneral.Columns[11].Width = 100; //No Tarjeta
            dg_contactGeneral.Columns[11].Visible = true;
            dg_contactGeneral.Columns[12].Width = 100; //deposito
            dg_contactGeneral.Columns[12].Visible = false;
            dg_contactGeneral.Columns[13].Width = 60; //metodo**
            dg_contactGeneral.Columns[13].Visible = true;
            dg_contactGeneral.Columns[14].Width = 80; //Precio Organizador
            dg_contactGeneral.Columns[14].Visible = true;
            dg_contactGeneral.Columns[15].Width = 100; // video
            dg_contactGeneral.Columns[15].Visible = false;
            dg_contactGeneral.Columns[16].Width = 100; //realizado
            dg_contactGeneral.Columns[16].Visible = false;
            dg_contactGeneral.Columns[17].Width = 80; //vendedor
            dg_contactGeneral.Columns[17].Visible = true;
            dg_contactGeneral.Columns[18].Width = 300; //observaciones
            dg_contactGeneral.Columns[18].Visible = true;
            dg_contactGeneral.Columns[19].Width = 200; //fecha seguimiento
            dg_contactGeneral.Columns[19].Visible = true;
            dg_contactGeneral.Columns[20].Width = 200; //AFF
            dg_contactGeneral.Columns[20].Visible = false;
            dg_contactGeneral.Columns[21].Width = 100; //videos
            dg_contactGeneral.Columns[21].Visible = false;
            dg_contactGeneral.Columns[22].Width = 200; //referencia
            dg_contactGeneral.Columns[22].Visible = true;
            dg_contactGeneral.Columns[23].Width = 100; //organizador
            dg_contactGeneral.Columns[23].Visible = false;
            dg_contactGeneral.Columns[24].Width = 100; //iddropzone
            dg_contactGeneral.Columns[24].Visible = false;
            dg_contactGeneral.Columns[25].Width = 100; //FechaReservacion
            dg_contactGeneral.Columns[25].Visible = true;
            dg_contactGeneral.Columns[26].Width = 100; //idbudget
            dg_contactGeneral.Columns[26].Visible = true;
            u.Formatodgv(dg_contactGeneral);


            // Ajustamos el combo oficina y logos
            //misglobales.dropzone = Convert.ToInt32( dg_contactGeneral.Columns[24].ToString());


            misglobales.contadordetalle = 0;

            for (int i = 0; i < dg_contacts.RowCount; i++)
            {
                

                    misglobales.contadordetalle = misglobales.contadordetalle + Convert.ToInt32(dg_contacts.Rows[i].Cells[6].Value);
                    if (IntEsCambio == 0)
                    {
                        misglobales.dropzone = Convert.ToInt32(dg_contacts.Rows[i].Cells[24].Value.ToString());
                        cmb_office.SelectedValue = misglobales.dropzone;
                    }
                    logotipos();
                
            }

            lbl_numreserva.Text = misglobales.contador.ToString() + "      Tandems: " + misglobales.contadordetalle;




            InicializaGridviewPlane();

            condicion = "";
            condicion2 = "";
            condicion3 = "";


        }
        #endregion

        #region Inicializa DataGridView de reserva a detalle
        private void inicializagridview()
        {
            condicion = @" WHERE tbr.code = " + misglobales.NumeroReservacion + " order by organizador desc ";
            dg_contactsw.EnableHeadersVisualStyles = false;
            dg_contactsw.DataSource = conexion.ConsultaReserva(condicion);  //getdata(fuente;
            dg_contactsw.Columns[0].Width = 50; //code reserva
            dg_contactsw.Columns[0].Visible = true;
            dg_contactsw.Columns[1].Width = 80; //Jump Date
            dg_contactsw.Columns[1].Visible = true;
            dg_contactsw.Columns[2].Width = 70; //Schedule
            dg_contactsw.Columns[2].Visible = true;
            dg_contactsw.Columns[3].Width = 50; //People Group
            dg_contactsw.Columns[3].Visible = true;
            dg_contactsw.Columns[4].Width = 130; //name
            dg_contactsw.Columns[4].Visible = true;
            dg_contactsw.Columns[5].Width = 130; //lastname
            dg_contactsw.Columns[5].Visible = true;
            dg_contactsw.Columns[6].Width = 150; //email
            dg_contactsw.Columns[6].Visible = true;
            dg_contactsw.Columns[7].Width = 100; //phone
            dg_contactsw.Columns[7].Visible = true;
            dg_contactsw.Columns[8].Width = 100; //phone2
            dg_contactsw.Columns[8].Visible = false;
            dg_contactsw.Columns[9].Width = 100; //movil
            dg_contactsw.Columns[9].Visible = true;
            dg_contactsw.Columns[10].Width = 80; //price
            dg_contactsw.Columns[10].Visible = true;
            dg_contactsw.Columns[11].Width = 80; //Deposit
            dg_contactsw.Columns[11].Visible = true;
            dg_contactsw.Columns[12].Width = 90; //Method
            dg_contactsw.Columns[12].Visible = true;
            dg_contactsw.Columns[13].Width = 90; //Card number 
            dg_contactsw.Columns[13].Visible = true;
            dg_contactsw.Columns[14].Width = 70; //Confirmation
            dg_contactsw.Columns[14].Visible = true;
            dg_contactsw.Columns[15].Width = 100; //Jumped
            dg_contactsw.Columns[15].Visible = true;
            dg_contactsw.Columns[16].Width = 100; //Vendor
            dg_contactsw.Columns[16].Visible = true;
            dg_contactsw.Columns[17].Width = 100; //comments
            dg_contactsw.Columns[17].Visible = true;
            dg_contactsw.Columns[18].Width = 300; //follow date
            dg_contactsw.Columns[18].Visible = true;
            dg_contactsw.Columns[19].Width = 200; //aff
            dg_contactsw.Columns[19].Visible = false;
            dg_contactsw.Columns[20].Width = 200; //video
            dg_contactsw.Columns[20].Visible = false;
            dg_contactsw.Columns[21].Width = 100; //videos
            dg_contactsw.Columns[21].Visible = true;
            dg_contactsw.Columns[22].Width = 200; //reference
            dg_contactsw.Columns[22].Visible = true;
            dg_contactsw.Columns[23].Width = 100; //reservation date
            dg_contactsw.Columns[23].Visible = true;
            dg_contactsw.Columns[24].Width = 100; //id
            dg_contactsw.Columns[24].Visible = true;
            dg_contactsw.Columns[25].Width = 50; //organizador
            dg_contactsw.Columns[25].Visible = true;
            dg_contactsw.Columns[26].Width = 50; //idbudget
            dg_contactsw.Columns[26].Visible = true;
            dg_contactsw.Columns[27].Width = 150; //idbudget
            dg_contactsw.Columns[27].Visible = true;

           

            u.Formatodgv(dg_contactsw);


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
                if (cmb_office.Text == "PUEBLA")
                {
                    txb_metodo.Text = "15Mil";
                }
                else if (cmb_office.Text == "CUAUTLA")
                {
                    txb_metodo.Text = "17Mil";
                }
                else
                {
                    txb_metodo.Text = "13Mil";
                }
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
                //InicializaObjetos();
                inicializagridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try update reservation " + misglobales.NumeroReservacion + " please contact system administrator " + ex.Message);
            }
        }
        #endregion 


        #region Evento click del boton create 
        private void btn_create_Click(object sender, EventArgs e)
        {


            if (btn_create.Text == "Generate Reservation")
            {
                if (txb_deposit.Text == "")
                {
                    txb_deposit.Text = "0";
                }



                if (InserUpdate(condicion) == "insert")
                {
                    //insert
                    DateTime horario = Convert.ToDateTime(dp_schedule.Text);
                    DataSet dscode = new DataSet();
                    tabla = "tb_reserva";
                    condicion = "";
                    sql = "SELECT isnull(MAX(CONVERT(INT,CODE))+1,1) AS CODE FROM dbo.tb_reserva";
                    dscode = conexion.ConsultaUniversal(sql, condicion, tabla);
                    txb_idreserva.Text = dscode.Tables[0].Rows[0].ItemArray[0].ToString();
                    conexion.CloseDB();
                    dp_reserva.Text = Convert.ToString(DateTime.Now);

                    tabla = "tb_reserva";
                    campos = @"code, fecha_reserva, nombre, apellido, email, telefono, telefono2, celular, no_tarjeta, deposito, confirmacion, metodo, fecha_salto, 
                           horario,   vendedor, observaciones, fecha_seguimiento, personas, organizador, precio, realizado, referencia, iddropzone, idusuario, idbudget";
                    valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + dp_reserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                               txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ",0 , '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "', '" +
                               txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103), " + txb_personas.Text + ", 0, " + txb_price.Text + ", 0, '" + txb_name.Text + " " + txb_lastname.Text + "',  " + iddropzone + ", " + misglobales.usuario_idusuario + ", " + cmb_budget.SelectedValue.ToString();

                    Int32 Npersonas = Convert.ToInt32(txb_personas.Text);




                    try
                    {
                        for (int j = 0; j < Npersonas; j++)
                        {
                            if (j == 0)
                            {
                                valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + dp_reserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                                        txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ",0, '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), convert(varchar(8),'" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',114) , '" +
                                        txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103), " + txb_personas.Text + ", 1, " + txb_priceorg.Text + ",0, '" + txb_name.Text + " " + txb_lastname.Text + "',  " + iddropzone + ", " + misglobales.usuario_idusuario + ", " + cmb_budget.SelectedValue.ToString();
                            }
                            else
                            {
                                valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + dp_reserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                                        txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ",0, '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), convert(varchar(8), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',14), '" +
                                        txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103), " + txb_personas.Text + ", 0, " + txb_price.Text + ",0, '" + txb_name.Text + " " + txb_lastname.Text + "',  " + iddropzone + ", " + misglobales.usuario_idusuario + ", " + cmb_budget.SelectedValue.ToString();
                            }
                            conexion.InsertTabla(campos, tabla, valores);
                        }
                        MessageBox.Show("Reservation: " + txb_idreserva.Text + " for " + txb_name.Text + " " + txb_lastname.Text + "  generated successfully ");
                        conexion.RegistroLog(misglobales.usuario_idusuario, "Reserva", "Nueva reservacion" + txb_idreserva + " a nombre de " + txb_name.Text + " " + txb_lastname.Text);

                        InicializaObjetos();
                        inicializagridviewHome();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error try save new reservation" + ex.Message);
                    }

                }
                else
                {
                    //Update
                    DateTime horario = Convert.ToDateTime(dp_schedule.Text);
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
                             @" horario = '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "', " +
                             @" vendedor = '" + txb_vendor.Text + "', " +
                             @" observaciones = '" + txb_note.Text + "', " +
                             @" fecha_seguimiento = convert(varchar(10),'" + dp_follow.Value + "',103), " +
                             @" personas = " + txb_personas.Text + "," +
                             @" iddropzone = " + iddropzone + ", " +
                             @" precio = " + txb_price.Text + ", " +
                             @" precio = " + misglobales.usuario_idusuario + ", " +
                             @" idbudget = " + cmb_budget.SelectedValue.ToString();
                    condicion = " where code = '" + txb_idreserva.Text + "' and id = " + lbl_id.Text;
                    try
                    {
                        conexion.RegistroLog(misglobales.usuario_idusuario, "Reserva", "Modificación a la reservacion: " + txb_idreserva + " a nombre de " + txb_name.Text + " " + txb_lastname.Text + " a la zona de salto: " + iddropzone);
                        conexion.UpdateTabla(campos, tabla, condicion);
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
                        if (cmb_office.Text == "PUEBLA")
                        {
                            txb_metodo.Text = "15Mil";
                        }
                        else if (cmb_office.Text == "CUAUTLA")
                        {
                            txb_metodo.Text = "17Mil";
                        }
                        else
                        {
                            txb_metodo.Text = "13Mil";
                        }
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
                        inicializagridview();

                    }
                    catch (Exception
                         ex)
                    {

                        MessageBox.Show("Error try save or update this Reservation, please verify the information for each field is correct " + ex.Message);
                    }
                }
            }
            if (btn_create.Text == "Save")
            {

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

                    DateTime horario = Convert.ToDateTime(dp_schedule.Text);

                    tabla = "tb_reserva";
                    campos = @"code, fecha_reserva, nombre, apellido, email, telefono, telefono2, celular, no_tarjeta, deposito, metodo, fecha_salto, 
                           horario,  vendedor, observaciones, fecha_seguimiento, precio, confirmacion, idbudget ";
                    valores = @"'" + txb_idreserva.Text + "', convert(varchar(10),'" + txb_datereserva.Text + "',103), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_email.Text + "', '" + txb_homephone.Text + "', '" + txb_workphone.Text + "', '" +
                               txb_mobile.Text + "', '" + txb_card.Text + "', " + txb_deposit.Text + ", '" + txb_metodo.Text + "', convert(varchar(10),'" + dp_jumpdate.Value + "',103), '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "', '" +
                               txb_vendor.Text + "', '" + txb_note.Text + "', convert(varchar(10),'" + dp_follow.Value + "',103) , " + txb_price.Text + ", " + Convert.ToByte(chk_confirm.Checked) + ", " + cmb_budget.SelectedValue.ToString();
                               ;

                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                        MessageBox.Show("Save Successfully");
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
                        if (cmb_office.Text == "PUEBLA")
                        {
                            txb_metodo.Text = "15Mil";
                        }
                        else if (cmb_office.Text == "CUAUTLA")
                        {
                            txb_metodo.Text = "17Mil";
                        }
                        else
                        {
                            txb_metodo.Text = "13Mil";
                        }
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
                        lbl_organizador.Visible = false;
                        dp_jumpdate.Text = DateTime.Now.ToShortDateString();
                        inicializagridview();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error try save new reservation" + ex.Message);
                    }

                }
                else
                {

                    ZonaNueva = cmb_dropzone.Text;


                    //if (iddropzone != Convert.ToInt32(cmb_office.SelectedValue.ToString()) )
                    if (ZonaAnterior != ZonaNueva)
                    {
                    
                    DialogResult resultado = MessageBox.Show("Are you sure change DROPZONE !!!!?", "Warning", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        cmb_office.Text = ZonaAnterior;
                        
                        return;
                    }

                    }

                    //Update
                    DateTime horario = Convert.ToDateTime(dp_schedule.Text);
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
                             @" horario = '" + horario.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "', " +
                             @" vendedor = '" + txb_vendor.Text + "', " +
                             @" observaciones = '" + txb_note.Text + "', " +
                             @" fecha_seguimiento = convert(varchar(10),'" + dp_follow.Value + "',103), " +
                             @" confirmacion = convert(bit, " + Convert.ToInt32(chk_confirmacion.Checked) + "), " +
                             @" iddropzone = " + iddropzone + ", " +
                             //@" precio = " + Convert.ToInt32(txb_priceorg.Text.ToString()) + "";
                             @" precio = " + txb_priceorg.Text.ToString() + ", " +
                             @" idbudget = " + cmb_budget.SelectedValue.ToString();
                    condicion = " where code = '" + txb_idreserva.Text + "' and id = " + lbl_id.Text;
                    try
                    {
                        conexion.RegistroLog(misglobales.usuario_idusuario, "Reserva", "Modificación a la reservacion: " + txb_idreserva.Text + " a nombre de: " + txb_name.Text + " " + txb_lastname.Text + " de la zona: " + ZonaAnterior + " a la zona de salto: " + ZonaNueva);
                        conexion.UpdateTabla(campos, tabla, condicion);
                        tabla = "tb_reserva";
                        campos = " iddropzone = " + iddropzone + " ";
                        condicion = " where code = '" + txb_idreserva.Text + "'";
                        conexion.UpdateTabla(campos, tabla, condicion);

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
                        if (cmb_office.Text == "PUEBLA")
                        {
                            txb_metodo.Text = "15Mil";
                        }
                        else if (cmb_office.Text == "CUAUTLA")
                        {
                            txb_metodo.Text = "17Mil";
                        }
                        else
                        {
                            txb_metodo.Text = "13Mil";
                        }
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
                        lbl_organizador.Visible = false;
                        dp_jumpdate.Text = DateTime.Now.ToShortDateString();
                        inicializagridview();
                    }
                    catch (Exception
                         ex)
                    {

                        MessageBox.Show("Error try save or update this Reservation, please verify the information for each field is correct " + ex.Message);
                    }
                }
            }

            ActualizaContadorReservacion();

        }
        #endregion

        #region Boton Filter Click
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
                condicion2 = @" and ( tbr.nombre + ' ' + tbr.apellido like '%" + txb_filtro_nombre.Text + "%') ";
            }
            //if (txb_name.Text == "" & txb_lastname.Text == "")
            //{
            //    condicion2 = "";
            //    FiltradoPorNombre = 0;
            //}
            //else
            //{
            //    FiltradoPorNombre = 1;
            //    condicion2 = @" and ( nombre + ' ' + apellido like '%" + txb_name.Text + "%" + txb_lastname.Text + "%') ";
            //}
            inicializagridviewHome();
        }
        #endregion

        private void dp_gridinfo_ValueChanged(object sender, EventArgs e)
        {
            inicializagridviewHome();
        }

        private void dp_gridinfo_fin_ValueChanged(object sender, EventArgs e)
        {
            inicializagridviewHome();
        }

        private void chk_lista_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_lista.Checked)
            { dg_contacts.Visible = true; }
            else
            { dg_contacts.Visible = false; }
        }


        //public class Item
        //{
        //    public string Name { get; set; }
        //    public int Value { get; set; }
        //    public Item(string name, int value)
        //    {
        //        Name = name;
        //        Value = value;
        //    }
        //    public override string ToString()
        //    {
        //        return Name;
        //    }
        //}


        #region Evento selectedIndexChanged del cmb_office
        private void cmb_office_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            //cmb_office.SelectedValue = misglobales.dropzone;

            switch (cmb_office.SelectedValue.ToString())
            { 
                case "0":
                    gp_header.BackColor = Color.White;
                    break;
                case "1":
                    gp_header.BackColor = Color.DarkOrange;
                    break;
                case "2":
                    gp_header.BackColor = Color.CadetBlue;
                    break;
                case "3":
                    gp_header.BackColor = Color.MediumVioletRed;
                    break;
                case "4":
                    gp_header.BackColor = Color.Fuchsia;
                    break;
            }
            
        }
        #endregion

        #region logotipos
        public void logotipos()
        {
            lbl_titulo_home.Text = cmb_office.Text;
            if (misglobales.dropzone == 2)
            {
                
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
                
            }
            else if (misglobales.dropzone == 4)
            {
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
            }
            else if (misglobales.dropzone == 3)
            {
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
            }
            else
            {
                logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");
                logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");
                logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");

               
            }
        }
        #endregion

        #region Cambio realizdo en el combo cmb_office
        private void cmb_office_SelectionChangeCommitted(object sender, EventArgs e)
        {
            iddropzone = Convert.ToInt32(cmb_office.SelectedValue.ToString());
            misglobales.dropzone = Convert.ToInt32(cmb_office.SelectedValue.ToString());

            IntEsCambio = 1;
            logotipos();

            //lbl_titulo_home.Text = cmb_office.Text;
            //if (misglobales.dropzone == 2)
            //{
                
            //    logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
            //    logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
            //    logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_cuautla.jpg");
                
            //}
            //else if (misglobales.dropzone == 4)
            //{
            //    logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
            //    logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
            //    logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puebla.jpg");
            //}
            //else if (misglobales.dropzone == 3)
            //{
            //    logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
            //    logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
            //    logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\logo_puertoescondido.jpg");
            //}
            //else
            //{
            //    logo_home.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");
            //    logo_reserve.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");
            //    logo_calendar.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\parachute.jpg");

               
            //}
            if (cmb_office.Text == "PUEBLA")
            {
                txb_metodo.Text = "15Mil";
            }
            else if (cmb_office.Text == "CUAUTLA")
            {
                txb_metodo.Text = "17Mil";
            }
            else
            {
                txb_metodo.Text = "13Mil";
            }
            inicializagridviewHome();
            IntEsCambio = 0;

        }
        #endregion

        #region dobleclick en la celda del grid  dg_contactgeneral
        private void dg_contactGeneral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            misglobales.NumeroReservacion = Convert.ToInt32(dg_contactGeneral.Rows[dg_contactGeneral.CurrentRow.Index].Cells[1].Value.ToString());
            chk_confirm.Visible = true;
            gpb_detail.Visible = true;
            gpb_general.Visible = false;
            gp_persons.Visible = false;
            btn_closegroup.Visible = true;
            btn_create.Text = "Save";
            btn_create.Visible = true;
            chk_confirmacion.Visible = true;
            gp_palitos.Visible = true;
            lbl_reservations.Text = "Reservations Detail";
            inicializagridview();
        }
        #endregion


        #region evento doble click en la celda del grid dg_contacts
        private void dg_contacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            misglobales.NumeroReservacion = Convert.ToInt32(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[1].Value.ToString());
            chk_confirm.Visible = true;
            gpb_detail.Visible = true;
            gpb_general.Visible = false;
            gp_persons.Visible = false;
            btn_closegroup.Visible = true;
            btn_create.Text = "Save";
            btn_create.Visible = true;
            chk_confirmacion.Visible = true;
            gp_palitos.Visible = true;
            lbl_reservations.Text = "Reservations Detail";
            inicializagridview();
            tbc_reserve.SelectedIndex = 1;

        }
        #endregion


        #region evento click en el boton btn_closegroup
        private void btn_closegroup_Click(object sender, EventArgs e)
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
            if (cmb_office.Text == "PUEBLA")
            {
                txb_metodo.Text = "15Mil";
            }
            else if (cmb_office.Text == "CUAUTLA")
            {
                txb_metodo.Text = "17Mil";
            }
            else
            {
                txb_metodo.Text = "13Mil";
            }
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
            chk_confirm.Visible = false;

            gpb_detail.Visible = false;
            gpb_general.Visible = true;
            gp_persons.Visible = true;
            btn_closegroup.Visible = false;
            chk_confirmacion.Visible = false;
            
            chk_confirmacion.Checked = false;
            btn_create.Text = "Generate Reservation";
            btn_create.Visible = true;
            lbl_reservations.Text = "General Reservations";
            gp_palitos.Visible = false;
            ZonaNueva = "";
            ZonaAnterior = "";

            inicializagridview();
        }
#endregion


        #region Evento Checked changed del check box confirmacion
        private void chk_confirm_CheckedChanged(object sender, EventArgs e)
        {
            Int16 bConfirm = 0;

            if (chk_confirm.Checked == true)
            {
                //Para la reservacion seleccoinada en base de datos realizará un update a este campo reserve = 1
                bConfirm = 1;
                //Se refrescará el grid de detalle
            }
            else 
            {
                //Para la reservacion seleccoinada en base de datos realizará un update a este campo reserve = 0
                bConfirm = 0;
                //Se refrescará el grid de detalle
                
            }

            tabla = "tb_reserva";
            campos = @" confirmacion = convert(bit, " + bConfirm + ")";
            condicion = " where code = '" + misglobales.NumeroReservacion + "'  ";
            try
            {
                conexion.UpdateTabla(campos, tabla, condicion);
                inicializagridview();
            }
            catch (Exception
                 ex)
            {

                MessageBox.Show("Error try save or update this Reservation, please verify the information for each field is correct " + ex.Message);
            }


        }
        #endregion 


        #region Evento doble click en la celda del grid dg_cntacsw
        private void dg_contactsw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ZonaAnterior = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[27].Value);


                if ( Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[25].Value) == "True")
                { 
                    lbl_organizador.Visible = true;
                    lbl_organizador.Text = "ORGANIZADOR";
                    lbl_organizador.ForeColor = Color.Red;
                }
                else
                {
                    lbl_organizador.Visible = true;
                    lbl_organizador.Text = "MIEMBRO";
                    lbl_organizador.ForeColor = Color.Black;
                }
                txb_idreserva.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[0].Value);
                txb_datereserva.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[23].Value);

                txb_name.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[4].Value);
                txb_lastname.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[5].Value);
                txb_email.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[6].Value);
                txb_homephone.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[7].Value);
                txb_workphone.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[8].Value);
                txb_mobile.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[9].Value);
                txb_card.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[13].Value);
                txb_deposit.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[11].Value);

                txb_metodo.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[12].Value);
                dp_jumpdate.Value = Convert.ToDateTime(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[1].Value);
                if (dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[2].Value.ToString() != "")
                {
                    dp_horario2.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[2].Value);
                    dp_horario1.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[2].Value);
                    dp_schedule.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[2].Value);
                }
               
                if (dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[14].Value.ToString() != "")
                {
                    //chk_confirm.Checked = Convert.ToBoolean(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[14].Value);
                    //chk_confirm.Checked = chk_confirmacion.Checked;
                    chk_confirmacion.Checked = Convert.ToBoolean(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[14].Value);
                }

                txb_vendor.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[16].Value);
                txb_note.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[17].Value);
                if (dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[18].Value.ToString().Length > 0)
                {
                    dp_follow.Value = Convert.ToDateTime(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[18].Value);
                }
                txb_price.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[10].Value);
                txb_priceorg.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[10].Value);
                lbl_id.Text = Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[24].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to load informacion " + ex.Message);
            }
        }
        #endregion


        #region Metodo Borra registro
        private void BorraRegistro()
        {
            tabla = "tb_reserva";
            condicion = "  code = '" + Convert.ToString(dg_contacts.Rows[dg_contacts.CurrentRow.Index].Cells[1].Value) + "'";
            conexion.BorraRegistro(condicion, tabla);
            
        }
        #endregion 


        #region evento borrando renglon del grid dg_dg_contacts
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
        private void BorraRegistro2()
        {
            tabla = "tb_reserva";
            condicion = "  code = '" + Convert.ToString(dg_contactGeneral.Rows[dg_contactGeneral.CurrentRow.Index].Cells[1].Value) + "'";
            conexion.BorraRegistro(condicion, tabla);

        }
        #endregion 


        #region Evento borrando renglon del grid dg_contactGeneral
        private void dg_contactGeneral_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                BorraRegistro2();
            }
        }
        #endregion




        #region Metodo Borra registro
        private void BorraRegistro3()
        {
            tabla = "tb_reserva";
            condicion = "  code = '" + Convert.ToString(dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[0].Value) + "' and id = " + dg_contactsw.Rows[dg_contactsw.CurrentRow.Index].Cells[24].Value;
            conexion.BorraRegistro(condicion, tabla);
           

        }
        #endregion 


        #region Evento borrando renglon en el grid dg_contactsw
        private void dg_contactsw_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                BorraRegistro3();
            }
        }
        #endregion 


        #region Evento renglon borrado del grid dg_contacts
        private void dg_contacts_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            inicializagridviewHome();
        }
        #endregion 

        #region Evento Renglon borrado del grid dg_contactgeneral
        private void dg_contactGeneral_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            inicializagridviewHome();
        }
        #endregion 


        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }


        #region Evento CellendEdit del dg_calendar
        private void dg_calendar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btn_savecalendar.Visible = true;
        }
        #endregion


        #region Evento click del boton btn_savecalendar
        private void btn_savecalendar_Click(object sender, EventArgs e)
        {
            tabla = "CT_CALENDAR";
            condicion = "iddropzone = " + iddropzone.ToString();
            conexion.BorraRegistro(condicion, tabla);


            for (int i = 0; i < dg_calendar.RowCount; i++)
            {


                     tabla = "CT_CALENDAR";
                     campos = "horario, capacidad_lunes, capacidad_martes, capacidad_miercoles, capacidad_jueves, capacidad_viernes, capacidad_sabado, capacidad_domingo, iddropzone, updatedate, idusuario";
                     valores = "'" + dg_calendar.Rows[i].Cells[1].Value + "', 0, 0,  " + dg_calendar.Rows[i].Cells[4].Value + ", " + dg_calendar.Rows[i].Cells[5].Value + ", " + dg_calendar.Rows[i].Cells[6].Value + ", " + dg_calendar.Rows[i].Cells[7].Value + ", " + dg_calendar.Rows[i].Cells[8].Value + ", " + iddropzone.ToString()  + " , getdate(), "+ misglobales.usuario_idusuario.ToString();
                    conexion.InsertTabla(campos, tabla, valores);
              
            }

            btn_savecalendar.Visible = false;
        }
        #endregion


        #region Evento enter del grupbox1
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #endregion


        #region User Deleted row del grid dg_contactsw
        private void dg_contactsw_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ActualizaContadorReservacion();
        }
        #endregion

        private void label17_Click(object sender, EventArgs e)
        {

        }

        #region Evento checked modificado del chk_notconfirm
        private void chk_notconfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_notconfirm.Checked)
            {
                 notconfirm = 1;
                 grp_emailing.Visible = true;
            }
            else
            { 
                notconfirm = 0;
                grp_emailing.Visible = false;
            }
            inicializagridviewHome();
        }
        #endregion

        #region Metodo para enviar eMail con las instruccions para proceder 
        private bool emailinstructions(string eMailTo, string eMailFrom, string nameFrom)
        {
            string colorfondo = "";
                    if ( cmb_office.Text == "CUAUTLA")
                    {
                        colorfondo = "#0099da";
                    }
                    else if ( cmb_office.Text == "PUEBLA")
                    {
                        colorfondo = "#e73c3c";
                    }
                    else if (cmb_office.Text == "PUERTO ESCONDIDO")
                    {
                        colorfondo = "#16ac8d";
                    }
                    else 
                    {
                        colorfondo = "#16ac8d";
                    }
                    //string correovisible = eMailTo;
                    pb_sync.Visible = true;
                    eMailTo = "ccruz@wht.mx";
                    MailMessage msg = new MailMessage();
                    msg.To.Add(eMailTo); //"Email a quien se le envia "
                    msg.From = new MailAddress(eMailFrom, misglobales.usuario_nombre + " " + misglobales.usuario_paterno, System.Text.Encoding.UTF8);
                    MailAddress cc = new MailAddress(misglobales.usuario_email);
                   // msg.CC.Add(cc);
                    msg.Subject = "SKYDIVE " + cmb_office.Text + " RESERVACIÓN";
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body = @"
 <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
        <html xmlns=""http://www.w3.org/1999/xhtml"">

        <head>
          <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
          <title>SKYDIVE " + cmb_office.Text + @" RESERVACION</title>
          <style type=""text/css"">
          body {margin: 0; padding: 0; min-width: 100%!important;}
          img {height: auto;}
          .content {width: 100%; max-width: 600px;}
          .header {padding: 40px 30px 20px 30px;}
          .innerpadding {padding: 30px 30px 30px 30px;}
          .borderbottom {border-bottom: 1px solid #f2eeed;}
          .subhead {font-size: 35px; color: #ffffff; font-family: Helvetica,Arial,sans-serif; letter-spacing: 1px;}
          .h1, .h2, .bodycopy {color: #153643; font-family: sans-serif;}
          .h1 {font-size: 33px; line-height: 38px; font-weight: bold;}
          .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;}
          .bodycopy {font-size: 16px; line-height: 22px;}
          .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;}
          .button a {color: #ffffff; text-decoration: none;}
          .footer {padding: 20px 30px 15px 30px;}
          .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;}
          .footercopy a {color: #ffffff; text-decoration: underline;}

          @media only screen and (max-width: 550px), screen and (max-device-width: 550px) {
          body[yahoo] .hide {display: none!important;}
          body[yahoo] .buttonwrapper {background-color: transparent!important;}
          body[yahoo] .button {padding: 0px!important;}
          body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;}
          body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;}
          }

          /*@media only screen and (min-device-width: 601px) {
            .content {width: 600px !important;}
            .col425 {width: 425px!important;}
            .col380 {width: 380px!important;}
            }*/

          </style>
        </head>

        <body yahoo bgcolor=""#f6f8f1"">
        <table width=""100%"" bgcolor=""#f6f8f1"" border=""0"" cellpadding=""0"" cellspacing=""0"">
        <tr>
          <td>
            <!--[if (gte mso 9)|(IE)]>
              <table width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                <tr>
                  <td>
            <![endif]-->     
            <table bgcolor=""#ffffff"" class=""content"" align=""center"" cellpadding=""0"" cellspacing=""0"" border=""0"">
              <tr>
                <td bgcolor=""" + colorfondo + @""" class=""header"">
                  <table width=""70"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"">  
                    <tr>
                      <td height=""70"" style=""padding: 0 20px 20px 0;"">
                        <!--<img class=""fix"" src=""images/icon.gif"" width=""70"" height=""70"" border=""0"" alt="" />-->
                      </td>
                    </tr>
                  </table>
                  <!--[if (gte mso 9)|(IE)]>
                    <table width=""425"" align=""left"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                      <tr>
                        <td>
                  <![endif]-->
                  <table class=""col425"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width: 100%; max-width: 425px;"">  
                    <tr>
                      <td height=""70"">
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                          <tr>
                            <td class=""subhead"" style=""padding: 0 0 0 3px;"">
                              Skydive " + cmb_office.Text + @"
                            </td>
                          </tr>
                          <tr>
                            <td class=""subhead"" style=""padding: 5px 0 0 0;"">
                              Información para tu Reservación
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                  <!--[if (gte mso 9)|(IE)]>
                        </td>
                      </tr>
                  </table>
                  <![endif]-->
                </td>
              </tr>
              <tr>
                <td class=""innerpadding borderbottom"">
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                    <tr>
                      <td class=""h2"">
        Hola! " + nameFrom + @"
        <br><br>
                        
                      </td>
                    </tr>
                    <tr>
                      <td class=""bodycopy"">
                        Gracias por ser parte de nuestro Club, para que tu registro quede asegurado, solicitamos un anticipo de $ 500.00 por persona; en caso de registrar un grupo no importa si es en una sola exhibición, únicamente envíanos los nombres completos de los integrantes.
                        <br><br>
                        Una vez recibido el importe del deposito queda completamente asegurada tu afiliación y por lo tanto tu reservación.
				        <br><br><br>
                        Los datos de la reservación son los siguientes: 
                        <br><br>
                        Te agradeceremos nos des los nombres completos de las personas que van a saltar así como sus correos electrónicos y especificaciones en cuanto al peso. (si es que existen)
                        <br><br>
                        Nombre:_____________________________ <br>
                        Fecha: _____________________________ <br>
                        Horario: ___________________________ <br>
                        No. Personas: ______________________ <br>
                        Teléfono fijo: _____________________ <br>
                        Celular: ___________________________ <br>
                        Servicios :  TANDEM " + cmb_office.Text + @"<br>
                        Nota: Copia el cuadro de arriba y pégalo en el correo que envíes con tu ficha escaneada. <br>
                        Indispensable presentar original y copia de identificación oficial el día del salto.<br><br><br><br>
                        Favor de realizar tu deposito:<br>
                        Grupos de menos de 5 personas: al menos con 1 semana de anticipación<br>
                        Grupos de más de 5 personas: al menos con 2 semanas de anticipación<br><br><br>
                        Nota. Evita la cancelación de tu reservación depositando lo antes posible. Si llegaras a tener cambios en tu reservación (horario, fecha o número de personas), llama a nuestra oficina para revisar disponibilidad.
                        <br><br><br>
                        Te recordamos que tienes 2 formas de realizar el pago.<br><br>
                        Deposito en efectivo o transferencias Bancomer:<br>
                        Num. 0192373750 en BBVA Bancomer a nombre de Centro Deportivo de Paracaidismo Cuautla AC<br>
                        Después de realizar el depósito deberás enviar la imagen (escáner o foto) lo más legible posible y mandarla a:<br>
                        " + eMailFrom + @"<br><br>
                        Transferencia Bancaria si tu Banco no es Bancomer<br>
                        Num.012180001923737503 en BBVA Bancomer a nombre de Centro Deportivo de Paracaidismo Cuautla AC<br>
                        En el Campo de referencia favor de poner tu nombre y nuestro correo en la casilla del correo de terceros.<br>
                        Después de realizar la transferencia te pedimos envíes la confirmación a:<br>
                        " + eMailFrom + @"<br><br>
                        En cuanto tu correo sea recibido y revisado te enviaremos la confirmación con tu numero de reservación (24 horas para depósito, 48 horas para transferencia), además del mapa para llegar a nuestras instalaciones.<br><br>
                        Para la liquidación del salto (en la zona de salto), aceptamos:<br>
                        Efectivo<br>
                        Tarjetas de crédito y debito (con un cargo de 5% adicional; Visa, Visa Electron, Master Card y American Express).<br><br>
                        Los depósitos no son reembolsables, podemos hacer modificaciones en cuanto a la fecha y horario siempre y cuando sea con una anticipación minima de 48 horas. En el único caso que podemos reembolsar los depósitos es debido a una cancelación por nuestra parte.<br><br>
                        Recuerda que si alguno de tus acompañantes se anima a saltar sin tener reservacion, pagara el precio normal, actualmente es de $2,400.00 a 13 mil pies snm y de $2,800.00 a 17 mil pies snm. El precio de reservacion solo aplica con la ficha de deposito.<br><br>
                        HORARIOS:<br>
                        A partir de las 8:00 a.m. hasta las 18:00 hrs cada hora nuestras reservaciones según disponibilida<br><br><br>
                        PESO MAXIMO 90 KILOS<br>
                        SKYDIVECUAUTLA Y SKYDIVEPUEBLA tiene la capacidad de hacer un salto a 13 mil pies de altura como en cualquier otra zona de salto pero, ninguna otra zona de salto tiene la capacidad de hacer un salto a 17 mil pies de altura como nosotros!!!!! NUESTRO UNICO SALTO PREMIUM<br><br>
                        SOLAMENTE TENEMOS 2 ZONAS DE SALTO<br>
                        CUAUTLA Y PUEBLA<br>
                        NO TENEMOS MAS SUCURSALES<br><br>
                        Como llegar:<br>
                        Desde la salida de la caseta de la autopista a Cuernavaca sigue el siguiente enlace: http://goo.gl/maps/sqsjV <br><br>
                        Desde Puebla toma la autopista a Atlixco sigue el siguiente enlace: http://goo.gl/maps/qMC5r <br><br>
                        Nota: También puedes ver el mapa desde nuestra página www.skydivecuautla.com, haz click en cómo llegar?<br><br><br>
                        Condiciones:<br>
                            1.- Confirmar tu reservación al menos 3 días antes de la fecha de tu salto con anticipo de $400.00 pesos por persona mediante deposito bancario (llama a reservaciones para obtener la información)<br>
                            2.- 5% de comisión si realizas tu pago con tarjeta de crédito o debito (VISA, MASTERCARD. AMEX, VISA ELECTRON)<br>
                            3.- Si alguno de tus acompañantes decide saltar sin tener reservación, pagara el precio normal (2,800 pesos a 17,000 pies, $2,400.00 A 13 mil pies), el precio de promoción solo aplica al entregar tu ficha de deposito<br>
                            4.- Durante la caída libre por tu seguridad se prohíbe llevar cualquier objeto en tus manos, solamente el instructor podrá hacerlo.<br>
                            5.- Peso Máximo 90 kg<br>
                            6.- Problemas de cuello o espalda.<br>
                            7.- Problemas cardiacos<br>
                            8.- hipertensión<br>
                            9.- Gripa<br>
                           10.- Fracturas recientes.<br>
                           11.- No ingerir bebidas alcohólicas antes del salto.<br>
                           12.- No se permiten alimentos ajenos al lugar<br><br><br>
                        Duración:<br>
                        La duración aproximada de la actividad es de 2 a 3 horas desde tu llegada al club, mismas que pudieran prolongarse debido a que se trata de una actividad al aire libre y de uso de espacio aéreo, por lo que está sujeta a las restricciones climatológicas y de espacio aéreo controlado, se sugiere disponer de hasta 6 horas de estadía en el club. 
                        <br><br><br>
                        Bienvenido a esta nueva experiencia
                        <br><br><br>
                        Feel the Rush!
                        <br><br><br><br><br><br>
                        " + misglobales.usuario_nombre + @" " + misglobales.usuario_paterno + @"<br> " + eMailFrom + @"<br>
                        (52)55.5517.8529 ext 101 ó 102
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td class=""footer"" bgcolor=""#44525f"">
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                    <tr>
                      <td align=""center"" class=""footercopy"">
                        &reg; 
        Copyright © 2016 Skydive " + cmb_office.Text + @". Todos los derechos reservados.<br>
        La Informacion mostrada en este mensaje es para uso interno y confidencial de la empresa, se recomienda discreción.
        <br/><br>
        CENTRO DEPORTIVO DE PARACAIDISMO CUAUTLA, A.C., (SKYDIVE CUAUTLA), reconoce, respeta y es responsable de la protección de sus datos personales. Le informamos que sus datos personales se utilizarán para dar seguimiento a su solicitud planteada con relación a nuestros servicios de paracaidismo. Para mayor información acerca del tratamiento de sus datos personales y de los derechos que puede hacer valer, usted puede consultar nuestro aviso de privacidad integral en el sitio http://www.skydivecuautla.com/aviso_privacidad.html <br>
        AVISO IMPORTANTE: Este correo electrónico y/o material adjunto es/son para uso exclusivo de la persona o la entidad a la que expresamente se le ha enviado, y puede contener información confidencial o material privilegiado. Si usted no es el destinatario legítimo del mismo, por favor repórtelo inmediatamente al originador del correo y bórrelo. Cualquier revisión, retransmisión, difusión o cualquier otro uso de este correo, por personas o entidades distintas a las del destinatario legítimo, queda expresamente prohibido. Este correo electrónico no pretende ni debe ser considerado como constitutivo de ninguna relación legal, contractual o de otra índole similar.<br><br>
                        <a href=""#"" class=""unsubscribe""><font color=""#ffffff"">Darse de baja</font></a> 
                        <span class=""hide"">de esta notificación</span><br/><br>
                      </td>
                    </tr>
                    <tr>
                      <td align=""center"" style=""padding: 20px 0 0 0;"">
                        <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                          <tr>
                            <td width=""37"" style=""text-align: center; padding: 0 10px 0 10px;"">
                              <a href=""http://www.facebook.com/skydivecuautla"">
                                <img src=""images/facebook.png"" width=""37"" height=""37"" alt=""Facebook"" border=""0"" />
                              </a>
                            </td>
                            <td width=""37"" style=""text-align: center; padding: 0 10px 0 10px;"">
                              <a href=""http://www.twitter.com/skydivecuautla"">
                                <img src=""images/twitter.png"" width=""37"" height=""37"" alt=""Twitter"" border=""0"" />
                              </a>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
            <!--[if (gte mso 9)|(IE)]>
                  </td>
                </tr>
            </table>
            <![endif]-->
            </td>
          </tr>
        </table>

        <!--analytics-->
        <script src=""http://code.jquery.com/jquery-1.10.1.min.js""></script>
        <script src=""http://tutsplus.github.io/github-analytics/ga-tracking.min.js""></script>
        </body>
        </html>";
                    msg.IsBodyHtml = true; //Si vas a enviar un correo con contenido html entonces cambia el valor a true
                    //Aquí es donde se hace lo especial
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("reserva.standby@skydivecuautla.com", "#67yhju%");
                    client.Port = 587;
                    client.Host = "mail.skydivecuautla.com";//Este es el smtp valido para Gmail
                    //Esto es para que vaya a través de SSL que es obligatorio con GMail
                    try
                    {
                        client.Send(msg);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
        }
        #endregion

        #region metodo Enviar eMail de presion o recordatorio REMINDERS
        private bool EnviarEmail(string eMailTo, string eMailFrom, string nameFrom) 
                {
                    string colorfondo = "";
                    if ( cmb_office.Text == "CUAUTLA")
                    {
                        colorfondo = "#0099da";
                    }
                    else if ( cmb_office.Text == "PUEBLA")
                    {
                        colorfondo = "#e73c3c";
                    }
                    else if (cmb_office.Text == "PUERTO ESCONDIDO")
                    {
                        colorfondo = "#16ac8d";
                    }
                    else 
                    {
                        colorfondo = "#16ac8d";
                    }
                    //string correovisible = eMailTo;
                    pb_sync.Visible = true;
                    //eMailTo = "ccruz@wht.mx";
                    MailMessage msg = new MailMessage();
                    msg.To.Add(eMailTo); //"Email a quien se le envia "
                    msg.From = new MailAddress(eMailFrom, misglobales.usuario_nombre + " " + misglobales.usuario_paterno, System.Text.Encoding.UTF8);
                    MailAddress cc = new MailAddress(misglobales.usuario_email);
                    msg.CC.Add(cc);
                    msg.Subject = "Reservación pendiente";
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body = @"
        <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
        <html xmlns=""http://www.w3.org/1999/xhtml"">
 
        <head>
          <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
          <title>Reservation Email</title>
          <style type=""text/css"">
          body {margin: 0; padding: 0; min-width: 100%!important;}
          img {height: auto;}
          .content {width: 100%; max-width: 600px;}
          .header {padding: 40px 30px 20px 30px;}
          .innerpadding {padding: 30px 30px 30px 30px;}
          .borderbottom {border-bottom: 1px solid #f2eeed;}
          .subhead {font-size: 35px; color: #ffffff; font-family: Helvetica,Arial,sans-serif; letter-spacing: 1px;}
          .h1, .h2, .bodycopy {color: #153643; font-family: sans-serif;}
          .h1 {font-size: 33px; line-height: 38px; font-weight: bold;}
          .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;}
          .bodycopy {font-size: 16px; line-height: 22px;}
          .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;}
          .button a {color: #ffffff; text-decoration: none;}
          .footer {padding: 20px 30px 15px 30px;}
          .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;}
          .footercopy a {color: #ffffff; text-decoration: underline;}

          @media only screen and (max-width: 550px), screen and (max-device-width: 550px) {
          body[yahoo] .hide {display: none!important;}
          body[yahoo] .buttonwrapper {background-color: transparent!important;}
          body[yahoo] .button {padding: 0px!important;}
          body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;}
          body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;}
          }

          /*@media only screen and (min-device-width: 601px) {
            .content {width: 600px !important;}
            .col425 {width: 425px!important;}
            .col380 {width: 380px!important;}
            }*/

          </style>
        </head>

        <body yahoo bgcolor=""#f6f8f1"">
        <table width=""100%"" bgcolor=""#f6f8f1"" border=""0"" cellpadding=""0"" cellspacing=""0"">
        <tr>
          <td>
            <!--[if (gte mso 9)|(IE)]>
              <table width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                <tr>
                  <td>
            <![endif]-->     
            <table bgcolor=""#ffffff"" class=""content"" align=""center"" cellpadding=""0"" cellspacing=""0"" border=""0"">
              <tr>
                <td bgcolor="""+ colorfondo + @""" class=""header"">
                  <table width=""70"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"">  
                    <tr>
                      <td height=""70"" style=""padding: 0 20px 20px 0;"">
                        <!--<img class=""fix"" src=""images/icon.gif"" width=""70"" height=""70"" border=""0"" alt="" />-->
                      </td>
                    </tr>
                  </table>
                  <!--[if (gte mso 9)|(IE)]>
                    <table width=""425"" align=""left"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                      <tr>
                        <td>
                  <![endif]-->
                  <table class=""col425"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width: 100%; max-width: 425px;"">  
                    <tr>
                      <td height=""70"">
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                          <tr>
                            <td class=""subhead"" style=""padding: 0 0 0 3px;"">
                              Skydive " + cmb_office.Text + @"
                            </td>
                          </tr>
                          <tr>
                            <td class=""subhead"" style=""padding: 5px 0 0 0;"">
                              Reservación pendiente
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                  <!--[if (gte mso 9)|(IE)]>
                        </td>
                      </tr>
                  </table>
                  <![endif]-->
                </td>
              </tr>
              <tr>
                <td class=""innerpadding borderbottom"">
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                    <tr>
                      <td class=""h2"">
        Hola! " + nameFrom +@"
        <br><br>
                        Para nosotros es muy importante tu asistencia!!!
                      </td>
                    </tr>
                    <tr>
                      <td class=""bodycopy"">
                        No olvides realizar tu deposito lo más pronto posible para garantizar tu lugar con nosotros, te recordamos que hay dos maneras de hacerlo, ya sea por medio de un depósito bancario o por transferencia electrónica, elige la que te sea más práctica.
				        <br><br>Y si tienes alguna duda… Comunícate con nosotros!!!<br><br>Este es un Mensaje Generado Automaticamente, no intente responder al mismo. <br><br><br>
                        " + misglobales.usuario_nombre + @" " + misglobales.usuario_paterno + @"<br> " + eMailFrom + @"<br>
                        (52)55.5517.8529 ext 101 ó 102
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td class=""footer"" bgcolor=""#44525f"">
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                    <tr>
                      <td align=""center"" class=""footercopy"">
                        &reg; 
        Copyright © 2016 Skydive " + cmb_office.Text + @". Todos los derechos reservados.<br>
        La Informacion mostrada en este mensaje es para uso interno y confidencial de la empresa, se recomienda discreción.
        <br/><br>
        CENTRO DEPORTIVO DE PARACAIDISMO CUAUTLA, A.C., (SKYDIVE CUAUTLA), reconoce, respeta y es responsable de la protección de sus datos personales. Le informamos que sus datos personales se utilizarán para dar seguimiento a su solicitud planteada con relación a nuestros servicios de paracaidismo. Para mayor información acerca del tratamiento de sus datos personales y de los derechos que puede hacer valer, usted puede consultar nuestro aviso de privacidad integral en el sitio http://www.skydivecuautla.com/aviso_privacidad.html <br>
        AVISO IMPORTANTE: Este correo electrónico y/o material adjunto es/son para uso exclusivo de la persona o la entidad a la que expresamente se le ha enviado, y puede contener información confidencial o material privilegiado. Si usted no es el destinatario legítimo del mismo, por favor repórtelo inmediatamente al originador del correo y bórrelo. Cualquier revisión, retransmisión, difusión o cualquier otro uso de este correo, por personas o entidades distintas a las del destinatario legítimo, queda expresamente prohibido. Este correo electrónico no pretende ni debe ser considerado como constitutivo de ninguna relación legal, contractual o de otra índole similar.<br><br>
                        <a href=""#"" class=""unsubscribe""><font color=""#ffffff"">Darse de baja</font></a> 
                        <span class=""hide"">de esta notificación</span><br/><br>
                      </td>
                    </tr>
                    <tr>
                      <td align=""center"" style=""padding: 20px 0 0 0;"">
                        <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                          <tr>
                            <td width=""37"" style=""text-align: center; padding: 0 10px 0 10px;"">
                              <a href=""http://www.facebook.com/skydivecuautla"">
                                <img src=""images/facebook.png"" width=""37"" height=""37"" alt=""Facebook"" border=""0"" />
                              </a>
                            </td>
                            <td width=""37"" style=""text-align: center; padding: 0 10px 0 10px;"">
                              <a href=""http://www.twitter.com/skydivecuautla"">
                                <img src=""images/twitter.png"" width=""37"" height=""37"" alt=""Twitter"" border=""0"" />
                              </a>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
            <!--[if (gte mso 9)|(IE)]>
                  </td>
                </tr>
            </table>
            <![endif]-->
            </td>
          </tr>
        </table>

        <!--analytics-->
        <script src=""http://code.jquery.com/jquery-1.10.1.min.js""></script>
        <script src=""http://tutsplus.github.io/github-analytics/ga-tracking.min.js""></script>
        </body>
        </html>
        ";
            
            
            
                    //Para nosotros es muy importante tu asistencia!!!! {0} No olvides realizar tu deposito lo más pronto posible para garantizar tu lugar con nosotros, te recordamos que hay dos maneras de hacerlo, ya sea por medio de un depósito bancario o por transferencia electrónica, elige la que te sea más práctica. {0}  " +
                    //            " Y si tienes alguna duda… Comunícate con nosotros!!! " + Environment.NewLine + Environment.NewLine + Environment.NewLine + misglobales.usuario_nombre + " " + misglobales.usuario_paterno + "{0} (52)55.5517.8529 ext. 101 {0} " +
                    //eMailFrom + " {0} www.skydivecuautla.com {0} FB /skydivecuautla {0} TW   {0} {0} {0} " +
                    //            " CENTRO DEPORTIVO DE PARACAIDISMO CUAUTLA, A.C., (SKYDIVE CUAUTLA), reconoce, respeta y es responsable de la protección de sus datos personales. Le informamos que sus datos personales se utilizarán para dar seguimiento a su solicitud planteada con relación a nuestros         servicios de paracaidismo. Para mayor información acerca del tratamiento de sus datos personales y de los derechos que puede hacer valer, usted puede consultar nuestro aviso de privacidad integral en el sitio http://www.skydivecuautla.com/aviso_privacidad.html  {0} " +
                    //            " AVISO IMPORTANTE: Este correo electrónico y/o material adjunto es/son para uso exclusivo de la persona o la entidad a la que expresamente se le ha enviado, y puede contener información confidencial o material privilegiado. Si usted no es el destinatario legítimo del mismo, por favor repórtelo inmediatamente al originador del correo y bórrelo. Cualquier revisión, retransmisión, difusión o cualquier otro uso de este correo, por personas o entidades distintas a las del destinatario legítimo, queda expresamente prohibido. Este correo electrónico no pretende ni debe ser considerado como constitutivo de ninguna relación legal, contractual o de otra índole similar.";
                    //msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true; //Si vas a enviar un correo con contenido html entonces cambia el valor a true
                    //Aquí es donde se hace lo especial
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("reserva.standby@skydivecuautla.com", "#67yhju%");
                    client.Port = 587;
                    client.Host = "mail.skydivecuautla.com";//Este es el smtp valido para Gmail
                    //Esto es para que vaya a través de SSL que es obligatorio con GMail
                    try
                    {
                        client.Send(msg);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
 
            }
        #endregion




        #region Evento click del btn_email
        private void btn_email_Click(object sender, EventArgs e)
        {
            //dg_contacts
            //u.IsValidEmail(email)
            Int32 enviados = 0;
            pb_sync.Visible = true;
            if (rdbtn_reminder.Checked == true)
            {
                DialogResult resultado = MessageBox.Show("Are you sure send reminders eMails !!!!?", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                    for (int i = 0; i < dg_contacts.RowCount; i++)
                    {
                        string emailvalido = Convert.ToString(dg_contacts.Rows[i].Cells[7].Value);
                        if (u.IsValidEmail(emailvalido) == true)
                        {
                            DialogResult resultado2 = MessageBox.Show("Do you want send eMail to: " + Convert.ToString(dg_contacts.Rows[i].Cells[4].Value) + " " + Convert.ToString(dg_contacts.Rows[i].Cells[5].Value), "Warning", MessageBoxButtons.YesNo);
                            if (resultado2 == DialogResult.Yes)
                            {
                                EnviarEmail(Convert.ToString(dg_contacts.Rows[i].Cells[7].Value), misglobales.usuario_email, Convert.ToString(dg_contacts.Rows[i].Cells[4].Value) + " " + Convert.ToString(dg_contacts.Rows[i].Cells[5].Value));
                                enviados = enviados + 1;
                            }
                        }

                    }

                    if (enviados > 0)
                    {
                        MessageBox.Show(enviados + "  eMails has been sent successfully");
                    }
                    pb_sync.Visible = false;
                }
            }
            else  if (rdbtn_instructions.Checked == true)
            {
                //Envía correos con las instrucciones de como proseguir con su reservación
                DialogResult resultado = MessageBox.Show("Are you sure send eMails with INSTRUCTIONS for reserve !!!!?", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    for (int i = 0; i < dg_contacts.RowCount; i++)
                    {
                        string emailvalido = Convert.ToString(dg_contacts.Rows[i].Cells[7].Value);
                        if (u.IsValidEmail(emailvalido) == true)
                        {
                            DialogResult resultado2 = MessageBox.Show("Do you want send eMail to: " + Convert.ToString(dg_contacts.Rows[i].Cells[4].Value) + " " + Convert.ToString(dg_contacts.Rows[i].Cells[5].Value), "Warning", MessageBoxButtons.YesNo);
                            if (resultado2 == DialogResult.Yes)
                            {
                                // metodo con el HTML de reservaciones
                                emailinstructions(Convert.ToString(dg_contacts.Rows[i].Cells[7].Value), misglobales.usuario_email, Convert.ToString(dg_contacts.Rows[i].Cells[4].Value));
                                enviados = enviados + 1;
                            }
                        }
                    }
                    if (enviados > 0)
                    {
                        MessageBox.Show(enviados + "  eMails has been sent successfully");
                    }
                    pb_sync.Visible = false;

                }
            }
            else if (rdbtn_confirmation.Checked == true)
            {
                //envía correos con el número de reservación y la instrucciones de como llegar a la zona
                DialogResult resultado = MessageBox.Show("Are you sure send eMails with CONFIRMATION instructions !!!!?", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    for (int i = 0; i < dg_contacts.RowCount; i++)
                    {
                        string emailvalido = Convert.ToString(dg_contacts.Rows[i].Cells[7].Value);
                        if (u.IsValidEmail(emailvalido) == true)
                        {
                           DialogResult resultado2 = MessageBox.Show("Do you want send eMail to: " + Convert.ToString(dg_contacts.Rows[i].Cells[4].Value) + " " + Convert.ToString(dg_contacts.Rows[i].Cells[5].Value), "Warning", MessageBoxButtons.YesNo);
                           if (resultado2 == DialogResult.Yes)
                           {
                               // metodo con el HTML de reservaciones

                               enviados = enviados + 1;
                           }
                        }
                    }
                    if (enviados > 0)
                    {
                        MessageBox.Show(enviados + "  eMails has been sent successfully");
                    }
                    pb_sync.Visible = false;

                }
            }

        }
        #endregion



    }
}
