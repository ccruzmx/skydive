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
    public partial class Frm_Itinerary : Form
    {


        utilerias u = new utilerias();
        ConectaBD conexion = new ConectaBD();
        string condicion, campos, sql, tabla;
        DataTable dt = new DataTable();
        Int32 RefresMonitor = 0;
        String losminutos = ":0";
        String lossegundos = ":0";

        String losminutos2 = ":0";
        String lossegundos2 = ":0";

        String losminutos3 = ":0";
        String lossegundos3 = ":0";

        #region Constructor del Form Frm_Itinerary
        public Frm_Itinerary()
        {
            InitializeComponent();
        }
        #endregion

        #region Inicializa Grid
        private void InicializaGrid()
        {
            RefresMonitor = 0;
            sql = "SELECT idvuelo, descripcion_vuelo, vuelo_minuto, vuelo_segundo, vuelo_centesimas, monobj, monitor_idvuelo, ontime FROM dbo.tb_Monitor ";
            tabla = "dbo.tb_Monitor";
            condicion = " ";

            dt = conexion.ConsultaUniversalDT(sql, condicion, tabla);

            lbl_crono1.Text = "00:00:00";
            lbl_monvuelo1.Text = "";
            lbl_ontime1.Text = "";

            lbl_crono2.Text = "00:00:00";
            lbl_monvuelo2.Text = "";
            lbl_ontime2.Text = "";

            lbl_crono2.Text = "00:00:00";
            lbl_monvuelo2.Text = "";
            lbl_ontime2.Text = "";



            if (dt.Rows.Count == 1)
            {
                misglobales.idvuelo1 = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                misglobales.idvuelo2 = 0;
                misglobales.idvuelo3 = 0;

            }
            else if (dt.Rows.Count == 2) 
            {
                misglobales.idvuelo1 = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                misglobales.idvuelo2 = Convert.ToInt32(dt.Rows[1].ItemArray[0].ToString());
                misglobales.idvuelo3 = 0;
            }
            else if (dt.Rows.Count == 3)
            {
                misglobales.idvuelo1 = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                misglobales.idvuelo2 = Convert.ToInt32(dt.Rows[1].ItemArray[0].ToString());
                misglobales.idvuelo3 = Convert.ToInt32(dt.Rows[2].ItemArray[0].ToString());
            }
            else {
                return; 
            }

            condicion = @" WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.idvuelo1;
            
            dg_itinerario1.EnableHeadersVisualStyles = false;
            dg_itinerario1.Refresh();

            dg_itinerario1.DataSource = conexion.ConsultaManifiestoItinerario(condicion);  //getdata(fuente;
            //     
            //       JUMPTYPE.Altitud
            dg_itinerario1.Columns[0].Width = 10; // IDMANIFIESTO
            dg_itinerario1.Columns[0].Visible = false;
            dg_itinerario1.Columns[1].Width = 100; // IDVUELO
            dg_itinerario1.Columns[1].Visible = false;
            dg_itinerario1.Columns[2].Width = 0;  // IDJUMPER
            dg_itinerario1.Columns[2].Visible = false;
            dg_itinerario1.Columns[3].Width = 350;  // JUMPER_NAME
            dg_itinerario1.Columns[3].Visible = true;
            dg_itinerario1.Columns[3].HeaderText = "JUMPER NAME";
            dg_itinerario1.Columns[4].Width = 200;  // JUMPTYPE
            dg_itinerario1.Columns[4].Visible = true;
            dg_itinerario1.Columns[4].HeaderText = "JUMP TYPE";
            dg_itinerario1.Columns[5].Width = 0;  // IDTANDEM
            dg_itinerario1.Columns[5].Visible = false;
            dg_itinerario1.Columns[6].Width = 50;  // VIDEO
            dg_itinerario1.Columns[6].Visible = false;
            dg_itinerario1.Columns[6].HeaderText = "VIDEO";
            dg_itinerario1.Columns[7].Width = 50;  // HANDVIDEO
            dg_itinerario1.Columns[7].Visible = false;
            dg_itinerario1.Columns[7].HeaderText = "HAND VIDEO";
            dg_itinerario1.Columns[8].Visible = false; // VIDEORENT
            


            //dg_itinerario1.Columns[5].Width = 459; // JUMPER_NAME
            //dg_itinerario1.Columns[5].Visible = false;
            //dg_itinerario1.Columns[6].Width = 0;  // IDJUMPTYPE
            //dg_itinerario1.Columns[6].Visible = false;
            //dg_itinerario1.Columns[7].Width = 0;  // IDTANDEM
            //dg_itinerario1.Columns[7].Visible = false;
            //dg_itinerario1.Columns[8].Width = 0;  // TANDEM_NAME
            //dg_itinerario1.Columns[8].Visible = false;
            //dg_itinerario1.Columns[9].Width = 0;  // ALTITUD
            //dg_itinerario1.Columns[9].Visible = false;
            //dg_itinerario1.Columns[10].Width = 0;  // LEADGER_NAME
            //dg_itinerario1.Columns[10].Visible = false;
            //dg_itinerario1.Columns[11].Width = 0;  // ID_TANDEM
            //dg_itinerario1.Columns[11].Visible = false;
            //dg_itinerario1.Columns[12].Width = 459;  // MONITOR_NAME
            //dg_itinerario1.Columns[12].HeaderText = "JUMPER NAME";
            u.Formatodgv(dg_itinerario1);

            condicion = @" WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.idvuelo2;
            dg_itinerario2.EnableHeadersVisualStyles = false;
            dg_itinerario2.Refresh();
            dg_itinerario2.DataSource = conexion.ConsultaManifiestoItinerario(condicion);  //getdata(fuente;
            //dg_itinerario2.Columns[0].Width = 10; // IDMANIFIESTO
            //dg_itinerario2.Columns[0].Visible = false;
            //dg_itinerario2.Columns[1].Width = 100; // IDVUELO
            //dg_itinerario2.Columns[1].Visible = false;
            //dg_itinerario2.Columns[2].Width = 0;  // IDAERONAVE
            //dg_itinerario2.Columns[2].Visible = false;
            //dg_itinerario2.Columns[3].Width = 0;  // MATRICULA
            //dg_itinerario2.Columns[3].Visible = false;
            //dg_itinerario2.Columns[4].Width = 0;  // IDJUMPER
            //dg_itinerario2.Columns[4].Visible = false;
            //dg_itinerario2.Columns[5].Width = 459; // JUMPER_NAME
            //dg_itinerario2.Columns[5].Visible = false;
            //dg_itinerario2.Columns[6].Width = 0;  // IDJUMPTYPE
            //dg_itinerario2.Columns[6].Visible = false;
            //dg_itinerario2.Columns[7].Width = 0;  // IDTANDEM
            //dg_itinerario2.Columns[7].Visible = false;
            //dg_itinerario2.Columns[8].Width = 0;  // TANDEM_NAME
            //dg_itinerario2.Columns[8].Visible = false;
            //dg_itinerario2.Columns[9].Width = 0;  // ALTITUD
            //dg_itinerario2.Columns[9].Visible = false;
            //dg_itinerario2.Columns[10].Width = 0;  // LEADGER_NAME
            //dg_itinerario2.Columns[10].Visible = false;
            //dg_itinerario2.Columns[11].Width = 0;  // ID_TANDEM
            //dg_itinerario2.Columns[11].Visible = false;
            //dg_itinerario2.Columns[12].Width = 459;  // MONITOR_NAME
            //dg_itinerario2.Columns[12].HeaderText = "JUMPER NAME";
            dg_itinerario2.Columns[0].Width = 10; // IDMANIFIESTO
            dg_itinerario2.Columns[0].Visible = false;
            dg_itinerario2.Columns[1].Width = 100; // IDVUELO
            dg_itinerario2.Columns[1].Visible = false;
            dg_itinerario2.Columns[2].Width = 0;  // IDJUMPER
            dg_itinerario2.Columns[2].Visible = false;
            dg_itinerario2.Columns[3].Width = 350;  // JUMPER_NAME
            dg_itinerario2.Columns[3].Visible = true;
            dg_itinerario2.Columns[3].HeaderText = "JUMPER NAME";
            dg_itinerario2.Columns[4].Width = 200;  // JUMPTYPE
            dg_itinerario2.Columns[4].Visible = true;
            dg_itinerario2.Columns[4].HeaderText = "JUMP TYPE";
            dg_itinerario2.Columns[5].Width = 0;  // IDTANDEM
            dg_itinerario2.Columns[5].Visible = false;
            dg_itinerario2.Columns[6].Width = 50;  // VIDEO
            dg_itinerario2.Columns[6].Visible = false;
            dg_itinerario2.Columns[6].HeaderText = "VIDEO";
            dg_itinerario2.Columns[7].Width = 50;  // HANDVIDEO
            dg_itinerario2.Columns[7].Visible = false;
            dg_itinerario2.Columns[7].HeaderText = "HAND VIDEO";
            dg_itinerario2.Columns[8].Visible = false; // VIDEORENT

            u.Formatodgv(dg_itinerario2);

            condicion = @" WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.idvuelo3;
            dg_itinerario3.EnableHeadersVisualStyles = false;
            dg_itinerario3.Refresh();
            dg_itinerario3.DataSource = conexion.ConsultaManifiestoItinerario(condicion);  //getdata(fuente;
            //dg_itinerario3.Columns[0].Width = 10; // IDMANIFIESTO
            //dg_itinerario3.Columns[0].Visible = false;
            //dg_itinerario3.Columns[1].Width = 100; // IDVUELO
            //dg_itinerario3.Columns[1].Visible = false;
            //dg_itinerario3.Columns[2].Width = 0;  // IDAERONAVE
            //dg_itinerario3.Columns[2].Visible = false;
            //dg_itinerario3.Columns[3].Width = 0;  // MATRICULA
            //dg_itinerario3.Columns[3].Visible = false;
            //dg_itinerario3.Columns[4].Width = 0;  // IDJUMPER
            //dg_itinerario3.Columns[4].Visible = false;
            //dg_itinerario3.Columns[5].Width = 459; // JUMPER_NAME
            //dg_itinerario3.Columns[5].Visible = false;
            //dg_itinerario3.Columns[6].Width = 0;  // IDJUMPTYPE
            //dg_itinerario3.Columns[6].Visible = false;
            //dg_itinerario3.Columns[7].Width = 0;  // IDTANDEM
            //dg_itinerario3.Columns[7].Visible = false;
            //dg_itinerario3.Columns[8].Width = 0;  // TANDEM_NAME
            //dg_itinerario3.Columns[8].Visible = false;
            //dg_itinerario3.Columns[9].Width = 0;  // ALTITUD
            //dg_itinerario3.Columns[9].Visible = false;
            //dg_itinerario3.Columns[10].Width = 0;  // LEADGER_NAME
            //dg_itinerario3.Columns[10].Visible = false;
            //dg_itinerario3.Columns[11].Width = 0;  // ID_TANDEM
            //dg_itinerario3.Columns[11].Visible = false;
            //dg_itinerario3.Columns[12].Width = 455;  // MONITOR_NAME
            //dg_itinerario3.Columns[12].HeaderText = "JUMPER NAME";
            dg_itinerario3.Columns[0].Width = 10; // IDMANIFIESTO
            dg_itinerario3.Columns[0].Visible = false;
            dg_itinerario3.Columns[1].Width = 100; // IDVUELO
            dg_itinerario3.Columns[1].Visible = false;
            dg_itinerario3.Columns[2].Width = 0;  // IDJUMPER
            dg_itinerario3.Columns[2].Visible = false;
            dg_itinerario3.Columns[3].Width = 350;  // JUMPER_NAME
            dg_itinerario3.Columns[3].Visible = true;
            dg_itinerario3.Columns[3].HeaderText = "JUMPER NAME";
            dg_itinerario3.Columns[4].Width = 200;  // JUMPTYPE
            dg_itinerario3.Columns[4].Visible = true;
            dg_itinerario3.Columns[4].HeaderText = "JUMP TYPE";
            dg_itinerario3.Columns[5].Width = 0;  // IDTANDEM
            dg_itinerario3.Columns[5].Visible = false;
            dg_itinerario3.Columns[6].Width = 50;  // VIDEO
            dg_itinerario3.Columns[6].Visible = false;
            dg_itinerario3.Columns[6].HeaderText = "VIDEO";
            dg_itinerario3.Columns[7].Width = 50;  // HANDVIDEO
            dg_itinerario3.Columns[7].Visible = false;
            dg_itinerario3.Columns[7].HeaderText = "HAND VIDEO";
            dg_itinerario3.Columns[8].Visible = false; // VIDEORENT
            
            u.Formatodgv(dg_itinerario3);
            

        }
        #endregion

        #region Evento Load del Form Frm_Itinerary
        private void Frm_Itinerary_Load(object sender, EventArgs e)
        {
            InicializaGrid();
            tmr_ontime.Start();

        }
        #endregion

        #region Evento Activatede del From Frm_Itinerary
        private void Frm_Itinerary_Activated(object sender, EventArgs e)
        {
            InicializaGrid();
            tmr_ontime.Start();
        }
        #endregion

        #region Evento Tick del Timer tmr_ontime
        private void tmr_ontime_Tick(object sender, EventArgs e)
        {

            //MONITOREANDO DESDE BD
            RefresMonitor = RefresMonitor + 1;

            sql = "SELECT idvuelo, descripcion_vuelo, vuelo_minuto, vuelo_segundo, vuelo_centesimas, monobj, monitor_idvuelo, ontime FROM dbo.tb_Monitor ";
            tabla = "dbo.tb_Monitor";
            condicion = " " ;

            dt = conexion.ConsultaUniversalDT(sql, condicion, tabla);

            if (dt.Rows.Count == 1)
            {
                misglobales.idvuelo1 = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                misglobales.monidvuelo1 = dt.Rows[0].ItemArray[1].ToString();
                misglobales.vuelo1min = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
                misglobales.vuelo1seg = Convert.ToInt32(dt.Rows[0].ItemArray[3].ToString());
                misglobales.vuelo1centesimas = Convert.ToInt32(dt.Rows[0].ItemArray[4].ToString());
                misglobales.ontime1 = dt.Rows[0].ItemArray[7].ToString();

                misglobales.idvuelo2 = 0;
                misglobales.monidvuelo2 = "";
                //misglobales.vuelo2min = 0;
                //misglobales.vuelo2seg = 0;
                //misglobales.vuelo2centesimas = 0;
                misglobales.ontime2 = "ON-TIME";
                lbl_crono2.Text = "00:00:00";


                misglobales.idvuelo3 = 0;
                misglobales.monidvuelo3 = "";
                //misglobales.vuelo3min = 0;
                //misglobales.vuelo3seg = 0;
                //misglobales.vuelo3centesimas = 0;
                misglobales.ontime3 = "ON-TIME";
                lbl_crono3.Text = "00:00:00";

            }
            else if (dt.Rows.Count == 2)
            {

                misglobales.idvuelo1 = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                misglobales.monidvuelo1 = dt.Rows[0].ItemArray[1].ToString();
                misglobales.vuelo1min = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
                misglobales.vuelo1seg = Convert.ToInt32(dt.Rows[0].ItemArray[3].ToString());
                misglobales.vuelo1centesimas = Convert.ToInt32(dt.Rows[0].ItemArray[4].ToString());
                misglobales.ontime1 = dt.Rows[0].ItemArray[7].ToString();


                misglobales.idvuelo2 = Convert.ToInt32(dt.Rows[1].ItemArray[0].ToString());
                misglobales.monidvuelo2 = dt.Rows[1].ItemArray[1].ToString();
                misglobales.vuelo2min = Convert.ToInt32(dt.Rows[1].ItemArray[2].ToString());
                misglobales.vuelo2seg = Convert.ToInt32(dt.Rows[1].ItemArray[3].ToString());
                misglobales.vuelo2centesimas = Convert.ToInt32(dt.Rows[1].ItemArray[4].ToString());
                misglobales.ontime2 = dt.Rows[1].ItemArray[7].ToString();

                misglobales.idvuelo3 = 0;
                misglobales.monidvuelo3 = "";
                //misglobales.vuelo3min = 0;
                //misglobales.vuelo3seg = 0;
                //misglobales.vuelo3centesimas = 0;
                misglobales.ontime3 = "ON-TIME";
                lbl_crono3.Text = "00:00:00";

            }
            else if (dt.Rows.Count == 3)
            {

                misglobales.idvuelo1 = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                misglobales.monidvuelo1 = dt.Rows[0].ItemArray[1].ToString();
                misglobales.vuelo1min = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
                misglobales.vuelo1seg = Convert.ToInt32(dt.Rows[0].ItemArray[3].ToString());
                misglobales.vuelo1centesimas = Convert.ToInt32(dt.Rows[0].ItemArray[4].ToString());
                misglobales.ontime1 = dt.Rows[0].ItemArray[7].ToString();


                misglobales.idvuelo2 = Convert.ToInt32(dt.Rows[1].ItemArray[0].ToString());
                misglobales.monidvuelo2 = dt.Rows[1].ItemArray[1].ToString();
                misglobales.vuelo2min = Convert.ToInt32(dt.Rows[1].ItemArray[2].ToString());
                misglobales.vuelo2seg = Convert.ToInt32(dt.Rows[1].ItemArray[3].ToString());
                misglobales.vuelo2centesimas = Convert.ToInt32(dt.Rows[1].ItemArray[4].ToString());
                misglobales.ontime2 = dt.Rows[1].ItemArray[7].ToString();

                misglobales.idvuelo3 = Convert.ToInt32(dt.Rows[2].ItemArray[0].ToString());
                misglobales.monidvuelo3 = dt.Rows[2].ItemArray[1].ToString();
                misglobales.vuelo3min = Convert.ToInt32(dt.Rows[2].ItemArray[2].ToString());
                misglobales.vuelo3seg = Convert.ToInt32(dt.Rows[2].ItemArray[3].ToString());
                misglobales.vuelo3centesimas = Convert.ToInt32(dt.Rows[2].ItemArray[4].ToString());
                misglobales.ontime3 = dt.Rows[2].ItemArray[7].ToString();
            }
            else if (dt.Rows.Count == 0)
            {
                misglobales.idvuelo1 = 0;
                misglobales.monidvuelo1 = "";
                //misglobales.vuelo1min = 0;
                //misglobales.vuelo1seg = 0;
                //misglobales.vuelo1centesimas = 0;
                misglobales.ontime1 = "ON-TIME";
                lbl_crono1.Text = "00:00:00";

                misglobales.idvuelo2 = 0;
                misglobales.monidvuelo2 = "";
                //misglobales.vuelo2min = 0;
                //misglobales.vuelo2seg = 0;
                //misglobales.vuelo2centesimas = 0;
                misglobales.ontime2 = "ON-TIME";
                lbl_crono2.Text = "00:00:00";

                misglobales.idvuelo3 = 0;
                misglobales.monidvuelo3 = "";
                //misglobales.vuelo3min = 0;
                //misglobales.vuelo3seg = 0;
                //misglobales.vuelo3centesimas = 0;
                misglobales.ontime3 = "ON-TIME";
                lbl_crono3.Text = "00:00:00";

                InicializaGrid(); 
            }

            conexion.CloseDB();
            if (RefresMonitor == 2000) { InicializaGrid(); RefresMonitor = 0; }
        
            //

            if (misglobales.vuelo1seg < 10 ) { lossegundos = ":0"; }
            else
            { lossegundos = ":"; }

            if (misglobales.vuelo2seg < 10)  { lossegundos2 = ":0"; }
            else
            { lossegundos2 = ":"; }

            if (misglobales.vuelo3seg < 10) { lossegundos3 = ":0"; }
            else
            { lossegundos3 = ":"; }


            if (misglobales.vuelo1min < 10) { losminutos = "00:0"; }
            else
            { losminutos = "00:"; }

            if (misglobales.vuelo2min < 10) { losminutos2 = "00:0"; }
            else
            { losminutos2 = "00:"; }

            if (misglobales.vuelo3min < 10) { losminutos3= "00:0"; }
            else
            { losminutos3 = "00:"; }

            lbl_crono1.Text = losminutos + misglobales.vuelo1min + lossegundos + misglobales.vuelo1seg;
            lbl_crono2.Text = losminutos2 + misglobales.vuelo2min + lossegundos2 + misglobales.vuelo2seg;
            lbl_crono3.Text = losminutos3 + misglobales.vuelo3min + lossegundos3 + misglobales.vuelo3seg;


            lbl_ontime1.Text = misglobales.ontime1;
            lbl_ontime2.Text = misglobales.ontime2;
            lbl_ontime3.Text = misglobales.ontime3;

            lbl_monvuelo1.Text = misglobales.monidvuelo1;
            lbl_monvuelo2.Text = misglobales.monidvuelo2;
            lbl_monvuelo3.Text = misglobales.monidvuelo3;


            if (misglobales.ontime1 == "ON-HOLD")
            {
                lbl_ontime1.BackColor = Color.Orange; lbl_ontime1.ForeColor = Color.Green;
            }
            else if (misglobales.ontime1 == "ON-TIME")
            {
                lbl_ontime1.BackColor = Color.Green; lbl_ontime1.ForeColor = Color.Yellow;
            }
            else if (misglobales.ontime1 == "ON-CALL")
            {
                lbl_ontime1.BackColor = Color.Yellow; lbl_ontime1.ForeColor = Color.Green;
            }
            else if (misglobales.ontime1 == "ON-BOARD")
            {
                lbl_ontime1.BackColor = Color.Red; lbl_ontime1.ForeColor = Color.Yellow;
            }


            
            if (misglobales.ontime2 == "ON-HOLD")
            {
                lbl_ontime2.BackColor = Color.Orange; lbl_ontime2.ForeColor = Color.Green;
            }
            else if (misglobales.ontime2 == "ON-TIME")
            {
                lbl_ontime2.BackColor = Color.Green; lbl_ontime2.ForeColor = Color.Yellow;
            }
            else if (misglobales.ontime2 == "ON-CALL")
            {
                lbl_ontime2.BackColor = Color.Yellow; lbl_ontime2.ForeColor = Color.Green;
            }
            else if (misglobales.ontime2 == "ON-BOARD")
            {
                lbl_ontime1.BackColor = Color.Red; lbl_ontime1.ForeColor = Color.Yellow;
            }


            if (misglobales.ontime3 == "ON-HOLD")
            {
                lbl_ontime3.BackColor = Color.Orange; lbl_ontime3.ForeColor = Color.Green;
            }
            else if (misglobales.ontime3 == "ON-TIME")
            {
                lbl_ontime3.BackColor = Color.Green;lbl_ontime3.ForeColor = Color.Yellow;
            }
            else if (misglobales.ontime3 == "ON-CALL")
            {
                lbl_ontime3.BackColor = Color.Yellow; lbl_ontime3.ForeColor = Color.Green;
            }
            else if (misglobales.ontime3 == "ON-BOARD")
            {
                lbl_ontime1.BackColor = Color.Red; lbl_ontime1.ForeColor = Color.Yellow;
            }

        }
        #endregion

    }
}
