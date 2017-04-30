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
    public partial class Frm_offices : Form
    {

        #region variables de la clase

        ConectaBD Permisos = new ConectaBD();
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        string condicion = "";
        string sql = "";
        #endregion

        #region Constructor de la Forma
        public Frm_offices()
        {
            InitializeComponent();
        }
        #endregion

        #region Load de la forma Usuarios
        private void Frm_offices_Load(object sender, EventArgs e)
        {
            habilitoobjetos();
            InicializaGridview();
        }
        #endregion

        #region HabilitoObjetos
        private void habilitoobjetos()
        {

            bool lopresento = Permisos.habilitado("btn_destroy");
            btn_destroy.Enabled = lopresento;
            cmb_responsable.DropDownStyle = ComboBoxStyle.DropDown;
            cmb_status.DropDownStyle = ComboBoxStyle.DropDown;
            Cmb_State.DropDownStyle = ComboBoxStyle.DropDown;

        }
        #endregion

        #region InicializaObjetos
        private void InicializaObjetos()
        {

            sql = @" SELECT RESPONSABLE.nombre + ' ' + RESPONSABLE.paterno + ' ' + RESPONSABLE.materno AS [RESPONSABLE]
                       FROM DBO.CT_USUARIO RESPONSABLE WHERE idestatus = 1";
            DataSet dsresponsable = conexion.ConsultaUniversal(sql, condicion, "CT_USUARIO");
            DataSet dsstatus = conexion.ConsultaStatus("");
            sql = @" SELECT ENTIDAD.descripcion AS [STATES DESCRIPTION]
                       FROM DBO.CT_ENTIDAD ENTIDAD ";
            DataSet dsstate = conexion.ConsultaUniversal(sql, condicion, "CT_ENTIDAD");


            txb_officename.Text = "";
            txb_geographical.Text = "";
            
            cmb_responsable.DataSource = dsresponsable.Tables[0].DefaultView;
            cmb_responsable.AutoCompleteCustomSource = LoadAutoComplete(dsresponsable, "RESPONSABLE");
            cmb_responsable.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_responsable.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_responsable.ValueMember = "RESPONSABLE";
            cmb_responsable.SelectedItem = null;

            cmb_status.DataSource = dsstatus.Tables[0].DefaultView;
            cmb_status.AutoCompleteCustomSource = LoadAutoComplete(dsstatus, "STATUS");
            cmb_status.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_status.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_status.ValueMember = "STATUS";
            cmb_status.SelectedItem = null;


            Cmb_State.DataSource = dsstate.Tables[0].DefaultView;
            Cmb_State.AutoCompleteCustomSource = LoadAutoComplete(dsstate, "STATES DESCRIPTION");
            Cmb_State.AutoCompleteMode = AutoCompleteMode.Suggest;
            Cmb_State.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Cmb_State.ValueMember = "STATES DESCRIPTION";
            Cmb_State.SelectedItem = null;

        }
        #endregion

        #region Inicializa DataGrid Usuarios
        private void InicializaGridview()
        {
            

            try
            {
                    dg_office.EnableHeadersVisualStyles = false;
                    dg_office.DataSource = conexion.ConsultaOficinas(condicion);   //getdata(fuente;
                    dg_office.Columns[0].Width = 210; //OFFICE NAME
                    dg_office.Columns[1].Width = 150; //RESPONSABLE
                    dg_office.Columns[2].Width = 200; //COORDINATES
                    dg_office.Columns[3].Width = 70;  //RENAPO CODE
                    dg_office.Columns[4].Width = 150;  //DESCRIPTION STATE
                    dg_office.Columns[5].Width = 150;  //MODIFY FOR
                    dg_office.Columns[6].Width = 168;  //UPDATE DATE
                    dg_office.Columns[7].Width = 168;  //STATUS
                    dg_office.Columns[0].HeaderText = "OFFICE NAME";
                    dg_office.Columns[1].HeaderText = "OFFICE RESPONSABLE";
                    dg_office.Columns[2].HeaderText = "COORDINATES";
                    dg_office.Columns[3].HeaderText = "RENAPO CODE";
                    dg_office.Columns[4].HeaderText = "STATES DESCRIPTION";
                    dg_office.Columns[5].HeaderText = "MODIFY FOR";
                    dg_office.Columns[6].HeaderText = "UPDATE DATE";
                    dg_office.Columns[7].HeaderText = "STATUS";

                    u.Formatodgv(dg_office);
                    InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Evento click al Datagridview
        private void dg_office_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                InicializaObjetos();
                u.Pasarcampo(dg_office, txb_officename, "OFFICE NAME");
                u.Pasarcampo(dg_office, txb_geographical, "COORDINATES");
                u.Pasarcombo(dg_office, Cmb_State, "STATES DESCRIPTION");
                u.Pasarcombo(dg_office, cmb_status, "STATUS");
                u.Pasarcombo(dg_office, cmb_responsable, "OFFICE RESPONSABLE");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

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

        #region Cargar datos buscados
        private void CargaDatosBuscados(string condicion)
        {
            DataTable dt;

            dt = conexion.ConsultaOficinas(condicion);

            if (dt.Rows.Count > 0)
            {

                txb_officename.Text = dt.Rows[0].ItemArray[0].ToString();
                cmb_responsable.SelectedText = dt.Rows[0].ItemArray[1].ToString();
                txb_geographical.Text = dt.Rows[0].ItemArray[2].ToString();
                Cmb_State.SelectedText = dt.Rows[0].ItemArray[4].ToString();
                cmb_status.SelectedText = dt.Rows[0].ItemArray[7].ToString();
            }
            else
            { 
                MessageBox.Show("Can not information about"); 
            }
        }
        #endregion

        #region Boton Buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string condicion = " ";


            if (txb_officename.Text != "")
            {
                if (condicion == " ")
                {
                    condicion = " WHERE ";
                }
                condicion += "  OFICINA.NOMBRE = '" + txb_officename.Text + "'";

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

        #region Valida si estan llenos todos los campos
        public bool validacampos()
        {
            if (txb_officename.Text == "")
            {
                MessageBox.Show("Need type a OFFICE NAME");
                return false;

            }
            if (cmb_responsable.Text == "")
            {
                MessageBox.Show("Need select a RESPONSABLE");
                return false;
            }
            if (txb_geographical.Text == "")
            {
                MessageBox.Show("Need type a COORDINATES");
                return false;
            }
            if (Cmb_State.Text == "")
            {
                MessageBox.Show("Need select a STATE");
                return false;
            }
            if (cmb_status.Text == "")
            {
                MessageBox.Show("Need select a STATUS");
                return false;
            }

            return true;

        }
        #endregion

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            ds = conexion.ConsultaOficina(condicion);
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

        #region Boton Guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validacampos())
            {
                string condicion = " WHERE ";
                string campos = "";
                string tabla = "dbo.CT_OFICINA";
                string valores = "";
                DataSet dsoficina = conexion.ConsultaOficina(" WHERE NOMBRE = '" + txb_officename.Text + "'");
                //DataSet dsresponsble = conexion.Consulta1Usuario(" WHERE USUARIO.nombre + ' ' + USUARIO.paterno + ' ' +  USUARIO.materno  = '" + cmb_responsable + "'");
                DataSet dsresponsable = conexion.ConsultaUniversal("SELECT IDUSUARIO, USUARIO FROM dbo.CT_USUARIO", " WHERE USUARIO = '" + cmb_responsable.Text + "'", "CT_USUARIO");
                DataSet dsstatus = conexion.ConsultaStatus(" WHERE DESCRIPCION = '" + cmb_status.Text + "'");
                DataSet dsstate = conexion.ConsultaUniversal("SELECT identidad, descripcion FROM dbo.CT_ENTIDAD ", " WHERE descripcion = '" + Cmb_State.Text + "'", "CT_ENTIDAD");
                condicion += " NOMBRE = '" + txb_officename.Text + "'";
                String str = txb_geographical.Text;
                str = str.Replace("'", "''");
                if (InserUpdate(condicion) == "insert")
                {                    //INSERT
                    campos = "[identidad], [Nombre], [idusuariotitular], [ubicacion], [idusuario], [fecha_creacion], [idestatus]";
                    valores = @"" + dsstate.Tables[0].Rows[0][0].ToString() + ",'" +
                              txb_officename.Text + "'," + misglobales.usuario_idusuario  // corregir
                              + ", '" + str.ToString() +
                              "'," + misglobales.usuario_idusuario + ", getdate(), " + dsstatus.Tables[0].Rows[0][0].ToString() ;
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to create new DropZone, please contact system admin | ", ex.Message);

                    
                    }
                }
                else
                {
                    //Update
                    campos = @" [identidad] = "  +dsstate.Tables[0].Rows[0][0].ToString() + "," + 
                              "  [Nombre] =  '" + txb_officename.Text + "' ," +
                              "  [idusuariotitular] = " + misglobales.usuario_idusuario + "," +
                              "  [ubicacion] = '" + str.ToString() + "'," +
                              "  [idusuario] = " + misglobales.usuario_idusuario + " ," +
                              "  [fecha_creacion] = getdate() ," +
                              "  [idestatus] = " + dsstatus.Tables[0].Rows[0][0].ToString();
                    //condicion += " Nombre = '" + txb_officename.Text + "'";
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to update informacion DropZone, please contact to system admin | ", ex.Message);
                    }
                }
                InicializaGridview();
            }
        }
        #endregion

        #region Boton cerrar
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion


    }
}
