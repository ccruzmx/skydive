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
    public partial class Frm_Jump : Form
    {
        #region Variable locales
        Int32 _status = 1;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String sql, condicion, tabla, valores, campos;
        Int32 _idjumptype = 0;
        Boolean _Insert = true;
        #endregion 

        #region Constructor de la Frm_jump
        public Frm_Jump()
        {
            InitializeComponent();
        }
        #endregion 

        #region Evento CheckedChanged del chk_active
        private void chk_active_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_active.Checked == true) { _status = 1; } else { _status = 2; }
        }
        #endregion 

        #region Load de la Frm_Jump
        private void Frm_Jump_Load(object sender, EventArgs e)
        {
            InicializaGridview();
            InicializaObjetos();
        }
        #endregion 

        #region Inicializa DataGrid Usuarios
        private void InicializaGridview()
        {
            try
            {
                dg_jumptype.EnableHeadersVisualStyles = false;
                dg_jumptype.DataSource = conexion.ConsultaJumpType();   //getdata(fuente;
                dg_jumptype.Columns[0].Width = 100; //idjumptype
                dg_jumptype.Columns[0].Visible = false;

                dg_jumptype.Columns[1].Width = 50; //orden
                dg_jumptype.Columns[2].Width = 50; //codigo
                dg_jumptype.Columns[2].Visible = false;
                dg_jumptype.Columns[3].Width = 265; //jump_type
                dg_jumptype.Columns[4].Width = 100; //price
                dg_jumptype.Columns[5].Width = 150; //[group]
                dg_jumptype.Columns[6].Width = 400; //[Description]
                dg_jumptype.Columns[7].Width = 100; //Altitud
                dg_jumptype.Columns[8].Width = 150; //Codey
                dg_jumptype.Columns[9].Width = 20; //idchargetype
                dg_jumptype.Columns[9].Visible = false;
                dg_jumptype.Columns[10].Width = 200; //charge_type_description
                dg_jumptype.Columns[11].Width = 97; //charge_type
                dg_jumptype.Columns[11].Visible = false;
                dg_jumptype.Columns[12].Width = 50; //idestatus

                dg_jumptype.Columns[0].HeaderText = "idjumptype";
                dg_jumptype.Columns[1].HeaderText = "SEQ";
                dg_jumptype.Columns[2].HeaderText = "CODE";
                dg_jumptype.Columns[3].HeaderText = "JUMP TYPE";
                dg_jumptype.Columns[4].HeaderText = "PRICE";
                dg_jumptype.Columns[5].HeaderText = "GROUP";
                dg_jumptype.Columns[6].HeaderText = "DESCRIPTION";
                dg_jumptype.Columns[7].HeaderText = "ALTITUD";
                dg_jumptype.Columns[8].HeaderText = "CODEY";
                dg_jumptype.Columns[9].HeaderText = "IDCHARGETYPE";
                dg_jumptype.Columns[10].HeaderText = "CHARGE TYPE";
                dg_jumptype.Columns[11].HeaderText = "CHARGE TYPE2";
                dg_jumptype.Columns[12].HeaderText = "ACTIVE";
                u.Formatodgv(dg_jumptype);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
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
            txb_jumptype.Text = "";
            txb_sequence.Text = "";
            txb_price.Text = "";
            txb_altitud.Text = "";
            txb_codey.Text = "";
            txb_group.Text = "";
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
                _Insert = true;
                btn_guardar.Text = "Save New";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message); 
            }
            

        }
        #endregion

        #region Evento ClicK del btn_limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }
        #endregion 

        #region Evento Deleting Row del grid dg_jumptype
        private void dg_jumptype_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("this process can not rollback, are you sure delete this record: ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                condicion = " idjumptype = " + dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[0].Value.ToString();
                tabla = "CT_JUMP_TYPE";
                conexion.BorraRegistro(condicion, tabla);
            }

        }
        #endregion

        #region Evento Mouse click del dg_jumptype
        private void dg_jumptype_MouseClick(object sender, MouseEventArgs e)
        {
            _idjumptype = Convert.ToInt32(dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[0].Value.ToString());
            Boolean _active = false;
            if (Convert.ToInt32(dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[12].Value) == 1) { _active = true; } else { _active = false; }
            chk_active.Checked = _active;
            txb_code.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[2].Value.ToString() ;
            txb_jumptype.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[3].Value.ToString();
            txb_sequence.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[1].Value.ToString();
            txb_price.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[4].Value.ToString();
            txb_altitud.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[7].Value.ToString();
            txb_codey.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[8].Value.ToString();
            txb_group.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[5].Value.ToString();
            txb_description.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[6].Value.ToString();
            cmb_chargetype.Text = dg_jumptype.Rows[dg_jumptype.CurrentRow.Index].Cells[10].Value.ToString();
            
            _Insert = false;
            if (_Insert == false) { btn_guardar.Text = "Update"; }
        }
        #endregion 

        #region Valida campos
        private Boolean ValidaCampos()
        {
            if (txb_jumptype.Text.Length <= 2)
            {
                return false;
            }
            if (txb_sequence.Text.Length == 0)
            {
                txb_sequence.Text = "0";
                return true;
            }
            if (txb_price.Text.Length <= 0)
            {
                return false;
            }
            if (txb_altitud.Text.Length <= 0)
            {
                return false;
            }
            if (cmb_chargetype.Text == "")
            {
                return false;
            }

            u.Parseacomilla(txb_jumptype.Text);
            u.Parseacomilla(txb_altitud.Text);
            u.Parseacomilla(txb_group.Text);
            u.Parseacomilla(txb_description.Text);
            u.Parseacomilla(txb_codey.Text);

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

                    DataSet dsjumptype = new DataSet();
                    sql = @"Select max(idjumptype)+1 idjumptype
                             From dbo.CT_JUMP_TYPE";
                    tabla = "CT_JUMP_TYPE";
                    dsjumptype = conexion.ConsultaUniversal(sql, "", tabla);
                    Int32 _id = Convert.ToInt32( dsjumptype.Tables[0].Rows[0].ItemArray[0].ToString());
                    txb_code.Text = txb_jumptype.Text.Substring(1,3) + "-" + _id.ToString();
                    dsjumptype.Dispose();
                    tabla = "CT_CHARGE_TYPE";
                    sql = @"select idchargetype, charge_type, codigo from dbo.CT_CHARGE_TYPE ";
                    condicion = " WHERE charge_type = '" + cmb_chargetype.Text + "'";
                    DataSet dschargetype = conexion.ConsultaUniversal(sql, condicion, tabla);
                    tabla = "CT_JUMP_TYPE";
                    campos = "codigo, jump_type, price, [group], [Description], Altitud, codey, orden, idchargetype, charge_type_description, idestatus";
                    valores = @"'" + txb_code.Text + "', '" + txb_jumptype.Text + "', " + txb_price.Text + ", '" + txb_group.Text + "', '" + txb_description.Text + "', '"
                                   + txb_altitud.Text + "', '" + txb_codey.Text + "'," + txb_sequence.Text + ", " + dschargetype.Tables[0].Rows[0].ItemArray[0] + ", '" + dschargetype.Tables[0].Rows[0].ItemArray[2] + "', " + _status.ToString();

                    try
                    {

                        conexion.InsertTabla(campos, tabla, valores);
                        dschargetype.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try create new JumpType record, please contact system administrator | " + ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Error, review the fields information an save again");
                }

            }
            else
            { 
            //actualizar
                if (ValidaCampos())
                {
                    tabla = "CT_CHARGE_TYPE";
                    sql = @"select idchargetype, charge_type, codigo from dbo.CT_CHARGE_TYPE ";
                    condicion = " WHERE codigo = '" + cmb_chargetype.Text + "'";
                    DataSet dschargetype = conexion.ConsultaUniversal(sql, condicion, tabla);

                    tabla = "CT_JUMP_TYPE";
                    campos = @" idestatus = " + _status.ToString() + ", " +
                              " jump_type = '" + txb_jumptype.Text + "', " +
                              " price = " + txb_price.Text + ", " +
                              " [group] = '" + txb_group.Text + "', " +
                              " [Description] = '" + txb_description.Text + "', " +
                              " Altitud = '" + txb_altitud.Text + "', " +
                              " codey = '" + txb_codey.Text + "', " +
                              " orden = " + txb_sequence.Text + ", " +
                              " idchargetype = " + dschargetype.Tables[0].Rows[0].ItemArray[0] + ", " +
                              " charge_type_description = '" + dschargetype.Tables[0].Rows[0].ItemArray[2] + "' ";
                    condicion = @" WHERE idjumptype = " + _idjumptype;
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try update JumpType, please contact system administrator |"+ ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Error, review the fields information and update again");
                }
            }
            InicializaGridview();
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

        #region Evento KeyPress del txb_price
        private void txb_price_KeyPress(object sender, KeyPressEventArgs e)
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
