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
    public partial class Frm_Prospect : Form
    {

        Boolean _leejumper = false;
        Boolean _Insert = true;

        ConectaBD conexion = new ConectaBD();
        DataSet dssourcetype;
        utilerias u = new utilerias();
        String sql, condicion, tabla , campos= "";

        #region Constructor de la forma Frm_Prospect
        public Frm_Prospect()
        {
            InitializeComponent();
        }
        #endregion 

        #region Load de la forma Frm_Prospect
        private void Frm_Prospect_Load(object sender, EventArgs e)
        {
            LimpiaCampos();
        }
        #endregion

        #region Evento click del boton exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento Click del boton find
        private void btn_find_Click(object sender, EventArgs e)
        {
            
            Frm_ProspectSelection FrmProspectSelector = new Frm_ProspectSelection();
            FrmProspectSelector.Show();
            _leejumper = true;
            _Insert = false;
            tmr_readjumper.Start();

        }
        #endregion 

        #region Limpia Campos
        private void LimpiaCampos()
        {
            txb_prospectid.Text = "";
            txb_dateentered.Text = "";
            txb_Name.Text = "";
            txb_lastname.Text = "";
            txb_organization.Text = "";
            txb_address.Text = "";
            txb_address2.Text = "";
            txb_city.Text = "";
            txb_state.Text = "";
            txb_country.Text = "";
            txb_postalcode.Text = "";
            txb_homephone.Text = "";
            txb_workphone.Text = "";
            txb_fax.Text = "";
            txb_mobil.Text = "";
            txb_nextel.Text = "";
            txb_other.Text = "";
            txb_email.Text = "";
            chk_interested.Checked = false;
            txb_referenced.Text = "";
            txb_jumpcount.Text = "";
            txb_lastjump.Text = "";
            cmb_sourcetype.SelectedText = "";
            txb_note.Text = "";
            btn_save.Enabled = false;
        }
        #endregion

        #region Carga Campos
        private void CargaCampos()
        {
            DataTable dt = new DataTable();
            txb_prospectid.Text = misglobales.jumper_code_list;


            sql = @"select Source_Type From dbo.CT_SOURCE_TYPE WHERE idestatus <> 4 ORDER BY orden";
            dssourcetype = conexion.ConsultaUniversal(sql, "", "CT_SOURCE_TYPE");
            cmb_sourcetype.DataSource = dssourcetype.Tables[0].DefaultView;
            cmb_sourcetype.AutoCompleteCustomSource = u.LoadAutoComplete(dssourcetype, "Source_Type");
            cmb_sourcetype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_sourcetype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_sourcetype.ValueMember = "Source_Type";
            cmb_sourcetype.SelectedItem = null;

            if (txb_prospectid.Text != "")
            {
                condicion = " WHERE idtandemup = '" + txb_prospectid.Text + "' ";

                dt = conexion.ConsultaProspect(condicion, txb_prospectid.Text);

                misglobales.jumperid = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                txb_dateentered.Text = dt.Rows[0].ItemArray[2].ToString();
                txb_Name.Text = dt.Rows[0].ItemArray[12].ToString();
                txb_lastname.Text = dt.Rows[0].ItemArray[11].ToString();
                txb_organization.Text = dt.Rows[0].ItemArray[4].ToString();
                txb_address.Text = dt.Rows[0].ItemArray[13].ToString();
                txb_address2.Text = dt.Rows[0].ItemArray[14].ToString();
                txb_city.Text = dt.Rows[0].ItemArray[15].ToString();
                txb_state.Text = dt.Rows[0].ItemArray[16].ToString();
                txb_country.Text = dt.Rows[0].ItemArray[17].ToString();
                txb_postalcode.Text = dt.Rows[0].ItemArray[18].ToString();
                txb_homephone.Text = dt.Rows[0].ItemArray[19].ToString();
                txb_workphone.Text = dt.Rows[0].ItemArray[20].ToString();
                txb_fax.Text = dt.Rows[0].ItemArray[21].ToString();
                txb_mobil.Text = dt.Rows[0].ItemArray[22].ToString();
                txb_nextel.Text = dt.Rows[0].ItemArray[23].ToString();
                txb_other.Text = dt.Rows[0].ItemArray[24].ToString();
                txb_email.Text = dt.Rows[0].ItemArray[25].ToString();
                chk_interested.Checked = Convert.ToBoolean(dt.Rows[0].ItemArray[6]);
                txb_referenced.Text = dt.Rows[0].ItemArray[5].ToString();
                txb_jumpcount.Text = dt.Rows[0].ItemArray[7].ToString();
                txb_lastjump.Text = dt.Rows[0].ItemArray[8].ToString();
                cmb_sourcetype.SelectedText = dt.Rows[0].ItemArray[26].ToString();
                txb_note.Text = dt.Rows[0].ItemArray[10].ToString();
                if (_leejumper && misglobales._readjumper) { tmr_readjumper.Stop(); _leejumper = false; misglobales._readjumper = false; }


            }



        }
        #endregion

        #region Evento Tick del tmr_readjumper
        private void tmr_readjumper_Tick(object sender, EventArgs e)
        {
            if (misglobales._readjumper)
            {
                LimpiaCampos();
                CargaCampos();
                btn_save.Enabled = true;

                //txb_balancejumper.Text = Convert.ToString(u.BalanceSaltos());
            }
        }
        #endregion

        #region Evento click al boton Clear Screen
        private void btn_clear_Click(object sender, EventArgs e)
        {
            LimpiaCampos();
        }
        #endregion 

        #region Evento Click del boton Add
        private void btn_add_Click(object sender, EventArgs e)
        {
            LimpiaCampos();
        }
        #endregion 

        #region Evento click del boton delte
        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (txb_prospectid.Text != "")
            {
                tabla = "CT_PROSPECT";
                condicion = " CODE = '" + txb_prospectid.Text + "'";
                conexion.BorraRegistro(condicion, tabla);
            }
            else
            {
                MessageBox.Show("Please select prospect before delete action");
            }
        }
        #endregion 

        #region Evento click del boton make
        private void btn_make_Click(object sender, EventArgs e)
        {
            if (txb_prospectid.Text != "")
            {

                // grava en Jumper el registro

                tabla = "CT_JUMPER";
                campos = "codigo, nombre, paterno, materno, total_saltos, Fecha_alta, Fecha_ultimo_salto, Equipamiento, ReserveRepackDate, USPA_Member, USPA_Licence, USPA_Expires, idjumpertypecode, idjumptypecode, id_sourcetypecode, Balance, Balance_Jump, Waiver_Expires, Locker, Reference_idJumpercode, Debit_Padlock, All_Day_Jump_padlock, Allow_Override_Padlock, idoficina, Note, Aliasjumper, systemflag, Allow_PaidBy, Allow_FirstJump, FirstJump_Padlock, name, lastname, address1, address2, city, state, country, postal_code, home_phone, work_phone, fax, mobile_phone, other_phone, email, credit_card, medical_insurance, nextel, idestatus";
                sql = @"SELECT CODE, NAME, Firstname, lastname, jump_count, GETDATE(), lastJumpDate, NULL, NULL, NULL, NULL, NULL, NULL, NULL, id_source_type, 0, 0, NULL, NULL, NULL, 0,0,0,idoficina,  
                               note, NULL, 0,0,0,0,Firstname, lastname,  Adress, Adress2, City, [State], Country, Postal_Code, Home_phone, Work_phone, fax, Mobile_phone, Other_phone, email,
                               NULL, Medical_insurance, Nextel,  1
                          FROM dbo.CT_PROSPECT
                         WHERE CODE = '"+ txb_prospectid.Text +"'";

                try
                {
                    conexion.InsertTablaQry(campos, tabla, sql);


                    // lo borra de Prospect
                    tabla = "CT_PROSPECT";
                    condicion = "CODE = '" + txb_prospectid.Text + "'";
                    conexion.BorraRegistro(condicion, tabla);
                    conexion.CloseDB();
                    LimpiaCampos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try make to jumper this prospect, contact system administrator or try later | " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please select prospect before make jumper action");
            }


        }
        #endregion 

        #region Evento click del boton save
        private void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                tabla = "TB_TANDEMUP";
                campos = @" organization = '" + txb_organization.Text + "', " +
                          " Adress = '" + txb_address.Text + "', " +
                          " Adress2 = '" + txb_address2.Text + "', " +
                          " City = '" + txb_city.Text + "', " +
                          " State = '" + txb_state.Text + "', " +
                          " Country = '" + txb_country.Text + "', " +
                          " Postal_Code = '" + txb_postalcode.Text + "', " +
                          " Home_phone = '" + txb_homephone.Text + "', " +
                          " [Work_phone] = '" + txb_workphone.Text + "', " +
                          " [fax] = '" + txb_fax.Text + "', " +
                          " [Mobile_phone] = '" + txb_mobil.Text + "', " +
                          " [Nextel] = '" + txb_nextel.Text + "', " +
                          " [Other_phone]  = '" + txb_other.Text + "', " +
                          " email  = '" + txb_email.Text + "', " +
                          " referenced_by  = '" + txb_referenced.Text + "', " +
                          " [Source_type] = '" + cmb_sourcetype.Text + "',  " +
                          " [note] = '" + txb_note.Text + "'  ";
                condicion = " where idtandemup = " + txb_prospectid.Text;
                conexion.UpdateTabla(campos, tabla, condicion);

                MessageBox.Show("Save successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try update prospect : " + ex.Message);
            }

        }
        #endregion 

        #region Evento pierde foco el campo usuario
        private void txb_postalcode_LostFocus(object sender, EventArgs e)
        {
           
            if (u.IsValidLength(txb_postalcode.Text, 5))
            {
                // AQUI VA LA CONSULTA DEL CODIGO POSTAL PARA RELLENAR COLONIA, ESTADO


            }
            else
            {
                MessageBox.Show("incorrect lenght user, max 15 characters");
                //txb_user.Focus();
                //txb_user.SelectAll();
            }
        }

        #endregion


        private void txb_Name_TextChanged(object sender, EventArgs e)
        {
            //txb_Name.Text = txb_Name.Text.ToUpper();


        }

        private void txb_lastname_TextChanged(object sender, EventArgs e)
        {
            //txb_lastname.Text = txb_lastname.Text.ToUpper();
        }

        private void txb_organization_TextChanged(object sender, EventArgs e)
        {
            //txb_organization.Text = txb_organization.Text.ToUpper();

        }

        private void txb_address_TextChanged(object sender, EventArgs e)
        {
            //txb_address.Text = txb_address.Text.ToUpper();

        }

        private void txb_address2_TextChanged(object sender, EventArgs e)
        {
            //txb_address2.Text = txb_address2.Text.ToUpper();
        }

        private void txb_city_TextChanged(object sender, EventArgs e)
        {
            //txb_city.Text = txb_city.Text.ToUpper();
        }

        private void txb_state_TextChanged(object sender, EventArgs e)
        {
            //txb_state.Text = txb_state.Text.ToUpper();
        }

        private void txb_country_TextChanged(object sender, EventArgs e)
        {
            //txb_country.Text = txb_country.Text.ToUpper();
        }

        private void txb_email_TextChanged(object sender, EventArgs e)
        {
            //txb_email.Text = txb_email.Text.ToUpper();
        }

        private void txb_referenced_TextChanged(object sender, EventArgs e)
        {
            //txb_referenced.Text = txb_referenced.Text.ToUpper();
        }



    }
}
