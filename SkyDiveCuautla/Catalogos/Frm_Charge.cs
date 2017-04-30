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
    public partial class Frm_Charge : Form
    {
        #region Variables Locales
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        Int32 _chargetype = 0, _status = 2;
        Boolean _Insert = true;
        String sql, condicion, tabla, valores, campos;
        #endregion 

        #region Constructor de la Frm_Charge
        public Frm_Charge()
        {
            InitializeComponent();
        }
        #endregion 

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            txb_code.Text = "";
            txb_group.Text = "";
            txb_chargetype.Text = "";
            txb_sequence.Text = "";
            txb_note.Text = "";
            chk_active.Checked = false;
            btn_guardar.Text = "Save";
        }
        #endregion 

        #region Inicializa DataGrid Charge Type
        private void InicializaGridview()
        {
            try
            {
                dg_chargetype.EnableHeadersVisualStyles = false;
                //idchargetype, codigo, sort, Grupo, charge_type, note
                dg_chargetype.DataSource = conexion.ConsultaChargeType();
                dg_chargetype.Columns[0].Width = 100; //idchargetype
                dg_chargetype.Columns[0].Visible = false;
                dg_chargetype.Columns[1].Width = 50; //codigo
                dg_chargetype.Columns[1].Visible = false;
                dg_chargetype.Columns[2].Width = 50; //sort
                dg_chargetype.Columns[3].Width = 250; //Grupo
                dg_chargetype.Columns[4].Width = 300; //charge_type
                dg_chargetype.Columns[5].Width = 50; //ACTIVE
                dg_chargetype.Columns[6].Width = 532; //note

                dg_chargetype.Columns[0].HeaderText = "idchargetype";
                dg_chargetype.Columns[1].HeaderText = "CODE";
                dg_chargetype.Columns[2].HeaderText = "SEQ";
                dg_chargetype.Columns[3].HeaderText = "GROUP";
                dg_chargetype.Columns[4].HeaderText = "CHARGE TYPE";
                dg_chargetype.Columns[5].HeaderText = "ACTIVE";
                dg_chargetype.Columns[6].HeaderText = "NOTE";
                u.Formatodgv(dg_chargetype);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        #endregion

        #region Load de la Frm_Charge
        private void Frm_Charge_Load(object sender, EventArgs e)
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

        #region Evento User Deleting Row del dg_chargetype
        private void dg_chargetype_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                tabla = "CT_CHARGE_TYPE";
                campos = @"idestatus = 4";
                condicion = " where idchargetype = " + _chargetype;
                conexion.UpdateTabla(campos, tabla, condicion);
            }
            InicializaObjetos();
        }
        #endregion 

        #region Evento Mouse click del dg_chargetype
        private void dg_chargetype_MouseClick(object sender, MouseEventArgs e)
        {
            _chargetype = Convert.ToInt32(dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[5].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_code.Text = dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[1].Value.ToString();
            txb_chargetype.Text = dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[4].Value.ToString();
            txb_sequence.Text = dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[2].Value.ToString();
            txb_group.Text = dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[3].Value.ToString();
            txb_note.Text = dg_chargetype.Rows[dg_chargetype.CurrentRow.Index].Cells[6].Value.ToString();

            _Insert = false;
            btn_guardar.Text = "Update";
        }
        #endregion 

        #region Evento click del btn_cerrar
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento click del btn_limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion

        #region Valida campos
        private Boolean ValidaCampos()
        {
            if (txb_chargetype.Text.Length <= 2)
            {
                return false;

            }
            txb_group.Text = u.Parseacomilla(txb_group.Text);
            txb_note.Text = u.Parseacomilla(txb_note.Text);
           

            return true;

        }
        #endregion 

        //ocole maluna

        #region Evento click del btn_guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (_Insert)
            {
                //Insertar
                if (ValidaCampos())
                {
                    tabla = "CT_CHARGE_TYPE";
                    campos = "codigo, charge_type, note, sort, Grupo, idestatus";
                    if (_status != 1) { _status = 2; }
                    valores = "'" + txb_code.Text + "', '" + txb_chargetype.Text + "', '" + txb_note.Text + "', " + txb_sequence.Text + ", '" + txb_group.Text + "', " + _status.ToString();
                    conexion.InsertTabla(campos, tabla, valores);
                }
                else
                {
                    MessageBox.Show("Warning: Please review fields informations an try save again");
                }
            }
            else
            { 
                //Update
                if (ValidaCampos())
                {
                    tabla = "CT_CHARGE_TYPE";
                    if (_status != 1) { _status = 2; }
                    campos = @" charge_type = '" + txb_chargetype.Text + "', " +
                              " note = '" + txb_note.Text + "', " +
                              " sort = " + txb_sequence.Text + ", " +
                              " Grupo = '" + txb_group.Text + "', " +
                              " idestatus = " + _status;
                    condicion = " where idchargetype = " + _chargetype;
                    conexion.UpdateTabla(campos, tabla, condicion);
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
