using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;


namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_AddPreManifest : Form
    {
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        String valores, condicion, sql, tabla, campos, storeprocedure;
        SqlCommand cmd;
        SqlConnection cnn;
        String Script;


        #region Constructor de la Frm_AddPreManifest
        public Frm_AddPreManifest()
        {
            InitializeComponent();
        }
        #endregion 

        #region Inicializa Grids
        private void InicializaGrid()
        {
            //condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) AND manifested in(1,2, 0 ) ORDER BY idpremanifiesto asc ";
            condicion = "  WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), '" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 23) AND manifested in(1,2, 0 ) ORDER BY idpremanifiesto asc ";
            dg_premanifestdetail.EnableHeadersVisualStyles = false;
            dg_premanifestdetail.DataSource = conexion.ConsultaPreManifiesto(condicion);  //getdata(fuente;
            dg_premanifestdetail.Columns[0].Width = 100; // idpremanifiesto
            dg_premanifestdetail.Columns[0].Visible = false;
            dg_premanifestdetail.Columns[1].Width = 150; // code
            dg_premanifestdetail.Columns[1].Visible = true;
            dg_premanifestdetail.Columns[2].Width = 100; // idvuelo
            dg_premanifestdetail.Columns[2].Visible = false;
            dg_premanifestdetail.Columns[3].Width = 100; // idjumper
            dg_premanifestdetail.Columns[3].Visible = false;
            dg_premanifestdetail.Columns[4].Width = 350; // jumpername
            dg_premanifestdetail.Columns[4].Visible = true;
            dg_premanifestdetail.Columns[5].Width = 100; // idjumptype
            dg_premanifestdetail.Columns[5].Visible = false;
            dg_premanifestdetail.Columns[6].Width = 150; // jumptype
            dg_premanifestdetail.Columns[6].Visible = true;
            dg_premanifestdetail.Columns[7].Width = 150; // idtandem
            dg_premanifestdetail.Columns[7].Visible = false;
            dg_premanifestdetail.Columns[8].Width = 150; // altitud
            dg_premanifestdetail.Columns[8].Visible = true;
            dg_premanifestdetail.Columns[9].Width = 150; // codegroup
            dg_premanifestdetail.Columns[9].Visible = true;

            u.Formatodgv(dg_premanifestdetail);

        }
        #endregion

        #region Load de la Frm_AddPreManifest
        private void Frm_AddPreManifest_Load(object sender, EventArgs e)
        {
            InicializaGrid();
        }
        #endregion 

        #region Valida Excepciones en costo
        public Decimal JumperException(int idjumper, string jump_type_code)
        {

            tabla = "cT_jumper_exceptions";
            sql = "  select id, idjumper, jumper_code, idjumptype, jump_type_code, charge from cT_jumper_exceptions";
            condicion = " where idjumper = " + idjumper + " and jump_type_code = '" + jump_type_code + "'  ";

            try
            {
                DataSet dsexcepcion = conexion.ConsultaUniversal(sql, condicion, tabla);

                if (dsexcepcion.Tables[0].Rows.Count > 0)
                {
                    // si hay excpeción en el precio
                    return Convert.ToDecimal(dsexcepcion.Tables[0].Rows[0].ItemArray[5].ToString());
                }
                else
                {

                    tabla = "cT_jumper_exceptions";
                    sql = "select idjumptype, jump_type, price from CT_JUMP_TYPE ";
                    condicion = " where jump_type = '" + jump_type_code + "'";

                    try
                    {
                        DataSet dspreciolista = conexion.ConsultaUniversal(sql, condicion, tabla);

                        if (dspreciolista.Tables[0].Rows.Count > 0)
                        {
                            return Convert.ToDecimal(dspreciolista.Tables[0].Rows[0].ItemArray[2].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Warning not exist price for this jump type " + jump_type_code.ToString() + " please contact system administrator ");
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error extract price of Jump Type Catalog " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try find exceptcion, contact system administrator  " + ex.Message);
            }



            return 0;
        }
        #endregion 

        #region Evento Cell Double Click del dg_manifiestdetail
        private void dg_premanifestdetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //REVISAR QUE ALGUNOS DE LOS INSTRUCTORES NO ESTE MANIFESTADO YA EN EL MISMO VUELO
            //REVISAR PORQUE LOS TANDEMS LOS METE COMO INSTRUCTORES

            String _IdManifiesto;
            tabla = "TB_LEDGER";
            //sql = " select max(SUBSTRING(code, 1,len(idledger)))+1 as id from TB_LEDGER ";
            sql = "select REPLACE( max(SUBSTRING(code, 1,len(idledger))), '-', '')+1 as id from TB_LEDGER ";
            condicion = "";
            DataSet dsledger = conexion.ConsultaUniversal(sql, condicion, tabla);
            String CodeLedger = dsledger.Tables[0].Rows[0].ItemArray[0].ToString() + "-PREMANFST";

            tabla = "TB_PRE_MANIFIESTO";
            sql = @"
                SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.code as Flight, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
		                'T-' + ISNULL(CT_JUMPER.lastname,'') + ', ' + ISNULL(CT_JUMPER.NAME,'')  as JUMPER_NAME,
		                JUMPTYPE.idjumptype, TB_MANIFIESTO.jumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup
	                FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO
	                INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem     
	                LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.jumptype 
	                WHERE TB_MANIFIESTO.IDJUMPER = " + misglobales.idJumperTandem+@" AND TB_MANIFIESTO.codegroup = " + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[9].Value +
                " AND TB_MANIFIESTO.code = '" + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[1].Value + "'";
            condicion = "";
            DataSet dsedita = conexion.ConsultaUniversal(sql, condicion, tabla);

            DataSet dspuedebrincar = conexion.ConsultaUniversal(" select IDTANDEMUP, release, sequence, manifested, idusuario from TB_TANDEMUP ", "WHERE idtandemup = " + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[9].Value, "TB_TANDEMUP");
            if (dspuedebrincar.Tables[0].Rows[0].ItemArray[1].ToString() == "1")
            {


                tabla = "TB_TANDEMUP";
                campos = " jump_flag = 1, manifested = 2 ";
                condicion = " WHERE idtandemup = " + dsedita.Tables[0].Rows[0].ItemArray[7].ToString();
                try
                {
                    conexion.UpdateTabla(campos, tabla, condicion);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try on flag jump for this tandemup, please contact system administrator " + ex.Message);
                    return;

                }
                //INSERTAMOS EL TANDEMUP
                try
                {

                    sql = " select max(idledger)+1 from tb_ledger";
                    condicion = "";
                    tabla = "tb_ledger";
                    DataSet dsidledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                    Int32 _IdLedger = Convert.ToInt32(dsidledger.Tables[0].Rows[0].ItemArray[0].ToString());

                    tabla = "tb_manifiesto";
                    campos = "idvuelo, code, idjumper, idtandem, idleadger, idjumptype, reservefor";
                    string valores = misglobales.id1 + misglobales._codetandemup + misglobales.idJumperTandem + ", " + dsedita.Tables[0].Rows[0].ItemArray[7].ToString() + " ," + _IdLedger + ", " + dsedita.Tables[0].Rows[0].ItemArray[5].ToString() + ", ''";  //dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[5].Value  + ", ''";
                    conexion.InsertTabla(campos, tabla, valores);


                    sql = "	SELECT max(idmanifiesto) as idmanifiesto FROM dbo.TB_MANIFIESTO ";
                    condicion = "";
                    tabla = "TB_MANIFIESTO";
                    DataSet dsidmanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);
                    _IdManifiesto = dsidmanifiesto.Tables[0].Rows[0].ItemArray[0].ToString();
                    

                    //ANTES DE BORRARLO LO PONGO A DISPOSICION DE LOS DIPLOMAS
                    Script = @" INSERT INTO bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE (idmanifiesto, code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup) 
                            SELECT " + _IdManifiesto + ", code, " + misglobales.id1 + @", idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup 
                              FROM bd_skydivecuautla.dbo.TB_PRE_MANIFIESTO
                             WHERE CODEGROUP = " + dsedita.Tables[0].Rows[0].ItemArray[9].ToString() + " AND idtandem = " + dsedita.Tables[0].Rows[0].ItemArray[7].ToString();
                    ExecScript(Script);




                   
                    // Aplicar al ledger
                    //sql = @" SELECT convert(varchar(6),max(SUBSTRING(code, 1,len(idledger)))+1) + '-MANFST' as code FROM dbo.TB_LEDGER ";
                    sql = @"SELECT convert(varchar(6),REPLACE( max(SUBSTRING(code, 1,len(idledger))), '-', '')+1) + '-MANFST' as code FROM dbo.TB_LEDGER";
                    condicion = "";
                    tabla = "TB_LEDGER";
                    DataSet dscodeledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                    String _Code = dscodeledger.Tables[0].Rows[0].ItemArray[0].ToString();

                    tabla = "TB_MANIFIESTO";
                    sql = "select idmanifiesto from DBO.TB_MANIFIESTO ";
                    Int32 Longitud = misglobales._codetandemup.Length - 4;
                    String _CodeTandemUp = misglobales._codetandemup.Substring(2, Longitud);
                    condicion = " where idvuelo = " + misglobales.id1 + " and code = '" + _CodeTandemUp + "'";
                    DataSet dsmanifiestoid = conexion.ConsultaUniversal(sql, condicion, tabla);

                    tabla = "TB_TANDEMUP";
                    sql = "SELECT idtandemup, code, jumptype, pricejump, charge, paymant, idusuario FROM dbo.TB_TANDEMUP ";
                    condicion = "WHERE IDTANDEMUP = " + dsedita.Tables[0].Rows[0].ItemArray[7].ToString(); // +" AND CONVERT(varchar(10),registertime, 23) = CONVERT(varchar(10),GETDATE(), 23)";
                    DataSet dscostos = conexion.ConsultaUniversal(sql, condicion, tabla);
                    Decimal _charge = Convert.ToDecimal(dscostos.Tables[0].Rows[0].ItemArray[4].ToString());
                    String _Code_Tandem = Convert.ToString(dscostos.Tables[0].Rows[0].ItemArray[1].ToString());
                    String _CodeJumpType = Convert.ToString(dscostos.Tables[0].Rows[0].ItemArray[2].ToString());   //Convert.ToString(dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[6].Value);
                    Decimal _Payment = Convert.ToDecimal(dscostos.Tables[0].Rows[0].ItemArray[5].ToString());
                     _IdManifiesto = dsmanifiestoid.Tables[0].Rows[0].ItemArray[0].ToString();

                    sql = "select idjumptype, jump_type, charge_type_description from ct_jump_type ";
                    condicion = " where jump_type = '" + _CodeJumpType + "'";
                    tabla = "ct_jump_type";

                    DataSet dsjumptypecode = conexion.ConsultaUniversal(sql, condicion, tabla);

                    String _codechargetype = dsjumptypecode.Tables[0].Rows[0].ItemArray[2].ToString();

                    u.AplicaLedger(_Code, "9999-Tandem", misglobales._Updatedate, _codechargetype, _charge, _CodeJumpType, 0, "", _Payment, 0, "", misglobales.id1.ToString(), 0, "", dsedita.Tables[0].Rows[0].ItemArray[4].ToString(), 0, 0, 0, 0, _Code_Tandem.ToString(), 0, 0, misglobales.oficina_id_oficina, "", Convert.ToInt32( dscostos.Tables[0].Rows[0].ItemArray[6]));
                    //Convert.ToString(dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[4].Value)
                    misglobales.jumper_code = "9999-Tandem";
                    u.Balance();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try add into manifest, contact system administrator" + ex.Message);
                    return;
                }

                //INSERTAR EL INSTRUCTOR TANDEM
                tabla = "TB_PRE_MANIFIESTO";
                sql = @"
                	SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.code, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
		                    ISNULL(CT_JUMPER.nombre,'')as JUMPER_NAME,
		                     JUMPTYPE.idjumptype, TB_MANIFIESTO.jumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup, CT_JUMPER.CODIGO, JUMPTYPE.jump_type, charge_type_description
	                    FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO 
	                    INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
	                    LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = TB_MANIFIESTO.jumptypecode WHERE TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem+@"
	                    AND TB_MANIFIESTO.codegroup = " + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[9].Value + " AND TB_MANIFIESTO.code = '" + dg_premanifestdetail.Rows[dg_premanifestdetail.CurrentRow.Index].Cells[1].Value + "'" +
                           " order by TB_MANIFIESTO.codegroup";
                condicion = "";
                DataSet dseditainst = conexion.ConsultaUniversal(sql, condicion, tabla);

                Decimal preciosalto = JumperException(Convert.ToInt32(dseditainst.Tables[0].Rows[0].ItemArray[3].ToString()), dseditainst.Tables[0].Rows[0].ItemArray[11].ToString());

                try
                {

                    sql = " select max(idledger)+1 from tb_ledger";
                    condicion = "";
                    tabla = "tb_ledger";
                    DataSet dsidledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                    Int32 _IdLedger = Convert.ToInt32(dsidledger.Tables[0].Rows[0].ItemArray[0].ToString());


                    tabla = "tb_manifiesto";
                    campos = "idvuelo, code, idjumper, idtandem, idleadger, idjumptype, reservefor";
                    string valores = misglobales.id1 + misglobales._codetandemup + dseditainst.Tables[0].Rows[0].ItemArray[3].ToString() + ", 0, " + _IdLedger + ", " + dseditainst.Tables[0].Rows[0].ItemArray[5].ToString() + ", '' " ;
                    conexion.InsertTabla(campos, tabla, valores);

                                        u.ActividadInstructor("jumps_manifested", 1, Convert.ToInt32(dseditainst.Tables[0].Rows[0].ItemArray[3].ToString()), "+");
                    u.ActividadInstructor("jumps_premanifested", 1, Convert.ToInt32(dseditainst.Tables[0].Rows[0].ItemArray[3].ToString()), "-");
                    misglobales.jumper_code = dseditainst.Tables[0].Rows[0].ItemArray[10].ToString();

                    sql = "	SELECT max(idmanifiesto) as idmanifiesto FROM dbo.TB_MANIFIESTO ";
                    condicion = "";
                    tabla = "TB_MANIFIESTO";
                    DataSet dsidmanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);


                    u.AplicaLedger(CodeLedger, dseditainst.Tables[0].Rows[0].ItemArray[10].ToString(), misglobales._Updatedate,  dseditainst.Tables[0].Rows[0].ItemArray[12].ToString(), preciosalto, dseditainst.Tables[0].Rows[0].ItemArray[11].ToString(), 0, "", 0, 0, "", misglobales.id1.ToString() , 0, "", dseditainst.Tables[0].Rows[0].ItemArray[4].ToString(), 0, 0, 0, 0, "", 0, 0, misglobales.oficina_id_oficina, "", misglobales.usuario_idusuario);


                    sql = "	SELECT max(idmanifiesto) as idmanifiesto FROM dbo.TB_MANIFIESTO ";
                    condicion = "";
                    tabla = "TB_MANIFIESTO";
                    dsidmanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);
                    _IdManifiesto = dsidmanifiesto.Tables[0].Rows[0].ItemArray[0].ToString();


                    //ANTES DE BORRARLO LO PONGO A DISPOSICION DE LOS DIPLOMAS
                    Script = @" INSERT INTO bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE (idmanifiesto, code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent) 
                            SELECT " + _IdManifiesto + ", code, " + misglobales.id1 + @", idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent
                              FROM bd_skydivecuautla.dbo.TB_PRE_MANIFIESTO
                             WHERE CODEGROUP = " + dsedita.Tables[0].Rows[0].ItemArray[9].ToString() + " AND idjumper = " + dseditainst.Tables[0].Rows[0].ItemArray[3].ToString();
                    ExecScript(Script);





                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try add into manifest, contact system administrator" + ex.Message);
                    return;
                }


                //INSERTAR EL INSTRUCTOR VIDEO
                if (dseditainst.Tables[0].Rows.Count == 2)
                {

                    try
                    {
                        sql = " select max(idledger)+1 from tb_ledger";
                        condicion = "";
                        tabla = "tb_ledger";
                        DataSet dsidledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                        Int32 _IdLedger = Convert.ToInt32(dsidledger.Tables[0].Rows[0].ItemArray[0].ToString());

                        tabla = "tb_manifiesto";
                        campos = "idvuelo, code, idjumper, idtandem, idleadger, idjumptype, reservefor";
                        string valores = misglobales.id1 + misglobales._codetandemup + dseditainst.Tables[0].Rows[1].ItemArray[3].ToString() + ", 0, " + _IdLedger + ", " + dseditainst.Tables[0].Rows[1].ItemArray[5].ToString() + ", ''";
                        conexion.InsertTabla(campos, tabla, valores);
                        misglobales.jumper_code = dseditainst.Tables[0].Rows[1].ItemArray[10].ToString();
                        u.ActividadInstructor("jumps_manifested", 1, Convert.ToInt32(dseditainst.Tables[0].Rows[1].ItemArray[3].ToString()), "+");
                        u.ActividadInstructor("jumps_premanifested", 1, Convert.ToInt32(dseditainst.Tables[0].Rows[1].ItemArray[3].ToString()), "-");
                        preciosalto = JumperException(Convert.ToInt32(dseditainst.Tables[0].Rows[1].ItemArray[3].ToString()), dseditainst.Tables[0].Rows[1].ItemArray[11].ToString());

                        sql = "	SELECT max(idmanifiesto) as idmanifiesto FROM dbo.TB_MANIFIESTO ";
                        condicion = "";
                        tabla = "TB_MANIFIESTO";
                        DataSet dsidmanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);
                        _IdManifiesto = dsidmanifiesto.Tables[0].Rows[0].ItemArray[0].ToString();

                        u.AplicaLedger(CodeLedger, dseditainst.Tables[0].Rows[1].ItemArray[10].ToString(), misglobales._Updatedate, dseditainst.Tables[0].Rows[1].ItemArray[12].ToString(), preciosalto, dseditainst.Tables[0].Rows[1].ItemArray[11].ToString(), 0, "", 0, 0, "", misglobales.id1.ToString(), 0, "", dseditainst.Tables[0].Rows[1].ItemArray[4].ToString(), 0, 0, 0, 0, "", 0, 0, misglobales.oficina_id_oficina, "", misglobales.usuario_idusuario);


                        //ANTES DE BORRARLO LO PONGO A DISPOSICION DE LOS DIPLOMAS
                        Script = @" INSERT INTO bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE (idmanifiesto, code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent) 
                            SELECT " + _IdManifiesto + ", code, " + misglobales.id1 + @", idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup, videorent
                              FROM bd_skydivecuautla.dbo.TB_PRE_MANIFIESTO
                             WHERE CODEGROUP = " + dsedita.Tables[0].Rows[0].ItemArray[9].ToString() + " AND idjumper = " + dseditainst.Tables[0].Rows[1].ItemArray[3].ToString();
                        ExecScript(Script);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error try add into manifest, contact system administrator" + ex.Message);
                        return;
                    }

                }

