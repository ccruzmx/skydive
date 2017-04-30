using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_Manifiest : Form
    {

        #region variables de la clase
        Int32 cronometros = 0;
        ConectaBD Permisos = new ConectaBD();
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String campos, tabla, condicion = "";
        Frm_Itinerary frm = new Frm_Itinerary();
        ConectaBD Menus;
        ConectaBD Monitores = new ConectaBD();
       
        
        Int32 onoff = 0;
        // Variables del cronometro
        Int32 obj0 = 9999, obj1 = 9999, obj2 = 9999, obj3 = 9999, obj4 = 9999, obj5 = 9999, obj6 = 9999, obj7 = 9999, obj8 = 9999, obj9 = 9999, obj10 = 9999;
        Int32 obj11 = 9999, obj12 = 9999, obj13 = 9999, obj14 = 9999, obj15 = 9999, obj16 = 9999, obj17 = 9999, obj18 = 9999, obj19 = 9999;
        Int32 horas, centesimas = 100, segundos = 59, minutos = 20;
        Int32 horas2, centesimas2 = 100, segundos2 = 59, minutos2 = 20;
        Int32 horas3, centesimas3 = 100, segundos3 = 59, minutos3 = 20;
        Int32 horas4, centesimas4 = 100, segundos4 = 59, minutos4 = 20;
        Int32 horas5, centesimas5 = 100, segundos5 = 59, minutos5 = 20;
        Int32 horas6, centesimas6 = 100, segundos6 = 59, minutos6 = 20;
        Int32 horas7, centesimas7 = 100, segundos7 = 59, minutos7 = 20;
        Int32 horas8, centesimas8 = 100, segundos8 = 59, minutos8 = 20;
        Int32 horas9, centesimas9 = 100, segundos9 = 59, minutos9 = 20;
        Int32 horas10, centesimas10 = 100, segundos10 = 59, minutos10 = 20;
        Int32 horas11, centesimas11 = 100, segundos11 = 59, minutos11 = 20;
        Int32 horas12, centesimas12 = 100, segundos12 = 59, minutos12 = 20;
        Int32 horas13, centesimas13 = 100, segundos13 = 59, minutos13 = 20;
        Int32 horas14, centesimas14 = 100, segundos14 = 59, minutos14 = 20;
        Int32 horas15, centesimas15 = 100, segundos15 = 59, minutos15 = 20;
        Int32 horas16, centesimas16 = 100, segundos16 = 59, minutos16 = 20;
        Int32 horas17, centesimas17 = 100, segundos17 = 59, minutos17 = 20;
        Int32 horas18, centesimas18 = 100, segundos18 = 59, minutos18 = 20;
        Int32 horas19, centesimas19 = 100, segundos19 = 59, minutos19 = 20;
        Int32 horas20, centesimas20 = 100, segundos20 = 59, minutos20 = 20;

        Int32 ancla = 20;

        bool estado = true, estado2 = true, estado3 = true, estado4 = true, estado5 = true, estado6 = true, estado7 = true, estado8 = true, estado9 = true, estado10 = true;
        bool estado11 = true, estado12 = true, estado13 = true, estado14 = true, estado15 = true, estado16 = true, estado17 = true, estado18 = true, estado19 = true, estado20 = true;

        Int32 bgobj0 = 9999, bgobj1 = 9999, bgobj2 = 9999, bgobj3 = 9999, bgobj4 = 9999, bgobj5 = 9999, bgobj6 = 9999, bgobj7 = 9999, bgobj8 = 9999, bgobj9 = 9999, bgobj10 = 9999;
        Int32 bgobj11 = 9999, bgobj12 = 9999, bgobj13 = 9999, bgobj14 = 9999, bgobj15 = 9999, bgobj16 = 9999, bgobj17 = 9999, bgobj18 = 9999, bgobj19 = 9999;

        Int32 monobj0 = 9999, monobj1 = 9999, monobj2 = 9999;

        Int32 registroseleccionado = 0;


        String registrovuelo, cronometro="";

        String cronometro2 = "", cronometro3 = "", cronometro4 = "", cronometro5 = "", cronometro6 = "", cronometro7 = "", cronometro8 = "", cronometro9 = "", cronometro10 = "";
        String cronometro11 = "", cronometro12 = "", cronometro13 = "", cronometro14 = "", cronometro15 = "", cronometro16 = "", cronometro17 = "", cronometro18 = "", cronometro19 = "", cronometro20 = "";

        bool _cronometro = true, _cronometro2 = true, _cronometro3 = true, _cronometro4 = true, _cronometro5 = true, _cronometro6 = true, _cronometro7 = true, _cronometro8 = true, _cronometro9 = true, _cronometro10 = true;
        bool _cronometro11 = true, _cronometro12 = true, _cronometro13 = true, _cronometro14 = true, _cronometro15 = true, _cronometro16 = true, _cronometro17 = true, _cronometro18 = true, _cronometro19 = true, _cronometro20 = true;

        Int32 _cronolista = 0, _cronolista2 = 0, _cronolista3 = 0, _cronolista4 = 0, _cronolista5 = 0, _cronolista6 = 0, _cronolista7 = 0, _cronolista8 = 0, _cronolista9 = 0, _cronolista10 = 0;
        Int32 _cronolista11 = 0, _cronolista12 = 0, _cronolista13 = 0, _cronolista14 = 0, _cronolista15 = 0, _cronolista16 = 0, _cronolista17 = 0, _cronolista18 = 0, _cronolista19 = 0, _cronolista20 = 0;

        Int32 borrados = 0;
        Int32 longitud=0;

        Int32 enmonitor = 0;


        Int32 idvuelo ;
        Int32 numerovuelo;
        String matricula;
        Int32 estatus;
        String estatusd;
        Int32 oncall;



        // ***************************************

        #endregion

        #region Constructor
        public Frm_Manifiest()
        {
            { InitializeComponent(); }

        }
        #endregion

        #region HabilitoObjetos
        private void habilitoobjetos()
        {

            bool lopresento = Permisos.habilitado("btn_destroy");
            btn_destroy.Visible = lopresento;



        }
        #endregion

        #region Inicializa grid vuelos
        private void inicializagridview()
        {
//            condicion = @" WHERE DAY(VUELOS.fechaabrevuelo) >= DAY(GETDATE())  
//                             AND MONTH(VUELOS.fechaabrevuelo) >= MONTH(GETDATE())  
//                             AND YEAR(VUELOS.fechaabrevuelo) >= YEAR(GETDATE())  ";

            condicion = " WHERE  CONVERT(VARCHAR(10), VUELOS.fechaabrevuelo, 23) = CONVERT(VARCHAR(10),'" + dp_filterdate.Text + "',23)";
            dg_flights.EnableHeadersVisualStyles = false;
            dg_flights.DataSource = conexion.ConsultaVuelos(condicion);   //getdata(fuente;
            dg_flights.Columns[0].Width = 10; //IDVUELO
            dg_flights.Columns[0].Visible = false;
            dg_flights.Columns[1].Width = 10; //IDAERONAVE
            dg_flights.Columns[1].Visible = false;
            dg_flights.Columns[2].Width = 50; //NUMERO DE VUELO

            dg_flights.Columns[3].Width = 110; //MATRICULA
            dg_flights.Columns[4].Width = 70;  //CODIGO DEL AVION
            dg_flights.Columns[4].Visible = false;
            dg_flights.Columns[5].Width = 90;  //CAPACIDAD PERSONAS
            dg_flights.Columns[6].Width = 90;  //CAPACIDAD PESO
            dg_flights.Columns[7].Width = 70;  //ALTITUD
            dg_flights.Columns[8].Width = 168;  //IDPILOTO
            dg_flights.Columns[8].Visible = false;


            dg_flights.Columns[9].Width = 110;  //NOMBRE PILOTO
            dg_flights.Columns[10].Width = 110;  //PATERNO PILOTO
            dg_flights.Columns[11].Width = 120;  //MATERNO PILOTO
            dg_flights.Columns[11].Visible = false;
            dg_flights.Columns[12].Width = 120;  //LICENCIA PILOTO
            dg_flights.Columns[12].Visible = false;
            dg_flights.Columns[13].Width = 150;  //FECHA APERTURA DE VUELO
            dg_flights.Columns[14].Width = 150;  //FECHA CIERRE DEL VUELO
            dg_flights.Columns[15].Width = 168;  //ID ESTATUS VUELO
            dg_flights.Columns[15].Visible = false;
            dg_flights.Columns[16].Width = 70;  //DESCRIPCION ESTATUS DE VUELO
            dg_flights.Columns[17].Width = 168;  //IDUSUARIO
            dg_flights.Columns[17].Visible = false;
            dg_flights.Columns[18].Width = 200;  //NOMBRE USUARIO
            dg_flights.Columns[18].Visible = false;
            dg_flights.Columns[19].Width = 100;
            dg_flights.Columns[19].Visible = false;
            //dg_flights.Columns[20].Width = 50;

            //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            //dg_flights.Columns.Add(chk);
            //chk.HeaderText = "Monitor"; 


            dg_flights.Columns[2].HeaderText = "#";
            dg_flights.Columns[3].HeaderText = "AIRCRAFT REGISTRATION NUMBER";
            dg_flights.Columns[4].HeaderText = "PLANE CODE";
            dg_flights.Columns[5].HeaderText = "ON BOARD";
            dg_flights.Columns[6].HeaderText = "CAPCITY WEIGHT";
            dg_flights.Columns[7].HeaderText = "ALTITUD";

            dg_flights.Columns[9].HeaderText = "PILOT FIRST NAME";
            dg_flights.Columns[10].HeaderText = "PILOT LAST NAME";
            dg_flights.Columns[11].HeaderText = "PILOT SECOND LAST NAME";
            dg_flights.Columns[12].HeaderText = "LICENSE";
            dg_flights.Columns[13].HeaderText = "OPEN DATE";
            dg_flights.Columns[14].HeaderText = "CLOSE DATE";
            dg_flights.Columns[16].HeaderText = "STATUS FLIGHT";
            dg_flights.Columns[18].HeaderText = "NAME FLIGHT CREATOR";
            dg_flights.Columns[19].HeaderText = "ON CALL";




            u.Formatodgv(dg_flights);
            InicializaObjetos(false);

        }
        #endregion

        #region InicializaObjetos
        private void InicializaObjetos(Boolean textboxonly)
        {
            System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-MX", false);
            misglobales.FechaMovimiento = System.DateTime.ParseExact(dp_filterdate.Text, "yyyy-MM-dd", MiFp);

            if (textboxonly)
            {
                txb_planecode.Text = "";
                txb_pilot.Text = "";
                txb_capacitypersons.Text = "";
                txb_capacityweight.Text = "";
                txb_altitud.Text = "";
            }
            else
            {
                txb_planecode.Enabled = true;
                cmb_status.Enabled = true;
                txb_capacitypersons.Enabled = true;
                txb_capacityweight.Enabled = true;
                txb_altitud.Enabled = true;

                txb_planecode.Text = "";
                txb_pilot.Text = "";
                txb_capacitypersons.Text = "";
                txb_capacityweight.Text = "";
                txb_altitud.Text = "";


                cmb_status.SelectedText = "";
                String sql = @"SELECT MATRICULA FROM dbo.CT_AERONAVE WHERE idestatus = 1";
                DataSet dsplane = conexion.ConsultaUniversal(sql, "", "CT_AERONAVE");

                cmb_matricula.SelectedText = "";
                cmb_matricula.DataSource = dsplane.Tables[0].DefaultView;
                cmb_matricula.AutoCompleteCustomSource = LoadAutoComplete(dsplane, "MATRICULA");
                cmb_matricula.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_matricula.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_matricula.ValueMember = "MATRICULA";
                cmb_matricula.SelectedItem = null;


                sql = @"SELECT IDESTATUS, DESCRIPCION AS ESTATUS FROM dbo.CT_ESTATUS WHERE IDESTATUS IN (5, 6)";
                DataSet dsestatus = conexion.ConsultaUniversal(sql, "", "CT_ESTATUS");

                cmb_status.DataSource = dsestatus.Tables[0].DefaultView;
                cmb_status.AutoCompleteCustomSource = LoadAutoComplete(dsestatus, "ESTATUS");
                cmb_status.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_status.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_status.ValueMember = "ESTATUS";
                cmb_status.SelectedItem = null;
            

                sql = @"SELECT IDPILOTO, NOMBRE_PILOTO + ' ' + PATERNO_PILOTO + ' ' + MATERNO_PILOTO as PILOTO FROM dbo.CT_PILOTO";
                DataSet dspiloto = conexion.ConsultaUniversal(sql,"  WHERE IDESTATUS = 1 ", "CT_PILOTO");

                cmb_piloto.DataSource = dspiloto.Tables[0].DefaultView;
                cmb_piloto.AutoCompleteCustomSource = LoadAutoComplete(dspiloto, "PILOTO");
                cmb_piloto.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_piloto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_piloto.ValueMember = "PILOTO";
                cmb_piloto.SelectedItem = null;

                sql = @" SELECT count(tandemup.idtandemup) NUMJUMPERS FROM dbo.TB_TANDEMUP tandemup 
                          WHERE ( YEAR(tandemup.reserved_date) = YEAR(GETDATE()) AND MONTH(tandemup.reserved_date) = MONTH(GETDATE()) AND DAY(tandemup.reserved_date) = DAY(GETDATE()) )";
                DataSet dstandemup = conexion.ConsultaUniversal(sql, "", "TB_TANDEMUP");
                Int32 numjumpers = Convert.ToInt32(dstandemup.Tables[0].Rows[0].ItemArray[0].ToString());
                if (numjumpers > 0)
                {
                    txb_tandemup.Visible = true;
                    lbl_tandemup.Visible = true;
                    txb_tandemup.Text = numjumpers.ToString();
                    txb_tandemup.BackColor = Color.Orange;
                    txb_tandemup.ForeColor = Color.DarkGreen;
                }
                else
                {
                    txb_tandemup.Text = "";
                    txb_tandemup.Visible = false;
                }
                dstandemup.Dispose();


            }

        }
        #endregion

        #region LoadAutoComplete
        public static AutoCompleteStringCollection LoadAutoComplete(DataSet ds, String campo)
        {

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                stringCol.Add(Convert.ToString(row[campo]));
            }
            return stringCol;
        }
        #endregion

        #region Load del Frm_Manifiest
        private void Frm_Manifiest_Load(object sender, EventArgs e)
        {
            dp_filterdate.Value = DateTime.Now.Date;
            misglobales.FechaMovimiento = Convert.ToDateTime(dp_filterdate.Text);
            //System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-MX", false);
            //misglobales.FechaMovimiento = System.DateTime.ParseExact(dp_filterdate.Text, "yyyy-MM-dd", MiFp);



            habilitoobjetos();
            inicializagridview();
            
        }
        #endregion

        #region Evento clik boton salir
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion

        #region Evento boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos(false);
        }
        #endregion

        #region Selecciona matricula en el combo
        private void cmb_matricula_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InicializaObjetos(true);
            condicion = " Where AERONAVE.matricula = '" + cmb_matricula.SelectedValue + "' ";
            String sql = @" SELECT AERONAVE.matricula AS MATRICULA, AERONAVE.codigo AS [PLANE CODE], AERONAVE.capacidadpersonas AS [CAPACIDAD PERSONAS], 
                            AERONAVE.capacidadpeso AS [CAPACIDAD PESO], AERONAVE.altitud AS [PLANE ALTITUD], 
                            AERONAVE.IDPILOTO,  PILOTO.nombre_piloto AS [NOMBRE PILOTO], PILOTO.paterno_piloto [PATERNO PILOTO], PILOTO.materno_piloto [MATERNO PILOTO], 
                            PILOTO.licencia AS [LICENCIA PILOTO]
                            FROM dbo.CT_AERONAVE AERONAVE 
                            INNER JOIN dbo.CT_PILOTO PILOTO ON PILOTO.idpiloto = AERONAVE.idpiloto
                            INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.idestatus = AERONAVE.IDESTATUS " + condicion + " ORDER BY AERONAVE.matricula ";
            try
            {
                DataSet dsplane = conexion.ConsultaUniversal(sql, "", "CT_AERONAVE");
                txb_planecode.Text = dsplane.Tables[0].Rows[0].ItemArray[1].ToString();//     .Rows[0].ItemArray[1];
                cmb_piloto.SelectedText = dsplane.Tables[0].Rows[0].ItemArray[6].ToString() + " " + dsplane.Tables[0].Rows[0].ItemArray[7].ToString() + " " + dsplane.Tables[0].Rows[0].ItemArray[8].ToString();


                txb_pilot.Text = dsplane.Tables[0].Rows[0].ItemArray[5].ToString();

                txb_capacitypersons.Text = dsplane.Tables[0].Rows[0].ItemArray[2].ToString();
                txb_capacityweight.Text = dsplane.Tables[0].Rows[0].ItemArray[3].ToString();
                txb_altitud.Text = dsplane.Tables[0].Rows[0].ItemArray[4].ToString();
                //cmb_status.SelectedText = "OPEN";
                cmb_status.SelectedValue = "OPEN";

                txb_planecode.Enabled = false;
                cmb_status.Enabled = false;
                txb_capacitypersons.Enabled = false;
                txb_capacityweight.Enabled = false;
                txb_altitud.Enabled = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying read database, please try againb later (" + ex + ")");
            }


        }
        #endregion

        #region Valida si estan llenos todos los campos
        public bool validacampos()
        {

            if (cmb_matricula.Text == "")
            {
                MessageBox.Show("Need select a Aircraft registration number");
                return false;

            }

            if (cmb_status.Text == "")
            {
                MessageBox.Show("Need select a status");
                return false;
            }


            return true;

        }
        #endregion

        #region Determina si es Insert or Update
        public String InserUpdate(String condicion)
        {
            DataTable dt;
            dt = conexion.ConsultaVuelos(condicion);
            if (dt.Rows.Count == 0)
            {
                return "insert";
            }
            else
            {
                return "update";
            }
        }
        #endregion

        #region Registrar o actualizar vuelo
        private void btn_registrarvuelo_Click(object sender, EventArgs e)
        {
            String campos;
            Int32 numerovuelo = 0;

            //System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-MX", false);
            //misglobales.FechaMovimiento = System.DateTime.ParseExact(dp_filterdate.Text, "yyyy-MM-dd", MiFp);

            if (validacampos())
            {

                String sql = @"SELECT idaeronave, idpiloto FROM dbo.CT_AERONAVE WHERE MATRICULA = '" + cmb_matricula.Text + "'";
                DataSet dsplane = conexion.ConsultaUniversal(sql, "", "CT_AERONAVE");
                DataSet dsvuelo;
                
                String tabla = "dbo.TB_VUELOS";

                condicion = @" WHERE vuelos.idaeronave = " + dsplane.Tables[0].Rows[0][0].ToString() +
                            @" and vuelos.idestatus = 6 AND day(vuelos.FECHAABREVUELO) = day("+dp_filterdate.Text+") and MONTH(vuelos.FECHAABREVUELO) = MONTH("+dp_filterdate.Text+ @")
                               and YEAR(vuelos.FECHAABREVUELO) = YEAR("+dp_filterdate.Text+") AND 3=2";

                sql = @" SELECT ISNULL(MAX(NUMEROVUELO),0)+1 NUMEROVUELO 
                           FROM dbo.TB_VUELOS 
                          WHERE idaeronave = " + dsplane.Tables[0].Rows[0][0].ToString() +
                        @"  AND (       DAY(fechaabrevuelo) = DAY('"+dp_filterdate.Text+@"') 
                                    AND MONTH(fechaabrevuelo) = MONTH('"+dp_filterdate.Text+@"') 
                                    AND YEAR(fechaabrevuelo) = YEAR('"+dp_filterdate.Text+@"')
                                 )";
                dsvuelo = conexion.ConsultaUniversal(sql, "", "TB_VUELOS");


                if ( InserUpdate(condicion ) == "insert")
                {
                    String Dia = misglobales.FechaMovimiento.ToString("dd");
                    String Mes = misglobales.FechaMovimiento.ToString("MM");
                    String yy = misglobales.FechaMovimiento.ToString("yyyy");
                    String fecha = Dia + "-" + Mes + "-" + yy;


                    campos = "idaeronave, idpiloto, numerovuelo, fechaabrevuelo, fechacierrevuelo, idestatus, idusuario, idoficina, manifest_code_migration, capacity, Loaded, BackToBack";
                    String valores = dsplane.Tables[0].Rows[0][0].ToString() + "," + txb_pilot.Text + ", " + dsvuelo.Tables[0].Rows[0].ItemArray[0].ToString() + ", CONVERT(VARCHAR(10),'" + fecha.ToString() + "',23) , NULL, 6, " +
                    misglobales.usuario_idusuario + ", " + misglobales.oficina_id_oficina + ", null,  " + txb_capacitypersons.Text + ", 0, 0";
                    conexion.InsertTabla(campos, tabla, valores);
                }
                else
                {
                    sql = @"SELECT IDESTATUS FROM dbo.CT_ESTATUS WHERE DESCRIPCION = '" + cmb_status.Text + "'";
                    DataSet dsestatus = conexion.ConsultaUniversal(sql, "", "CT_ESTATUS");
                    condicion = " WHERE idaeronave = " + dsplane.Tables[0].Rows[0][0].ToString() + " and idestatus = 6 AND FECHAABREVUELO >= GETDATE()-1 ";
                    campos = @" idestatus = " + dsestatus.Tables[0].Rows[0][0].ToString() + ", fechacierrevuelo = getdate() ";
                    conexion.UpdateTabla(campos, tabla, condicion);
                }

                inicializagridview();

            }


        }
        #endregion

        #region Pinta renglones condicionados
        private void dg_flights_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Font Negrita = new Font(dg_flights.Font, FontStyle.Bold);
            Font Normal = new Font(dg_flights.Font, FontStyle.Regular);

            if ((e.RowIndex) < (this.dg_flights.Rows.Count ))
            {

                DataGridViewRow gvr = this.dg_flights.Rows[e.RowIndex];

                if (gvr.Cells["ESTATUS VUELO"].Value.ToString() == "OPEN")
                {

                    gvr.DefaultCellStyle.Font = Negrita;
                    gvr.DefaultCellStyle.ForeColor = Color.Green;

                }
                else if (gvr.Cells["ESTATUS VUELO"].Value.ToString() == "CLOSED")
                {

                    gvr.DefaultCellStyle.Font = Normal;
                    gvr.DefaultCellStyle.ForeColor = Color.DarkGray;


                }

            }
        }
        #endregion

        #region Selecciona un piloto
        private void cmb_piloto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txb_pilot.Text = "";
            String sql = @"SELECT IDPILOTO, NOMBRE_PILOTO + ' ' + PATERNO_PILOTO + ' ' + MATERNO_PILOTO as PILOTO FROM dbo.CT_PILOTO";
            DataSet dspiloto = conexion.ConsultaUniversal(sql, "  WHERE NOMBRE_PILOTO + ' ' + PATERNO_PILOTO + ' ' + MATERNO_PILOTO = '" + cmb_piloto.SelectedValue + "'", "CT_PILOTO");
            txb_pilot.Text = dspiloto.Tables[0].Rows[0].ItemArray[0].ToString();

        }
        #endregion

        #region Evento doble click
        private void dg_flights_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (misglobales.id2 != 2)
                {
                    misglobales.id1 = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[0].Value.ToString());
                    Frm_ManifiestJumpers frmjumpers = new Frm_ManifiestJumpers();
                    //this.Visible = false;

                    //u.Pasarcampo(dg_flights, txb_officename, "OFFICE NAME");
                    //u.Pasarcampo(dg_flights, txb_geographical, "COORDINATES");
                    //u.Pasarcombo(dg_flights, Cmb_State, "STATES DESCRIPTION");
                    //u.Pasarcombo(dg_flights, cmb_status, "STATUS");
                    //u.Pasarcombo(dg_flights, cmb_responsable, "OFFICE RESPONSABLE");
                    //Catalogos.Plantilla Formulario = (Catalogos.Plantilla)ObjFrm;
                    //Formulario.Id_Perfil = id_Perfil;
                    Int32 reloj = dg_flights.CurrentRow.Index;
                    misglobales._Updatedate = Convert.ToDateTime(dp_filterdate.Text);


                    if (bgobj0 == reloj) { misglobales.manifiestomin = minutos; misglobales.manifiestoseg = segundos; misglobales.maifiestocentesimas = centesimas; }
                    else if (bgobj1 == reloj) { misglobales.manifiestomin = minutos2; misglobales.manifiestoseg = segundos2; misglobales.maifiestocentesimas = centesimas2; }
                    else if (bgobj2 == reloj) { misglobales.manifiestomin = minutos3; misglobales.manifiestoseg = segundos3; misglobales.maifiestocentesimas = centesimas3; }
                    else if (bgobj3 == reloj) { misglobales.manifiestomin = minutos4; misglobales.manifiestoseg = segundos4; misglobales.maifiestocentesimas = centesimas4; }
                    else if (bgobj4 == reloj) { misglobales.manifiestomin = minutos5; misglobales.manifiestoseg = segundos5; misglobales.maifiestocentesimas = centesimas5; }
                    else if (bgobj5 == reloj) { misglobales.manifiestomin = minutos6; misglobales.manifiestoseg = segundos6; misglobales.maifiestocentesimas = centesimas6; }
                    else if (bgobj6 == reloj) { misglobales.manifiestomin = minutos7; misglobales.manifiestoseg = segundos7; misglobales.maifiestocentesimas = centesimas7; }
                    else if (bgobj7 == reloj) { misglobales.manifiestomin = minutos8; misglobales.manifiestoseg = segundos8; misglobales.maifiestocentesimas = centesimas8; }
                    else if (bgobj8 == reloj) { misglobales.manifiestomin = minutos9; misglobales.manifiestoseg = segundos9; misglobales.maifiestocentesimas = centesimas9; }
                    else if (bgobj9 == reloj) { misglobales.manifiestomin = minutos10; misglobales.manifiestoseg = segundos10; misglobales.maifiestocentesimas = centesimas10; }
                    else if (bgobj10 == reloj) { misglobales.manifiestomin = minutos11; misglobales.manifiestoseg = segundos11; misglobales.maifiestocentesimas = centesimas11; }
                    else if (bgobj11 == reloj) { misglobales.manifiestomin = minutos12; misglobales.manifiestoseg = segundos12; misglobales.maifiestocentesimas = centesimas12; }
                    else if (bgobj12 == reloj) { misglobales.manifiestomin = minutos13; misglobales.manifiestoseg = segundos13; misglobales.maifiestocentesimas = centesimas13; }
                    else if (bgobj13 == reloj) { misglobales.manifiestomin = minutos14; misglobales.manifiestoseg = segundos14; misglobales.maifiestocentesimas = centesimas14; }
                    else if (bgobj14 == reloj) { misglobales.manifiestomin = minutos15; misglobales.manifiestoseg = segundos15; misglobales.maifiestocentesimas = centesimas15; }
                    else if (bgobj15 == reloj) { misglobales.manifiestomin = minutos16; misglobales.manifiestoseg = segundos16; misglobales.maifiestocentesimas = centesimas16; }
                    else if (bgobj16 == reloj) { misglobales.manifiestomin = minutos17; misglobales.manifiestoseg = segundos17; misglobales.maifiestocentesimas = centesimas17; }
                    else if (bgobj17 == reloj) { misglobales.manifiestomin = minutos18; misglobales.manifiestoseg = segundos18; misglobales.maifiestocentesimas = centesimas18; }
                    else if (bgobj18 == reloj) { misglobales.manifiestomin = minutos19; misglobales.manifiestoseg = segundos19; misglobales.maifiestocentesimas = centesimas19; }
                    else if (bgobj19 == reloj) { misglobales.manifiestomin = minutos20; misglobales.manifiestoseg = segundos20; misglobales.maifiestocentesimas = centesimas20; }

                    misglobales.numero_de_vuelo = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[2].Value.ToString());

                    misglobales.id2 = 2; //indica si esta aierto el manifiesto
                    frmjumpers.MdiParent = MDISkyDiveCuautla.ActiveForm;
                    frmjumpers.WindowState = FormWindowState.Maximized;
                    frmjumpers.Show();
                }
                else
                {
                    MessageBox.Show("Warning you have already open a manifiest, please close this and try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Forma Manifiesto activada
        private void Frm_Manifiest_Activated(object sender, EventArgs e)
        {
             inicializagridview(); 
        }
        #endregion

        #region Metodo de borrado
        private void borrarcronometro(Int32 elemento)
        {

            Int32 reloj;

           reloj = elemento;

          // reloj = reloj + borrados;
           if (monobj0 == reloj) { misglobales.ontime1 = "ON-TIME"; //monobj0 = 9999; 
           Monitores.BorraRegistro("idvuelo=" + misglobales.idvuelo1 + " and idusuario = " + misglobales.usuario_idusuario.ToString(), "dbo.tb_Monitor");

           }
           if (monobj1 == reloj) { misglobales.ontime2 = "ON-TIME"; //monobj1 = 9999; 
           Monitores.BorraRegistro("idvuelo=" + misglobales.idvuelo2 + " and idusuario = " + misglobales.usuario_idusuario.ToString(), "dbo.tb_Monitor"); 
           }
           if (monobj2 == reloj) { misglobales.ontime3 = "ON-TIME"; //monobj2 = 9999; 
           Monitores.BorraRegistro("idvuelo=" + misglobales.idvuelo3 + " and idusuario = " + misglobales.usuario_idusuario.ToString(), "dbo.tb_Monitor");
           }


           if (obj0 == reloj)
           {
               timer_cronometro.Stop(); _cronometro = true;
               if (obj1 > 0 & obj1 > obj0) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj0) { obj2 = obj2 - 1; } 
               if (obj3 > 0 & obj3 > obj0) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj0) { obj4 = obj4 - 1; } 
               if (obj5 > 0 & obj5 > obj0) { obj5 = obj5 - 1; } 
               if (obj6 > 0 & obj6 > obj0) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj0) { obj7 = obj7 - 1; } 
               if (obj8 > 0 & obj8 > obj0) { obj8 = obj8 - 1; } 
               if (obj9 > 0 & obj9 > obj0) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj0) { obj10 = obj10 - 1; } 
               if (obj11 > 0 & obj11 > obj0) { obj11 = obj11 - 1; } 
               if (obj12 > 0 & obj12 > obj0) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj0) { obj13 = obj13 - 1; } 
               if (obj14 > 0 & obj14 > obj0) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj0) { obj15 = obj15 - 1; } 
               if (obj16 > 0 & obj16 > obj0) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj0) { obj17 = obj17 - 1; } 
               if (obj18 > 0 & obj18 > obj0) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj0) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; obj6 = obj5; obj5 = obj4; obj4 = obj3; obj3 = obj2; obj2 = obj1; obj1 = obj0; 
               obj0 = 9999;
               dg_flights.Rows[bgobj0].Cells[19].Value = 0;
               bgobj0 = 9999;
               if (reloj < ancla) { ancla = obj0; }
           }
           else if (obj1 == reloj)
           {
               timer_cronometro2.Stop(); _cronometro2 = true;
               if (obj0 > 0 & obj0 > obj1) { obj0 = obj0 - 1; }
               if (obj2 > 0 & obj2 > obj1) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj1) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj1) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj1) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj1) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj1) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj1) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj1) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj1) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj1) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj1) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj1) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj1) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj1) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj1) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj1) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj1) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj1) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; obj6 = obj5; obj5 = obj4; obj4 = obj3; obj3 = obj2; obj2 = obj1;
               dg_flights.Rows[bgobj1].Cells[19].Value = 0;
               obj1 = 9999; bgobj1 = 9999;
               if (reloj < ancla) { ancla = obj1; }
           }
           else if (obj2 == reloj)
           {
               timer_cronometro3.Stop(); _cronometro3 = true;
               if (obj0 > 0 & obj0 > obj2) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj2) { obj1 = obj1 - 1; }
               if (obj3 > 0 & obj3 > obj2) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj2) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj2) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj2) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj2) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj2) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj2) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj2) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj2) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj2) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj2) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj2) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj2) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj2) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj2) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj2) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj2) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; obj6 = obj5; obj5 = obj4; obj4 = obj3; obj3 = obj2;
               dg_flights.Rows[bgobj2].Cells[19].Value = 0;
               obj2 = 9999; bgobj2 = 9999;
               if (reloj < ancla) { ancla = obj2; }
           }
           else if (obj3 == reloj) 
           {
               timer_cronometro4.Stop(); _cronometro4 = true;
               if (obj0 > 0 & obj0 > obj3) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj3) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj3) { obj2 = obj2 - 1; }
               if (obj4 > 0 & obj4 > obj3) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj3) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj3) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj3) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj3) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj3) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj3) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj3) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj3) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj3) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj3) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj3) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj3) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj3) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj3) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj3) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; obj6 = obj5; obj5 = obj4; obj4 = obj3;
               dg_flights.Rows[bgobj3].Cells[19].Value = 0;
               obj3 = 9999; bgobj3 = 9999;
               if (reloj < ancla) { ancla = obj3; }
           }
           else if (obj4 == reloj) 
           {
               timer_cronometro5.Stop(); _cronometro5 = true;
               if (obj0 > 0 & obj0 > obj4) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj4) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj4) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj4) { obj3 = obj3 - 1; }
               if (obj5 > 0 & obj5 > obj4) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj4) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj4) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj4) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj4) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj4) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj4) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj4) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj4) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj4) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj4) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj4) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj4) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj4) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj4) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; obj6 = obj5; obj5 = obj4;
               dg_flights.Rows[bgobj4].Cells[19].Value = 0;
               obj4 = 9999; bgobj4 = 9999;
               if (reloj < ancla) { ancla = obj4; }
           }
           else if (obj5 == reloj) 
           {
               timer_cronometro6.Stop(); _cronometro6 = true;
               if (obj0 > 0 & obj0 > obj5) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj5) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj5) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj5) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj5) { obj4 = obj4 - 1; }

               if (obj6 > 0 & obj6 > obj5) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj5) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj5) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj5) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj5) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj5) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj5) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj5) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj5) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj5) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj5) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj5) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj5) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj5) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; obj6 = obj5; obj5 = obj4;
               dg_flights.Rows[bgobj5].Cells[19].Value = 0;
               obj5 = 9999; bgobj5 = 9999;
               if (reloj < ancla) { ancla = obj5; }
           }
           else if (obj6 == reloj) 
           {
               timer_cronometro7.Stop(); _cronometro7 = true;
               if (obj0 > 0 & obj0 > obj6) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj6) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj6) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj6) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj6) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj6) { obj5 = obj5 - 1; }

               if (obj7 > 0 & obj7 > obj6) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj6) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj6) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj6) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj6) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj6) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj6) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj6) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj6) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj6) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj6) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj6) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj6) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               //obj7 = obj6; 
               dg_flights.Rows[bgobj6].Cells[19].Value = 0;
               obj6 = 9999; bgobj6 = 9999;
               if (reloj < ancla) { ancla = obj6; }
 
           }
           else if (obj7 == reloj) 
           {
               timer_cronometro8.Stop(); _cronometro8 = true;
               if (obj0 > 0 & obj0 > obj7) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj7) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj7) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj7) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj7) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj7) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj7) { obj6 = obj6 - 1; }
               if (obj8 > 0 & obj8 > obj7) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj7) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj7) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj7) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj7) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj7) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj7) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj7) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj7) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj7) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj7) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj7) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8; obj8 = obj7;
               dg_flights.Rows[bgobj7].Cells[19].Value = 0;
               obj7 = 9999; bgobj7 = 9999;
               if (reloj < ancla) { ancla = obj7; }
  
           }
           else if (obj8 == reloj) 
           {
               timer_cronometro9.Stop(); _cronometro9 = true;
               if (obj0 > 0 & obj0 > obj8) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj8) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj8) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj8) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj8) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj8) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj8) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj8) { obj7 = obj7 - 1; }

               if (obj9 > 0 & obj9 > obj8) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj8) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj8) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj8) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj8) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj8) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj8) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj8) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj8) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj8) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj8) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9; obj9 = obj8;
               dg_flights.Rows[bgobj8].Cells[19].Value = 0;
               obj8 = 9999; bgobj8 = 9999;
               if (reloj < ancla) { ancla = obj8; }
           }
           else if (obj9 == reloj)
           {
               timer_cronometro10.Stop(); _cronometro10 = true;
               if (obj0 > 0 & obj0 > obj9) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj9) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj9) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj9) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj9) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj9) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj9) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj9) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj9) { obj8 = obj8 - 1; }

               if (obj10 > 0 & obj10 > obj9) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj9) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj9) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj9) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj9) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj9) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj9) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj9) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj9) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj9) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10; obj10 = obj9;
               dg_flights.Rows[bgobj9].Cells[19].Value = 0;
               obj9 = 9999;
               bgobj9 = 9999;
               if (reloj < ancla) { ancla = obj9; }
           }
           else if (obj10 == reloj) 
           {
               timer_cronometro11.Stop(); _cronometro11 = true;
               if (obj0 > 0 & obj0 > obj10) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj10) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj10) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj10) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj10) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj10) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj10) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj10) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj10) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj10) { obj9 = obj9 - 1; }

               if (obj11 > 0 & obj11 > obj10) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj10) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj10) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj10) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj10) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj10) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj10) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj10) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj10) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11; obj11 = obj10;
               dg_flights.Rows[bgobj10].Cells[19].Value = 0;
               obj10 = 9999; bgobj10 = 9999;
               if (reloj < ancla) { ancla = obj10; }
           }
           else if (obj11 == reloj) 
           {
               timer_cronometro12.Stop(); _cronometro12 = true;
               if (obj0 > 0 & obj0 > obj11) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj11) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj11) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj11) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj11) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj11) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj11) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj11) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj11) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj11) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj11) { obj10 = obj10 - 1; }

               if (obj12 > 0 & obj12 > obj11) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj11) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj11) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj11) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj11) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj11) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj11) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj11) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; obj12 = obj11;
               dg_flights.Rows[bgobj11].Cells[19].Value = 0;
               obj11 = 9999; bgobj11 = 9999;
               if (reloj < ancla) { ancla = obj11; }
           }
           else if (obj12 == reloj) 
           {
               timer_cronometro13.Stop(); _cronometro13 = true;
               if (obj0 > 0 & obj0 > obj12) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj12) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj12) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj12) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj12) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj12) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj12) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj12) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj12) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj12) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj12) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj12) { obj11 = obj11 - 1; }

               if (obj13 > 0 & obj13 > obj12) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj12) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj12) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj12) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj12) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj12) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj12) { obj19 = obj19 - 1; }
               dg_flights.Rows[bgobj12].Cells[19].Value = 0;
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13; obj13 = obj12; 
               obj12 = 9999; bgobj12 = 9999;
               if (reloj < ancla) { ancla = obj12; }
           }
           else if (obj13 == reloj) 
           {
               timer_cronometro14.Stop(); _cronometro14 = true;
               if (obj0 > 0 & obj0 > obj13) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj13) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj13) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj13) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj13) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj13) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj13) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj13) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj13) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj13) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj13) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj13) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj13) { obj12 = obj12 - 1; }

               if (obj14 > 0 & obj14 > obj13) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj13) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj13) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj13) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj13) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj13) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14; obj14 = obj13;
               dg_flights.Rows[bgobj13].Cells[19].Value = 0;
               obj13 = 9999; bgobj13 = 9999;
               if (reloj < ancla) { ancla = obj13; }
           }
           else if (obj14 == reloj) 
           {
               timer_cronometro15.Stop(); _cronometro15 = true;
               if (obj0 > 0 & obj0 > obj14) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj14) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj14) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj14) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj14) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj14) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj14) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj14) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj14) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj14) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj14) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj14) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj14) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj14) { obj13 = obj13 - 1; }


               if (obj15 > 0 & obj15 > obj14) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj14) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj14) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj14) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj14) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15; obj15 = obj14;
               dg_flights.Rows[bgobj14].Cells[19].Value = 0;
               obj14 = 9999; bgobj14 = 9999;
               if (reloj < ancla) { ancla = obj14; }
           }
           else if (obj15 == reloj) 
           {
               timer_cronometro16.Stop(); _cronometro16 = true;
               if (obj0 > 0 & obj0 > obj15) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj15) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj15) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj15) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj15) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj15) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj15) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj15) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj15) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj15) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj15) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj15) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj15) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj15) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj15) { obj14 = obj14 - 1; }

               if (obj16 > 0 & obj16 > obj15) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj15) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj15) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj15) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16; obj16 = obj15;
               dg_flights.Rows[bgobj15].Cells[19].Value = 0;
               obj15 = 9999; bgobj15 = 9999;
               if (reloj < ancla) { ancla = obj15; }
           }
           else if (obj16 == reloj) 
           {
               timer_cronometro17.Stop(); _cronometro17 = true;
               if (obj0 > 0 & obj0 > obj16) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj16) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj16) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj16) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj16) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj16) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj16) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj16) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj16) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj16) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj16) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj16) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj16) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj16) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj16) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj16) { obj15 = obj15 - 1; }

               if (obj17 > 0 & obj17 > obj16) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj16) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj16) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17; obj17 = obj16;
               dg_flights.Rows[bgobj16].Cells[19].Value = 0;
               obj16 = 9999; bgobj16 = 9999;
               if (reloj < ancla) { ancla = obj16; }
           }
           else if (obj17 == reloj)
           {
               timer_cronometro18.Stop(); _cronometro18 = true;
               if (obj0 > 0 & obj0 > obj17) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj17) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj17) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj17) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj17) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj17) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj17) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj17) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj17) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj17) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj17) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj17) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj17) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj17) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj17) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj17) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj17) { obj16 = obj16 - 1; }

               if (obj18 > 0 & obj18 > obj17) { obj18 = obj18 - 1; }
               if (obj19 > 0 & obj19 > obj17) { obj19 = obj19 - 1; }
               //obj19 = obj18; obj18 = obj17;
               dg_flights.Rows[bgobj17].Cells[19].Value = 0;
               obj17 = 9999; bgobj17 = 9999;
               if (reloj < ancla) { ancla = obj17; }
           }
           else if (obj18 == reloj) 
           {
               timer_cronometro19.Stop(); _cronometro19 = true;
               if (obj0 > 0 & obj0 > obj18) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj18) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj18) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj18) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj18) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj18) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj18) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj18) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj18) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj18) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj18) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj18) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj18) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj18) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj18) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj18) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj18) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj18) { obj17 = obj17 - 1; }

               if (obj19 > 0 & obj19 > obj18) { obj19 = obj19 - 1; }
               //obj19 = obj18;
               dg_flights.Rows[bgobj18].Cells[19].Value = 0;
               obj18 = 9999; bgobj18 = 9999;
               if (reloj < ancla) { ancla = obj18; }
           }
           else if (obj19 == reloj) 
           {
               timer_cronometro20.Stop(); _cronometro20 = true;
               if (obj0 > 0 & obj0 > obj19) { obj0 = obj0 - 1; }
               if (obj1 > 0 & obj1 > obj19) { obj1 = obj1 - 1; }
               if (obj2 > 0 & obj2 > obj19) { obj2 = obj2 - 1; }
               if (obj3 > 0 & obj3 > obj19) { obj3 = obj3 - 1; }
               if (obj4 > 0 & obj4 > obj19) { obj4 = obj4 - 1; }
               if (obj5 > 0 & obj5 > obj19) { obj5 = obj5 - 1; }
               if (obj6 > 0 & obj6 > obj19) { obj6 = obj6 - 1; }
               if (obj7 > 0 & obj7 > obj19) { obj7 = obj7 - 1; }
               if (obj8 > 0 & obj8 > obj19) { obj8 = obj8 - 1; }
               if (obj9 > 0 & obj9 > obj19) { obj9 = obj9 - 1; }
               if (obj10 > 0 & obj10 > obj19) { obj10 = obj10 - 1; }
               if (obj11 > 0 & obj11 > obj19) { obj11 = obj11 - 1; }
               if (obj12 > 0 & obj12 > obj19) { obj12 = obj12 - 1; }
               if (obj13 > 0 & obj13 > obj19) { obj13 = obj13 - 1; }
               if (obj14 > 0 & obj14 > obj19) { obj14 = obj14 - 1; }
               if (obj15 > 0 & obj15 > obj19) { obj15 = obj15 - 1; }
               if (obj16 > 0 & obj16 > obj19) { obj16 = obj16 - 1; }
               if (obj17 > 0 & obj17 > obj19) { obj17 = obj17 - 1; }
               if (obj18 > 0 & obj18 > obj19) { obj18 = obj18 - 1; }

               dg_flights.Rows[bgobj19].Cells[19].Value = 0;
               obj19 = 9999; bgobj19 = 9999;
               if (reloj < ancla) { ancla = obj19; }
           }

           if (elemento >= 0) { lsb_vuelo.Items.RemoveAt(elemento); }


            if (ancla <= reloj)
            {
                borrados = borrados + 1;
            }
            cronometros = cronometros - 1;
        
        }
        #endregion

        #region Evento click al boton Poner en 20 min el cronometro seleccionado
        private void btn_20_Click(object sender, EventArgs e)
        {
            Int32 reloj = lsb_vuelo.SelectedIndex;

            if (obj0 == reloj) { minutos = 20; }
            else if (obj1 == reloj) { minutos2 = 20; }
            else if (obj2 == reloj) { minutos3 = 20; }
            else if (obj3 == reloj) { minutos4 = 20; }
            else if (obj4 == reloj) { minutos5 = 20; }
            else if (obj5 == reloj) { minutos6 = 20; }
            else if (obj6 == reloj) { minutos7 = 20; }
            else if (obj7 == reloj) { minutos8 = 20; }
            else if (obj8 == reloj) { minutos9 = 20; }
            else if (obj9 == reloj) { minutos10 = 20; }
            else if (obj10 == reloj) { minutos11 = 20; }
            else if (obj11 == reloj) { minutos12 = 20; }
            else if (obj12 == reloj) { minutos13 = 20; }
            else if (obj13 == reloj) { minutos14 = 20; }
            else if (obj14 == reloj) { minutos15 = 20; }
            else if (obj15 == reloj) { minutos16 = 20; }
            else if (obj16 == reloj) { minutos17 = 20; }
            else if (obj17 == reloj) { minutos18 = 20; }
            else if (obj18 == reloj) { minutos19 = 20; }
            else if (obj19 == reloj) { minutos20 = 20; }


          

        }
        #endregion

        #region Evento click en el boton Agregar 1 minuto al cronometro seleccionado
        private void btn_1min_Click(object sender, EventArgs e)
        {
            Int32 reloj = lsb_vuelo.SelectedIndex;

            if (obj0 == reloj) {  minutos = minutos + 1; }
            else if (obj1 == reloj) { minutos2 = minutos2 + 1; }
            else if (obj2 == reloj) { minutos3 = minutos3 + 1;  }
            else if (obj3 == reloj) { minutos4 = minutos4 + 1;  }
            else if (obj4 == reloj) {  minutos5 = minutos5 + 1;  }
            else if (obj5 == reloj) {  minutos6 = minutos6 + 1;  }
            else if (obj6 == reloj) { minutos7 = minutos7 + 1;  }
            else if (obj7 == reloj) { minutos8 = minutos8 + 1; }
            else if (obj8 == reloj) { minutos9 = minutos9 + 1; }
            else if (obj9 == reloj) { minutos10 = minutos10 + 1; }
            else if (obj10 == reloj) { minutos11 = minutos11 + 1; }
            else if (obj11 == reloj) { minutos12 = minutos12 + 1; }
            else if (obj12 == reloj) { minutos13 = minutos13 + 1; }
            else if (obj13 == reloj) {  minutos14 = minutos14 + 1; }
            else if (obj14 == reloj) { minutos15 = minutos15 + 1; }
            else if (obj15 == reloj) {  minutos16 = minutos16 + 1; }
            else if (obj16 == reloj) { minutos17 = minutos17 + 1; }
            else if (obj17 == reloj) { minutos18 = minutos18 + 1;}
            else if (obj18 == reloj) { minutos19 = minutos19 + 1;  }
            else if (obj19 == reloj) {  minutos20 = minutos20 + 1; }

        }
        #endregion

        #region Evento click del boton Restar 1 minuto al cronometro seleccionado
        private void btn_1minmenos_Click(object sender, EventArgs e)
        {
            Int32 reloj = lsb_vuelo.SelectedIndex;
            //if (ancla <= reloj)
            //{
            //    reloj = reloj + borrados;
            //}

            if (obj0 == reloj) { if (minutos > 0) { minutos = minutos - 1; } }
            else if (obj1 == reloj) { if (minutos2 > 0) { minutos2 = minutos2 - 1; }  }
            else if (obj2 == reloj) { if (minutos3 > 0) { minutos3 = minutos3 - 1; }  }
            else if (obj3 == reloj) { if (minutos4 > 0) { minutos4 = minutos4 - 1; }  }
            else if (obj4 == reloj) { if (minutos5 > 0) { minutos5 = minutos5 - 1; }  }
            else if (obj5 == reloj) { if (minutos6 > 0) { minutos6 = minutos6 - 1; }  }
            else if (obj6 == reloj) { if (minutos7 > 0) { minutos7 = minutos7 - 1; }  }
            else if (obj7 == reloj) { if (minutos8 > 0) { minutos8 = minutos8 - 1; }  }
            else if (obj8 == reloj) { if (minutos9 > 0) { minutos9 = minutos9 - 1; }  }
            else if (obj9 == reloj) { if (minutos10 > 0) { minutos10 = minutos10 - 1; } }
            else if (obj10 == reloj) { if (minutos11 > 0) { minutos11 = minutos11 - 1; } }
            else if (obj11 == reloj) { if (minutos12 > 0) { minutos12 = minutos12 - 1; } }
            else if (obj12 == reloj) { if (minutos13 > 0) { minutos13 = minutos13 - 1; } }
            else if (obj13 == reloj) { if (minutos14 > 0) { minutos14 = minutos14 - 1; } }
            else if (obj14 == reloj) { if (minutos15 > 0) { minutos15 = minutos15 - 1; } }
            else if (obj15 == reloj) { if (minutos16 > 0) { minutos16 = minutos16 - 1; } }
            else if (obj16 == reloj) { if (minutos17 > 0) { minutos17 = minutos17 - 1; } }
            else if (obj17 == reloj) { if (minutos18 > 0) { minutos18 = minutos18 - 1; } }
            else if (obj18 == reloj) { if (minutos19 > 0) { minutos19 = minutos19 - 1; } }
            else if (obj19 == reloj) { if (minutos20 > 0) { minutos20 = minutos20 - 1; } }


            //switch (reloj)
            //{
            //    case 0:
            //        if (minutos > 0) { minutos = minutos - 1; }
            //        break;
            //    case 1:
            //        if (minutos2 > 0) { minutos2 = minutos2 - 1; }
            //        break;
            //    case 2:
            //        if (minutos3 > 0) { minutos3 = minutos3 - 1; }
            //        break;
            //    case 3:
            //        if (minutos4 > 0) { minutos4 = minutos4 - 1; }
            //        break;
            //    case 4:
            //        if (minutos5 > 0) { minutos5 = minutos5 - 1; }
            //        break;
            //    case 5:
            //        if (minutos6 > 0) { minutos6 = minutos6 - 1; }
            //        break;
            //    case 6:
            //        if (minutos7 > 0) { minutos7 = minutos7 - 1; }
            //        break;
            //    case 7:
            //        if (minutos8 > 0) { minutos8 = minutos8 - 1; }
            //        break;
            //    case 8:
            //        if (minutos9 > 0) { minutos9 = minutos9 - 1; }
            //        break;
            //    case 9:
            //        if (minutos10 > 0) { minutos10 = minutos10 - 1; }
            //        break;
            //    case 10:
            //        if (minutos11 > 0) { minutos11 = minutos11 - 1; }
            //        break;
            //    case 11:
            //        if (minutos12 > 0) { minutos12 = minutos12 - 1; }
            //        break;
            //    case 12:
            //        if (minutos13 > 0) { minutos13 = minutos13 - 1; }
            //        break;
            //    case 13:
            //        if (minutos14 > 0) { minutos14 = minutos14 - 1; }
            //        break;
            //    case 14:
            //        if (minutos15 > 0) { minutos15 = minutos15 - 1; }
            //        break;
            //    case 15:
            //        if (minutos16 > 0) { minutos16 = minutos16 - 1; }
            //        break;
            //    case 16:
            //        if (minutos17 > 0) { minutos17 = minutos17 - 1; }
            //        break;
            //    case 17:
            //        if (minutos18 > 0) { minutos18 = minutos18 - 1; }
            //        break;
            //    case 18:
            //        if (minutos19 > 0) { minutos19 = minutos19 - 1; }
            //        break;
            //    case 19:
            //        if (minutos20 > 0) { minutos20 = minutos20 - 1; }
            //        break;

            //}

        }
        #endregion 

        #region Evento click del boton Hold / On
        private void btn_holdgo_Click(object sender, EventArgs e)
        {

            Int32 reloj = lsb_vuelo.SelectedIndex;
            String ontimehold = "ON-TIME";


            if (obj0 == reloj) { if (estado) { estado = false; timer_cronometro.Start(); ontimehold = "ON-TIME"; } else { estado = true; timer_cronometro.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj1 == reloj) { if (estado2) { estado2 = false; timer_cronometro2.Start(); ontimehold = "ON-TIME"; } else { estado2 = true; timer_cronometro2.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj2 == reloj) { if (estado3) { estado3 = false; timer_cronometro3.Start(); ontimehold = "ON-TIME"; } else { estado3 = true; timer_cronometro3.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj3 == reloj) { if (estado4) { estado4 = false; timer_cronometro4.Start(); ontimehold = "ON-TIME"; } else { estado4 = true; timer_cronometro4.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj4 == reloj) { if (estado5) { estado5 = false; timer_cronometro5.Start(); ontimehold = "ON-TIME"; } else { estado5 = true; timer_cronometro5.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj5 == reloj) { if (estado6) { estado6 = false; timer_cronometro6.Start(); ontimehold = "ON-TIME"; } else { estado6 = true; timer_cronometro6.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj6 == reloj) { if (estado7) { estado7 = false; timer_cronometro7.Start(); ontimehold = "ON-TIME"; } else { estado7 = true; timer_cronometro7.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj7 == reloj) { if (estado8) { estado8 = false; timer_cronometro8.Start(); ontimehold = "ON-TIME"; } else { estado8 = true; timer_cronometro8.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj8 == reloj) { if (estado9) { estado9 = false; timer_cronometro9.Start(); ontimehold = "ON-TIME"; } else { estado9 = true; timer_cronometro9.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj9 == reloj) { if (estado10) { estado10 = false; timer_cronometro10.Start(); ontimehold = "ON-TIME"; } else { estado10 = true; timer_cronometro10.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj10 == reloj) { if (estado11) { estado11 = false; timer_cronometro11.Start(); ontimehold = "ON-TIME"; } else { estado11 = true; timer_cronometro11.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj11 == reloj) { if (estado12) { estado12 = false; timer_cronometro12.Start(); ontimehold = "ON-TIME"; } else { estado12 = true; timer_cronometro12.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj12 == reloj) { if (estado13) { estado13 = false; timer_cronometro13.Start(); ontimehold = "ON-TIME"; } else { estado13 = true; timer_cronometro13.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj13 == reloj) { if (estado14) { estado14 = false; timer_cronometro14.Start(); ontimehold = "ON-TIME"; } else { estado14 = true; timer_cronometro14.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj14 == reloj) { if (estado15) { estado15 = false; timer_cronometro15.Start(); ontimehold = "ON-TIME"; } else { estado15 = true; timer_cronometro15.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj15 == reloj) { if (estado16) { estado16 = false; timer_cronometro16.Start(); ontimehold = "ON-TIME"; } else { estado16 = true; timer_cronometro16.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj16 == reloj) { if (estado17) { estado17 = false; timer_cronometro17.Start(); ontimehold = "ON-TIME"; } else { estado17 = true; timer_cronometro17.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj17 == reloj) { if (estado18) { estado18 = false; timer_cronometro18.Start(); ontimehold = "ON-TIME"; } else { estado18 = true; timer_cronometro18.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj18 == reloj) { if (estado19) { estado19 = false; timer_cronometro19.Start(); ontimehold = "ON-TIME"; } else { estado19 = true; timer_cronometro19.Stop(); ontimehold = "ON-HOLD"; } }
            else if (obj19 == reloj) { if (estado20) { estado20 = false; timer_cronometro20.Start(); ontimehold = "ON-TIME"; } else { estado20 = true; timer_cronometro20.Stop(); ontimehold = "ON-HOLD"; } }

            if (monobj0 == reloj) { misglobales.ontime1 = ontimehold; }
            if (monobj1 == reloj) { misglobales.ontime2 = ontimehold; }
            if (monobj2 == reloj) { misglobales.ontime3 = ontimehold; }

    

        }
        #endregion

        #region Evento click del boton borrar
        private void btn_delete_Click(object sender, EventArgs e)
        {
            borrarcronometro(lsb_vuelo.SelectedIndex);
        }
        #endregion

        #region Evento delete en el grid
        private void dg_flights_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("are you sure delete this record: ?", "Warning", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                //Borrar
                String condicion = " IDVUELO = " + dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[0].Value.ToString();
                conexion.BorraRegistro(condicion, "TB_VUELOS");



            }
        }
        #endregion

        #region Evento click en el boton Start
        private void btn_start_Click(object sender, EventArgs e)
        {
            registroseleccionado = dg_flights.CurrentRow.Index;
            idvuelo = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[0].Value.ToString());
            numerovuelo = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[2].Value.ToString());
            matricula = dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[3].Value.ToString();
            estatus = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[15].Value.ToString());
            estatusd = dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[16].Value.ToString();
            oncall = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[19].Value.ToString());
            bool Autoriza = true;





            if (bgobj0 == registroseleccionado) { Autoriza = false;} 
            else if (bgobj1 == registroseleccionado) { Autoriza = false;}
            else if (bgobj2 == registroseleccionado) { Autoriza = false; }
            else if (bgobj3 == registroseleccionado) { Autoriza = false; }
            else if (bgobj4 == registroseleccionado) { Autoriza = false; }
            else if (bgobj5 == registroseleccionado) { Autoriza = false; }
            else if (bgobj6 == registroseleccionado) { Autoriza = false; }
            else if (bgobj7 == registroseleccionado) { Autoriza = false; }
            else if (bgobj8 == registroseleccionado) { Autoriza = false; }
            else if (bgobj9 == registroseleccionado) { Autoriza = false; }
            else if (bgobj10 == registroseleccionado) { Autoriza = false; }
            else if (bgobj11 == registroseleccionado) { Autoriza = false; }
            else if (bgobj12 == registroseleccionado) { Autoriza = false; }
            else if (bgobj13 == registroseleccionado) { Autoriza = false; }
            else if (bgobj14 == registroseleccionado) { Autoriza = false; }
            else if (bgobj15 == registroseleccionado) { Autoriza = false; }
            else if (bgobj16 == registroseleccionado) { Autoriza = false; }
            else if (bgobj17 == registroseleccionado) { Autoriza = false; }
            else if (bgobj18 == registroseleccionado) { Autoriza = false; }
            else if (bgobj19 == registroseleccionado) { Autoriza = false; }


            if (estatusd == "OPEN" & Autoriza == true)
            {
                dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[19].Value = 1;


                registrovuelo = Convert.ToString(horas) + ":" + Convert.ToString(minutos) + ":" + Convert.ToString(segundos) + " | (" + numerovuelo.ToString() + ") " + matricula.ToString();

                lsb_vuelo.Items.Add(registrovuelo);
                cronometros = lsb_vuelo.Items.Count - 1;
        

                if (_cronometro) 
                {
                    horas = 0; minutos = 20; segundos = 59; centesimas = 100; timer_cronometro.Start(); estado = false; _cronometro = false; obj0 = cronometros; bgobj0 = registroseleccionado;
                }
                else if (_cronometro2)
                {
                    horas2 = 0; minutos2 = 20; segundos2 = 59; centesimas2 = 100; timer_cronometro2.Start(); estado2 = false; _cronometro2 = false; obj1 = cronometros; bgobj1 = registroseleccionado;
                }
                else if (_cronometro3)
                {
                    horas3 = 0; minutos3 = 20; segundos3 = 59; centesimas3 = 100; timer_cronometro3.Start(); estado3 = false; _cronometro3 = false; obj2 = cronometros; bgobj2 = registroseleccionado;
                }
                else if (_cronometro4)
                {
                    horas4 = 0; minutos4 = 20; segundos4 = 59; centesimas4 = 100; timer_cronometro4.Start(); estado4 = false; _cronometro4 = false; obj3 = cronometros; bgobj3 = registroseleccionado;
                }
                else if (_cronometro5)
                {
                    horas5 = 0; minutos5 = 20; segundos5 = 59; centesimas5 = 100; timer_cronometro5.Start(); estado5 = false; _cronometro5 = false; obj4 = cronometros; bgobj4 = registroseleccionado;
                }
                else if (_cronometro6)
                {
                    horas6 = 0; minutos6 = 20; segundos6 = 59; centesimas6 = 100; timer_cronometro6.Start(); estado6 = false; _cronometro6 = false; obj5 = cronometros; bgobj5 = registroseleccionado;
                }
                else if (_cronometro7)
                {
                    horas7 = 0; minutos7 = 20; segundos7 = 59; centesimas7 = 100; timer_cronometro7.Start(); estado7 = false; _cronometro7 = false; obj6 = cronometros; bgobj6 = registroseleccionado;
                }
                else if (_cronometro8)
                {
                    horas8 = 0; minutos8 = 20; segundos8 = 59; centesimas8 = 100; timer_cronometro8.Start(); estado8 = false; _cronometro8 = false; obj7 = cronometros; bgobj7 = registroseleccionado;
                }
                else if (_cronometro9)
                {
                    horas9 = 0; minutos9 = 20; segundos9 = 59; centesimas9 = 100; timer_cronometro9.Start(); estado9 = false; _cronometro9 = false; obj8 = cronometros; bgobj8 = registroseleccionado;
                }
                else if (_cronometro10)
                {
                    horas10 = 0; minutos10 = 20; segundos10 = 59; centesimas10 = 100; timer_cronometro10.Start(); estado10 = false; _cronometro10 = false; obj9 = cronometros; bgobj9 = registroseleccionado;
                }
                else if (_cronometro11)
                {
                    horas11 = 0; minutos11 = 20; segundos11 = 59; centesimas11 = 100; timer_cronometro11.Start(); estado11 = false; _cronometro11 = false; obj10 = cronometros; bgobj10 = registroseleccionado;
                }
                else if (_cronometro12)
                {
                    horas12 = 0; minutos12 = 20; segundos12 = 59; centesimas12 = 100; timer_cronometro12.Start(); estado12 = false; _cronometro12 = false; obj11 = cronometros; bgobj11 = registroseleccionado;
                }
                else if (_cronometro13)
                {
                    horas13 = 0; minutos13 = 20; segundos13 = 59; centesimas13 = 100; timer_cronometro13.Start(); estado13 = false; _cronometro13 = false; obj12 = cronometros; bgobj12 = registroseleccionado;
                }
                else if (_cronometro14)
                {
                    horas14 = 0; minutos14 = 20; segundos14 = 59; centesimas14 = 100; timer_cronometro14.Start(); estado14 = false; _cronometro14 = false; obj13 = cronometros; bgobj13 = registroseleccionado;
                }
                else if (_cronometro15)
                {
                    horas15 = 0; minutos15 = 20; segundos15 = 59; centesimas15 = 100; timer_cronometro15.Start(); estado15 = false; _cronometro15 = false; obj14 = cronometros; bgobj14 = registroseleccionado;
                }
                else if (_cronometro16)
                {
                    horas16 = 0; minutos16 = 20; segundos16 = 59; centesimas16 = 100; timer_cronometro16.Start(); estado16 = false; _cronometro16 = false; obj15 = cronometros; bgobj15 = registroseleccionado;
                }
                else if (_cronometro17)
                {
                    horas17 = 0; minutos17 = 20; segundos17 = 59; centesimas17 = 100; timer_cronometro17.Start(); estado17 = false; _cronometro17 = false; obj16 = cronometros; bgobj16 = registroseleccionado;
                }
                else if (_cronometro18)
                {
                    horas18 = 0; minutos18 = 20; segundos18 = 59; centesimas18 = 100; timer_cronometro18.Start(); estado18 = false; _cronometro18 = false; obj17 = cronometros; bgobj17 = registroseleccionado;
                }
                else if (_cronometro19)
                {
                    horas19 = 0; minutos19 = 20; segundos19 = 59; centesimas19 = 100; timer_cronometro19.Start(); estado19 = false; _cronometro19 = false; obj18 = cronometros; bgobj18 = registroseleccionado;
                }
                else if (_cronometro20)
                {
                    horas20 = 0; minutos20 = 20; segundos20 = 59; centesimas20 = 100; timer_cronometro20.Start(); estado20 = false; _cronometro20 = false; obj19 = cronometros; bgobj19 = registroseleccionado;
                }



            }
            else
            {
                if (oncall == 1) { MessageBox.Show("Flight already oncall "); } else { MessageBox.Show("You need open the flight to start"); }
            }
        }
        #endregion

        #region Modificando cronometro de la lista
        private void ModificaCronometroLista(Int32 lbox, Int32 posicion)
        {
            //lsb_vuelo.Items[lbox] = cronometro + " | " + lsb_vuelo.Items[lbox].ToString().Substring(posicion, lsb_vuelo.Items[lbox].ToString().Length - posicion);
        }
        #endregion

        #region Evento timer cronometro
        private void timer_cronometro_Tick(object sender, EventArgs e)
        {

            String enturno = "";

            centesimas = centesimas - 14;
            if (centesimas <= -12)
            {
                centesimas = 99;
                segundos = segundos - 1;
                if (segundos == 0)
                {
                    segundos = 59;
                    minutos = minutos - 1;
                    if (minutos == 0)
                    {
                        minutos = 0;
                    }
                }
            }
            cronometro = Convert.ToString(horas) + ":" + Convert.ToString(minutos) + ":" + Convert.ToString(segundos);
            Int32 posicion = 10;
            if (segundos < 10 || minutos < 10)
            {
                posicion = 9;
            }

            if (segundos < 10 & minutos < 10)
            {
                posicion = 8;
            }
           // ModificaCronometroLista(_cronolista, posicion);
            lsb_vuelo.Items[obj0] = cronometro + " | " + lsb_vuelo.Items[obj0].ToString().Substring(posicion, lsb_vuelo.Items[obj0].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj0].ToString().Substring(posicion, lsb_vuelo.Items[obj0].ToString().Length - posicion);

            if (monobj0 == obj0)
            {
                misglobales.vuelo1min = minutos; misglobales.vuelo1seg = segundos; misglobales.vuelo1centesimas = centesimas;
            }
            if (monobj1 == obj0)
            {
                misglobales.vuelo2min = minutos; misglobales.vuelo2seg = segundos; misglobales.vuelo2centesimas = centesimas;
            }
            if (monobj2 == obj0)
            {
                misglobales.vuelo3min = minutos; misglobales.vuelo3seg = segundos; misglobales.vuelo3centesimas = centesimas;
            }



            if (minutos <= 4 & dg_flights.Rows[bgobj0].DefaultCellStyle.BackColor != Color.Salmon)
            {
                dg_flights.Rows[bgobj0].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj0) { misglobales.ontime1 = "ON-CALL";}
                if (monobj1 == obj0) { misglobales.ontime2 = "ON-CALL";}
                if (monobj2 == obj0) { misglobales.ontime3 = "ON-CALL";}

            }
            if (minutos >= 5 & dg_flights.Rows[bgobj0].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj0].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj0) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj0) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj0) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos <= 2)
            {
                dg_flights.Rows[bgobj0].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj0) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj0) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj0) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos < 1 & segundos < 2)
            {
                dg_flights.Rows[bgobj0].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj0].Cells[19].Value = 0;
                //timer_cronometro.Stop();
                borrarcronometro(obj0);
                //lsb_vuelo.Items.RemoveAt(obj0);
                //obj1 = obj1 - 1; obj2 = obj2 - 1; obj3 = obj3 - 1; obj4 = obj4 - 1; obj5 = obj5 - 1; obj6 = obj6 - 1; obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");

            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1+ "'" ;
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);

            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 2
        private void timer_cronometro2_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas2 = centesimas2 - 14;
            if (centesimas2 <= -12)
            {
                centesimas2 = 99;
                segundos2 = segundos2 - 1;
                if (segundos2 == 0)
                {
                    segundos2 = 59;
                    minutos2 = minutos2 - 1;
                    if (minutos2 == 0)
                    {
                        minutos2 = 0;
                    }
                }
            }
            cronometro2 = Convert.ToString(horas2) + ":" + Convert.ToString(minutos2) + ":" + Convert.ToString(segundos2);
            Int32 posicion = 10;
            if (segundos2 < 10 || minutos2 < 10)
            {
                    posicion = 9;
            }

            if (segundos2 < 10 & minutos2 < 10)
            {
                posicion = 8;
            }
            //ModificaCronometroLista(_cronolista2, posicion);
            lsb_vuelo.Items[obj1] = cronometro2 + " | " + lsb_vuelo.Items[obj1].ToString().Substring(posicion, lsb_vuelo.Items[obj1].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj1].ToString().Substring(posicion, lsb_vuelo.Items[obj1].ToString().Length - posicion);

            if (monobj0 == obj1)
            {
                misglobales.vuelo1min = minutos2; misglobales.vuelo1seg = segundos2; misglobales.vuelo1centesimas = centesimas2;
            }
            if (monobj1 == obj1)
            {
                misglobales.vuelo2min = minutos2; misglobales.vuelo2seg = segundos2; misglobales.vuelo2centesimas = centesimas2;
            }
            if (monobj2 == obj1)
            {
                misglobales.vuelo3min = minutos2; misglobales.vuelo3seg = segundos2; misglobales.vuelo3centesimas = centesimas2;
            }


            if (minutos2 <= 4 & dg_flights.Rows[bgobj1].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj1].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj1) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj1) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj1) { misglobales.ontime3 = "ON-CALL"; }

            }
            if (minutos2 >= 5 & dg_flights.Rows[bgobj1].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj1].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj1) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj1) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj1) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos2 <= 2)
            {
                dg_flights.Rows[bgobj1].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj1) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj1) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj1) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos2 < 1 & segundos2 < 2)
            {
                dg_flights.Rows[bgobj1].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj1].Cells[19].Value = 0;
                //timer_cronometro2.Stop();
                borrarcronometro(obj1);
                //lsb_vuelo.Items.RemoveAt(obj1);
                //obj2 = obj2 - 1; obj3 = obj3 - 1; obj4 = obj4 - 1; obj5 = obj5 - 1; obj6 = obj6 - 1; obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                // borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");

            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();


        }
        #endregion

        #region Evento timer del cronometro 3
        private void timer_cronometro3_Tick(object sender, EventArgs e)
        {
            String enturno = "";

            centesimas3 = centesimas3 - 14;
            if (centesimas3 <= -12)
            {
                centesimas3 = 99;
                segundos3 = segundos3 - 1;
                if (segundos3 == 0)
                {
                    segundos3 = 59;
                    minutos3 = minutos3 - 1;
                    if (minutos3 == 0)
                    {
                        minutos3 = 0;
                    }
                }
            }
            cronometro3 = Convert.ToString(horas3) + ":" + Convert.ToString(minutos3) + ":" + Convert.ToString(segundos3);
            Int32 posicion = 10;
            if (segundos3 < 10 || minutos3 < 10)
            {
                posicion = 9;
            }

            if (segundos3 < 10 & minutos3 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj2] = cronometro3 + " | " + lsb_vuelo.Items[obj2].ToString().Substring(posicion, lsb_vuelo.Items[obj2].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj2].ToString().Substring(posicion, lsb_vuelo.Items[obj2].ToString().Length - posicion);

            if (monobj0 == obj2)
            {
                misglobales.vuelo1min = minutos3; misglobales.vuelo1seg = segundos3; misglobales.vuelo1centesimas = centesimas3;
            }
            if (monobj1 == obj2)
            {
                misglobales.vuelo2min = minutos3; misglobales.vuelo2seg = segundos3; misglobales.vuelo2centesimas = centesimas3;
            }
            if (monobj2 == obj2)
            {
                misglobales.vuelo3min = minutos3; misglobales.vuelo3seg = segundos3; misglobales.vuelo3centesimas = centesimas3;
            }

            if (minutos3 <= 4 && dg_flights.Rows[bgobj2].DefaultCellStyle.BackColor == Color.White )
            {
                dg_flights.Rows[bgobj2].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj2) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj2) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj2) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos3 >= 5 && dg_flights.Rows[bgobj2].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj2].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj2) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj2) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj2) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos3 <= 2)
            {
                dg_flights.Rows[bgobj2].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj2) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj2) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj2) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos3 < 1 & segundos3 < 2)
            {
                dg_flights.Rows[bgobj2].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj2].Cells[19].Value = 0;
                //timer_cronometro3.Stop();
                borrarcronometro(obj2);
                //lsb_vuelo.Items.RemoveAt(obj2);
                //obj3 = obj3 - 1; obj4 = obj4 - 1; obj5 = obj5 - 1; obj6 = obj6 - 1; obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");

            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();


        }
        #endregion

        #region Evento timer del cronometro 4
        private void timer_cronometro4_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas4 = centesimas4 - 14;
            if (centesimas4 <= -12)
            {
                centesimas4 = 99;
                segundos4 = segundos4 - 1;
                if (segundos4 == 0)
                {
                    segundos4 = 59;
                    minutos4 = minutos4 - 1;
                    if (minutos4 == 0)
                    {
                        minutos4 = 0;
                    }
                }
            }
            cronometro4 = Convert.ToString(horas4) + ":" + Convert.ToString(minutos4) + ":" + Convert.ToString(segundos4);
            Int32 posicion = 10;
            if (segundos4 < 10 || minutos4 < 10)
            {
                posicion = 9;
            }

            if (segundos4 < 10 & minutos4 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj3] = cronometro4 + " | " + lsb_vuelo.Items[obj3].ToString().Substring(posicion, lsb_vuelo.Items[obj3].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj3].ToString().Substring(posicion, lsb_vuelo.Items[obj3].ToString().Length - posicion);

            if (monobj0 == obj3)
            {
                misglobales.vuelo1min = minutos4; misglobales.vuelo1seg = segundos4; misglobales.vuelo1centesimas = centesimas4;
            }
            if (monobj1 == obj3)
            {
                misglobales.vuelo2min = minutos4; misglobales.vuelo2seg = segundos4; misglobales.vuelo2centesimas = centesimas4;
            }
            if (monobj2 == obj3)
            {
                misglobales.vuelo3min = minutos4; misglobales.vuelo3seg = segundos4; misglobales.vuelo3centesimas = centesimas4;
            }

            if (minutos4 <= 4 && dg_flights.Rows[bgobj3].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj3].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj3) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj3) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj3) { misglobales.ontime3 = "ON-CALL"; }

            }
            if (minutos4 >= 5 && dg_flights.Rows[bgobj3].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj3].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj3) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj3) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj3) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos4 <= 2)
            {
                dg_flights.Rows[bgobj3].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj3) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj3) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj3) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos4 < 1 & segundos4 < 2)
            {
                dg_flights.Rows[bgobj3].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj3].Cells[19].Value = 0;
                //timer_cronometro4.Stop();
                borrarcronometro(obj3);
                //lsb_vuelo.Items.RemoveAt(obj3);
                //obj4 = obj4 - 1; obj5 = obj5 - 1; obj6 = obj6 - 1; obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");

            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();


        }
        #endregion

        #region Evento timer del cronometro 5
        private void timer_cronometro5_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas5 = centesimas5 - 14;
            if (centesimas5 <= -12)
            {
                centesimas5 = 99;
                segundos5 = segundos5 - 1;
                if (segundos5 == 0)
                {
                    segundos5 = 59;
                    minutos5 = minutos5 - 1;
                    if (minutos5 == 0)
                    {
                        minutos5 = 0;
                    }
                }
            }
            cronometro5 = Convert.ToString(horas5) + ":" + Convert.ToString(minutos5) + ":" + Convert.ToString(segundos5);
            Int32 posicion = 10;
            if (segundos5 < 10 || minutos5 < 10)
            {
                posicion = 9;
            }

            if (segundos5 < 10 & minutos5 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj4] = cronometro5 + " | " + lsb_vuelo.Items[obj4].ToString().Substring(posicion, lsb_vuelo.Items[obj4].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj4].ToString().Substring(posicion, lsb_vuelo.Items[obj4].ToString().Length - posicion);

            if (monobj0 == obj4)
            {
                misglobales.vuelo1min = minutos5; misglobales.vuelo1seg = segundos5; misglobales.vuelo1centesimas = centesimas5;
            }
            if (monobj1 == obj4)
            {
                misglobales.vuelo2min = minutos5; misglobales.vuelo2seg = segundos5; misglobales.vuelo2centesimas = centesimas5;
            }
            if (monobj2 == obj4)
            {
                misglobales.vuelo3min = minutos5; misglobales.vuelo3seg = segundos5; misglobales.vuelo3centesimas = centesimas5;
            }


            if (minutos5 <= 4 && dg_flights.Rows[bgobj4].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj4].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj4) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj4) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj4) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos5 >= 5 && dg_flights.Rows[bgobj4].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj4].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj4) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj4) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj4) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos5 <= 2)
            {
                dg_flights.Rows[bgobj4].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj4) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj4) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj4) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos5 < 1 & segundos5 < 2)
            {
                dg_flights.Rows[bgobj4].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj4].Cells[19].Value = 0;
                //timer_cronometro5.Stop();
                borrarcronometro(obj4);
                //lsb_vuelo.Items.RemoveAt(obj4);
                //obj5 = obj5 - 1; obj6 = obj6 - 1; obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");

            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();


        }
        #endregion

        #region Evento timer del cronometro 6
        private void timer_cronometro6_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas6 = centesimas6 - 14;
            if (centesimas6 <= -12)
            {
                centesimas6 = 99;
                segundos6 = segundos6 - 1;
                if (segundos6 == 0)
                {
                    segundos6 = 59;
                    minutos6 = minutos6 - 1;
                    if (minutos6 == 0)
                    {
                        minutos6 = 0;
                    }
                }
            }
            cronometro6 = Convert.ToString(horas6) + ":" + Convert.ToString(minutos6) + ":" + Convert.ToString(segundos6);
            Int32 posicion = 10;
            if (segundos6 < 10 || minutos6 < 10)
            {
                posicion = 9;
            }

            if (segundos6 < 10 & minutos6 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj5] = cronometro6 + " | " + lsb_vuelo.Items[obj5].ToString().Substring(posicion, lsb_vuelo.Items[obj5].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj5].ToString().Substring(posicion, lsb_vuelo.Items[obj5].ToString().Length - posicion);

            if (monobj0 == obj5)
            {
                misglobales.vuelo1min = minutos6; misglobales.vuelo1seg = segundos6; misglobales.vuelo1centesimas = centesimas6;
            }
            if (monobj1 == obj5)
            {
                misglobales.vuelo2min = minutos6; misglobales.vuelo2seg = segundos6; misglobales.vuelo2centesimas = centesimas6;
            }
            if (monobj2 == obj5)
            {
                misglobales.vuelo3min = minutos6; misglobales.vuelo3seg = segundos6; misglobales.vuelo3centesimas = centesimas6;
            }

            if (minutos6 <= 4 && dg_flights.Rows[bgobj5].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj5].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj5) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj5) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj5) { misglobales.ontime3 = "ON-CALL"; }

            }
            if (minutos6 >= 5 && dg_flights.Rows[bgobj5].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj5].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj5) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj5) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj5) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos6 <= 2)
            {
                dg_flights.Rows[bgobj5].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj5) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj5) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj5) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos6 < 1 & segundos6 < 2)
            {
                dg_flights.Rows[bgobj5].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj5].Cells[19].Value = 0;
                //timer_cronometro6.Stop();
                borrarcronometro(obj5);
                //lsb_vuelo.Items.RemoveAt(obj5);
                //obj6 = obj6 - 1; obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 7
        private void timer_cronometro7_Tick(object sender, EventArgs e)
        {
            String enturno = "";

            centesimas7 = centesimas7 - 14;
            if (centesimas7 <= -12)
            {
                centesimas7 = 99;
                segundos7 = segundos7 - 1;
                if (segundos7 == 0)
                {
                    segundos7 = 59;
                    minutos7 = minutos7 - 1;
                    if (minutos7 == 0)
                    {
                        minutos7 = 0;
                    }
                }
            }
            cronometro7 = Convert.ToString(horas7) + ":" + Convert.ToString(minutos7) + ":" + Convert.ToString(segundos7);
            Int32 posicion = 10;
            if (segundos7 < 10 || minutos7 < 10)
            {
                posicion = 9;
            }

            if (segundos7 < 10 & minutos7 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj6] = cronometro7 + " | " + lsb_vuelo.Items[obj6].ToString().Substring(posicion, lsb_vuelo.Items[obj6].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj6].ToString().Substring(posicion, lsb_vuelo.Items[obj6].ToString().Length - posicion);

            if (monobj0 == obj6)
            {
                misglobales.vuelo1min = minutos7; misglobales.vuelo1seg = segundos7; misglobales.vuelo1centesimas = centesimas7;
            }
            if (monobj1 == obj6)
            {
                misglobales.vuelo2min = minutos7; misglobales.vuelo2seg = segundos7; misglobales.vuelo2centesimas = centesimas7;
            }
            if (monobj2 == obj6)
            {
                misglobales.vuelo3min = minutos7; misglobales.vuelo3seg = segundos7; misglobales.vuelo3centesimas = centesimas7;
            }


            if (minutos7 <= 4 && dg_flights.Rows[bgobj6].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj6].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj6) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj6) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj6) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos7 >= 5 && dg_flights.Rows[bgobj6].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj6].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj6) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj6) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj6) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos7 <= 2)
            {
                dg_flights.Rows[bgobj6].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj6) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj6) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj6) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos7 < 1 & segundos7 < 2)
            {
                dg_flights.Rows[bgobj6].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj6].Cells[19].Value = 0;
                //timer_cronometro7.Stop();
                borrarcronometro(obj6);
                //lsb_vuelo.Items.RemoveAt(obj6);
                //obj7 = obj7 - 1; obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");
            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 8
        private void timer_cronometro8_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas8 = centesimas8 - 14;
            if (centesimas8 <= -12)
            {
                centesimas8 = 99;
                segundos8 = segundos8 - 1;
                if (segundos8 == 0)
                {
                    segundos8 = 59;
                    minutos8 = minutos8 - 1;
                    if (minutos8 == 0)
                    {
                        minutos8 = 0;
                    }
                }
            }
            cronometro8 = Convert.ToString(horas8) + ":" + Convert.ToString(minutos8) + ":" + Convert.ToString(segundos8);
            Int32 posicion = 10;
            if (segundos8 < 10 || minutos8 < 10)
            {
                posicion = 9;
            }

            if (segundos8 < 10 & minutos8 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj7] = cronometro8 + " | " + lsb_vuelo.Items[obj7].ToString().Substring(posicion, lsb_vuelo.Items[obj7].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj7].ToString().Substring(posicion, lsb_vuelo.Items[obj7].ToString().Length - posicion);

            if (monobj0 == obj7)
            {
                misglobales.vuelo1min = minutos8; misglobales.vuelo1seg = segundos8; misglobales.vuelo1centesimas = centesimas8;
            }
            if (monobj1 == obj7)
            {
                misglobales.vuelo2min = minutos8; misglobales.vuelo2seg = segundos8; misglobales.vuelo2centesimas = centesimas8;
            }
            if (monobj2 == obj7)
            {
                misglobales.vuelo3min = minutos8; misglobales.vuelo3seg = segundos8; misglobales.vuelo3centesimas = centesimas8;
            }


            if (minutos8 <= 4 && dg_flights.Rows[bgobj7].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj7].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj7) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj7) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj7) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos8 >= 5 && dg_flights.Rows[bgobj7].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj7].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj7) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj7) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj7) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos8 <= 2)
            {
                dg_flights.Rows[bgobj7].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj7) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj7) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj7) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos8 < 1 & segundos8 < 2)
            {
                dg_flights.Rows[bgobj7].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj7].Cells[19].Value = 0;
                //timer_cronometro8.Stop();
                borrarcronometro(obj7);
                //lsb_vuelo.Items.RemoveAt(obj7);
                //obj8 = obj8 - 1; obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();


        }
        #endregion

        #region Evento timer del cronometro 9
        private void timer_cronometro9_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas9 = centesimas9 - 14;
            if (centesimas9 <= -12)
            {
                centesimas9 = 99;
                segundos9 = segundos9 - 1;
                if (segundos9 == 0)
                {
                    segundos9 = 59;
                    minutos9 = minutos9 - 1;
                    if (minutos9 == 0)
                    {
                        minutos9 = 0;
                    }
                }
            }
            cronometro9 = Convert.ToString(horas9) + ":" + Convert.ToString(minutos9) + ":" + Convert.ToString(segundos9);
            Int32 posicion = 10;
            if (segundos9 < 10 || minutos9 < 10)
            {
                posicion = 9;
            }

            if (segundos9 < 10 & minutos9 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj8] = cronometro9 + " | " + lsb_vuelo.Items[obj8].ToString().Substring(posicion, lsb_vuelo.Items[obj8].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj8].ToString().Substring(posicion, lsb_vuelo.Items[obj8].ToString().Length - posicion);

            if (monobj0 == obj8)
            {
                misglobales.vuelo1min = minutos9; misglobales.vuelo1seg = segundos9; misglobales.vuelo1centesimas = centesimas9;
            }
            if (monobj1 == obj8)
            {
                misglobales.vuelo2min = minutos9; misglobales.vuelo2seg = segundos9; misglobales.vuelo2centesimas = centesimas9;
            }
            if (monobj2 == obj8)
            {
                misglobales.vuelo3min = minutos9; misglobales.vuelo3seg = segundos9; misglobales.vuelo3centesimas = centesimas9;
            }


            if (minutos9 <= 4 && dg_flights.Rows[bgobj8].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj8].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj8) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj8) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj8) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos9 >= 5 && dg_flights.Rows[bgobj8].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj8].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj8) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj8) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj8) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos9 <= 2)
            {
                dg_flights.Rows[bgobj8].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj8) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj8) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj8) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos9 < 1 & segundos9 < 2)
            {
                dg_flights.Rows[bgobj8].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj8].Cells[19].Value = 0;
                //timer_cronometro9.Stop();
                borrarcronometro(obj8);
                //lsb_vuelo.Items.RemoveAt(obj8);
                //obj9 = obj9 - 1; obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();


        }
        #endregion

        #region Evento timer del cronometro 10
        private void timer_cronometro10_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas10 = centesimas10 - 14;
            if (centesimas10 <= -12)
            {
                centesimas10 = 99;
                segundos10 = segundos10 - 1;
                if (segundos10 == 0)
                {
                    segundos10 = 59;
                    minutos10 = minutos10 - 1;
                    if (minutos10 == 0)
                    {
                        minutos10 = 0;
                    }
                }
            }
            cronometro10 = Convert.ToString(horas10) + ":" + Convert.ToString(minutos10) + ":" + Convert.ToString(segundos10);
            Int32 posicion = 10;
            if (segundos10 < 10 || minutos10 < 10)
            {
                posicion = 9;
            }

            if (segundos10 < 10 & minutos10 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj9] = cronometro10 + " | " + lsb_vuelo.Items[obj9].ToString().Substring(posicion, lsb_vuelo.Items[obj9].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj9].ToString().Substring(posicion, lsb_vuelo.Items[obj9].ToString().Length - posicion);


            if (monobj0 == obj9)
            {
                misglobales.vuelo1min = minutos10; misglobales.vuelo1seg = segundos10; misglobales.vuelo1centesimas = centesimas10;
            }
            if (monobj1 == obj9)
            {
                misglobales.vuelo2min = minutos10; misglobales.vuelo2seg = segundos10; misglobales.vuelo2centesimas = centesimas10;
            }
            if (monobj2 == obj9)
            {
                misglobales.vuelo3min = minutos10; misglobales.vuelo3seg = segundos10; misglobales.vuelo3centesimas = centesimas10;
            }

            if (minutos10 <= 4 && dg_flights.Rows[bgobj9].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj9].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj9) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj9) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj9) { misglobales.ontime3 = "ON-CALL"; }

            }
            if (minutos10 >= 5 && dg_flights.Rows[bgobj9].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj9].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj9) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj9) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj9) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos10 <= 2)
            {
                dg_flights.Rows[bgobj9].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj9) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj9) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj9) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos10 < 1 & segundos10 < 2)
            {
                dg_flights.Rows[bgobj9].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj9].Cells[19].Value = 0;
                //timer_cronometro10.Stop();
                borrarcronometro(obj9);
                //lsb_vuelo.Items.RemoveAt(obj9);
                //obj10 = obj10 - 1;
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");
            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 11
        private void timer_cronometro11_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas11 = centesimas11 - 14;
            if (centesimas11 <= -12)
            {
                centesimas11 = 99;
                segundos11 = segundos11 - 1;
                if (segundos11 == 0)
                {
                    segundos11 = 59;
                    minutos11 = minutos11 - 1;
                    if (minutos11 == 0)
                    {
                        minutos11 = 0;
                    }
                }
            }
            cronometro11 = Convert.ToString(horas11) + ":" + Convert.ToString(minutos11) + ":" + Convert.ToString(segundos11);
            Int32 posicion = 10;
            if (segundos11 < 10 || minutos11 < 10)
            {
                posicion = 9;
            }

            if (segundos11 < 10 & minutos11 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj10] = cronometro11 + " | " + lsb_vuelo.Items[obj10].ToString().Substring(posicion, lsb_vuelo.Items[obj10].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj10].ToString().Substring(posicion, lsb_vuelo.Items[obj10].ToString().Length - posicion);

            if (monobj0 == obj10)
            {
                misglobales.vuelo1min = minutos11; misglobales.vuelo1seg = segundos11; misglobales.vuelo1centesimas = centesimas11;
            }
            if (monobj1 == obj10)
            {
                misglobales.vuelo2min = minutos11; misglobales.vuelo2seg = segundos11; misglobales.vuelo2centesimas = centesimas11;
            }
            if (monobj2 == obj10)
            {
                misglobales.vuelo3min = minutos11; misglobales.vuelo3seg = segundos11; misglobales.vuelo3centesimas = centesimas11;
            }


            if (minutos11 <= 4 && dg_flights.Rows[bgobj10].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj10].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj10) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj10) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj10) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos11 >= 5 && dg_flights.Rows[bgobj10].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj10].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj10) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj10) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj10) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos11 <= 2)
            {
                dg_flights.Rows[bgobj10].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj10) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj10) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj10) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos11 < 1 & segundos11 < 2)
            {
                dg_flights.Rows[bgobj10].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj10].Cells[19].Value = 0;
                //timer_cronometro11.Stop();
                borrarcronometro(obj10);
                //lsb_vuelo.Items.RemoveAt(obj10);
                //obj11 = obj11 - 1; obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno + " is ready to leave");
            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer cronometro 12
        private void timer_cronometro12_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas12 = centesimas12 - 14;
            if (centesimas12 <= -12)
            {
                centesimas12 = 99;
                segundos12 = segundos12 - 1;
                if (segundos12 == 0)
                {
                    segundos12 = 59;
                    minutos12 = minutos12 - 1;
                    if (minutos12 == 0)
                    {
                        minutos12 = 0;
                    }
                }
            }
            cronometro12 = Convert.ToString(horas12) + ":" + Convert.ToString(minutos12) + ":" + Convert.ToString(segundos12);
            Int32 posicion = 10;
            if (segundos12 < 10 || minutos12 < 10)
            {
                posicion = 9;
            }

            if (segundos12 < 10 & minutos12 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj11] = cronometro12 + " | " + lsb_vuelo.Items[obj11].ToString().Substring(posicion, lsb_vuelo.Items[obj11].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj11].ToString().Substring(posicion, lsb_vuelo.Items[obj11].ToString().Length - posicion);

            if (monobj0 == obj11)
            {
                misglobales.vuelo1min = minutos12; misglobales.vuelo1seg = segundos12; misglobales.vuelo1centesimas = centesimas12;
            }
            if (monobj1 == obj11)
            {
                misglobales.vuelo2min = minutos12; misglobales.vuelo2seg = segundos12; misglobales.vuelo2centesimas = centesimas12;
            }
            if (monobj2 == obj11)
            {
                misglobales.vuelo3min = minutos12; misglobales.vuelo3seg = segundos12; misglobales.vuelo3centesimas = centesimas12;
            }


            if (minutos <= 4 && dg_flights.Rows[bgobj11].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj11].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj11) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj11) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj11) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos12 >= 5 && dg_flights.Rows[bgobj11].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj11].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj11) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj11) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj11) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos12 <= 2)
            {
                dg_flights.Rows[bgobj11].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj11) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj11) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj11) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos12 < 1 & segundos12 < 2)
            {
                dg_flights.Rows[bgobj11].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj11].Cells[19].Value = 0;
                //timer_cronometro12.Stop();
                borrarcronometro(obj11);
                //lsb_vuelo.Items.RemoveAt(obj11);
                //obj12 = obj12 - 1; obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");
   

            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();
        }
        #endregion

        #region Evento timer del cronometro 13
        private void timer_cronometro13_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas13 = centesimas13 - 14;
            if (centesimas13 <= -12)
            {
                centesimas13 = 99;
                segundos13 = segundos13 - 1;
                if (segundos13 == 0)
                {
                    segundos13 = 59;
                    minutos13 = minutos13 - 1;
                    if (minutos13 == 0)
                    {
                        minutos13 = 0;
                    }
                }
            }
            cronometro13 = Convert.ToString(horas13) + ":" + Convert.ToString(minutos13) + ":" + Convert.ToString(segundos13);
            Int32 posicion = 10;
            if (segundos13 < 10 || minutos13 < 10)
            {
                posicion = 9;
            }

            if (segundos13 < 10 & minutos13 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj12] = cronometro13 + " | " + lsb_vuelo.Items[obj12].ToString().Substring(posicion, lsb_vuelo.Items[obj12].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj12].ToString().Substring(posicion, lsb_vuelo.Items[obj12].ToString().Length - posicion);

            if (monobj0 == obj12)
            {
                misglobales.vuelo1min = minutos13; misglobales.vuelo1seg = segundos13; misglobales.vuelo1centesimas = centesimas13;
            }
            if (monobj1 == obj12)
            {
                misglobales.vuelo2min = minutos13; misglobales.vuelo2seg = segundos13; misglobales.vuelo2centesimas = centesimas13;
            }
            if (monobj2 == obj12)
            {
                misglobales.vuelo3min = minutos13; misglobales.vuelo3seg = segundos13; misglobales.vuelo3centesimas = centesimas13;
            }


            if (minutos13 <= 4 && dg_flights.Rows[bgobj12].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj12].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj12) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj12) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj12) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos13 >= 5 && dg_flights.Rows[bgobj12].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj12].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj12) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj12) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj12) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos13 <= 2)
            {
                dg_flights.Rows[bgobj12].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj12) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj12) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj12) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos13 < 1 & segundos13 < 2)
            {
                dg_flights.Rows[bgobj12].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj12].Cells[19].Value = 0;
                //timer_cronometro13.Stop();
                borrarcronometro(obj12);
                //lsb_vuelo.Items.RemoveAt(obj12);
                //obj13 = obj13 - 1; obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion 

        #region Evento timer del cronometro 14
        private void timer_cronometro14_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            centesimas14 = centesimas14 - 14;
            if (centesimas14 <= -12)
            {
                centesimas14 = 99;
                segundos14 = segundos14 - 1;
                if (segundos14 == 0)
                {
                    segundos14 = 59;
                    minutos14 = minutos14 - 1;
                    if (minutos14 == 0)
                    {
                        minutos14 = 0;
                    }
                }
            }
            cronometro14 = Convert.ToString(horas14) + ":" + Convert.ToString(minutos14) + ":" + Convert.ToString(segundos14);
            Int32 posicion = 10;
            if (segundos14 < 10 || minutos14 < 10)
            {
                posicion = 9;
            }

            if (segundos14 < 10 & minutos14 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj13] = cronometro14 + " | " + lsb_vuelo.Items[obj13].ToString().Substring(posicion, lsb_vuelo.Items[obj13].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj13].ToString().Substring(posicion, lsb_vuelo.Items[obj13].ToString().Length - posicion);

            if (monobj0 == obj13)
            {
                misglobales.vuelo1min = minutos14; misglobales.vuelo1seg = segundos14; misglobales.vuelo1centesimas = centesimas14;
            }
            if (monobj1 == obj13)
            {
                misglobales.vuelo2min = minutos14; misglobales.vuelo2seg = segundos14; misglobales.vuelo2centesimas = centesimas14;
            }
            if (monobj2 == obj13)
            {
                misglobales.vuelo3min = minutos14; misglobales.vuelo3seg = segundos14; misglobales.vuelo3centesimas = centesimas14;
            }


            if (minutos14 <= 4 && dg_flights.Rows[bgobj13].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj13].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj13) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj13) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj13) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos14 >= 5 && dg_flights.Rows[bgobj13].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj13].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj13) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj13) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj13) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos14 <= 2)
            {
                dg_flights.Rows[bgobj13].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj13) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj13) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj13) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos14 < 1 & segundos14 < 2)
            {
                dg_flights.Rows[bgobj13].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj13].Cells[19].Value = 0;
                //timer_cronometro14.Stop();
                borrarcronometro(obj13);
                //lsb_vuelo.Items.RemoveAt(obj13);
                //obj14 = obj14 - 1; obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");
            }


            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();
        }
        #endregion

        #region Evento timer del cronometro 15
        private void timer_cronometro15_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            if (centesimas15 <= -12)
            {
                centesimas15 = 99;
                segundos15 = segundos15 - 1;
                if (segundos15 == 0)
                {
                    segundos15 = 59;
                    minutos15 = minutos15 - 1;
                    if (minutos15 == 0)
                    {
                        minutos15 = 0;
                    }
                }
            }
            cronometro15 = Convert.ToString(horas15) + ":" + Convert.ToString(minutos15) + ":" + Convert.ToString(segundos15);
            Int32 posicion = 10;
            if (segundos15 < 10 || minutos15 < 10)
            {
                posicion = 9;
            }

            if (segundos15 < 10 & minutos15 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj14] = cronometro15 + " | " + lsb_vuelo.Items[obj14].ToString().Substring(posicion, lsb_vuelo.Items[obj14].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj14].ToString().Substring(posicion, lsb_vuelo.Items[obj14].ToString().Length - posicion);

            if (monobj0 == obj14)
            {
                misglobales.vuelo1min = minutos15; misglobales.vuelo1seg = segundos15; misglobales.vuelo1centesimas = centesimas15;
            }
            if (monobj1 == obj14)
            {
                misglobales.vuelo2min = minutos15; misglobales.vuelo2seg = segundos15; misglobales.vuelo2centesimas = centesimas15;
            }
            if (monobj2 == obj14)
            {
                misglobales.vuelo3min = minutos15; misglobales.vuelo3seg = segundos15; misglobales.vuelo3centesimas = centesimas15;
            }


            if (minutos15 <= 4 && dg_flights.Rows[bgobj14].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj14].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj14) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj14) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj14) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos15 >= 5 && dg_flights.Rows[bgobj14].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj14].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj14) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj14) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj14) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos15 <= 2)
            {
                dg_flights.Rows[bgobj14].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj14) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj14) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj14) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos15 < 1 & segundos15 < 2)
            {
                dg_flights.Rows[bgobj14].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj14].Cells[19].Value = 0;
                //timer_cronometro15.Stop();
                borrarcronometro(obj14);
                //lsb_vuelo.Items.RemoveAt(obj14);
                //obj15 = obj15 - 1; obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }


            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 16
        private void timer_cronometro16_Tick(object sender, EventArgs e)
        {
            String enturno = "";

            if (centesimas16 <= -12)
            {
                centesimas16 = 99;
                segundos16 = segundos16 - 1;
                if (segundos16 == 0)
                {
                    segundos16 = 59;
                    minutos16 = minutos16 - 1;
                    if (minutos16 == 0)
                    {
                        minutos16 = 0;
                    }
                }
            }
            cronometro16 = Convert.ToString(horas16) + ":" + Convert.ToString(minutos16) + ":" + Convert.ToString(segundos16);
            Int32 posicion = 10;
            if (segundos16 < 10 || minutos16 < 10)
            {
                posicion = 9;
            }

            if (segundos16 < 10 & minutos16 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj15] = cronometro16 + " | " + lsb_vuelo.Items[obj15].ToString().Substring(posicion, lsb_vuelo.Items[obj15].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj15].ToString().Substring(posicion, lsb_vuelo.Items[obj15].ToString().Length - posicion);

            if (monobj0 == obj15)
            {
                misglobales.vuelo1min = minutos16; misglobales.vuelo1seg = segundos16; misglobales.vuelo1centesimas = centesimas16;
            }
            if (monobj1 == obj15)
            {
                misglobales.vuelo2min = minutos16; misglobales.vuelo2seg = segundos16; misglobales.vuelo2centesimas = centesimas16;
            }
            if (monobj2 == obj15)
            {
                misglobales.vuelo3min = minutos16; misglobales.vuelo3seg = segundos16; misglobales.vuelo3centesimas = centesimas16;
            }


            if (minutos16 <= 4 && dg_flights.Rows[bgobj15].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj15].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj15) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj15) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj15) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos16 >= 5 && dg_flights.Rows[bgobj15].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj15].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj15) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj15) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj15) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos16 <= 2)
            {
                dg_flights.Rows[bgobj15].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj15) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj15) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj15) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos16 < 1 & segundos16 < 2)
            {
                dg_flights.Rows[bgobj15].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj15].Cells[19].Value = 0;
                //timer_cronometro16.Stop();
                borrarcronometro(obj15);
                //lsb_vuelo.Items.RemoveAt(obj15);
                //obj16 = obj16 - 1; obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer cronometro 17
        private void timer_cronometro17_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            if (centesimas17 <= -12)
            {
                centesimas17 = 99;
                segundos17 = segundos17 - 1;
                if (segundos17 == 0)
                {
                    segundos17 = 59;
                    minutos17 = minutos17 - 1;
                    if (minutos17 == 0)
                    {
                        minutos17 = 0;
                    }
                }
            }
            cronometro17 = Convert.ToString(horas17) + ":" + Convert.ToString(minutos17) + ":" + Convert.ToString(segundos17);
            Int32 posicion = 10;
            if (segundos17 < 10 || minutos17 < 10)
            {
                posicion = 9;
            }

            if (segundos17 < 10 & minutos17 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj16] = cronometro17 + " | " + lsb_vuelo.Items[obj16].ToString().Substring(posicion, lsb_vuelo.Items[obj16].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj16].ToString().Substring(posicion, lsb_vuelo.Items[obj16].ToString().Length - posicion);

            if (monobj0 == obj16)
            {
                misglobales.vuelo1min = minutos17; misglobales.vuelo1seg = segundos17; misglobales.vuelo1centesimas = centesimas17;
            }
            if (monobj1 == obj16)
            {
                misglobales.vuelo2min = minutos17; misglobales.vuelo2seg = segundos17; misglobales.vuelo2centesimas = centesimas17;
            }
            if (monobj2 == obj16)
            {
                misglobales.vuelo3min = minutos17; misglobales.vuelo3seg = segundos17; misglobales.vuelo3centesimas = centesimas17;
            }


            if (minutos17 <= 4 && dg_flights.Rows[bgobj16].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj16].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj16) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj16) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj16) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos17 >= 5 && dg_flights.Rows[bgobj16].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj16].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj16) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj16) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj16) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos17 <= 2)
            {
                dg_flights.Rows[bgobj16].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj16) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj16) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj16) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos17 < 1 & segundos17 < 2)
            {
                dg_flights.Rows[bgobj16].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj16].Cells[19].Value = 0;
                //timer_cronometro17.Stop();
                borrarcronometro(obj16);
                //lsb_vuelo.Items.RemoveAt(obj16);
                //obj17 = obj17 - 1; obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);

            Monitores.CloseDB();
        }
        #endregion

        #region Evento timer del cronometro 18
        private void timer_cronometro18_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            if (centesimas18 <= -12)
            {
                centesimas18 = 99;
                segundos18 = segundos18 - 1;
                if (segundos18 == 0)
                {
                    segundos18 = 59;
                    minutos18 = minutos18 - 1;
                    if (minutos18 == 0)
                    {
                        minutos18 = 0;
                    }
                }
            }
            cronometro18 = Convert.ToString(horas18) + ":" + Convert.ToString(minutos18) + ":" + Convert.ToString(segundos18);
            Int32 posicion = 10;
            if (segundos18 < 10 || minutos18 < 10)
            {
                posicion = 9;
            }

            if (segundos18 < 10 & minutos18 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj17] = cronometro18 + " | " + lsb_vuelo.Items[obj17].ToString().Substring(posicion, lsb_vuelo.Items[obj17].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj17].ToString().Substring(posicion, lsb_vuelo.Items[obj17].ToString().Length - posicion);

            if (monobj0 == obj17)
            {
                misglobales.vuelo1min = minutos18; misglobales.vuelo1seg = segundos18; misglobales.vuelo1centesimas = centesimas18;
            }
            if (monobj1 == obj17)
            {
                misglobales.vuelo2min = minutos18; misglobales.vuelo2seg = segundos18; misglobales.vuelo2centesimas = centesimas18;
            }
            if (monobj2 == obj17)
            {
                misglobales.vuelo3min = minutos18; misglobales.vuelo3seg = segundos18; misglobales.vuelo3centesimas = centesimas18;
            }


            if (minutos18 <= 4 && dg_flights.Rows[bgobj17].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj17].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj17) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj17) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj17) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos18 >= 5 && dg_flights.Rows[bgobj17].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj17].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj17) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj17) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj17) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos18 <= 2)
            {
                dg_flights.Rows[bgobj17].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj17) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj17) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj17) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos18 < 1 & segundos18 < 2)
            {
                dg_flights.Rows[bgobj17].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj17].Cells[19].Value = 0;
                //timer_cronometro18.Stop();
                borrarcronometro(obj17);
                //lsb_vuelo.Items.RemoveAt(obj17);
                //obj18 = obj18 - 1; obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");

            }


            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 19
        private void timer_cronometro19_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            if (centesimas19 <= -12)
            {
                centesimas19 = 99;
                segundos19 = segundos19 - 1;
                if (segundos19 == 0)
                {
                    segundos19 = 59;
                    minutos19 = minutos19 - 1;
                    if (minutos19 == 0)
                    {
                        minutos19 = 0;
                    }
                }
            }
            cronometro19 = Convert.ToString(horas19) + ":" + Convert.ToString(minutos19) + ":" + Convert.ToString(segundos19);
            Int32 posicion = 10;
            if (segundos19 < 10 || minutos19 < 10)
            {
                posicion = 9;
            }

            if (segundos19 < 10 & minutos19 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj18] = cronometro19 + " | " + lsb_vuelo.Items[obj18].ToString().Substring(posicion, lsb_vuelo.Items[obj18].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj18].ToString().Substring(posicion, lsb_vuelo.Items[obj18].ToString().Length - posicion);

            if (monobj0 == obj18)
            {
                misglobales.vuelo1min = minutos19; misglobales.vuelo1seg = segundos19; misglobales.vuelo1centesimas = centesimas19;
            }
            if (monobj1 == obj18)
            {
                misglobales.vuelo2min = minutos19; misglobales.vuelo2seg = segundos19; misglobales.vuelo2centesimas = centesimas19;
            }
            if (monobj2 == obj18)
            {
                misglobales.vuelo3min = minutos19; misglobales.vuelo3seg = segundos19; misglobales.vuelo3centesimas = centesimas19;
            }


            if (minutos19 <= 4 && dg_flights.Rows[bgobj18].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj18].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj18) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj18) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj18) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos19 >= 5 && dg_flights.Rows[bgobj18].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj18].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj18) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj18) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj18) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos19 <= 2)
            {
                dg_flights.Rows[bgobj18].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj18) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj18) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj18) { misglobales.ontime3 = "ON-BOARD"; }
            }

            if (minutos19 < 1 & segundos19 < 2)
            {
                dg_flights.Rows[bgobj18].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj18].Cells[19].Value = 0;
                //timer_cronometro19.Stop();
                borrarcronometro(obj18);
                //lsb_vuelo.Items.RemoveAt(obj18);
                //obj19 = obj19 - 1;
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");


            }

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);
            Monitores.CloseDB();

        }
        #endregion

        #region Evento timer del cronometro 20
        private void timer_cronometro20_Tick(object sender, EventArgs e)
        {
            String enturno = "";
            if (centesimas20 <= -12)
            {
                centesimas20 = 99;
                segundos20 = segundos20 - 1;
                if (segundos20 == 0)
                {
                    segundos20 = 59;
                    minutos20 = minutos20 - 1;
                    if (minutos20 == 0)
                    {
                        minutos20 = 0;
                    }
                }
            }
            cronometro20 = Convert.ToString(horas20) + ":" + Convert.ToString(minutos20) + ":" + Convert.ToString(segundos20);
            Int32 posicion = 10;
            if (segundos20 < 10 || minutos20 < 10)
            {
                posicion = 9;
            }

            if (segundos20 < 10 & minutos20 < 10)
            {
                posicion = 8;
            }
            lsb_vuelo.Items[obj19] = cronometro20 + " | " + lsb_vuelo.Items[obj19].ToString().Substring(posicion, lsb_vuelo.Items[obj19].ToString().Length - posicion);
            enturno = lsb_vuelo.Items[obj19].ToString().Substring(posicion, lsb_vuelo.Items[obj19].ToString().Length - posicion);

            if (monobj0 == obj19)
            {
                misglobales.vuelo1min = minutos20; misglobales.vuelo1seg = segundos20; misglobales.vuelo1centesimas = centesimas20;
            }
            if (monobj1 == obj19)
            {
                misglobales.vuelo2min = minutos20; misglobales.vuelo2seg = segundos20; misglobales.vuelo2centesimas = centesimas20;
            }
            if (monobj2 == obj19)
            {
                misglobales.vuelo3min = minutos20; misglobales.vuelo3seg = segundos20; misglobales.vuelo3centesimas = centesimas20;
            }



            if (minutos20 <= 4 && dg_flights.Rows[bgobj19].DefaultCellStyle.BackColor == Color.White)
            {
                dg_flights.Rows[bgobj19].DefaultCellStyle.BackColor = Color.Salmon;
                if (monobj0 == obj19) { misglobales.ontime1 = "ON-CALL"; }
                if (monobj1 == obj19) { misglobales.ontime2 = "ON-CALL"; }
                if (monobj2 == obj19) { misglobales.ontime3 = "ON-CALL"; }
            }
            if (minutos20 >= 5 && dg_flights.Rows[bgobj19].DefaultCellStyle.BackColor != Color.White)
            {
                dg_flights.Rows[bgobj19].DefaultCellStyle.BackColor = Color.White;
                if (monobj0 == obj19) { misglobales.ontime1 = "ON-TIME"; }
                if (monobj1 == obj19) { misglobales.ontime2 = "ON-TIME"; }
                if (monobj2 == obj19) { misglobales.ontime3 = "ON-TIME"; }
            }
            if (minutos20 <= 2)
            {
                dg_flights.Rows[bgobj19].DefaultCellStyle.BackColor = Color.Red;
                if (monobj0 == obj19) { misglobales.ontime1 = "ON-BOARD"; }
                if (monobj1 == obj19) { misglobales.ontime2 = "ON-BOARD"; }
                if (monobj2 == obj19) { misglobales.ontime3 = "ON-BOARD"; }
            }
            if (minutos20 < 1 & segundos20 < 2)
            {

                
                dg_flights.Rows[bgobj19].DefaultCellStyle.BackColor = Color.White;
                dg_flights.Rows[bgobj19].Cells[19].Value = 0;
                //timer_cronometro20.Stop();
                borrarcronometro(obj19);
                //lsb_vuelo.Items.RemoveAt(obj19);
                //borrados = borrados + 1;
                MessageBox.Show("Flight " + enturno.ToString() + " is ready to leave");
               

            }
            



            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo1min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo1seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo1centesimas + @" ,
                      ontime = '" + misglobales.ontime1 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo1;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo2min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo2seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo2centesimas + @" ,
                      ontime = '" + misglobales.ontime2 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo2;
            Monitores.UpdateTabla(campos, tabla, condicion);

            tabla = "dbo.tb_Monitor";
            campos = "vuelo_minuto = " + misglobales.vuelo3min + @" ,
                      vuelo_segundo =  " + misglobales.vuelo3seg + @" ,
                      vuelo_centesimas = " + misglobales.vuelo3centesimas + @" ,
                      ontime = '" + misglobales.ontime3 + "'";
            condicion = " where idusuario = " + misglobales.usuario_idusuario + " and idvuelo = " + misglobales.idvuelo3;
            Monitores.UpdateTabla(campos, tabla, condicion);

            Monitores.CloseDB();

        }
        #endregion

        #region Evento FormClose de Frm_manifiest
        private void Frm_Manifiest_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (lsb_vuelo.Items.Count >= 0)
            //{

            //    DialogResult resultado = MessageBox.Show("Are you sure to close manifest manager ?", "Warning", MessageBoxButtons.YesNo);
            //    if (resultado == DialogResult.Yes)
            //    {
            //        this.Close();
            //    }
            //    else
            //    {
            //        return;
            //    }
            
               
            //}


            Monitores.BorraRegistro("idusuario = " + misglobales.usuario_idusuario.ToString(), " dbo.tb_monitor ");


        }
        #endregion 

        #region EncendidoApagado
        private void EncendidoApagado()
        {
            if (onoff == 0)
            {
                onoff = 1;
                frm.Visible = true;
                frm.Show();
            }
            else
            {
                onoff = 0;
                frm.Visible = false;
            }
        }
        #endregion 


        #region Evento click del boton OnOff
        private void btn_onoff_Click(object sender, EventArgs e)
        {
            EncendidoApagado();
        }
        #endregion

        #region Evento Click del boton MonitorDelete
        private void btn_monitordelete_Click(object sender, EventArgs e)
        {
            Int32 borro = lb_monitor.SelectedIndex;

            if (lb_monitor.SelectedIndex >= 0)
            {
                lb_monitor.Items.RemoveAt(lb_monitor.SelectedIndex);
                if (borro == 0) { Monitores.BorraRegistro("idvuelo=" + misglobales.idvuelo1 + " and idusuario = " + misglobales.usuario_idusuario.ToString(), "dbo.tb_Monitor");  misglobales.ontime1 = "WAITING"; 
                    //monobj0 = 9999; 
                    misglobales.monidvuelo1 = "EMPTY FLIGHT"; misglobales.idvuelo1 = 0; }
                if (borro == 1) { Monitores.BorraRegistro("idvuelo=" + misglobales.idvuelo2 + " and idusuario = " + misglobales.usuario_idusuario.ToString(), "dbo.tb_Monitor"); misglobales.ontime2 = "WAITING"; 
                    //monobj1 = 9999;
                    misglobales.monidvuelo2 = "EMPTY FLIGHT"; misglobales.idvuelo2 = 0; }
                if (borro == 2) { Monitores.BorraRegistro("idvuelo=" + misglobales.idvuelo3 + " and idusuario = " + misglobales.usuario_idusuario.ToString(), "dbo.tb_Monitor"); misglobales.ontime3 = "WAITING"; 
                    //monobj2 = 9999;
                    misglobales.monidvuelo3 = "EMPTY FLIGHT"; misglobales.idvuelo3 = 0; }
                enmonitor -= 1;

            }

        }
        #endregion

        #region Evento Clik del boton monitor
        private void btn_monitor_Click(object sender, EventArgs e)
        {

            

            Int32 idvuelo = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[0].Value.ToString());
            Int32 numerovuelo = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[2].Value.ToString());
            String matricula = dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[3].Value.ToString();
            String monitoreando = matricula.ToString() +  "-" + numerovuelo.ToString() ;

            Int32 celdaseleccionada = dg_flights.CurrentRow.Index;

            Int32 elminuto=20, elsegundo=60, lacentesima=100, elobjeto=9999;

            if (enmonitor <= 2)
            {
                if (bgobj0 == celdaseleccionada) { elminuto = minutos; elsegundo = segundos; lacentesima = centesimas; elobjeto = obj0; }
                else if (bgobj1 == celdaseleccionada) { elminuto = minutos2; elsegundo = segundos2; lacentesima = centesimas2; elobjeto = obj1; }
                else if (bgobj2 == celdaseleccionada) { elminuto = minutos3; elsegundo = segundos3; lacentesima = centesimas3; elobjeto = obj2; }
                else if (bgobj3 == celdaseleccionada) { elminuto = minutos4; elsegundo = segundos4; lacentesima = centesimas4; elobjeto = obj3; }
                else if (bgobj4 == celdaseleccionada) { elminuto = minutos5; elsegundo = segundos5; lacentesima = centesimas5; elobjeto = obj4; }
                else if (bgobj5 == celdaseleccionada) { elminuto = minutos6; elsegundo = segundos6; lacentesima = centesimas6; elobjeto = obj5; }
                else if (bgobj6 == celdaseleccionada) { elminuto = minutos7; elsegundo = segundos7; lacentesima = centesimas7; elobjeto = obj6; }
                else if (bgobj7 == celdaseleccionada) { elminuto = minutos8; elsegundo = segundos8; lacentesima = centesimas8; elobjeto = obj7; }
                else if (bgobj8 == celdaseleccionada) { elminuto = minutos9; elsegundo = segundos9; lacentesima = centesimas9; elobjeto = obj8; }
                else if (bgobj9 == celdaseleccionada) { elminuto = minutos10; elsegundo = segundos10; lacentesima = centesimas10; elobjeto = obj9; }
                else if (bgobj10 == celdaseleccionada) { elminuto = minutos11; elsegundo = segundos11; lacentesima = centesimas11; elobjeto = obj10; }
                else if (bgobj11 == celdaseleccionada) { elminuto = minutos12; elsegundo = segundos12; lacentesima = centesimas12; elobjeto = obj11; }
                else if (bgobj12 == celdaseleccionada) { elminuto = minutos13; elsegundo = segundos13; lacentesima = centesimas13; elobjeto = obj12; }
                else if (bgobj13 == celdaseleccionada) { elminuto = minutos14; elsegundo = segundos14; lacentesima = centesimas14; elobjeto = obj13; }
                else if (bgobj14 == celdaseleccionada) { elminuto = minutos15; elsegundo = segundos15; lacentesima = centesimas15; elobjeto = obj14; }
                else if (bgobj15 == celdaseleccionada) { elminuto = minutos16; elsegundo = segundos16; lacentesima = centesimas16; elobjeto = obj15; }
                else if (bgobj16 == celdaseleccionada) { elminuto = minutos17; elsegundo = segundos17; lacentesima = centesimas17; elobjeto = obj16; }
                else if (bgobj17 == celdaseleccionada) { elminuto = minutos18; elsegundo = segundos18; lacentesima = centesimas18; elobjeto = obj17; }
                else if (bgobj18 == celdaseleccionada) { elminuto = minutos19; elsegundo = segundos19; lacentesima = centesimas19; elobjeto = obj18; }
                else if (bgobj19 == celdaseleccionada) { elminuto = minutos20; elsegundo = segundos20; lacentesima = centesimas20; elobjeto = obj19; }

                if (enmonitor == 0) 
                {
                    Monitores.BorraRegistro("idvuelo=" + idvuelo, "dbo.tb_Monitor");

                    misglobales.idvuelo1 = idvuelo; misglobales.desvuelo1 = matricula.ToString() + "-" + numerovuelo.ToString();
                    misglobales.vuelo1min = elminuto; misglobales.vuelo1seg = elsegundo; misglobales.vuelo1centesimas = lacentesima;
                    monobj0 = elobjeto; misglobales.ontime1 = "ON-TIME"; misglobales.monidvuelo1 = monitoreando;
                    Monitores.InsertTabla("idvuelo, descripcion_vuelo, vuelo_minuto, vuelo_segundo, vuelo_centesimas, monobj, monitor_idvuelo, ontime, idusuario", "dbo.tb_Monitor",
                    misglobales.idvuelo1.ToString() + ",'" + misglobales.desvuelo1 + "', " + misglobales.vuelo1min + ", " + misglobales.vuelo1seg + ", " + misglobales.vuelo1centesimas
                    + ", " + monobj0 + ", '" + misglobales.monidvuelo1 + "', '" + misglobales.ontime1 + "',"+ misglobales.usuario_idusuario.ToString() );

                }
                if (enmonitor == 1) 
                {
                    Monitores.BorraRegistro("idvuelo=" + idvuelo, "dbo.tb_Monitor");

                    misglobales.idvuelo2 = idvuelo; misglobales.desvuelo2 = matricula.ToString() + "-" + numerovuelo.ToString(); 
                    misglobales.vuelo2min = elminuto; misglobales.vuelo2seg = elsegundo; misglobales.vuelo2centesimas = lacentesima;
                    monobj1 = elobjeto; misglobales.ontime2 = "ON-TIME"; misglobales.monidvuelo2 = monitoreando;
                    Monitores.InsertTabla("idvuelo, descripcion_vuelo, vuelo_minuto, vuelo_segundo, vuelo_centesimas, monobj, monitor_idvuelo, ontime, idusuario", "dbo.tb_Monitor",
                    misglobales.idvuelo2.ToString() + ",'" + misglobales.desvuelo2 + "', " + misglobales.vuelo2min + ", " + misglobales.vuelo2seg + ", " + misglobales.vuelo2centesimas
                    + ", " + monobj1 + ", '" + misglobales.monidvuelo2 + "', '" + misglobales.ontime2 + "'," + misglobales.usuario_idusuario.ToString());

                    
                }
                if (enmonitor == 2) 
                {
                    Monitores.BorraRegistro("idvuelo=" + idvuelo, "dbo.tb_Monitor");

                    misglobales.idvuelo3 = idvuelo; misglobales.desvuelo3 = matricula.ToString() + "-" + numerovuelo.ToString(); 
                    misglobales.vuelo3min = elminuto; misglobales.vuelo3seg = elsegundo; misglobales.vuelo3centesimas = lacentesima;
                    monobj2 = elobjeto; misglobales.ontime3 = "ON-TIME"; misglobales.monidvuelo3 = monitoreando;
                    Monitores.InsertTabla("idvuelo, descripcion_vuelo, vuelo_minuto, vuelo_segundo, vuelo_centesimas, monobj, monitor_idvuelo, ontime, idusuario", "dbo.tb_Monitor",
                    misglobales.idvuelo3.ToString() + ",'" + misglobales.desvuelo3 + "', " + misglobales.vuelo3min + ", " + misglobales.vuelo3seg + ", " + misglobales.vuelo3centesimas
                    + ", " + monobj2 + ", '" + misglobales.monidvuelo3 + "', '" + misglobales.ontime3 + "'," + misglobales.usuario_idusuario.ToString());

                }

                lb_monitor.Items.Add(monitoreando);
                enmonitor += 1;
                Monitores.CloseDB();


            }
            else
            {
                MessageBox.Show("You can view only 3 flights on monitor");
                Monitores.CloseDB(); //MONITOREANDO DESDE BD
            }


        }
        #endregion

        #region Evento click al boton Exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (onoff == 1)
            {

                DialogResult resultado = MessageBox.Show("Flights on-time in the monitor and this will be close, Are you sure to close manifest manager ?", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    EncendidoApagado();
                    this.Close();
                }
                else
                {
                    EncendidoApagado();
                    return;
                }


            }
            else
            {
                this.Close();
            }
            
        }
        #endregion 


        #region Evento clik en una celda
        private void dg_flights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String estatusvuelo = dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[16].Value.ToString();

            if (estatusvuelo == "OPEN")
            {
                btn_1minmenos.Enabled = true;
                btn_1min.Enabled = true;
                btn_20.Enabled = true;
                btn_delete.Enabled = true;
                btn_holdgo.Enabled = true;
                btn_start.Enabled = true;
                misglobales.iniciovuelo = dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[2].Value.ToString();
                misglobales.id1 = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[0].Value.ToString());
                misglobales.numero_de_vuelo = Convert.ToInt32(dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[2].Value.ToString());
                registroseleccionado = dg_flights.CurrentRow.Index;
            }

        }
        #endregion


        #region evento tick del timer autoriza
        private void tmr_autoriza_Tick(object sender, EventArgs e)
        {
            if (misglobales._Autoriza == true)
            {
                if (misglobales._Login == 6)
                {
                    if (gp_filterdate.Enabled)
                    {
                        gp_filterdate.Enabled = false;
                    }
                    else
                    {
                        gp_filterdate.Enabled = true;
                    }
                    tmr_autoriza.Stop();
                }


            }
            else
            {
                if (misglobales._Login == 6) { gp_filterdate.Enabled = false; }

            }
        }
        #endregion



        private void btn_key_Click(object sender, EventArgs e)
        {
            Menus = new ConectaBD();
            misglobales._Login = 6;

             misglobales._Autoriza = false;

             if (misglobales._Autoriza == false)
             {

                 acceso _FrmLogin = new acceso();
                 tmr_autoriza.Start();
                 _FrmLogin.Show();


             }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            misglobales.FechaMovimiento = Convert.ToDateTime(dp_filterdate.Text);
            //System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-MX", false);
            //misglobales.FechaMovimiento = System.DateTime.ParseExact(dp_filterdate.Text, "yyyy-MM-dd", MiFp);

            inicializagridview();
        }

        private void dp_filterdate_ValueChanged(object sender, EventArgs e)
        {
            //System.IFormatProvider MiFp = new System.Globalization.CultureInfo("es-MX", false);
            //misglobales.FechaMovimiento = System.DateTime.ParseExact(dp_filterdate.Text, "yyyy-MM-dd", MiFp);
            misglobales.FechaMovimiento = Convert.ToDateTime(dp_filterdate.Text);

        }

        private void Frm_Manifiest_FormClosing(object sender, FormClosingEventArgs e)
        {
            // si tiene elementos la lista, npo permitir cerrar y avisar
            //if (onoff == 1)
            //{

            //    DialogResult resultado = MessageBox.Show("Flights on-time in the monitor and this will be close, Are you sure to close manifest manager ?", "Warning", MessageBoxButtons.YesNo);
            //    if (resultado == DialogResult.Yes)
            //    {
            //        EncendidoApagado();
            //    }
            //    else
            //    {
            //        EncendidoApagado();
            //        return;
            //    }

                
            //}
        }

    







    }
}
