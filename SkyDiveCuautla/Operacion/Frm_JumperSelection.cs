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
    public partial class Frm_JumperSelection : Form
    {
        #region Variables locales
        DataSet dsjumper;
        ConectaBD conexion = new ConectaBD();
        string sql;
        #endregion 

        #region constructor del Frm_JumperSelection
        public Frm_JumperSelection()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento click del btn_cancel
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LoadAutoComplete
        public static AutoCompleteStringCollection LoadAutoComplete(DataSet ds, string campo)
        {

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                stringCol.Add(Convert.ToString(row[campo]));
            }
            return stringCol;
        }
        #endregion

        #region Evento Load de la Frm_JumperSelection
        private void Frm_JumperSelection_Load(object sender, EventArgs e)
        {
            sql = @"SELECT j.codigo as ID, j.lastname  + ', ' + j.name as name FROM dbo.CT_JUMPER j ";
            dsjumper = conexion.ConsultaUniversal(sql, " WHERE J.idjumper > 1 order by  J.NOMBRE", "CT_JUMPER"); //MODIFICAR EL CODIGO 1802 POR 1
            cmb_jumper.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_jumper.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NAME");
            cmb_jumper.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumper.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumper.ValueMember = "NAME";
            cmb_jumper.SelectedItem = null;
        }
        #endregion

        #region Evento click del btn_OK
        private void btn_ok_Click(object sender, EventArgs e)
        {
            sql = @"SELECT idjumper, codigo, nombre FROM dbo.CT_JUMPER";
            dsjumper = conexion.ConsultaUniversal(sql, " WHERE nombre ='" + cmb_jumper.Text + "'" , "CT_JUMPER");
            if (dsjumper.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Error to try read the jumper information.");
            }
            else 
            {
                misglobales.jumper_code_list = dsjumper.Tables[0].Rows[0].ItemArray[1].ToString();
                misglobales.jumperid = Convert.ToInt32( dsjumper.Tables[0].Rows[0].ItemArray[0].ToString());
                misglobales._readjumper = true;
                this.Close();
            }
        }
        #endregion

        private void cmb_jumper_TextChanged(object sender, EventArgs e)
        {
            //btn_ok.Focus();
        }

        private void cmb_jumper_Enter(object sender, EventArgs e)
        {
            //btn_ok.Focus(); 
        }

        private void cmb_jumper_TextUpdate(object sender, EventArgs e)
        {
            //btn_ok.Focus(); 
        }

        private void cmb_jumper_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //btn_ok.Focus(); 
        }

        private void cmb_jumper_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_ok.Focus(); 
        }


    }
}
