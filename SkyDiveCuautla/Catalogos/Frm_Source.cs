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
    public partial class Frm_Source : Form
    {


        #region Variable locales
        Int32 _status = 1;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla, valores, campos;
        Int32 _source_type = 0;
        Boolean _Insert = true;
        #endregion

        #region Constructor de la Frm_Source
        public Frm_Source()
        {
            InitializeComponent();
        }
        #endregion

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            chk_active.Checked = false;
            txb_code.Text = "";
            txb_sequence.Text = "";
            txb_source_type.Text = "";
            btn_guardar.Text = "Save";
        }
        #endregion

        #region Inicializa DataGrid Usuarios
        private void InicializaGridview()
        {
            try
            {
                dg_sourcetype.EnableHeadersVisualStyles = false;
                dg_sourcetype.DataSource = conexion.ConsultaSourceType();
                //idsourcetype, codigo, Orden, Source_Type, idestatus
                dg_sourcetype.Columns[0].Width = 100; //idsourcetype
                dg_sourcetype.Columns[0].Visible = false;
                dg_sourcetype.Columns[1].Width = 50; //codigo
                dg_sourcetype.Columns[1].Visible = false;
                dg_sourcetype.Columns[2].Width = 100; //Orden
                dg_sourcetype.Columns[3].Width = 500; //Source_Type
                dg_sourcetype.Columns[4].Width = 100; //active
                dg_sourcetype.Columns[0].HeaderText = "idpaymenttype";
                dg_sourcetype.Columns[1].HeaderText = "code";
                dg_sourcetype.Columns[2].HeaderText = "SEQ";
                dg_sourcetype.Columns[3].HeaderText = "SOURCE TYPE";
                dg_sourcetype.Columns[4].HeaderText = "ACTIVE";
                u.Formatodgv(dg_sourcetype);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Load de la Frm_Source
        private void Frm_Source_Load(object sender, EventArgs e)
        {
            InicializaGridview();
        }
        #endregion

        #region Evento KeyPress del txb_sequence
        private void txb_sequence_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Evento CheckedChanged del chk_active
        private void chk_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_active.Checked == true) { _status = 1; } else { _status = 2; }
        }
        #endregion

        #region Evento Mouse Click del dg_sourcetype
        private void dg_sourcetype_MouseClick(object sender, MouseEventArgs e)
        {
            _source_type = Convert.ToInt32(dg_sourcetype.Rows[dg_sourcetype.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_sourcetype.Rows[dg_sourcetype.CurrentRow.Index].Cells[4].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_code.Text = dg_sourcetype.Rows[dg_sourcetype.CurrentRow.Index].Cells[1].Value.ToString();
            txb_sequence.Text = dg_sourcetype.Rows[dg_sourcetype.CurrentRow.Index].Cells[2].Value.ToString();
            txb_source_type.Text = dg_sourcetype.Rows[dg_sourcetype.CurrentRow.Index].Cells[3].Value.ToString();
            _Insert = false;
            if (_Insert == false) { btn_guardar.Text = "Update"; }
        }
        #endregion

        #region Evento UserDeletingRow del dg_sourcetype
        private void dg_sourcetype_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                tabla = "CT_SOURCE_TYPE";
                campos = @"idestatus = 4";
                condicion = " where idsourcetype = " + _source_type.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);
            }
            InicializaObjetos();
        }
        #endregion

        #region Evento click del btn_limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion

        #region Evento click del btn_cerrar
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Valida campos
        private Boolean ValidaCampos()
        {
            txb_source_type.Text = u.Parseacomilla(txb_source_type.Text);

            if (txb_source_type.Text.Length <= 2)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Evento Click del btn_guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (_Insert)
            {
                //insertar
                if (ValidaCampos())
                {

                    DataSet dssource = new DataSet();
                    sql = @"Select max(idsourcetype)+1 idsourcetype
                             From dbo.CT_SOURCE_TYPE";
                    tabla = "CT_SOURCE_TYPE";
                    dssource = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _id = Convert.ToInt32(dssource.Tables[0].Rows[0].ItemArray[0].ToString());
                    txb_code.Enabled = true;
                    txb_code.Text = _id.ToString() + "-" + txb_source_type.Text.Substring(1, 3).ToUpper();
                    txb_code.Enabled = false;
                    dssource.Dispose();

                    if (_status != 1) { _status = 2; }
                    tabla = "CT_SOURCE_TYPE";
                    campos = "codigo, Orden, Source_Type, idestatus";
                    valores = @"'" + txb_code.Text + "', " + txb_sequence.Text + ", '" + txb_source_type.Text + "', " + _status.ToString();
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error try create new Source type, please contact system administrator | ", ex.Message);
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

                    if (_status != 1) { _status = 2; }
                    tabla = "CT_SOURCE_TYPE";
                    campos = " codigo = '" + txb_code.Text + "', " +
                             " Orden = " + txb_sequence.Text + ", " +
                             " Source_Type = '" + txb_source_type.Text + "', " +
                             " idestatus = " + _status.ToString();
                    condicion = " WHERE idsourcetype =" + _source_type.ToString();
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to update Source type, please contact system administrator | ", ex.Message); 
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




    }
}
