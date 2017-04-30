using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyDiveCuautla.Catalogos 
{
    public partial class Frm_Users : Form
    {

        #region variables de la clase
        ConectaBD Permisos = new ConectaBD();
        ConectaBD conexion = new ConectaBD();
        BindingSource fuente = new BindingSource();
        utilerias u = new utilerias();
        Int32 CambiaPassword = 0;
        #endregion

        #region Contructor de la Frm_Users
        public Frm_Users()
        {
            InitializeComponent();
        }
        #endregion 

        #region Evento click del btn_cerrar
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Boton Destroy
        private void btn_destroy_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        #region HabilitoObjetos
        private void habilitoobjetos()
        {
            bool lopresento = Permisos.habilitado("btn_destroy");
            btn_destroy.Enabled = lopresento;
            txb_pwd.Enabled = true;
            txb_pwd.Text = "";
            txb_pwdconfirm.Visible = false;
            lbl_confirmpwd.Visible = false;
            cmb_office.DropDownStyle = ComboBoxStyle.DropDown;
            cmb_role.DropDownStyle = ComboBoxStyle.DropDown;
            cmb_status.DropDownStyle = ComboBoxStyle.DropDown;

        }
        #endregion

        #region Load de la forma Usuarios
        private void Frm_Users_Load(object sender, EventArgs e)
        {

            habilitoobjetos();
            InicializaGridview();
            
        }
        #endregion

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            DataSet dsrol = conexion.ConsultaRol("");
            DataSet dsstatus = conexion.ConsultaStatus("");
            DataSet dsoffice = conexion.ConsultaOficina("");
            txb_user.Text = "";
            txb_email.Text = "";
            txb_firstname.Text = "";
            txb_lastname1.Text = "";
            txb_lastname2.Text = "";
            txb_pwd.Text = "";
            txb_pwdconfirm.Text = "";
            
            cmb_role.DataSource = dsrol.Tables[0].DefaultView;
            cmb_role.AutoCompleteCustomSource = LoadAutoComplete(dsrol, "ROL");
            cmb_role.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_role.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_role.ValueMember = "ROL";
            cmb_role.SelectedItem = null;
            
            cmb_status.DataSource = dsstatus.Tables[0].DefaultView;
            cmb_status.AutoCompleteCustomSource = LoadAutoComplete(dsstatus, "STATUS");
            cmb_status.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_status.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_status.ValueMember = "STATUS";
            cmb_status.SelectedItem = null;
            
            cmb_office.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_office.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            cmb_office.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_office.ValueMember = "OFICINA";
            cmb_office.SelectedItem = null;
        }
        #endregion

        #region Inicializa DataGrid Usuarios
        private void InicializaGridview()
        {
            try
            {
                String condicion= "";
                if (chb_activos.Checked == true) { condicion = " WHERE USUARIO.idestatus = 1"; } else { condicion = ""; }
                dg_usuarios.EnableHeadersVisualStyles = false;
                dg_usuarios.DataSource = conexion.ConsultaUsuarios( condicion);   //getdata(fuente;
                dg_usuarios.Columns[0].Width = 100; //user
                dg_usuarios.Columns[1].Width = 155; //first name
                dg_usuarios.Columns[2].Width = 135; //lastname 1
                dg_usuarios.Columns[3].Width = 135; //lastname 2
                dg_usuarios.Columns[4].Width = 250; //e-mail
                dg_usuarios.Columns[5].Width = 150; //user rol
                dg_usuarios.Columns[6].Width = 97; //status
                dg_usuarios.Columns[7].Width = 290; //OFFICE
                dg_usuarios.Columns[0].HeaderText = "USER";
                dg_usuarios.Columns[1].HeaderText = "FIRST NAME";
                dg_usuarios.Columns[2].HeaderText = "LAST NAME";
                dg_usuarios.Columns[3].HeaderText = "LAST SECOND NAME";
                dg_usuarios.Columns[4].HeaderText = "E-MAIL";
                dg_usuarios.Columns[5].HeaderText = "USER ROL";
                dg_usuarios.Columns[6].HeaderText = "STATUS";
                dg_usuarios.Columns[7].HeaderText = "OFFICE";
                u.Formatodgv(dg_usuarios);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Evento click en el Header del DataGridView
        private void dg_usuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dg_usuarios.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dg_usuarios.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted. 
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder. 
                if (oldColumn == newColumn &&
                    dg_usuarios.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dg_usuarios.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

        }
        #endregion

        #region Evento DataBindingComplete
        private void dg_usuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode. 
            foreach (DataGridViewColumn column in dg_usuarios.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion

        #region Evento click al Datagridview
        private void dg_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                InicializaObjetos();
                u.Pasarcampo(dg_usuarios, txb_user, "USER");
                u.Pasarcampo(dg_usuarios, txb_email, "E-MAIL");
                u.Pasarcampo(dg_usuarios, txb_firstname, "FIRST NAME");
                u.Pasarcampo(dg_usuarios, txb_lastname1, "LAST NAME 1");
                u.Pasarcampo(dg_usuarios, txb_lastname2, "LAST NAME 2");
                u.Pasarcombo(dg_usuarios, cmb_role, "USER ROL");
                u.Pasarcombo(dg_usuarios, cmb_status, "STATUS");
                u.Pasarcombo(dg_usuarios, cmb_office, "OFFICE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Evento pierde foco el campo usuario
        private void txb_user_LostFocus(object sender, EventArgs e)
        {

            if (u.IsValidLength(txb_user.Text, 16))
            {

            }
            else
            {
                MessageBox.Show("incorrect lenght user, max 15 characters");
                txb_user.Focus();
                txb_user.SelectAll();
            }
        }

        #endregion

        #region evento pierde foco el campo email
        private void txb_email_LostFocus(object sender, EventArgs e)
        {
            if (txb_email.Text.Length >= 1)
            {
                if (u.IsValidEmail(txb_email.Text))
                {

                }
                else
                {

                    MessageBox.Show("incorrect format e-mail");
                    txb_email.Focus();

                }
            }
        }
        #endregion

        #region Botón limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion

        #region Boton cerrar
        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Cargar datos buscados
        private void CargaDatosBuscados(string condicion)
        {
            DataSet ds;
            ds = conexion.Consulta1Usuario(condicion);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txb_user.Text = ds.Tables[0].Rows[0][0].ToString();
                txb_firstname.Text = ds.Tables[0].Rows[0][1].ToString();
                txb_lastname1.Text = ds.Tables[0].Rows[0][2].ToString();
                txb_lastname2.Text = ds.Tables[0].Rows[0][3].ToString();
                txb_email.Text = ds.Tables[0].Rows[0][4].ToString();
                cmb_role.SelectedText = ds.Tables[0].Rows[0][5].ToString();
                cmb_status.SelectedText = ds.Tables[0].Rows[0][6].ToString();
                cmb_office.SelectedText = ds.Tables[0].Rows[0][7].ToString();
            }
            else 
            {
                MessageBox.Show("Can not information about");
            }
        }
        #endregion

        #region Boton buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string condicion = " ";

            
            if (txb_user.Text != "")
            {
                if (condicion == " ") 
                   { 
                    condicion = " WHERE "; 
                   }
                condicion += " USUARIO.USUARIO = '" + txb_user.Text + "'";
               
            }

            if (txb_firstname.Text != "")
            {
                if (condicion == " ")
                {
                    condicion = " WHERE ";
                    condicion += " USUARIO.NOMBRE = '" + txb_firstname.Text + "'";
                }
                else
                {
                    condicion += " AND USUARIO.NOMBRE = '" + txb_firstname.Text + "'";
                }
            }

            if (txb_lastname1.Text != "")
            {
                if (condicion == " ")
                {
                    condicion = " WHERE ";
                    condicion += " USUARIO.PATERNO = '" + txb_lastname1.Text + "'";
                }
                else
                {
                    condicion += " AND USUARIO.PATERNO = '" + txb_lastname1.Text + "'";
                }
            }


            if (txb_lastname2.Text != "")
            {
                if (condicion == " ")
                {
                    condicion = " WHERE ";
                    condicion += " USUARIO.MATERNO = '" + txb_lastname2.Text + "'";
                }
                else
                {
                    condicion += " AND USUARIO.MATERNO = '" + txb_lastname2.Text + "'";
                }
            }


            if (condicion != " ")
            {
                CargaDatosBuscados(condicion);
            }
            else
            {
                MessageBox.Show("Please, type some data to search");
            }

            

        }
        #endregion

        #region Evento Texto cambiado en el txb_pwd
        private void txb_pwd_TextChanged(object sender, EventArgs e)
        {
            lbl_confirmpwd.Visible = true;
            txb_pwdconfirm.Visible = true;
            txb_pwdconfirm.Enabled = true;

        }
        #endregion

        #region Evento pierde foco el campo CONFIRMA EL PWD
        private void txb_pwdconfirm_LostFocus(object sender, EventArgs e)
        {
            if (txb_pwd.Text != txb_pwdconfirm.Text)
            {
                MessageBox.Show("Error: type the same password into PASSWORD and CONFIRM fields");
                txb_pwd.Focus();
                txb_pwd.SelectAll();

            }
            else
            {
                CambiaPassword = 1;
            }
        }
        #endregion

        #region Valida si estan llenos todos los campos
        public bool validacampos()
        {

            txb_user.Text = u.Parseacomilla(txb_user.Text);
            txb_firstname.Text = u.Parseacomilla(txb_firstname.Text);
            txb_email.Text = u.Parseacomilla(txb_email.Text);
            txb_lastname1.Text = u.Parseacomilla(txb_lastname1.Text);
            txb_lastname2.Text = u.Parseacomilla(txb_lastname2.Text);


            if (txb_user.Text == "")
            {
                MessageBox.Show("Need type a USER");
                return false;

            }
            if (txb_firstname.Text == "")
            {
                MessageBox.Show("Need type a FIRST NAME");
                return false;
            }
            if (txb_lastname1.Text == "")
            {
                MessageBox.Show("Need type a LAST NAME");
                return false;
            }
            if (txb_lastname2.Text == "")
            {
                MessageBox.Show("Need type a LAST SECOND NAME");
                return false;
            }
            if (txb_email.Text == "")
            {
                MessageBox.Show("Need type a E-MAIL");
                return false;
            }


            return true;

        }
        #endregion

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            ds = conexion.Consulta1Usuario(condicion);
            if (ds.Tables[0].Rows.Count==0)
            {
                return "insert";
            }
            else
            {
                return "update";
            }
        }
        #endregion

        #region Boton Guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validacampos())
            {
                string condicion = " WHERE ";
                string campos = "";
                string tabla = "dbo.ct_usuario";
                string valores = "";
                DataSet dsrol = conexion.ConsultaRol(" WHERE DESCRIPCION = '" + cmb_role.Text + "'");
                DataSet dsstatus = conexion.ConsultaStatus(" WHERE DESCRIPCION = '" + cmb_status.Text + "'");
                DataSet dsoffice = conexion.ConsultaOficina(" WHERE NOMBRE = '" + cmb_office.Text + "'");

                condicion += " USUARIO = '" + txb_user.Text + "'";
                if (InserUpdate(condicion) == "insert")
                {
                    //insert
                    campos = "usuario, contraseña, nombre, paterno, materno, email, idperfil, idoficina, fecha_creacion, idusuariocreador, idestatus, autenticacion, fecha_actualizacion";
                    valores = @"'" + txb_user.Text + "', convert(varbinary(255), pwdencrypt ('"+ txb_pwd.Text +"')), '" + txb_firstname.Text + "', '"
                             + txb_lastname1.Text + "', '" + txb_lastname2.Text + "', '" + txb_email.Text + "', " + dsrol.Tables[0].Rows[0][0].ToString()
                             + ", " + dsoffice.Tables[0].Rows[0][0].ToString() +", getdate(), " + misglobales.usuario_idusuario + ", " 
                             + dsstatus.Tables[0].Rows[0][0].ToString() + ", 'online', getdate()" ;
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                        MessageBox.Show("User created sucessfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try create user | " + ex.Message);
                    }
                }
                else 
                { 
                    //Update
                    campos = @"  nombre = '" + txb_firstname.Text + "'," +
                            " paterno = '" + txb_lastname1.Text + "', " +
                            " materno = '" + txb_lastname2.Text + "', " +
                            " email = '" + txb_email.Text + "', " +
                            " idperfil = " + dsrol.Tables[0].Rows[0][0].ToString() + ", " +
                            " idoficina =  " + dsoffice.Tables[0].Rows[0][0].ToString() + ", " +
                            " idestatus = " + dsstatus.Tables[0].Rows[0][0].ToString() + ", fecha_actualizacion = getdate() "; 

                    if(CambiaPassword == 1)
                    {
                        campos += " , contraseña = convert(varbinary(255), pwdencrypt ('" + txb_pwd.Text + "')) ";  
                                  
                    }
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                        MessageBox.Show("User updated sucessfully");
                        //UpdateTabla(campos, tabla, condicion)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try update user | " + ex.Message);
                    }
                }
                InicializaGridview();

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

        #region Metodo Borra registro
        private void BorraRegistro()
        {
            try
            {
                String tabla = "ct_usuario";
                String condicion = "  usuario = '" + Convert.ToString(dg_usuarios.Rows[dg_usuarios.CurrentRow.Index].Cells[0].Value) + "'";
                conexion.BorraRegistro(condicion, tabla);
                InicializaGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not delete it, This user have history trasactions please disable and save" + ex.Message);
            }
           

        }
        #endregion 

        #region Evenvo User Deleting Row del dg_usuarios
        private void dg_usuarios_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure disable this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                BorraRegistro();
            }
        }
        #endregion

        private void chb_activos_CheckedChanged(object sender, EventArgs e)
        {

            InicializaGridview();
        }




    }
}
