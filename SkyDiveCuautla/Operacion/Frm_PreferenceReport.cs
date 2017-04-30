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
    public partial class Frm_PreferenceReport : Form
    {
        string condicion = "";
        ConectaBD conexion = new ConectaBD();
        DataSet dsjumper, dsjumptype;
        string sql = "";
        utilerias u = new utilerias();



        public Frm_PreferenceReport()
        {
            InitializeComponent();
        }


        #region InicializaGridView
        public void InicializaGrid()
        {



            if (cmb_preference.SelectedItem != null)
            {
                condicion = " where long_description = '" + cmb_preference.SelectedValue + "'  order by ctj.idjumper";

            }
            else
            {
                condicion = @" order by ctj.idjumper";
            }


            dg_preferencelist.EnableHeadersVisualStyles = false;
            dg_preferencelist.DataSource = conexion.ConsultaPreferenceList(condicion);
            dg_preferencelist.Columns[0].Width = 100; //idjumper
            dg_preferencelist.Columns[0].Visible = false;
            dg_preferencelist.Columns[1].Width = 150; //nombre
            dg_preferencelist.Columns[1].Visible = true;
            dg_preferencelist.Columns[2].Width = 190; //email
            dg_preferencelist.Columns[2].Visible = true;
            dg_preferencelist.Columns[3].Width = 100; //home_phone
            dg_preferencelist.Columns[3].Visible = true;
            dg_preferencelist.Columns[4].Width = 100; //mobile_phone
            dg_preferencelist.Columns[4].Visible = true;
            dg_preferencelist.Columns[5].Width = 100; //work_phone
            dg_preferencelist.Columns[5].Visible = true;
            dg_preferencelist.Columns[6].Width = 100; //city
            dg_preferencelist.Columns[6].Visible = true;
            dg_preferencelist.Columns[7].Width = 100; //state
            dg_preferencelist.Columns[7].Visible = true;
            dg_preferencelist.Columns[8].Width = 100; //idpreferences
            dg_preferencelist.Columns[8].Visible = false;
            dg_preferencelist.Columns[9].Width = 190; //long_description
            dg_preferencelist.Columns[9].Visible = true;
            dg_preferencelist.Columns[10].Width = 150; //WAIVER_DATE
            dg_preferencelist.Columns[10].Visible = true;
            dg_preferencelist.Columns[11].Width = 150; //MEMBER_NUMBER
            dg_preferencelist.Columns[11].Visible = true;
            dg_preferencelist.Columns[12].Width = 150; //LICENCE/MEMBER EXPIRE
            dg_preferencelist.Columns[12].Visible = true;
            dg_preferencelist.Columns[13].Width = 80; //active
            dg_preferencelist.Columns[13].Visible = false;
            dg_preferencelist.Columns[14].Width = 300; //comments
            dg_preferencelist.Columns[14].Visible = true;
            u.Formatodgv(dg_preferencelist);


        }
        #endregion

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


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



        private void Frm_PreferenceReport_Load(object sender, EventArgs e)
        {
            sql = @" Select idpreferences, codigo, long_description from CT_PREFERENCES ";
            dsjumper = conexion.ConsultaUniversal(sql, " order by long_description", "CT_PREFERENCES");

            cmb_preference.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_preference.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "long_description");
            cmb_preference.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_preference.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_preference.ValueMember = "long_description";
            cmb_preference.SelectedItem = null;
            conexion.CloseDB();


            InicializaGrid();
        }

        private void cmb_preference_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_preference_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cmb_preference_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_preference_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_preference.SelectedValue.ToString() != "")
            {
                condicion = " where long_description = '" + cmb_preference.SelectedValue + "'  order by ctj.idjumper";

            }
            else
            {
                condicion = @" order by ctj.idjumper";
            }

            InicializaGrid();
        }




    }
}
