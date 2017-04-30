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
    public partial class Frm_Preferences : Form
    {

        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        string condicion = "";
        string campos = "";
        string tabla = "";
        string valores = "";


        public Frm_Preferences()
        {
            InitializeComponent();
        }


        #region InicializaObjetos
        private void InicializaObjetos()
        {
            chk_active.Checked = false;
            txb_code.Text = "";
            cmb_type.Text = "";
            txb_short.Text = "";
            txb_altitud.Text = "";


        }
        #endregion

        #region Inicializa DataGrid Plane
        private void InicializaGridview()
        {
            try
            {
                dg_plane.EnableHeadersVisualStyles = false;
                dg_plane.DataSource = conexion.ConsultaPreferences();
                dg_plane.Columns[0].Width = 100; //idpreferences
                dg_plane.Columns[0].Visible = false;
                dg_plane.Columns[1].Width = 150; //codigo
                dg_plane.Columns[1].Visible = true;
                dg_plane.Columns[2].Width = 200; //preference_type
                dg_plane.Columns[2].Visible = true;
                dg_plane.Columns[3].Width = 300; //short_description
                dg_plane.Columns[3].Visible = true;
                dg_plane.Columns[4].Width = 400; //long_description
                dg_plane.Columns[4].Visible = true;
                dg_plane.Columns[5].Width = 150; //idestatus
                dg_plane.Columns[5].Visible = true;


                dg_plane.Columns[0].HeaderText = "idpreferences";
                dg_plane.Columns[1].HeaderText = "codigo";
                dg_plane.Columns[2].HeaderText = "preference_type";
                dg_plane.Columns[3].HeaderText = "short_description";
                dg_plane.Columns[4].HeaderText = "long_description";
                dg_plane.Columns[5].HeaderText = "idestatus";
              

                u.Formatodgv(dg_plane);
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
        #endregion




        private void Frm_Preferences_Load(object sender, EventArgs e)
        {
            InicializaGridview();
        }

        private void dg_plane_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                InicializaObjetos();


                chk_active.Checked = false;
                txb_code.Text = "";
                cmb_type.Text = "";
                txb_short.Text = "";
                txb_altitud.Text = "";



                u.Pasarcampo(dg_plane, txb_code, "codigo");
                u.Pasarcampo(dg_plane, cmb_type, "preference_type");
                u.Pasarcampo(dg_plane, txb_short, "short_description");
                u.Pasarcampo(dg_plane, txb_altitud, "long_description");

                chk_active.Checked = Convert.ToBoolean( dg_plane.Rows[dg_plane.CurrentRow.Index].Cells[5].Value.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            InicializaObjetos();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Valida si estan llenos todos los campos
        public bool validacampos()
        {
            if (txb_code.Text == "")
            {
                MessageBox.Show("Need type a CODE");
                return false;

            }
            if (cmb_type.Text == "")
            {
                MessageBox.Show("Need select a PREFERENCE TYPE");
                return false;
            }
            if (txb_short.Text == "")
            {
                MessageBox.Show("Need type a SHORT PREFERENCE");
                return false;
            }
            if (txb_altitud.Text == "")
            {
                MessageBox.Show("Need select a LONG DESCRIPTION");
                return false;
            }


            return true;

        }
        #endregion



        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            ds = conexion.ConsultaPreferencias(condicion);
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




        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Int32 _estatus = 0; 

            if (validacampos())
            {
                condicion = " where codigo = '" + txb_code.Text + "'";

                if (InserUpdate(condicion) == "insert")
                {
                    //INSERT
                    tabla = "CT_PREFERENCES";
                    campos = "[codigo], [preference_type], [short_description], [long_description], [idestatus]";
                    if (chk_active.Checked == true) { _estatus = 1; } else { _estatus = 0; }
                    valores = @"'" + txb_code.Text + "','" + cmb_type.Text + "','" + txb_short.Text + "', '" + txb_altitud.Text + "', " + _estatus;
                    try
                    {
                        conexion.InsertTabla(campos, tabla, valores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to create new Preferences, please contact system admin | "+ ex.Message);


                    }
                }
                else
                {

                    if (chk_active.Checked == true) { _estatus = 1; } else { _estatus = 0; }

                    campos = @" [codigo] = '" + txb_code.Text + "'," +
                               "  [preference_type] =  '" + cmb_type.Text + "' ," +
                               "  [short_description] = '" + txb_short.Text + "'," +
                               "  [long_description] = '" + txb_altitud.Text + "'," +
                               "  [idestatus] = " + _estatus;
                    //condicion += " Nombre = '" + txb_officename.Text + "'";
                    tabla = "CT_PREFERENCES";
                    try
                    {
                        conexion.UpdateTabla(campos, tabla, condicion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to update informacion DropZone, please contact to system admin | "+ ex.Message);
                    }         
                }

                MessageBox.Show(" Save Successfully ");
                InicializaGridview();
            }

        }

        private void dg_plane_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            InicializaGridview();
        }
    }
}
