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
    public partial class Frm_PreManifest : Form
    {
        #region Zona de variables
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String valores, condicion, sql, tabla, campos, storeprocedure;
        String _grupo = "A";
        DataSet dstandemup, dsinstructores;
        #endregion 

        #region constructor de la forma Frm_PreManifest
        public Frm_PreManifest()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento click del boton exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Inicializa Grids
        private void InicializaGrid()
        {
            dg_premanifest.ScrollBars = ScrollBars.Vertical;
            



            condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) AND manifested = 0  ORDER BY convert(int,tandemup.SEQUENCE) asc ";
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


            condicion = "  WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  ORDER BY jumps_totals, sequence asc -- CONVERT(VARCHAR(8), REGISTERTIME, 108) asc ";
            dg_instructores.EnableHeadersVisualStyles = false;
            dg_instructores.DataSource = conexion.ConsultaInstructores(condicion);
            dg_instructores.Columns[0].Width = 25; //ID 
            dg_instructores.Columns[0].Visible = false;
            dg_instructores.Columns[1].Width = 25; //IDjumper 
            dg_instructores.Columns[1].Visible = false;
            dg_instructores.Columns[2].Width = 50; //sequence 
            dg_instructores.Columns[2].Visible = true;
            dg_instructores.Columns[3].Width = 100; //registertime 
            dg_instructores.Columns[3].Visible = true;
            dg_instructores.Columns[4].Width = 221; //name 
            dg_instructores.Columns[4].Visible = true;
            dg_instructores.Columns[5].Width = 80; //video 
            dg_instructores.Columns[5].Visible = true;
            dg_instructores.Columns[6].Width = 80; //Handvideo 
            dg_instructores.Columns[6].Visible = true;
            dg_instructores.Columns[7].Width = 80; //Video Rent 
            dg_instructores.Columns[7].Visible = true;
            dg_instructores.Columns[8].Width = 80; //tandem
            dg_instructores.Columns[8].Visible = true;
            dg_instructores.Columns[9].Width = 100; //bussy
            dg_instructores.Columns[9].Visible = false;
            dg_instructores.Columns[10].Width = 90; //jumps_premanifested 
            dg_instructores.Columns[10].Visible = true;
            dg_instructores.Columns[11].Width = 90; //jumps_manifested 
            dg_instructores.Columns[11].Visible = true;
            dg_instructores.Columns[12].Width = 90; //jumps_rejected
            dg_instructores.Columns[12].Visible = true;
            dg_instructores.Columns[12].Width = 90; //jumps_totals
            dg_instructores.Columns[12].Visible = true;


            dg_instructores.Columns[2].HeaderText = "Seq";
            dg_instructores.Columns[3].HeaderText = "Register Time";
            dg_instructores.Columns[4].HeaderText = "Name";
            dg_instructores.Columns[5].HeaderText = "Video";
            dg_instructores.Columns[6].HeaderText = "Hand Video";
            dg_instructores.Columns[7].HeaderText = "Video Rent";
            dg_instructores.Columns[8].HeaderText = "Tandem";
            dg_instructores.Columns[10].HeaderText = "# Jumps pre manifested";
            dg_instructores.Columns[11].HeaderText = "# Jumps manifested";
            dg_instructores.Columns[12].HeaderText = "# Jumps rejected";
            dg_instructores.Columns[13].HeaderText = "TOTAL JUMPS";

            u.Formatodgv(dg_instructores);


            condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) AND manifested in( 0,1,2) order by TB_MANIFIESTO.code, TB_MANIFIESTO.IDMANIFIESTO";
            dg_premanifestdetail.EnableHeadersVisualStyles = false;
            dg_premanifestdetail.DataSource = conexion.ConsultaPreManifiesto(condicion);  //getdata(fuente;
            dg_premanifestdetail.Columns[0].Width = 100; // idpremanifiesto
            dg_premanifestdetail.Columns[0].Visible = false;
            dg_premanifestdetail.Columns[1].Width = 100; // code
            dg_premanifestdetail.Columns[1].Visible = true;
            dg_premanifestdetail.Columns[2].Width = 100; // idvuelo
            dg_premanifestdetail.Columns[2].Visible = false;
            dg_premanifestdetail.Columns[3].Width = 100; // idjumper
            dg_premanifestdetail.Columns[3].Visible = false;
            dg_premanifestdetail.Columns[4].Width = 180; // jumpername
            dg_premanifestdetail.Columns[4].Visible = true;
            dg_premanifestdetail.Columns[5].Width = 100; // idjumptype
            dg_premanifestdetail.Columns[5].Visible = false;
            dg_premanifestdetail.Columns[6].Width = 150; // jumptype
            dg_premanifestdetail.Columns[6].Visible = true;
            dg_premanifestdetail.Columns[7].Width = 150; // idtandem
            dg_premanifestdetail.Columns[7].Visible = false;
            dg_premanifestdetail.Columns[8].Width = 80; // altitud
            dg_premanifestdetail.Columns[8].Visible = true;
            dg_premanifestdetail.Columns[9].Width = 150; // codegroup
            dg_premanifestdetail.Columns[9].Visible = false;
            dg_premanifestdetail.Columns[10].Width = 50; //video
            dg_premanifestdetail.Columns[10].Visible = true;
            dg_premanifestdetail.Columns[11].Width = 90; //handvideo
            dg_premanifestdetail.Columns[11].Visible = true;
            dg_premanifestdetail.Columns[12].Width = 70; //videorent
            dg_premanifestdetail.Columns[12].Visible = true;

            u.Formatodgv(dg_premanifestdetail);

        }
        #endregion

        #region Carga Combo Instructor 1
        private void CargaComboInstructor1()
        {

            int videorent, handvideo = 0;
            string condicionadicional = " ";


            if (chk_handvideo.Checked == true) { handvideo = 1; condicionadicional = " AND handvideo = 1"; } else { handvideo = 0; }
            if (chb_videorent.Checked == true) { videorent = 1; condicionadicional = " AND videorent = 1"; } else { videorent = 0; }
            
            if (lbl_idjumper2.Text == "idjumper2") {  lbl_idjumper2.Text = "0";}
                  sql = @" select id, idjumper, sequence, CONVERT(VARCHAR(8), REGISTERTIME, 108),  name, video, handvideo, tandem, busy from dbo.tb_instructors_activity with(nolock) ";
                tabla =  "tb_instructors_activity";
                condicion = @"  WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                             AND idjumper <> " + lbl_idjumper2.Text + @" AND TANDEM = 1 " + condicionadicional +
                                                   " ORDER BY jumps_totals, CONVERT(VARCHAR(8), REGISTERTIME, 108) asc";
                            //" ORDER BY  CONVERT(VARCHAR(8), REGISTERTIME, 108) asc ";
            DataSet dsinstructor = conexion.ConsultaUniversal(sql, condicion, tabla);

            cmb_instructor1.DataSource = dsinstructor.Tables[0].DefaultView;
            cmb_instructor1.AutoCompleteCustomSource = LoadAutoComplete(dsinstructor, "name");
            cmb_instructor1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_instructor1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_instructor1.DisplayMember = "name";
            cmb_instructor1.ValueMember = "idjumper";
            cmb_instructor1.SelectedItem = null;
        }
        #endregion 

        #region Carga Combo Instructor 2
        private void CargaComboInstructor2()
        {
            if (lbl_idjumper1.Text == "idjumper1") { lbl_idjumper1.Text = "0"; }
            sql = @" select id, idjumper, sequence, CONVERT(VARCHAR(8), REGISTERTIME, 108),  name, video, handvideo, tandem, busy from dbo.tb_instructors_activity with(nolock) ";
            tabla = "tb_instructors_activity";
            condicion = @"  WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                             AND idjumper <> " + lbl_idjumper1.Text + @"  AND ( VIDEO = 1 )" +
                                               " ORDER BY jumps_totals, CONVERT(VARCHAR(8), REGISTERTIME, 108) asc";
                          //"  ORDER BY  CONVERT(VARCHAR(8), REGISTERTIME, 108) asc ";

            DataSet dsinstructor2 = conexion.ConsultaUniversal(sql, condicion, tabla);

            cmb_instructor2.DataSource = dsinstructor2.Tables[0].DefaultView;
            cmb_instructor2.AutoCompleteCustomSource = LoadAutoComplete(dsinstructor2, "name");
            cmb_instructor2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_instructor2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_instructor2.DisplayMember = "name";
            cmb_instructor2.ValueMember = "idjumper";
            cmb_instructor2.SelectedItem = null;
        }
        #endregion 

        #region Inicializa Objetos
        private void InicializaObjetos()
        {

            txb_sequence.Text = "";
            lbl_idtandem.Text = "idtandem";
            txb_flight.Text = "";
            txb_tandemname.Text = "";
            txb_jumptype.Text = "";
            lbl_idjumptype.Text = "id_jumptype";
            txb_weight.Text = "";
            txb_height.Text = "";

            CargaComboInstructor1();


            sql = @"SELECT idjumptype, codigo, jump_type, codey FROM dbo.CT_JUMP_TYPE";
            condicion = @" where idestatus = 1 and idjumptype in(66,8) order by orden";
            tabla = "CT_JUMP_TYPE";

            DataSet dsjumptype1 = conexion.ConsultaUniversal(sql, condicion, tabla);
            cmb_jumptype1.DataSource = dsjumptype1.Tables[0].DefaultView;
            cmb_jumptype1.AutoCompleteCustomSource = LoadAutoComplete(dsjumptype1, "jump_type");
            cmb_jumptype1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumptype1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumptype1.DisplayMember = "jump_type";
            cmb_jumptype1.ValueMember = "idjumptype";
            cmb_jumptype1.SelectedItem = 1;


            CargaComboInstructor2();

            sql = @"SELECT idjumptype, codigo, jump_type, codey FROM dbo.CT_JUMP_TYPE";
            condicion = @" where idestatus = 1 and idjumptype = 70 order by orden";
            tabla = "CT_JUMP_TYPE";
            DataSet dsjumptype2 = conexion.ConsultaUniversal(sql, condicion, tabla);
            cmb_jumptype2.DataSource = dsjumptype2.Tables[0].DefaultView;
            cmb_jumptype2.AutoCompleteCustomSource = LoadAutoComplete(dsjumptype2, "jump_type");
            cmb_jumptype2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumptype2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumptype2.DisplayMember = "jump_type";
            cmb_jumptype2.ValueMember = "idjumptype";
            cmb_jumptype2.SelectedItem = 1;
            cmb_instructor2.Visible = false;
            lbl_jumptype2.Visible = false;
            cmb_jumptype2.Visible = false;




            lbl_idjumper1.Text = "idjumper1";
            lbl_idjumper2.Text = "idjumper2";
            chk_video.Checked = false;
            chk_handvideo.Checked = false;
            chb_videorent.Checked = false;

            grb_edit.Enabled = false;
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

        #region Metodo inserta Instructor
        private void InsertaInstructor(String Flight, Int32 _idinstructor, String  _jumptypecodeinstructor, string ReservedFor, string grupo, Int32 videorenta      )
        {

            tabla = "TB_PRE_MANIFIESTO";
            campos = "code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, codegroup, videorent";

            valores = "'" + Flight + "', 0, " + _idinstructor + ", 0 , 0, '" + _jumptypecodeinstructor +
          "', '" + ReservedFor + "', '" + grupo + "'," + videorenta;

            try
            {
                conexion.InsertTabla(campos, tabla, valores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try add instructor into pre manifest " + ex.Message);
            }

        }
        #endregion 

        #region Metodo Arma PreManifiesto
        private void ArmaPreManifiesto()
        {
           // Cargar datasets con información de tandemup e instructores

            tabla = "tandemup";
            condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) AND manifested = 0  ORDER BY convert(int,tandemup.SEQUENCE) asc ";
            sql = @" truncate table dbo.TB_PRE_MANIFIESTO

                    SELECT tandemup.idtandemup,  tandemup.SEQUENCE, CONVERT(VARCHAR(8), tandemup.REGISTERTIME, 108) as REGISTERTIME, tandemup.NAME, tandemup.LASTNAME, tandemup.REFERENCED_BY, 
                           tandemup.JUMPTYPE, tandemup.pricejump, tandemup.CHARGE, tandemup.PAYMaNT, Convert(bit,tandemup.RELEASE) as release,  tandemup.RESERVED_DATE,  tandemup.EMAIL,  
                           convert(bit,tandemup.JUMP_FLAG) as [JUMP FLAG],  tandemup.ID_PROSPECT, tandemup.CODE_LEDGER, tandemup.CODE, tandemup.manifested, convert(bit,0) as video, 999999.99 as pricevideo,
                           convert(bit,0) as handvideo, 999999.99 as pricehandvideo
                      INTO #TANDEMUP
                      FROM dbo.TB_TANDEMUP tandemup " + condicion + @"
 
                    UPDATE #TANDEMUP SET pricevideo = 0.00, pricehandvideo = 0.00

                    update tandemup 
                       set tandemup.pricevideo = tuas.price
                      FROM #TANDEMUP tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup AND TUAS.idaditionalservices = 1

                    update tandemup 
                       set tandemup.pricehandvideo = tuas.price
                      FROM #TANDEMUP tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup and TUAS.idaditionalservices = 2


                    UPDATE TU
                       SET TU.video = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                      FROM #TANDEMUP TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices = 1
  
                    UPDATE TU
                       SET TU.handvideo = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                      FROM #TANDEMUP TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices = 2
  
                    SELECT idtandemup, code, sequence, REGISTERTIME, name, lastname, referenced_by, jumptype, release, reserved_date, email, video, handvideo
                      FROM #TANDEMUP tandemup 
                     WHERE release = 1  ";
         dstandemup = conexion.ConsultaUniversal(sql, "", tabla);


         

         Int32 _idinstructor = 0;
         

         //Barremos el dataset de tandemup para preconstruir el manifisto
         for (int i = 0; i < dstandemup.Tables[0].Rows.Count; i++)
         {
             _grupo = Convert.ToString(Convert.ToChar(i + 65));

             //INSERTA EL TANDEMUP
             tabla = "TB_PRE_MANIFIESTO";
             campos = "code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, codegroup";
             valores = "'PRE_MANIFEST', 0, "+misglobales.idJumperTandem+", " + dstandemup.Tables[0].Rows[i].ItemArray[0].ToString() + ", 0, '" + dstandemup.Tables[0].Rows[i].ItemArray[7].ToString() +
                       "', '" + dstandemup.Tables[0].Rows[i].ItemArray[6].ToString() + "', '" + _grupo + "'";
             try
             {
                 conexion.InsertTabla(campos, tabla, valores);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error try add tandemup into pre manifest " + ex.Message);
             }
             // INSERTA EL INSTRUCTOR


             if (Convert.ToBoolean(dstandemup.Tables[0].Rows[i].ItemArray[11].ToString()) == true && Convert.ToBoolean(dstandemup.Tables[0].Rows[i].ItemArray[12].ToString()) == true)
             {
                 //Es un tandem con video, asignar instructor tandem con video de mano y un instructor con video  (handvideo y video)
                 //TANDEM
                 tabla = "tb_instructors_activity";
                 condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                                  AND idjumper not in(select idjumper from TB_PRE_MANIFIESTO)
                                  AND TANDEM = 1 AND HANDVIDEO = 1
                                 ORDER BY convert(int, jumps), registertime ASC  ";
                 sql = @"SELECT TOP 1  id, idjumper, registertime, sequence, name, video, handvideo, tandem, busy, jumps
                           FROM tb_instructors_activity";
                 dsinstructores = conexion.ConsultaUniversal(sql, condicion, tabla);
                 _idinstructor = Convert.ToInt32(dsinstructores.Tables[0].Rows[0].ItemArray[1].ToString());
                 if (dsinstructores.Tables[0].Rows.Count > 0)
                 {
                     //InsertaInstructor(_idinstructor, dstandemup.Tables[0].Rows[i].ItemArray[7].ToString(), dstandemup.Tables[0].Rows[i].ItemArray[6].ToString());
                 }
                 //VIDEO
                 tabla = "tb_instructors_activity";
                 condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                                  AND idjumper not in(select idjumper from TB_PRE_MANIFIESTO)
                                  AND VIDEO = 1
                                 ORDER BY convert(int, jumps), registertime ASC  ";
                 sql = @"SELECT TOP 1  id, idjumper, registertime, sequence, name, video, handvideo, tandem, busy, jumps
                           FROM tb_instructors_activity";
                 dsinstructores = conexion.ConsultaUniversal(sql, condicion, tabla);
                 _idinstructor = Convert.ToInt32(dsinstructores.Tables[0].Rows[0].ItemArray[1].ToString());
                 if (dsinstructores.Tables[0].Rows.Count > 0)
                 {
                     //InsertaInstructor(_idinstructor, dstandemup.Tables[0].Rows[i].ItemArray[7].ToString(), dstandemup.Tables[0].Rows[i].ItemArray[6].ToString());
                 }
             } 
             else if (Convert.ToBoolean(dstandemup.Tables[0].Rows[i].ItemArray[11].ToString()) == true)
             {
                 //Es un tandem con video, asignar instructor tandem y un instructor con video  (video)
                 //TANDEM
                 tabla = "tb_instructors_activity";
                 condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                                  AND idjumper not in(select idjumper from TB_PRE_MANIFIESTO)
                                  AND TANDEM = 1 
                                 ORDER BY convert(int, jumps), registertime ASC  ";
                 sql = @"SELECT TOP 1  id, idjumper, registertime, sequence, name, video, handvideo, tandem, busy, jumps
                           FROM tb_instructors_activity";
                 dsinstructores = conexion.ConsultaUniversal(sql, condicion, tabla);
                 _idinstructor = Convert.ToInt32(dsinstructores.Tables[0].Rows[i].ItemArray[1].ToString());
                 if (dsinstructores.Tables[0].Rows.Count > 0)
                 {
                     //InsertaInstructor(_idinstructor, dstandemup.Tables[0].Rows[i].ItemArray[7].ToString(), dstandemup.Tables[0].Rows[i].ItemArray[6].ToString());
                 }
                 //VIDEO
                 tabla = "tb_instructors_activity";
                 condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                                  AND idjumper not in(select idjumper from TB_PRE_MANIFIESTO)
                                  AND VIDEO = 1
                                 ORDER BY convert(int, jumps), registertime ASC  ";
                 sql = @"SELECT TOP 1  id, idjumper, registertime, sequence, name, video, handvideo, tandem, busy, jumps
                           FROM tb_instructors_activity";
                 dsinstructores = conexion.ConsultaUniversal(sql, condicion, tabla);
                 _idinstructor = Convert.ToInt32(dsinstructores.Tables[0].Rows[0].ItemArray[1].ToString());
                 if (dsinstructores.Tables[0].Rows.Count > 0)
                 {
                     //InsertaInstructor(_idinstructor, dstandemup.Tables[0].Rows[i].ItemArray[7].ToString(), dstandemup.Tables[0].Rows[i].ItemArray[6].ToString());
                 }
             }
             else if (Convert.ToBoolean(dstandemup.Tables[0].Rows[i].ItemArray[12].ToString()) == true)
             {
                 //Es un tandem con video, asignar instructor tandem con video de mano (hand video)
                 //TANDEM
                 tabla = "tb_instructors_activity";
                 condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                                  AND idjumper not in(select idjumper from TB_PRE_MANIFIESTO)
                                  AND TANDEM = 1 AND HANDVIDEO = 1
                                 ORDER BY convert(int, jumps), registertime ASC  ";
                 sql = @"SELECT TOP 1  id, idjumper, registertime, sequence, name, video, handvideo, tandem, busy, jumps
                           FROM tb_instructors_activity";
                 dsinstructores = conexion.ConsultaUniversal(sql, condicion, tabla);
                 _idinstructor = Convert.ToInt32(dsinstructores.Tables[0].Rows[0].ItemArray[1].ToString());
                 if (dsinstructores.Tables[0].Rows.Count > 0)
                 {
                     //InsertaInstructor(_idinstructor, dstandemup.Tables[0].Rows[i].ItemArray[7].ToString(), dstandemup.Tables[0].Rows[i].ItemArray[6].ToString());
                 }

             }
             else if (Convert.ToBoolean(dstandemup.Tables[0].Rows[i].ItemArray[11].ToString()) == true && Convert.ToBoolean(dstandemup.Tables[0].Rows[i].ItemArray[12].ToString()) == true)
             { 
                 //solo se asigna un instructor para tandem
                 //TANDEM
                 tabla = "tb_instructors_activity";
                 condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  
                                  AND idjumper not in(select idjumper from TB_PRE_MANIFIESTO)
                                  AND TANDEM = 1
                                 ORDER BY convert(int, jumps), registertime ASC  ";
                 sql = @"SELECT TOP 1  id, idjumper, registertime, sequence, name, video, handvideo, tandem, busy, jumps
                           FROM tb_instructors_activity";
                 dsinstructores = conexion.ConsultaUniversal(sql, condicion, tabla);
                 _idinstructor = Convert.ToInt32(dsinstructores.Tables[0].Rows[0].ItemArray[1].ToString());
                 if (dsinstructores.Tables[0].Rows.Count > 0)
                 {
                     
                     //InsertaInstructor(_idinstructor, dstandemup.Tables[0].Rows[i].ItemArray[7].ToString(), dstandemup.Tables[0].Rows[i].ItemArray[6].ToString());
                 }
             }

             
         }
        }
        #endregion 

        #region Metodo Load de la forma PreManifest
        private void Frm_PreManifest_Load(object sender, EventArgs e)
        {
            //DataSet dsSTORE = new DataSet();
            //storeprocedure = "SP_PRE_MANIFEST";
            try
            {
                //conexion.EXECSP(storeprocedure);
                //ArmaPreManifiesto();
                InicializaGrid();
                InicializaObjetos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try calculate Pre Manifest" + ex.Message);
            }
        }
        #endregion 

        private void btn_import_Click(object sender, EventArgs e)
        {

        }


        #region Metodo Sugerencia de Instructor
        private void SugerirInstructor()
        { 
        
        }
        #endregion 


        #region Evento click del Grid dg_premanifest
        private void dg_premanifest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grb_edit.Enabled = true;
            txb_sequence.Text = Convert.ToString(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[2].Value);
            lbl_idtandem.Text = Convert.ToString(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[0].Value);
            txb_tandemname.Text = Convert.ToString(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[4].Value);
            txb_jumptype.Text = Convert.ToString(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[6].Value);
            chk_video.Checked = Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[10].Value);
            chk_handvideo.Checked = Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[11].Value);
            chb_videorent.Checked = Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[12].Value);
            txb_weight.Text = Convert.ToString(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[13].Value);
            txb_height.Text = Convert.ToString(  Convert.ToInt32( dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[15].Value)  );

            //Este combo es para el instructor tandem
            cmb_instructor1.Visible = true;
            CargaComboInstructor1();

            if (chk_handvideo.Checked == true) 
            {
                cmb_jumptype1.Text = txb_jumptype.Text + " J/M Video Mano";
            }
            else if (chb_videorent.Checked == true)
            {
                cmb_jumptype1.Text = txb_jumptype.Text+" J/M Video Renta";
            }
            else
            {
                cmb_jumptype1.Text = txb_jumptype.Text + " J/M";
            }
            cmb_jumptype1.Enabled = false;

            if (Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[10].Value) == true)
            {
                cmb_instructor2.Visible = true;
                CargaComboInstructor2();
                lbl_instructor2.Visible = true;
                cmb_jumptype2.Visible = true;
                lbl_jumptype2.Visible = true;
                cmb_jumptype2.Text = "VIDEO J/M";
                cmb_jumptype2.Enabled = false;
            }
            else
            {
                //Solo brincara con un instructor de tandem
                cmb_instructor2.Visible = false;
                lbl_instructor2.Visible = false;
                cmb_jumptype2.Visible = false;
                lbl_jumptype2.Visible = false;
            }

        }
        #endregion 

        #region Metodo Valida si el instructor ya existe en el grupo
        private Boolean ValidaInstructor(Int32 idjumper, String Grupo)
        {

            tabla = "TB_PRE_MANIFIESTO";
            sql = " Select * From dbo.TB_PRE_MANIFIESTO";
            condicion = "  where idjumper = " + idjumper + 
                        "  and code = '"+ Grupo +"'";
            DataSet dsvalida = conexion.ConsultaUniversal(sql, condicion, tabla);

            if (dsvalida.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion 

        #region Evento clik del boton PreManifested
        private void btn_premanifested_Click(object sender, EventArgs e)
        {
            
            int _idinstructor = Convert.ToInt32( cmb_instructor1.SelectedValue.ToString());
            String _grupo = lbl_idtandem.Text;
            String Grupo = "";

            if (ValidaInstructor(_idinstructor, txb_flight.Text) == true)
            {
                MessageBox.Show("WARNING: The Instructor " + cmb_instructor1.Text + " already exist premanifest in the same Group " + txb_flight.Text + " , pre manifest in other group");
                return;
            }

            if (cmb_instructor2.Text != "")
            {
                if (ValidaInstructor(Convert.ToInt32(cmb_instructor2.SelectedValue.ToString()), txb_flight.Text))
                {
                    MessageBox.Show("WARNING: The Instructor " + cmb_instructor2.Text + " already exist premanifest in the same Group " + txb_flight.Text + " , pre manifest in other group");
                    return;
                }
            }


           

                //guarda en el premanifiesto el TANDEMUP

                tabla = "TB_PRE_MANIFIESTO";
                campos = "code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent";
                valores = "'" + txb_flight.Text + "', 0, "+misglobales.idJumperTandem+", " + lbl_idtandem.Text + ", 0, '" + txb_jumptype.Text +
                          "', ''," + Convert.ToByte(chk_video.Checked) + " ," + Convert.ToByte(chk_handvideo.Checked) + " , '" + _grupo + "', " + Convert.ToByte(chb_videorent.Checked);
                try
                {
                    conexion.InsertTabla(campos, tabla, valores);

                    tabla = "TB_TANDEMUP";
                    campos = " manifested = 1";
                    condicion = "  where idtandemup = " + lbl_idtandem.Text;
                    conexion.UpdateTabla(campos, tabla, condicion);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try insert TANDEMUP to PRE MANIFEST " + ex.Message);
                    return;
                }


                //guarda en el premanifiesto el INSTRUCTOR TANDEM

                tabla = "TB_PRE_MANIFIESTO";
                campos = "code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent";

                String ReservedFor = "";
                String ActividadInstructor = "";
                int _videorent = Convert.ToInt32(chb_videorent.Checked);

                if (Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[11].Value) == true)
                {
                    ActividadInstructor = cmb_jumptype1.Text;
                }
                else
                {
                    ActividadInstructor = cmb_jumptype1.Text;
                }

                _grupo = lbl_idtandem.Text;
                try
                {
                    InsertaInstructor(txb_flight.Text, _idinstructor, ActividadInstructor, ReservedFor, _grupo, _videorent);
                    u.ActividadInstructor("jumps_premanifested", 1,  Convert.ToInt32(cmb_instructor1.SelectedValue.ToString()), "+");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try add Instructor to pre manifest" + ex.Message);
                    return;
                }
                //guarda en el premanifiesto el INSTRUCTOR VIDEO

                if (Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[10].Value) == true || cmb_instructor2.Visible ==true ) 
                {
                    try
                    {
                        _grupo = lbl_idtandem.Text;
                        _idinstructor =  Convert.ToInt32(cmb_instructor2.SelectedValue.ToString());
                        ActividadInstructor = cmb_jumptype2.Text;

                        InsertaInstructor(txb_flight.Text, _idinstructor, ActividadInstructor, ReservedFor, _grupo, 0);
                        u.ActividadInstructor("jumps_premanifested", 1, Convert.ToInt32(cmb_instructor2.SelectedValue.ToString()), "+");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error to try add pre-manifest the Instructor for video " + ex.Message);
                        return;
                    }

                }

                Grupo = txb_flight.Text;
                InicializaGrid();
                InicializaObjetos();
                grb_edit.Enabled = false;
                txb_flight.Text = Grupo;
            
        }
        #endregion 

        #region Evento Selection Change Commited del combobox Instructor1
        private void cmb_instructor1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbl_idjumper1.Text = cmb_instructor1.SelectedValue.ToString();
            //cmb_jumptype1.SelectedText  = 
            //cmb_jumptype1.Text = "";

            //tabla = "CT_JUMPER";
            //sql = " select idjumper, idjumptypecode from dbo.CT_JUMPER ";
            //condicion = " where idjumper = " + lbl_idjumper1.Text ;

            //DataSet dsjumperlook = conexion.ConsultaUniversal(sql, condicion, tabla);

            //cmb_jumptype1.SelectedText = dsjumperlook.Tables[0].Rows[0].ItemArray[1].ToString();

            CargaComboInstructor2();

        }
        #endregion


        #region Evento Selection Change Commited del combobox Instructor2
        private void cmb_instructor2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbl_idjumper2.Text = cmb_instructor2.SelectedValue.ToString();
            //cmb_jumptype2.Text = "";
            //tabla = "CT_JUMPER";
            //sql = " select idjumper, idjumptypecode from dbo.CT_JUMPER ";
            //condicion = " where idjumper = " + lbl_idjumper2.Text;

            //DataSet dsjumperlook = conexion.ConsultaUniversal(sql, condicion, tabla);

            //cmb_jumptype2.SelectedText = dsjumperlook.Tables[0].Rows[0].ItemArray[1].ToString();


        }
        #endregion


        #region Evento click en celda del datagridview PreManifestdetail
        private void dg_premanifestdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            grb_edit.Enabled = true;
            tabla = "TB_PRE_MANIFIESTO";
            sql = @"
                SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.code as Flight, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
		                ISNULL(UPPER(CT_JUMPER.NAME),'') + ' ' + ISNULL(UPPER(CT_JUMPER.lastname),'') + ' ( ' +isnull(tb_manifiesto.reservefor,'') + ' )' as JUMPER_NAME,
		                JUMPTYPE.idjumptype, TB_MANIFIESTO.jumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup, TB_MANIFIESTO.video, TB_MANIFIESTO.handvideo
	                FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO
	                INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem     
	                LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.jumptype 
	                WHERE TB_MANIFIESTO.IDJUMPER = "+misglobales.idJumperTandem+" AND TB_MANIFIESTO.codegroup = " + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[9].Value  +
                " AND TB_MANIFIESTO.code = '" + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[1].Value + "'";
            condicion = "";
            DataSet dsedita = conexion.ConsultaUniversal(sql, condicion, tabla);


            lbl_sequence.Visible = false;
            txb_sequence.Visible = false;

            lbl_idtandem.Text = dsedita.Tables [0].Rows[0].ItemArray[7].ToString();
            txb_tandemname.Text = dsedita.Tables [0].Rows[0].ItemArray[4].ToString();
            txb_jumptype.Text = dsedita.Tables [0].Rows[0].ItemArray[6].ToString();
            txb_flight.Text = dsedita.Tables[0].Rows[0].ItemArray[1].ToString();
            chk_video.Checked = Convert.ToBoolean( dsedita.Tables[0].Rows[0].ItemArray[10].ToString());
            chk_handvideo.Checked = Convert.ToBoolean(dsedita.Tables[0].Rows[0].ItemArray[11].ToString());


            tabla = "TB_TANDEMUP";
            campos = " manifested = 0";
            condicion = "  where idtandemup = " + lbl_idtandem.Text;
            conexion.UpdateTabla(campos, tabla, condicion);


            //Este combo es para el instructor tandem
            cmb_instructor1.Visible = true;
            tabla = "TB_PRE_MANIFIESTO";
            sql = @"
                	SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.code, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
		                    ISNULL(UPPER(CT_JUMPER.nombre),'') + ' ' + ISNULL(CT_JUMPER.paterno, '') + ' ' + ISNULL(CT_JUMPER.materno, '') + '(instructor)' as JUMPER_NAME,
		                    JUMPTYPE.idjumptype, TB_MANIFIESTO.jumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup
	                    FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO 
	                    INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
	                    LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.idjumptypecode WHERE TB_MANIFIESTO.IDJUMPER <> "+misglobales.idJumperTandem+@"
	                    AND TB_MANIFIESTO.codegroup = " + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[9].Value+" AND TB_MANIFIESTO.code = '"+dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[1].Value+"'" +
	                   " order by TB_MANIFIESTO.codegroup";
            condicion = "";
            DataSet dseditainst = conexion.ConsultaUniversal(sql, condicion, tabla);
            cmb_instructor1.SelectedValue = dseditainst.Tables[0].Rows[0].ItemArray[3].ToString();
            cmb_jumptype1.SelectedText = dseditainst.Tables[0].Rows[0].ItemArray[6].ToString();
            cmb_jumptype1.Text = dseditainst.Tables[0].Rows[0].ItemArray[6].ToString();
            try
            {
                u.ActividadInstructor("jumps_premanifested", 1, Convert.ToInt32(cmb_instructor1.SelectedValue.ToString()), "-");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error try update Instructor counter, please verify your conectivity and try again (ERROR: " + ex.Message + " )");
            
            }

            if (dseditainst.Tables[0].Rows.Count > 1)
            {
                cmb_instructor2.Visible = true;
                lbl_instructor2.Visible = true;
                cmb_jumptype2.Visible = true;
                lbl_jumptype2.Visible = true;
                cmb_instructor2.SelectedValue = dseditainst.Tables[0].Rows[1].ItemArray[3].ToString();
                cmb_jumptype2.SelectedText = dseditainst.Tables[0].Rows[1].ItemArray[6].ToString();
                cmb_jumptype2.Text = dseditainst.Tables[0].Rows[1].ItemArray[6].ToString();
                try
                {
                    u.ActividadInstructor("jumps_premanifested", 1, Convert.ToInt32(cmb_instructor2.SelectedValue.ToString()), "-");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Error try update Instructor counter, please verify your conectivity and try again (ERROR: " + ex.Message +" )");

                }
            }
            else
            {
                //Solo brincara con un instructor de tandem
                cmb_instructor2.Visible = false;
                lbl_instructor2.Visible = false;
                cmb_jumptype2.Visible = false;
                lbl_jumptype2.Visible = false;
            }

           // btn_save.Visible = true;
          //  btn_premanifested.Visible = false;

            tabla = "TB_PRE_MANIFIESTO";
            condicion = " codegroup = " + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[9].Value + " and code = '" + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[1].Value+"'" ;

            try
            {
                conexion.BorraRegistro(condicion, tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error try update premanifest record, please verify your conectivity and try again (ERROR: " + ex.Message + " )");

            }
            
            InicializaGrid();
            InicializaObjetos();
        }
        #endregion 

        #region Evento Clik en el voton Save
        private void btn_save_Click(object sender, EventArgs e)
        {

            //guarda en el premanifiesto el TANDEMUP
            String _grupo = lbl_idtandem.Text;
            tabla = "TB_PRE_MANIFIESTO";
            campos = "code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent";
            valores = "'" + txb_flight.Text + "', 0, "+misglobales.idJumperTandem+", " + lbl_idtandem.Text + ", 0, '" + txb_jumptype.Text +
                      "', ''," + Convert.ToByte(chk_video.Checked) + " ," + Convert.ToByte(chk_handvideo.Checked) + " ,'" + _grupo + "'," + Convert.ToByte(chb_videorent.Checked);
            try
            {
                conexion.InsertTabla(campos, tabla, valores);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try insert TANDEMUP to PRE MANIFEST " + ex.Message);
                return;
            }


            //guarda en el premanifiesto el INSTRUCTOR TANDEM

            int _idinstructor = Convert.ToInt32(cmb_instructor1.SelectedValue.ToString());
            String ReservedFor = "";
            String ActividadInstructor = "";
            int videorenta = Convert.ToInt32(chb_videorent.Checked);
            if (Convert.ToBoolean(dg_premanifest.Rows[dg_premanifest.CurrentRow.Index].Cells[11].Value) == true)
            {
                ActividadInstructor = cmb_jumptype1.Text;
            }
            else
            {
                ActividadInstructor = cmb_jumptype1.Text;
            }

            _grupo = lbl_idtandem.Text;
            try
            {
                InsertaInstructor(txb_flight.Text, _idinstructor, ActividadInstructor, ReservedFor, _grupo, videorenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to try add Instructor to pre manifest" + ex.Message);
                return;
            }
            //guarda en el premanifiesto el INSTRUCTOR VIDEO

            if (cmb_instructor2.Visible == true)
            {
                try
                {
                    _grupo = lbl_idtandem.Text;
                    _idinstructor = Convert.ToInt32(cmb_instructor2.SelectedValue.ToString());
                    ActividadInstructor = cmb_jumptype2.Text;

                    InsertaInstructor(txb_flight.Text, _idinstructor, ActividadInstructor, ReservedFor, _grupo,0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try add pre-manifest the Instructor for video " + ex.Message);
                    return;
                }

            }


            InicializaGrid();
            InicializaObjetos();
            grb_edit.Enabled = false;



            btn_save.Visible = false;
            btn_premanifested.Visible = true;
        }
        #endregion 

        #region Evento click del boton Clear
        private void btn_clear_Click(object sender, EventArgs e)
        {
            btn_save.Visible = false;
            btn_premanifested.Visible = true;
            InicializaObjetos();
        }
        #endregion 

        private void btn_instructor_Click(object sender, EventArgs e)
        {
            Frm_Instructors_blackboard FrmRegistry = new Frm_Instructors_blackboard();
            FrmRegistry.MdiParent = MDISkyDiveCuautla.ActiveForm;
            FrmRegistry.WindowState = FormWindowState.Maximized;
            FrmRegistry.Show();
        }

        private void cmb_instructor1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Evento click del boton refresh
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dg_premanifest.ScrollBars = ScrollBars.Vertical;

            condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) AND manifested = 0  ORDER BY convert(int,tandemup.SEQUENCE) asc ";
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







    }
}
