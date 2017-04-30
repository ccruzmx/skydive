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
    public partial class Frm_vtavideos : Form
    {

        #region Variables

        ConectaBD conexion = new ConectaBD();
        //Int32 IdStatus;
        //DataSet dsjumper, dsbalancejump;
        //DataSet dsjumptype;
        //DataSet dsplane;
        //DataSet dsinsturctores;
        string condicion, campos, sql, tabla;
        utilerias u = new utilerias();
        int capacity = 0;

        //int _idjumper = 0;
        //int _idvuelo = 0;

        //Boolean PermiteCambioTipoSaltoEnManifiesto = false;
        //Boolean TicketValido = false;

        #endregion


        public Frm_vtavideos()
        {
            InitializeComponent();
        }

        private void Frm_vtavideos_Load(object sender, EventArgs e)
        {
            InicializaGrid();
        }



        #region Inicializa Grid
        private void InicializaGrid()
        {
            //condicion = @" WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.id1;
            condicion = "";
            dg_manifiesto.EnableHeadersVisualStyles = false;
            dg_manifiesto.DataSource = conexion.ConsultaManifiestoVtaVideo(condicion);  //getdata(fuente;
            //capacity = conexion.ConsultaManifiestoVtaVideo(condicion).Rows.Count;
            dg_manifiesto.Columns[0].Width = 50; // numerovuelo
            dg_manifiesto.Columns[0].Visible = true;

            dg_manifiesto.Columns[1].Width = 10; // IDMANIFIESTO
            dg_manifiesto.Columns[1].Visible = false;
            dg_manifiesto.Columns[2].Width = 10; // IDVUELO
            dg_manifiesto.Columns[2].Visible = false;
            dg_manifiesto.Columns[3].Width = 10; // idaeronave
            dg_manifiesto.Columns[3].Visible = false;
            dg_manifiesto.Columns[4].Width = 10; // matricula
            dg_manifiesto.Columns[4].Visible = false;
            dg_manifiesto.Columns[5].Width = 10; // IDJUMPER
            dg_manifiesto.Columns[5].Visible = false;
            dg_manifiesto.Columns[6].Width = 250; // JUMPER_NAME
            dg_manifiesto.Columns[7].Width = 150; // idjumptypecode

            dg_manifiesto.Columns[8].Width = 10; // IDTANDEM
            dg_manifiesto.Columns[8].Visible = false;

            dg_manifiesto.Columns[9].Width = 100; // Altitud
            dg_manifiesto.Columns[9].Visible = false;
            dg_manifiesto.Columns[10].Width = 150; // ticket
            dg_manifiesto.Columns[10].Visible = false;
            dg_manifiesto.Columns[11].Width = 200; // ticket
            dg_manifiesto.Columns[11].Visible = false;
            dg_manifiesto.Columns[12].Width = 100; // video
            dg_manifiesto.Columns[12].Visible = true;
            dg_manifiesto.Columns[13].Width = 100; // handvideo
            dg_manifiesto.Columns[13].Visible = true;
            dg_manifiesto.Columns[14].Width = 100; // video rent
            dg_manifiesto.Columns[14].Visible = true;
            dg_manifiesto.Columns[15].Width = 200; // referenced by
            dg_manifiesto.Columns[15].Visible = true;

            dg_manifiesto.Columns[0].HeaderText = "# VUELO";
            dg_manifiesto.Columns[6].HeaderText = "JUMPER NAME";
            dg_manifiesto.Columns[7].HeaderText = "JUMP TYPE";
            dg_manifiesto.Columns[9].HeaderText = "ALTITUD";
            dg_manifiesto.Columns[10].HeaderText = "TICKET";//
            dg_manifiesto.Columns[12].HeaderText = "VIDEO";
            dg_manifiesto.Columns[13].HeaderText = "HAND VIDEO";
            dg_manifiesto.Columns[14].HeaderText = "VIDEO RENT";
            dg_manifiesto.Columns[15].HeaderText = "REFERENCED BY";



            u.Formatodgv(dg_manifiesto);
           

        }
        #endregion

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            InicializaGrid();
        }



    }
}
