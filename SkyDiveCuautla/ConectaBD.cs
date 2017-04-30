using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

//Desarrollado por Carlos Cruz


namespace SkyDiveCuautla
{
    #region Clase ConectaBD
    class ConectaBD
    {



        #region Miembros de la clase
        SqlCommand cmd;
        SqlConnection cnn;
        private int id_menu;
        private int id_menupadre;
        private string descripcionmenu;
        private int posicionmenu;
        private int habilitadomenu;
        private string urlmenu;
        private int formularioasociado;
        private int id_perfil;
        private string condicionadicional;
        private DataTable dtpermisos;
        #endregion

        #region "Condiciones para los miembros de la clase"
        private bool bid_menu;
        private bool bid_menupadre;
        private bool bdescripcionmenu;
        private bool bposicionmenu;
        private bool bhabilitadomenu;
        private bool burlmenu;
        private bool bformularioasociado;
        private bool bid_perfil;
        #endregion

        #region "Propiedades de la clase"

        /// <summary>
        /// Propiedad para el campo Id_Menu
        /// </summary>
        public int Id_Menu
        {
            get
            {
                return id_menu;
            }
            set
            {
                id_menu = value;
                bid_menu = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo Id_MenuPadre
        /// </summary>
        public int Id_MenuPadre
        {
            get
            {
                return id_menupadre;
            }
            set
            {
                id_menupadre = value;
                bid_menupadre = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo DescripcionMenu
        /// </summary>
        public string DescripcionMenu
        {
            get
            {
                return descripcionmenu;
            }
            set
            {
                descripcionmenu = value;
                bdescripcionmenu = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo PosicionMenu
        /// </summary>
        public int PosicionMenu
        {
            get
            {
                return posicionmenu;
            }
            set
            {
                posicionmenu = value;
                bposicionmenu = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo HabilitadoMenu
        /// </summary>
        public int HabilitadoMenu
        {
            get
            {
                return habilitadomenu;
            }
            set
            {
                habilitadomenu = value;
                bhabilitadomenu = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo UrlMenu
        /// </summary>
        public string UrlMenu
        {
            get
            {
                return urlmenu;
            }
            set
            {
                urlmenu = value;
                burlmenu = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo FormularioAsociado
        /// </summary>
        public int FormularioAsociado
        {
            get
            {
                return formularioasociado;
            }
            set
            {
                formularioasociado = value;
                bformularioasociado = true;
            }
        }

        /// <summary>
        /// Propiedad para el campo id_Perfil
        /// </summary>
        public int Id_Perfil
        {
            get
            {
                return id_perfil;
            }
            set
            {
                id_perfil = value;
                bid_perfil = true;
            }
        }

        /// <summary>
        /// Propiedad para estalecer condicion adicional de busqueda
        /// </summary>
        public string CondicionAdicional
        {
            get
            {
                return condicionadicional;
            }
            set
            {
                condicionadicional = value;
            }
        }

        #endregion

        #region Constructor
        public ConectaBD()
        {
            try
            {
                String CadenaConexion = misglobales.cadenaconexionSQL; //"data source=hectorh; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False;";

                cmd = new SqlCommand();
                cnn = new SqlConnection(CadenaConexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region validacredenciales
        public bool ValidarCredenciales(string nombreUsuario, string password)
        {
            String comando = "SELECT USUARIO.IDUSUARIO, USUARIO.USUARIO, USUARIO.CONTRASEÑA, USUARIO.NOMBRE, USUARIO.PATERNO, USUARIO.MATERNO, " +
                " USUARIO.EMAIL, PERFIL.IDPERFIL,  PERFIL.DESCRIPCION AS PERFIL, OFICINA.IDOFICINA, OFICINA.NOMBRE AS OFICINA, " +
                " ESTATUS.IDESTATUS, ESTATUS.DESCRIPCION AS ESTATUS, ENTIDAD.IDENTIDAD, ENTIDAD.DESCRIPCION AS ENTIDAD, USUARIO.autenticacion AS AUTENTICACION, impresora_height " +
                " FROM dbo.CT_USUARIO USUARIO " +
                " INNER JOIN dbo.CT_PERFIL PERFIL ON PERFIL.IDPERFIL = USUARIO.IDPERFIL " +
                " INNER JOIN dbo.CT_OFICINA OFICINA ON OFICINA.IDOFICINA = USUARIO.IDOFICINA " +
                " INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.IDESTATUS = USUARIO.IDESTATUS " +
                " INNER JOIN dbo.CT_ENTIDAD ENTIDAD ON ENTIDAD.IDENTIDAD = OFICINA.IDENTIDAD " +
                " WHERE USUARIO.USUARIO = '" + nombreUsuario + "'";
                
              try 
              {
              
                SqlCommand sqlcmd = new SqlCommand(comando, cnn);
                sqlcmd.Connection.Open();
                SqlDataReader rdr = sqlcmd.ExecuteReader();
                rdr.Read();
                misglobales.usuario_idusuario = (int)rdr["IDUSUARIO"];
                misglobales.usuario_usuario = (string)rdr["USUARIO"];
                misglobales.contraseña = (byte[])rdr["CONTRASEÑA"];
                misglobales.usuario_nombre = (string)rdr["NOMBRE"];
                misglobales.usuario_paterno = (string)rdr["PATERNO"];
                misglobales.usuario_materno = (string)rdr["MATERNO"];
                misglobales.usuario_email = (string)rdr["EMAIL"];
                misglobales.perfil_idperfil = (int)rdr["IDPERFIL"];
                misglobales.perfil_perfil = (string)rdr["PERFIL"];
                misglobales.oficina_id_oficina = (int)rdr["IDOFICINA"];
                misglobales.oficina_oficina = (string)rdr["OFICINA"];
                misglobales.estatus_idestatus = (int)rdr["IDESTATUS"];
                misglobales.estatus_estatus = (string)rdr["ESTATUS"];
                misglobales.entidad_identidad = (int)rdr["IDENTIDAD"];
                misglobales.entidad_entidad = (string)rdr["ENTIDAD"];
                misglobales.usuario_autenticacion = (string)rdr["AUTENTICACION"];
                misglobales._impresora_height = (int)rdr["impresora_height"];

                if (misglobales.usuario_autenticacion == "online")
                {
                    //misglobales.cadenaconexionSQL = "data source=hectorh; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False;";  //Al server SQL
                    misglobales.cadenaconexionSQL = "data source=" + misglobales.servername + "; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False;";
                    
                }
                else if (misglobales.usuario_autenticacion == "offline")
                {
                    //misglobales.cadenaconexionSQL = "data source=hectorh; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False;";  //Al server local del equipo
                    misglobales.cadenaconexionSQL = "data source=" + misglobales.servername + "; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False;";
                }
                rdr.Close();
                sqlcmd.Connection.Close();

                comando = "select pwdcompare ('" + password + "',(SELECT  USUARIO.CONTRASEÑA" +
                                                                  " FROM dbo.CT_USUARIO USUARIO " +
                                                                  " INNER JOIN dbo.CT_PERFIL PERFIL ON PERFIL.IDPERFIL = USUARIO.IDPERFIL " +
                                                                  " INNER JOIN dbo.CT_OFICINA OFICINA ON OFICINA.IDOFICINA = USUARIO.IDOFICINA " +
                                                                  " INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.IDESTATUS = USUARIO.IDESTATUS " +
                                                                  " INNER JOIN dbo.CT_ENTIDAD ENTIDAD ON ENTIDAD.IDENTIDAD = OFICINA.IDENTIDAD " +
                                                                  " WHERE USUARIO.USUARIO = '" + misglobales.usuario_usuario + "')) AS LLAVE";
                sqlcmd = new SqlCommand(comando, cnn);
                sqlcmd.Connection.Open();
                SqlDataReader rdrautoriza = sqlcmd.ExecuteReader();
                rdrautoriza.Read();
                int valida = 0;
                valida = (int)rdrautoriza["LLAVE"];
                sqlcmd.Connection.Close();
                if (valida == 1)  
                {
                    return true;
                }
                else
                  {
                      return false;
                  }
              }
            catch (Exception ex)
              {

                return false;              
            }
        }
        #endregion

        #region MenusWindowsDelPerfil
        public DataTable MenusWindowsDelPerfil(Int32 id_Perfil)
        {
            HabilitadoMenu = 1;
            Id_Perfil = id_Perfil;
            DescripcionMenu = "";
            UrlMenu = "";
            CondicionAdicional = "";
            return BuscarPerfilesPermisos();
        }
        #endregion

        #region BuscarPerfilesPermisos para el menu de opciones
        public DataTable BuscarPerfilesPermisos()
        {
            DataTable dt = new DataTable();
            //Construyendo la condición
            string condicion = "";
            if (id_menu > 0) condicion += " AND T1.Id_Menu =" + id_menu;
            if (id_menupadre > 0) condicion += " AND T1.Id_MenuPadre =" + id_menupadre;
            if (descripcionmenu.Length > 0) condicion += " AND T1.DescripcionMenu Like '%" + descripcionmenu + "%'";
            if (posicionmenu > 0) condicion += " AND T1.PosicionMenu =" + posicionmenu;
            if (habilitadomenu > 0) condicion += " AND permiso.[enabled] = " + habilitadomenu;
            if (urlmenu.Length > 0) condicion += " AND T1.UrlMenu Like '%" + urlmenu + "%'";
            if (formularioasociado > 0) condicion += " AND T1.FormularioAsociado =" + formularioasociado;
            if (id_perfil > 0) condicion += " AND permiso.idperfil =" + misglobales.perfil_idperfil;
            if (condicionadicional.Length > 0) condicion += " AND " + condicionadicional;
            if (condicion != "") condicion = " WHERE menu.idestatus = 1 AND " + condicion.Substring(5);
            string sql = @"SELECT menu.idobjeto, menu.idobjetopadre, menu.descripcion, menu.url, permiso.[enabled], permiso.[locked], 
                                  permiso.[visible]
					         FROM dbo.ct_menu menu
                            INNER JOIN dbo.ct_objeto objeto ON menu.idobjeto = objeto.idobjeto
                            INNER JOIN dbo.ct_permiso permiso ON permiso.idobjeto = menu.idobjeto and  objeto.idobjeto = permiso.idobjeto " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }//buscar
        #endregion

        #region RegistroLog
        public bool RegistroLog(Int32 idUsuario, string url, string Descripcion )
        {

            String comando = @"Insert into  dbo.TB_LOG (idusuario, fechamovimiento, url, descripcion) 
                             values(" + idUsuario + ", getdate(), '" + url + "', '" + Descripcion + "')";

                try
                {

                    SqlCommand sqlcmd = new SqlCommand(comando, cnn);
                    sqlcmd.Connection.Open();
                    int rdr = sqlcmd.ExecuteNonQuery();
                    sqlcmd.Connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

        }

        #endregion

        #region BuscaPermisos por objeto
        public DataTable BuscarPermisosPerfil(Int32 varidperfil)
        {
            DataTable dt = new DataTable();
            //Construyendo la condición
            string sql = @"SELECT PERMISO.IDPERMISO, PERMISO.IDPERFIL, PERFIL.descripcion, OBJETO.IDOBJETO, OBJETO.nombre AS OBJETO, PERMISO.[ENABLED], PERMISO.[LOCKED], PERMISO.[VISIBLE]
                             FROM dbo.CT_OBJETO OBJETO 
                             LEFT OUTER JOIN dbo.CT_PERMISO PERMISO ON OBJETO.idobjeto = PERMISO.idobjeto
                             LEFT JOIN dbo.CT_PERFIL PERFIL ON PERFIL.idperfil = PERMISO.idperfil WHERE perfil.idperfil =" + varidperfil;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        #endregion

        #region propiedades del objeto
        public bool habilitado(string Objetohabilitado)
        {
            ConectaBD OpcionesMenu = new ConectaBD();
            dtpermisos = new DataTable();
            dtpermisos = OpcionesMenu.BuscarPermisosPerfil(misglobales.perfil_idperfil);
            String _cadena = "OBJETO= '" + misglobales._Objeto + "' AND [enabled]=1";

            if (dtpermisos.Select(_cadena).Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion 

        #region Consulta Roles
        public DataSet ConsultaRol(string condicion)
        {
            DataSet ds = new DataSet();
            string sql = @"Select idperfil as ID, descripcion AS ROL From dbo.CT_PERFIL WITH(NOLOCK) " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds, "CT_PERFIL");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consulta catalogo Status
        public DataSet ConsultaStatus(string condicion)
        {
            DataSet ds = new DataSet();
            string sql = @"Select IDESTATUS AS ID, descripcion AS STATUS  From dbo.CT_ESTATUS WITH(NOLOCK)" + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds, "CT_ESTATUS");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consulta catalogo Oficina
        public DataSet ConsultaOficina(string condicion)
        {
            DataSet ds = new DataSet();
            string sql = @"Select IDOFICINA AS ID, Nombre as OFICINA From dbo.CT_OFICINA WITH(NOLOCK) " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds, "CT_OFICINA");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consulta catalogo de categoría presupuestal
        public DataSet Consultabudget(string condicion)
        {
            DataSet ds = new DataSet();
            string sql = @"Select idbudget, [description] as descripcion From dbo.ct_budget WITH(NOLOCK) order by idbudget " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds, "ct_budget");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consulta catalogo Jumper Preferences
        public DataSet ConsultaPreferencias(string condicion)
        {
            DataSet ds = new DataSet();
            string sql = @"Select idpreferences, codigo, long_description From dbo.CT_PREFERENCES WITH(NOLOCK) " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds, "CT_PREFERENCES");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Cinsulta Universal DataTable
        public DataTable ConsultaUniversalDT(string sql, string condicion, string tabla)
        {
            DataTable dt = new DataTable();
            sql += condicion;   
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                misglobales.contador = dt.Rows.Count;
               
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        #endregion 

        #region Consulta universal
        public DataSet ConsultaUniversal(string sql, string condicion, string tabla)
        {
            DataSet ds = new DataSet();
            //string sql = @"Select IDOFICINA AS ID, Nombre as OFICINA From dbo.CT_OFICINA WITH(NOLOCK) " + condicion;
            sql += condicion;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds, tabla);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Cerrar conexion
        public void CloseDB()
        {
            cnn.Close();
        }
        #endregion 

        #region Consulta Jumper Leder Detail
        public DataTable ConsultaLederDetail(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CODE, UPDATEDATE, idchargetype, charge, payment, staff_payment, transfer_amt, TRAnSFER_JUMPER_NAME, nota, idmanifestold, idmanifiesto 
                             FROM dbo.TB_LEDGER " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

         

        }
        #endregion 

        #region Consulta Ledger
        public DataTable ShowLedger(string sql, string condicion)
        {
            DataTable dt = new DataTable();
            string query = sql + " " + condicion;
            //+
            //@" UNION ALL 
            //SELECT null, 'TOTALES', SUM(TBL.charge), SUM(TBL.payment), SUM(TBL.staff_payment) , SUM(tbl.transfer_amt), '', ''
            //FROM dbo.TB_LEDGER TBL " + condicion +
            //" order by TBL.updatedate desc";
            //            string sql = @"SELECT TBL.updatedate AS [Date], CTCT.charge_type as [Charge Type], TBL.charge AS [Charge], TBL.payment as [Payment], TBL.staff_payment as [Staff Pay], 
            //                                  TBL.transfer_jumper_name AS [Transfer Jumper], TBL.nota as [Note]
            //                             FROM dbo.TB_LEDGER TBL LEFT OUTER JOIN dbo.CT_CHARGE_TYPE CTCT ON CTCT.codigo = TBL.idchargetype " + condicion +
            //              @" UNION ALL 
            //                            SELECT null, 'TOTALES', SUM(TBL.charge), SUM(TBL.payment), SUM(TBL.staff_payment) ,  '', ''
            //                              FROM dbo.TB_LEDGER TBL " + condicion +
            //                " order by TBL.updatedate desc";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Ledger
        public DataTable ConsultaLedger(string condicion)
        { 
            DataTable dt = new DataTable();
            string sql = @"SELECT TBL.updatedate AS [Date], CTCT.charge_type as [Charge Type], TBL.charge AS [Charge], TBL.payment as [Payment], TBL.staff_payment as [Staff Pay], 
                                  tbl.transfer_amt as [Transfer], TBL.transfer_jumper_name AS [Transfer Jumper], TBL.nota as [Note]
                             FROM dbo.TB_LEDGER TBL LEFT OUTER JOIN dbo.CT_CHARGE_TYPE CTCT ON CTCT.codigo = TBL.idchargetype " + condicion;
                                                                                                                                //+
                          //@" UNION ALL 
                            //SELECT null, 'TOTALES', SUM(TBL.charge), SUM(TBL.payment), SUM(TBL.staff_payment) , SUM(tbl.transfer_amt), '', ''
                              //FROM dbo.TB_LEDGER TBL " + condicion +
                            //" order by TBL.updatedate desc";
//            string sql = @"SELECT TBL.updatedate AS [Date], CTCT.charge_type as [Charge Type], TBL.charge AS [Charge], TBL.payment as [Payment], TBL.staff_payment as [Staff Pay], 
//                                  TBL.transfer_jumper_name AS [Transfer Jumper], TBL.nota as [Note]
//                             FROM dbo.TB_LEDGER TBL LEFT OUTER JOIN dbo.CT_CHARGE_TYPE CTCT ON CTCT.codigo = TBL.idchargetype " + condicion +
//              @" UNION ALL 
//                            SELECT null, 'TOTALES', SUM(TBL.charge), SUM(TBL.payment), SUM(TBL.staff_payment) ,  '', ''
//                              FROM dbo.TB_LEDGER TBL " + condicion +
//                " order by TBL.updatedate desc";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta TandemUp to Manifest
        public DataTable ConsultaTandemUpManifest(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @" SELECT tandemup.idtandemup,  tandemup.SEQUENCE, tandemup.NAME, tandemup.LASTNAME, tandemup.JUMPTYPE, tandemup.RESERVED_DATE, tandemup.manifested
                              FROM dbo.TB_TANDEMUP tandemup 
                            " + condicion;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta TandemUP Displat List
        public DataTable ConsultaTandemDisplay(string condicion)
        {
            DataTable dt = new DataTable();
//            string sql = @"  SELECT tandemup.idtandemup,  tandemup.SEQUENCE, tandemup.REGISTERTIME, tandemup.NAME, tandemup.LASTNAME,  tandemup.CHARGE,     tandemup.PAYMaNT,     tandemup.RESERVED_DATE,
//                                    tandemup.JUMPTYPE,  tandemup.EMAIL,   tandemup.REFERENCED_BY, Convert(bit,tandemup.RELEASE) as release,    convert(bit,tandemup.JUMP_FLAG) as [JUMP FLAG],
//                                    tandemup.manifested
//                              FROM  dbo.TB_TANDEMUP tandemup" + condicion;


            string sql = @" SELECT tandemup.idtandemup, tandemup.SEQUENCE, tandemup.REGISTERTIME, tandemup.NAME, tandemup.LASTNAME, tandemup.CHARGE, tandemup.PAYMaNT AS PAYMENT, CONVERT(VARCHAR(10), tandemup.RESERVED_DATE, 23) AS [RESERVED DATE],
                                   tandemup.JUMPTYPE, tandemup.EMAIL, tandemup.REFERENCED_BY, Convert(bit,tandemup.RELEASE) as release, convert(bit,tandemup.JUMP_FLAG) as [JUMP FLAG],
                                   case when tandemup.manifested = 2 then convert(bit, 1) else convert(bit, 0) end
                                   , tbv.numerovuelo as [Numero Vuelo], convert(varchar(10), tbv.fechaabrevuelo,23)  as [Fecha Vuelo], CTO.nombre as OFICINA
                             FROM  dbo.TB_TANDEMUP tandemup
                             INNER JOIN dbo.TB_MANIFIESTO tbm ON tbm.idtandem = tandemup.idtandemup
                             INNER JOIN dbo.TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo 
                             INNER JOIN dbo.ct_oficina cto on cto.idoficina = tbv.idoficina " + condicion;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Blackboard de los Instructores
        public DataTable ConsultaBlackboardInstructores(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"  select id, idjumper, CONVERT(VARCHAR(8), REGISTERTIME, 108) as registertime,  name, 
                                   isnull(v1,'') as [1], isnull(v2,'') as [2], isnull(v3,'') as [3], isnull(v4,'') as [4], isnull(v5,'') as [5], 
                                   isnull(v6,'') as [6], isnull(v7,'') as [7], isnull(v8,'') as [8], ISNULL(v9,'') as [9], ISNULL(v10,'') as[10],
                                   isnull(v11,'') as [11], isnull(v12,'') as [12], isnull(v13,'') as [13], isnull(v14,'') as [14], isnull(v15,'') as [15], 
                                   isnull(v16,'') as [16], isnull(v17,'') as [17], isnull(v18,'') as [18], ISNULL(v19,'') as [19], ISNULL(v20,'') as [20]
                              from dbo.tb_instructors_blackboard with(nolock)" + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Instructores
        public DataTable ConsultaInstructores(string condicion)
        {
            DataTable dt = new DataTable();
            //            string sql = @"SELECT idtandemup,  SEQUENCE, REGISTERTIME, NAME, LASTNAME, REFERENCED_BY, JUMPTYPE, CHARGE, PAYMANT,  RELEASE,  RESERVED_DATE,  EMAIL,  JUMP_FLAG,  ID_PROSPECT, CODE_LEDGER, CODE
            //                             FROM dbo.TB_TANDEMUP " + condicion;
            string sql = @"  select id, idjumper, sequence, CONVERT(VARCHAR(8), REGISTERTIME, 108),  name, video, handvideo, videorent, tandem, busy, 
                                    jumps_premanifested, jumps_manifested, jumps_rejected, jumps_totals  from dbo.tb_instructors_activity with(nolock) " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Reserva
        public DataTable ConsultaReserva(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @" SELECT tbr.code, CONVERT(VARCHAR(10),tbr.fecha_salto,23) as [Jump Date], tbr.horario as Schedule,  tbr.personas as [People Group], tbr.nombre as [Name], tbr.apellido as [Lastname], tbr.email, tbr.telefono as [Phone], tbr.telefono2 as [Phone 2], 
       tbr.celular [Movil],  tbr.precio [Price], tbr.deposito [Deposit], tbr.metodo [Altitude], tbr.no_tarjeta as [Card number],
       convert(bit,tbr.confirmacion) [Confirmation], tbr.realizado [Jumped], tbr.vendedor [Vendor], tbr.observaciones [Comments], tbr.fecha_seguimiento [Follow date], tbr.aff,  tbr.video, tbr.videos, 
	   tbr.referencia [Reference],CONVERT(VARCHAR(10), tbr.fecha_reserva, 103) as [Reservation date], tbr.id, convert(bit,tbr.organizador) [Organizator],  ctb.description as [Budget Category], cto.Nombre
  FROM dbo.tb_reserva tbr  left outer join dbo.ct_budget ctb on ctb.idbudget = tbr.idbudget   
  inner join dbo.CT_OFICINA cto on cto.idoficina = tbr.iddropzone  " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Tickets
        public DataTable ConsultaTickets(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @" select ttb.id, ttb.idjumper, ttb.codejumper, ttb.nombre, ttb.folioticket, ttb.jumptypecode , ttb.price, ttb.updatedate, ttb.validity,  
       ttb.idoficina, cto.nombre as office_name,
       case when ttb.idestatus = 1 then CONVERT(bit,1) else CONVERT(bit,0) end as active, ttb.nota as concept
  from dbo.TB_TICKETS_BALANCE ttb inner join dbo.CT_OFICINA cto on cto.idoficina = ttb.idoficina " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Certificados
        public DataTable ConsultaCertificados(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @" select tbmc.codegroup, tbmc.idtandem, tbt.lastname LASTNAME, tbt.name  NAME, tbmc.idvuelo
                              from dbo.TB_MANIFIESTO_CERTIFICATE tbmc
                             inner join dbo.TB_TANDEMUP tbt on tbt.idtandemup = tbmc.idtandem " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region Consulta TandemUp
        public DataTable ConsultaTandemup(string condicion)
        {
            DataTable dt = new DataTable();
//            string sql = @"SELECT idtandemup,  SEQUENCE, REGISTERTIME, NAME, LASTNAME, REFERENCED_BY, JUMPTYPE, CHARGE, PAYMANT,  RELEASE,  RESERVED_DATE,  EMAIL,  JUMP_FLAG,  ID_PROSPECT, CODE_LEDGER, CODE
//                             FROM dbo.TB_TANDEMUP " + condicion;
            string sql = @" delete TB_TANDEMUP_ONSCREEN

                           INSERT INTO TB_TANDEMUP_ONSCREEN
                            SELECT tandemup.idtandemup,  tandemup.SEQUENCE, CONVERT(VARCHAR(8), tandemup.REGISTERTIME, 108) as REGISTERTIME, tandemup.NAME, tandemup.LASTNAME, tandemup.REFERENCED_BY, 
                                   tandemup.JUMPTYPE, tandemup.pricejump, tandemup.CHARGE, tandemup.PAYMaNT, Convert(bit,tandemup.RELEASE) as release,  tandemup.RESERVED_DATE,  tandemup.EMAIL,  
                                   convert(bit,tandemup.JUMP_FLAG) as [JUMP FLAG],  tandemup.ID_PROSPECT, tandemup.CODE_LEDGER, tandemup.CODE, tandemup.manifested, convert(bit,0) as video, 999999.99 as pricevideo,
                                   convert(bit,0) as handvideo, 999999.99 as pricehandvideo, idusuario, tandemweight, tandemheight, tandemovenweight,  convert(bit,0) as videorent, 999999.99 as pricevideorent, ticket_videorent, ENUSO, USADOPOR, 999999 as idvuelo
                            --  INTO #TANDEMUP
                              FROM dbo.TB_TANDEMUP tandemup " + condicion +
                          @"            


       
                            UPDATE TB_TANDEMUP_ONSCREEN SET pricevideo = 0.00, pricehandvideo = 0.00

                            update tandemup 
                               set tandemup.pricevideo = tuas.price
                              FROM TB_TANDEMUP_ONSCREEN tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

                            update tandemup 
                               set tandemup.pricevideorent = tuas.price
                              FROM TB_TANDEMUP_ONSCREEN tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  )

                            update tandemup 
                               set tandemup.pricehandvideo = tuas.price
                              FROM TB_TANDEMUP_ONSCREEN tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup and TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  )




                             UPDATE TU
                                SET TU.video = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                               FROM TB_TANDEMUP_ONSCREEN TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
  
                             UPDATE TU
                                SET TU.handvideo = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                               FROM TB_TANDEMUP_ONSCREEN TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  )

                             UPDATE TU
                                SET TU.videorent = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                               FROM TB_TANDEMUP_ONSCREEN TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  )

  
                            SELECT tandemup.idtandemup, tandemup.sequence, convert(varchar(8),tandemup.REGISTERTIME,108) as REGISTERTIME,  tandemup.name, tandemup.lastname, tandemup.referenced_by, tandemup.jumptype, 
                                   convert(decimal(6,2),tandemup.tandemweight) as tandemweight, tandemup.tandemovenweight,convert(int,tandemup.tandemheight) as tandemheight , convert(bit,tandemup.video) as video, 
                                   convert(bit,tandemup.handvideo) as handvideo, convert(bit,tandemup.videorent) as videorent,  convert(decimal(8,2),tandemup.pricejump) pricejump, tandemup.pricevideo,  tandemup.pricehandvideo,
                                   convert(decimal(8,2),tandemup.charge) as charge, convert(decimal(8,2),tandemup.paymant) paymant, convert(bit,tandemup.release) as release, tandemup.reserved_date, tandemup.email, tandemup.[JUMP_FLAG], 
                                   tandemup.id_prospect, tandemup.code_ledger, tandemup.code, tandemup.manifested, ctu.idusuario, convert(bit,tandemup.ticket_videorent),
                                   tbv.numerovuelo as [# VUELO], UPPER(ctu.nombre + ' ' + ctu.paterno) , ENUSO, USADOPOR, pricevideorent, tbv.idvuelo
                               FROM TB_TANDEMUP_ONSCREEN tandemup  
                               LEFT OUTER JOIN tb_manifiesto tbm on tbm.idtandem =  tandemup.idtandemup
                               LEFT OUTER JOIN tb_vuelos tbv on tbv.idvuelo = tbm.idvuelo
                               INNER JOIN ct_usuario ctu on ctu.idusuario = tandemup.idusuario    ";
            if (misglobales.TandemSelection == 1)
            {
                sql = sql + @"    where idtandemup not in (SELECT distinct TB_MANIFIESTO.idtandem
                                                         FROM dbo.TB_VUELOS VUELOS
														INNER JOIN TB_MANIFIESTO on TB_MANIFIESTO.idvuelo = VUELOS.idvuelo
														 WHERE convert(varchar(10), VUELOS.fechaabrevuelo, 23) = '" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ) order by sequence";
            }
            else
            {
                sql = sql + "  order by manifested, sequence";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                
                da.SelectCommand.CommandTimeout = 2600;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        #endregion 

        #region Consulta Manifiesto para el Itinerario
        public DataTable ConsultaManifiestoItinerario(string condicion)
        {
            DataTable dt = new DataTable();
//            string sql = @"SELECT TB_MANIFIESTO.IDMANIFIESTO,
//                                TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
//                                TB_MANIFIESTO.IDJUMPER,  ISNULL(UPPER(CT_JUMPER.nombre),'')  as JUMPER_NAME,
//                                CT_JUMPER.idjumptypecode,
//                                TB_MANIFIESTO.IDTANDEM,  ISNULL(TANDEM.nombre,'') + ' ' + ISNULL(TANDEM.paterno,'') + ' ' + ISNULL(TANDEM.materno,'') AS TANDEM_NAME,
//                                TB_MANIFIESTO.IDLEADGER, 
//                                --ISNULL(LEADGER.nombre,'') + ' ' + ISNULL(CT_JUMPER.paterno,'') + ' ' + ISNULL(LEADGER.materno,'') AS LEADGER_NAME,
//                                '' AS LEADGER_NAME, TB_MANIFIESTO.IDTANDEM,   ISNULL(UPPER(CT_JUMPER.nombre),'') AS MONITOR_NAME
//                                FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
//                                INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
//                                INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
//                                left JOIN dbo.CT_JUMPER TANDEM ON TANDEM.idjumper = TB_MANIFIESTO.IDTANDEM
//                                LEFT JOIN dbo.CT_JUMPER LEADGER ON LEADGER.idjumper = TB_MANIFIESTO.IDLEADGER  " + condicion;
            String sql = @"

SELECT TB_MANIFIESTO.IDMANIFIESTO,
       TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
       TB_MANIFIESTO.IDJUMPER,  case when len(ct_jumper.Aliasjumper) > 2 then CT_JUMPER.Aliasjumper else  CT_JUMPER.nombre end  as  JUMPER_NAME,
       JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent
  into #MANIFIESTO
  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
 INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem + @"
 INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +
             @"UNION ALL 
SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
       TB_MANIFIESTO.idtandem, CT_JUMPER.lastname + ' ' + CT_JUMPER.name  as JUMPER_NAME,
       JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent
  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
 INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
 INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +

             @"
update tandemup 
   set tandemup.video = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
   
   update tandemup 
   set tandemup.handvideo = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
   

   update tandemup 
   set tandemup.videorent = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  )   


 UPDATE tandemup
    SET tandemup.altitud = tbmc.jumptypecode
   FROM #MANIFIESTO tandemup
  INNER JOIN dbo.TB_MANIFIESTO_CERTIFICATE tbmc on tbmc.idvuelo = tandemup.idvuelo and tbmc.idjumper = tandemup.idjumper
 



SELECT idmanifiesto, idvuelo, idjumper, case when idjumper in(select idjumper
   from tb_instructors_activity
  where CONVERT(varchar(10), registertime,23) = CONVERT(varchar(10), getdate(),23))  then '       ' + UPPER(JUMPER_NAME) else UPPER(jumper_name) end  as jumpername,  upper(altitud) as jump_type,  idtandem, convert(bit,video) as video, convert(bit,handvideo) as handvideo, convert(bit,videorent) AS videorent
  FROM #MANIFIESTO ORDER BY idmanifiesto

";




            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Pre Manifiesto
        public DataTable ConsultaPreManifiesto(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @" SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.code as [Group], TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
                                     CT_JUMPER.lastname + ', ' + CT_JUMPER.NAME as JUMPER_NAME,
                                    JUMPTYPE.idjumptype, TB_MANIFIESTO.jumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup,TB_MANIFIESTO.video, TB_MANIFIESTO.handvideo, TB_MANIFIESTO.videorent
                                FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO
                                INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem     
                                LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.jumptype 
                                WHERE TB_MANIFIESTO.IDJUMPER = " + misglobales.idJumperTandem+ @"
                                UNION ALL
                                SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.code, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
                                    '          ' + ISNULL(CT_JUMPER.nombre,'')  as JUMPER_NAME,
                                    JUMPTYPE.idjumptype, TB_MANIFIESTO.jumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup,TB_MANIFIESTO.video, TB_MANIFIESTO.handvideo, TB_MANIFIESTO.videorent
                                FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO 
                                INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
                                LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = TB_MANIFIESTO.jumptypecode WHERE TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem + @"
                                order by TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.codegroup";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        #endregion 

        #region Consulta ConsultaPrePreManifiesto
        public DataTable ConsultaPrePreManifiesto(string condicion)
        {
            DataTable dt = new DataTable();
//            string sql = @" SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
//                                       ISNULL(UPPER(CT_JUMPER.NAME),'') + ' ' + ISNULL(UPPER(CT_JUMPER.lastname),'') + ' ( ' +isnull(tb_manifiesto.reservefor,'') + ' )' as JUMPER_NAME,
//                                       CT_JUMPER.jumptype, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup
//                                  FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO
//                                 INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem     
//                                  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.jumptype 
//                                 WHERE TB_MANIFIESTO.IDJUMPER = 1206
//                                 UNION ALL
//                                 SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_MANIFIESTO.IDJUMPER,  
//                                       ISNULL(UPPER(CT_JUMPER.nombre),'') + ' ' + ISNULL(CT_JUMPER.paterno, '') + ' ' + ISNULL(CT_JUMPER.materno, '') + '(instructor)' as JUMPER_NAME,
//                                       CT_JUMPER.idjumptypecode, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.codegroup
//                                  FROM dbo.TB_PRE_MANIFIESTO TB_MANIFIESTO 
//                                 INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
//                                  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.jump_type = CT_JUMPER.idjumptypecode WHERE TB_MANIFIESTO.IDJUMPER <> 1206
//                                 order by TB_MANIFIESTO.codegroup";

            string sql = @"
                    SELECT tandemup.idtandemup,  tandemup.SEQUENCE, CONVERT(VARCHAR(8), tandemup.REGISTERTIME, 108) as REGISTERTIME, tandemup.NAME, tandemup.LASTNAME, tandemup.REFERENCED_BY, 
                           tandemup.JUMPTYPE, tandemup.pricejump, tandemup.CHARGE, tandemup.PAYMaNT, Convert(bit,tandemup.RELEASE) as release,  tandemup.RESERVED_DATE,  tandemup.EMAIL,  
                           convert(bit,tandemup.JUMP_FLAG) as [JUMP FLAG],  tandemup.ID_PROSPECT, tandemup.CODE_LEDGER, tandemup.CODE, tandemup.manifested, convert(bit,0) as video, 999999.99 as pricevideo,
                           convert(bit,0) as handvideo, 999999.99 as pricehandvideo, convert(decimal(6,2),tandemweight) as tandemweight, tandemheight, tandemovenweight,  convert(bit,0) as videorent, 999999.99 as pricevideorent
                      INTO #TANDEMUP
                      FROM dbo.TB_TANDEMUP tandemup " + condicion + @"

/*IF OBJECT_ID('ix_tandem', 'U') IS NOT NULL
  DROP  index ix_tandem on #TANDEMUP;

                    create unique index ix_tandem on #TANDEM (idtandemup) */

 
                    UPDATE #TANDEMUP SET pricevideo = 0.00, pricehandvideo = 0.00, pricevideorent = 0.00

                    update tandemup 
                       set tandemup.pricevideo = tuas.price
                      FROM #TANDEMUP tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

                    update tandemup 
                       set tandemup.pricehandvideo = tuas.price
                      FROM #TANDEMUP tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup and TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

                    update tandemup 
                       set tandemup.pricevideorent = tuas.price
                      FROM #TANDEMUP tandemup inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandemup and TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 


                    UPDATE TU
                       SET TU.video = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                      FROM #TANDEMUP TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  )
  
                    UPDATE TU
                       SET TU.handvideo = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                      FROM #TANDEMUP TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

                    UPDATE TU
                       SET TU.videorent = CASE WHEN TUAS.PRICE IS NULL THEN 0 ELSE 1 END
                      FROM #TANDEMUP TU LEFT OUTER JOIN TB_TANDEMUP_ADITIONAL_SERVICES TUAS ON TUAS.IDTANDEMUP = TU.idtandemup AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
  
                    SELECT idtandemup, code, sequence, REGISTERTIME, lastname + ', '+ name , referenced_by, jumptype, CONVERT(bit,release) as release, reserved_date, email, CONVERT(bit,video) as video, 
                           CONVERT(bit,handvideo) as handvideo, CONVERT(bit,videorent), convert(decimal(6,2),tandemweight) as tandemweight ,  case when convert(int,tandemovenweight) > 0 then CONVERT(bit,1) else CONVERT(bit,0) end as ovenweight, convert(int,tandemheight)
                      FROM #TANDEMUP tandemup 
                     WHERE (idtandemup NOT IN (SELECT idtandem FROM dbo.TB_PRE_MANIFIESTO)) 
/* and (idtandemup NOT IN (SELECT idtandem FROM dbo.TB_MANIFIESTO))  )*/
                     
";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Manifiesto en la venta de videos UPGRADE
        public DataTable ConsultaManifiestoVtaVideo(string condicion)
        {
            DataTable dt = new DataTable();
            String sql = @"

                            SELECT TB_VUELOS.numerovuelo, TB_MANIFIESTO.IDMANIFIESTO,
                                   TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
                                   TB_MANIFIESTO.IDJUMPER,  CT_JUMPER.nombre   as JUMPER_NAME,
                                   JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent, '' AS referenced_by
                              into #MANIFIESTO
                              FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO 
                               AND CONVERT(varchar(10), TB_VUELOS.fechaabrevuelo,23) = CONVERT(varchar(10), GETDATE(),23)
                             INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem + @"
                             INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
                              LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +
                             @"UNION ALL 
                            SELECT TB_VUELOS.numerovuelo, TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
                                   TB_MANIFIESTO.idtandem, CT_JUMPER.lastname + ' ' + CT_JUMPER.name  as JUMPER_NAME,
                                   JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent, referenced_by
                              FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
                               AND CONVERT(varchar(10), TB_VUELOS.fechaabrevuelo,23) = CONVERT(varchar(10), GETDATE(),23)
                             INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
                             INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
                              LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +

                             @"
                            update tandemup 
                               set tandemup.video = 1
                              FROM #MANIFIESTO tandemup 
                             inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
                               AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
   
                               update tandemup 
                               set tandemup.handvideo = 1
                              FROM #MANIFIESTO tandemup 
                             inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
                               AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 


                               update tandemup 
                               set tandemup.videorent = 1
                              FROM #MANIFIESTO tandemup 
                             inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
                               AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

                               Update tandemup
                                 set tandemup.videorent = 1
                                FROM #MANIFIESTO tandemup
                                INNER JOIN dbo.tb_manifiesto_certificate TBMC on TBMC.idmanifiesto = tandemup.IDMANIFIESTO 
                                       and TBMC.videorent = 1
   

                            SELECT numerovuelo, idmanifiesto, idvuelo, idaeronave, matricula, idjumper,case when idjumper in(select idjumper
                               from tb_instructors_activity
                              where CONVERT(varchar(10), registertime,23) = CONVERT(varchar(10), getdate(),23))  then '          ' + JUMPER_NAME else jumper_name end as jumpername, jump_type, idtandem, Altitud, folioticket, idleadger, 
                                   convert(bit,video) as video, convert(bit,handvideo) as handvideo,  convert(bit,videorent) as [VIDEO RENT], referenced_by
                              FROM #MANIFIESTO 
                            ORDER BY numerovuelo,idmanifiesto";

            //CT_JUMPER.idjumptypecode
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Manifiesto Para modificar el Manifiesto de un tandem ya manifestdo
        public DataTable ConsultaManifiestoAModificar(string condicion)
        {
            DataTable dt = new DataTable();
            String sql = @"

                            SELECT TB_VUELOS.numerovuelo, TB_MANIFIESTO.IDMANIFIESTO,
                                   TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
                                   TB_MANIFIESTO.IDJUMPER,  CT_JUMPER.nombre   as JUMPER_NAME,
                                   JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent, '' AS referenced_by
                              into #MANIFIESTO
                              FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
                             INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem + @"
                             INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
                              LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype 
                            UNION ALL 
                            SELECT TB_VUELOS.numerovuelo, TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
                                   TB_MANIFIESTO.idtandem, CT_JUMPER.lastname + ' ' + CT_JUMPER.name  as JUMPER_NAME,
                                   JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent, referenced_by
                              FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
                             INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
                             INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
                              LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype 
                            update tandemup 
                               set tandemup.video = 1
                              FROM #MANIFIESTO tandemup 
                             inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
                               AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
   
                               update tandemup 
                               set tandemup.handvideo = 1
                              FROM #MANIFIESTO tandemup 
                             inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
                               AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 


                               update tandemup 
                               set tandemup.videorent = 1
                              FROM #MANIFIESTO tandemup 
                             inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
                               AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

                               Update tandemup
                                 set tandemup.videorent = 1
                                FROM #MANIFIESTO tandemup
                                INNER JOIN dbo.tb_manifiesto_certificate TBMC on TBMC.idmanifiesto = tandemup.IDMANIFIESTO 
                                       and TBMC.videorent = 1

                            SELECT M.numerovuelo, M.idmanifiesto, M.idvuelo, M.idaeronave, M.matricula, M.idjumper,case when M.idjumper in(select idjumper
                               from tb_instructors_activity
                              where CONVERT(varchar(10), registertime,23) = CONVERT(varchar(10), getdate(),23))  then '          ' + JUMPER_NAME else jumper_name end as jumpername, 
                              M.jump_type, M.idtandem, M.Altitud, M.folioticket, M.idleadger, 
                                   convert(bit,M.video) as video, convert(bit,M.handvideo) as handvideo,  convert(bit,M.videorent) as [VIDEO RENT], M.referenced_by
                              FROM #MANIFIESTO M
                              WHERE IDTANDEM = " + condicion +@"
                              OR idjumper IN ( SELECT TBMC.IDJUMPER FROM dbo.TB_MANIFIESTO_CERTIFICATE TBMC WHERE TBMC.CODEGROUP = "+condicion+" AND TBMC.IDVUELO = M.idvuelo AND TBMC.IDJUMPER <> " + misglobales.idJumperTandem + @")
                            ORDER BY numerovuelo,idmanifiesto";

            //CT_JUMPER.idjumptypecode
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Manifiesto
        public DataTable ConsultaManifiesto(string condicion)
        {
            DataTable dt = new DataTable();
//            string sql = @"SELECT TB_MANIFIESTO.IDMANIFIESTO,
//                    TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
//                    TB_MANIFIESTO.IDJUMPER,  ISNULL(UPPER(CT_JUMPER.nombre),'') + ' ' + ISNULL(CT_JUMPER.paterno, '') + ' ' + ISNULL(CT_JUMPER.materno, '') as JUMPER_NAME,
//                    CT_JUMPER.idjumptypecode,
//                    TB_MANIFIESTO.IDTANDEM,  ISNULL(TANDEM.nombre,'') + ' ' + ISNULL(TANDEM.paterno,'') + ' ' + ISNULL(TANDEM.materno,'') AS TANDEM_NAME,
//                    TB_MANIFIESTO.IDLEADGER, 
//                    --ISNULL(LEADGER.nombre,'') + ' ' + ISNULL(CT_JUMPER.paterno,'') + ' ' + ISNULL(LEADGER.materno,'') AS LEADGER_NAME,
//                    '' AS LEADGER_NAME, TB_MANIFIESTO.IDTANDEM,  ISNULL(UPPER(TANDEM.paterno),'') + ', ' +  ISNULL(UPPER(CT_JUMPER.nombre),'') AS MONITOR_NAME
//                    FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
//                    INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER
//                    INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
//                    left JOIN dbo.CT_JUMPER TANDEM ON TANDEM.idjumper = TB_MANIFIESTO.IDTANDEM
//                    LEFT JOIN dbo.CT_JUMPER LEADGER ON LEADGER.idjumper = TB_MANIFIESTO.IDLEADGER  " + condicion;
            //string sql = @" SELECT TB_MANIFIESTO.IDMANIFIESTO,
//                    TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
//                    TB_MANIFIESTO.IDJUMPER,  ISNULL(UPPER(CT_JUMPER.nombre),'') + ' ' + ISNULL(CT_JUMPER.paterno, '') + ' ' + ISNULL(CT_JUMPER.materno, '') +  '-' + CONVERT(char(6),idmanifiesto) + '-' + isnull(tb_manifiesto.reservefor,'') as JUMPER_NAME,
//                    JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger
//                    FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
//                    INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> 1206
//                    INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
//                    LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +
//                    @" UNION ALL SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
//                              TB_MANIFIESTO.idtandem, ISNULL(UPPER(CT_JUMPER.name),'') + ' ' + ISNULL(CT_JUMPER.lastname, '') + '-' + CONVERT(char(6),idmanifiesto) + '-' + isnull(tb_manifiesto.reservefor,'') as JUMPER_NAME,
//                              JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger
//                         FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
//                        INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
//                        INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
//                         LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion;



 //VER151
            String sql = @"

SELECT TB_MANIFIESTO.IDMANIFIESTO,
       TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
       TB_MANIFIESTO.IDJUMPER,  CT_JUMPER.nombre   as JUMPER_NAME,
       JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent, upgrade, idusuario_upgrade, upgradedate
  into #MANIFIESTO
  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
 INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem +@"
 INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +
 @"UNION ALL 
SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
       TB_MANIFIESTO.idtandem, CT_JUMPER.lastname + ' ' + CT_JUMPER.name  as JUMPER_NAME,
       JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent, upgrade, idusuario_upgrade, upgradedate
  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
 INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
 INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +

 @"
update tandemup 
   set tandemup.video = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
   
   update tandemup 
   set tandemup.handvideo = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 


   update tandemup 
   set tandemup.videorent = 1
  FROM #MANIFIESTO tandemup 
 inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 

   Update tandemup
     set tandemup.videorent = 1
    FROM #MANIFIESTO tandemup
    INNER JOIN dbo.tb_manifiesto_certificate TBMC on TBMC.idmanifiesto = tandemup.IDMANIFIESTO 
           and TBMC.videorent = 1
   

SELECT idmanifiesto, idvuelo, idaeronave, matricula, idjumper,case when idjumper in(select idjumper
   from tb_instructors_activity
  where CONVERT(varchar(10), registertime,23) = CONVERT(varchar(10), getdate(),23))  then '          ' + JUMPER_NAME else jumper_name end as jumpername, jump_type, idtandem, Altitud, folioticket, idleadger, 
       convert(bit,video) as video, convert(bit,handvideo) as handvideo,  convert(bit,videorent) as [VIDEO RENT], upgrade, idusuario_upgrade, upgradedate
  FROM #MANIFIESTO ORDER BY idmanifiesto

";



//            String sql = @"
//
//SELECT TB_MANIFIESTO.IDMANIFIESTO,
//       TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
//       TB_MANIFIESTO.IDJUMPER,  CT_JUMPER.nombre   as JUMPER_NAME,
//       JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud, TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent
//  into #MANIFIESTO
//  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
// INNER JOIN dbo.CT_JUMPER CT_JUMPER ON CT_JUMPER.idjumper = TB_MANIFIESTO.IDJUMPER AND TB_MANIFIESTO.IDJUMPER <> " + misglobales.idJumperTandem + @"
// INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
//  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +
//@"UNION ALL 
//SELECT TB_MANIFIESTO.IDMANIFIESTO, TB_MANIFIESTO.IDVUELO, TB_VUELOS.idaeronave, CT_AERONAVE.matricula,
//       TB_MANIFIESTO.idtandem, CT_JUMPER.lastname + ' ' + CT_JUMPER.name  as JUMPER_NAME,
//       JUMPTYPE.jump_type, TB_MANIFIESTO.IDTANDEM, JUMPTYPE.Altitud,  TB_MANIFIESTO.folioticket, TB_MANIFIESTO.idleadger, 0 as video, 0 as handvideo, 0 as videorent
//  FROM dbo.TB_MANIFIESTO TB_MANIFIESTO INNER JOIN dbo.TB_VUELOS TB_VUELOS ON TB_VUELOS.idvuelo = TB_MANIFIESTO.IDVUELO
// INNER JOIN DBO.TB_TANDEMUP CT_JUMPER   ON CT_JUMPER.idtandemup = TB_MANIFIESTO.idtandem AND idtandem <> 0     
// INNER JOIN dbo.CT_AERONAVE CT_AERONAVE ON CT_AERONAVE.idaeronave =  TB_VUELOS.idaeronave
//  LEFT OUTER JOIN dbo.CT_JUMP_TYPE JUMPTYPE ON JUMPTYPE.idjumptype = TB_MANIFIESTO.idjumptype " + condicion +

//@"
//update tandemup 
//   set tandemup.video = 1
//  FROM #MANIFIESTO tandemup 
// inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
//   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'FOTO Y VIDEO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
//   
//   update tandemup 
//   set tandemup.handvideo = 1
//  FROM #MANIFIESTO tandemup 
// inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
//   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO DE MANO' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
//
//
//   update tandemup 
//   set tandemup.videorent = 1
//  FROM #MANIFIESTO tandemup 
// inner join TB_TANDEMUP_ADITIONAL_SERVICES tuas on tuas.idtandemup = tandemup.idtandem 
//   AND TUAS.idaditionalservices in (select id from dbo.CT_ADITIONAL_SERVICES where descripcion = 'VIDEO RENTA' AND idoficina = " + misglobales.oficina_id_oficina + @"  ) 
//
//   Update tandemup
//     set tandemup.videorent = 1
//    FROM #MANIFIESTO tandemup
//    INNER JOIN dbo.tb_manifiesto_certificate TBMC on TBMC.idmanifiesto = tandemup.IDMANIFIESTO 
//           and TBMC.videorent = 1
//   
//
//SELECT idmanifiesto, idvuelo, idaeronave, matricula, idjumper,case when idjumper in(select idjumper
//   from tb_instructors_activity
//  where CONVERT(varchar(10), registertime,23) = CONVERT(varchar(10), getdate(),23))  then '          ' + JUMPER_NAME else jumper_name end as jumpername, jump_type, idtandem, Altitud, folioticket, idleadger, 
//       convert(bit,video) as video, convert(bit,handvideo) as handvideo,  convert(bit,videorent) as [VIDEO RENT]
//  FROM #MANIFIESTO ORDER BY idmanifiesto
//
//";


            //CT_JUMPER.idjumptypecode
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        #endregion 

        #region Consulta Calendario exceptions
        public DataTable ExceptionCalendar(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = "";
            //            string sql = @" SELECT idpaymenttype, code, payment_type, '0.00' payment
            //                              FROM CT_PAYMENT_TYPE
            //                             ORDER BY sort" + condicion;

            sql = @"select idcalendar,horario, capacidad_lunes, capacidad_martes, capacidad_miercoles, capacidad_jueves, " +
                  @"  capacidad_viernes, capacidad_sabado, capacidad_domingo, iddropzone, updatedate, idusuario  " +
                  @"    from CT_CALENDAR  where iddropzone = " + condicion;


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Calendario base
        public DataTable Calendario(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = "";
            //            string sql = @" SELECT idpaymenttype, code, payment_type, '0.00' payment
            //                              FROM CT_PAYMENT_TYPE
            //                             ORDER BY sort" + condicion;

            sql = @"select idcalendar,horario, capacidad_lunes, capacidad_martes, capacidad_miercoles, capacidad_jueves, " +
                  @"  capacidad_viernes, capacidad_sabado, capacidad_domingo, iddropzone, updatedate, idusuario  " +
                  @"    from CT_CALENDAR  where iddropzone = " + condicion;


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Jumper Ratings
        public DataTable JumperRatings(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT jp.idjumper,  ctp.idratings, ctp.long_description, convert(bit, isnull(jp.active,0))  as active, isnull(jp.comments,'') as comments, JP.CODEJUMPER
                      FROM TB_JUMPER_RATINGS JP 
                     right OUTER JOIN CT_RATINGS CTP  ON CTP.idratings = JP.idratings
                     and jp.idjumper =  " + condicion;


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Jumper Preferences
        public DataTable JumperPreferences(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = "";
            //            string sql = @" SELECT idpaymenttype, code, payment_type, '0.00' payment
            //                              FROM CT_PAYMENT_TYPE
            //                             ORDER BY sort" + condicion;

            sql = @"SELECT jp.idjumper, ctp.idpreferences, ctp.long_description, convert(bit, isnull(jp.active,0))  as active, isnull(jp.comments,'') as comments
                      FROM CT_JUMPER_PREFERENCES JP 
                     right OUTER JOIN CT_PREFERENCES CTP  ON CTP.idpreferences = JP.idpreferences
                     and jp.idjumper =  " + condicion;


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Preferences
        public DataTable ConsultaPreferences()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT  idpreferences, codigo, preference_type, short_description, long_description, convert(bit, idestatus) as idestatus from CT_PREFERENCES";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Payment Breakdown
        public DataTable ConsultaBreakdown(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = "" ;
//            string sql = @" SELECT idpaymenttype, code, payment_type, '0.00' payment
//                              FROM CT_PAYMENT_TYPE
//                             ORDER BY sort" + condicion;
            if(misglobales._BreakDown == 1)
            {
                //dbo.TB_BREAKDOWNTANDEM
                sql = @"SELECT ctp.idpaymenttype, ctp.code, ctp.payment_type,
                        case when tbb.payment IS NULL  then '0.00' else tbb.payment end payment
                        FROM CT_PAYMENT_TYPE ctp LEFT OUTER JOIN dbo.TB_BREAKDOWNTANDEM TBB ON
                        TBB.code_payment_type = ctp.code " + condicion;
            }
            if (misglobales._BreakDown == 0)
            {
                sql = @"SELECT ctp.idpaymenttype, ctp.code, ctp.payment_type,
                        case when tbb.payment IS NULL  then '0.00' else tbb.payment end payment
                        FROM CT_PAYMENT_TYPE ctp LEFT OUTER JOIN dbo.TB_BREAKEDOWN TBB ON
                        TBB.code_payment_type = ctp.code " + condicion;
                //and TBB.code_ledger = 'TANDEM-JU'";

            }
     
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Prospect
        public DataTable ConsultaProspect(string condicion, string idtandemupvar)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT idtandemup, CODE, date_entered, name, organization, referenced_by, isnull(interested,0) as interested, 
                                  (Select COUNT(idmanifiesto) From TB_MANIFIESTO where idtandem = '"+ idtandemupvar + @"' )  asjump_count,
                                  (Select MAX(fechaabrevuelo) From dbo.TB_VUELOS where idvuelo in(Select idvuelo From TB_MANIFIESTO where idtandem = '" + idtandemupvar + @"') )  as  lastJumpDate, 
                                  id_source_type, note, name as Firstname, lastname, Adress, Adress2, City, [State], Country, Postal_Code, Home_phone, Work_phone, fax, Mobile_phone,
                                  Nextel, Other_phone, email, [Source_type], idoficina
                             FROM dbo.tb_tandemup " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsultaJumperList
        public DataTable ConsultaPreferenceList(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @" SELECT jp.idjumper, CTJ.nombre, CTJ.email, CTJ.home_phone, CTJ.mobile_phone, CTJ.work_phone, CTJ.city,  CTJ.[state],  ctp.idpreferences, ctp.long_description, 
        CONVERT(VARCHAR(10),CTJ.Waiver_Expires,23) AS WAIVER_DATE,  CTJ.USPA_Member AS MEMBER_NUMBER ,  CONVERT(VARCHAR(10),CTJ.USPA_Expires,23) as [LICENCE/MEMBER EXPIRE] ,
        convert(bit, isnull(jp.active,0)) as active, isnull(jp.comments,'') as comments
  FROM CT_JUMPER_PREFERENCES JP 
 INNER JOIN CT_PREFERENCES CTP  ON CTP.idpreferences = JP.idpreferences
 INNER JOIN CT_JUMPER CTJ ON CTJ.idjumper = JP.idjumper  " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsultaJumperList
        public DataTable ConsultaJumperList(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT j.codigo as ID, CASE j.idestatus WHEN 1 THEN convert(bit,1) ELSE convert(bit,0) END as Active, j.Fecha_alta AS [Date Entered], j.name as [First Name],
                                    j.lastname as [Last Name], j.Balance, j.idjumptypecode as [Jump Type], j.idjumpertypecode as [Jumper Type],
                                    j.Aliasjumper as [Alias], j.total_saltos as [# Jumps], j.Fecha_ultimo_salto as [Last Jump], j.address1 as [Address],
                                    j.address2 as [Address cont...], j.city as [City], j.[state]  as [State], j.country as Country, j.postal_code as [Postal Code],
                                    j.home_phone as [Home Phone], j.work_phone as [Work Phone], j.fax as [Fax], j.mobile_phone as [Mobile Phone], 
                                    j.other_phone as [Other Phone], j.email as [e-Mail], j.nextel, j.Equipamiento as [Equipment], j.ReserveRepackDate as [Reserve Repack],
                                    j.USPA_Member as [USPA Member], j.USPA_Licence as [USPA Licence], j.USPA_Expires as [USPA Expires], j.id_sourcetypecode as [Source],
                                    j.Reference_idJumpercode as [Reference], j.Waiver_Expires as [Waiver Expires], j.Locker as [Locker], convert(bit,j.All_Day_Jump_padlock) as [All Day Jump],
                                    convert(bit,j.Debit_Padlock) as [Allow Trans. w/no balance], convert(bit,j.Allow_Override_Padlock) as [Allow Change Jump Type],
                                    convert(bit,j.Allow_PaidBy) as [Allow Paid By],
                                    convert(bit,j.Allow_FirstJump) as [Allow First Jumpe Chance], convert(bit,j.FirstJump_Padlock) as [First Jump Taken], j.Note as Note,
                                    j.medical_insurance, j.credit_card, j.balance_jump, j.idjumper, j.licencetype, convert(varchar(10),j.BORNDATE, 23) as borndate, j.GRADE, j.CURP, 
                                    convert(varchar(10),j.DATEBEGINSPORT,23), updatedate, idgender, instructor_name
                            FROM dbo.CT_JUMPER j  " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsultaVuelos
        public DataTable ConsultaVuelos(string condicion)
        { 
            DataTable dt = new DataTable();
            string sql = @"SELECT VUELOS.IDVUELO, VUELOS.IDAERONAVE,  VUELOS.NUMEROVUELO,  AERONAVE.matricula AS MATRICULA, AERONAVE.codigo AS [PLANE CODE], 
                                    CONVERT(CHAR(2),(SELECT COUNT(M.IDJUMPER) FROM DBO.TB_MANIFIESTO M WHERE M.idvuelo = VUELOS.IDVUELO)) + ' Of ' + CONVERT(CHAR(3),AERONAVE.capacidadpersonas) [ON BOARD],
                                    AERONAVE.capacidadpeso AS [CAPACIDAD PESO], 
                                    AERONAVE.altitud AS [PLANE ALTITUD], VUELOS.IDPILOTO, PILOTO.nombre_piloto AS [NOMBRE PILOTO], 
                                    PILOTO.paterno_piloto [PATERNO PILOTO], PILOTO.materno_piloto [MATERNO PILOTO], 
                                    PILOTO.licencia AS [LICENCIA PILOTO], VUELOS.FECHAABREVUELO AS [FECHA APERTURA], 
                                    VUELOS.FECHACIERREVUELO [FECHA CIERRE], VUELOS.IDESTATUS, ESTATUS.descripcion AS [ESTATUS VUELO],
                                    VUELOS.IDUSUARIO, USUARIO.nombre  + ' ' + USUARIO.paterno  + ' ' + USUARIO.materno, 0 oncall
                            FROM dbo.TB_VUELOS VUELOS
                    INNER JOIN dbo.CT_AERONAVE AERONAVE ON VUELOS.IDAERONAVE = AERONAVE.idaeronave
                    INNER JOIN dbo.CT_PILOTO PILOTO ON PILOTO.idpiloto = VUELOS.idpiloto
                    INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.idestatus = VUELOS.IDESTATUS
                    INNER JOIN dbo.CT_USUARIO USUARIO ON USUARIO.idusuario = VUELOS.IDUSUARIO " + condicion +
                    " ORDER BY  convert(varchar(10),VUELOS.FECHAABREVUELO,23) desc, VUELOS.NUMEROVUELO asc";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsultaOficinas
        public DataTable ConsultaOficinas(string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT OFICINA.Nombre AS [OFFICE NAME],  RESPONSABLE.nombre + ' ' + RESPONSABLE.paterno + ' ' + RESPONSABLE.materno AS [OFFICE RESPONSABLE],
                                  OFICINA.UBICACION AS COORDINATES, ENTIDAD.renapo AS [RENAPO CODE], ENTIDAD.descripcion [STATES DESCRIPTION],
                                  MODIFICADOPOR.nombre + ' ' + MODIFICADOPOR.paterno + ' ' + MODIFICADOPOR.materno AS [MODIFICADOPOR],
                                  OFICINA.fecha_creacion AS MODIFICADOEL, ESTATUS.descripcion AS [STATUS]
                             FROM DBO.CT_OFICINA OFICINA INNER JOIN DBO.CT_ENTIDAD ENTIDAD ON ENTIDAD.identidad = OFICINA.identidad
                            INNER JOIN DBO.CT_USUARIO RESPONSABLE ON RESPONSABLE.idusuario = OFICINA.idusuariotitular
                            INNER JOIN DBO.CT_USUARIO MODIFICADOPOR ON MODIFICADOPOR.idusuario = OFICINA.idusuario
                            INNER JOIN DBO.CT_ESTATUS ESTATUS ON ESTATUS.idestatus = OFICINA.idestatus " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Estatus
        public DataTable ConsultaEstatus()
        {
            DataTable dt = new DataTable();
            string sql = @"select idestatus, descripcion, fecha_creacion from dbo.CT_ESTATUS";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Pilotos
        public DataTable ConsultaPilot()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT idpiloto, Codigo, nombre_piloto, paterno_piloto, materno_piloto, licencia, 
                                  CASE WHEN idestatus= 1 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END IDESTATUS, fechamovimiento 
                             FROM dbo.CT_PILOTO 
                            WHERE idestatus <> 4";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Jumper Type
        public DataTable ConsultaJumperType()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT idjumpertype, Codigo, orden, Descripcion, CASE WHEN idestatus= 1 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END IDESTATUS  
                             FROM dbo.CT_JUMPER_TYPE 
                            WHERE idestatus <> 4 order by orden";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Jump Type
        public DataTable ConsultaJumpType()
        {
            DataTable dt = new DataTable();
            string sql = @"Select jt.idjumptype, jt.orden as SEQ, jt.codigo, jt.jump_type, jt.price, jt.[group],
                                   jt.[Description], jt.Altitud, jt.codey, jt.idchargetype, jt.charge_type_description, ct.charge_type,
                                   case when jt.idestatus = 1 then convert(bit,1) else convert(bit,0) end idestatus
                              From dbo.CT_JUMP_TYPE jt inner join  dbo.CT_CHARGE_TYPE ct on ct.idchargetype = jt.idchargetype order by jt.orden";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Jump Type
        public DataTable ConsultaAditionalServices( String condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT cta.[id], cta.[code], cta.[Descripcion], cta.[price], ct.[idchargetype], cta.[codechargetype], cta.[idestatus], cte.descripcion as estatus, cta.idoficina, cto.nombre
                             FROM [bd_skydivecuautla].[dbo].[CT_ADITIONAL_SERVICES] cta
                            INNER JOIN dbo.CT_CHARGE_TYPE ct on ct.idchargetype = cta.[idchargetype]
                            INNER JOIN dbo.CT_ESTATUS cte on cte.idestatus = cta.idestatus  
                            INNER JOIN dbo.CT_OFICINA cto on cto.idoficina = cta.idoficina " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Payment type
        public DataTable ConsultaSourceType()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT [idsourcetype], [codigo], [Orden], [Source_Type], CASE WHEN idestatus= 1 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END IDESTATUS
                             FROM [bd_skydivecuautla].[dbo].[CT_SOURCE_TYPE] WHERE idestatus <> 4 ORDER BY Orden";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Payment type
        public DataTable ConsultaPaymenType()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT idpaymenttype,  code, sort, payment_type,  CASE WHEN idestatus= 1 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END IDESTATUS, note
                             FROM dbo.CT_PAYMENT_TYPE order by sort";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 

        #region Consulta Plane's
        public DataTable ConsultaPlane()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CTA.idaeronave, CTA.codigo, CTA.matricula, CTA.capacidadpersonas, CTA.capacidadpeso, CTA.idunidadmedida, CTA.idpiloto, CTP.nombre_piloto , 
       CTP.paterno_piloto, ctp.materno_piloto, CTP.paterno_piloto+ ', ' + CTP.nombre_piloto , CTA.altitud,  CTA.codey,
       CASE WHEN CTA.idestatus= 1 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END IDESTATUS, CTA.fechamovimiento
  FROM dbo.CT_AERONAVE CTA INNER JOIN dbo.CT_PILOTO CTP ON CTP.idpiloto = CTA.idpiloto
 WHERE CTA.idestatus <> 4";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Consulta Charge Type
        public DataTable ConsultaChargeType()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT idchargetype, codigo, sort, Grupo, charge_type, CASE WHEN IDESTATUS = 1 THEN CONVERT(BIT,1) ELSE CONVERT(BIT,0) END IDESTATUS, note   
                             FROM dbo.CT_CHARGE_TYPE  ORDER by sort";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Usuarios
        public DataTable ConsultaUsuarios( string condicion)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT USUARIO.usuario as [USER], USUARIO.nombre as [FIRST NAME], USUARIO.paterno as [LAST NAME 1], USUARIO.materno as [LAST NAME 2], USUARIO.email as [E-MAIL], PERFIL.descripcion as [USER ROL],
                                  ESTATUS.descripcion as [STATUS], OFICINA.Nombre as [OFFICE]
                             FROM dbo.CT_USUARIO USUARIO 
                            INNER JOIN dbo.CT_PERFIL PERFIL ON PERFIL.idperfil = USUARIO.idperfil
                            INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.idestatus = USUARIO.idestatus
                            INNER JOIN dbo.CT_OFICINA OFICINA ON OFICINA.idoficina = USUARIO.idoficina"  + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta Un solo Usuario
        public DataSet Consulta1Usuario(string condicion)
        {
            
            DataSet ds = new DataSet();
            string sql = @"SELECT USUARIO.usuario as [USER], USUARIO.nombre as [FIRST NAME], USUARIO.paterno as [LAST NAME 1], USUARIO.materno as [LAST NAME 2], USUARIO.email as [E-MAIL], PERFIL.descripcion as [USER ROL],
                                  ESTATUS.descripcion as [STATUS], OFICINA.Nombre as [OFFICE]
                             FROM dbo.CT_USUARIO USUARIO 
                            INNER JOIN dbo.CT_PERFIL PERFIL ON PERFIL.idperfil = USUARIO.idperfil
                            INNER JOIN dbo.CT_ESTATUS ESTATUS ON ESTATUS.idestatus = USUARIO.idestatus
                            INNER JOIN dbo.CT_OFICINA OFICINA ON OFICINA.idoficina = USUARIO.idoficina " + condicion;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Actualiza tabla en BD
        public void UpdateTabla(string setcampos, string tabla, string condicion)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" UPDATE " + tabla + " SET " + setcampos + " " + condicion;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();

        }
        #endregion

        #region Executa SP
        public void EXECSP(string storeprocedure)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" EXEC dbo." + storeprocedure ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();

        }
        #endregion


        #region Executa SP
        public void EXECquery(string Query)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" use [bd_skydivecuautla]  " + Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();

        }
        #endregion



        #region Inserta nuevo registro en tabla
        public void InsertTabla(string setcampos, string tabla, string valores)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" INSERT INTO " + tabla + " (" + setcampos + ") VALUES (" + valores + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;
            //SqlTransaction trx = cmd.Connection.BeginTransaction();
            //cmd.Transaction = trx;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();
        
        }
        #endregion

        #region Inserta nuevo registro en tabla
        public void InsertTablaQry(string setcampos, string tabla, string sql)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" INSERT INTO " + tabla + " (" + setcampos + ")  " + sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();
        }
        #endregion

        #region Borra un registro
        public void BorraRegistro(string condicion, string tabla)
        {

            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQL);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;
            cmd.CommandText = @" DELETE " + tabla + " WHERE " + condicion;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();
            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();

            
        
        }
        #endregion

    }
    #endregion
}
