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
    public partial class Frm_Aditional_Services : Form
    {

        #region Variable locales
     
            ConectaBD conexion = new ConectaBD();
            utilerias u = new utilerias();
            String sql, condicion, tabla, valores, campos;
            Int32 _idaditionalservices = 0;
            Boolean _Insert = true;
            Int32 _status = 1;


        #endregion 



        public Frm_Aditional_Services()
        {
            InitializeComponent();
        }

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

        #region Load de la Forma Frm_Aditional
        private void Frm_Aditional_Services_Load(object sender, EventArgs e)
        {
            DataSet dsoffice = conexion.ConsultaOficina("");
            cmb_office.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_office.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            //cmb_office.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_office.DisplayMember = "OFICINA";
            cmb_office.ValueMember = "ID";
            cmb_office.SelectedValue =  misglobales.oficina_id_oficina;

            InicializaGridview();
            InicializaObjetos();
        }
        #endregion 

        #region Inicializa DataGrid Usuarios
        private void InicializaGridview()
        {
            try
            {
                dg_aditionalservices.EnableHeadersVisualStyles = false;
                dg_aditionalservices.DataSource = conexion.ConsultaAditionalServices(" Where  cto.nombre = '" + cmb_office.Text + "'");   //getdata(fuente;
                dg_aditionalservices.Columns[0].Width = 100; //ID
                dg_aditionalservices.Columns[0].Visible = true;

                dg_aditionalservices.Columns[1].Width = 200; //code
                dg_aditionalservices.Columns[1].Visible = true;

                dg_aditionalservices.Columns[2].Width = 300; //Descripcion
                dg_aditionalservices.Columns[2].Visible = true;

                dg_aditionalservices.Columns[3].Width = 100; //price
                dg_aditionalservices.Columns[3].Visible = true;

                dg_aditionalservices.Columns[4].Width = 100; //idchargetype
                dg_aditionalservices.Columns[4].Visible = true;

                dg_aditionalservices.Columns[5].Width = 200; //[codechargetype]
                dg_aditionalservices.Columns[5].Visible = true;

                dg_aditionalservices.Columns[6].Width = 100; //[idestatus]
                dg_aditionalservices.Columns[6].Visible = false;

                dg_aditionalservices.Columns[7].Width = 150; //[estaus]
                dg_aditionalservices.Columns[7].Visible = true;



                dg_aditionalservices.Columns[0].HeaderText = "ID";
                dg_aditionalservices.Columns[1].HeaderText = "CODE";
                dg_aditionalservices.Columns[2].HeaderText = "DESCRIPTION";
                dg_aditionalservices.Columns[3].HeaderText = "PRICE";
                dg_aditionalservices.Columns[4].HeaderText = "ID CHARGE TYPE";
                dg_aditionalservices.Columns[5].HeaderText = "CODE CHARGE TYPE";
                dg_aditionalservices.Columns[7].HeaderText = "ESTATUS";

                u.Formatodgv(dg_aditionalservices);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            chk_active.Checked = false;
            txb_code.Text = "";
        
            txb_price.Text = "";
          
            txb_description.Text = "";
            sql = @"select idchargetype, codigo, charge_type From dbo.CT_CHARGE_TYPE order by sort";
            try
            {
                DataSet dschargetype = conexion.ConsultaUniversal(sql, "", "CT_CHARGE_TYPE");
                cmb_chargetype.DataSource = dschargetype.Tables[0].DefaultView;
                cmb_chargetype.AutoCompleteCustomSource = u.LoadAutoComplete(dschargetype, "CHARGE_TYPE");
                cmb_chargetype.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_chargetype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_chargetype.ValueMember = "CHARGE_TYPE";
                cmb_chargetype.SelectedItem = null;
                cmb_chargetype.ValueMember = "idchargetype";
                btn_guardar.Text = "Save New";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }

        }
        #endregion

        #region Evento Cell Click de Aditional Services
        private void dg_aditionalservices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _idaditionalservices = Convert.ToInt32(dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[6].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;


            txb_code.Text = dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[1].Value.ToString();
            txb_code.Enabled = false;
            txb_description.Text = dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[2].Value.ToString();
            txb_price.Text = dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[3].Value.ToString();


            cmb_chargetype.Text = dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[5].Value.ToString();

            _Insert = false;
            if (_Insert == false) { btn_guardar.Text = "Update"; }

        }
        #endregion 

        #region Evento click del boton cerrar
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento clic del boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            chk_active.Checked = false;
            txb_code.Text = "";
            txb_description.Text = "";
            txb_price.Text = ""; 
        }
        #endregion

        #region Evento de cambio en el combo OFICINA
        private void cmb_office_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InicializaGridview();
            InicializaObjetos();

        }
        #endregion 

        #region Evento click del botón Guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (_Insert)
            {
                //insertar
                if (ValidaCampos())
                {
                    tabla = "CT_ADITIONAL_SERVICES";
                    campos = "code, Descripcion, price, idchargetype, codechargetype, idestatus, doficina";
                    valores = @"'" + txb_code.Text + "', '" + txb_description.Text + "', " + txb_price.Text + ", " + cmb_chargetype.SelectedValue + ", '" + cmb_chargetype.Text + "', "
                                   + _status + ", " + cmb_office.SelectedValue;
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                        InicializaGridview();
                        InicializaObjetos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try create new Aditional Services record, please contact system administrator | " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please review mandatory fields and try again ");
                }
            }
            else
            {
                if (ValidaCampos())
                {
                    tabla = "CT_ADITIONAL_SERVICES";
                    campos = @" idestatus = " + _status.ToString() + ", " +
                              " code = '" + txb_code.Text + "', " +
                              " price = " + txb_price.Text + ", " +
                              " [Descripcion] = '" + txb_description.Text + "', " +
                              " idoficina = " + cmb_office.SelectedValue + " ," +
                              " idchargetype = " + cmb_chargetype.SelectedValue + ", " +
                              " codechargetype = '" + cmb_chargetype.Text + "' ";
                    condicion = @" WHERE code = '" + txb_code.Text + "' and ID = " + dg_aditionalservices.Rows[dg_aditionalservices.CurrentRow.Index].Cells[0].Value.ToString();
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                        InicializaGridview();
                        InicializaObjetos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try update Aditional Services, please contact system administrator |" + ex.Message);
                    }
                }
             
             }

        }
        #endregion 


        #region Valida campos
        private Boolean ValidaCampos()
        {

            if (txb_code.Text.Length <= 10)
            {
                return false;
            }


            if (txb_description.Text.Length <= 5)
            {
                return false;
            }


            if (txb_price.Text.Length <= 0)
            {
                return false;
            }

            if (cmb_chargetype.Text == "")
            {
                return false;
            }


            u.Parseacomilla(txb_code.Text);
            u.Parseacomilla(txb_description.Text);


            return true; 
        }
        #endregion

        #region Evento Checked Changed
        private void chk_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_active.Checked == true)
            {
                _status = 1;
            }
            else
            {
                _status = 0;
            }
        }
        #endregion


    }
}
