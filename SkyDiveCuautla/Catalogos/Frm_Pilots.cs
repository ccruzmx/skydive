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
    public partial class Frm_Pilots : Form
    {

        #region Variables Locales
            ConectaBD conexion = new ConectaBD();
            utilerias u = new utilerias();
            String sql, condicion, tabla, valores, campos, _codigo;
            Int32 _idpiloto = 0, _status = 2;
            Boolean _Insert = true;
        #endregion 

        #region Inicializa DataGrid Jumpers Type
        private void InicializaGridview()
        {
            try
            {
                dg_piloto.EnableHeadersVisualStyles = false;
                dg_piloto.DataSource = conexion.ConsultaPilot();
                dg_piloto.Columns[0].Width = 100; //idpiloto
                dg_piloto.Columns[0].Visible = false;
                dg_piloto.Columns[1].Width = 50; //Codigo
                dg_piloto.Columns[1].Visible = false;
                dg_piloto.Columns[2].Width = 150; //name piloto
                dg_piloto.Columns[3].Width = 150; //paterno piloto
                dg_piloto.Columns[4].Width = 150; //materno piloto
                dg_piloto.Columns[5].Width = 350; //licencia
                dg_piloto.Columns[6].Width = 80; //idestatus
                dg_piloto.Columns[7].Width = 200; //fecha actualizacion
                dg_piloto.Columns[0].HeaderText = "idpiloto";
                dg_piloto.Columns[1].HeaderText = "Codigo";
                dg_piloto.Columns[2].HeaderText = "FIRTS NAME";
                dg_piloto.Columns[3].HeaderText = "LAST NAME";
                dg_piloto.Columns[4].HeaderText = "SECOND LAST NAME";
                dg_piloto.Columns[5].HeaderText = "LICENCE";
                dg_piloto.Columns[6].HeaderText = "ACTIVE";
                dg_piloto.Columns[7].HeaderText = "UPDATE DATE";
                u.Formatodgv(dg_piloto);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        #endregion

        #region Constructor del frm_Pilots
        public Frm_Pilots()
        {
            InitializeComponent();
        }
        #endregion 

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            chk_active.Checked = false;
            txb_pilotname.Text = "";
            txb_lastname.Text = "";
            txb_secondlastname.Text = "";
            txb_license.Text = "";
            txb_code.Text = "";
            _Insert = true;
            btn_guardar.Text = "Save";
        }
        #endregion 

        #region Evento click del btn_cerrar
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento click del btn_click
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion 

        #region Evento Checked Changed del chk_active
        private void chk_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_active.Checked == true) { _status = 1; } else { _status = 2; }
        }
        #endregion

        #region Load de la Frm_Pilots
        private void Frm_Pilots_Load(object sender, EventArgs e)
        {
            InicializaGridview();
        }
        #endregion 

        #region Valida campos
        private Boolean ValidaCampos()
        {

            txb_pilotname.Text = u.Parseacomilla(txb_pilotname.Text);
            txb_lastname.Text = u.Parseacomilla(txb_lastname.Text);
            txb_secondlastname.Text = u.Parseacomilla(txb_secondlastname.Text);
            txb_license.Text = u.Parseacomilla(txb_license.Text);


            if (txb_pilotname.Text.Length <= 3)
            {
                return false;

            }
            if (txb_lastname.Text.Length <= 2)
            {
                return false;

            }
            if (txb_secondlastname.Text.Length <= 3)
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
                    DataSet dspiloto = new DataSet();
                    sql = @"Select max(idpiloto)+1 idpiloto
                             From dbo.CT_PILOTO";
                    tabla = "CT_PILOTO";
                    dspiloto = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _id = Convert.ToInt32(dspiloto.Tables[0].Rows[0].ItemArray[0].ToString());
                    txb_code.Text = _id.ToString() + "-" + txb_pilotname.Text.Substring(1, 3).ToUpper();
                    dspiloto.Dispose();

                    if (_status != 1) { _status = 2; }
                    tabla = "CT_PILOTO";
                    campos = "Codigo, nombre_piloto, paterno_piloto, materno_piloto, licencia, idestatus, fechamovimiento";
                    valores = @"'" + txb_code.Text + "', '" + txb_pilotname.Text + "', '" + txb_lastname.Text + "', '" + txb_secondlastname.Text + "', '" + txb_license.Text + "', " + _status.ToString() + ",getdate() ";
                    conexion.InsertTabla(campos, tabla, valores);
                }
                else
                {
                    MessageBox.Show("Warning: Please review fields informations and try save again");
                }

            }
            else
            {
                //actualizar
                if (ValidaCampos())
                {
                    if (_status != 1) { _status = 2; }
                    tabla = "CT_PILOTO";
                    campos = @" Codigo = '" + txb_code.Text + "'," +
                              " nombre_piloto = '" + txb_pilotname.Text + "'," +
                              " paterno_piloto = '" + txb_lastname.Text + "'," +
                              " materno_piloto = '" + txb_secondlastname.Text + "'," +
                              " licencia = '" + txb_license.Text + "'," +
                              " idestatus = " + _status.ToString() + "," + 
                              " fechamovimiento = getdate() ";
                    condicion = " WHERE idpiloto = " + _idpiloto.ToString();
                    conexion.UpdateTabla(campos, tabla, condicion);
                }
                else
                {
                    MessageBox.Show("Warning: Please review fields informations and try update again");
                }
            }
            InicializaGridview();
        }
        #endregion 

        #region Evento click del dg_piloto
        private void dg_piloto_MouseClick(object sender, MouseEventArgs e)
        {
            _idpiloto = Convert.ToInt32(dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[0].Value.ToString());
            txb_code.Text = dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[1].Value.ToString();
            Boolean _active = false;
            if (Convert.ToInt32(dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[6].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_pilotname.Text = dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[2].Value.ToString();
            txb_lastname.Text = dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[3].Value.ToString();
            txb_secondlastname.Text = dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[4].Value.ToString();
            txb_license.Text = dg_piloto.Rows[dg_piloto.CurrentRow.Index].Cells[5].Value.ToString();
            _Insert = false;
            btn_guardar.Text = "Update";
        }
        #endregion 

        #region Evento Deleting Row del dg_piloto
        private void dg_piloto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                tabla = "CT_PILOTO";
                campos = @"idestatus = 4";
                condicion = " where idpiloto = " + _idpiloto.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);
            }
            InicializaObjetos();
        }
        #endregion 



    }
}
