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
    public partial class Frm_Jumpers : Form
    {

        #region Variables
        string condicion = "";
        ConectaBD conexion = new ConectaBD();
        String sql = "";
        int btn_lockpadlock = 0;
        Int32 _status = 2;
        Boolean _Insert = true;
        Boolean _leejumper = false;
        DataSet dsjumpertype, dsjumptype, dssourcetype, dsjumper, dsgender;
        utilerias u = new utilerias();
        Int32 JumpTypeChanged = 0;
        String JumpTypePhoto = "";
        Boolean LeadgerActive = false;

        #endregion 

        #region Constructor de la Frm_Jumpers
        public Frm_Jumpers()
        {
            InitializeComponent();
        }
        #endregion 

        #region Valida Perfil
        public void validaperfil()
        {
            if (misglobales.perfil_idperfil == 6 )
            {
                btn_Ledger.Visible = false;
                btn_transaction.Visible = false;
                btn_jumperlist.Visible = false;
                btn_ListbyClass.Visible = false;
                btn_History.Visible = false;
                btn_history_resume.Visible = false;
                btn_ticket.Visible = false;
                btn_identity.Visible = false;
                lbl_balance.Visible = false;
                txb_balancemoney.Visible = false;
                lbll_balancejumper.Visible = false;
                txb_balancejumper.Visible = false;
                btn_delete.Visible = false;
                btn_limpiar.Visible = false;
                grp_padlocks.Visible = false;
                btn_lock.Visible = false;
            }
            if (misglobales.perfil_idperfil == 4)
            {
                btn_Ledger.Visible = false;
                btn_transaction.Visible = false;
                btn_jumperlist.Visible = false;
                btn_ListbyClass.Visible = false;
                btn_History.Visible = true;
                btn_history_resume.Visible = true;
                btn_preferences.Visible = true;
                btn_ticket.Visible = false;
                btn_identity.Visible = false;
                lbl_balance.Visible = false;
                txb_balancemoney.Visible = false;
                lbll_balancejumper.Visible = false;
                txb_balancejumper.Visible = false;
                btn_delete.Visible = false;
                btn_limpiar.Visible = false;
                grp_padlocks.Visible = false;
            }

        }
        #endregion

        #region Load de la forma
        private void Frm_Jumpers_Load(object sender, EventArgs e)
        {
            if (LeadgerActive == false) { grpb_Ledger.Visible = false; } else { grpb_Ledger.Visible = true; }
            LimpiaCampos();
            validaperfil();


        }
        #endregion
         
        #region Evento click del btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Evento click del btn_jumperlist
        private void btn_jumperlist_Click(object sender, EventArgs e)
        {
            Frm_JumperList FrmJumperL = new Frm_JumperList();
            FrmJumperL.MdiParent = MDISkyDiveCuautla.ActiveForm;
            FrmJumperL.WindowState = FormWindowState.Maximized;
            FrmJumperL.Show();

        }
        #endregion

        #region Carga Campos
        private void CargaCampos()
        {
            validaperfil();

            DataTable dt = new DataTable();
            txb_jumperid.Text = misglobales.jumper_code_list;
            misglobales.jumper_code = txb_jumperid.Text;
           
           sql = @"select Descripcion From dbo.CT_JUMPER_TYPE WHERE idestatus <> 4 ORDER BY orden";
            dsjumpertype = conexion.ConsultaUniversal(sql, "", "CT_JUMPER_TYPE");
            cmb_jumpertype.DataSource = dsjumpertype.Tables[0].DefaultView;
            cmb_jumpertype.AutoCompleteCustomSource = u.LoadAutoComplete(dsjumpertype, "Descripcion");
            cmb_jumpertype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumpertype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumpertype.ValueMember = "Descripcion";
            cmb_jumpertype.SelectedItem = null;
            dsjumpertype.Dispose();



            sql = @"select jump_type From dbo.CT_JUMP_TYPE WHERE idestatus <> 4 ORDER BY orden";
            dsjumptype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
            cmb_defaultjumptype.DataSource = dsjumptype.Tables[0].DefaultView;
            cmb_defaultjumptype.AutoCompleteCustomSource = u.LoadAutoComplete(dsjumptype, "jump_type");
            cmb_defaultjumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_defaultjumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_defaultjumptype.ValueMember = "jump_type";
            cmb_defaultjumptype.SelectedItem = null;
            dsjumptype.Dispose();

            sql = @"select Source_Type From dbo.CT_SOURCE_TYPE WHERE idestatus <> 4 ORDER BY orden";
            dssourcetype = conexion.ConsultaUniversal(sql, "", "CT_SOURCE_TYPE");
            cmb_sourcetype.DataSource = dssourcetype.Tables[0].DefaultView;
            cmb_sourcetype.AutoCompleteCustomSource = u.LoadAutoComplete(dssourcetype, "Source_Type");
            cmb_sourcetype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_sourcetype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_sourcetype.ValueMember = "Source_Type";
            cmb_sourcetype.SelectedItem = null;
            dssourcetype.Dispose();

            sql = @"SELECT idjumper , lastname  + ', ' + name as name FROM dbo.CT_JUMPER ";
            dsjumper = conexion.ConsultaUniversal(sql, " WHERE idjumper > 1 and idestatus <> 4 order by lastname  + ', ' + name", "CT_JUMPER"); 
            cmb_referencejumper.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_referencejumper.AutoCompleteCustomSource = u.LoadAutoComplete(dsjumper, "NAME");
            cmb_referencejumper.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_referencejumper.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_referencejumper.ValueMember = "NAME";
            cmb_referencejumper.SelectedItem = null;
            dsjumper.Dispose();

            sql = "select idgender, code, descripcion, fecha_creacion, idestatus from ct_gender order by idgender";
            dsgender = conexion.ConsultaUniversal(sql, "", "ct_gender");
            cmb_gender.DataSource = dsgender.Tables[0].DefaultView;
            cmb_gender.AutoCompleteCustomSource = u.LoadAutoComplete(dsgender, "code");
            cmb_gender.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_gender.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_gender.ValueMember = "code";
            cmb_gender.SelectedItem = null;
            dsgender.Dispose();




            if (txb_jumperid.Text != "")
            {
                condicion = "WHERE j.codigo = '" + txb_jumperid.Text + "' ";

                dt = conexion.ConsultaJumperList(condicion);
                misglobales.jumperid = Convert.ToInt32(dt.Rows[0].ItemArray[43].ToString());


                sql = @"select Descripcion From dbo.CT_JUMPER_TYPE WHERE codigo = '" + dt.Rows[0].ItemArray[7].ToString() + "'";
                dsjumpertype = conexion.ConsultaUniversal(sql, "", "CT_JUMPER_TYPE");
                cmb_jumpertype.SelectedValue = dsjumpertype.Tables[0].Rows[0].ItemArray[0].ToString();
                dsjumpertype.Dispose();

                sql = @"select jump_type From dbo.CT_JUMP_TYPE WHERE codigo ='" + dt.Rows[0].ItemArray[6].ToString() + "'";
                dsjumptype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
                cmb_defaultjumptype.SelectedValue = dsjumptype.Tables[0].Rows[0].ItemArray[0].ToString();
                dsjumptype.Dispose();

                sql = "select descripcion from dbo.ct_gender where idgender = " + dt.Rows[0].ItemArray[50].ToString();
                dsgender = conexion.ConsultaUniversal(sql, "", "ct_gender");
                cmb_gender.SelectedValue = dsgender.Tables[0].Rows[0].ItemArray[0].ToString();
                dsgender.Dispose();



                String idsource = dt.Rows[0].ItemArray[29].ToString();
                if (idsource != "")
                {
                    sql = @"select Source_Type From dbo.CT_SOURCE_TYPE WHERE codigo = '" + idsource.ToString() + "'";
                    dssourcetype = conexion.ConsultaUniversal(sql, "", "CT_SOURCE_TYPE");
                    if (dssourcetype.Tables[0].Rows.Count > 0)
                    {
                        cmb_sourcetype.SelectedValue = dssourcetype.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    dssourcetype.Dispose();
                }
                else
                {
                    cmb_sourcetype.SelectedItem = null;

                }

                String idReference = 
                sql = @"SELECT lastname  + ', ' + name as name FROM dbo.CT_JUMPER ";
                condicion = @" WHERE codigo = '" + dt.Rows[0].ItemArray[30].ToString() + "'";
                dsjumper = conexion.ConsultaUniversal(sql, condicion, "CT_JUMPER");
                if (dsjumper.Tables[0].Rows.Count > 0)
                {
                    cmb_referencejumper.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                dsjumper.Dispose();
         
                grp_padlocks.Enabled = true;
                txb_dateentered.Text = dt.Rows[0].ItemArray[2].ToString();
                txb_lastname.Text = dt.Rows[0].ItemArray[4].ToString();
                txb_firstname.Text = dt.Rows[0].ItemArray[3].ToString();
                txb_alias.Text = dt.Rows[0].ItemArray[8].ToString();
                txb_adress1.Text = dt.Rows[0].ItemArray[11].ToString();
                txb_address2.Text = dt.Rows[0].ItemArray[12].ToString();
                txb_city.Text = dt.Rows[0].ItemArray[13].ToString();
                txb_state.Text = dt.Rows[0].ItemArray[14].ToString();
                txb_country.Text = dt.Rows[0].ItemArray[15].ToString();
                txb_postalcode.Text = dt.Rows[0].ItemArray[16].ToString();
                txb_home.Text = dt.Rows[0].ItemArray[17].ToString();
                txb_fax.Text = dt.Rows[0].ItemArray[19].ToString();
                txb_nextel.Text = dt.Rows[0].ItemArray[23].ToString();
                txb_email.Text = dt.Rows[0].ItemArray[22].ToString();
                txb_workphone.Text = dt.Rows[0].ItemArray[18].ToString();
                txb_mobil.Text = dt.Rows[0].ItemArray[20].ToString();
                txb_other.Text = dt.Rows[0].ItemArray[21].ToString();
                txb_medical.Text = dt.Rows[0].ItemArray[40].ToString();
                txb_creditcard.Text = dt.Rows[0].ItemArray[41].ToString();
                txb_notes.Text = dt.Rows[0].ItemArray[39].ToString();
                chb_active.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[1].ToString());
                txb_totaljumps.Text = dt.Rows[0].ItemArray[9].ToString();
                txb_lastdayjump.Text = dt.Rows[0].ItemArray[10].ToString();
                txb_equipment.Text = dt.Rows[0].ItemArray[24].ToString();
                txb_instructorname.Text = dt.Rows[0].ItemArray[51].ToString();
          
                if (dt.Rows[0].ItemArray[25].ToString() == "")
                {
                    txb_reserve.CustomFormat = " ";
                    txb_reserve.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    txb_reserve.CustomFormat = "dd/MM/yyyy";
                    txb_reserve.Text = dt.Rows[0].ItemArray[25].ToString();
                }


                if (dt.Rows[0].ItemArray[31].ToString() == "")
                {
                    dp_waiverdate.CustomFormat = " ";
                    dp_waiverdate.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dp_waiverdate.CustomFormat = "dd/MM/yyyy";
                    dp_waiverdate.Text = dt.Rows[0].ItemArray[31].ToString();
                }

                
                txb_uspamember.Text = dt.Rows[0].ItemArray[26].ToString();
                txb_uspalicence.Text = dt.Rows[0].ItemArray[27].ToString();
                cmb_licencetype.Text = dt.Rows[0].ItemArray[44].ToString();

                if (dt.Rows[0].ItemArray[45].ToString() == "")
                {
                    dp_borndate.CustomFormat = " ";
                    dp_borndate.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dp_borndate.CustomFormat = "dd/MM/yyyy";
                    dp_borndate.Text = dt.Rows[0].ItemArray[45].ToString();
                }

                txb_grade.Text = dt.Rows[0].ItemArray[46].ToString();
                txb_curp.Text = dt.Rows[0].ItemArray[47].ToString();

                if (dt.Rows[0].ItemArray[48].ToString() == "")
                {

                    dp_datebegin.CustomFormat = " ";
                    dp_datebegin.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dp_datebegin.CustomFormat = "dd/MM/yyyy";
                    dp_datebegin.Text = dt.Rows[0].ItemArray[48].ToString();
                }




                if (dt.Rows[0].ItemArray[28].ToString() == "")
                {
                    dp_uspaexpiresdate.CustomFormat = " ";
                    dp_uspaexpiresdate.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dp_uspaexpiresdate.CustomFormat = "dd/MM/yyyy";
                    dp_uspaexpiresdate.Text = dt.Rows[0].ItemArray[28].ToString();
                }

                
                
                chk_allowwnb.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[34].ToString());
                chk_alldayjump.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[33].ToString());
                chk_allowchangejumptype.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[35].ToString());
                chk_allowpaidbyjumper.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[36].ToString());
                chk_allowfirstjump.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[37].ToString());

                if (Convert.ToDecimal(dt.Rows[0].ItemArray[5].ToString()) <= 0)
                {
                    txb_balancemoney.Text = dt.Rows[0].ItemArray[5].ToString();
                    txb_balancemoney.Text = Convert.ToString(Convert.ToDecimal(txb_balancemoney.Text));    // string.Format("{0:C}", Convert.ToDecimal(txb_balancemoney.Text));
                    txb_balancemoney.Enabled = true;
                    txb_balancemoney.BackColor = Color.Green;
                    txb_balancemoney.ForeColor = Color.Yellow;
                    txb_balancemoney.ReadOnly = true;
                }
                else
                {
                    txb_balancemoney.Text = dt.Rows[0].ItemArray[5].ToString();
                    txb_balancemoney.Text = Convert.ToString(Convert.ToDecimal(txb_balancemoney.Text));  //string.Format("{0:C}", Convert.ToDecimal(txb_balancemoney.Text));
                    txb_balancemoney.Enabled = true;
                    txb_balancemoney.BackColor = Color.Red;
                    txb_balancemoney.ForeColor = Color.White;
                    txb_balancemoney.ReadOnly = true;
                }
                txb_balancejumper.Text = u.BalanceSaltos().ToString() ;// dt.Rows[0].ItemArray[42].ToString();
                txb_balancejumper.Enabled = true;
                txb_balancejumper.ForeColor = Color.Yellow;
                txb_balancejumper.ReadOnly = true;

                _Insert = false;
                grp_padlocks.Enabled = false;
                if (_leejumper && misglobales._readjumper) { tmr_readjumper.Stop(); _leejumper = false; misglobales._readjumper = false; }
                btn_Ledger.Enabled = true;
                btn_transaction.Enabled = true;
                btn_identity.Enabled = true;
                JumpTypePhoto = cmb_defaultjumptype.Text;

            }

        }
        #endregion

        #region Evento Actived del Frm_Jumpers
        private void Frm_Jumpers_Activated(object sender, EventArgs e)
        {
            LimpiaCampos();
            CargaCampos();

        }
        #endregion

        #region Limpia Campos
        private void LimpiaCampos()
        {
            dp_borndate.Text = "";
            txb_grade.Text = "";
            txb_curp.Text = "";
            dp_datebegin.Text = "";


            txb_dateentered.Text = "";
            txb_lastname.Text = "";
            txb_firstname.Text = "";
            txb_alias.Text = "";
            txb_adress1.Text = "";
            txb_address2.Text = "";
            txb_city.Text = "";
            txb_state.Text = "";
            txb_country.Text = "";
            txb_postalcode.Text = "";
            txb_home.Text = "";
            txb_fax.Text = "";
            txb_nextel.Text = "";
            txb_email.Text = "";
            txb_workphone.Text = "";
            txb_mobil.Text = "";
            txb_other.Text = "";
            txb_medical.Text = "";
            txb_creditcard.Text = "";
            txb_notes.Text = "";
            chb_active.Checked = true;
            txb_totaljumps.Text = "";
            txb_lastdayjump.Text = "";
            txb_equipment.Text = "";
            txb_reserve.Text = "";
            dp_waiverdate.Text = "";
            txb_uspamember.Text = "";
            txb_uspalicence.Text = "";
            dp_uspaexpiresdate.Text = "";
            chk_allowwnb.Checked = false;
            chk_alldayjump.Checked = false;
            chk_allowchangejumptype.Checked = false;
            chk_allowpaidbyjumper.Checked = false;
            chk_allowfirstjump.Checked = false;
            txb_balancemoney.Text = "0.00";
            txb_balancejumper.Text = "0";
            _Insert = true;
            cmb_defaultjumptype.SelectedItem = null;
            cmb_gender.SelectedItem = null;
            cmb_jumpertype.SelectedItem = null;
            cmb_referencejumper.SelectedItem = null;
            cmb_sourcetype.SelectedItem = null;
            txb_jumperid.Enabled = true;
            txb_jumperid.Text = "";
            txb_jumperid.Enabled = false;
            txb_balancemoney.BackColor = Color.Green;
            txb_balancemoney.ForeColor = Color.Yellow;
            //if (LeadgerActive == false)
            //{
            //    dg_ledger.Visible = true;
            //}
            //else
            //{
            //    dg_ledger.Visible = false;
            //}
            dp_uspaexpiresdate.CustomFormat = " ";
            dp_uspaexpiresdate.Format = DateTimePickerFormat.Custom;
            dp_waiverdate.CustomFormat = " ";
            dp_waiverdate.Format = DateTimePickerFormat.Custom;
            txb_reserve.CustomFormat = " ";
            txb_reserve.Format = DateTimePickerFormat.Custom;

            dp_borndate.CustomFormat = " ";
            dp_borndate.Format = DateTimePickerFormat.Custom;

            dp_datebegin.CustomFormat = " ";
            dp_datebegin.Format = DateTimePickerFormat.Custom;

            txb_instructorname.Text = "";


        }
        #endregion 

        #region Valida campos obligatorios
        private Boolean ValidaCamposObligatorios()
        {
            bool respuesta = false;

            if (txb_firstname.TextLength >= 2)
            {
                respuesta = true;
            }
            else { MessageBox.Show(" Firtsname field it's needed "); respuesta = false; return respuesta; }
            if (txb_lastname.TextLength >= 2)
            {
                respuesta = true;
            }
            else { MessageBox.Show(" Lastname field it's needed"); respuesta = false; return respuesta; }
            if (txb_email.TextLength > 10)
            {
                respuesta = true;
            }
            else { MessageBox.Show(" eMail field it's needed "); respuesta = false; return respuesta; }
            if (cmb_jumpertype.Text != "" )
            { respuesta = true; }
            else
            { MessageBox.Show(" Select Jumpertype it's needed "); respuesta = false; return respuesta; }

            if (cmb_defaultjumptype.Text != "")
            { respuesta = true; }
            else
            { MessageBox.Show(" Select Default Jumpt Type "); respuesta = false; return respuesta; }

            if (cmb_gender.Text != "")
            { respuesta = true; }
            else
            { MessageBox.Show(" Please select Gender "); respuesta = false; return respuesta; }

            return respuesta;


        }
        #endregion 

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            String sql = @"SELECT * FROM dbo.CT_JUMPER ";
            String tabla = "CT_JUMPER";
            ds = conexion.ConsultaUniversal(sql, condicion, tabla);
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

        #region Evento click del btn_save
        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            string campos = "";
            string tabla = "dbo.CT_JUMPER";
            string valores = "";

            btn_Ledger.Enabled = true;
            btn_transaction.Enabled = true;

            Int32 idgender = 1;

            


            if (ValidaCamposObligatorios())  // si ya se generó el nuevo jumper o se consulto un jumper
            {
                String _idjumper;
                String _idsourcetype, _idgender;
                    if (txb_totaljumps.Text  == "") {txb_totaljumps.Text="0";}

                    sql = @"select codigo, idjumpertype, Descripcion From dbo.CT_JUMPER_TYPE  WHERE Descripcion = '" + cmb_jumpertype.Text + "'";
                    dsjumpertype = conexion.ConsultaUniversal(sql, "", "CT_JUMPER_TYPE");
                    String _idjumpertype = dsjumpertype.Tables[0].Rows[0].ItemArray[0].ToString();
                    dsjumpertype.Dispose();
                    sql = @"select codigo, idjumptype, jump_type From dbo.CT_JUMP_TYPE  WHERE jump_type = '" + cmb_defaultjumptype.Text + "'";
                    dsjumptype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
                    String _idjumptype = dsjumptype.Tables[0].Rows[0].ItemArray[0].ToString();
                    dsjumptype.Dispose();

                    if (cmb_sourcetype.Text != "")
                    {
                        sql = @"select codigo, idsourcetype, Source_Type From dbo.CT_SOURCE_TYPE  WHERE Source_Type = '" + cmb_sourcetype.Text + "'";
                        dssourcetype = conexion.ConsultaUniversal(sql, "", "CT_SOURCE_TYPE");
                        _idsourcetype = dssourcetype.Tables[0].Rows[0].ItemArray[0].ToString();
                        dssourcetype.Dispose();
                    }
                    else
                    {
                        _idsourcetype = "INTERNET";
                    }


                    if(cmb_gender.Text != "")
                    {
                        sql = @"select idgender, code, descripcion, idestatus From dbo.CT_GENDER  WHERE CODE = '" + cmb_gender.Text + "'";
                        dssourcetype = conexion.ConsultaUniversal(sql, "", "ct_gender");
                        _idgender = dssourcetype.Tables[0].Rows[0].ItemArray[0].ToString();
                        dssourcetype.Dispose();
                    }
                    else
                    {
                        _idgender = "MASCULINO";


                    }


                    if (cmb_referencejumper.Text != "")
                    {
                        sql = @"SELECT codigo, idjumper , lastname  + ', ' + name as name FROM dbo.CT_JUMPER WHERE idestatus <> 4 AND lastname  + ', ' + name = '" + cmb_referencejumper.Text + "'";
                        dsjumper = conexion.ConsultaUniversal(sql, "", "CT_JUMPER");
                        _idjumper = dsjumper.Tables[0].Rows[0].ItemArray[0].ToString();
                        dsjumper.Dispose();
                    }
                    else
                    {
                        _idjumper = "";
                    }
                    Int32 _allowwnb = 2;
                    if (chk_allowwnb.Checked == true) { _allowwnb = 1; } else { _allowwnb = 0; }
                    Int32 _alldayjump = 2;
                    if (chk_alldayjump.Checked == true) { _alldayjump = 1; } else { _alldayjump = 0; }
                    Int32 _allowchangejumptype = 2;
                    if (chk_allowchangejumptype.Checked == true) { _allowchangejumptype = 1; } else { _allowchangejumptype = 0; }
                    Int32 _allowpaidbyjumper = 2;
                    if (chk_allowpaidbyjumper.Checked == true) { _allowpaidbyjumper = 1; } else { _allowpaidbyjumper = 0; }
                    Int32 _allowfirstjump = 2;
                    if (chk_allowfirstjump.Checked == true) { _allowfirstjump = 1; } else { _allowfirstjump = 0; }

                    String condicionespecial = " WHERE codigo = '" + txb_jumperid.Text + "' ";
                    if (InserUpdate(condicionespecial) == "insert") { _Insert = true; } else { _Insert = false; }

                    if (_status != 1) { _status = 2; }
                if (_Insert)
                {
                //insert New Jumper
                    DataSet ds;
                    sql = @"SELECT max(idjumper) + 1 FROM dbo.CT_JUMPER ";
                    tabla = "CT_JUMPER";
                    condicion = "";
                    ds = conexion.ConsultaUniversal(sql, condicion, tabla);
                    string codigo = ds.Tables[0].Rows[0].ItemArray[0].ToString() + "-" + txb_firstname.Text.Substring(0, 2).ToUpper() + txb_lastname.Text.Substring(0, 2).ToUpper();
                    txb_jumperid.Text = codigo;
                    tabla = "CT_JUMPER";
                    campos = @"[codigo], [nombre], [paterno], [materno], [total_saltos], [Fecha_alta], [Fecha_ultimo_salto], [Equipamiento], [ReserveRepackDate], [USPA_Member],
                               [USPA_Licence], [USPA_Expires], [idjumpertypecode], [idjumptypecode], [id_sourcetypecode], [Balance], [Waiver_Expires], [Locker], [Reference_idJumpercode],
                               [Debit_Padlock], [All_Day_Jump_padlock], [Allow_Override_Padlock], [idoficina], [Note], [Aliasjumper], [systemflag], [Allow_PaidBy], [Allow_FirstJump],
                               [FirstJump_Padlock], [name], [lastname], [address1], [address2], [city], [state], [country], [postal_code], [home_phone], [work_phone], [fax],
                               [mobile_phone], [other_phone], [email], [credit_card], [medical_insurance], [nextel], [idestatus], licencetype, [BORNDATE], [GRADE], [CURP], [DATEBEGINSPORT], updatedate, idgender, instructor_name";
                    valores = "'" + txb_jumperid.Text + "', '" + txb_lastname.Text + ", " + txb_firstname.Text + "', '" + txb_lastname.Text + "', '', " + txb_totaljumps.Text + ", getdate(), null, '" +
                              txb_equipment.Text + "', " + " getdate(), '" + txb_uspamember.Text + "', '" + txb_uspalicence.Text + "',   getdate(), '" + _idjumpertype.ToString() + "', '" + _idjumptype.ToString() +
                              "', '" + _idsourcetype.ToString() + "', " + txb_balancemoney.Text + ", '"+dp_waiverdate.Text+"', null, '" + _idjumper.ToString() + "', " + _allowwnb.ToString() + ", " +
                               _alldayjump.ToString() + ", " + _allowchangejumptype + ", " + misglobales.oficina_id_oficina + ", '" + txb_notes.Text + "', '" +
                               txb_alias.Text + "', 0, " + _allowpaidbyjumper + ", " + _allowfirstjump + ", 0, '" + txb_firstname.Text + "', '" +
                               txb_lastname.Text + "', '" + txb_adress1.Text + "', '" + txb_address2.Text + "', '" + txb_city.Text + "', '" + txb_state.Text + "', '" + txb_country.Text + "', '" + txb_postalcode.Text + "', '" +
                               txb_home.Text + "', '" + txb_workphone.Text + "', '" + txb_fax.Text + "', '" + txb_mobil.Text + "', '" + txb_other.Text + "', '" + txb_email.Text + "', '" + txb_creditcard.Text + "', '" +
                               txb_medical.Text + "', '" + txb_nextel.Text + "', " + _status+ ", '" + cmb_licencetype.Text + "', '" + dp_borndate.Text + "', '" + txb_grade.Text + "', '" + txb_curp.Text +"', '" + dp_datebegin.Text + "', getdate()," + _idgender + ", '" + txb_instructorname.Text +"'";
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
//                        campos = "idjumper, codigo, nombre, balance, balancejump, jumptypecode, price, updatedate, idoficina";
//                        tabla = "TB_BALANCE_JUMP";
//                        sql = @"SELECT CTJ.idjumper, CTJ.codigo, CTJ.nombre, CTJ.Balance, 
//                                           case when CTJ.Balance = 0 or CTJ.Balance = null then 0 
//                                                when CTJT.price = 0 then 0
//                                                else Convert(int, (CTJ.Balance / CTJT.price ) *-1) end  Balance_Jump, CTJ.idjumptypecode, CTJT.price , GETDATE(), 1
//                                     FROM CT_JUMPER CTJ LEFT OUTER JOIN CT_JUMP_TYPE CTJT ON CTJT.codigo = CTJ.idjumptypecode 
//                                    WHERE ctj.codigo = '" + txb_jumperid.Text + @"' 
//                                    order by CTJ.Balance";

//                        conexion.InsertTablaQry(campos, tabla, sql);
                        conexion.CloseDB();
                        MessageBox.Show("Saved successfully", "Information");
                        btn_transaction.Enabled = true;
                        btn_Ledger.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to create new jumper, | " + ex.Message );
                    }
                }
                else
                { 
                    //update

                    campos = @"[nombre] = '" + txb_lastname.Text + ", " + txb_firstname.Text + "', " +
                              "[paterno] = '" + txb_lastname.Text + "', " +
                              "[materno]  = '', " +
                              "[total_saltos] = " + txb_totaljumps.Text + ", " +
                              "[Equipamiento] = '" + txb_equipment.Text + "', " +
                              "[USPA_Member] = '" + txb_uspamember.Text + "', " +
                              "[USPA_Licence] = '" + txb_uspalicence.Text + "', " +
                              "[ReserveRepackDate] = '" + txb_reserve.Text + "', " +
                              "[USPA_Expires] = '" + dp_uspaexpiresdate.Text + "', " +
                              "[Waiver_Expires] = '" + dp_waiverdate.Text + "', " +
                              "[idjumpertypecode] = '" + _idjumpertype.ToString() + "', " +
                              "[idjumptypecode] = '" + _idjumptype.ToString() + "', " +
                              "[id_sourcetypecode] = '" + _idsourcetype.ToString() + "', " +
                              "[Reference_idJumpercode] = '" + _idjumper.ToString() + "', " +
                              "[Debit_Padlock] = " + _allowwnb.ToString() + ", " +
                              "[All_Day_Jump_padlock] = " + _alldayjump.ToString() + ", " +
                              "[Allow_Override_Padlock] = " + _allowchangejumptype + ", " +
                              "[idoficina] = " + misglobales.oficina_id_oficina + ", " +
                              "[Note] = '" + txb_notes.Text + "', " +
                              "[Aliasjumper] = '" + txb_alias.Text + "', " +
                              "[Allow_PaidBy] = " + _allowpaidbyjumper + ", " +
                              "[Allow_FirstJump] = " + _allowfirstjump + ", " +
                              "[FirstJump_Padlock] = " + _allowfirstjump + ", " +
                              "[name] = '" + txb_firstname.Text + "', " +
                              "[lastname] = '" + txb_lastname.Text + "', " +
                              "[address1] = '" + txb_adress1.Text + "', " +
                              "[address2] = '" + txb_address2.Text + "', " +
                              "[city] = '" + txb_city.Text + "', " +
                              "[state] = '" + txb_state.Text + "', " +
                              "[country] = '" + txb_country.Text + "', " +
                              "[postal_code] = '" + txb_postalcode.Text + "', " +
                              "[home_phone] = '" + txb_home.Text + "', " +
                              "[work_phone] = '" + txb_workphone.Text + "', " +
                              "[fax] = '" + txb_fax.Text + "', " +
                              "[mobile_phone] = '" + txb_mobil.Text + "', " +
                              "[other_phone] = '" + txb_other.Text + "', " +
                              "[email] = '" + txb_email.Text + "', " +
                              "[credit_card] = substring('" + txb_creditcard.Text +"',1,99), " +
                              "[medical_insurance] = '" + txb_medical.Text + "', " +
                              "[nextel] = '" +  txb_nextel.Text + "', " +
                              "licencetype = '" + cmb_licencetype.Text + "', " +
                              "[idestatus] = " + _status + ", " +
                              "[BORNDATE] = '" + dp_borndate.Text + "', " +
                              "[GRADE] = '" + txb_grade.Text + "', "+
                              "[CURP] = '" + txb_curp.Text + "'," +
                              "[DATEBEGINSPORT] = '" + dp_datebegin.Text + "', updatedate = getdate(), idgender = " + _idgender + ", instructor_name='" + txb_instructorname.Text + "'";
                    tabla = "CT_JUMPER";
                    condicion = " WHERE CODIGO = '" + txb_jumperid.Text + "'";
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
//                        if (JumpTypePhoto != cmb_defaultjumptype.Text)
//                        {
//                            campos = "idjumper, codigo, nombre, balance, balancejump, jumptypecode, price, updatedate, idoficina";
//                            tabla = "TB_BALANCE_JUMP";
//                            sql = @"SELECT CTJ.idjumper, CTJ.codigo, CTJ.nombre, CTJ.Balance, 
//                                           case when CTJ.Balance = 0 or CTJ.Balance = null then 0 
//                                                when CTJT.price = 0 then 0
//                                                else Convert(int, (CTJ.Balance / CTJT.price ) *-1) end  Balance_Jump, CTJ.idjumptypecode, CTJT.price , GETDATE(), 1
//                                     FROM CT_JUMPER CTJ LEFT OUTER JOIN CT_JUMP_TYPE CTJT ON CTJT.codigo = CTJ.idjumptypecode 
//                                    WHERE ctj.codigo = '" + txb_jumperid.Text + @"' 
//                                    order by CTJ.Balance";

//                            conexion.InsertTablaQry(campos, tabla, sql);
//                            conexion.CloseDB();
//                        }
                        //conexion.EXECSP("sp_actualiza_jumper");
                        MessageBox.Show("Update successfully", "Information");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" Error to update jumper " + ex.Message);
                    }


                }
                
                //LimpiaCampos();

            }
            else
            {
                MessageBox.Show("Select Jumper or capture all need information before to save");
            }

            btn_save.Enabled = true;
        }
        #endregion 

        #region Evento Click del btn_delete
        private void btn_delete_Click(object sender, EventArgs e)
        {
            // delete record selected
            if (txb_jumperid.TextLength > 5)  // si ya se generó el nuevo jumper o se consulto un jumper
            {
                Int32 BalanceJumper = Convert.ToInt32(txb_balancejumper.Text);
                Int32 BalanceMoney = Convert.ToInt32(txb_balancemoney.Text);

                if (BalanceJumper == 0 && BalanceMoney==0)
                {
                    DialogResult resultado = MessageBox.Show("this process can not rollback, are you sure delete this record: ?", "Warning", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        //Borrar
                        string condicion = " CODIGO = '" + txb_jumperid.Text + "'";
                        conexion.BorraRegistro(condicion, "CT_JUMPER");
                        condicion = " CODE = '" + txb_jumperid.Text + "'";
                        conexion.BorraRegistro(condicion, "CT_JUMPER_INFORMATION");
                        LimpiaCampos();
                        MessageBox.Show("Deleted successfully");
                    }
                }
                else
                {
                    MessageBox.Show(" Jumper have balance, you Can't delete");
                }

            }
            else
            {
                MessageBox.Show("Select Jumper before to delete");
            }
        }
        #endregion 

        #region Metodo Autoriza y acepta el cambio en cualquier Padlock
        private void AutorizaPadlock()
        {
            misglobales._Login = 2; //PADLOCK 1: Allow Transaction with no Balance
            acceso _FrmLogin = new acceso();
            _FrmLogin.Show();

        }
        #endregion 

        #region Evento Click del btn_Lock
        private void btn_lock_Click(object sender, EventArgs e)
        {
            

            if (misglobales._Autoriza == false)
            {
                AutorizaPadlock();
               
            }
            tmr_autoriza.Start();
        }
        #endregion 

        #region Timer Autoriza mover los padlocks
        private void tmr_autoriza_Tick(object sender, EventArgs e)
        {
            if (misglobales._Autoriza == true)
            {
                
                if (btn_lockpadlock == 0)
                {
                    btn_lock.Text = "Lock Padlocks";
                    btn_lockpadlock = 1;
                    grp_padlocks.Enabled = true;
                    tmr_autoriza.Stop();
                }
                else
                {
                    btn_lock.Text = "UnLock Padlocks";
                    btn_lockpadlock = 0;
                    misglobales._Autoriza = false;
                    grp_padlocks.Enabled = false;
                    tmr_autoriza.Stop();
                }
            }

        }
        #endregion 

        #region Evento click del btn_limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            btn_Ledger.Enabled = false;
            btn_transaction.Enabled = false;
            btn_identity.Enabled = false;
            LimpiaCampos();
        }
        #endregion 

        #region Evento click del btn_buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            btn_lock.Text = "UnLock Padlocks";
            btn_lockpadlock = 0;
            misglobales._Autoriza = false;
            grp_padlocks.Enabled = false;

            Frm_JumperSelection FrmJumperSelector = new Frm_JumperSelection();
            //FrmJumperSelector.MdiParent = MDISkyDiveCuautla.ActiveForm;
            //FrmJumperSelector.WindowState = FormWindowState.Normal;
            FrmJumperSelector.Show();
            _leejumper = true;
            _Insert = false;
            tmr_readjumper.Start();
        }
        #endregion 

        #region Evento click 1 del btn_exit
        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento Tick del tmr_readjumper
        private void tmr_readjumper_Tick(object sender, EventArgs e)
        {
            if (misglobales._readjumper)
            {
                LimpiaCampos();
                CargaCampos();
                inicializagridview();
                txb_balancejumper.Text = Convert.ToString(u.BalanceSaltos());
            }
        }
        #endregion

        #region evento CheckedChanged del checkbox chb_active
        private void chb_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_active.Checked == true) { _status = 1; } else { _status = 2; }
        }
        #endregion 

        #region Evento click del btn_transaction
        private void btn_transaction_Click(object sender, EventArgs e)
        {
            misglobales._Login = 1;
            tmr_balance.Start();
            misglobales.ActualizandoTransaccion = false;
            this.Enabled = false;
            if (txb_lastname.Text != "")
            {
                misglobales._name = txb_lastname.Text + ", " + txb_firstname.Text;
                misglobales.jumper_code = txb_jumperid.Text;
                
                misglobales._tandemupcode = txb_jumperid.Text; 
                misglobales.jumptype = cmb_defaultjumptype.Text;
                misglobales._TransaccionLedger = "-JMPTRN";
                
            }
            else
            {
                misglobales._name = "";
            }
            //misglobales._manifiesto = Lbl_matriculainfo.Text + "-" + Lbl_FlightCode.Text;
            acceso _FrmLogin = new acceso();
            _FrmLogin.Show();
        }
        #endregion

        #region Inicializa grid del Ledger
        private void inicializagridview()
        {
            dg_ledger.EnableHeadersVisualStyles = false;
            condicion = @" WHERE tbl.jumper_code = '" + txb_jumperid.Text + "' order by TBL.updatedate desc";
            dg_ledger.DataSource = conexion.ConsultaLedger(condicion);
            dg_ledger.Columns[0].Width = 150; //UPDATEDATE
            dg_ledger.Columns[1].Width = 200; //Charge type
            dg_ledger.Columns[2].Width = 100; //charge
            dg_ledger.Columns[3].Width = 100; //payment
            dg_ledger.Columns[4].Width = 100; //Staff Pay
            dg_ledger.Columns[5].Width = 100; //Transfer ATM
            dg_ledger.Columns[6].Width = 250; //Transfer Jumper
            dg_ledger.Columns[7].Width = 350; //Note

            dg_ledger.Columns[0].HeaderText = "Date";
            dg_ledger.Columns[1].HeaderText = "Charge Type";
            dg_ledger.Columns[2].HeaderText = "Charge";
            dg_ledger.Columns[3].HeaderText = "Payment";
            dg_ledger.Columns[4].HeaderText = "Staff Pay";
            dg_ledger.Columns[5].HeaderText = "Transfer";
            dg_ledger.Columns[6].HeaderText = "Transfer Jumper";
            dg_ledger.Columns[7].HeaderText = "Note";


            u.Formatodgv(dg_ledger);
            conexion.CloseDB();
        }
        #endregion

        #region Evento click del btn_ledger
        private void btn_Ledger_Click(object sender, EventArgs e)
        {
            if (LeadgerActive == false)
            {
                
                grpb_Ledger.Visible = true;
                dg_ledger.Visible = true;
                inicializagridview();
                LeadgerActive = true;
            }
            else
            {
                grpb_Ledger.Visible = true;
                dg_ledger.Visible = false;
                inicializagridview();
                LeadgerActive = false;
            }
        }
        #endregion 

        #region Evento Tick del tmr_balance
        private void tmr_balance_Tick(object sender, EventArgs e)
        {
            if (misglobales.ActualizandoTransaccion == true)
            {
                txb_balancemoney.Text = u.Balance().ToString();
                txb_balancejumper.Text = u.BalanceSaltos().ToString();
                this.Enabled = true;
                if ( Convert.ToInt32(Convert.ToDecimal(  txb_balancemoney.Text)) <= 0)
                {   
                    txb_balancemoney.Enabled = true;
                    txb_balancemoney.BackColor = Color.Green;
                    txb_balancemoney.ForeColor = Color.Yellow;
                    txb_balancemoney.ReadOnly = true;
                }
                else
                {
                    txb_balancemoney.Enabled = true;
                    txb_balancemoney.BackColor = Color.Red;
                    txb_balancemoney.ForeColor = Color.White;
                    txb_balancemoney.ReadOnly = true;
                }
                inicializagridview();
                misglobales.ActualizandoTransaccion = false;
                //tmr_balance.Stop();
            }
        }
        #endregion

        #region Evento click del btn_history
        private void btn_History_Click(object sender, EventArgs e)
        {
            misglobales._HistoryJumper = "Frm_HistoryJumper";
                
                //Reportes.History_Jumper _FrmReportHistoryJumper = new Reportes.History_Jumper();
            
            //_FrmReportHistoryJumper.Show();

            Reportes.Frm_FiltroReportes _FrmReportFilter = new Reportes.Frm_FiltroReportes();
            _FrmReportFilter.Show();
            tmr_readjumper.Start();


        }
        #endregion 


        #region Evento Clicl del btn_history resume
        private void btn_history_resume_Click(object sender, EventArgs e)
        {
            misglobales._HistoryJumper = "Frm_HistoryJumper_resume";
            Reportes.Frm_FiltroReportes _FrmReportFilter = new Reportes.Frm_FiltroReportes();
            _FrmReportFilter.Show();
            tmr_readjumper.Start();


        }
        #endregion 




        #region Evento click del btn_ticket
        private void btn_ticket_Click(object sender, EventArgs e)
        {
            if (txb_jumperid.Text != "")
            {
                String St_USPA_Expires = dp_uspaexpiresdate.Text; //dsjumper.Tables[0].Rows[0].ItemArray[8].ToString();

                if ((St_USPA_Expires == "") || (Convert.ToDateTime(St_USPA_Expires) < DateTime.Now))
                {
                    MessageBox.Show(" Your licence or Member has been expired !!!  CAN NOT buy tickets");
                }
                else
                {
                    if (txb_jumperid.Text != "")
                    {
                        Frm_ticket FrmJumperL = new Frm_ticket();
                        FrmJumperL.MdiParent = MDISkyDiveCuautla.ActiveForm;
                        FrmJumperL.WindowState = FormWindowState.Maximized;

                        misglobales._name = txb_lastname.Text + ", " + txb_firstname.Text;
                        misglobales.jumper_code = txb_jumperid.Text;

                        misglobales._tandemupcode = txb_jumperid.Text;
                        misglobales.jumptype = cmb_defaultjumptype.Text;
                        misglobales._TransaccionLedger = "-JMPTRN";
                        FrmJumperL.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a jumper");
            }
        }
        #endregion 

        #region Evento click del btn_prospect
        private void btn_prospect_Click(object sender, EventArgs e)
        {
            //Abre ventana de prospectos.

        }
        #endregion

        #region Evento click del btn_listbyclass
        private void btn_ListbyClass_Click(object sender, EventArgs e)
        {
            //Abre ventana de busqueda por clase
        }
        #endregion 

        #region Evento click al boton Jumper Custom prices
        private void btn_jumper_Click(object sender, EventArgs e)
        {
            misglobales._name = txb_lastname.Text + ", " + txb_firstname.Text;
            misglobales.jumper_code = txb_jumperid.Text;
            // abre ventana de precios customizados por jumper
            Frm_Jump_Exceptions JumpException = new Frm_Jump_Exceptions();
            JumpException.Show();

        }
        #endregion 

        #region Evento enter del groupbox4
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        #endregion 

        #region Evento clic1 del btn_delete
        private void btn_delete_Click_1(object sender, EventArgs e)
        {

        }
        #endregion 

        #region Evento DobleClick del Grid dg_ledger
        private void dg_ledger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            misglobales.jumper_code = txb_jumperid.Text;
            Frm_Ledger FrmLedger = new Frm_Ledger();
            FrmLedger.MdiParent = MDISkyDiveCuautla.ActiveForm;
            FrmLedger.WindowState = FormWindowState.Maximized;
            FrmLedger.Show();

        }
        #endregion 

        #region Evento click del chk_allownb
        private void chk_allowwnb_Click(object sender, EventArgs e)
        {
            conexion.RegistroLog(misglobales.usuario_idusuario, "jumper", "modificación del padlock para el jumper " + misglobales.jumper_code + " [Allow Transaction with no Balance] :" + chk_allowwnb.Checked.ToString());
        }
        #endregion 

        #region Evento click del chk_alldayjump
        private void chk_alldayjump_Click(object sender, EventArgs e)
        {
            conexion.RegistroLog(misglobales.usuario_idusuario, "jumper", "modificación del padlock para el jumper " + misglobales.jumper_code + " [All day jump] :" + chk_allowwnb.Checked.ToString());
        }
        #endregion 

        #region Eventoclick del chk_allowchangejumptype
        private void chk_allowchangejumptype_Click(object sender, EventArgs e)
        {
            conexion.RegistroLog(misglobales.usuario_idusuario, "jumper", "modificación del padlock para el jumper " + misglobales.jumper_code + " [Allow change jump type in manifest] :" + chk_allowwnb.Checked.ToString());
        }
        #endregion 

        #region Evento click del chk_allowpaidbyjumper
        private void chk_allowpaidbyjumper_Click(object sender, EventArgs e)
        {
            conexion.RegistroLog(misglobales.usuario_idusuario, "jumper", "modificación del padlock para el jumper " + misglobales.jumper_code + " [Allow Paid By Jumper] :" + chk_allowwnb.Checked.ToString());
        }
        #endregion 

        #region Evento click del chk_allowfirstjump
        private void chk_allowfirstjump_Click(object sender, EventArgs e)
        {
            conexion.RegistroLog(misglobales.usuario_idusuario, "jumper", "modificación del padlock para el jumper " + misglobales.jumper_code + " [Allow First Jump with no balance] :" + chk_allowwnb.Checked.ToString());
        }
        #endregion 

        #region Evento click del boton btn_resetflag
        private void btn_resetflag_Click(object sender, EventArgs e)
        {
            chk_allowwnb.Checked = false;
            chk_alldayjump.Checked = false;
            chk_allowchangejumptype.Checked = false;
            chk_allowpaidbyjumper.Checked = false;
            chk_allowfirstjump.Checked = false;

        }
        #endregion

        #region Evento ValueChanged del DatePart waiverdate
        private void dp_waiverdate_ValueChanged(object sender, EventArgs e)
        {
            dp_waiverdate.CustomFormat = "dd/MM/yyyy";
        }
        #endregion

        #region Evento ValueChanged del DatePart waiverdate
        private void dp_uspaexpiresdate_ValueChanged(object sender, EventArgs e)
        {
            dp_uspaexpiresdate.CustomFormat = "dd/MM/yyyy";
        }
        #endregion 

        private void txb_reserve_ValueChanged(object sender, EventArgs e)
        {
            txb_reserve.CustomFormat = "dd/MM/yyyy";
        }

       

        private void btn_preferences_Click(object sender, EventArgs e)
        {
            Frm_PreferenceReport FrmPreferenceJ = new Frm_PreferenceReport();
            FrmPreferenceJ.MdiParent = MDISkyDiveCuautla.ActiveForm;
            FrmPreferenceJ.WindowState = FormWindowState.Maximized;
            FrmPreferenceJ.Show();
        }

        #region Evento click del boton btn_ratings
        private void btn_ratings_Click(object sender, EventArgs e)
        {
            if (txb_lastname.Text != "")
            {
                misglobales._name = txb_lastname.Text + ", " + txb_firstname.Text;
                misglobales.jumper_code = txb_jumperid.Text;

                misglobales._tandemupcode = txb_jumperid.Text;
                misglobales.jumptype = cmb_defaultjumptype.Text;
                misglobales._TransaccionLedger = "-JMPTRN";

                Operacion.Frm_Jumper_Ratings _Ratings = new Operacion.Frm_Jumper_Ratings();
                _Ratings.Show();
            }
            else
            {
                misglobales._name = "";
                MessageBox.Show("Please, select jumper");
            }
        }
        #endregion


        #region Evento click del boton btn_preference
        private void btn_preferencias_Click(object sender, EventArgs e)
        {
            if (txb_lastname.Text != "")
            {
                misglobales._name = txb_lastname.Text + ", " + txb_firstname.Text;
                misglobales.jumper_code = txb_jumperid.Text;

                misglobales._tandemupcode = txb_jumperid.Text;
                misglobales.jumptype = cmb_defaultjumptype.Text;
                misglobales._TransaccionLedger = "-JMPTRN";

                Operacion.Frm_Jumper_Preferences _Preferences = new Operacion.Frm_Jumper_Preferences();
                _Preferences.Show();



            }
            else
            {
                misglobales._name = "";
                MessageBox.Show("Please, select jumper");
            }
        }
        #endregion

        private void chk_alldayjump_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dp_borndate_ValueChanged(object sender, EventArgs e)
        {
            dp_borndate.CustomFormat = "dd/MM/yyyy";
        }

        private void dp_datebegin_ValueChanged(object sender, EventArgs e)
        {
            dp_datebegin.CustomFormat = "dd/MM/yyyy";
        }

        private void chk_allowpaidbyjumper_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_totalbalance_Click(object sender, EventArgs e)
        {

        }






    }
}
