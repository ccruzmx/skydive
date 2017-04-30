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
    public partial class Frm_Payment : Form
    {

        #region Variable locales
        Int32 _status = 1;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla, valores, campos;
        Int32 _idpayment_type = 0;
        Boolean _Insert = true;
        #endregion 

        #region Constructor de la Frm_Payment
        public Frm_Payment()
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
            txb_payment_type.Text = "";
            txb_note.Text = "";
        }
        #endregion

        #region Inicializa DataGrid Usuarios
        private void InicializaGridview()
        {
            try
            {
                dg_paymentype.EnableHeadersVisualStyles = false;
                dg_paymentype.DataSource = conexion.ConsultaPaymenType();
                //idpaymenttype,  code, sort, payment_type,  note
                dg_paymentype.Columns[0].Width = 100; //idpaymenttype
                dg_paymentype.Columns[0].Visible = false;
                dg_paymentype.Columns[1].Width = 50; //code
                dg_paymentype.Columns[1].Visible = false;
                dg_paymentype.Columns[2].Width = 100; //sort
                dg_paymentype.Columns[3].Width = 300; //payment_type
                dg_paymentype.Columns[4].Width = 100; //active
                dg_paymentype.Columns[5].Width = 600; //note
                dg_paymentype.Columns[0].HeaderText = "idpaymenttype";
                dg_paymentype.Columns[1].HeaderText = "code";
                dg_paymentype.Columns[2].HeaderText = "SEQ";
                dg_paymentype.Columns[3].HeaderText = "PAYMENT TYPE";
                dg_paymentype.Columns[4].HeaderText = "ACTIVE";
                dg_paymentype.Columns[5].HeaderText = "NOTE";
                u.Formatodgv(dg_paymentype);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion

        #region Load de la Frm_Payment
        private void Frm_Payment_Load(object sender, EventArgs e)
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

        #region Valida campos
        private Boolean ValidaCampos()
        {
            if (txb_payment_type.Text.Length <= 2)
            {
                return false;
            }
            u.Parseacomilla(txb_sequence.Text);
            u.Parseacomilla(txb_payment_type.Text);
            u.Parseacomilla(txb_note.Text);
            
            return true;
        }
        #endregion

        #region Evento MouseClick del dg_paymentype
        private void dg_paymentype_MouseClick(object sender, MouseEventArgs e)
        {
            _idpayment_type = Convert.ToInt32(dg_paymentype.Rows[dg_paymentype.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_paymentype.Rows[dg_paymentype.CurrentRow.Index].Cells[4].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_code.Text = dg_paymentype.Rows[dg_paymentype.CurrentRow.Index].Cells[1].Value.ToString();
            txb_sequence.Text = dg_paymentype.Rows[dg_paymentype.CurrentRow.Index].Cells[2].Value.ToString();
            txb_payment_type.Text = dg_paymentype.Rows[dg_paymentype.CurrentRow.Index].Cells[3].Value.ToString();
            txb_note.Text = dg_paymentype.Rows[dg_paymentype.CurrentRow.Index].Cells[5].Value.ToString();
            _Insert = false;
            if (_Insert == false) { btn_guardar.Text = "Update"; }
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
                    txb_code.Text = txb_payment_type.Text;
                    if (_status != 1) { _status = 2; }
                    if (txb_sequence.Text == "") { txb_sequence.Text = "0"; }
                    tabla = "CT_PAYMENT_TYPE";
                    campos = "code, sort, payment_type,  idestatus, note";
                    valores = @" '" + txb_code.Text + "', " + txb_sequence.Text + ", '" + txb_payment_type.Text + "'," + _status.ToString()  + ", '" + txb_note.Text + "' ";
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try create new payment type, please contact system adminitrator | ", ex.Message);
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
                    tabla = "CT_PAYMENT_TYPE";
                    campos = @" code = '"+ txb_code.Text +"', " +
                              " sort = " + txb_sequence.Text + ", " + 
                              " payment_type = '"+ txb_payment_type.Text +"', " +
                              " idestatus = " + _status.ToString() + ", " + 
                              " note = '"+ txb_note.Text + "' ";
                    condicion = " WHERE idpaymenttype = " + _idpayment_type.ToString();
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error try update Payment type, please contact system administrator | ", ex.Message);

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

        #region Evento User Deleting Row del dg_paymentype
        private void dg_paymentype_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("This process can not rollback, are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                tabla = "CT_PAYMENT_TYPE";
                campos = @"idestatus = 4";
                condicion = " where idpaymenttype = " + _idpayment_type.ToString();
                conexion.UpdateTabla(campos, tabla, condicion);
            }
            InicializaObjetos();

        }
        #endregion 




    }
}
