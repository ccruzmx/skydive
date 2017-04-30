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
    public partial class Frm_Status : Form
    {
        #region Variables locales
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        Int32 _idestatus = 0;
        Boolean _Insert = true;
        String condicion, tabla, campos, valores;
        #endregion 

        #region Constructor de la forma
        public Frm_Status()
        {
            InitializeComponent();
        }
        #endregion 

        #region Metodo InicializaGrid
        private void InicializaGrid()
        {
            dg_estatus.EnableHeadersVisualStyles = false;
            dg_estatus.DataSource = conexion.ConsultaEstatus();
            dg_estatus.Columns[0].Width = 80; //IDESTATUS
            dg_estatus.Columns[1].Width = 400; //DESCRIPCION 
            dg_estatus.Columns[2].Width = 150; //FECHA CREACION+
            dg_estatus.Columns[0].HeaderText = "ID";
            dg_estatus.Columns[1].HeaderText = "DESCRIPTION";
            dg_estatus.Columns[2].HeaderText = "UPDATE DATE";
            u.Formatodgv(dg_estatus);
            if (_Insert) { btn_guardar.Text = "Save New"; } else { btn_guardar.Text = "Update"; }
        }
        #endregion 

        #region Evento Load de la Forma Satus
        private void Frm_Status_Load(object sender, EventArgs e)
        {
            InicializaGrid();

        }
        #endregion 

        #region Evento click en el boton Clear
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txb_description.Text = "";
            _Insert = true;
            InicializaGrid();
        }
        #endregion 

        #region Evento click del boton Exit
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento clik del btn_guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            txb_description.Text = u.Parseacomilla(txb_description.Text);

            if (_Insert)
            {
                if (txb_description.Text.Length > 2)
                {
                    DataSet dsestatus = new DataSet();
                    campos = "descripcion, fecha_creacion";
                    tabla = "CT_ESTATUS";
                    valores = "'" + txb_description.Text + "', getdate()";
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error try create new status, please contact system administrator | ", ex.Message);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Type description before to save, thanks");
                }
            }
            else 
            {
                //Actualizalo
                tabla = "CT_ESTATUS";
                campos = "descripcion = '" + txb_description.Text + "', fecha_creacion = getdate()";
                condicion = " WHERE idestatus = " + _idestatus;
                try
                {
                    conexion.UpdateTabla(campos, tabla, condicion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try update this Status, please contact system administrator | ", ex.Message);
                }

            }

            InicializaGrid();
        }
        #endregion

        #region Evento Deleting Row del grid dg_estatus
        private void dg_estatus_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("this process can not rollback, are you sure delete this record: ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                condicion = " IDESTATUS = " + dg_estatus.Rows[dg_estatus.CurrentRow.Index].Cells[0].Value.ToString();
                tabla = "CT_ESTATUS";
                conexion.BorraRegistro(condicion, tabla);
            }

        }
        #endregion 

        #region Evento Mouse Click del datagrid dg_estatus
        private void dg_estatus_MouseClick(object sender, MouseEventArgs e)
        {
            _idestatus = Convert.ToInt32( dg_estatus.Rows[dg_estatus.CurrentRow.Index].Cells[0].Value.ToString());
            txb_description.Text = dg_estatus.Rows[dg_estatus.CurrentRow.Index].Cells[1].Value.ToString();
            _Insert = false;
            if (_Insert == false) { btn_guardar.Text = "Update"; }
        }
        #endregion 



    }
}
