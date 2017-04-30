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
    public partial class Frm_ticket : Form
    {

        #region Zona de variables
        String sql, _code, condicion, campos, tabla, _idticketbalance;
        DataSet dsjumper, dsjumptype;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        Int32 _Ledger = 0;
        String strPrinterName = "BIXOLON SLP-T400";
        Int32 CanNotBuyTickets = 0;
        String St_USPA_Expires;
        #endregion 

        #region Constructor de la forma Frm_ticket
        public Frm_ticket()
        {
            InitializeComponent();
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

        #region Inicializa DataGridView 
        private void inicializagridview()
        {
            condicion = @"  where ttb.idestatus = 1 and ttb.nombre = '" + cmb_name.Text + "'";
            dg_tickets.EnableHeadersVisualStyles = false;
            dg_tickets.DataSource = conexion.ConsultaTickets(condicion);  //getdatcmba(fuente;
            dg_tickets.Columns[0].Width = 25; //ID
            dg_tickets.Columns[0].Visible = false;
            dg_tickets.Columns[1].Width = 25; //idjumper
            dg_tickets.Columns[1].Visible = false;
            dg_tickets.Columns[2].Width = 25; //codejumper
            dg_tickets.Columns[2].Visible = false;
            dg_tickets.Columns[3].Width = 25; //nombre
            dg_tickets.Columns[3].Visible = false;
            dg_tickets.Columns[4].Width = 200; //folioticket
            dg_tickets.Columns[4].Visible = true;
            dg_tickets.Columns[5].Width = 200; //jumptypecode
            dg_tickets.Columns[5].Visible = true;
            dg_tickets.Columns[6].Width = 150; //price
            dg_tickets.Columns[6].Visible = true;
            dg_tickets.Columns[7].Width = 200; //updatedate
            dg_tickets.Columns[7].Visible = true;
            dg_tickets.Columns[8].Width = 200; //validity
            dg_tickets.Columns[8].Visible = true;
            dg_tickets.Columns[9].Width = 25; //IDoficina
            dg_tickets.Columns[9].Visible = false;
            dg_tickets.Columns[10].Width = 300; //office name
            dg_tickets.Columns[10].Visible = false;
            dg_tickets.Columns[11].Width = 100; //active
            dg_tickets.Columns[11].Visible = true;
            dg_tickets.Columns[12].Width = 300; //nota
            dg_tickets.Columns[12].Visible = true;

            u.Formatodgv(dg_tickets);



        }
        #endregion

        #region Metodo al seleccionar un Jump Type
        private void JumTypeSeleccionado()
        {
            Decimal preciosalto=0;

            if (cmb_defaultjumptype.SelectedIndex >= 0 && cmb_name.SelectedIndex >=0)
            {

                



                string sql = @" select idjumptype, codigo, jump_type, Altitud, price from dbo.CT_JUMP_TYPE ";
                DataSet dsjumptype = conexion.ConsultaUniversal(sql, " where idestatus = 1 and jump_type = '" + cmb_defaultjumptype.Text + "'", "CT_JUMP_TYPE");
                if (dsjumptype.Tables[0].Rows.Count > 0)
                {
                    // Vaslidar que el tipo de salto seleccionado para el jumper no exita en jump_excepcions, en caso de existir, ese se tomará como precio valido.
                    preciosalto = u.JumperException(misglobales.jumperid, misglobales.jumper_code, Convert.ToString(dsjumptype.Tables[0].Rows[0].ItemArray[2].ToString()));

                    if (preciosalto != 0)
                    {
                        txb_price.Text = preciosalto.ToString();
                        lbl_price.Text = preciosalto.ToString();
                        lbl_price.Visible = false;
                        //btn_sale.Enabled = true;
                    }
                    else
                    {
                        txb_price.Text = Convert.ToString(dsjumptype.Tables[0].Rows[0].ItemArray[4].ToString());  //string.Format("{0:C}",dsjumptype.Tables[0].Rows[0].ItemArray[4].ToString());
                        lbl_price.Text = dsjumptype.Tables[0].Rows[0].ItemArray[4].ToString();
                        lbl_price.Visible = false;
                        //btn_sale.Enabled = false;
                    }
                    Calculo();
                    if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
                    {
                        MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                        CanNotBuyTickets = 1;
                    }
                    else
                    {
                        CanNotBuyTickets = 0;


                    }
                    if (CanNotBuyTickets == 1)
                    {
                        groupBox2.Enabled = false;
                        groupBox3.Enabled = false;
                        lbl_jumpername.Text = lbl_jumpername.Text + " Your licence or Member has been expired !!!  CAN NOT buy tickets";
                    }
                }
                conexion.CloseDB();

                inicializagridview();


            }


        }
        #endregion 

        #region Metodo de calculo 
        public void Calculo()
        {
            Decimal _Balance = 0;
            Decimal _Subtotal = 0;
            Decimal _Importe = 0;
            Decimal _Payment = 0;
            Boolean SaltarSinSaldo = false;

            _Payment = Convert.ToDecimal(txb_payment.Text);
             _Balance = Convert.ToDecimal(u.Balance()) * -1 ;
            _Subtotal = Convert.ToDecimal(lbl_subtotal.Text);
            _Importe = Convert.ToDecimal(_Subtotal - (_Balance + _Payment));
            lbl_debe.Text = "0.00";

            String JumperName;

            if (misglobales._name  == "")
            {
                JumperName = cmb_name.Text;
            }
            else
            {
                JumperName = misglobales._name;
            }

                sql = @"SELECT J.idjumper,  J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance,  Debit_Padlock, All_Day_Jump_padlock, Allow_Override_Padlock,
                           convert(bit,Allow_FirstJump ), j.Balance_Jump, j.codigo, JT.codey, jt.price, jt.charge_type_description, jt.jump_type, j.uspa_expires
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode where j.nombre = '" + JumperName + "' order by  J.NOMBRE";
                try
                {
                    dsjumper = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try consult jumper " + ex.Message);
                }



                St_USPA_Expires = dsjumper.Tables[0].Rows[0].ItemArray[17].ToString();


                if (dsjumper.Tables[0].Rows.Count > 0)
                {
                   

                    SaltarSinSaldo = Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[7].ToString());
                    if (txb_amount.Text == "") { txb_amount.Text = "0"; }


                    if ((SaltarSinSaldo != true) && (_Balance <= 0 ) && (_Importe!=0))
                {
                    //MessageBox.Show("The balance of the jumper is insufficient, payment breakdown required");
                    //txb_currentbalance.BackColor = Color.Red;
                    //txb_currentbalance.ForeColor = Color.White;
                    btn_sale.Enabled = false;
                    label5.Visible = false;
                }
                else
                {
                    //txb_currentbalance.BackColor = Color.Green;
                    //txb_currentbalance.ForeColor = Color.Yellow;
                    btn_sale.Enabled = true;
                    label5.Visible = true;
                    label5.Text = misglobales._name.ToString() + " - Allow transaction with no balance = " + SaltarSinSaldo;

                }
                }

            if (txb_currentbalance.Text != "")
            {
                Decimal SaldoJumper = -1;

                try
                {
                    SaldoJumper =  Decimal.Parse(txb_currentbalance.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error balance value, notify system administrator " + ex.Message);
                }
            finally
                {
                    if (SaldoJumper < 0)
                    {
                        //Tiene saldo a favor
                        txb_currentbalance.BackColor = Color.Green;
                        txb_currentbalance.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        //No tiene saldo
                        txb_currentbalance.BackColor = Color.Red;
                        txb_currentbalance.ForeColor = Color.White;
                    }
                }
            }
           
        }
        #endregion 

        #region Metodo al seleccionar un Jump Type
        private void JumperSeleccionado()
        {
            if (cmb_name.SelectedIndex >= 0)
            {
                txb_payment.Text = "0.00";
                Calculo();
                if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
                {
                    MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                    CanNotBuyTickets = 1;
                }
                else
                {
                    CanNotBuyTickets = 0;


                }
                if (CanNotBuyTickets == 1)
                {
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    lbl_jumpername.Text = lbl_jumpername.Text + " Your licence or Member has been expired !!!  CAN NOT buy tickets";
                }
                string sql = @" select idjumper, codigo, nombre, balance, balance_jump from dbo.CT_JUMPER ";
                DataSet dsjumper = conexion.ConsultaUniversal(sql, " where idestatus = 1 and NOMBRE = '" + cmb_name.Text + "'", "CT_JUMPER");
                if (dsjumper.Tables[0].Rows.Count > 0)
                {

                    misglobales.jumper_code = dsjumper.Tables[0].Rows[0].ItemArray[1].ToString();
                    txb_currentbalance.Text = Convert.ToString(Convert.ToDecimal(u.Balance()));// string.Format("{0:C}", Convert.ToDecimal(u.Balance()));
                    lbl_jumpername.Text = cmb_name.Text;
                    misglobales.jumperid = Convert.ToInt32(dsjumper.Tables[0].Rows[0].ItemArray[0].ToString());
               
                    
                }
                conexion.CloseDB();
                inicializagridview();
            }
            else
            {
                txb_currentbalance.Text = "0.00"; // string.Format("{0:C}", "0.00");
                lbl_jumpername.Text = cmb_name.Text;
            }

        }
        #endregion

        #region IniciaObjetos()
        public void IniciaObjetos()
        {
            label5.Visible = false;
            //carga combo box name
            try
            {
                sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
                dsjumper = conexion.ConsultaUniversal(sql, "WHERE J.idjumper > 0 order by  J.NOMBRE", "CT_JUMPER");
                cmb_name.DataSource = dsjumper.Tables[0].DefaultView;
                cmb_name.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NOMBRE");
                cmb_name.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_name.ValueMember = "NOMBRE";
                cmb_name.SelectedItem = null;
                
                
                
                if (misglobales._impresora_height == 361)
                {
                    rb_361.Checked = true;
                }
                else
                    if (misglobales._impresora_height == 240)
                    {
                        rb_240.Checked = true;
                    }
                conexion.CloseDB();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro try load combo name information: " + ex.Message);
            }

            try
            {
                sql = @"select idjumptype, jump_type From dbo.CT_JUMP_TYPE WHERE idestatus = 1 ORDER BY orden";
                dsjumptype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
                
                cmb_defaultjumptype.DataSource = dsjumptype.Tables[0].DefaultView;
                cmb_defaultjumptype.AutoCompleteCustomSource = u.LoadAutoComplete(dsjumptype, "jump_type");
                cmb_defaultjumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_defaultjumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_defaultjumptype.ValueMember = "jump_type";
                cmb_defaultjumptype.SelectedItem = null;
                conexion.CloseDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try load combo jump type information: " + ex.Message);
            }

            dsjumptype.Dispose();
            if (misglobales._name != "")
            {

                cmb_name.SelectedItem = cmb_name.FindString(misglobales._name);
                cmb_name.SelectedValue = misglobales._name;
                //txb_currentbalance.Text = Convert.ToString(Convert.ToDecimal(u.Balance())); //string.Format("{0:C}", Convert.ToDecimal(u.Balance()));
                Decimal BalanceJumper = 0;
                BalanceJumper = Convert.ToDecimal(u.Balance());
                //txb_currentbalance.Text = Convert.ToString(BalanceJumper);
                txb_currentbalance.Text = BalanceJumper.ToString();
                if (BalanceJumper <= 0)
                {
                    txb_currentbalance.BackColor = Color.Green;
                    txb_currentbalance.ForeColor = Color.Yellow;
                }
                else if (BalanceJumper > 0)
                {
                    txb_currentbalance.BackColor = Color.Red;
                    txb_currentbalance.ForeColor = Color.White;
                
                }

                try
                {

                    cmb_defaultjumptype.SelectedItem = cmb_defaultjumptype.FindString(misglobales.jumptype);
                    //cmb_defaultjumptype.ValueMember = misglobales.jumptype;
                    cmb_defaultjumptype.SelectedValue = misglobales.jumptype;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                inicializagridview();
                Calculo();

                if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
                {
                    MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                    CanNotBuyTickets = 1;
                }
                else
                {
                    CanNotBuyTickets = 0;
                    

                }
                if (CanNotBuyTickets == 1)
                {
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    lbl_jumpername.Text = lbl_jumpername.Text ;
                }
               

            }
            else 
            {
                txb_currentbalance.Text = "0.00";// string.Format("{0:C}", "0.00");
                txb_price.Text = string.Format("${0:C}","0.00");
            }
            lbl_jumpername.Text = cmb_name.Text;
            JumTypeSeleccionado();

            misglobales._BreakDown = 0;
            misglobales._TransaccionLedger = "-TICKET";
            sql = "select max(substring(code,1,5))+1 from dbo.TB_LEDGER";
            DataSet dsconsecutivo = conexion.ConsultaUniversal(sql, "", "TB_LEDGER");
            _code = dsconsecutivo.Tables[0].Rows[0].ItemArray[0].ToString() + misglobales._TransaccionLedger;
            misglobales._TransaccionLedger = _code;
            _Ledger = Convert.ToInt32(dsconsecutivo.Tables[0].Rows[0].ItemArray[0].ToString());
            txb_amount.Text = "1";


            //Si no esta encendida la impresora que notifique
            try
            {
                if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false)
                    MessageBox.Show("Please turn ON the BIXOLON T400");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRINTER IS NOT INSTALLED, PLEASE VERIFY AND TRY AGAIN : ( " +  ex.Message + " ) ");
            }


            

            if (CanNotBuyTickets == 1)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                lbl_jumpername.Text = lbl_jumpername.Text ;
            }


        }
        #endregion 

        #region Load de la forma Frm_ticket
        private void Frm_ticket_Load(object sender, EventArgs e)
        {
            Int32 num = 0;
            num = num + 1;
            IniciaObjetos();

 
        }
        #endregion 

        #region Evento click del boton Exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento KeyPress del txb_amount solo permitirá valores numericos
        private void txb_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                //lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text));
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

        #region Evento Selected Index Changed del cmb_defaultjumptype
        private void cmb_defaultjumptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
            if (txb_amount.Text != "")
            {
                if (Convert.ToInt32(txb_amount.Text) > 0) { lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text)); }
            }
        }
        #endregion 

        #region Evento TextChanged del txb_amount
        private void txb_amount_TextChanged(object sender, EventArgs e)
        {
            if (txb_amount.Text != "" && lbl_price.Text != "")
            {
                lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text));
                Calculo();
                if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
                {
                    MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                    CanNotBuyTickets = 1;
                }
                else
                {
                    CanNotBuyTickets = 0;


                }
                if (CanNotBuyTickets == 1)
                {
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    lbl_jumpername.Text = lbl_jumpername.Text + " Your licence or Member has been expired !!!  CAN NOT buy tickets";
                }
            }
        }
        #endregion 

        #region Evento Selected Value Changed en el combo Jump Type
        private void cmb_defaultjumptype_SelectedValueChanged(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
            if (txb_amount.Text != "")
            {
                if (Convert.ToInt32(txb_amount.Text) > 0) { lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text)); }
            }
        }
        #endregion

        #region Evento Text Changed del combo Jump Type
        private void cmb_defaultjumptype_TextChanged(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
            if (txb_amount.Text != "")
            {
                if (Convert.ToInt32(txb_amount.Text) > 0) { lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text)); }
            }
        }
        #endregion 

        #region Evento Text Update del combo Jump Type
        private void cmb_defaultjumptype_TextUpdate(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
            if (txb_amount.Text != "")
            {
                if (Convert.ToInt32(txb_amount.Text) > 0) { lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text)); }
            }
        }
        #endregion

        #region Evento Selection Changed Committed del cmb_defaultjumptype
        private void cmb_defaultjumptype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            JumTypeSeleccionado();
            if (txb_amount.Text != "" && lbl_price.Text != "")
            {
                if (Convert.ToInt32(txb_amount.Text) > 0) { lbl_subtotal.Text = Convert.ToString(Convert.ToDecimal(txb_amount.Text) * Convert.ToDecimal(lbl_price.Text)); }
            }
        }
        #endregion

        #region Evento Selected Index Changed del combo name
        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            //JumperSeleccionado();
        }
        #endregion 

        #region Evento Selected Value Changed del cmb_name
        private void cmb_name_SelectedValueChanged(object sender, EventArgs e)
        {
            //JumperSeleccionado();
        }
        #endregion 

        #region Evento click del btn_payment
        private void btn_payment_Click(object sender, EventArgs e)
        {

            txb_payment.Enabled = true;

            Frm_Payment_Breakdown FrmPayment = new Frm_Payment_Breakdown();
            tmr_payment.Start();
            FrmPayment.Show();
        }
        #endregion 

        #region Evento tick tmr_payment
        private void tmr_payment_Tick(object sender, EventArgs e)
        {
            txb_payment.Text = misglobales._TotalBalance.ToString();

            Decimal _Pagado = 0;
            Decimal _Saldo = 0;



            if (misglobales._utilizandoPayment == false) 
            {
                _Pagado = Convert.ToDecimal(txb_payment.Text);
                _Saldo = Convert.ToDecimal(txb_currentbalance.Text);


                txb_currentbalance.Text = Convert.ToString( _Saldo + _Pagado);
                Calculo();
                
                if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
                {
                    MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                    CanNotBuyTickets = 1;
                }
                else
                {
                    CanNotBuyTickets = 0;
                }
                if (CanNotBuyTickets == 1)
                {
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    lbl_jumpername.Text = lbl_jumpername.Text + " Your licence or Member has been expired !!!  CAN NOT buy tickets";
                }
                tmr_payment.Stop(); 
            }
        }
        #endregion 
        
        #region Imprime TICKET BIXOLON
        private void Imprimeticket(String Jump_Type_Code, String FolioTicket, String Jumper)
        {
            Int32 IntHeight = 0;
            if (rb_240.Checked == true)
            {
                IntHeight = 240;
            }
            else if (rb_361.Checked == true)
            {
                IntHeight = 361;
            }
            if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false) { MessageBox.Show("BIXOLON is OFF"); return; }
            String _Width="90.5", Height="44", Margin_X="0", Margin_Y="0";
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
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 190, BIXOLONSkyDiveCuautla.BXLLIB.ENG_22X34, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true,  Jumper.ToString());
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

        #region Imprime TICKET OKIPOS
        private void Imprimeticketokipos(String Jump_Type_Code, String FolioTicket, String Jumper)
        {
            if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false) { MessageBox.Show("BIXOLON is OFF"); return; }
            String _Width = "90.5", Height = "44", Margin_X = "0", Margin_Y = "0";
            int MM2D = 8;
            MM2D = BIXOLONSkyDiveCuautla.BXLLIB.GetPrinterResolution() < 300 ? 8 : 12;

            int nPaper_Width = Convert.ToInt32(double.Parse(_Width) * MM2D);
            int nPaper_Height = 240; //Convert.ToInt32(double.Parse(Height) * MM2D);
            int nMarginX = Convert.ToInt32(double.Parse(Margin_X) * MM2D);
            int nMarginY = Convert.ToInt32(double.Parse(Margin_Y) * MM2D);

            int nSpeed = 7;
            int nDensity = Convert.ToInt32(20);

            bool bAutoCut = false;
            bool bReverseFeeding = false; //TRUE 343 en height


            strPrinterName = "OKIPOS";

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

        #region Actualiza Saldo en Saltos
        private void BalanceJumpUpdate()
        {
            DataSet dsfoliadora;
            Int32 Foliador;
            String SelloFolio = "0000", FolioDelTicket = "", sellomes = "00", foliomes = "", foliodia = "", sellodia = "00";


            // Prepara Insert para el balance en saltos mediante un query
            tabla = "TB_TICKETS_BALANCE";
            campos = "idjumper, codejumper, nombre, folioticket,  jumptypecode, price, updatedate, validity, idoficina, idestatus, nota";
            
            Int32 _NumTicket = Convert.ToInt32(txb_amount.Text);

            for (int i = 0; i < _NumTicket; i++)
            {

                sql = @"SELECT isnull(MAX( SUBSTRING(folioticket,9,4))+1,1) FROM dbo.TB_TICKETS_BALANCE ";
                condicion = " WHERE CONVERT(VARCHAR(10),updatedate,23) = CONVERT(VARCHAR(10),GETDATE(),23) ";
                tabla = "TB_TICKETS_BALANCE";
                dsfoliadora = conexion.ConsultaUniversal(sql, condicion, tabla);
                Foliador = Convert.ToInt32(dsfoliadora.Tables[0].Rows[0].ItemArray[0].ToString());

                if (Foliador.ToString().Length == 1) { SelloFolio = "000" + Foliador.ToString(); }
                else if (Foliador.ToString().Length == 2) { SelloFolio = "00" + Foliador.ToString(); }
                else if (Foliador.ToString().Length == 3) { SelloFolio = "0" + Foliador.ToString(); }
                else if (Foliador.ToString().Length == 4) { SelloFolio = "" + Foliador.ToString(); }

                tabla = "TB_TICKETS_BALANCE";
                campos = "idjumper, codejumper, nombre, folioticket,  jumptypecode, price, updatedate, validity, idoficina, idestatus, nota";

                foliomes = Convert.ToString( DateTime.Now.Month);
                if (foliomes.ToString().Length == 1) { sellomes = "0"; } else { sellomes = ""; }
                foliomes = sellomes +""+ foliomes;

                foliodia = Convert.ToString(DateTime.Now.Day);
                if (foliodia.ToString().Length == 1) { sellodia = "0"; } else { sellodia = ""; }
                foliodia = sellodia + "" + foliodia;

                DateTime expirationDate =  DateTime.Now; // random date
                string lastTwoDigitsOfYear = expirationDate.ToString("yy");


                //FolioDelTicket = DateTime.Now.Year +""+ foliomes +""+ foliodia  +""+ SelloFolio.ToString();
                FolioDelTicket = "0" + misglobales.oficina_id_oficina + "" + lastTwoDigitsOfYear + "" + foliomes + "" + foliodia + "" + SelloFolio.ToString();
                sql = @"SELECT " + misglobales.jumperid + ", '" + misglobales.jumper_code + "', '" + cmb_name.Text + "', '" +FolioDelTicket + "' as folioticket, '" + cmb_defaultjumptype.Text + "', " + txb_price.Text + ", getdate(), getdate(), " + misglobales.oficina_id_oficina + ", 1, 'Ticket vendido al jumper' FROM CT_JUMP_TYPE WHERE jump_type = '" + cmb_defaultjumptype.Text + "' ";
                try
                {
                    conexion.InsertTablaQry(campos, tabla, sql);
                    if (misglobales._impresora == "okipos")
                    {
                        Imprimeticketokipos(cmb_defaultjumptype.Text, FolioDelTicket, cmb_name.Text);
                    }
                    else 
                    {
                        Imprimeticket(cmb_defaultjumptype.Text, FolioDelTicket, cmb_name.Text);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try registry balance jump, please contact system administrator" + ex.Message);
                }
            }

            // Prepara Insert para actualizar el balance y el balance en saltos en CT_JUMPER
            String tabla2 = "CT_JUMPER";
            String campos2 = @" balance = balance + (-" + txb_payment.Text + ") + "  +  lbl_subtotal.Text + "," +
                                " balance_jump = ( SELECT isnull(COUNT(folioticket), 0) FROM dbo.TB_TICKETS_BALANCE WHERE idestatus = 1 AND codejumper = '" + misglobales.jumper_code + "')";
            String condicion2 = " WHERE CODIGO = '" + misglobales.jumper_code + "'";
            try
            {
                conexion.UpdateTabla(campos2, tabla2, condicion2);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try update balance and balance jump, please contact system administrator" + ex.Message);
            }

            String tabla5 = "CT_CHARGE_TYPE";
            String sql5 = @"SELECT ctj.idjumptype, ctj.jump_type, ctct.charge_type, ctj.charge_type_description,  ctj.CODEY 
                             FROM ct_jump_type ctj 
                            INNER JOIN CT_CHARGE_TYPE ctct 
                                    ON ctj.idchargetype = ctct.idchargetype ";
            //String condicion5 = "  AND ctj.jump_type = '" + misglobales.jumptype + "'";
            String condicion5 = "  AND ctj.jump_type = '" + cmb_defaultjumptype.Text + "'";
                                                          //cmb_defaultjumptype
            try
            {
                DataSet dschargetype = conexion.ConsultaUniversal(sql5, condicion5, tabla5);

                // insertar ledger para registrar el movimiento a favor de Skydive y se vea reflejado en la columna payment
                String tabla3 = "TB_LEDGER";
                String campos3 = @"code, jumper_code, updatedate, idchargetype, charge, codigo_jumptype, transfer_amt, payment, staff_payment, idoficina, nota, name, idusuario";
                String valores3 = @"'" + _code + "', '" + misglobales.jumper_code + "', getdate(), '" + dschargetype.Tables[0].Rows[0].ItemArray[2].ToString() + "'," + Convert.ToInt32(Convert.ToDecimal(lbl_subtotal.Text)) + ", '" + dschargetype.Tables[0].Rows[0].ItemArray[1].ToString() + "', 0, (" + txb_payment.Text + "), 0, " + misglobales.oficina_id_oficina + ", 'venta de boleto(s)', '" + cmb_name.Text + "', " + misglobales.usuario_idusuario;
                
       
                conexion.InsertTabla(campos3, tabla3, valores3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try registry ledger, please contact system administrator" + ex.Message);
            }
            inicializagridview();
            txb_currentbalance.Text = Convert.ToString(Convert.ToDecimal(u.Balance())); //string.Format("{0:C}", Convert.ToDecimal(u.Balance()));
            
        }
        #endregion 

        #region Metodo Limpia campos
        private void LimpiaCampos()
        {
            txb_amount.Text = "1";
            txb_payment.Text = "0";
            Calculo();
            if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
            {
                MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                CanNotBuyTickets = 1;
            }
            else
            {
                CanNotBuyTickets = 0;


            }
            if (CanNotBuyTickets == 1)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                lbl_jumpername.Text = lbl_jumpername.Text + " Your licence or Member has been expired !!!  CAN NOT buy tickets";
            }
        }
        #endregion 

        #region Evento click del boton btn_sale
        private void btn_sale_Click(object sender, EventArgs e)
        {
            try
            {

                //misglobales._impresora = u.ImpresoraSeleccionada(misglobales._impresora);


                //Bixolon SLP-T400
                if (misglobales._impresora == "bixolont400")
                {
                    if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false)
                    {
                        MessageBox.Show("PLease TURN ON the BIXOLON T400 printer");
                    }
                    else
                    {
                        BalanceJumpUpdate();
                        LimpiaCampos();
                        inicializagridview();
                    }

                }
                else if (misglobales._impresora == "bixolonsrp350plus")
                {
                    if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false)
                    {
                        MessageBox.Show("PLease TURN ON the BIXOLON T400 printer");
                    }
                    else
                    {
                        BalanceJumpUpdate();
                        LimpiaCampos();
                        inicializagridview();
                    }

                
                }
                else if (misglobales._impresora == "okipos")
                {
                    
                        BalanceJumpUpdate();
                        LimpiaCampos();
                        inicializagridview();
           
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try ticket operation, contact system administrator " + ex.Message);
            }

        }
        #endregion 

        #region Evento Cellclick del grid dg_tickets
        private void dg_tickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cargar campos

        }
        #endregion 

        #region Evento click del btn_purchase
        private void btn_purchase_Click(object sender, EventArgs e)
        {
            //Update para colocar en cancelado el ticket
            String tabla6 = "TB_TICKETS_BALANCE";
            String campos6 = @" idestatus = 4 ";
            String condicion6 = " WHERE codejumper = '" + misglobales.jumper_code + "' and folioticket = " + lbl_ticket.Text + " and id = " + _idticketbalance;
            try
            {
                conexion.UpdateTabla(campos6, tabla6, condicion6);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try update ticket, please contact system administrator" + ex.Message);
            }

            //Ledger para aplicar un cargo a favor del jumper por el importe


            String tabla5 = "CT_CHARGE_TYPE";
            String sql5 = @"SELECT ctj.idjumptype, ctj.jump_type, ctct.charge_type, ctj.charge_type_description,  ctj.CODEY 
                             FROM ct_jump_type ctj 
                            INNER JOIN CT_CHARGE_TYPE ctct 
                                    ON ctj.idchargetype = ctct.idchargetype ";
            //String condicion5 = "  AND ctj.jump_type = '" + misglobales.jumptype + "'";
            String condicion5 = "  AND ctj.jump_type = '" + cmb_defaultjumptype.Text + "'";

            DataSet dschargetype = conexion.ConsultaUniversal(sql5, condicion5, tabla5);

            String tabla7 = "TB_LEDGER";
            String campos7 = @"code, jumper_code, updatedate, idchargetype, charge, codigo_jumptype, transfer_amt, payment, staff_payment, idoficina, nota, name, idusuario";
            String valores7 = @"'" + _code + "', '" + misglobales.jumper_code + "', getdate(), '" + dschargetype.Tables[0].Rows[0].ItemArray[2].ToString() + "'," + lbl_subtotal.Text + "*-1, '" + misglobales.jumptype + "', 0, (" + txb_payment.Text + "), 0, " + misglobales.oficina_id_oficina + ", 'Cancelación del boleto(s) al jumper', '" + cmb_name.Text + "',"+ misglobales.usuario_idusuario;

            try
            {
                conexion.InsertTabla(campos7, tabla7, valores7);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try registry ledger, please contact system administrator" + ex.Message);
            }

            txb_currentbalance.Text = Convert.ToString(Convert.ToDecimal(u.Balance()));// string.Format("{0:C}", Convert.ToDecimal(u.Balance()));

            //actualizar saldos
             tabla5 = "CT_JUMPER";
            String campos5 = @" balance = balance + (" + lbl_subtotal.Text + "*-1)," +
                                " balance_jump = ( SELECT isnull(COUNT(folioticket), 0) FROM dbo.TB_TICKETS_BALANCE WHERE idestatus = 1 AND codejumper = '" + misglobales.jumper_code + "')";
            condicion5 = " WHERE CODIGO = '" + misglobales.jumper_code + "'";
            try
            {
                conexion.UpdateTabla(campos5, tabla5, condicion5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try update balance and balance jump, please contact system administrator" + ex.Message);
            }
            lbl_ticket.Visible = false;
            btn_purchase.Enabled = false;

            LimpiaCampos();
            inicializagridview();

        }
        #endregion

        #region Evento CellDobleClick del grid dg_ticket
        private void dg_tickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            misglobales.jumptype = Convert.ToString(dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[5].Value);
            _idticketbalance = Convert.ToString(dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[0].Value);
            lbl_ticket.Visible = true;
            lbl_ticket.Text = Convert.ToString(dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[4].Value);
            txb_price.Text = Convert.ToString(dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[6].Value);
            txb_amount.Text = "1";
            cmb_defaultjumptype.SelectedItem = cmb_defaultjumptype.FindString(Convert.ToString(dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[1].Value));
            cmb_defaultjumptype.SelectedValue = Convert.ToString(dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[5].Value);
            btn_purchase.Enabled = true;

        }
        #endregion 

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void Frm_ticket_Enter(object sender, EventArgs e)
        {

        }

        private void rb_240_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_240.Checked == true)
            {
                conexion.UpdateTabla(" impresora_height = 240", "ct_usuario", " where idusuario =" + misglobales.usuario_idusuario);
            }
        }

        private void rb_361_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_361.Checked == true)
            {
                conexion.UpdateTabla(" impresora_height = 361", "ct_usuario", " where idusuario =" + misglobales.usuario_idusuario);
            }
        }




    }
}
