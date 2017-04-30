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
    public partial class Frm_JumperLeaderDetail : Form
    {

        ConectaBD conexion = new ConectaBD();
        string condicion, campos, sql, tabla;
        utilerias u = new utilerias();



        public Frm_JumperLeaderDetail()
        {
            InitializeComponent();
        }

        private void Frm_JumperLeaderDetail_Load(object sender, EventArgs e)
        {
            lbl_jumper.Text = misglobales._name;
            InicializaGrid();

        }


        #region Inicializa Grid
        private void InicializaGrid()
        {

            char[] charsToTrim = {' '};
            condicion = "WHERE name = '" + misglobales._name.Trim(charsToTrim) +"'";
            try
            {
                dg_ledgerdetail.EnableHeadersVisualStyles = false;
                dg_ledgerdetail.DataSource = conexion.ConsultaLederDetail(condicion);
                dg_ledgerdetail.Columns[0].Width = 100;  // CODE
                dg_ledgerdetail.Columns[1].Width = 200;  // UPDATEDATE
                dg_ledgerdetail.Columns[2].Width = 200;  // IDCHARGETYPE
                dg_ledgerdetail.Columns[3].Width = 100;  // CHARGE
                dg_ledgerdetail.Columns[4].Width = 100;  // PAYMENT
                dg_ledgerdetail.Columns[5].Width = 100;  // STAFF
                dg_ledgerdetail.Columns[6].Width = 100;  // TRANSFER
                dg_ledgerdetail.Columns[7].Width = 400;  // TRANFER NAME
                dg_ledgerdetail.Columns[8].Width = 100;  // NOTE
                dg_ledgerdetail.Columns[9].Width = 100;  // IDMANIFIESTOOLD
                dg_ledgerdetail.Columns[10].Width = 100; // IDMANIFIESTO

                dg_ledgerdetail.Columns[0].HeaderText = "ID";
                dg_ledgerdetail.Columns[1].HeaderText = "Date";
                dg_ledgerdetail.Columns[2].HeaderText = "Charge Type";
                dg_ledgerdetail.Columns[3].HeaderText = "Charge";
                dg_ledgerdetail.Columns[4].HeaderText = "Payment";
                dg_ledgerdetail.Columns[5].HeaderText = "Staff";
                dg_ledgerdetail.Columns[6].HeaderText = "Transfer";
                dg_ledgerdetail.Columns[7].HeaderText = "Jumper of Transfer";
                dg_ledgerdetail.Columns[8].HeaderText = "Note";
                dg_ledgerdetail.Columns[9].HeaderText = "Manifest";
                dg_ledgerdetail.Columns[10].HeaderText = "Manifest new";

                u.Formatodgv(dg_ledgerdetail);
            }
            catch (Exception ex)
            { 
                MessageBox.Show("No records found " + ex.Message);
            }
        }
        #endregion

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }



    }
}
