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
    public partial class Frm_TandemupList : Form
    {

        utilerias u = new utilerias();
        ConectaBD conexion = new ConectaBD();
        string condicion;

        public Frm_TandemupList()
        {
            InitializeComponent();
        }



        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview()
        {
            

            dg_tandemdisplay.EnableHeadersVisualStyles = false;
            dg_tandemdisplay.DataSource = conexion.ConsultaTandemDisplay(condicion);
            dg_tandemdisplay.Columns[0].Width = 25; //IDTANDEMUP
            dg_tandemdisplay.Columns[0].Visible = false;
            dg_tandemdisplay.Columns[1].Width = 50; //SEQUENCE
            dg_tandemdisplay.Columns[2].Width = 150; //REGISTER DATE/TIME
            dg_tandemdisplay.Columns[3].Width = 150; //NAME
            dg_tandemdisplay.Columns[4].Width = 150; //LASTNAME
            dg_tandemdisplay.Columns[5].Width = 70; //CHARGE
            dg_tandemdisplay.Columns[6].Width = 70; //PAYMENT
            dg_tandemdisplay.Columns[7].Width = 80; //RESERVED FOR
            dg_tandemdisplay.Columns[8].Width = 150; //JUMP TYPE
            dg_tandemdisplay.Columns[9].Width = 150; //EMAIL
            dg_tandemdisplay.Columns[10].Width = 250; //REFERENCE 
            dg_tandemdisplay.Columns[11].Width = 60; //RELEASE
            dg_tandemdisplay.Columns[12].Width = 60; //JUMPED
            dg_tandemdisplay.Columns[13].Width = 80;  //manifested
            dg_tandemdisplay.Columns[14].Width = 60;  //Numero Vuelo
            dg_tandemdisplay.Columns[15].Width = 120;  //Fecha Vuelo
            dg_tandemdisplay.Columns[16].Width = 100;  //OFICINA

            dg_tandemdisplay.Columns[1].HeaderText = "Sequence";
            dg_tandemdisplay.Columns[2].HeaderText = "Register Date / TIme";
            dg_tandemdisplay.Columns[3].HeaderText = "First Name";
            dg_tandemdisplay.Columns[4].HeaderText = "Last Name";
            dg_tandemdisplay.Columns[5].HeaderText = "Charge";
            dg_tandemdisplay.Columns[6].HeaderText = "Payment";
            dg_tandemdisplay.Columns[7].HeaderText = "Reserved Date";
            dg_tandemdisplay.Columns[8].HeaderText = "Jump";
            dg_tandemdisplay.Columns[9].HeaderText = "e-Mail";
            dg_tandemdisplay.Columns[10].HeaderText = "Reference";
            dg_tandemdisplay.Columns[11].HeaderText = "Release";
            dg_tandemdisplay.Columns[12].HeaderText = "Jumped";
            dg_tandemdisplay.Columns[13].HeaderText = "Manifested";
            dg_tandemdisplay.Columns[14].HeaderText = "Numero Vuelo";
            dg_tandemdisplay.Columns[15].HeaderText = "Fecha Vuelo";
            dg_tandemdisplay.Columns[16].HeaderText = "Oficina";


            u.Formatodgv(dg_tandemdisplay);

            //conexion.CloseDB();
        }
        #endregion



        #region Evento click
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btn_all_Click(object sender, EventArgs e)
        {
            condicion = "  ORDER BY tbv.fechaabrevuelo, tbv.numerovuelo, convert(int,tandemup.SEQUENCE) asc";
            inicializagridview();
        }

        private void LimpiaGrid()
        {
            condicion = "  WHERE 1 =2 ";
            inicializagridview();
        }

        private void btn_debt_Click(object sender, EventArgs e)
        {
            //LimpiaGrid();
            condicion = "  WHERE tandemup.PAYMaNT < tandemup.CHARGE  ORDER BY tbv.fechaabrevuelo, tbv.numerovuelo, convert(int,tandemup.SEQUENCE) asc";
            inicializagridview();
        }

        private void Frm_TandemupList_Load(object sender, EventArgs e)
        {
            //LimpiaGrid();
            condicion = "  ORDER BY tbv.fechaabrevuelo, tbv.numerovuelo, convert(int,tandemup.SEQUENCE) asc";
            inicializagridview();
        }


    }
}
