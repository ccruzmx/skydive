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
    public partial class Frm_RUD : Form
    {

        utilerias u = new utilerias();
        String condicion, sql, tabla;
        ConectaBD conexion = new ConectaBD();


        public Frm_RUD()
        {
            InitializeComponent();
        }

        #region Evento Load de la forma frm_RUD
        private void Frm_RUD_Load(object sender, EventArgs e)
        {
            inicializagridview();
        }
        #endregion


        #region Inicializa grid del Ledger
        private void inicializagridview()
        {
            dg_rud.Visible = true;
            dg_rud.EnableHeadersVisualStyles = false;
            sql = @" SELECT isnull(CURP,'') as CURP, name AS NOMBRE, lastname AS PATERNO, idgender AS GENERO, GRADE AS ESCOLARIDAD, 'PARACAIDISMO' AS DEPORTE,  [state] AS ESTADO, address2 AS COLONIA,
                            address1 AS CALLE, postal_code AS [CODIGO POSTAL], email AS CORREO, home_phone AS TELEFONO, 'Centro Deportivo de Paracaidismo Cuautla A.C' AS CLUB, 
                            'Skydive Cuautla' AS [ZONA DE OPERACIÓN], DATEBEGINSPORT [TIEMPO PRACTICANDO], INSTRUCTOR_NAME [NOMBRE DE SU INSTRUCTOR]
                                       /*,(SELECT CTR.short_description
                                          FROM TB_JUMPER_RATINGS JR 
                                          INNER JOIN CT_RATINGS CTR ON CTR.idratings = JR.idratings
                                         WHERE JR.idjumper = idjumper) AS HABILIDADES*/
                            ,'ANPAD' AS [ASOCIACIÓN NACIONAL QUE NORMA SU ESPECIALIDAD], licencetype + '-' + USPA_Licence AS [TIPO DE LICENCIA QUE POSEE], 
                            USPA_Expires AS [VIGENCIA DE LICENCIA], BORNDATE AS [EDAD], BORNDATE AS [FECHA NACIMIENTO], 'Paracaidismo Deportivo ' AS [ESPECIALIDAD AERODEPORTICA]
                       FROM CT_JUMPER";
            tabla = "CT_JUMPER";
            condicion = @"  order by NAME";
            dg_rud.DataSource = conexion.ConsultaUniversalDT(sql, condicion, tabla);
            dg_rud.Columns[0].Width = 200; // CURP
            dg_rud.Columns[0].Visible = true;


            //dg_ledger.DataSource = conexion.ShowLedger(sql, condicion);
            //dg_ledger.Columns[0].Width = 150; //UPDATEDATE
            //dg_ledger.Columns[1].Width = 100; //Charge type
            //dg_ledger.Columns[2].Width = 150; //Jump type
            //dg_ledger.Columns[3].Width = 200; //Name
            //dg_ledger.Columns[4].Width = 100; //charge
            //dg_ledger.Columns[5].Width = 100; //payment
            //dg_ledger.Columns[6].Width = 100; //Staff Pay
            //dg_ledger.Columns[7].Width = 100; //Transfer ATM
            //dg_ledger.Columns[8].Width = 150; //Transfer Jumper
            //dg_ledger.Columns[9].Width = 160; //idoficina
            //dg_ledger.Columns[9].Visible = false;
            //dg_ledger.Columns[10].Width = 160; //Nombre Oficina
            //dg_ledger.Columns[11].Width = 70; //Numero Vuelo
            //dg_ledger.Columns[12].Width = 70; //Matricula
            //dg_ledger.Columns[13].Width = 125; //Fecha Vuelo
            //dg_ledger.Columns[14].Width = 350; //Note
            //dg_ledger.Columns[15].Width = 250; //idusuario
            //dg_ledger.Columns[15].Visible = false;
            //dg_ledger.Columns[16].Width = 250; //Usuario Sistema

            //dg_ledger.Columns[0].HeaderText = "Date Operation";
            //dg_ledger.Columns[1].HeaderText = "Charge Type";
            //dg_ledger.Columns[2].HeaderText = "Jump type";
            //dg_ledger.Columns[3].HeaderText = "Jumper/Tandem Name";
            //dg_ledger.Columns[4].HeaderText = "Charge";
            //dg_ledger.Columns[5].HeaderText = "Payment";
            //dg_ledger.Columns[6].HeaderText = "Staff Payment";
            //dg_ledger.Columns[7].HeaderText = "Transfer ATM";
            //dg_ledger.Columns[8].HeaderText = "Transfer Jumper";
            //dg_ledger.Columns[10].HeaderText = "Dropzone";
            //dg_ledger.Columns[11].HeaderText = "Flight Number";
            //dg_ledger.Columns[12].HeaderText = "Aircraft";
            //dg_ledger.Columns[13].HeaderText = "Flight Date";
            //dg_ledger.Columns[14].HeaderText = "Note";
            //dg_ledger.Columns[16].HeaderText = "User System";

            //u.Formatodgv(dg_ledger);
            //conexion.CloseDB();

            //lbl_jumpername.Text = misglobales.jumper_code;

            u.Formatodgv(dg_rud);
            conexion.CloseDB();


        }
        #endregion

    }
}
