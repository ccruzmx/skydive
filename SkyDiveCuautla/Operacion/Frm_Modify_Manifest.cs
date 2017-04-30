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
    public partial class Frm_Modify_Manifest : Form
    {


        #region Variables
        string condicion;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();

        #endregion


        public Frm_Modify_Manifest()
        {
            InitializeComponent();
        }



        #region Inicializa Grid
        private void InicializaGrid()
        {
            //condicion = @" WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.id1;
            condicion = Convert.ToString( misglobales._idtandemup);
            dg_manifiesto.EnableHeadersVisualStyles = false;
            dg_manifiesto.DataSource = conexion.ConsultaManifiestoAModificar(condicion);  //getdata(fuente;
            //capacity = conexion.ConsultaManifiestoVtaVideo(condicion).Rows.Count;
            dg_manifiesto.Columns[0].Width = 60; // numerovuelo
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
            dg_manifiesto.Columns[12].Width = 60; // video
            dg_manifiesto.Columns[12].Visible = true;
            dg_manifiesto.Columns[13].Width = 60; // handvideo
            dg_manifiesto.Columns[13].Visible = true;
            dg_manifiesto.Columns[14].Width = 60; // video rent
            dg_manifiesto.Columns[14].Visible = true;
            dg_manifiesto.Columns[15].Width = 200; // referenced by
            dg_manifiesto.Columns[15].Visible = false;

            dg_manifiesto.Columns[0].HeaderText = "# VUELO";
            dg_manifiesto.Columns[6].HeaderText = "JUMPER NAME";
            dg_manifiesto.Columns[7].HeaderText = "JUMP TYPE";
            dg_manifiesto.Columns[10].HeaderText = "TICKET";//
            dg_manifiesto.Columns[12].HeaderText = "VIDEO";
            dg_manifiesto.Columns[13].HeaderText = "HAND VIDEO";
            dg_manifiesto.Columns[14].HeaderText = "VIDEO RENT";

            u.Formatodgv(dg_manifiesto);


        }
        #endregion


        #region Inicializa Grids
        private void InicializaGridPreManifest()
        {
            dg_premanifest.ScrollBars = ScrollBars.Vertical;


            condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) AND tandemup.idtandemup = " + Convert.ToString(misglobales._idtandemup) +"  ORDER BY convert(int,tandemup.SEQUENCE) asc ";
            dg_premanifest.EnableHeadersVisualStyles = false;
            dg_premanifest.DataSource = conexion.ConsultaPrePreManifiesto(condicion);  //getdata(fuente;
            dg_premanifest.Columns[0].Width = 10; // idtandemup
            dg_premanifest.Columns[0].Visible = false;
            dg_premanifest.Columns[1].Width = 10; // code
            dg_premanifest.Columns[1].Visible = false;
            dg_premanifest.Columns[2].Width = 35; // sequence
            dg_premanifest.Columns[2].Visible = true;
            dg_premanifest.Columns[3].Width = 10; // REGISTERTIME
            dg_premanifest.Columns[3].Visible = false;
            dg_premanifest.Columns[4].Width = 170; // name
            dg_premanifest.Columns[4].Visible = true;

            dg_premanifest.Columns[5].Width = 110; // referenced_by
            dg_premanifest.Columns[5].Visible = true;
            dg_premanifest.Columns[6].Width = 50; // jumptype
            dg_premanifest.Columns[6].Visible = false;
            dg_premanifest.Columns[7].Width = 70; // release
            dg_premanifest.Columns[7].Visible = true;
            dg_premanifest.Columns[8].Width = 190; // reserved_date
            dg_premanifest.Columns[8].Visible = false;
            dg_premanifest.Columns[9].Width = 200; // email
            dg_premanifest.Columns[9].Visible = false;
            dg_premanifest.Columns[10].Width = 55; // video
            dg_premanifest.Columns[10].Visible = true;
            dg_premanifest.Columns[11].Width = 55; // handvideo
            dg_premanifest.Columns[11].Visible = true;
            dg_premanifest.Columns[12].Width = 55; // video rent
            dg_premanifest.Columns[12].Visible = true;

            dg_premanifest.Columns[13].Width = 60; // tandemweight Peso
            dg_premanifest.Columns[13].Visible = true;
            dg_premanifest.Columns[14].Width = 60; // tandemovenweight sobrepeso
            dg_premanifest.Columns[14].Visible = true;
            dg_premanifest.Columns[15].Width = 60; // tandemheight altitud
            dg_premanifest.Columns[15].Visible = true;

            dg_premanifest.Columns[2].HeaderText = "#";
            dg_premanifest.Columns[4].HeaderText = "JUMPER NAME";
            dg_premanifest.Columns[5].HeaderText = "REFERENCE BY";
            dg_premanifest.Columns[7].HeaderText = "RELEASE";
            dg_premanifest.Columns[10].HeaderText = "VIDEO";
            dg_premanifest.Columns[11].HeaderText = "HAND VIDEO";
            dg_premanifest.Columns[12].HeaderText = "VIDEO RENT";
            dg_premanifest.Columns[13].HeaderText = "WEIGHT";
            dg_premanifest.Columns[14].HeaderText = "OVEN WEIGHT";
            dg_premanifest.Columns[15].HeaderText = "ALTITUD";


            u.Formatodgv(dg_premanifest);


        }
        #endregion



        private void Frm_Modify_Manifest_Load(object sender, EventArgs e)
        {
            InicializaGrid();
            InicializaGridPreManifest();

        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
