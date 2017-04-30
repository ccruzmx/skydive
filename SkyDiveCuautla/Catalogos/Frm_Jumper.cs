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
    public partial class Frm_Jumper : Form
    {
        #region Variables Locales
            ConectaBD conexion = new ConectaBD();
            utilerias u = new utilerias();
            String sql, condicion, tabla, valores, campos;
            Int32 _jumpertype = 0,  _status = 2;
            Boolean _Insert = true;
        #endregion 

        #region Constructor de la frm_Jumper
        public Frm_Jumper()
        {
            InitializeComponent();
        }
        #endregion 

        #region InicializaObjetos
        private void InicializaObjetos()
        {
            chk_active.Checked = false;
            txb_code.Text = "";
            txb_jumpertype.Text = "";
            txb_sequence.Text = "";
            _Insert = true;
            btn_guardar.Text = "Save";
        }
        #endregion 

        #region Inicializa DataGrid Jumpers Type
        private void InicializaGridview()
        {
            try
            {
                dg_jumpertype.EnableHeadersVisualStyles = false;
                dg_jumpertype.DataSource = conexion.ConsultaJumperType(); 
                dg_jumpertype.Columns[0].Width = 100; //idjumpertype
                dg_jumpertype.Columns[0].Visible = false;
                dg_jumpertype.Columns[1].Width = 50; //Codigo
                dg_jumpertype.Columns[1].Visible = false;
                dg_jumpertype.Columns[2].Width = 50; //orden
                dg_jumpertype.Columns[3].Width = 265; //Descripcion
                dg_jumpertype.Columns[4].Width = 50; //idestatus


                dg_jumpertype.Columns[0].HeaderText = "idjumpertype";
                dg_jumpertype.Columns[1].HeaderText = "CODE";
                dg_jumpertype.Columns[2].HeaderText = "SEQ";
                dg_jumpertype.Columns[3].HeaderText = "DESCRIPTION";
                dg_jumpertype.Columns[4].HeaderText = "ACTIVE";
                u.Formatodgv(dg_jumpertype);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        #endregion

        #region Load de la Frm_Jumper
        private void Frm_Jumper_Load(object sender, EventArgs e)
        {
            InicializaGridview();
            
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

        #region Evento click del dg_jumpertype
        private void dg_jumpertype_MouseClick(object sender, MouseEventArgs e)
        {
            _jumpertype = Convert.ToInt32(dg_jumpertype.Rows[dg_jumpertype.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_jumpertype.Rows[dg_jumpertype.CurrentRow.Index].Cells[4].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_code.Text = dg_jumpertype.Rows[dg_jumpertype.CurrentRow.Index].Cells[1].Value.ToString();
            txb_jumpertype.Text = dg_jumpertype.Rows[dg_jumpertype.CurrentRow.Index].Cells[3].Value.ToString();
            txb_sequence.Text = dg_jumpertype.Rows[dg_jumpertype.CurrentRow.Index].Cells[2].Value.ToString();
            _Insert = false;
            btn_guardar.Text = "Update";
        }
        #endregion 

        #region Valida campos
        private Boolean ValidaCampos()
        {
            if (txb_jumpertype.Text.Length <= 2)
            {
                return false;

            }

            txb_jumpertype.Text = u.Parseacomilla(txb_jumpertype.Text);
            u.Parseacomilla(txb_jumpertype.Text);

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
                    DataSet dsjumpertype = new DataSet();
                    sql = @"Select max(idjumpertype)+1 idjumpertype
                             From dbo.CT_JUMPER_TYPE";
                    tabla = "CT_JUMPER_TYPE";
                    dsjumpertype = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _id = Convert.ToInt32(dsjumpertype.Tables[0].Rows[0].ItemArray[0].ToString());
                    txb_code.Text = _id.ToString() + "-" + txb_jumpertype.Text.Substring(1, 3);
                    dsjumpertype.Dispose();

                    tabla = "CT_JUMPER_TYPE";
                    campos = "Codigo, Descripcion,   idestatus, orden";
                    if (_status != 1) { _status = 2; }
                    valores = "'" + txb_code.Text + "', '" + txb_jumpertype.Text + "', " + _status.ToString() + ", " + txb_sequence.Text;
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try create new Jumper Type, please contact system administrator | ", ex.Message);
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
                    tabla = "CT_JUMPER_TYPE";
                    if (_status != 1) { _status = 2; }
                    campos = @"Codigo = '" + txb_code.Text + "'," + 
                               "Descripcion = '" + txb_jumpertype.Text + "'," +   
                               "idestatus = " + _status + "," + 
                               "orden = " + txb_sequence.Text;
                    condicion = " where idjumpertype = " + _jumpertype;
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try update Jumper Type, please contact system administrator | ", ex.Message);
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

        #region Evento Checked Changed del chk_active
        private void chk_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_active.Checked == true) { _status = 1; } else { _status = 2; }
        }
        #endregion 

        #region Evento User Deleting Row 
        private void dg_jumpertype_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                tabla = "CT_JUMPER_TYPE";
                campos = @"idestatus = 4";
                condicion = " where idjumpertype = " + _jumpertype;
                conexion.UpdateTabla(campos, tabla, condicion);
            }
            InicializaObjetos();
        }
        #endregion 


    }
}
