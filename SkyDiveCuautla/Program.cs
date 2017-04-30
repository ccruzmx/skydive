using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace SkyDiveCuautla
{

    public static class misglobales
    {


        public static int contador = 0; // Variable utilizada para retornar valores contadores de una consulta
        public static int contadordetalle = 0; // vaiable para sumar o contar los datos de un campo de la consulta
        public static Boolean credenciales = false;
        public static int _Login = 0;  // 0 = Login Inicial    1 = FrmJumperTransactionEntires  2 = Autoriza Padlock
        public static Boolean _Autoriza = false;
        public static string _name = ""; // nombre del jumper seleccionado en el manifiesto
        public static string _manifiesto = ""; // codigo del manifiesto seleccionado
        public static string query = "";
        public static int usuario_idusuario = 1;
        public static string usuario_usuario = "";
        public static byte[] contraseña;
        public static string usuario_nombre = "";
        public static string usuario_paterno = "";
        public static string usuario_materno = "";
        public static string usuario_email = "";
        public static int perfil_idperfil = 0;
        public static string perfil_perfil = "";
        public static int oficina_id_oficina = 0;
        public static string oficina_oficina = "";
        public static int estatus_idestatus = 0;
        public static string estatus_estatus = "";
        public static int entidad_identidad = 0;
        public static string entidad_entidad = "";
        public static string usuario_autenticacion = "";
        public static string servername = "local";
        public static string cadenaconexionSQL = "data source="+servername+"; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False; Connect Timeout=120"; //conexion local fuera de linea
        public static string cadenaconexionSQLmaster = "data source=" + servername + "; initial catalog=msdb; user ID=sa; password=67yhju%; Trusted_Connection=False;"; //conexion local fuera de linea
        public static Int32 id1 = 0; //id de la tabla manifiesto
        public static Int32 numero_de_vuelo; //Es el número de vuelo
        public static Int32 id2 = 0;
        public static string iniciovuelo = "";
        public static string cronometrodevuelo = "";
        public static Int32 ontime = 0;
        public static Int32 manifiestomin=20, manifiestoseg=59, maifiestocentesimas=100;
        public static Int32 idvuelo1=0, idvuelo2=0, idvuelo3=0;
        public static string desvuelo1 = "CLOSED", desvuelo2 = "CLOSED", desvuelo3 = "CLOSED";
        public static Int32 vuelo1min = 20, vuelo1seg = 59, vuelo1centesimas = 100;
        public static Int32 vuelo2min = 20, vuelo2seg = 59, vuelo2centesimas = 100;
        public static Int32 vuelo3min = 20, vuelo3seg = 59, vuelo3centesimas = 100;
        public static string ontime1 = "ON-TIME", ontime2 = "ON-TIME", ontime3 = "ON-TIME";
        public static string monidvuelo1 = "", monidvuelo2 = "", monidvuelo3 = "";
        public static string jumper_code_list = "";
        public static string jumper_code = "";
        public static int jumperid = 0;
        public static string jumptype = "";
        public static Int32 jumper_from_tandemup = 0;
        public static string matricula_info = "";
        public static Boolean _readjumper = false;
        public static Decimal _TotalBalance = 0;
        public static Boolean _utilizandoPayment = false;
        public static String _TransaccionLedger = "";
        public static Int32 _BreakDown = 0;   //0 cuando alamacenará el dato en dbo.TB_BREAKEDOWN  y 1 en la tabla dbo.TB_BREAKDOWNTANDEM
        public static Int32 _idpaymenttype = 2;  //2  cash
        public static decimal _payment = 0;
        public static String _DateIni, _DateFin;
        public static string _tandemupcode = "";
        public static Int32 _idtandemup = 0;
        public static string _codetandemup = "";
        public static Int32 _Importing = 0;
        public static string _Objeto = "";
        public static Int32 AgregandoPreManifiesto = 0;
        public static Int32 TandemSelection = 0;
        public static Boolean TicketActualizado = false;
        public static String TicketElegido = "";
        public static String NombreParaTicket = "";
        public static Boolean ActualizandoTransaccion = false;
        public static Int32 idJumperTandem = 1207;
        public static Int32 NumeroReservacion = 0;
        public static DateTime FechaMovimiento ;
        public static String TandemName = "";
        public static decimal TandemJumpPrice = 0;
        public static decimal TandemVideoPrice = 0;
        public static decimal TandemHandVideoPrice = 0;
        public static Int32 QuienSaltaid = 0;
        public static String QuienSaltaname = "";
        public static Int32 QuienPaga = 0;
        public static String QuienPaganame = "";
        public static Int32 ListoPaidBy = 0;
        public static String PaidByMatricula = "";
        public static String PaidByFlightCode = "";
        public static Int32 dropzone = 1;
        public static DateTime Rangoini;
        public static DateTime Rangofin;
        public static Int32 _impresora_height=240;
        public static String _impresora;
        public static String _sysversion = "0";
        public static Boolean _conectando = false;
        public static DateTime _Updatedate = DateTime.Now;
        public static Boolean BreakdownOpen = false;
        public static String _HistoryJumper = "Frm_HistoryJumper";
    } 

    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new acceso());

            if (   (misglobales.credenciales) && (misglobales.perfil_idperfil != 2))
            {

            Application.Run(new MDISkyDiveCuautla());

            }
            else if (    (misglobales.credenciales) && (misglobales.perfil_idperfil == 2))
            {
                //Application.Run(new MDISkyDiveCuautla());
                Application.Run(new Reservaciones.Frm_MenuReservas() );  // Este se habilita cuando se requiera cambiar el acceso a Reservas

            }
        }
    }
}
