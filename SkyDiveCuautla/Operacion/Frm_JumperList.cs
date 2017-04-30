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
    public partial class Frm_JumperList : Form
    {

        string condicion = "";
        ConectaBD conexion = new ConectaBD();

        #region Contructor de la Frm_JumperLis
        public Frm_JumperList()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento click del btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region InicializaGridView
        public void InicializaGrid()
        {
            condicion = @" order by j.codigo";
            dg_jumperlist.EnableHeadersVisualStyles = false;
            dg_jumperlist.DataSource = conexion.ConsultaJumperList(condicion);
            dg_jumperlist.Columns[0].Width = 100; //ID
            dg_jumperlist.Columns[1].Width = 50; //Active
            dg_jumperlist.Columns[2].Width = 100; //Date Entered
            dg_jumperlist.Columns[3].Width = 100; //First Name
            dg_jumperlist.Columns[4].Width = 100; //Last Name
            dg_jumperlist.Columns[5].Width = 100; //Balance
            dg_jumperlist.Columns[6].Width = 100; //Jump Type
            dg_jumperlist.Columns[7].Width = 100; //Jumper Type
            dg_jumperlist.Columns[8].Width = 100; //Alias
            dg_jumperlist.Columns[9].Width = 100; //# Jumps
            dg_jumperlist.Columns[10].Width = 100; //Last Jump
            dg_jumperlist.Columns[11].Width = 100; //Address
            dg_jumperlist.Columns[12].Width = 100; //Address cont...
            dg_jumperlist.Columns[13].Width = 100; //City
            dg_jumperlist.Columns[14].Width = 100; //state
            dg_jumperlist.Columns[15].Width = 100; //Country
            dg_jumperlist.Columns[16].Width = 100; //Postal Code
            dg_jumperlist.Columns[17].Width = 100; //Home Phone
            dg_jumperlist.Columns[18].Width = 100; //Work Phone
            dg_jumperlist.Columns[19].Width = 100; //Fax
            dg_jumperlist.Columns[20].Width = 100; //Mobile Phone
            dg_jumperlist.Columns[21].Width = 100; //Other Phone
            dg_jumperlist.Columns[22].Width = 100; //e-Mail
            dg_jumperlist.Columns[23].Width = 100; //nextel
            dg_jumperlist.Columns[24].Width = 100; //Equipment
            dg_jumperlist.Columns[25].Width = 100; //Reserve Repack
            dg_jumperlist.Columns[26].Width = 100; //USPA Member
            dg_jumperlist.Columns[27].Width = 100; //USPA Licence
            dg_jumperlist.Columns[28].Width = 100; //USPA Expires
            dg_jumperlist.Columns[29].Width = 100; //Source
            dg_jumperlist.Columns[30].Width = 100; //Reference
            dg_jumperlist.Columns[31].Width = 100; //Waiver Expires
            dg_jumperlist.Columns[32].Width = 100; //Locker
            dg_jumperlist.Columns[33].Width = 50; //All Day Jump
            dg_jumperlist.Columns[34].Width = 50; //Allow Trans. w/no balance
            dg_jumperlist.Columns[35].Width = 50; //Allow Change Jump Type
            dg_jumperlist.Columns[36].Width = 50; //Allow Paid By
            dg_jumperlist.Columns[37].Width = 50; //Allow First Jumpe Chance
            dg_jumperlist.Columns[38].Width = 50; //First Jump Taken
            dg_jumperlist.Columns[39].Width = 200; //Note
            dg_jumperlist.Columns[40].Width = 200; //Medical Insurance
            dg_jumperlist.Columns[40].Visible = false;
            dg_jumperlist.Columns[41].Width = 200; //credit card
            dg_jumperlist.Columns[41].Visible = false;


            utilerias u = new utilerias();
            u.Formatodgv(dg_jumperlist);
        
        }
        #endregion 

        #region Evento Load del Frm_JumperList
        private void Frm_JumperList_Load(object sender, EventArgs e)
        {
            InicializaGrid();
        }
        #endregion 

        #region Evento doble click en la celda del dg_jumperlist
        private void dg_jumperlist_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            misglobales.jumper_code_list = dg_jumperlist.Rows[dg_jumperlist.CurrentRow.Index].Cells[0].Value.ToString();
            this.Close();
        }
        #endregion



    }
}