//                //ANTES DE BORRARLO LO PONGO A DISPOSICION DE LOS DIPLOMAS
//                Script = @" INSERT INTO bd_skydivecuautla.dbo.TB_MANIFIESTO_CERTIFICATE (idmanifiesto, code, idvuelo, idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup) 
//                            SELECT " + _IdManifiesto + ", code, " + misglobales.id1 + @", idjumper, idtandem, idleadger, jumptypecode, reservefor, video, handvideo, codegroup 
//                              FROM bd_skydivecuautla.dbo.TB_PRE_MANIFIESTO
//                             WHERE CODEGROUP = " + dsedita.Tables[0].Rows[0].ItemArray[9].ToString();
//                ExecScript(Script);


                tabla = "TB_PRE_MANIFIESTO";
                condicion = " codegroup = " + dsedita.Tables[0].Rows[0].ItemArray[9].ToString() + " and code = '" + dsedita.Tables[0].Rows[0].ItemArray[1].ToString() + "'";

                conexion.BorraRegistro(condicion, tabla);

                InicializaGrid();
                misglobales.AgregandoPreManifiesto = 0;
                this.Close();

            }
            else
            {
                MessageBox.Show("has not been released, please send the passenger to make the payment inmediatly!!!!");
            }
        }
        #endregion


        #region Ejecuta script
        public void ExecScript(string script)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQLmaster);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" " + script;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();
        }
        #endregion 


        #region Evento click del btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 



    }
}
