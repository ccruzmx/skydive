using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_ManifiestJumpers : Form
    {

        #region Variables 

        ConectaBD conexion = new ConectaBD();
        Int32 IdStatus;
        DataSet dsjumper, dsbalancejump;
        DataSet dsjumptype;
        DataSet dsplane;
        DataSet dsinsturctores;
        string condicion, campos, sql, tabla;
        utilerias u = new utilerias();
        int capacity = 0;

        int _idjumper = 0;
        int _idvuelo = 0;

        Boolean PermiteCambioTipoSaltoEnManifiesto = false;
        Boolean TicketValido = false;
       
        #endregion

        #region constructor de la forma
        public Frm_ManifiestJumpers()
        {
            InitializeComponent();
        }
        #endregion

        #region Carga la lista de vuelos
        private void ControlBack()
        {
            
        }
        #endregion

        #region Evento closed de la forma
        private void Frm_ManifiestJumpers_FormClosed(object sender, FormClosedEventArgs e)
        {
            sql = @"  UPDATE tbv 
                          SET LOADED = (SELECT COUNT(*) FROM TB_MANIFIESTO tbm WHERE tbm.idvuelo = tbv.idvuelo)
                         FROM TB_VUELOS tbv  ";
            condicion = "";
            tabla = "TB_VUELOS";

            DataSet dscontadoresvuelo = conexion.ConsultaUniversal(sql, condicion, tabla);


            InicializaGrid();
            ControlBack();
            misglobales.id2 = 1;

        }
        #endregion

        #region Cargar campos de vuelo
        private void CargaCampos()
        {
            txb_idvuelo.Text = misglobales.id1.ToString();
            Lbl_FlightCode.Text = misglobales.id1.ToString();
            lbl_numerovuelo.Text = Convert.ToString(misglobales.numero_de_vuelo);

            string condicion = @" where VUELOS.idvuelo = " + txb_idvuelo.Text;

            string sql = @"SELECT VUELOS.IDVUELO, VUELOS.IDAERONAVE, AERONAVE.matricula AS MATRICULA, AERONAVE.codigo AS [PLANE CODE], AERONAVE.capacidadpersonas AS [CAPACIDAD PERSONAS], 
                                    AERONAVE.capacidadpeso AS [CAPACIDAD PESO], AERONAVE.altitud AS [PLANE ALTITUD], 
                                    VUELOS.IDPILOTO, PILOTO.nombre_piloto AS [NOMBRE PILOTO], PILOTO.paterno_piloto [PATERNO PILOTO], PILOTO.materno_piloto [MATERNO PILOTO], 
                                    PILOTO.licencia AS [LICENCIA PILOTO], 
                                    VUELOS.FECHAABREVUELO AS [FECHA APERTURA], VUELOS.FECHACIERREVUELO [FECHA CIERRE], 
                                    VUELOS.IDESTATUS, ESTATUS.descripcion AS [ESTATUS VUELO],
                                    VUELOS.IDUSUARIO, USUARIO.nombre  + ' ' + USUARIO.paterno  + ' ' + USUARIO.materno 
                            FROM dbo.TB_VUELOS VUELOS 
                            INNER JOIN dbo.CT_AERONAVE AERONAVE ON VUELOS.IDAERONAVE = AERONAVE.idaeronave
                            INNER JOIN dbo.CT_PILOTO PILOTO ON PILOTO.idpiloto = VUELOS.idpiloto
                            INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.idestatus = VUELOS.IDESTATUS
                            INNER JOIN dbo.CT_USUARIO USUARIO ON USUARIO.idusuario = VUELOS.IDUSUARIO " + condicion +
                          " ORDER BY VUELOS.IDESTATUS,  VUELOS.FECHAABREVUELO";
            dsplane = conexion.ConsultaUniversal(sql, "", "CT_AERONAVE");

            lbl_Piloto.Text =  dsplane.Tables[0].Rows[0].ItemArray[8].ToString() + " " + dsplane.Tables[0].Rows[0].ItemArray[9].ToString() + " " + dsplane.Tables[0].Rows[0].ItemArray[10].ToString();
            Lbl_matriculainfo.Text = dsplane.Tables[0].Rows[0].ItemArray[2].ToString();
            Lbl_capacitydetail.Text = dsplane.Tables[0].Rows[0].ItemArray[4].ToString();
            Lbl_openeddetail.Text = dsplane.Tables[0].Rows[0].ItemArray[12].ToString();
            Lbl_Closeddetail.Text = dsplane.Tables[0].Rows[0].ItemArray[13].ToString();
            txb_idstatusvuelo.Text = dsplane.Tables[0].Rows[0].ItemArray[14].ToString();

            txb_status.Enabled = true;

           IdStatus = Convert.ToInt32(dsplane.Tables[0].Rows[0].ItemArray[14].ToString());

            if (IdStatus == 6)
            { 
                //opened
                
                txb_status.BackColor = Color.Green;
                txb_status.ForeColor = Color.Yellow;


            }
            else if (IdStatus == 5)
            { 
               //closed

                txb_status.BackColor = Color.Red;
                txb_status.ForeColor = Color.White;


            }

            txb_status.Text = dsplane.Tables[0].Rows[0].ItemArray[15].ToString();
            txb_status.TextAlign = HorizontalAlignment.Center;

            sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance, j.Allow_Override_Padlock
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
            dsjumper = conexion.ConsultaUniversal(sql, "WHERE J.idjumper > 0 order by  J.NOMBRE", "CT_JUMPER"); //MODIFICAR EL CODIGO 1802 POR 1
            cmb_jumper.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_jumper.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NOMBRE");
            cmb_jumper.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumper.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumper.ValueMember = "NOMBRE";
            cmb_jumper.SelectedItem = null;
            PermiteCambioTipoSaltoEnManifiesto = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[8].ToString());

            sql = @"select idjumptype, jump_type from dbo.CT_JUMP_TYPE where idestatus = 1 order by orden";
            dsjumptype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
            cmb_jumptype.DataSource = dsjumptype.Tables[0].DefaultView;
            cmb_jumptype.AutoCompleteCustomSource = LoadAutoComplete(dsjumptype, "jump_type");
            cmb_jumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumptype.ValueMember = "jump_type";
            cmb_jumptype.SelectedItem = null;
            cmb_jumptype.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[3].ToString();



            sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance,J.Note
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode 
                     WHERE (idjumpertypecode IN ('EXPERIENCED', 'LOAD ORGANIZER')
                        OR Altitud IN ( 'Instructor AFF', 'Instructor Tandem', 'Camarografo', ''))
                       AND J.Note = '003-cuau'
                       AND J.Allow_PaidBy = 1
                     order by  J.NOMBRE ";
            dsinsturctores = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
            //lsb_instructores.DataSource = dsinsturctores;
            //lsb_instructores.DisplayMember = "NOMBRE";
            //lsb_instructores.ValueMember = "idjumper";

//            sql = @" SELECT count(tandemup.idtandemup) NUMJUMPERS FROM dbo.TB_TANDEMUP tandemup 
//                          WHERE ( YEAR(tandemup.reserved_date) = YEAR(GETDATE()) AND MONTH(tandemup.reserved_date) = MONTH(GETDATE()) AND DAY(tandemup.reserved_date) = DAY(GETDATE()) )";

            sql = @" SELECT count(tandemup.idtandemup) NUMJUMPERS FROM dbo.TB_TANDEMUP tandemup 
                          WHERE ( YEAR(tandemup.reserved_date) = YEAR('" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "') AND MONTH(tandemup.reserved_date) = MONTH('" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "') AND DAY(tandemup.reserved_date) = DAY('" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "') )";

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

            conexion.CloseDB();
            txb_ticket.Text = "";
            txb_ticket.Focus();

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

        #region Evento Load de la forma
        private void Frm_ManifiestJumpers_Load(object sender, EventArgs e)
        {
            timer_manjum.Start();
            if (misglobales.manifiestomin == 20 & misglobales.manifiestoseg == 60) { lbl_cronometro.Text = "00:00:00"; } else { tmr_manifiesto.Start(); }
            CargaCampos();
            InicializaGrid();
            txb_ticket.Focus();
        }
        #endregion

        #region Evento Timer Reloj
        private void timer_manjum_Tick(object sender, EventArgs e)
        {
            lbl_timer.Text = DateTime.Now.ToLongTimeString();
        }
        #endregion

        #region Evento Clik boton OpenClose
        private void btn_openclose_Click(object sender, EventArgs e)
        {

            string condicion;
            string campos = "";
            string tabla = "dbo.TB_VUELOS";

            if (IdStatus == 6)
            {
                //Opened to Closed


                txb_status.BackColor = Color.Red;
                txb_status.ForeColor = Color.White;
                txb_status.Text = "CLOSE";
                IdStatus = 5;
                txb_idstatusvuelo.Text = IdStatus.ToString();
                //Update status del vuelo
                
                campos = @" idestatus = 5, fechacierrevuelo = getdate() ";
                //campos = @" idestatus = 5, fechacierrevuelo = convert(varchar(10),'" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "',23) ";

                misglobales.ontime = 3;


            }
            else if (IdStatus == 5)
            {
                //Closed to Opened

                misglobales.ontime = 1;
                txb_status.BackColor = Color.Green;
                txb_status.ForeColor = Color.Yellow;
                txb_status.Text = "OPEN";
                IdStatus = 6;
                txb_idstatusvuelo.Text = IdStatus.ToString();
                //Update Status del vuelo
                Lbl_Closeddetail.Text = "";
                campos = @" idestatus = 6, fechacierrevuelo = null ";
            }


            condicion = " WHERE idvuelo = " + txb_idvuelo.Text;

            try
            {

                conexion.UpdateTabla(campos, tabla, condicion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try update the flight status " + ex.Message);
            }

            CargaCampos();

        }
        #endregion

        #region Evento clik al boton cerrar
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                misglobales.id2 = 1;
                misglobales.maifiestocentesimas = 0;
                misglobales.manifiestoseg = 60;
                misglobales.manifiestomin = 20;
                this.Close();
                ControlBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try exit this screen " + ex.Message);
            }
        }
        #endregion

        #region Metodo al seleccionar un Jumper
        private void JumperSeleccionado()
        {

            if (cmb_jumper.SelectedIndex >0)
            {
                string sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, Jt.jump_type, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance, Allow_Override_Padlock, j.balance_jump, jt.codey
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
                dsjumper = conexion.ConsultaUniversal(sql, " WHERE J.NOMBRE = '" + cmb_jumper.SelectedValue.ToString() + "'", "CT_JUMPER");

                if (Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[6].ToString()) == true)
                {
                    btn_paidby.Enabled = true;
                    btn_paidby.BackColor = Color.GreenYellow;
                    misglobales.QuienSaltaid = Convert.ToInt32(dsjumper.Tables[0].Rows[0].ItemArray[0].ToString());
                    misglobales.QuienSaltaname = dsjumper.Tables[0].Rows[0].ItemArray[2].ToString();

                }
                else
                {
                    btn_paidby.BackColor = Color.LightGray;
                    btn_paidby.Enabled = false;
                }





                if (Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[8].ToString()) == true)
                {
                    sql = @"
                              select jump_type as jumptypecode
                                from dbo.CT_JUMP_TYPE
                                where idestatus = 1
                                order by orden";
                    tabla = "CT_JUMP_TYPE";
                }
                else
                {
                    sql = @"SELECT distinct jumptypecode FROM dbo.TB_TICKETS_BALANCE " +
                           " where idestatus = 1 and codejumper = '" + dsjumper.Tables[0].Rows[0].ItemArray[1].ToString() + "' " +
                          @" union all
                        select idjumptypecode
                          from dbo.CT_JUMPER
                         where idestatus = 1 and codigo = '" + dsjumper.Tables[0].Rows[0].ItemArray[1].ToString() + "' ";
                    tabla = "TB_TICKETS_BALANCE";
                }

                
                       //" and idjumptypecode in(select jump_type from CT_JUMP_TYPE  where len(codey)>= 1) ";
                
                condicion = "";
                dsbalancejump = conexion.ConsultaUniversal(sql, condicion, tabla);

                cmb_jumptype.DataSource = dsbalancejump.Tables[0].DefaultView;
                cmb_jumptype.AutoCompleteCustomSource = LoadAutoComplete(dsbalancejump, "jumptypecode");
                cmb_jumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_jumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_jumptype.ValueMember = "jumptypecode";
                cmb_jumptype.SelectedItem = null;

                cmb_jumptype.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[3].ToString();
                txb_Altitud.Text = dsjumper.Tables[0].Rows[0].ItemArray[5].ToString();
                txb_balance.Text = dsjumper.Tables[0].Rows[0].ItemArray[9].ToString();
                //txb_balance.Text = txb_balance.Text;  //string.Format("{0:C}", Convert.ToDecimal(txb_balance.Text));
                PermiteCambioTipoSaltoEnManifiesto = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[8].ToString());
                //if (PermiteCambioTipoSaltoEnManifiesto == true)
                //{
                    cmb_jumptype.Enabled = true;
                //}
                conexion.CloseDB();
                btn_addjumper.Enabled = true;

            }

        }
        #endregion 

        #region Metodo al seleccionar un Jump Type
        private void JumTypeSeleccionado()
        {
            if (cmb_jumptype.SelectedIndex > 0)
            {

                string sql = @" select idjumptype, codigo, jump_type, Altitud from dbo.CT_JUMP_TYPE ";
                DataSet dsjumptype = conexion.ConsultaUniversal(sql, " where idestatus = 1 and jump_type = '" + cmb_jumptype.Text + "'", "CT_JUMP_TYPE");
                txb_Altitud.Text = dsjumptype.Tables[0].Rows[0].ItemArray[3].ToString();
                conexion.CloseDB();
            }
        

        }
        #endregion 

        #region Al seleccionar un Jumper
        private void cmb_jumper_SelectionChangeCommitted(object sender, EventArgs e)
        {

            JumperSeleccionado();

        }
        #endregion

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            sql = @"select * from tb_manifiesto ";

            try
            {
        
                ds = conexion.ConsultaUniversal(sql, condicion, "tb_manifiesto");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return "insert";
                }
                else
                {
                    return "update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try consult manifiesto" + ex.Message);
                return "fail";
            }

        }
        #endregion

        #region Inicializa Grid
        private void InicializaGrid()
        {
            condicion = @" WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.id1;
            dg_manifiesto.EnableHeadersVisualStyles = false;
            dg_manifiesto.DataSource = conexion.ConsultaManifiesto(condicion);  //getdata(fuente;
            capacity = conexion.ConsultaManifiesto(condicion).Rows.Count;
            dg_manifiesto.Columns[0].Width = 10; // IDMANIFIESTO
            dg_manifiesto.Columns[0].Visible = false;
            dg_manifiesto.Columns[1].Width = 10; // IDVUELO
            dg_manifiesto.Columns[1].Visible = false;
            dg_manifiesto.Columns[2].Width = 10; // idaeronave
            dg_manifiesto.Columns[2].Visible = false;
            dg_manifiesto.Columns[3].Width = 10; // matricula
            dg_manifiesto.Columns[3].Visible = false;
            dg_manifiesto.Columns[4].Width = 10; // IDJUMPER
            dg_manifiesto.Columns[4].Visible = false;
            dg_manifiesto.Columns[5].Width = 250; // JUMPER_NAME
            dg_manifiesto.Columns[6].Width = 150; // idjumptypecode

            dg_manifiesto.Columns[7].Width = 10; // IDTANDEM
            dg_manifiesto.Columns[7].Visible = false;

            dg_manifiesto.Columns[8].Width = 100; // Altitud
            dg_manifiesto.Columns[8].Visible = true;
            dg_manifiesto.Columns[9].Width = 150; // ticket
            dg_manifiesto.Columns[9].Visible = true;
            dg_manifiesto.Columns[10].Width = 200; // ticket
            dg_manifiesto.Columns[10].Visible = false;
            dg_manifiesto.Columns[11].Width = 100; // video
            dg_manifiesto.Columns[11].Visible = true;
            dg_manifiesto.Columns[12].Width = 100; // handvideo
            dg_manifiesto.Columns[12].Visible = true;

            dg_manifiesto.Columns[5].HeaderText = "JUMPER NAME";
            dg_manifiesto.Columns[6].HeaderText = "JUMP TYPE";
             dg_manifiesto.Columns[8].HeaderText = "ALTITUD";
             dg_manifiesto.Columns[9].HeaderText = "TICKET";
             dg_manifiesto.Columns[11].HeaderText = "VIDEO";
             dg_manifiesto.Columns[12].HeaderText = "HAND VIDEO";


            u.Formatodgv(dg_manifiesto);
            txb_capacity.Text = capacity.ToString();
            if (txb_capacity.Text == Lbl_capacitydetail.Text)
            {
                btn_addjumper.Enabled = false;
                btn_addreservation.Enabled = false;

            }
            //conexion.EXECSP(" sp_manifest_report");

        }
        #endregion



        #region Pinta renglones condicionados
        private void dg_manifiesto_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // VER151
            Font Negrita = new Font(dg_manifiesto.Font, FontStyle.Bold);
            Font Normal = new Font(dg_manifiesto.Font, FontStyle.Regular);

            if ((e.RowIndex) < (this.dg_manifiesto.Rows.Count))
            {

                DataGridViewRow gvr = this.dg_manifiesto.Rows[e.RowIndex];


                if (Convert.ToInt32(gvr.Cells[14].Value) == 1)
                {

                    gvr.DefaultCellStyle.Font = Negrita;
                    gvr.DefaultCellStyle.ForeColor = Color.Green;
                    gvr.DefaultCellStyle.BackColor = Color.Yellow;


                }

            }
        }
        #endregion




        #region Metodo MANIFIESTALO !!!
        private void Manifiestalo(String CodeJumper, Int32 _idjumper, Int32 Tickets, String CodeLeadger)
        {
            int differenceInDays= 0;

            tabla = "ct_jumper";
            sql = "select idjumper, codigo, nombre, ReserveRepackDate, USPA_Expires, Waiver_Expires FROM dbo.CT_JUMPER ";
            condicion = " Where codigo = '" + CodeJumper + "'";
            DataSet dsmensajeespecial = conexion.ConsultaUniversal(sql, condicion, tabla);

            String St_USPA_Expires = dsmensajeespecial.Tables[0].Rows[0].ItemArray[4].ToString();
            String St_Waiver_Expires = dsmensajeespecial.Tables[0].Rows[0].ItemArray[5].ToString();


            if (St_Waiver_Expires != "" )
            {
            // Difference in days, hours, and minutes.
            TimeSpan ts = DateTime.Now - Convert.ToDateTime( dsmensajeespecial.Tables[0].Rows[0].ItemArray[5].ToString());

            // Difference in days.
             differenceInDays = ts.Days;
            }


            if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now  ))
            {
                MessageBox.Show(" Your licence or Member has been expired ");
            }


            if ((St_Waiver_Expires == "") || (differenceInDays >= 365))
            {
                MessageBox.Show(" Your Waiver has been expired ");
            }



            tabla = "TB_LEDGER";
            sql = @" SELECT * 
                       FROM TB_LEDGER ";
            condicion = @" WHERE jumper_code = '"+CodeJumper + @"' " + 
                         " AND idmanifiesto = "+ misglobales.id1;
            
            DataSet dsidleadger = conexion.ConsultaUniversal(sql, condicion, tabla);
            Int32 idleadgervar;

            if (dsidleadger.Tables[0].Rows.Count > 0)
            {
                idleadgervar = Convert.ToInt32(dsidleadger.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                idleadgervar = 0;
            }

            if (_idjumper == 1)
            { condicion = @" where idvuelo = " + misglobales.id1 + " and 1=2"; }
            else
            { condicion = @" where idvuelo = " + misglobales.id1 + " and idjumper = " + _idjumper; }


            String InUp = InserUpdate(condicion);

            if (InUp == "insert")
            {

                //if (lsb_instructores.SelectedItem == null)
                //{
                //    leadger = "0";
                //}
                //else
                //{

                //    sql = @"select idjumper from CT_JUMPER where nombre = '" + lsb_instructores.SelectedItem.ToString() + "'";
                //    DataSet dsleadger = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
                //    leadger = dsleadger.Tables[0].Rows[0].ItemArray[0].ToString();

                //}

                // obtener el jump_type cmb_jumptype.text
                tabla = "CT_JUMP_TYPE";
                sql = @" select idjumptype, codigo, jump_type, price, Altitud from dbo.CT_JUMP_TYPE ";
                condicion = " WHERE jump_type = '" + cmb_jumptype.Text + "'";
                DataSet dsidjumptype = conexion.ConsultaUniversal(sql, condicion, tabla);

                // Descontar el boleto y actualizar balances
//                tabla = "TB_TICKETS_BALANCE";
//                sql = @"select top 1 id, idjumper, codejumper, nombre, folioticket, price, updatedate, idestatus
//                              from dbo.TB_TICKETS_BALANCE where nombre = '" + cmb_jumper.Text + "' and jumptypecode = '" + cmb_jumptype.Text + "'";
//                condicion = " AND idestatus = 1";
//                DataSet dsticket = conexion.ConsultaUniversal(sql, condicion, tabla);


                //Gravar manifiesto
                tabla = "tb_manifiesto";
                campos = "idvuelo, code, idjumper, idtandem, idleadger, idjumptype, reservefor, folioticket";
                string valores = misglobales.id1 + ",'" + Lbl_matriculainfo.Text + "-" + Lbl_FlightCode.Text + "'," + dsjumper.Tables[0].Rows[0].ItemArray[0] + ", 0," +
                       idleadgervar + ", " + dsidjumptype.Tables[0].Rows[0].ItemArray[0].ToString() + ", '" + txb_reservefor.Text + "','" + txb_ticket.Text + "'";

                try
                {
                    conexion.InsertTabla(campos, tabla, valores);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try insert into manifest " + ex.Message);

                }

                if (txb_ticket.Text != "")
                {
                    

                    //Update para colocar en cancelado el ticket
                    String tabla6 = "TB_TICKETS_BALANCE";
                    String campos6 = @" idestatus = 8 ";
                    String condicion6 = " WHERE codejumper = '" + CodeJumper + "' and folioticket = '" + txb_ticket.Text + "'";
                    try
                    {
                        conexion.UpdateTabla(campos6, tabla6, condicion6);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try update ticket, please contact system administrator" + ex.Message);
                    }
                }
                
                //Actualiza JUMPER
                String tabla5 = "CT_JUMPER";
                String campos5 = @" balance_jump = ( SELECT isnull(COUNT(folioticket), 0) FROM dbo.TB_TICKETS_BALANCE WHERE idestatus = 1 AND codejumper = '" + CodeJumper + "'), " +
                                  "  fecha_ultimo_salto = getdate(), " +
                                  " total_saltos =  total_saltos +1 ";


                String condicion5 = " WHERE CODIGO = '" + CodeJumper + "'";
                try
                {
                    conexion.UpdateTabla(campos5, tabla5, condicion5);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try update balance and balance jump, please contact system administrator" + ex.Message);
                }
             


            }
            else if (InUp == "update")
            {
                MessageBox.Show("Jumper already exist in the manifest");
            }

            conexion.CloseDB();

            InicializaGrid();
        }
        #endregion 


        #region Valida Excepciones en costo
        public Decimal JumperException(int idjumper, string jump_type_code)
        {

            tabla = "cT_jumper_exceptions";
            sql = "  select id, idjumper, jumper_code, idjumptype, jump_type_code, charge from cT_jumper_exceptions";
            condicion = " where idjumper = " + idjumper + " and jump_type_code = '" + jump_type_code  + "'  ";

            try
            {
                DataSet dsexcepcion = conexion.ConsultaUniversal(sql, condicion, tabla);

                if (dsexcepcion.Tables[0].Rows.Count > 0)
                {
                    // si hay excpeción en el precio
                    return Convert.ToDecimal(dsexcepcion.Tables[0].Rows[0].ItemArray[5].ToString());
                }
                else
                {

                    tabla = "CT_JUMP_TYPE";
                    sql = "select idjumptype, jump_type, price from CT_JUMP_TYPE ";
                    condicion = " where jump_type = '" + jump_type_code + "'";

                    try
                    {
                        DataSet dspreciolista = conexion.ConsultaUniversal(sql, condicion, tabla);

                        if (dspreciolista.Tables[0].Rows.Count > 0)
                        {
                            return Convert.ToDecimal(dspreciolista.Tables[0].Rows[0].ItemArray[2].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Warning not exist price for this jump type " + jump_type_code.ToString() + " please contact system administrator ");
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error extract price of Jump Type Catalog " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try find exceptcion, contact system administrator  " + ex.Message);
            }



            return 0;
        }
        #endregion 

        #region Valida o Pide elegir un ticket
        private void ValidaEscogeTicket(Int32 _idjumper)
        {
            //Entro a este método porque detecto que tiene tickets, ahora hay que validar que ticket uso o pedirle en un popup que lo escoja
            tabla = "TB_TICKETS_BALANCE";
            sql = " select * from dbo.TB_TICKETS_BALANCE ";
            condicion = " where idjumper = " + _idjumper + "  and  folioticket = '" + txb_ticket.Text + "'";
            DataSet dsvalidaticket = conexion.ConsultaUniversal(sql, condicion, tabla);

            if (dsvalidaticket.Tables[0].Rows.Count > 0)
            { 
                //el ticket que se capturo o muestra en pantalla es correcto y se tomara como usado

            }
            else 
            { 
                // Pidamos que escoja uno valido de los tickets que tiene
                misglobales.TicketActualizado = false;
                misglobales.NombreParaTicket = cmb_jumper.Text;
                tmr_ticket.Start();
                Frm_ElegirTicket TicketPopUp = new Frm_ElegirTicket();
                TicketPopUp.Show();

            }


        }
        #endregion 

        #region Agregar Jumper
        private void btn_addjumper_Click(object sender, EventArgs e)
        {
            Decimal balance;
            Decimal balancepesos, preciosalto;
            Boolean Todoeldiasaltar;
            Boolean SaltarSinSaldo;
            Boolean PermitePrimerSalto;
            String codey, _campo, chargetypedescription;
            int _idjumper;

            String CodeJumper;
            sql = @"SELECT J.idjumper,  J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance,  Debit_Padlock, All_Day_Jump_padlock, Allow_Override_Padlock,
                           convert(bit,Allow_FirstJump ), j.Balance_Jump, j.codigo, JT.codey, jt.price, jt.charge_type_description, jt.jump_type, j.uspa_expires, j.Waiver_Expires
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode where j.nombre = '" + cmb_jumper.Text + "' order by  J.NOMBRE";
            try
            {
                dsjumper = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try consult jumper " + ex.Message);
            }

            if (dsjumper.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(" Invalid Jumper  ");
                txb_ticket.Focus();
                txb_ticket.SelectAll();
                return;
            }

            // Validar la fecha de su licencia
            int differenceInDays = 0;
            String St_USPA_Expires = dsjumper.Tables[0].Rows[0].ItemArray[17].ToString();
            String St_Waiver_Expires = dsjumper.Tables[0].Rows[0].ItemArray[18].ToString();


            if (St_Waiver_Expires != "")
            {
                // Difference in days, hours, and minutes.
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(dsjumper.Tables[0].Rows[0].ItemArray[18].ToString());

                // Difference in days.
                differenceInDays = ts.Days;
            }


            if ((St_Waiver_Expires == "") || (differenceInDays >= 365))
            {
                MessageBox.Show(" Your Waiver has been expired !!!  ");
                return;
            }

            if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
            {
                MessageBox.Show(" Your licence has been expired !!!  CAN NOT manifest");
                return;

            }


            sql = @" SELECT ctj.idjumptype, ctj.jump_type, ctct.charge_type, ctj.charge_type_description,  ctj.CODEY 
                       FROM ct_jump_type ctj 
                      INNER JOIN CT_CHARGE_TYPE ctct 
                              ON ctj.idchargetype = ctct.idchargetype ";
            condicion = " WHERE jump_type = '" + cmb_jumptype.Text + "'";
            tabla = "ct_jump_type";

            DataSet dsjumptypecode = conexion.ConsultaUniversal(sql, condicion, tabla);

            String JumpTypeCode = cmb_jumptype.Text; // dsjumper.Tables[0].Rows[0].ItemArray[16].ToString();
            _idjumper = Convert.ToInt32( dsjumper.Tables[0].Rows[0].ItemArray[0]);
            //preciosalto= Convert.ToDecimal(dsjumper.Tables[0].Rows[0].ItemArray[14].ToString());
            //preciosalto= Convert.ToDecimal(dsjumper.Tables[0].Rows[0].ItemArray[14].ToString());
            if (_idjumper == misglobales.idJumperTandem) { _campo = "idtandem"; } else { _campo = "idjumper"; }

            if (u.SePuedeManifestar(_idjumper, _campo) == false)
            {
                MessageBox.Show(" Already exist in the manifest ");
                return;
            }


  


            // Vaslidar que el tipo de salto seleccionado para el jumper no exista en jump_excepcions, en caso de existir, ese se tomará como precio valido.
            preciosalto = JumperException(_idjumper, cmb_jumptype.Text);


            
            CodeJumper = dsjumper.Tables[0].Rows[0].ItemArray[12].ToString();
            // condicionar si tiene j.Balance suficiente o si tiene padlock activo
            if (dsjumper.Tables[0].Rows[0].ItemArray[11].ToString() == "") { balance = 0; }
            else
            { balance = Convert.ToDecimal(dsjumper.Tables[0].Rows[0].ItemArray[11].ToString()); }
            if (dsjumper.Tables[0].Rows[0].ItemArray[6].ToString() == "")
            {
                balancepesos = 0;
            }
            else
            {
                balancepesos = Convert.ToDecimal(dsjumper.Tables[0].Rows[0].ItemArray[6].ToString());
            }
            chargetypedescription = dsjumptypecode.Tables[0].Rows[0].ItemArray[3].ToString(); //dsjumper.Tables[0].Rows[0].ItemArray[15].ToString();
            Todoeldiasaltar = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[8].ToString());
            SaltarSinSaldo = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[7].ToString());
            PermiteCambioTipoSaltoEnManifiesto = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[9].ToString());
            PermitePrimerSalto = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[10].ToString());

            codey = dsjumper.Tables[0].Rows[0].ItemArray[13].ToString();

                if (balance <= 0 && SaltarSinSaldo == false  && balancepesos >= 0 && preciosalto > 0)
                {
                    MessageBox.Show("cannot be manifested, the balance of the jumper is insufficient.");
                }
                else
                {

                    tabla = "TB_LEDGER";
                    //sql = " select max(SUBSTRING(code, 1,len(idledger)))+1 as id from TB_LEDGER ";
                    sql = "select REPLACE( max(SUBSTRING(code, 1,len(idledger))), '-', '')+1 as id from TB_LEDGER ";
                    condicion = "";
                    DataSet dsledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                    String CodeLedger = dsledger.Tables[0].Rows[0].ItemArray[0].ToString() + "-MANFST";


                    //// Si es un instrucotor MANIFIESTALO!
                    //if (codey.Length > 0)
                    //{
                    //    //APLICARLE EL PAGO DEL SALTO
                    //    Manifiestalo(CodeJumper, _idjumper);
                    //    return;
                    //}

                    if (dsjumptypecode.Tables[0].Rows[0].ItemArray[4].ToString().Length >= 1)
                    {
                        u.ActividadInstructor("jumps_manifested", 1, Convert.ToInt32(dsjumper.Tables[0].Rows[0].ItemArray[0].ToString()), "+");
                    }


                    Decimal LeAlcanza = balancepesos * -1;

                    if (preciosalto <= 0)
                    {
                        misglobales.jumper_code = CodeJumper;
                        if (preciosalto <= 0) 
                        {
                            u.AplicaLedger(CodeLedger, CodeJumper, misglobales._Updatedate, chargetypedescription, preciosalto, JumpTypeCode, 0, "", 0, 0, "", misglobales.id1.ToString(), 0, "", dsjumper.Tables[0].Rows[0].ItemArray[1].ToString(), 0, 0, 0, 0, "", 0, 0, misglobales.oficina_id_oficina, "", misglobales.usuario_idusuario); 
                        }
                        misglobales.jumper_code = CodeJumper;
                        Manifiestalo(CodeJumper, _idjumper, 0, CodeLedger);
                    }
                    else  if (balance > 0 && TicketValido == true)
                    {
                        //Si tiene tickets,es necesario validar el campo ticket o pedir que lo rellene
                        ValidaEscogeTicket(_idjumper);
                        if (txb_ticket.Text != "")
                        {
                           
                            Manifiestalo(CodeJumper, _idjumper, 1, CodeLedger);
                        }

                        CargaCampos();
                        InicializaGrid();
                        return;
                    }  
                    else if (LeAlcanza >= preciosalto || SaltarSinSaldo == true)
                    {
                        DialogResult resultado = MessageBox.Show(" We will apply charge to your balance for this jump, we recomend to change your balance into tickets; apply charge?", "Information", MessageBoxButtons.YesNo);

                        if (resultado == DialogResult.Yes)
                        {

                            // realzar cargo al jump por el costo que origina este salto
                            misglobales.jumper_code = CodeJumper;
                            u.AplicaLedger(CodeLedger, CodeJumper, misglobales._Updatedate, chargetypedescription, preciosalto, JumpTypeCode, 0, "", 0, 0, "", misglobales.id1.ToString(), 0, "", dsjumper.Tables[0].Rows[0].ItemArray[1].ToString(), 0, 0, 0, 0, "", 0, 0, misglobales.oficina_id_oficina, "", misglobales.usuario_idusuario);
                            Manifiestalo(CodeJumper, _idjumper, 0, CodeLedger);

             
                        }
                        else
                        {
                            MessageBox.Show(" Operation canceled ");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Balance insuficient ");
                    }
                }
            
            CargaCampos();
            InicializaGrid();

        }
        #endregion

        #region Evento Tick del cronometro de vuelo
        private void tmr_manifiesto_Tick(object sender, EventArgs e)
        {
            misglobales.maifiestocentesimas = misglobales.maifiestocentesimas - 14;
            if (misglobales.maifiestocentesimas == -12)
            {
                misglobales.maifiestocentesimas = 100;
                misglobales.manifiestoseg = misglobales.manifiestoseg - 1;
                if (misglobales.manifiestoseg == 0)
                {
                    misglobales.manifiestoseg = 60;
                    misglobales.manifiestomin = misglobales.manifiestomin - 1;
                    if (misglobales.manifiestomin == 0)
                    {
                        misglobales.manifiestomin = 0;
                        
                    }
                }
            }
            lbl_cronometro.Text = "00:" + Convert.ToString(misglobales.manifiestomin) + ":" + Convert.ToString(misglobales.manifiestoseg);
            if (misglobales.manifiestomin <= 0 & misglobales.manifiestoseg <= 01) 
            { 
                tmr_manifiesto.Stop();
                lbl_cronometro.Text = "00:00:00";
            }
        }
        #endregion

        #region CellContentClick
        private void dg_manifiesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _idvuelo = Convert.ToInt32(dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[1].Value);
            _idjumper = Convert.ToInt32(dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value);
        }
        #endregion

        #region agrear reservacion
        private void btn_addreservation_Click(object sender, EventArgs e)
        {
            // Agregar reservaciones
           
            tabla = "tb_manifiesto";
            campos = "idvuelo, idjumper, idtandem, idleadger";
            string valores = misglobales.id1 + ", 1 ,0 ,0 ";
            conexion.InsertTabla(campos, tabla, valores);
            InicializaGrid();
            if (txb_capacity.Text == Lbl_capacitydetail.Text)
            {
                btn_addjumper.Enabled = false;
                btn_addreservation.Enabled = false;
            }
        }
        #endregion

        #region eliminar reservacion
        private void btn_deductreservation_Click(object sender, EventArgs e)
        {

            condicion = @" idmanifiesto IN( SELECT max(IDMANIFIESTO) FROM dbo.TB_MANIFIESTO WHERE idvuelo = " + misglobales.id1 + " AND idjumper = 1)";
            tabla = "tb_manifiesto";
            conexion.BorraRegistro(condicion, tabla);
            txb_capacity.Text = Convert.ToString(Convert.ToInt32(txb_capacity.Text) - 1);
            InicializaGrid();
            if (Convert.ToInt32(txb_capacity.Text) < Convert.ToInt32(Lbl_capacitydetail.Text))
            {
                btn_addjumper.Enabled = true;
                btn_addreservation.Enabled = true;
            }

        }
        #endregion

        #region Evento SelectedValueChanged
        private void cmb_jumper_SelectedValueChanged(object sender, EventArgs e)
        {
            JumperSeleccionado();
//            if (cmb_jumper.SelectedValue.ToString() != "System.Data.DataRowView")
//            {
//                string sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance
//                          FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
//                dsjumper = conexion.ConsultaUniversal(sql, " WHERE J.NOMBRE = '" + cmb_jumper.SelectedValue.ToString() + "'", "CT_JUMPER");

//                cmb_jumptype.SelectedItem = null;
//                cmb_jumptype.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[3].ToString();
//                txb_Altitud.Text = dsjumper.Tables[0].Rows[0].ItemArray[5].ToString();
//                txb_balance.Text = dsjumper.Tables[0].Rows[0].ItemArray[7].ToString();
//                txb_balance.Text = string.Format("{0:C}", Convert.ToDecimal(txb_balance.Text));
//                conexion.CloseDB();
//            }
//            else 
//            {
//                cmb_jumper.Text = "";
//            }
            //string solocambio = "";
            //solocambio = cmb_jumper.SelectedText;
            //if (solocambio != "")
            //{
            //    int valor = 0;
            //}

        }
        #endregion

        #region Evento click en el boton GoTo Transactions
        private void btn_gototransactions_Click(object sender, EventArgs e)
        {
            misglobales._Login = 1;
            misglobales._name = cmb_jumper.Text.ToString();
            misglobales._manifiesto =  Lbl_matriculainfo.Text + "-" + Lbl_FlightCode.Text;
            acceso _FrmLogin = new acceso();
            _FrmLogin.Show();
            //if (misglobales.credenciales)
            //{
            //    _FrmJumperTransaction.Show();
            //}
        }
        #endregion

        #region Evento click del btn_deletejumper
        private void btn_deletejumper_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                //Borrar
                string condicion = " IDVUELO = " + _idvuelo + " and idjumper = " + _idjumper;
                conexion.BorraRegistro(condicion, "TB_MANIFIESTO");
                txb_capacity.Text = Convert.ToString(Convert.ToInt32(txb_capacity.Text) - 1);
            }
        }
        #endregion

        #region evento click del btn_jumperledger
        private void btn_jumperledger_Click(object sender, EventArgs e)
        {
            //dg_flights.Rows[dg_flights.CurrentRow.Index].Cells[16].Value.ToString();
            string jumpername = dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[5].Value.ToString();

            if (jumpername != "")
            {
                misglobales._name = jumpername;
                Frm_JumperLeaderDetail JumperLederDetail = new Frm_JumperLeaderDetail();
                JumperLederDetail.Show();
            }
        }
        #endregion 

        #region Evento Enter del cmb_jumper
        private void cmb_jumper_Enter(object sender, EventArgs e)
        {
            JumperSeleccionado();
        }
        #endregion 

        #region Evento SelectedIndexChanged
        private void cmb_jumper_SelectedIndexChanged(object sender, EventArgs e)
        {
            JumperSeleccionado();
        }
        #endregion 

        #region Evento Activated del Frm_ManifestJumpers
        private void Frm_ManifiestJumpers_Activated(object sender, EventArgs e)
        {
            InicializaGrid();
        }
        #endregion 

        #region Evento click del btn_reserve
        private void btn_reserve_Click(object sender, EventArgs e)
        {
            int NumeroReservaciones = Convert.ToInt32(txb_reserve.Text);

            for (int i = 0; i < NumeroReservaciones; i++)
            {
                tabla = "tb_manifiesto";
                campos = "idvuelo, idjumper, idtandem, idleadger, idjumptype, reservefor";
                string valores = misglobales.id1 + ", 1 ,0 ,0, 64, '" + txb_reservefor.Text +"'";
                if (Convert.ToInt32(txb_capacity.Text) < Convert.ToInt32(Lbl_capacitydetail.Text))
                {
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                        txb_capacity.Text = Convert.ToString( Convert.ToInt32(txb_capacity.Text) + 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try reserve, please contact system administrator " + ex.Message);
                    }

                    if (txb_capacity.Text == Lbl_capacitydetail.Text)
                    {
                        btn_addjumper.Enabled = false;
                        btn_addreservation.Enabled = false;
                    }
                }

            }
            InicializaGrid();
        }
        #endregion 

        #region Evento Key Press del txb_reserve
        private void txb_reserve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
        }
        #endregion 

        #region Evento TabIndexChanged del cmb_jumper
        private void cmb_jumper_TabIndexChanged(object sender, EventArgs e)
        {
            JumperSeleccionado();
        }
        #endregion 

        #region Evento clik del btn_tandemtomanifest
        private void btn_tandemtomanifest_Click(object sender, EventArgs e)
        {
            DataSet dsreservados = new DataSet();
            sql = @"SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDJUMPER,  
                           ISNULL(UPPER(CT_JUMPER.nombre),'') + ' ' + ISNULL(CT_JUMPER.paterno, '') + ' ' + ISNULL(CT_JUMPER.materno, '') +  '-' + CONVERT(char(4),idmanifiesto) as JUMPER_NAME
                      FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
                     INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
                     INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
                      LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.idjumptypecode";
            condicion = "  WHERE TB_MANIFIESTO.IDVUELO = " + Lbl_FlightCode.Text;
            tabla = "TB_MANIFIESTO";
            dsreservados = conexion.ConsultaUniversal(sql, condicion, tabla);
            Int32 _reservados = dsreservados.Tables[0].Rows.Count;
            misglobales.matricula_info = Lbl_matriculainfo.Text;
            misglobales.jumper_from_tandemup = (Convert.ToInt32(Lbl_capacitydetail.Text) - Convert.ToInt32(txb_capacity.Text)) + _reservados;
            //RegistryFromTandemUp FrmRegistry = new RegistryFromTandemUp();
            Frm_PreManifest FrmRegistry = new Frm_PreManifest();
            FrmRegistry.MdiParent = MDISkyDiveCuautla.ActiveForm;
            FrmRegistry.WindowState = FormWindowState.Maximized;
            FrmRegistry.Show();


        }
        #endregion 

        #region Evento Text Changed del cmb_jumper
        private void cmb_jumper_TextChanged(object sender, EventArgs e)
        {
            JumperSeleccionado();
        }
        #endregion 

        #region Evento Selected Index Changed del cmb_jumptype
        private void cmb_jumptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
        }
        #endregion 

        #region Evento Selected Valued Changed
        private void cmb_jumptype_SelectedValueChanged(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
        }
        #endregion

        #region Evento tab index changed del cmb_jumptype
        private void cmb_jumptype_TabIndexChanged(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
        }
        #endregion 

        #region Evento Enter  del cmb_jumptype
        private void cmb_jumptype_Enter(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
        }
        #endregion 

        #region Evento click para manifestar desde el booktandem
        private void btn_booktandem_Click(object sender, EventArgs e)
        {
            tmr_premanifiesto.Start();
            misglobales._codetandemup = ",'" + Lbl_matriculainfo.Text + "-" + Lbl_FlightCode.Text + "',";
            Frm_TandemSelection _DisplayList = new Frm_TandemSelection();
            _DisplayList.MdiParent = MDISkyDiveCuautla.ActiveForm;
            _DisplayList.WindowState = FormWindowState.Maximized;
            _DisplayList.Show();
        }
        #endregion 

        #region evento click del button1 Que es para manifestar desde el premanifiesto
        private void button1_Click(object sender, EventArgs e)
        {
            misglobales.AgregandoPreManifiesto = 1;
            tmr_premanifiesto.Start();
            //misglobales.
            misglobales._codetandemup = ",'" + Lbl_matriculainfo.Text + "-" + Lbl_FlightCode.Text + "',";
            Frm_AddPreManifest _AddManifest = new Frm_AddPreManifest();
            _AddManifest.Show();

        }
        #endregion 

        #region Evento User Deleting row del gridview Manifiesto
        private void dg_manifiesto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Se valida que el manifiesto este abierto
            if (txb_status.Text == "CLOSED")
            {
                MessageBox.Show("Pleae OPEN before modify this manifest ");
            }
            else
            {


                // Confirmamos si esta seguro de eliminar el registro
                DialogResult resultado = MessageBox.Show("are you sure delete this record ? : (ID)" + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[10].Value.ToString() + " Name: " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[5].Value.ToString(), "Warning", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    //Borrar
                    tabla = "TB_LEDGER";
                    sql = " select idledger, code, jumper_code, codigo_jumptype from TB_LEDGER ";
                    //condicion = " where jumper_code in( select codigo from CT_JUMPER where idjumper = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value + " and codigo_jumptype = '" + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[6].Value.ToString() +
                    //    "') and  idledger = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[10].Value;
                    condicion = " where idledger = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[10].Value.ToString();

                    //IDENTIFICO SI REALIZÓ UN PAGO CON DINERO Y RECONOZCO EL JUMPER
                    DataSet dspagolana = conexion.ConsultaUniversal(sql, condicion, tabla);
                    if (dspagolana.Tables[0].Rows.Count > 0)
                    {
                        misglobales.jumper_code = dspagolana.Tables[0].Rows[0].ItemArray[2].ToString();
                    }

                    //IDENTIFICO SI SE MANIFESTO CON UN TICKET PARA REGRESARSELO
                    if (dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[9].Value.ToString().Length > 6)
                    {
                        tabla = "ct_jumper";
                        sql = "select idjumper, codigo, nombre  from ct_jumper ";
                        condicion = " where idjumper = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value;
                        DataSet dscodejumper = conexion.ConsultaUniversal(sql, condicion, tabla);
                        misglobales.jumper_code = dscodejumper.Tables[0].Rows[0].ItemArray[1].ToString();

                        // si se manifesto con ticket, hay que regrsarle su ticket
                        tabla = "TB_TICKETS_BALANCE";
                        campos = " idestatus = 1 ";
                        //condicion = " where idjumper = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value + " AND folioticket = '" + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[9].Value + "'";
                        condicion = " where folioticket = '" + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[9].Value + "'";
                        conexion.UpdateTabla(campos, tabla, condicion);

                        //SE LE DESCUENTA EL SALTO DESDE 
                        tabla = "CT_JUMPER";
                        campos = " balance_jump = balance_jump + 1, total_saltos =  total_saltos  -1 ";
                        condicion = " where idjumper =  " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value;
                        conexion.UpdateTabla(campos, tabla, condicion);


                    }
                    else if (dspagolana.Tables[0].Rows.Count > 0)
                    {
                        //Si pago con dinero ó se le pago dinero, se anula la transacción en el ledger
                        tabla = "TB_LEDGER";
                        condicion = " idledger = " + dspagolana.Tables[0].Rows[0].ItemArray[0].ToString();
                        conexion.BorraRegistro(condicion, tabla);

                        // 
                        tabla = "CT_JUMPER";
                        misglobales.jumper_code = dspagolana.Tables[0].Rows[0].ItemArray[2].ToString();
                        campos = " balance = " + u.Balance();
                        condicion = " where idjumper =  " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value;
                        conexion.UpdateTabla(campos, tabla, condicion);

                    }


                    // Lo borro del manifiesto
                    condicion = " idmanifiesto = " + Convert.ToInt32(dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[0].Value);
                    conexion.BorraRegistro(condicion, "TB_MANIFIESTO");

                    sql = " select codegroup from dbo.TB_MANIFIESTO_CERTIFICATE";
                    condicion = " where (idtandem = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value + ")  or (idjumper = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value + ")";
                    tabla = "TB_MANIFIESTO_CERTIFICATE";
                    DataSet dsborrocertificado = conexion.ConsultaUniversal(sql, condicion, tabla);

                    if (dsborrocertificado.Tables[0].Rows.Count > 0)
                    {
                        // Borramos al tandem de los certificados
                        condicion = " codegroup  = " + dsborrocertificado.Tables[0].Rows[0].ItemArray[0].ToString();
                        conexion.BorraRegistro(condicion, "TB_MANIFIESTO_CERTIFICATE");
                    }



                    //Si es tandemup lo regreso al tandembook
                    if (Convert.ToInt32(dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[7].Value) != 0)
                    {
                        Int32 idtandem = Convert.ToInt32(dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[7].Value);
                        tabla = "TB_TANDEMUP";
                        campos = @" jump_flag = 0, manifested = 0 ";
                        condicion = " WHERE idtandemup = " + idtandem;
                        try
                        {
                            conexion.UpdateTabla(campos, tabla, condicion);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error to try on flag jump for this tandemup, please contact system administrator " + ex.Message);
                        }
                    }


                    //si el tipo de salto es codey y estoy en la lista de isntructores del día 
                    tabla = "CT_JUMP_TYPE";
                    sql = "select idjumptype, jump_type, price, codey from CT_JUMP_TYPE ";
                    condicion = "where jump_type = '" + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[6].Value.ToString() + "'";
                    DataSet dscodey = conexion.ConsultaUniversal(sql, condicion, tabla);

                    tabla = "tb_instructors_activity";
                    sql = "select id, idjumper, registertime, sequence, name from dbo.tb_instructors_activity";
                    //condicion = " where CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) and idjumper = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value;
                    condicion = " where CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), '" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 23) and idjumper = " + dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value;
                    DataSet dsinstructor = conexion.ConsultaUniversal(sql, condicion, tabla);

                    if (dscodey.Tables[0].Rows[0].ItemArray[3].ToString().Length >= 1 && dsinstructor.Tables[0].Rows.Count > 0)
                    {
                        u.ActividadInstructor("jumps_manifested", 1, Convert.ToInt32(dg_manifiesto.Rows[dg_manifiesto.CurrentRow.Index].Cells[4].Value), "-");
                    }

                    txb_capacity.Text = Convert.ToString(Convert.ToInt32(txb_capacity.Text) - 1);
                }
            }
          
            
        }
        #endregion 

        #region UserDeletedRow
        private void dg_manifiesto_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            InicializaGrid();
        }
        #endregion

        #region TICK del tmr_premanifieto
        private void tmr_premanifiesto_Tick(object sender, EventArgs e)
        {
            if (misglobales.AgregandoPreManifiesto == 0)
            {
                InicializaGrid();
                tmr_premanifiesto.Stop();
            }
        }
        #endregion

        #region Timer actualiza ticket
        private void tmr_ticket_Tick(object sender, EventArgs e)
        {

            if (misglobales.TicketActualizado == true)
            {
                if (misglobales.TicketElegido == "")
                {
                    MessageBox.Show(" Ticket not selected ");
                    txb_ticket.Text = "";
                }
                else
                {
                    txb_ticket.Text = misglobales.TicketElegido.ToString();
                    
                }
                tmr_ticket.Stop();
            }

        }
        #endregion 

        #region Metodo al seleccionar un Jumper
        private void TicketSeleccionado()
        {

            


            string sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, tbalance.jumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance, Allow_Override_Padlock, 
                                  j.balance_jump, jt.codey, tbalance.folioticket, tbalance.price, tbalance.idestatus
                             FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode
                            INNER JOIN dbo.TB_TICKETS_BALANCE tbalance ON tbalance.idjumper = j.idjumper and tbalance.folioticket = '" + txb_ticket.Text + "' and tbalance.idestatus in (1,9)";
            DataSet dsjumperselected = conexion.ConsultaUniversal(sql, " ", "CT_JUMPER");
               // if (dsjumper.Tables[0].Rows.Count > 0)
            if (dsjumperselected.Tables[0].Rows.Count > 0)
                {

                    if (dsjumperselected.Tables[0].Rows[0].ItemArray[13].ToString() == "1" || dsjumperselected.Tables[0].Rows[0].ItemArray[13].ToString() == "9")
                    {
                        cmb_jumper.SelectedValue = dsjumperselected.Tables[0].Rows[0].ItemArray[2].ToString();


                        if (Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[8].ToString()) == true)
                        {
                            sql = @"select jump_type as jumptypecode
                                from dbo.CT_JUMP_TYPE
                                where idestatus in( 1,9)
                                order by orden";
                            tabla = "CT_JUMP_TYPE";
                        }
                        else
                        {
                            sql = @"SELECT distinct jumptypecode FROM dbo.TB_TICKETS_BALANCE " +
                                   " where idestatus in( 1,9) and codejumper = '" + dsjumper.Tables[0].Rows[0].ItemArray[1].ToString() + "' " +
                                  @" union all
                        select idjumptypecode
                          from dbo.CT_JUMPER
                         where idestatus in ( 1,9) and codigo = '" + dsjumper.Tables[0].Rows[0].ItemArray[1].ToString() + "' ";
                            tabla = "TB_TICKETS_BALANCE";
                        }


                        //" and idjumptypecode in(select jump_type from CT_JUMP_TYPE  where len(codey)>= 1) ";

                        condicion = "";
                        dsbalancejump = conexion.ConsultaUniversal(sql, condicion, tabla);

                        cmb_jumptype.DataSource = dsbalancejump.Tables[0].DefaultView;
                        cmb_jumptype.AutoCompleteCustomSource = LoadAutoComplete(dsbalancejump, "jumptypecode");
                        cmb_jumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cmb_jumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        cmb_jumptype.ValueMember = "jumptypecode";
                        cmb_jumptype.SelectedItem = null;

                        //cmb_jumptype.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[3].ToString();
                        cmb_jumptype.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[3].ToString();

                        txb_Altitud.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[5].ToString();
                        txb_balance.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[9].ToString();
                        txb_balance.Text = Convert.ToString(Convert.ToDecimal(txb_balance.Text));  //string.Format("{0:C}", Convert.ToDecimal(txb_balance.Text));
                        PermiteCambioTipoSaltoEnManifiesto = Convert.ToBoolean(dsjumperselected.Tables[0].Rows[0].ItemArray[8].ToString());
                        //if (PermiteCambioTipoSaltoEnManifiesto == true)
                        //{
                        cmb_jumptype.Enabled = true;
                        //}
                        conexion.CloseDB();
                        btn_addjumper.Enabled = true;
                        TicketValido = true;
                    }
                    else if (dsjumperselected.Tables[0].Rows[0].ItemArray[13].ToString() == "8")
                    {

                        tabla = "TB_MANIFIESTO";
                        sql = @" SELECT tbv.numerovuelo, cta.matricula, tbv.fechaabrevuelo, ctu.nombre + ' ' + ctu.paterno + ' '+ ctu.materno, cto.Nombre
                                      FROM TB_MANIFIESTO tbm 
                                     INNER JOIN TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo
                                     INNER JOIN CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
                                     INNER JOIN CT_USUARIO ctu on ctu.idusuario = tbv.idusuario
                                     INNER JOIN CT_OFICINA cto on cto.idoficina = tbv.idoficina ";

                        condicion = " WHERE folioticket = '" + txb_ticket.Text + "'";
                        DataSet dsticketusado = conexion.ConsultaUniversal(sql, condicion, tabla);
                        MessageBox.Show(" Ticket used in flight: " + dsticketusado.Tables[0].Rows[0].ItemArray[0].ToString() + " Plane: " + dsticketusado.Tables[0].Rows[0].ItemArray[1].ToString() +
                            " Date: " + dsticketusado.Tables[0].Rows[0].ItemArray[2].ToString() + " on " + dsticketusado.Tables[0].Rows[0].ItemArray[4].ToString() + " Dropzone, registred in the system for : " +
                             dsticketusado.Tables[0].Rows[0].ItemArray[3].ToString());
                    }
                    else
                    {
                        tabla = "TB_MANIFIESTO";
                        sql = @" Select tb.folioticket, cte.descripcion, tb.nota 
                                  From dbo.TB_TICKETS_BALANCE tb
                                  inner join CT_ESTATUS cte on cte.idestatus = tb.idestatus";
                        condicion = " WHERE folioticket = '" + txb_ticket.Text + "'";
                        DataSet dsticketusado = conexion.ConsultaUniversal(sql, condicion, tabla);
                        MessageBox.Show(" The ticket " + txb_ticket.Text + " has been " + dsticketusado.Tables[0].Rows[0].ItemArray[1].ToString());

                        txb_ticket.Focus();
                        txb_ticket.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show(" This ticket not exist, apply review protocol wit your manager");
                    txb_ticket.Text = "";
                    cmb_jumper.Focus();
                    TicketValido = false;
                    txb_ticket.Focus();
                    txb_ticket.SelectAll();
                }
         
        }
        #endregion 

        #region Evento pierde foco el campo CONFIRMA EL PWD
        private void txb_ticket_LostFocus(object sender, EventArgs e)
        {
            if (txb_ticket.Text != "")
            {
                TicketSeleccionado();
            }
        }
        #endregion 

        #region Evento keypress del textbox txb_ticket
        private void txb_ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (misglobales.oficina_oficina == "CUAUTLA")
            {
                if (txb_ticket.Text != "")
                {
                    if (Char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "\b") //permitir teclas de control como retroceso
                    {
                        if (txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "C" || txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "a" || txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "e")
                        {
                            txb_ticket.Text = txb_ticket.Text.Substring(0, 12);
                        }
                        btn_addjumper.Focus();
                        TicketSeleccionado();
                        btn_addjumper_Click(sender, e);

                    }
                }
            }
            else
            {
                if (Char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "\b") //permitir teclas de control como retroceso
                {
                    if (txb_ticket.Text.Substring(0, 1) == "C" || txb_ticket.Text.Substring(0, 1) == "a" || txb_ticket.Text.Substring(0, 1) == "e")
                    {
                        txb_ticket.Text = txb_ticket.Text.Substring(3, 12);
                    }
                    btn_addjumper.Focus();
                    TicketSeleccionado();
                    btn_addjumper_Click(sender, e);

                }
            }
        }
        #endregion 


        #region Evento click del boton btn_
        private void btn_reportmanifest_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Manifiesto RPT_manifest = new Reportes.Frm_Manifiesto();
            RPT_manifest.Show();

        }
        #endregion 


        #region Evento click del boton btn_paidby
        private void btn_paidby_Click(object sender, EventArgs e)
        {
            tmr_paid_by.Start();
            misglobales.PaidByMatricula =Lbl_matriculainfo.Text;
            misglobales.PaidByFlightCode = Lbl_FlightCode.Text;


            Operacion.Frm_PaidBy PagadoPor = new Operacion.Frm_PaidBy();
            CargaCampos();
            PagadoPor.Show();
            

        }
        #endregion


        private void tmr_paidby(object sender, EventArgs e)
        {
            if (misglobales.ListoPaidBy == 1)
            {
                InicializaGrid();
                tmr_paid_by.Stop();
                misglobales.ListoPaidBy = 0;
            }
        }

        private void txb_ticket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                //...
                e.SuppressKeyPress = true;
            }
        }



    }
}
