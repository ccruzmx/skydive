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
    public partial class Frm_ProspectSelection : Form
    {


        #region Variables locales
        DataSet dsjumper;
        ConectaBD conexion = new ConectaBD();
        string sql;


        #endregion 
        public Frm_ProspectSelection()
        {
            InitializeComponent();
        }

        #region Load de la forma FR_ProspectSelecion
        private void Frm_ProspectSelection_Load(object sender, EventArgs e)
        {
            sql = @"SELECT idtandemup as ID, name + ' ' + lastname as name FROM dbo.TB_TANDEMUP";
            dsjumper = conexion.ConsultaUniversal(sql, " WHERE manifested = 2 order by name + ' ' + lastname", "TB_TANDEMUP"); //MODIFICAR EL CODIGO 1802 POR 1
            cmb_jumper.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_jumper.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NAME");
            cmb_jumper.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumper.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumper.ValueMember = "NAME";
            cmb_jumper.SelectedItem = null;
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

        #region Evento click del boton OK
        private void btn_ok_Click(object sender, EventArgs e)
        {
            sql = @" SELECT idtandemup as ID, name + ' ' + lastname as name FROM dbo.TB_TANDEMUP  ";
            dsjumper = conexion.ConsultaUniversal(sql, " WHERE name + ' ' + lastname  ='" + cmb_jumper.Text + "'", "TB_TANDEMUP");
            if (dsjumper.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Error to try read the prospect information.");
            }
            else
            {
                misglobales.jumper_code_list = dsjumper.Tables[0].Rows[0].ItemArray[0].ToString();
                misglobales._readjumper = true;
                this.Close();
            }
        }
        #endregion

        #region Evento click del boton Cancel
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void cmb_jumper_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_ok.Focus(); 
        }






    }
}
