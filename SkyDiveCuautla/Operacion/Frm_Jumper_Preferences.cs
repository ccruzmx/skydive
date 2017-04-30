using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_Jumper_Preferences : Form
    {

        ConectaBD conexion = new ConectaBD();
        string condicion = "";
        string tabla = "";
        string  campos = "";
        string valores = "";
        utilerias u = new utilerias();

        public Frm_Jumper_Preferences()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            tabla = "CT_JUMPER_PREFERENCES";
            condicion = "idjumper = " + lbl_idjumper.Text;

            conexion.BorraRegistro(condicion, tabla);


            for (int i = 0; i < dg_preferences.RowCount; i++)
            {
                if (Convert.ToDecimal(dg_preferences.Rows[i].Cells[3].Value) != 0)
                {

                         tabla = "CT_JUMPER_PREFERENCES";
                         campos = "idjumper, idpreferences, comments, updatedate, idusuario, active";
                         valores = lbl_idjumper.Text + ", " + dg_preferences.Rows[i].Cells[1].Value + ", '" + dg_preferences.Rows[i].Cells[4].Value + "', getdate()," + misglobales.usuario_idusuario + ", " + Convert.ToInt32( dg_preferences.Rows[i].Cells[3].Value);
                         conexion.InsertTabla(campos, tabla, valores);
                }
            }


            this.Close();
        }


        #region Inicializa grid vuelos
        private void inicializagridview()
        {

            condicion = misglobales.jumperid.ToString();
        

            dg_preferences.EnableHeadersVisualStyles = false;
            dg_preferences.DataSource = conexion.JumperPreferences(condicion);
            // idpaymenttype, code, payment_type, payment
            dg_preferences.Columns[0].Width = 10; //idjumper
            dg_preferences.Columns[0].Visible = false;
            dg_preferences.Columns[1].Width = 10; //idpreferences
            dg_preferences.Columns[1].Visible = false;
            dg_preferences.Columns[2].Width = 200; //long_description
            dg_preferences.Columns[3].Width = 30; //active
            dg_preferences.Columns[4].Width = 320;//comments
            dg_preferences.Columns[2].HeaderText = "Preference";
            dg_preferences.Columns[3].HeaderText = "Like";
            dg_preferences.Columns[4].HeaderText = "Comments";
            u.Formatodgv(dg_preferences);
            dg_preferences.ReadOnly = false;
            dg_preferences.Columns[2].ReadOnly = true;
            dg_preferences.Columns[3].ReadOnly = false;
            dg_preferences.Columns[4].ReadOnly = false;



        }
        #endregion



        private void Frm_Jumper_Preferences_Load(object sender, EventArgs e)
        {
            lbl_jumpername.Text = misglobales._name.ToString();
            lbl_jumpercode.Text = misglobales.jumper_code.ToString();
            lbl_idjumper.Text = misglobales.jumperid.ToString();
            inicializagridview();
            



        }
    }
}
