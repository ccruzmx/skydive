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
    public partial class Frm_Planes : Form
    {

        #region Variable locales
        Int32 _status = 1;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla, valores, campos;
        Int32 _idplane = 0;
        Boolean _Insert = true;
        #endregion 

        #region Constructor del Frm_Planes
        public Frm_Planes()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento click del btn_cerrar
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            chk_active.Checked = false;
            txb_code.Text = "";
            txb_aircraft.Text = "";
            txb_capacity.Text = "";
            txb_altitud.Text = "";
            txb_codey.Text = "";

            sql = @"select  paterno_piloto + ', ' + nombre_piloto as pilot from dbo.CT_PILOTO";
            try
            {
                DataSet dschargetype = conexion.ConsultaUniversal(sql, "", "CT_PILOTO");
                cmb_pilot.DataSource = dschargetype.Tables[0].DefaultView;
                cmb_pilot.AutoCompleteCustomSource = u.LoadAutoComplete(dschargetype, "PILOT");
                cmb_pilot.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb_pilot.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb_pilot.ValueMember = "PILOT";
                cmb_pilot.SelectedItem = null;
                _Insert = true;
                btn_guardar.Text = "Save New";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }


        }
        #endregion

        #region Inicializa DataGrid Plane
        private void InicializaGridview()
        {
            try
            {
                dg_plane.EnableHeadersVisualStyles = false;
                dg_plane.DataSource = conexion.ConsultaPlane();
                dg_plane.Columns[0].Width = 100; //idaeronave
                dg_plane.Columns[0].Visible = false;
                dg_plane.Columns[1].Width = 50; //codigo
                dg_plane.Columns[1].Visible = false; 
                dg_plane.Columns[2].Width = 230; //matricula
                dg_plane.Columns[3].Width = 100; //capacidadpersonas
                dg_plane.Columns[4].Width = 100; //capacidadpeso
                dg_plane.Columns[4].Visible = false;
                dg_plane.Columns[5].Width = 150; //idunidadmedida
                dg_plane.Columns[5].Visible = false;
                dg_plane.Columns[6].Width = 400; //idpiloto
                dg_plane.Columns[6].Visible = false;
                dg_plane.Columns[7].Width = 400; //nombre
                dg_plane.Columns[7].Visible = false;
                dg_plane.Columns[8].Width = 400; //paterno
                dg_plane.Columns[8].Visible = false;
                dg_plane.Columns[9].Width = 400; //materno
                dg_plane.Columns[9].Visible = false;
                dg_plane.Columns[10].Width = 600; //piloto
                dg_plane.Columns[11].Width = 100; //altitud
                dg_plane.Columns[12].Width = 100; //codey
                dg_plane.Columns[13].Width = 100; //IDESTATUS
                dg_plane.Columns[14].Width = 200; //fechamovimiento

                dg_plane.Columns[0].HeaderText = "idaeronave";
                dg_plane.Columns[1].HeaderText = "codigo";
                dg_plane.Columns[2].HeaderText = "AIR CRAFT REGISTRATION";
                dg_plane.Columns[3].HeaderText = "CAPACITY";
                dg_plane.Columns[4].HeaderText = "CAPACITY WEIGHT";
                dg_plane.Columns[5].HeaderText = "idunidadmedida";
                dg_plane.Columns[6].HeaderText = "idpiloto";
                dg_plane.Columns[7].HeaderText = "nombre";
                dg_plane.Columns[8].HeaderText = "paterno";
                dg_plane.Columns[9].HeaderText = "materno";

                dg_plane.Columns[10].HeaderText = "PILOT";
                dg_plane.Columns[11].HeaderText = "ALTITUDDE";
                dg_plane.Columns[12].HeaderText = "CODEY";
                dg_plane.Columns[13].HeaderText = "ACTIVE";
                dg_plane.Columns[14].HeaderText = "UPDATE DATE";

                u.Formatodgv(dg_plane);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Load del Frm_planes
        private void Frm_Planes_Load(object sender, EventArgs e)
        {
            InicializaGridview();
        }
        #endregion 

        #region Evento Checked Changed del chk_active
        private void chk_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_active.Checked == true) { _status = 1; } else { _status = 2; }
        }
        #endregion

        #region Evento click del btn_limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion 

        #region Evento Mouse Click del dg_plane
        private void dg_plane_MouseClick(object sender, MouseEventArgs e)
        {
            cmb_pilot.SelectedItem = null;
            _idplane = Convert.ToInt32(dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[13].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_code.Text = dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[1].Value.ToString();
            txb_aircraft.Text = dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[2].Value.ToString();
            txb_capacity.Text = dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[3].Value.ToString();
            txb_altitud.Text = dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[11].Value.ToString();
            cmb_pilot.SelectedValue = dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[10].Value.ToString();
            txb_codey.Text = dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[12].Value.ToString();
            _Insert = false;
            if (_Insert == false) { btn_guardar.Text = "Update"; }
        }
        #endregion

        #region Evento User Deleting Row del dg_plane
        private void dg_plane_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("this process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                tabla = "CT_AERONAVE";
                campos = @"idestatus = 4";
                condicion = " where idaeronave = " + dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[0].Value.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);

            }
        }
        #endregion 

        #region Valida campos
        private Boolean ValidaCampos()
        {


            txb_aircraft.Text = u.Parseacomilla(txb_aircraft.Text);
            txb_codey.Text = u.Parseacomilla(txb_codey.Text);
            if (txb_aircraft.Text.Length <= 4)
            {
                return false;

            }
            return true;

        }
        #endregion 

        #region Evento click del btn_guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (_Insert)
            {
                //insertar
                if (ValidaCampos())
                {
                    DataSet dspilot = new DataSet();
                    sql = @"SELECT IDPILOTO FROM dbo.CT_PILOTO WHERE paterno_piloto + ', ' + nombre_piloto = '" + cmb_pilot.SelectedValue.ToString() + "'";
                    tabla = "CT_PILOTO";
                    dspilot = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _idpiloto = Convert.ToInt32(dspilot.Tables[0].Rows[0].ItemArray[0].ToString());
                    dspilot.Dispose();

                    DataSet dsaeronave = new DataSet();
                    sql = @"Select max(idaeronave)+1 idaeronave
                             From dbo.CT_AERONAVE";
                    tabla = "CT_AERONAVE";
                    dsaeronave = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _id = Convert.ToInt32(dsaeronave.Tables[0].Rows[0].ItemArray[0].ToString());
                    txb_code.Text = _id.ToString() + "-" + dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[8].ToString().Substring(1, 3).ToUpper();
                    dsaeronave.Dispose();

                    if (_status != 1) { _status = 2; }
                    tabla = "CT_AERONAVE";
                    campos = "codigo, matricula, capacidadpersonas, capacidadpeso, idunidadmedida, idpiloto, altitud, codey, fechamovimiento, idestatus";
                    valores = @"'" + txb_code.Text + "', '" + txb_aircraft.Text + "', " + txb_capacity.Text + ", 0, 'kg', " + _idpiloto.ToString() + ", '" + txb_altitud.Text + "', '"+txb_codey.Text+"', getdate(), " + _status.ToString() ;
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try create new Plane, please contact system administrator | ", ex.Message);

                    }
                }
                else
                {
                    MessageBox.Show("Warning: Please review fields informations an try save again");
                }

            }
            else
            {
                //actualizar
                if (ValidaCampos())
                {
                    DataSet dspilot = new DataSet();
                    sql = @"SELECT IDPILOTO FROM dbo.CT_PILOTO WHERE paterno_piloto + ', ' + nombre_piloto = '" + cmb_pilot.SelectedValue.ToString() + "'";
                    tabla = "CT_PILOTO";
                    dspilot = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _idpiloto = Convert.ToInt32(dspilot.Tables[0].Rows[0].ItemArray[0].ToString());
                    if (_status != 1) { _status = 2; }
                    dspilot.Dispose();
                    tabla = "CT_AERONAVE";
                    campos = @" matricula = '"+ txb_aircraft.Text + "', " +
                              " capacidadpersonas = "+ txb_capacity.Text +", " +
                              " idpiloto = " + _idpiloto.ToString() + ", " +
                              " altitud = '"+ txb_altitud.Text + "', " + 
                              " codey = '" + txb_codey.Text + "', " +
                              " fechamovimiento = getdate(), " +
                              " idestatus = " + _status.ToString();
                    condicion = " WHERE idaeronave = " + _idplane.ToString();
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try update this plane, please contact system administrator | ", ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Warning: Please review fields informations an try update again");
                }
            }
            InicializaGridview();

        }
        #endregion 

        #region Evento KeyPress del txb_capacity
        private void txb_capacity_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Evento KeyPress del txb_altitud
        private void txb_altitud_KeyPress(object sender, KeyPressEventArgs e)
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




    }
}
