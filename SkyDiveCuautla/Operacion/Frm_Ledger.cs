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
    public partial class Frm_Ledger : Form
    {

        utilerias u = new utilerias();
        String condicion, sql, tabla;
        ConectaBD conexion = new ConectaBD();

        public Frm_Ledger()
        {
            InitializeComponent();
        }


        #region Inicializa grid del Ledger
        private void inicializagridview()
        {
            dg_ledger.EnableHeadersVisualStyles = false;
            sql = @" SELECT tbl.updatedate, CTCT.charge_type as [Charge Type], tbl.codigo_jumptype as [JumpType], tbl.name, tbl.charge, 
                            tbl.payment, tbl.staff_payment, tbl.transfer_amt, tbl.transfer_jumper_name, 
                            tbl.idoficina, cto.Nombre, tbv.numerovuelo,  CTA.matricula  , tbv.fechaabrevuelo,
                            tbl.nota, tbl.idusuario, 
                            ctu.nombre + ' ' + ctu.paterno + ' ' + ctu.materno as [User]
                       FROM TB_LEDGER tbl with(nolock) 
                      INNER JOIN CT_USUARIO ctu on ctu.idusuario = tbl.idusuario
                      INNER JOIN CT_OFICINA cto on cto.idoficina = tbl.idoficina
                       LEFT OUTER JOIN TB_VUELOS tbv on tbv.idvuelo = tbl.idmanifiesto 
                       LEFT OUTER JOIN CT_AERONAVE CTA ON CTA.idaeronave = TBV.idaeronave
                       LEFT OUTER JOIN dbo.CT_CHARGE_TYPE CTCT ON CTCT.codigo = TBL.idchargetype";
            tabla = "TB_LEDGER";
            condicion = @" WHERE tbl.jumper_code = '" + misglobales.jumper_code + "' order by tbl.updatedate desc";
            dg_ledger.DataSource = conexion.ShowLedger(sql, condicion);
            dg_ledger.Columns[0].Width = 150; //UPDATEDATE
            dg_ledger.Columns[1].Width = 100; //Charge type
            dg_ledger.Columns[2].Width = 150; //Jump type
            dg_ledger.Columns[3].Width = 200; //Name
            dg_ledger.Columns[4].Width = 100; //charge
            dg_ledger.Columns[5].Width = 100; //payment
            dg_ledger.Columns[6].Width = 100; //Staff Pay
            dg_ledger.Columns[7].Width = 100; //Transfer ATM
            dg_ledger.Columns[8].Width = 150; //Transfer Jumper
            dg_ledger.Columns[9].Width = 160; //idoficina
            dg_ledger.Columns[9].Visible = false;
            dg_ledger.Columns[10].Width = 160; //Nombre Oficina
            dg_ledger.Columns[11].Width = 70; //Numero Vuelo
            dg_ledger.Columns[12].Width = 70; //Matricula
            dg_ledger.Columns[13].Width = 125; //Fecha Vuelo
            dg_ledger.Columns[14].Width = 350; //Note
            dg_ledger.Columns[15].Width = 250; //idusuario
            dg_ledger.Columns[15].Visible = false;
            dg_ledger.Columns[16].Width = 250; //Usuario Sistema

            dg_ledger.Columns[0].HeaderText = "Date Operation";
            dg_ledger.Columns[1].HeaderText = "Charge Type";
            dg_ledger.Columns[2].HeaderText = "Jump type";
            dg_ledger.Columns[3].HeaderText = "Jumper/Tandem Name";
            dg_ledger.Columns[4].HeaderText = "Charge";
            dg_ledger.Columns[5].HeaderText = "Payment";
            dg_ledger.Columns[6].HeaderText = "Staff Payment";
            dg_ledger.Columns[7].HeaderText = "Transfer ATM";
            dg_ledger.Columns[8].HeaderText = "Transfer Jumper";
            dg_ledger.Columns[10].HeaderText = "Dropzone";
            dg_ledger.Columns[11].HeaderText = "Flight Number";
            dg_ledger.Columns[12].HeaderText = "Aircraft";
            dg_ledger.Columns[13].HeaderText = "Flight Date";
            dg_ledger.Columns[14].HeaderText = "Note";
            dg_ledger.Columns[16].HeaderText = "User System";

            u.Formatodgv(dg_ledger);
            conexion.CloseDB();

            lbl_jumpername.Text = misglobales.jumper_code;
        }
        #endregion

        private void Frm_Ledger_Load(object sender, EventArgs e)
        {
            
            inicializagridview();

        }
    }
}
