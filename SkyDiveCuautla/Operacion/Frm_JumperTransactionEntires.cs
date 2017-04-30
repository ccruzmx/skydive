using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Data.Sql;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_JumperTransactionEntires : Form
    {
        #region Zona de variables
        DataSet dsjumper, dsjumperto;
        DataSet dschargetype;
        DataSet dsledger;
        ConectaBD conexion = new ConectaBD();
        string condicion, campos, sql, tabla, valores;
        utilerias u = new utilerias();
        string _code = "";
        bool MakeToSave = false;

        decimal _payment=0;
        decimal  _charge=0 ;
        decimal _staff_payment=0;
        decimal _transfer_amt=0;
        #endregion 

        #region Constructor de Frm_JumperTransactionEntires
        public Frm_JumperTransactionEntires()
        {
            InitializeComponent();
            MakeToSave = true;
        }
        #endregion

        #region Actualiza currentbalance local
        private void ActualizaLocalCurrentBalance()
        {
            txb_currentbalance.Text = Convert.ToString(Convert.ToDecimal(u.Balance()) + Convert.ToDecimal(txb_payment.Text)*-1 +
            Convert.ToDecimal(txb_charge.Text) + Convert.ToDecimal(txb_staff.Text) + Convert.ToDecimal(txb_transfer.Text));
        }
        #endregion

        #region IniciaObjetos()
        public void IniciaObjetos()
        {
            lbl_jumpercode.Text = misglobales.jumper_code;
            //carga combo box name
            sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance
                      FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
            dsjumper = conexion.ConsultaUniversal(sql, "WHERE J.idjumper > 0 order by  J.NOMBRE", "CT_JUMPER"); 
            cmb_name.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_name.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NOMBRE");
            cmb_name.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_name.ValueMember = "NOMBRE";
            cmb_name.SelectedItem = null; 


            if (misglobales._name != "") 
            {
                cmb_name.SelectedItem = cmb_name.FindString(misglobales._name); 
                cmb_name.SelectedValue = misglobales._name;
            }

            dsjumperto = conexion.ConsultaUniversal(sql, "WHERE J.idjumper > 0 order by  J.NOMBRE", "CT_JUMPER"); 
            cmb_transferto.DataSource = dsjumperto.Tables[0].DefaultView;
            cmb_transferto.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NOMBRE");
            cmb_transferto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_transferto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_transferto.ValueMember = "NOMBRE";
            cmb_transferto.SelectedItem = null; 


            //Obtiene el BALANCE
            if (misglobales.jumper_code != "")
            {

                txb_currentbalance.Text = Convert.ToString( Convert.ToDecimal(u.Balance()));
                
            }
            else
            {
                txb_currentbalance.Text = "0.00";
            }
            //inicializa campos

            txb_charge.Text = "0.00";
            //txb_charge.Text = string.Format("{0:C}", Convert.ToDecimal(txb_charge.Text));

            txb_payment.Text = "0.00";
            //txb_payment.Text = string.Format("{0:C}", Convert.ToDecimal(txb_payment.Text));

            txb_staff.Text = "0.00";
            //txb_staff.Text = string.Format("{0:C}", Convert.ToDecimal(txb_staff.Text));

            txb_transfer.Text = "0.00";
            //txb_transfer.Text = string.Format("{0:C}", Convert.ToDecimal(txb_transfer.Text));
            txb_nota.Text = "";
            
            //carga combo charge type
            cmb_charge.Enabled = true;
            sql = @" SELECT charge_type, codigo, grupo FROM dbo.CT_CHARGE_TYPE ";
            tabla = "CT_CHARGE_TYPE";
            condicion = " ORDER BY SORT";
            dschargetype = conexion.ConsultaUniversal(sql, condicion, tabla);
            cmb_charge.DataSource = dschargetype.Tables[0].DefaultView;
            cmb_charge.AutoCompleteCustomSource = LoadAutoComplete(dschargetype, "charge_type");
            cmb_charge.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_charge.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_charge.ValueMember = "charge_type";
            //cmb_charge.SelectedItem = null;
            cmb_charge.SelectedItem = 1;
            //cmb_charge.SelectedText = 
            cmb_charge.Enabled = false;
            btn_save.Enabled = false;


            sql = " SELECT idoficina, Nombre  FROM dbo.CT_OFICINA order by idoficina ";
            tabla = "CT_OFICINA";
            condicion = " ";
            DataSet dsoficinas = conexion.ConsultaUniversal(sql, condicion, tabla);
            cmb_oficina.DataSource = dsoficinas.Tables[0].DefaultView;
            cmb_oficina.AutoCompleteCustomSource = LoadAutoComplete(dsoficinas, "Nombre");
            cmb_oficina.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_oficina.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_oficina.ValueMember = "idoficina";
            cmb_oficina.DisplayMember = "Nombre";
            cmb_oficina.SelectedItem = misglobales.oficina_oficina;
            cmb_oficina.Text = misglobales.oficina_oficina;


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

        #region Carga Ultimo Ledger
        private void LastLedger()
        {
            //sql = "select max(substring(code,1,6))+1 from dbo.TB_LEDGER";
            sql = "select max(idledger)+1 from dbo.TB_LEDGER";
            DataSet dsconsecutivo = conexion.ConsultaUniversal(sql, "", "TB_LEDGER");
            _code = dsconsecutivo.Tables[0].Rows[0].ItemArray[0].ToString() + misglobales._TransaccionLedger;
            lbl_jumpercode.Text = _code;
            misglobales._TransaccionLedger = _code;
        }
        #endregion 


        #region Load de Frm_JumperTransactionEntires
        private void Frm_JumperTransactionEntires_Load(object sender, EventArgs e)
        {
            IniciaObjetos();
            misglobales._TransaccionLedger = "-JMPTRN";
            
            //txb_balance.Text = string.Format("{0:C}", Convert.ToDecimal(txb_balance.Text));
            //txb_currentbalance.Enabled = true;
            //txb_currentbalance.Text = string.Format("{0:C}", Convert.ToDecimal(txb_currentbalance.Text));
            //txb_currentbalance.Enabled = false;
            tmr_currentbalance.Start();

        }
        #endregion 

        #region Evento Lost Focus de txb_charge
        private void txb_charge_LostFocus(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txb_charge.Text) > 0.00 || txb_charge.Text != "")
            {
                cmb_charge.Enabled = true;
            
            }
            else 
            {
                txb_charge.Text = "0.00";
                cmb_charge.Enabled = false;
            }

            //txb_balance.Text = string.Format("{0:C}", Convert.ToDecimal(txb_balance.Text));
            _charge = Convert.ToDecimal(txb_charge.Text);
            //txb_charge.Text = string.Format("{0:C}", Convert.ToDecimal(txb_charge.Text));
            btn_save.Enabled = true;
            MakeToSave = false;
            ActualizaLocalCurrentBalance(); 

        }
        #endregion

        #region Evento Lost Focus de txb_payment
        private void txb_payment_LostFocus(object sender, EventArgs e)
        {
            _payment = Convert.ToDecimal(txb_payment.Text);
            //txb_payment.Text = string.Format("{0:C}", Convert.ToDecimal(txb_payment.Text));
            MakeToSave = false;
            ActualizaLocalCurrentBalance();

        }
        #endregion

        #region Evento Lost Focus de txb_staff
        private void txb_staff_LostFocus(object sender, EventArgs e)
        {
            _staff_payment = Convert.ToDecimal(txb_staff.Text);
            //txb_staff.Text = string.Format("{0:C}", Convert.ToDecimal(txb_staff.Text));
            btn_save.Enabled = true;
            MakeToSave = false;
            ActualizaLocalCurrentBalance(); 
        }
        #endregion

        #region Evento Lost Focus de txb_transfer
        private void txb_transfer_LostFocus(object sender, EventArgs e)
        {
            _transfer_amt = Convert.ToDecimal(txb_transfer.Text);
            //txb_transfer.Text = string.Format("{0:C}", Convert.ToDecimal(txb_transfer.Text));
            btn_save.Enabled = true;
            MakeToSave = false;
            ActualizaLocalCurrentBalance(); 
        }
        #endregion

        #region Evento TextChanged del txb_charge
        private void txb_charge_TextChanged(object sender, EventArgs e)
        {
            MakeToSave = false;

            if (txb_charge.Text == "")
            {
                cmb_charge.Enabled = false;
            }
            else { cmb_charge.Enabled = true; }


        }
        #endregion

        #region Evento KeyPress del txb_charge
        private void txb_charge_KeyPress(object sender, KeyPressEventArgs e)
        {
            MakeToSave = false;
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

        #region Evento KeyPress del txb_payment
        private void txb_payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            MakeToSave = false;
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

        #region Evento KeyPress del txb_staff
        private void txb_staff_KeyPress(object sender, KeyPressEventArgs e)
        {
            MakeToSave = false;
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

        #region Evento KeyPress del txb_transfer
        private void txb_transfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            MakeToSave = false;
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

        #region evento click de txb_charge
        private void txb_charge_Click(object sender, EventArgs e)
        {
            txb_charge.SelectAll();
            MakeToSave = false;
        }
        #endregion

        #region evento click de txb_staff
        private void txb_staff_Click(object sender, EventArgs e)
        {
            txb_staff.SelectAll();
            MakeToSave = false;
        }
        #endregion

        #region evento click de txb_transfer
        private void txb_transfer_Click(object sender, EventArgs e)
        {
            MakeToSave = false;
            txb_transfer.SelectAll();
        }
        #endregion

        #region Actualiza Saldo en Saltos
        private void BalanceJumpUpdate()
        {

            if (cmb_charge.Text.Substring(0,3) == "110")
            {

                tabla = "TB_BALANCE_JUMP";
                campos = "idjumper, codigo, nombre, balancejump, jumptypecode, price, updatedate, idoficina";
                sql = @"SELECT " + misglobales.jumperid + ", '" + misglobales.jumper_code + "', '" + cmb_name.Text + "', (" + txb_charge.Text + " / price), '" + misglobales.jumptype + "', price, getdate(), " + misglobales.oficina_id_oficina + " FROM CT_JUMP_TYPE WHERE jump_type = '" + misglobales.jumptype + "' ";


                String tabla2 = "ctj";
                String campos2 = @"ctj.balance = case when ctj.balance = 0 then 0 
                                                      when tbbj.price is null then 0
                                                      else ctj.balance + (tbbj.balancejump * tbbj.price) end,
                                   ctj.balance_jump = tbbj.balancejump";
                String condicion2 = " FROM dbo.CT_JUMPER ctj inner join dbo.TB_BALANCE_JUMP tbbj on ctj.codigo  = tbbj.codigo and ctj.CODIGO = '" + misglobales.jumper_code + "'";

                try
                {
                    conexion.InsertTablaQry(campos, tabla, sql);

                    conexion.UpdateTabla(campos2, tabla2, condicion2);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try registry balance jump, please contact system administrator" + ex.Message);
                }
                
            }



        }
        #endregion 

        #region Metodo SalvarTRansacción
        private void SaveTransaction()
        {
            string sql = "";
            //  gravar el ledger
            tmr_currentbalance.Stop();
            try
            {
                //PREPARA CAMPOS

                string _jumper_code = misglobales.jumper_code;
                sql = @" SELECT charge_type, codigo, grupo FROM dbo.CT_CHARGE_TYPE ";
                tabla = "CT_CHARGE_TYPE";
                condicion = " WHERE charge_type = '" + cmb_charge.Text + "' ORDER BY SORT";
                dschargetype = conexion.ConsultaUniversal(sql, condicion, tabla);
                string _id_charge_type = dschargetype.Tables[0].Rows[0].ItemArray[1].ToString();  // dschargetype.Tables[0].Rows[0].ItemArray[1].ToString();


                sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance, JT.CODIGO
                                     FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
                dsjumper = conexion.ConsultaUniversal(sql, " WHERE J.NOMBRE = '" + cmb_name.Text + "'", "CT_JUMPER");
                string _codigo_jumptype = ""; // dsjumper.Tables[0].Rows[0].ItemArray[8].ToString();

                string _transfer_jumper_name = cmb_transferto.Text;


                string _idmanifestold = "";
                string _idmanifiesto = misglobales._manifiesto;
                string _manifest_line_nbr = "0";
                string _id_prospect = "";
                string _name = dsjumper.Tables[0].Rows[0].ItemArray[2].ToString();
                string _whoenteredid = "";
                string _WhoChanged_ID = "";
                string _WhenChanged = "null";
                string _BookedFromTeam = "0";
                string _Team_Name = ""; // misglobales.oficina_oficina;
                string _EOD_Processed = "0";
                string _DateEODProcessed = "null";
                //string _idoficina = misglobales.oficina_id_oficina.ToString();
                string _idoficina = cmb_oficina.SelectedValue.ToString(); 

                if (txb_payment.Text != "")
                {
                    _payment = Convert.ToDecimal(txb_payment.Text);
                }


                _staff_payment = Convert.ToDecimal(txb_staff.Text);
                _transfer_amt = Convert.ToDecimal(txb_transfer.Text);
                if (Convert.ToDecimal(txb_charge.Text) == 0)
                {
                    _id_charge_type = "";
                }

                try
                {
                    // PREPARA QUERY PARA INSERT
                    campos = @"code, jumper_code, updatedate, idchargetype, charge, codigo_jumptype, transfer_amt, transfer_jumper_name, 
                           payment, staff_payment, idmanifestold, idmanifiesto, manifest_line_nbr, id_prospect, name, whoenteredid, 
                           WhoChanged_ID, WhenChanged, BookedFromTeam, Team_Name, EOD_Processed, DateEODProcessed, idoficina, nota, idusuario";
                    tabla = "TB_LEDGER";
                    valores = "'" + _code + "', '" + _jumper_code + "', getdate(), '" + _id_charge_type + "', " + _charge + ", '" + _codigo_jumptype + "', " +
                              _transfer_amt + ", '" + _transfer_jumper_name + "', " + _payment.ToString() + ", " + _staff_payment + ", '" + _idmanifestold + "', '" + _idmanifiesto +
                              "', " + _manifest_line_nbr + ", '" + _id_prospect + "', '" + _name + "', '" + _whoenteredid + "', '" + _WhoChanged_ID +
                              "', " + _WhenChanged + ", " + _BookedFromTeam + ", '" + _Team_Name + "', " + _EOD_Processed + ", " + _DateEODProcessed +
                              ", " + _idoficina + ", '" + txb_nota.Text + "', " + misglobales.usuario_idusuario;
                    //se almacena la transacción (LEDGER)
                    conexion.InsertTabla(campos, tabla, valores);
                    conexion.RegistroLog(misglobales.usuario_idusuario, "Jumper Transactions", "Ledger for Jumper: " + misglobales.jumper_code + " Query: " + campos + " " + valores);

                    //SI SE TRATA DE UNA TRANSFERENCIA SE APLICA EL MOVIMIENTO LEDGER PARA QUIEN ESTA RECIBIENDO LA TRANSFERENCIA
                    if (_transfer_jumper_name.Length > 5)
                    {
                        campos = @"code, jumper_code, updatedate, idchargetype, charge, codigo_jumptype, transfer_amt, transfer_jumper_name, 
                           payment, staff_payment, idmanifestold, idmanifiesto, manifest_line_nbr, id_prospect, name, whoenteredid, 
                           WhoChanged_ID, WhenChanged, BookedFromTeam, Team_Name, EOD_Processed, DateEODProcessed, idoficina, nota, idusuario";
                        tabla = "TB_LEDGER";
                        _charge = 0;
                       _transfer_amt =  _transfer_amt * -1;
                        txb_nota.Text = " TRANSFER FROM JUMPER " + dsjumper.Tables[0].Rows[0].ItemArray[2].ToString();


                        sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, J.idjumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance, JT.CODIGO
                                     FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode ";
                        DataSet dsjumper2 = conexion.ConsultaUniversal(sql, " WHERE J.NOMBRE = '" + cmb_transferto.Text + "'", "CT_JUMPER");
                        String _jumper_code2 = dsjumper2.Tables[0].Rows[0].ItemArray[1].ToString();

                        valores = "'" + _code + "', '" + _jumper_code2 + "', getdate(), '" + _id_charge_type + "', " + _charge + ", '" + _codigo_jumptype + "', " +
                                   _transfer_amt + ", '" + _transfer_jumper_name + "', " + _payment.ToString() + ", " + _staff_payment + ", '" + _idmanifestold + "', '" + _idmanifiesto +
                                   "', " + _manifest_line_nbr + ", '" + _id_prospect + "', '" + _name + "', '" + _whoenteredid + "', '" + _WhoChanged_ID +
                                   "', " + _WhenChanged + ", " + _BookedFromTeam + ", '" + _Team_Name + "', " + _EOD_Processed + ", " + _DateEODProcessed +
                                   ", " + _idoficina + ", '" + txb_nota.Text + "', " + misglobales.usuario_idusuario;
                        conexion.InsertTabla(campos, tabla, valores);
                        conexion.RegistroLog(misglobales.usuario_idusuario, "Jumper Transactions", "Ledger for Jumper: " + _jumper_code2 + " Query: " + campos + " " + valores);

                        misglobales.jumper_code = _jumper_code2;
                        txb_currentbalance.Text = u.Balance().ToString();
                        campos = " Balance = " + u.Balance();
                        condicion = " where codigo ='" + misglobales.jumper_code + "'";
                        tabla = "ct_jumper";
                        conexion.UpdateTabla(campos, tabla, condicion);

                    }
                  
                    
                    //Se registra el balance en saltos
                    //BalanceJumpUpdate();
                    //Se actualiza el balance el pesos
                    _jumper_code = dsjumper.Tables[0].Rows[0].ItemArray[1].ToString();
                    misglobales.jumper_code = _jumper_code;
                    txb_currentbalance.Text = u.Balance().ToString();
                    campos = " Balance = " + u.Balance();
                    condicion = " where codigo ='" + misglobales.jumper_code + "'";
                    tabla = "ct_jumper";
                    conexion.UpdateTabla(campos, tabla, condicion);
                    
                    
                    misglobales._TotalBalance = Convert.ToDecimal(txb_currentbalance.Text);

                    
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try insert new ledger record, please contact system administrator"+ ex.Message);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }
        #endregion 

        #region Evento click btn_save
        private void btn_save_Click(object sender, EventArgs e)
        {
            MakeToSave = true;
            //MessageBox.Show("Save successfully");
            ActualizaLocalCurrentBalance(); 
        }
        #endregion

        #region validacampos()
        private bool HayInformacion()
        {
            if (Convert.ToInt32(Convert.ToDecimal( txb_charge.Text)) == 0 && Convert.ToInt32(Convert.ToDecimal( txb_payment.Text)) == 0 && Convert.ToInt32(Convert.ToDecimal( txb_staff.Text)) == 0 && Convert.ToInt32(Convert.ToDecimal( txb_transfer.Text)) == 0)
            {
                return false;
            }
            else
            {

                return true;
            }

        }
        #endregion

        #region Evento click del boton Exit
        private void button1_Click(object sender, EventArgs e)
        {
            if (HayInformacion() == true)
            {
                try
                {
                    if (MakeToSave == false)
                    {
                        DialogResult resultado = MessageBox.Show("Do you want save changes before to exit ?", "Warning", MessageBoxButtons.YesNo);
                        if (resultado == DialogResult.Yes)
                        {
                            SaveTransaction();
                        }
                        else
                        {
                            tmr_currentbalance.Stop();
                            if (Convert.ToDecimal(txb_payment.Text) != 0)
                            {
                                conexion.BorraRegistro(" code_ledger = '" + misglobales._TransaccionLedger + "'", "TB_BREAKEDOWN");
                            }

                        }
                    }
                    else
                    {
                        SaveTransaction();
                    }
                    misglobales.ActualizandoTransaccion = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try save transaction " + ex.Message);
                }

            }
            else
            {
                this.Close();
            }
        }
        #endregion

        #region Evento click del btn_new
        private void btn_new_Click(object sender, EventArgs e)
        {
            if (HayInformacion() == true)
            {
                try
                {
                    if (MakeToSave == false)
                    {
                        DialogResult resultado = MessageBox.Show("Do you want save changes before to new ?", "Warning", MessageBoxButtons.YesNo);
                        if (resultado == DialogResult.Yes)
                        {
                            SaveTransaction();
                        }
                        else
                        {
                            tmr_currentbalance.Stop();
                        }
                    }
                    else
                    {
                        SaveTransaction();
                    }
                    misglobales.ActualizandoTransaccion = true;
                    //misglobales._name = "";
                    //misglobales.jumper_code = "";
                    _payment = 0;
                    _charge = 0;
                    _staff_payment = 0;
                    _transfer_amt = 0;
                    _code = "";
                    btn_save.Enabled = false;
                    IniciaObjetos();
                    MakeToSave = true;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try save transaction | " + ex.Message);
                }
            }
            else
            {
                misglobales.ActualizandoTransaccion = true;
                //misglobales._name = "";
                //misglobales.jumper_code = "";
                _payment = 0;
                _charge = 0;
                _staff_payment = 0;
                _transfer_amt = 0;
                _code = "";
                btn_save.Enabled = false;
                IniciaObjetos();
                MakeToSave = true;
            }
        }
        #endregion 

        #region Evento click del btn_payment
        private void btn_payment_Click(object sender, EventArgs e)
        {
            MakeToSave = false;
            txb_payment.Enabled = true;
            misglobales._BreakDown = 0;
            LastLedger();
            Frm_Payment_Breakdown FrmPayment = new Frm_Payment_Breakdown();
            misglobales._TotalBalance = 0;
            tmr_payment.Start();
            FrmPayment.Show();
        }
        #endregion

        #region Tick tmr_payment
        private void tmr_payment_Tick(object sender, EventArgs e)
        {
            
            if (misglobales._utilizandoPayment == false) 
            {
                txb_payment.Text = misglobales._TotalBalance.ToString();
                tmr_payment.Stop(); 
            }
            else if (misglobales._utilizandoPayment == true)
            {
                txb_payment.Text = misglobales._TotalBalance.ToString();
                btn_save.Enabled = true;
            }

            txb_variables.Text = "misglobales._TotalBalance " + misglobales._TotalBalance.ToString();
        }
        #endregion 

        #region tick tmr_currentbalance
        private void tmr_currentbalance_Tick(object sender, EventArgs e)
        {
            txb_currentbalance.Enabled = true;
            //txb_currentbalance.Text = Convert.ToString( Convert.ToDecimal(txb_charge.Text) + Convert.ToDecimal(txb_payment.Text) + Convert.ToDecimal(txb_staff.Text) + Convert.ToDecimal(txb_transfer.Text));

            if (cmb_name.SelectedValue.ToString() != "") 
               { btn_save.Enabled = true; }

        }
        #endregion 

        #region Metodo al seleccionar un Jumper
        private void JumperSeleccionado()
        {

            if (cmb_name.SelectedText != "" && cmb_name.SelectedValue!= null)
            {

                try
                {
                    misglobales._name = cmb_name.SelectedValue.ToString();
                    sql = @" SELECT IDJUMPER, CODIGO, NOMBRE FROM  CT_JUMPER WHERE NOMBRE = '" + misglobales._name + "'";
                    DataSet dsj = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
                    misglobales.jumper_code = dsj.Tables[0].Rows[0].ItemArray[1].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try get jumper, please contact system administrator", ex.Message);
                }
                //misglobales.jumper_code


                if (cmb_name.SelectedIndex > 0)
                {
                    //txb_currentbalance.Text = string.Format("{0:C}", Convert.ToDecimal(Balance()));
                    txb_currentbalance.Text = Convert.ToString(Balance());
                }
            }

        }
        #endregion 

        #region Metodo para calcular el Balance
        private Decimal Balance()
        {
            sql = @" SELECT  jumper_code, (sum(charge)  + sum(payment)) + sum(staff_payment) + sum(transfer_amt)  BALANCE
                       FROM dbo.TB_LEDGER";
            tabla = "TB_LEDGER";
            condicion = @" WHERE jumper_code = '" + misglobales.jumper_code.ToString() + @"'
                        group by jumper_code";

            dsledger = conexion.ConsultaUniversal(sql, condicion, tabla);
            conexion.CloseDB();
            if (dsledger.Tables[0].Rows.Count == 0)
            {
                return  0;
            }
            else
            {
                return Convert.ToDecimal(dsledger.Tables[0].Rows[0].ItemArray[1].ToString());
                
            }


        }
        #endregion 

        #region value Changed cmb_name
        private void cmb_name_SelectedValueChanged(object sender, EventArgs e)
        {
            //al cargar la forma
            //al cambiar con las flechas cursoras
            //AL DAR ENTER despues de buscar un item
            JumperSeleccionado();
        }
        #endregion 

        #region Enter cmb_name
        private void cmb_name_Enter(object sender, EventArgs e)
        {
            //al abrir el combo si no tiene el foco
            JumperSeleccionado();
        }
        #endregion 

        #region SelectedIndexChanged cmb_name
        private void cmb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            //al cargar la forma
            //al cambiar con las flechas cursoras
            JumperSeleccionado();
        }
        #endregion 

        #region Evento Selection Change Comitted del cmb_name
        private void cmb_name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //al cambiar con las flachas cursoras
            JumperSeleccionado();
        }
        #endregion 

        #region Evento Tab Index Changed del cmb_name
        private void cmb_name_TabIndexChanged(object sender, EventArgs e)
        {
            JumperSeleccionado();
        }
        #endregion

        #region Evento Trxt changed del cmb_name
        private void cmb_name_TextChanged(object sender, EventArgs e)
        {
            //al cargar la forma
            //al cambiar con las flechas cursoras
            //al escribir en el combo
            JumperSeleccionado();
        }
        #endregion 

        #region evento TextUpdate del cmb_name
        private void cmb_name_TextUpdate(object sender, EventArgs e)
        {
            //al escribir en el combo
            JumperSeleccionado();
        }
        #endregion

        #region Value Member Changed del cmb_name
        private void cmb_name_ValueMemberChanged(object sender, EventArgs e)
        {
        // al cargar la forma
            JumperSeleccionado();
        }
        #endregion 

        #region Evento Visible Changed del cmb_name
        private void cmb_name_VisibleChanged(object sender, EventArgs e)
        {
            JumperSeleccionado();
        }
        #endregion 

        #region Evento Text Changed del txb_transfer
        private void txb_transfer_TextChanged(object sender, EventArgs e)
        {
            if (txb_transfer.Text != "")
            {
                cmb_transferto.Enabled = true;
            }
            else
            {
                cmb_transferto.Enabled = false;
                cmb_transferto.SelectedItem = null;

            }
        }
        #endregion 

        private void Frm_JumperTransactionEntires_FormClosing(object sender, FormClosingEventArgs e)
        {
            misglobales.ActualizandoTransaccion = true;
        }






    }
}
