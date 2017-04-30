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
    public partial class Frm_ElegirTicket : Form
    {

        String sql, _code, condicion, campos, tabla, _idticketbalance;
        DataSet dsjumper, dsjumptype;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();

        public Frm_ElegirTicket()
        {
            InitializeComponent();
        }


        #region Inicializa DataGridView
        private void inicializagridview()
        {
            condicion = @"  where ttb.idestatus = 1 and ttb.nombre = '" + misglobales.NombreParaTicket + "'";
            dg_tickets.EnableHeadersVisualStyles = false;
            dg_tickets.DataSource = conexion.ConsultaTickets(condicion);  //getdatcmba(fuente;
            dg_tickets.Columns[0].Width = 25; //ID
            dg_tickets.Columns[0].Visible = false;
            dg_tickets.Columns[1].Width = 25; //idjumper
            dg_tickets.Columns[1].Visible = false;
            dg_tickets.Columns[2].Width = 25; //codejumper
            dg_tickets.Columns[2].Visible = false;
            dg_tickets.Columns[3].Width = 25; //nombre
            dg_tickets.Columns[3].Visible = false;
            dg_tickets.Columns[4].Width = 200; //folioticket
            dg_tickets.Columns[4].Visible = true;
            dg_tickets.Columns[5].Width = 200; //jumptypecode
            dg_tickets.Columns[5].Visible = true;
            dg_tickets.Columns[6].Width = 150; //price
            dg_tickets.Columns[6].Visible = true;
            dg_tickets.Columns[7].Width = 200; //updatedate
            dg_tickets.Columns[7].Visible = true;
            dg_tickets.Columns[8].Width = 200; //validity
            dg_tickets.Columns[8].Visible = true;
            dg_tickets.Columns[9].Width = 25; //IDoficina
            dg_tickets.Columns[9].Visible = false;
            dg_tickets.Columns[10].Width = 300; //office name
            dg_tickets.Columns[10].Visible = false;
            dg_tickets.Columns[11].Width = 100; //active
            dg_tickets.Columns[11].Visible = true;
            dg_tickets.Columns[12].Width = 300; //nota
            dg_tickets.Columns[12].Visible = true;

            u.Formatodgv(dg_tickets);



        }
        #endregion


        private void Frm_ElegirTicket_Load(object sender, EventArgs e)
        {
            lbl_nombre.Text = misglobales.NombreParaTicket;
            inicializagridview();
        }

        private void dg_tickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            misglobales.TicketElegido = dg_tickets.Rows[dg_tickets.CurrentRow.Index].Cells[4].Value.ToString() ;
            misglobales.TicketActualizado = true;
            this.Close();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            misglobales.TicketElegido = "";
            misglobales.TicketActualizado = true;
            this.Close();
        }
    }
}
