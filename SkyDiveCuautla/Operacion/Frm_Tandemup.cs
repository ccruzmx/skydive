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
    public partial class Frm_Tandemup : Form
    {

        #region Zona de Variables
            ConectaBD Menus;
            private System.Reflection.Assembly Ensamblado;
            ConectaBD conexion = new ConectaBD();
            utilerias u = new utilerias();
            string condicion, campos, sql, tabla;
            int _release = 0;
            int _videorent = 0;
            string valores;
            Boolean _leejumper = false;
            int _idtandemup = 0;
            decimal _aditional_services = 0;
            DataSet CostosAdicionales, CostosAdicionalesAutorizados;
            Int32 DioClickGrid = 0;
            Int32 EsGold = 0;
            String strPrinterName = "BIXOLON SLP-T400";
            Int32 TandemEditado = 0;
            DataSet ConsultaEdicion;
            ConectaBD Permisos = new ConectaBD();
            Boolean EstaManifestado = false;
            Boolean CamposEnedicion = false;
        #endregion

        #region Constructor del Frm_Tandemup
        public Frm_Tandemup()
        {
            InitializeComponent();
        }
        #endregion

        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview()
        {
            conexion.UpdateTabla("tandemheight = 0", "TB_TANDEMUP", " WHERE tandemheight is null ");

            condicion = @" WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  ORDER BY convert(int,tandemup.SEQUENCE) asc ";
            misglobales.TandemSelection = 0;
            dg_tandemup.EnableHeadersVisualStyles = false;
            dg_tandemup.DataSource = conexion.ConsultaTandemup(condicion);  //getdata(fuente;
            dg_tandemup.Columns[0].Width = 25; //IDTANDEMUP
            dg_tandemup.Columns[0].Visible = false;
            dg_tandemup.Columns[1].Width = 40; //SEQUENCE
            dg_tandemup.Columns[1].Visible = true;
            dg_tandemup.Columns[2].Width = 65; //REGISTER TIME
            dg_tandemup.Columns[2].Visible = true;
            dg_tandemup.Columns[3].Width = 80; //NAME
            dg_tandemup.Columns[3].Visible = true;
            dg_tandemup.Columns[4].Width = 80; //LAST NAME
            dg_tandemup.Columns[4].Visible = true;
            dg_tandemup.Columns[5].Width = 120; //REFERENCED BY
            dg_tandemup.Columns[5].Visible = true;
            dg_tandemup.Columns[6].Width = 80; //JUMP TYPE
            dg_tandemup.Columns[6].Visible = true;

            dg_tandemup.Columns[7].Width = 50; //TANDEMWEIGHT
            dg_tandemup.Columns[7].Visible = true;
            dg_tandemup.Columns[8].Width = 90; //TANDEMOVENWEIGHT
            dg_tandemup.Columns[8].Visible = true;
            dg_tandemup.Columns[9].Width = 50; //TANDEMHEIGHT
            dg_tandemup.Columns[9].Visible = true;
            dg_tandemup.Columns[10].Width = 45; //VIDEO
            dg_tandemup.Columns[10].Visible = true;
            dg_tandemup.Columns[11].Width = 45; //HAND VIDEO
            dg_tandemup.Columns[11].Visible = true;
            dg_tandemup.Columns[12].Width = 45; //VIDEO RENT
            dg_tandemup.Columns[12].Visible = true;

            dg_tandemup.Columns[13].Width = 70; //PRICEJUMP
            dg_tandemup.Columns[13].Visible = true;
            dg_tandemup.Columns[14].Width = 70; //PRICEVIDEO
            dg_tandemup.Columns[14].Visible = true;
            dg_tandemup.Columns[15].Width = 70; //PRICEHANDVIDEO
            dg_tandemup.Columns[15].Visible = true;
            dg_tandemup.Columns[16].Width = 70; //CHARGE
            dg_tandemup.Columns[16].Visible = true;

            dg_tandemup.Columns[17].Width = 70; //PAYMANT
            dg_tandemup.Columns[17].Visible = true;//PAYMANT
            
            dg_tandemup.Columns[18].Width = 50; //RELEASE
            dg_tandemup.Columns[18].Visible = true;//RELEASE

            dg_tandemup.Columns[19].Width = 70; //RESERVED_DATE
            dg_tandemup.Columns[19].Visible = true;//RESERVED_DATE

            dg_tandemup.Columns[20].Width = 150; //EMAIL
            dg_tandemup.Columns[20].Visible = true;//EMAIL

            dg_tandemup.Columns[21].Width = 60; //JUMP_FLAG
            dg_tandemup.Columns[21].Visible = true;//JUMP_FLAG

            dg_tandemup.Columns[22].Visible = false; //ID_PROSPECT
            dg_tandemup.Columns[23].Width = 70; //CODE_LEDGER
            dg_tandemup.Columns[23].Visible = false; //CODE_LEDGER
            dg_tandemup.Columns[24].Width = 70; //CODE
            dg_tandemup.Columns[24].Visible = false; //CODE

            dg_tandemup.Columns[25].Width = 70; //MANIFESTED
            dg_tandemup.Columns[25].Visible = false; //MANIFESTED
            dg_tandemup.Columns[26].Width = 70; //IDUSUARIO
            dg_tandemup.Columns[26].Visible = false; //IDUSUARIO

            dg_tandemup.Columns[27].Width = 70; //ticket_videorent
            dg_tandemup.Columns[27].Visible = true; //ticket_videorent
            dg_tandemup.Columns[28].Visible = true;
            dg_tandemup.Columns[29].Visible = false;
            dg_tandemup.Columns[30].Visible = false; // en uso
            dg_tandemup.Columns[31].Visible = false; // usado por 
            dg_tandemup.Columns[32].Visible = false; // price video rent



            dg_tandemup.Columns[1].HeaderText = "Seq";
            dg_tandemup.Columns[2].HeaderText = "Register Time";
            dg_tandemup.Columns[3].HeaderText = "Name";
            dg_tandemup.Columns[4].HeaderText = "Last Name";
            dg_tandemup.Columns[5].HeaderText = "Referenced By";
            dg_tandemup.Columns[6].HeaderText = "Jump Type";

            dg_tandemup.Columns[7].HeaderText = "Weight";
            dg_tandemup.Columns[8].HeaderText = "Ovenweight";
            dg_tandemup.Columns[9].HeaderText = "Altitud";

            dg_tandemup.Columns[10].HeaderText = "Video";
            dg_tandemup.Columns[11].HeaderText = "Hand Video";
            dg_tandemup.Columns[12].HeaderText = "Video Rent";

            dg_tandemup.Columns[13].HeaderText = "Price Jump";
            dg_tandemup.Columns[14].HeaderText = "Price Video";
            dg_tandemup.Columns[15].HeaderText = "Price Hand Video";


            dg_tandemup.Columns[16].HeaderText = "Total Charge";
            dg_tandemup.Columns[17].HeaderText = "Payment";
            dg_tandemup.Columns[18].HeaderText = "Release";
            dg_tandemup.Columns[19].HeaderText = "Reserved Date";
            dg_tandemup.Columns[20].HeaderText = "eMail";
            dg_tandemup.Columns[21].HeaderText = "T/PM/M";
            dg_tandemup.Columns[27].HeaderText = "Ticket Video Rent";

            
            
            u.Formatodgv(dg_tandemup);

        }
        #endregion

        #region Pinta renglones condicionados
        private void dg_tandemup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Font Negrita = new Font(dg_tandemup.Font, FontStyle.Bold);
            Font Normal = new Font(dg_tandemup.Font, FontStyle.Regular);

            if ((e.RowIndex) < (this.dg_tandemup.Rows.Count))
            {

                DataGridViewRow gvr = this.dg_tandemup.Rows[e.RowIndex];


                //sql = "select *  from dbo.TB_PRE_MANIFIESTO ";
                //tabla = "TB_PRE_MANIFIESTO";
                //condicion = " where idtandem = " + Convert.ToInt32(gvr.Cells[0].Value);
                //DataSet dspremanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);

                if (Convert.ToInt32(gvr.Cells[25].Value) == 2)
                {

                    gvr.DefaultCellStyle.Font = Negrita;
                    gvr.DefaultCellStyle.ForeColor = Color.Yellow;
                    gvr.DefaultCellStyle.BackColor = Color.Green;


                }

                if (Convert.ToInt32(gvr.Cells[25].Value) == 1)
                {

                    gvr.DefaultCellStyle.Font = Normal;
                    gvr.DefaultCellStyle.ForeColor = Color.Black;
                    gvr.DefaultCellStyle.BackColor = Color.Gray;
                }

                //if (Convert.ToInt32(gvr.Cells[21].Value) == 2)
                //{

                //    gvr.DefaultCellStyle.Font = Negrita;
                //    gvr.DefaultCellStyle.ForeColor = Color.Yellow;
                //    gvr.DefaultCellStyle.BackColor = Color.Green;


                //}

                //if (Convert.ToInt32(gvr.Cells[21].Value) == 1)
                //{

                //    gvr.DefaultCellStyle.Font = Normal;
                //    gvr.DefaultCellStyle.ForeColor = Color.Black;
                //    gvr.DefaultCellStyle.BackColor = Color.Gray;
                //}
                //else if (dspremanifiesto.Tables[0].Rows.Count > 0)
                //{

                //    gvr.DefaultCellStyle.Font = Normal;
                //    gvr.DefaultCellStyle.ForeColor = Color.Black;
                //    gvr.DefaultCellStyle.BackColor = Color.Gray;


                //}

            }
        }
        #endregion

        #region Inicializa objetos
        private void InicializaObjetos()
        {
            btn_manifestmodify.Image = SkyDiveCuautla.Properties.Resources.Lock;
            btn_manifestmodify.Enabled = false;
            btn_manifest.Enabled = false;
            txb_charge.Text = "0";
            txb_sobrepeso.Text = "0.00";
            string sql = @"SELECT idjumptype, jump_type, price FROM dbo.CT_JUMP_TYPE WHERE IDESTATUS = 1 ORDER BY orden";
            DataSet dsjumpertype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
            cmb_jumptype.DataSource = dsjumpertype.Tables[0].DefaultView;
            cmb_jumptype.AutoCompleteCustomSource = LoadAutoComplete(dsjumpertype, "jump_type");
            cmb_jumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumptype.ValueMember = "jump_type";
            cmb_jumptype.SelectedItem = 1;
            //cmb_jumptype.SelectedValue = dsjumpertype.Tables[0].Rows[0].ItemArray[0].ToString();
            txb_charge.Enabled = true;
            txb_seq.Text = "";
            txb_name.Text = "";
            txb_lastname.Text = "";
            txb_email.Text = "";
            txb_payment.Text = "";
            txb_referenceby.Text = "";
            txb_qtygroup.Text = "";
            chk_release.Checked = false;
            chk_handvideo.Checked = false;
            chk_gold.Checked = false;
            txb_price_hand_video.Text = "0.00";
            chk_video.Checked = false;
            chk_rtavideo.Checked = false;
            chk_rtavideo.Text = "Video Rent";
            txb_price_video.Enabled = false;
            txb_price_video.Text = "0.00";
            TandemEditado = 0;
            CamposEnedicion = false;
            txb_pricevideorent.Enabled = true;
            txb_pricevideorent.Text = "0.00";
            txb_pricevideorent.Enabled = false;
            txb_totalcharges.Text = "0.00";
            txb_peso.Text = "";
            txb_height.Text = "";
            ObtenDatosJumpType();

            txb_sobrepeso.Text = "0.00";

            if (txb_sobrepeso.Text != "0.00")
            {
                txb_sobrepeso.BackColor = Color.Red;
                txb_sobrepeso.ForeColor = Color.Yellow;
            }
            else
            {
                txb_sobrepeso.BackColor = Color.White;
                txb_sobrepeso.ForeColor = Color.Black;
            }
            TandemEditado = 0;

            TandemEnUso(TandemEditado, 1);
            misglobales.BreakdownOpen = false;

        }
        #endregion

        #region Carga Campos
        private void CargaCampos()
        {

            string sql = @"select ctj.name, ctj.lastname, ctj.email, ctj.idjumptypecode, ctjt.jump_type, ctjt.price
                             from dbo.CT_JUMPER ctj inner join dbo.CT_JUMP_TYPE ctjt on ctjt.codigo = ctj.idjumptypecode ";
            condicion = " where ctj.codigo = '" + misglobales.jumper_code_list + "'";
            DataSet dsjumper = conexion.ConsultaUniversal(sql, condicion, "CT_JUMPER");
            if (dsjumper.Tables.Count > 0)
            {
                txb_name.Text = dsjumper.Tables[0].Rows[0].ItemArray[0].ToString();
                txb_lastname.Text = dsjumper.Tables[0].Rows[0].ItemArray[1].ToString();
                txb_email.Text = dsjumper.Tables[0].Rows[0].ItemArray[2].ToString();
                cmb_jumptype.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[4].ToString();
                txb_charge.Text = Convert.ToString( Convert.ToInt32(  dsjumper.Tables[0].Rows[0].ItemArray[5].ToString()));
                if (_leejumper && misglobales._readjumper) { tmr_readjumper.Stop(); _leejumper = false; misglobales._readjumper = false; }
                txb_payment.Enabled = true;

                txb_payment.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error try get prospect");
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

        #region Load del Frm_Tandemup
        private void Frm_Tandemup_Load(object sender, EventArgs e)
        {
            sql = "SELECT ID, CODE, DESCRIPCION, PRICE, IDCHARGETYPE, CODECHARGETYPE, IDESTATUS FROM CT_ADITIONAL_SERVICES ";
            condicion = " WHERE idestatus = 1  and idoficina = " + misglobales.oficina_id_oficina;
            tabla = "CT_ADITIONAL_SERVICES";
            CostosAdicionales = conexion.ConsultaUniversal(sql, condicion, tabla);


            //dg_tandemup
            lbl_fecha.Text = Convert.ToString(DateTime.Now);
            
            TandemEditado = 0;

            TandemEnUso(TandemEditado, 1);

            InicializaObjetos();
            inicializagridview();
        }
        #endregion

        #region Evento click del btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            TandemEditado = 0;

            TandemEnUso(TandemEditado, 1);
            this.Close();
        }
        #endregion

        #region Evento click del btn_list
        private void btn_list_Click(object sender, EventArgs e)
        {
            txb_charge.Enabled = false;

            // emite reporte de quienes pagaron
            Frm_TandemupList _DisplayList = new Frm_TandemupList();
            _DisplayList.MdiParent = MDISkyDiveCuautla.ActiveForm;
            _DisplayList.WindowState = FormWindowState.Maximized;
            _DisplayList.Show();
        }
        #endregion

        #region Agrega jumper TandemUp
        private void AgregaJumperTandemUp(Boolean Group, Int32 folio, String GroupName)
        {
            if (chk_release.Checked == true)
            { _release = 1; }
            else { _release = 0; }

            if (chk_rtavideo.Checked == true)
            { _videorent = 1; }
            else
            { _videorent = 0; }

            
            String Reservedate;

            if (chk_reservejump.Checked == true)
            {
                Reservedate = "'" + datet_reserve.Value.Day + "/" + datet_reserve.Value.Month + "/" + datet_reserve.Value.Year + "'";
            }
            else
            {
                Reservedate = "getdate()";
            }

            if (txb_seq.Text == "")
            {
                txb_seq.Text = "0";
                tabla = "TB_TANDEMUP";
                sql = @"SELECT MAX(sequence)+10 AS SEQ  FROM dbo.TB_TANDEMUP ";
                condicion = " WHERE jump_flag =  0 AND (YEAR(registertime) = YEAR(GETDATE()) AND MONTH(REGISTERTIME) = MONTH(GETDATE()) AND DAY(registertime) = DAY(GETDATE()))";

                DataSet dssequence = conexion.ConsultaUniversal(sql, condicion, tabla);
                if (dssequence.Tables.Count == 0 || dssequence.Tables[0].Rows[0].ItemArray[0].ToString() == "")
                {
                    txb_seq.Text = "10";
                }
                else
                {
                    txb_seq.Text = dssequence.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                dssequence.Dispose();


            }

            //if (Group == false)
            //{

            //     valores = "'TEMPORAL', " + txb_seq.Text + ", getdate(), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_referenceby.Text + "', '" + cmb_jumptype.Text + "', " + txb_charge.Text +
            //                     ", " + txb_payment.Text + ", " + _release + ", "  + Reservedate.ToString() + ", '" + txb_email.Text + "', 0, '', '', 0";

            //     tabla = "CT_JUMPER";
            //     campos = @" balance = " + txb_payment.Text;
            //     condicion = " where nombre = '" + txb_name.Text + ", " + txb_lastname.Text + "'";
            //     conexion.UpdateTabla(campos, tabla, condicion);

            //}
            //else
            //{
            //    if (txb_charge.Text == "") { txb_charge.Text = "0"; }
            //    if (txb_payment.Text == "") { txb_payment.Text = "0"; }


            //    
            //}
            String _code = "";
            if (Group == true)
            {

            }

            DataSet dscode = conexion.ConsultaUniversal("SELECT MAX(idtandemup)+1 FROM dbo.TB_TANDEMUP", "", "TB_TANDEMUP");
            if (dscode.Tables.Count == 0 || dscode.Tables[0].Rows[0].ItemArray[0].ToString() == "")
            {
                _code = "1-" + cmb_jumptype.Text + "-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
            }
            else
            {
                _code = dscode.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + cmb_jumptype.Text + "-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
            }

            if (txb_payment.Text == "")
            {
                txb_payment.Text = "0";
            }

            if (txb_peso.Text == "")
            { txb_peso.Text = "0"; }

            if (txb_height.Text == "")
            { txb_height.Text = "0"; }

            if (txb_sobrepeso.Text == "")
            { txb_sobrepeso.Text = "0"; }




            //SE AGREGA A TANDEM UP
            campos = "CODE, SEQUENCE, REGISTERTIME, NAME, LASTNAME, REFERENCED_BY, JUMPTYPE, pricejump, CHARGE, PAYMANT,  RELEASE,  RESERVED_DATE,  EMAIL,  JUMP_FLAG,  ID_PROSPECT, CODE_LEDGER, MANIFESTED, idusuario, tandemweight, tandemheight, tandemovenweight, videorent, idoficina ";
            tabla = "TB_TANDEMUP";

            valores = "'" + _code + "', " + txb_seq.Text + ", getdate(), '" + txb_name.Text + "', '" + txb_lastname.Text + "', '" + txb_referenceby.Text +
                      "', '" + cmb_jumptype.Text + "', " +  txb_charge.Text + ", " + txb_totalcharges.Text +
                      ", " + txb_payment.Text + ", " + _release + ", " + Reservedate.ToString() + ", '" + txb_email.Text + "', 0, '', '', 0," + misglobales.usuario_idusuario + "," + txb_peso.Text + "," + txb_height.Text + "," + txb_sobrepeso.Text + ", " + _videorent + "," + misglobales.oficina_id_oficina;
            try
            {
                conexion.InsertTabla(campos, tabla, valores);

                sql = " select max(idtandemup) as idtandemup from dbo.TB_TANDEMUP ";
                condicion = "";
                tabla = "TB_TANDEMUP";
                DataSet dsidtandemup = conexion.ConsultaUniversal(sql, condicion, tabla);
                _idtandemup = Convert.ToInt32(dsidtandemup.Tables[0].Rows[0].ItemArray[0].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error try add TandemUp " + ex.Message);
            }




            if (chk_video.Checked == true)
            {
                tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                campos = @" price = " + txb_price_video.Text;
                //condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices = 1 ";

                condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + "  ) ";
                conexion.UpdateTabla(campos, tabla, condicion);
            }

            if (chk_handvideo.Checked == true)
            {
                tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                campos = @" price = " + txb_price_hand_video.Text;
                //condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices = 2 ";
                condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + "  ) ";
                conexion.UpdateTabla(campos, tabla, condicion);
            }

            if (chk_rtavideo.Checked == true)
            {
                tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                campos = @" price = " + txb_price_hand_video.Text;
                //condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices = 4 ";
                condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + "  ) ";
                conexion.UpdateTabla(campos, tabla, condicion);
            }


            //GroupName.ToString() + "-" + folio.ToString() +
            //SE AGREGA A LEDGER


        }
        #endregion

        #region Evento Click del btn_add
        private void btn_add_Click(object sender, EventArgs e)
        {
            DioClickGrid = 0;
            if (cmb_jumptype.Text != "")
            {

                AgregaJumperTandemUp(false, 0, "");
                InicializaObjetos();
                inicializagridview();
            }
            else
            {
                MessageBox.Show("Please select a JumpType");
            }
        }
        #endregion

        #region Se bloquea o se libera un Tandemup para su edición
        private void TandemEnUso(Int32 EnUso, Int32 Alltandem)
        {

            tabla = "TB_TANDEMUP";
            campos = @" ENUSO = " + EnUso + "," +
                " USADOPOR = " + misglobales.usuario_idusuario;
            if (Alltandem == 0)
            {
                condicion = " where idtandemup = " + _idtandemup.ToString();
            }
            else if (Alltandem == 1)
            {
                condicion = " where usadopor = " + misglobales.usuario_idusuario;
            }
            conexion.UpdateTabla(campos, tabla, condicion);
        
        }
        #endregion 
         
        #region Evento que colorea los campos con alerta de que estan manifestdos
        private void CamposAlerta(Boolean Alertado, Boolean Habilitados)
        {
            if (Alertado)
            {
                txb_seq.ForeColor = Color.Red;
                txb_name.ForeColor = Color.Red;
                txb_lastname.ForeColor = Color.Red;
                txb_email.ForeColor = Color.Red;
                cmb_jumptype.ForeColor = Color.Red;
                txb_charge.ForeColor = Color.Red;
                txb_payment.ForeColor = Color.Red;
                txb_height.ForeColor = Color.Red;

                txb_seq.BackColor = Color.Lime;
                txb_name.BackColor = Color.Lime;
                txb_lastname.BackColor = Color.Lime;
                txb_email.BackColor = Color.Lime;
                cmb_jumptype.BackColor = Color.Lime;
                txb_charge.BackColor = Color.Lime;
                txb_payment.BackColor = Color.Lime;
                txb_height.BackColor = Color.Lime;

                lbl_titulo.ForeColor = Color.Red;
            }
            else
            {
                txb_seq.BackColor = Color.White;
                txb_name.BackColor = Color.White;
                txb_lastname.BackColor = Color.White;
                txb_email.BackColor = Color.White;
                cmb_jumptype.BackColor = Color.White;
                txb_charge.BackColor = Color.White;
                txb_payment.BackColor = Color.White;
                txb_height.BackColor = Color.White;


                txb_seq.ForeColor = Color.Black;
                txb_name.ForeColor = Color.Black;
                txb_lastname.ForeColor = Color.Black;
                txb_email.ForeColor = Color.Black;
                cmb_jumptype.ForeColor = Color.Black;
                txb_charge.ForeColor = Color.Black;
                txb_payment.ForeColor = Color.Black;
                txb_height.ForeColor = Color.Black;
                lbl_titulo.ForeColor = Color.SteelBlue;

            }

            txb_seq.Enabled = Habilitados;
            txb_name.Enabled = Habilitados;
            txb_lastname.Enabled = Habilitados;
            txb_email.Enabled = Habilitados;
            cmb_jumptype.Enabled = Habilitados;
            btn_autoriza.Enabled = Habilitados;
            btn_breakdown.Enabled = Habilitados;
            


            if (EstaManifestado)
            {
                btn_save2.Enabled = false;
                btn_save.Enabled = false;
            }
            else
            {
                btn_save2.Enabled = Habilitados;
                btn_save.Enabled = Habilitados;
            }

            btn_add.Enabled = Habilitados;
            btn_changevideoprice.Enabled = Habilitados;
            btn_changehandvideo.Enabled = Habilitados;
            chk_video.Enabled = Habilitados;
            chk_handvideo.Enabled = Habilitados;
            chk_gold.Enabled = Habilitados;
            chk_rtavideo.Enabled = Habilitados;
            btn_videorent.Enabled = Habilitados;
            txb_peso.Enabled = Habilitados;
            txb_sobrepeso.Enabled = Habilitados;
            chk_release.Enabled = Habilitados;
            txb_height.Enabled = Habilitados;

 
        }
        #endregion 

        #region cargacampos al dar clik en el grid
        private void CargaCamposdelGrid()
        {
            //gpo_tandemup.Enabled = false;

            btn_videorent.Enabled = true;
            grp_Grupo.Enabled = false;
            btn_processreserve.Enabled = false;
            btn_add.Enabled = false;
            btn_del.Enabled = false;
            btn_findpropspect.Enabled = false;

            TandemEditado = 0;
            TandemEnUso(TandemEditado, 1);



            sql = "select *  from dbo.TB_PRE_MANIFIESTO ";
            tabla = "TB_PRE_MANIFIESTO";
            condicion = " where idtandem = " + Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value);
            DataSet dspremanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);


            misglobales._Objeto = "ChangeManifest";
            bool lopresento = Permisos.habilitado("ChangeManifest");
            misglobales._Autoriza = lopresento;

            if (lopresento)
            {
                btn_manifestmodify.Enabled = true;

            }


            if (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[25].Value) == 0 || Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[25].Value) == 1 || lopresento == true)
            {
                if (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[17].Value) == 0 || (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[17].Value) > 0 && Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[26].Value) == misglobales.usuario_idusuario))
                {




                    sql = "SELECT idtandemup, code, sequence, name, lastname FROM dbo.TB_TANDEMUP  ";
                    condicion = " WHERE idtandemup = " + Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value) + " AND USADOPOR <> " + misglobales.usuario_idusuario + " AND ENUSO = 1";
                    tabla = "ct_usuario";
                    ConsultaEdicion = conexion.ConsultaUniversal(sql, condicion, tabla);


                    if (ConsultaEdicion.Tables[0].Rows.Count > 0)
                    {

                        sql = "SELECT IDUSUARIO, NOMBRE + ' ' + PATERNO FROM dbo.CT_USUARIO  ";
                        condicion = " WHERE IDUSUARIO = " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[31].Value;
                        tabla = "ct_usuario";
                        ConsultaEdicion = conexion.ConsultaUniversal(sql, condicion, tabla);

                        String UsadoPor = ConsultaEdicion.Tables[0].Rows[0].ItemArray[1].ToString();


                        MessageBox.Show("IMPORTANT!!!   Can not use this TANDEM because " + UsadoPor + ", is using just now ");
                    }
                    else
                    {
                        // cargar campos
                        txb_seq.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[1].Value);
                        txb_name.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[3].Value);
                        txb_lastname.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[4].Value);
                        txb_email.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[20].Value);
                        txb_referenceby.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[5].Value);

                        if (dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[7].Value == null || dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[7].Value == "") { txb_peso.Text = "0"; } else { txb_peso.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[7].Value); }
                        if (dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[8].Value == null || dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[8].Value == "") { txb_sobrepeso.Text = "0"; } else { txb_sobrepeso.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[8].Value); }
                        if (dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[9].Value == null || dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[9].Value == "") { txb_height.Text = "0"; } else { txb_height.Text = Convert.ToString(Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[9].Value)); }


                        tabla = "CT_JUMP_TYPE";
                        sql = @"select idjumptype, codigo, jump_type, price from dbo.CT_JUMP_TYPE ";
                        condicion = @" where codigo = '" + Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[6].Value) + "'  OR jump_type = '" + Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[6].Value) + "'";
                        DataSet dsjumptype = conexion.ConsultaUniversal(sql, condicion, tabla);
                        cmb_jumptype.SelectedValue = dsjumptype.Tables[0].Rows[0].ItemArray[2].ToString();
                        txb_charge.Enabled = true;
                        txb_charge.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[13].Value);  //dsjumptype.Tables[0].Rows[0].ItemArray[3].ToString();
                        if (txb_charge.Text == "") { txb_charge.Text = "0"; }
                        txb_charge.Enabled = false;
                        txb_totalcharges.ReadOnly = false;
                        txb_totalcharges.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[16].Value);
                        txb_totalcharges.ReadOnly = true;
                        txb_payment.Enabled = true;
                        txb_payment.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[17].Value);
                        txb_payment.Enabled = false;
                        dsjumptype.Dispose();
                        btn_save.Enabled = true;
                        btn_save2.Enabled = true;
                        _idtandemup = Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value);
                        DioClickGrid = 1;
                        misglobales._idtandemup = Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value);
                        misglobales._tandemupcode = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[24].Value); //+ "-TANDEM-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
                        chk_video.Checked = Convert.ToBoolean(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[10].Value);
                        chk_handvideo.Checked = Convert.ToBoolean(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[11].Value);
                        chk_rtavideo.Checked = Convert.ToBoolean(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[12].Value);
                        chk_release.Checked = Convert.ToBoolean(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[18].Value);

                        if (Convert.ToDecimal(txb_payment.Text) >= Convert.ToDecimal(txb_totalcharges.Text))
                        {
                            chk_release.Checked = true;
                        }
                        if (chk_video.Checked == true)
                        {
                            //CheckUncheckvideo = "Trae video";
                            //sql = "SELECT ID, idtandemup, idaditionalservices, price, updatedate FROM dbo.TB_TANDEMUP_ADITIONAL_SERVICES";
                            //condicion = " WHERE idtandemup = " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value + " AND " +
                            //            " idaditionalservices = 1";
                            //tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                            //CostosAdicionalesAutorizados = conexion.ConsultaUniversal(sql, condicion, tabla);
                            //txb_price_video.Text = CostosAdicionalesAutorizados.Tables[0].Rows[0].ItemArray[3].ToString();

                            txb_price_video.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[14].Value);

                        }
                        if (chk_handvideo.Checked == true)
                        {
                            //CheckUncheckvideo = "Trae video";
                            //sql = "SELECT ID, idtandemup, idaditionalservices, price, updatedate FROM dbo.TB_TANDEMUP_ADITIONAL_SERVICES";
                            //condicion = " WHERE idtandemup = " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value + " AND " +
                            //            " idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO') ";
                            //tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                            //CostosAdicionalesAutorizados = conexion.ConsultaUniversal(sql, condicion, tabla);
                            //txb_price_hand_video.Text = CostosAdicionalesAutorizados.Tables[0].Rows[0].ItemArray[3].ToString();
                            txb_price_hand_video.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[15].Value);

                        }

                        if (chk_rtavideo.Checked == true)
                        {
                            sql = "SELECT ID, idtandemup, idaditionalservices, price, updatedate FROM dbo.TB_TANDEMUP_ADITIONAL_SERVICES";
                            condicion = " WHERE idtandemup = " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value + " AND " +
                                        " idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA') ";
                            tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                            CostosAdicionalesAutorizados = conexion.ConsultaUniversal(sql, condicion, tabla);
                            txb_pricevideorent.Text = CostosAdicionalesAutorizados.Tables[0].Rows[0].ItemArray[3].ToString();

                            txb_pricevideorent.Text = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[32].Value);
                        }



                        ActualizaCargosTotales();

                        if (dspremanifiesto.Tables[0].Rows.Count > 0)
                        {
                            chk_video.Enabled = false;
                            chk_handvideo.Enabled = false;
                        }
                        else
                        {
                            chk_video.Enabled = true;
                            chk_handvideo.Enabled = true;
                        }

                        if (txb_sobrepeso.Text != "0.00")
                        {
                            txb_sobrepeso.BackColor = Color.Red;
                            txb_sobrepeso.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            txb_sobrepeso.BackColor = Color.White;
                            txb_sobrepeso.ForeColor = Color.Black;
                        }

                        TandemEditado = 1;
                        TandemEnUso(TandemEditado, 0);

                        //  Algoritmo para bloquear usuario

                        if (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[25].Value) == 2 && lopresento)
                        {
                            btn_manifestmodify.Enabled = true;
                            EstaManifestado = true;
                            CamposAlerta(true, false);

                        }
                        if (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[25].Value) != 2)
                        {

                            btn_manifestmodify.Enabled = false;
                            EstaManifestado = false;
                            CamposAlerta(false, true);
                        }



                    }
                }
                else
                {
                    MessageBox.Show(" Only  " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[29].Value + " can modify this record");
                }
            }
        }
        #endregion

        #region Evento click en la celda del grid
        private void dg_tandemup_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (CamposEnedicion == true)
            {
                DialogResult resultado = MessageBox.Show("Are you sure select other Tandem without save this Tandem  ???", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    CargaCamposdelGrid();
                }
            }
            else
            {
                CargaCamposdelGrid();
            }
            
            
            
        }
        #endregion

        #region Evento KeyPress del txb_qtygroup
        private void txb_qtygroup_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Evento Click del btn_brakdown
        private void btn_breakdown_Click(object sender, EventArgs e)
        {

            if (misglobales.BreakdownOpen == false)
            {
                misglobales.BreakdownOpen = true;
                CamposEnedicion = true;
                //misglobales._tandemupcode = "TANDEM";
                tmr_readjumper.Start();
                misglobales._utilizandoPayment = true;
                misglobales._BreakDown = 1;
                if (DioClickGrid == 0)
                {
                    String _code = "";
                    DataSet dscode = conexion.ConsultaUniversal("SELECT MAX(idtandemup)+1 FROM dbo.TB_TANDEMUP", "", "TB_TANDEMUP");
                    if (dscode.Tables.Count == 0 || dscode.Tables[0].Rows[0].ItemArray[0].ToString() == "")
                    {
                        _code = "1-" + cmb_jumptype.Text + "-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
                    }
                    else
                    {
                        _code = dscode.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + cmb_jumptype.Text + "-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
                    }


                    misglobales._tandemupcode = _code;
                }
                else
                {
                    misglobales._tandemupcode = Convert.ToString( dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[24].Value);
                }
                misglobales._BreakDown = 1;
                Frm_Payment_Breakdown FrmPayment = new Frm_Payment_Breakdown();
                FrmPayment.Show();

                //misglobales._Login = 1;
                //if (txb_lastname.Text != "")
                //{
                //    misglobales._name = txb_lastname.Text + ", " + txb_name.Text;
                //}
                //else
                //{
                //    misglobales._name = "";
                //}
                ////misglobales._manifiesto = Lbl_matriculainfo.Text + "-" + Lbl_FlightCode.Text;
                //acceso _FrmLogin = new acceso();
                //_FrmLogin.Show();
            }
            else
            {
                MessageBox.Show(" Breakdown it's open jet !!! ");
            }

        }
        #endregion

        #region Evento click del btn_generategroup
        private void btn_generategroup_Click(object sender, EventArgs e)
        {

                if (cmb_jumptype.Text == "")
                {
                    MessageBox.Show("Please select Jump Type before create Tandem Group ");

                }
                else
                {

                    txb_charge.Enabled = false;
                    String groupname = txb_referenceby.Text;
                    Int32 grupoqty = Convert.ToInt32(txb_qtygroup.Text);
                    Int32 Etiqueta = 1;

                    for (int i = 0; i < grupoqty; i++)
                    {
                        txb_lastname.Text = "Enqueued";
                        txb_name.Text = txb_referenceby.Text + " (" + Etiqueta.ToString() + ")";
                        txb_seq.Text = "";
                        AgregaJumperTandemUp(true, i + 1, groupname);
                        Etiqueta = Etiqueta + 1;

                    }

                    TandemEditado = 0;
                    TandemEnUso(TandemEditado, 1);

                    inicializagridview();
                }
            
        }
        #endregion

        #region Valida campos obligatorios
        private Boolean ValidaCamposObligatorios()
        {
            bool respuesta = false;

            if (cmb_jumptype.Text.Length >= 2)
            {
                respuesta = true;
            }
            else { MessageBox.Show(" Jump Type field it's needed "); respuesta = false; return respuesta; }

            return respuesta;


        }
        #endregion

        #region Salvar Tandem
        private void SalvarTandem()
        {
        gpo_tandemup.Enabled = true;
            CamposAlerta(false, true);
           


            if (ValidaCamposObligatorios())  // si ya se generó el nuevo jumper o se consulto un jumper
            {
                DioClickGrid = 0;
                btn_videorent.Enabled = false;

                //save record
                //if (CheckUncheckvideo == "Traia y le quito el video") 
                //{

                //txb_charge.Text = Convert.ToString(Convert.ToDecimal(txb_charge.Text) - Convert.ToDecimal(CostosAdicionales.Tables[0].Select("id = 1")[0].ItemArray[3].ToString()) + Convert.ToDecimal(txb_price_hand_video.Text));
                //}
                //else if (CheckUncheckvideo == "Trae video")
                //{
                //    txb_charge.Text = txb_charge.Text;
                //}
                //else
                //{

                if (txb_peso.Text == "") { txb_peso.Text = "0"; }
                if (txb_height.Text == "") { txb_height.Text = "0"; }
                if (txb_sobrepeso.Text == "") { txb_sobrepeso.Text = "0"; }


                String _Charge = Convert.ToString(Convert.ToDecimal(txb_charge.Text) + Convert.ToDecimal(txb_price_video.Text) + Convert.ToDecimal(txb_price_hand_video.Text) + Convert.ToDecimal(txb_pricevideorent.Text) + Convert.ToDecimal(txb_sobrepeso.Text));
                //}
                txb_totalcharges.Text = _Charge.ToString();
                ActualizaCargosTotales();


                conexion.RegistroLog(misglobales.usuario_idusuario, "TandemUp", "El Tandem : " +misglobales.TandemName + " fue modificado con Charge:" + txb_charge.Text + " y un Payment: " + txb_payment.Text); 


                tabla = "TB_TANDEMUP";
                campos = @" sequence = " + txb_seq.Text + ", " +
                          " name = '" + txb_name.Text + "', " +
                          " lastname = '" + txb_lastname.Text + "', " +
                          " email = '" + txb_email.Text + "', " +
                          " jumptype = '" + cmb_jumptype.Text + "', " +
                          " pricejump = " + txb_charge.Text + ", " +
                          " charge = " + _Charge + ", " +
                          " paymant = " + txb_payment.Text + ", " +
                          " release = " + _release.ToString() + ", " +
                          " REFERENCED_BY = '" + txb_referenceby.Text + "'," +
                          " idusuario = " + misglobales.usuario_idusuario + "," +
                          " tandemheight = " + txb_height.Text + "," +
                          " tandemovenweight = " + txb_sobrepeso.Text + "," +
                          " tandemweight = " + txb_peso.Text;
                condicion = " where idtandemup = " + _idtandemup.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);



                if (chk_video.Checked == true)
                {
                    tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                    campos = @" price = " + txb_price_video.Text;
                    condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = "+misglobales.oficina_id_oficina+"  ) ";
                    conexion.UpdateTabla(campos, tabla, condicion);
                }

                if (chk_handvideo.Checked == true)
                {
                    tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                    campos = @" price = " + txb_price_hand_video.Text;
                    condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + "  ) ";
                    conexion.UpdateTabla(campos, tabla, condicion);
                }


                if (chk_rtavideo.Checked == true)
                {
                    tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                    campos = @" price = " + txb_pricevideorent.Text;
                    condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + "  ) ";
                    conexion.UpdateTabla(campos, tabla, condicion);
                }


                TandemEditado = 0;
                TandemEnUso(TandemEditado, 1);


                InicializaObjetos();
                inicializagridview();
                btn_save.Enabled = false;
                btn_save2.Enabled = false;

                grp_Grupo.Enabled = true;
                btn_processreserve.Enabled = true;
                btn_add.Enabled = true;
                btn_del.Enabled = true;
                btn_findpropspect.Enabled = true;




            }
        }
        #endregion 

        #region Evento click del btn_save
        private void btn_save_Click(object sender, EventArgs e)
        {

            if(txb_totalcharges.Text == "") {txb_totalcharges.Text = "0";}
            if(txb_payment.Text == "") {txb_payment.Text = "0";}

            Decimal TotalCargos = Convert.ToDecimal( txb_totalcharges.Text);
            Decimal TotalPagado = Convert.ToDecimal( txb_payment.Text);

            if (TotalCargos < TotalPagado )
            {

                DialogResult resultado = MessageBox.Show("Are you sure save this Tandem with release with and Total Payment incomplete ???", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                    SalvarTandem();
                }
                else
                {
                    chk_release.Checked = false;
                }
            }
            else
            {
                SalvarTandem();
            }
            
            

        }
        #endregion

        #region ObtenDatosJumpType
        private void ObtenDatosJumpType()
        {
            if (cmb_jumptype.SelectedIndex >= 0)
            {
                txb_charge.Enabled = true;
                string sql = @"SELECT idjumptype, jump_type, price FROM dbo.CT_JUMP_TYPE WHERE jump_type = '" + cmb_jumptype.SelectedValue.ToString() + "' and IDESTATUS = 1 ORDER BY orden";
                DataSet dsjumpertype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
                if (dsjumpertype.Tables[0].Rows.Count > 0)
                {
                    txb_charge.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( dsjumpertype.Tables[0].Rows[0].ItemArray[2].ToString())));
                    txb_charge.Enabled = false;
                }
                ActualizaCargosTotales();
            }
        }
        #endregion

        #region Evento SlectedIndexChanged del cmb_jumptype
        private void cmb_jumptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenDatosJumpType();
        }
        #endregion

        #region Evento SelectedValueChanged del cmb_jumptype
        private void cmb_jumptype_SelectedValueChanged(object sender, EventArgs e)
        {
            ObtenDatosJumpType();
        }
        #endregion

        #region Evento Selection Change Committed del cmb_jumptype
        private void cmb_jumptype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ObtenDatosJumpType();
            CamposEnedicion = true;

        }
        #endregion

        #region Evento enter del combo jumptype
        private void cmb_jumptype_Enter(object sender, EventArgs e)
        {
            //ObtenDatosJumpType();
        }
        #endregion

        #region Evento text changed del combo jumptype
        private void cmb_jumptype_TextChanged(object sender, EventArgs e)
        {
            ObtenDatosJumpType();
        }
        #endregion

        #region Evento click del boton findprospect
        private void btn_findpropspect_Click(object sender, EventArgs e)
        {
            Frm_JumperSelection FrmJumperSelector = new Frm_JumperSelection();
            FrmJumperSelector.Show();
            _leejumper = true;
            //misglobales._readjumper = true;
            tmr_readjumper.Start();
        }
        #endregion

        #region Evento tick del timer readjumper
        private void tmr_readjumper_Tick(object sender, EventArgs e)
        {
            if (misglobales._readjumper)
            {
                InicializaObjetos();
                CargaCampos();

            }
            if (misglobales._utilizandoPayment == false)
            {
                txb_payment.Text = misglobales._TotalBalance.ToString();
                if (Convert.ToDecimal(txb_payment.Text) >= Convert.ToDecimal(txb_totalcharges.Text)) { chk_release.Checked = true; }
                tmr_readjumper.Stop();

            }


        }
        #endregion

        #region Evento CheckedChanged del check box release
        private void chk_release_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_release.Checked == true) { _release = 1; } else { _release = 0; }

        }
        #endregion

        #region Metodo Borra registro
        private void BorraRegistro()
        {
            tabla = "TB_TANDEMUP";
            condicion = "  idtandemup = " + _idtandemup.ToString();
            conexion.BorraRegistro(condicion, tabla);


            grp_Grupo.Enabled = true;
            btn_processreserve.Enabled = true;
            btn_add.Enabled = true;
            btn_del.Enabled = true;
            btn_findpropspect.Enabled = true;

        }
        #endregion

        #region Evento User Deleting Row del gridview tandemup
        private void dg_tandemup_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[13].Value) == 0 || (Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[13].Value) > 0 && Convert.ToInt32(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[26].Value) == misglobales.usuario_idusuario))
            {
                DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                    //tabla = "TB_TANDEMUP";
                    //campos = "";
                    //conexion.UpdateTabla(campos, tabla, condicion);


                    BorraRegistro();


                }
            }
            else 
            {
                MessageBox.Show(" Only  " +  dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[29].Value+ " can delete this record");
            }

        }
        #endregion

        #region Evento click del boton del
        private void btn_del_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                BorraRegistro();


            }
        }
        #endregion

        #region Evento clik del boton Reservaciones
        private void btn_reservaciones_Click(object sender, EventArgs e)
        {
            btn_reservaciones.Visible = true;
            Frm_LoadReservations LoadReservations = new Frm_LoadReservations();
            LoadReservations.Show();
            btn_processreserve.Visible = true;



        }
        #endregion

        #region evento click del boton processreserve
        private void btn_processreserve_Click(object sender, EventArgs e)
        {
            misglobales._Importing = 1;
            tmr_reserve.Start();
            Frm_Reserve_TandemUp TakeReserve = new Frm_Reserve_TandemUp();
            TakeReserve.Show();
        }
        #endregion

        #region evento tick del timer reserve
        private void tmr_reserve_Tick(object sender, EventArgs e)
        {
            if (misglobales._Importing == 0)
            {
                TandemEditado = 0;
                TandemEnUso(TandemEditado, 1); inicializagridview(); tmr_reserve.Stop();
            }
        }
        #endregion

        #region evento click del boton autoriza cambio de cargo
        private void btn_autoriza_Click(object sender, EventArgs e)
        {
            misglobales._Autoriza = false;

            if ((txb_name.Text.Length +  txb_lastname.Text.Length) >= 4)
            {
                if (misglobales._Autoriza == false)
                {
                    misglobales._Login = 3; //Change Charge: Allow Transaction with no Balance
                    misglobales.TandemName = txb_name.Text + " " + txb_lastname.Text;
                    misglobales.TandemJumpPrice = Convert.ToDecimal(txb_charge.Text);

                    acceso _FrmLogin = new acceso();
                    tmr_autoriza.Start();
                    _FrmLogin.Show();

                }
            }
            else 
            {
                MessageBox.Show("Please, select or register a Tandemup");
            }
        }
        #endregion

        #region evento tick del timer autoriza
        private void tmr_autoriza_Tick(object sender, EventArgs e)
        {
            if (misglobales._Autoriza == true)
            {
                if (misglobales._Login == 3)
                {
                    txb_charge.Enabled = true;
                    txb_charge.ReadOnly = false;
                    tmr_autoriza.Stop();
                }
                if (misglobales._Login == 4)
                {
                    txb_price_video.Enabled = true;
                    txb_price_video.ReadOnly = false;
                    tmr_autoriza.Stop();
                }
                if (misglobales._Login == 5)
                {
                    txb_price_hand_video.Enabled = true;
                    txb_price_hand_video.ReadOnly = false;
                    tmr_autoriza.Stop();
                }

            }
            else
            {
                if (misglobales._Login == 3) { txb_charge.Enabled = false; txb_charge.ReadOnly = true; }
                if (misglobales._Login == 4) { txb_price_video.Enabled = false; txb_price_video.ReadOnly = true; }
                if (misglobales._Login == 5) { txb_price_hand_video.Enabled = false; txb_price_hand_video.ReadOnly = true; }
            }

        }
        #endregion

        #region Evento tick del timer carga reserva
        private void tmr_cargareserva_Tick(object sender, EventArgs e)
        {
            TandemEditado = 0;
            TandemEnUso(TandemEditado, 1);
            inicializagridview();
        }
        #endregion

        #region Método que guarda los servicios adicionales para este tandemup
        private void GuardaServicios(int idaditionalservices, string price)
        {
            String _code = "";
            tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
            campos = "idtandemup, idaditionalservices, price, updatedate";

            if (DioClickGrid == 0)
            {

                DataSet dscode = conexion.ConsultaUniversal("SELECT MAX(idtandemup)+1 FROM dbo.TB_TANDEMUP", "", "TB_TANDEMUP");
                if (dscode.Tables.Count == 0 || dscode.Tables[0].Rows[0].ItemArray[0].ToString() == "")
                {
                    //_code = "1-TANDEM-" + txb_name.Text.Substring(0, 2) + txb_lastname.Text.Substring(0, 2);
                    _code = "1";
                }
                else
                {
                    _code = dscode.Tables[0].Rows[0].ItemArray[0].ToString();
                }



            }
            else
            {
                _code = Convert.ToString(dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value);
            }


            valores = "" + _code + ", " + idaditionalservices + ", " + price + ", getdate()";



            try
            {


                conexion.InsertTabla(campos, tabla, valores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try insert the aditional services for this tandemup " + ex.Message);
            }
        }
        #endregion

        #region Método para borrar los servicios aicionales
        private void BorraServicios(int idaditionalservices)
        {
            try
            {
                tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
                condicion = " idtandemup =  " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[0].Value + " AND " +
                            " idaditionalservices = " + idaditionalservices;

                conexion.BorraRegistro(condicion, tabla);

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error to try delete aditional service " + ex.Message);
            }
        }
        #endregion

        #region Metodo actualizar Cargo total
        private void ActualizaCargosTotales()
        {
            txb_totalcharges.Text = Convert.ToString(Convert.ToDecimal(txb_charge.Text) + Convert.ToDecimal(txb_price_video.Text) + Convert.ToDecimal(txb_price_hand_video.Text) + Convert.ToDecimal(txb_pricevideorent.Text) + Convert.ToDecimal(txb_sobrepeso.Text));
        }
        #endregion

        #region chk_gold_checked
        private void chk_gold_CheckedChanged(object sender, EventArgs e)
        {
            EsGold = 1;
            if (txb_name.Text != "")
            {
                decimal Registro = Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'FOTO Y VIDEO'")[0].ItemArray[3].ToString()) + Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO DE MANO'")[0].ItemArray[3].ToString()) - Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO GOLD'")[0].ItemArray[3].ToString()); 
                Int32 Servicio1 = Convert.ToInt32(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'FOTO Y VIDEO'")[0].ItemArray[0].ToString());
                Int32 Servicio2 = Convert.ToInt32(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO DE MANO'")[0].ItemArray[0].ToString());
                if (chk_gold.Checked == true)
                {
                    
                    chk_handvideo.Checked = true;
                    chk_video.Checked = true;
                    txb_price_video.Text = CostosAdicionales.Tables[0].Select("DESCRIPCION = 'FOTO Y VIDEO'")[0].ItemArray[3].ToString();
                    txb_price_hand_video.Text = Convert.ToString(Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO DE MANO'")[0].ItemArray[3].ToString()) - Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO GOLD'")[0].ItemArray[3].ToString()));
                    GuardaServicios(Servicio1, txb_price_video.Text);
                    GuardaServicios(Servicio2, txb_price_hand_video.Text);

                }
                else 
                {
                    chk_handvideo.Checked = false;
                    chk_video.Checked = false;
                    txb_price_video.Text = "0.00";
                    BorraServicios(Servicio1);
                    txb_price_hand_video.Text = "0.00";
                    BorraServicios(Servicio2);
                }
                ActualizaCargosTotales();
            }
            EsGold = 0;
        }
        #endregion

        #region Evento Checked Changed para el check box video
        private void chk_video_CheckedChanged(object sender, EventArgs e)
        {
            if (txb_name.Text != "" && EsGold==0)
            {
                decimal Registro = Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'FOTO Y VIDEO'")[0].ItemArray[3].ToString());
                Int32 servicio = Convert.ToInt32(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'FOTO Y VIDEO'")[0].ItemArray[0].ToString());
                //decimal Chargefinal = 0;
                if (chk_video.Checked == true)
                {

                    //if (CheckUncheckvideo == "Traia y le quito el video")
                    //{


                    //    CheckUncheckvideo = "Trae video";
                    //}
                    //else
                    //{

                    _aditional_services = Convert.ToDecimal(Registro);
                    //Chargefinal = Convert.ToDecimal(txb_charge.Text) + _aditional_services;
                    txb_price_video.Text = _aditional_services.ToString();
                    //txb_charge.Text = Chargefinal.ToString();
                    GuardaServicios(servicio, txb_price_video.Text);
                    //}
                }
                else
                {
                    _aditional_services = Convert.ToDecimal(Registro);
                    //Chargefinal = Convert.ToDecimal(txb_charge.Text) - _aditional_services;
                    txb_price_video.Text = "0.00";
                    BorraServicios(servicio);
                    //txb_charge.Text = Chargefinal.ToString();
                    //if (CheckUncheckvideo == "Trae video") { CheckUncheckvideo = "Traia y le quito el video"; }
                }
                ActualizaCargosTotales();
            }


        }
        #endregion

        #region Evento Checked Changed para el check box hand video
        private void chk_handvideo_CheckedChanged(object sender, EventArgs e)
        {
            if (txb_name.Text != "" && EsGold==0)
            {
                decimal Registro = Convert.ToDecimal(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO DE MANO'")[0].ItemArray[3].ToString());
                Int32 Servicio = Convert.ToInt32(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO DE MANO'")[0].ItemArray[0].ToString());
                //decimal Chargefinal = 0;
                if (chk_handvideo.Checked == true)
                {
                    _aditional_services = Convert.ToDecimal(Registro);
                    //Chargefinal = Convert.ToDecimal(txb_charge.Text) + _aditional_services;
                    txb_price_hand_video.Text = _aditional_services.ToString();
                    //txb_charge.Text = Chargefinal.ToString();
                    GuardaServicios(Servicio, txb_price_hand_video.Text);
                    chk_rtavideo.Checked = false;
                }
                else
                {
                    _aditional_services = Convert.ToDecimal(Registro);
                    //Chargefinal = Convert.ToDecimal(txb_charge.Text) - _aditional_services;
                    txb_price_hand_video.Text = "0.00";
                    BorraServicios(Servicio);
                    // txb_charge.Text = Chargefinal.ToString();
                }
                ActualizaCargosTotales();
            }

        }
        #endregion

        #region evento click del boton autoriza cambio de precio para el video
        private void btn_changevideoprice_Click(object sender, EventArgs e)
        {
            misglobales._Autoriza = false;

            if (misglobales._Autoriza == false)
            {
                misglobales._Login = 4; //Change price video
                misglobales.TandemVideoPrice = Convert.ToDecimal(txb_price_video.Text);

                acceso _FrmLogin = new acceso();
                tmr_autoriza.Start();
                _FrmLogin.Show();

            }
        }
        #endregion

        #region evento click del boton autoriza cambio de precio para el video de mano
        private void btn_changehandvideo_Click(object sender, EventArgs e)
        {
            misglobales._Autoriza = false;

            if (misglobales._Autoriza == false)
            {
                misglobales._Login = 5; //Change price video
                misglobales.TandemHandVideoPrice = Convert.ToDecimal(txb_price_hand_video.Text);
                acceso _FrmLogin = new acceso();
                tmr_autoriza.Start();
                _FrmLogin.Show();

            }
        }
        #endregion

        #region Evento Lost Focus de txb_charge
        private void txb_price_video_LostFocus(object sender, EventArgs e)
        {
            ActualizaCargosTotales();
            txb_price_video.ReadOnly = true;

        }
        #endregion

        #region Evento Lost Focus de txb_sobrepeso
        private void txb_sobrepeso_LostFocus(object sender, EventArgs e)
        {
            ActualizaCargosTotales();
            if (txb_sobrepeso.Text != "0.00")
            {
                txb_sobrepeso.BackColor = Color.Red;
                txb_sobrepeso.ForeColor = Color.Yellow;
            }
            else
            {
                txb_sobrepeso.BackColor = Color.White;
                txb_sobrepeso.ForeColor = Color.Black;
            }
        }
        #endregion

        #region Evento Lost Focus de txb_charge
        private void txb_price_hand_video_video_LostFocus(object sender, EventArgs e)
        {
            ActualizaCargosTotales();
            txb_price_hand_video.ReadOnly = true;
        }
        #endregion

        //#region Metodo click del boton Save 2
        //private void btn_save2_Click(object sender, EventArgs e)
        //{
        //    DioClickGrid = 0;
        //    //save record
        //    //if (CheckUncheckvideo == "Traia y le quito el video") 
        //    //{

        //    //txb_charge.Text = Convert.ToString(Convert.ToDecimal(txb_charge.Text) - Convert.ToDecimal(CostosAdicionales.Tables[0].Select("id = 1")[0].ItemArray[3].ToString()) + Convert.ToDecimal(txb_price_hand_video.Text));
        //    //}
        //    //else if (CheckUncheckvideo == "Trae video")
        //    //{
        //    //    txb_charge.Text = txb_charge.Text;
        //    //}
        //    //else
        //    //{
        //    String _Charge = Convert.ToString(Convert.ToDecimal(txb_charge.Text) + Convert.ToDecimal(txb_price_video.Text) + Convert.ToDecimal(txb_price_hand_video.Text));
        //    //}
        //    tabla = "TB_TANDEMUP";
        //    campos = @" sequence = " + txb_seq.Text + ", " +
        //              " name = '" + txb_name.Text + "', " +
        //              " lastname = '" + txb_lastname.Text + "', " +
        //              " email = '" + txb_email.Text + "', " +
        //              " jumptype = '" + cmb_jumptype.Text + "', " +
        //              " pricejump = " + Convert.ToString( Convert.ToInt32(Convert.ToDecimal( txb_charge.Text))) + ", " +
        //              " charge = " + Convert.ToString(Convert.ToInt32( Convert.ToDecimal(_Charge))) + ", " +
        //              " paymant = " + Convert.ToString(Convert.ToInt32( Convert.ToDecimal(txb_payment.Text )))+ ", " +
        //              " release = " + _release.ToString() + ", " +
        //              " REFERENCED_BY = '" + txb_referenceby.Text + "'";
        //    condicion = " where idtandemup = " + _idtandemup.ToString();
        //    conexion.UpdateTabla(campos, tabla, condicion);

        //    if (chk_video.Checked == true)
        //    {
        //        tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
        //        campos = @" price = " + txb_price_video.Text;
        //        condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices = 1 ";
        //        conexion.UpdateTabla(campos, tabla, condicion);
        //    }

        //    if (chk_handvideo.Checked == true)
        //    {
        //        tabla = "TB_TANDEMUP_ADITIONAL_SERVICES";
        //        campos = @" price = " + txb_price_hand_video.Text;
        //        condicion = " where idtandemup = " + _idtandemup.ToString() + " and idaditionalservices = 2 ";
        //        conexion.UpdateTabla(campos, tabla, condicion);
        //    }


        //    InicializaObjetos();
        //    inicializagridview();
        //    btn_save.Enabled = false;
        //    btn_save2.Enabled = false;

        //    grp_Grupo.Enabled = true;
        //    btn_processreserve.Enabled = true;
        //    btn_add.Enabled = true;
        //    btn_del.Enabled = true;
        //    btn_findpropspect.Enabled = true;

        //}
        //#endregion

        #region Evento user delete Row del Datagrid Tandem
        private void dg_tandemup_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TandemEditado = 0;
            TandemEnUso(TandemEditado, 1);
            InicializaObjetos();
            inicializagridview();
        }
        #endregion 

        #region Evento click del chk_release
        private void chk_release_Click(object sender, EventArgs e)
        {
            conexion.RegistroLog(misglobales.usuario_idusuario, "TandemUp", "Manual Release for TandemUp: " + txb_name.Text + " " + txb_lastname.Text);
        }
        #endregion 

        #region Keypress del txb_peso
        private void txb_peso_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Evento Keypress del txb_height
        private void txb_height_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Evento checked changed del chk_rtavideo
        private void chk_rtavideo_CheckedChanged(object sender, EventArgs e)
        {
            if (txb_name.Text != "" )
            {
                decimal Registro = Convert.ToDecimal(CostosAdicionales.Tables[0].Select("descripcion = 'VIDEO RENTA'")[0].ItemArray[3].ToString());
                Int32 Servicio = Convert.ToInt32(CostosAdicionales.Tables[0].Select("DESCRIPCION = 'VIDEO RENTA'")[0].ItemArray[0].ToString());
                //decimal Chargefinal = 0;
                if (chk_rtavideo.Checked == true)
                {
                    _aditional_services = Convert.ToDecimal(Registro);
                    //Chargefinal = Convert.ToDecimal(txb_charge.Text) + _aditional_services;
                    txb_pricevideorent.Text = _aditional_services.ToString();
                    //txb_charge.Text = Chargefinal.ToString();
                    GuardaServicios(Servicio, txb_pricevideorent.Text);
                    chk_handvideo.Checked = false;
                }
                else
                {
                    _aditional_services = Convert.ToDecimal(Registro);
                    //Chargefinal = Convert.ToDecimal(txb_charge.Text) - _aditional_services;
                    txb_pricevideorent.Text = "0.00";
                    BorraServicios(Servicio);
                    // txb_charge.Text = Chargefinal.ToString();
                }
                ActualizaCargosTotales();
            }
        }
        #endregion 

        #region Imprime TICKET BIXOLON
        private void Imprimeticket(String Jump_Type_Code, String FolioTicket, String Jumper)
        {
            Int32 IntHeight = 0;
            IntHeight = misglobales._impresora_height;
            
            if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false) { MessageBox.Show("BIXOLON is OFF"); return; }
            String _Width = "90.5", Height = "44", Margin_X = "0", Margin_Y = "0";
            int MM2D = 8;
            MM2D = BIXOLONSkyDiveCuautla.BXLLIB.GetPrinterResolution() < 300 ? 8 : 12;

            int nPaper_Width = Convert.ToInt32(double.Parse(_Width) * MM2D);
            int nPaper_Height = IntHeight; //Convert.ToInt32(double.Parse(Height) * MM2D); Para pueeto 361 / 240
            int nMarginX = Convert.ToInt32(double.Parse(Margin_X) * MM2D);
            int nMarginY = Convert.ToInt32(double.Parse(Margin_Y) * MM2D);

            int nSpeed = 7;
            int nDensity = Convert.ToInt32(20);

            bool bAutoCut = false;
            bool bReverseFeeding = false; //TRUE 343 en height


            strPrinterName = "BIXOLON SLP-T400";

            int nSensorType = BIXOLONSkyDiveCuautla.BXLLIB.CONTINUOUS;
            //si detecta una marca negra lo corta
            //nSensorType = BIXOLONSkyDiveCuautla.BXLLIB.BLACKMARK;

            //si lo queremos contiuo usamos
            //nSensorType = BIXOLONSkyDiveCuautla.BXLLIB.CONTINUOUS;

            //	Set the label start
            BIXOLONSkyDiveCuautla.BXLLIB.StartLabel();


            //	Set Label and Printer
            //BIXOLONSkyDiveCuautla.BXLLIB.SetConfigOfPrinter(BIXOLONSkyDiveCuautla.BXLLIB.SPEED_50, 17, BIXOLONSkyDiveCuautla.BXLLIB.TOP, false, 0, true);
            BIXOLONSkyDiveCuautla.BXLLIB.SetConfigOfPrinter(nSpeed, nDensity, BIXOLONSkyDiveCuautla.BXLLIB.BOTTOM, bAutoCut, 0, bReverseFeeding);
            BIXOLONSkyDiveCuautla.BXLLIB.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 16);// 16 por 0



            BIXOLONSkyDiveCuautla.BXLLIB.PrintDirect("STd"); //Direct Thermal
            //BIXOLONSkyDiveCuautla.BXLLIB.PrintDirect("STt"); //Termal transfer

            BIXOLONSkyDiveCuautla.BXLLIB.ClearBuffer();

            //BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(370, 40, 760, 150, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            ////imprimo 2  lineas en blanco
            //BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(18, 164, 798, 170, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            //BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(18, 410, 784, 415, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);

            BIXOLONSkyDiveCuautla.BXLLIB.PrintTrueFontLib(20, 60, "Arial", 14, 0, true, true, false, "Jump Ticket ");

            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(525, 1, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "No transferible");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 190, BIXOLONSkyDiveCuautla.BXLLIB.ENG_22X34, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, Jumper.ToString());
            //BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(60, 10, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, DateTime.Now.ToString());

            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 140, BIXOLONSkyDiveCuautla.BXLLIB.ENG_24X38, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, Jump_Type_Code);
            BIXOLONSkyDiveCuautla.BXLLIB.Print1DBarcode(350, 20, BIXOLONSkyDiveCuautla.BXLLIB.CODE39, 2, 4, 70, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, FolioTicket);


            BIXOLONSkyDiveCuautla.BXLLIB.Prints(1, 1);

            //	Set the Label End
            BIXOLONSkyDiveCuautla.BXLLIB.EndLabel();

            //	Disconnect Printer Driver
            BIXOLONSkyDiveCuautla.BXLLIB.DisconnectPrinter();


        }
        #endregion 

        #region Cuando se este cerrando la forma
        private void Frm_Tandemup_FormClosing(object sender, FormClosingEventArgs e)
        {

            TandemEditado = 0;

            TandemEnUso(TandemEditado, 1);
        }
        #endregion 

        #region Evento click del boton Refresh
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            CamposAlerta(false, true);
            TandemEditado = 0;

            TandemEnUso(TandemEditado, 1);

            gpo_tandemup.Enabled = true;
            InicializaObjetos();
            inicializagridview();
            btn_save.Enabled = false;
            btn_save2.Enabled = false;

            grp_Grupo.Enabled = true;
            btn_processreserve.Enabled = true;
            btn_add.Enabled = true;
            btn_del.Enabled = true;
            btn_findpropspect.Enabled = true;
        }
        #endregion 

        #region Evento click del boton Mnifest Modify
        private void btn_manifestmodify_Click(object sender, EventArgs e)
        {

            // Desbloquea los tandems que ya estan manifestados para ser editados
            misglobales.TandemName = txb_name.Text + " " + txb_lastname.Text;
            Menus = new ConectaBD();
            Menus.RegistroLog(misglobales.usuario_idusuario, "TandemUp " + misglobales.TandemName + " EDITAD@" , "manifestado-" + EstaManifestado + " video-" + chk_video.Checked + " Video-$" + txb_price_video.Text + " Hand Video-" + chk_handvideo.Checked + " HandVideo-$" + txb_price_hand_video.Text + " Gold-" + chk_gold.Checked + " Video Rent-" + chk_rtavideo.Checked + " Video Rent-$" + txb_pricevideorent.Text + " Salto-$" + txb_charge.Text + " Total Charge-$" + txb_totalcharges.Text + " Total Payment-$" + txb_payment.Text);
            CamposAlerta(true, true);
            btn_manifest.Enabled = true;
            btn_manifestmodify.Image = SkyDiveCuautla.Properties.Resources.Unlock;



        }
        #endregion 

        #region Evento click del boton Manifest
        private void btn_manifest_Click(object sender, EventArgs e)
        {

            btn_manifest.Enabled = false;

            Frm_Modify_Manifest ModificaManifiesto = new Frm_Modify_Manifest();

            if (ModificaManifiesto.CanFocus == false)
            {
                //ModificaManifiesto.Show();

                //MODIFICACIÓN EN CURSO 8 ABRIL 2017
                // abrir el vuelo y marcar el TANDEMUP en amarillo


                conexion.UpdateTabla(" idestatus = 6, fechacierrevuelo = null ", "dbo.TB_VUELOS", "where idvuelo = " + dg_tandemup.Rows[dg_tandemup.CurrentRow.Index].Cells[33].Value.ToString());
                conexion.UpdateTabla("upgrade = 1, idusuario_upgrade = " + misglobales.usuario_idusuario + ", upgradedate = getdate()", "TB_MANIFIESTO", " WHERE idtandem = " + misglobales._idtandemup);




                btn_save2.Enabled = true;
                btn_save.Enabled = true;
            }
            else
            {
                MessageBox.Show("El formulario solicitado ya se encuentra abierto");
            }

        }
        #endregion 

        #region Evento click del boton btn_videorent
        private void btn_videorent_Click(object sender, EventArgs e)
        {
            String FolioDelTicket = "", sellomes = "00", foliomes = "", foliodia = "", sellodia = "00";

            foliomes = Convert.ToString(DateTime.Now.Month);
            if (foliomes.ToString().Length == 1) { sellomes = "0"; } else { sellomes = ""; }
            foliomes = sellomes + "" + foliomes;

            foliodia = Convert.ToString(DateTime.Now.Day);
            if (foliodia.ToString().Length == 1) { sellodia = "0"; } else { sellodia = ""; }
            foliodia = sellodia + "" + foliodia;

            DateTime expirationDate = DateTime.Now; // random date
            string lastTwoDigitsOfYear = expirationDate.ToString("yy");

            FolioDelTicket = "0" + misglobales.oficina_id_oficina + "" + lastTwoDigitsOfYear + "" + foliomes + "" + foliodia + "" + txb_seq.Text;

            DialogResult resultado = MessageBox.Show("Are you sure will be print a video rent ticket?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {


                if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false)
                {
                    MessageBox.Show("Please TURN ON the BIXOLON T400 printer");
                }
                else
                {
                    Imprimeticket("TANDEM/VIDEO RENT $" + txb_pricevideorent.Text, FolioDelTicket, txb_lastname.Text + ' ' + txb_name.Text);

                    conexion.UpdateTabla("ticket_videorent= ticket_videorent + 1", "[TB_TANDEMUP]", " WHERE idtandemup = " + _idtandemup);

                    MessageBox.Show("Ticket Video Rent Printed successfully");
                }
            }


        }
        #endregion 

        #region Evento click del boton sobre peso
        private void BTN_IMPRIMESOBREPESO_Click(object sender, EventArgs e)
        {
            String FolioDelTicket = "", sellomes = "00", foliomes = "", foliodia = "", sellodia = "00";

            foliomes = Convert.ToString(DateTime.Now.Month);
            if (foliomes.ToString().Length == 1) { sellomes = "0"; } else { sellomes = ""; }
            foliomes = sellomes + "" + foliomes;

            foliodia = Convert.ToString(DateTime.Now.Day);
            if (foliodia.ToString().Length == 1) { sellodia = "0"; } else { sellodia = ""; }
            foliodia = sellodia + "" + foliodia;

            DateTime expirationDate = DateTime.Now; // random date
            string lastTwoDigitsOfYear = expirationDate.ToString("yy");

            FolioDelTicket = "0" + misglobales.oficina_id_oficina + "" + lastTwoDigitsOfYear + "" + foliomes + "" + foliodia + "" + txb_seq.Text;

            DialogResult resultado = MessageBox.Show("Are you sure will be print a OVENWEIGHT ticket?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {


                if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false)
                {
                    MessageBox.Show("Please TURN ON the BIXOLON T400 printer");
                }
                else
                {
                    Imprimeticket("TANDEM/OVENWEIGHT $" + txb_sobrepeso.Text, FolioDelTicket, txb_lastname.Text + ' ' + txb_name.Text);

                    //conexion.UpdateTabla("ticket_videorent= ticket_videorent + 1", "[TB_TANDEMUP]", " WHERE idtandemup = " + _idtandemup);

                    MessageBox.Show("Ticket OVENWEIGHT Printed successfully");
                }
            }
        }
        #endregion

        private void txb_seq_TextChanged(object sender, EventArgs e)
        {
            //CamposEnedicion = true;
        }

        private void txb_name_TextChanged(object sender, EventArgs e)
        {
            //CamposEnedicion = true;
        }

        private void txb_lastname_TextChanged(object sender, EventArgs e)
        {
            //CamposEnedicion = true;
        }

        private void txb_email_TextChanged(object sender, EventArgs e)
        {
            //CamposEnedicion = true;
        }

        private void txb_charge_TextChanged(object sender, EventArgs e)
        {
            //CamposEnedicion = true;
        }

        private void txb_payment_TextChanged(object sender, EventArgs e)
        {
            //CamposEnedicion = true;
        }

        private void txb_seq_KeyPress(object sender, KeyPressEventArgs e)
        {
            CamposEnedicion = true;
        }

        private void txb_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            CamposEnedicion = true;
        }

        private void txb_lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            CamposEnedicion = true;
        }

        private void txb_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            CamposEnedicion = true;
        }

        private void cmb_jumptype_KeyPress(object sender, KeyPressEventArgs e)
        {
            CamposEnedicion = true;
        }

        private void txb_charge_KeyPress(object sender, KeyPressEventArgs e)
        {
            CamposEnedicion = true;
        }


    }
}
