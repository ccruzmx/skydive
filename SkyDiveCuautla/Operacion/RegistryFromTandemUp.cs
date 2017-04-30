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
    public partial class RegistryFromTandemUp : Form
    {
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        string condicion, campos, sql, tabla;
        Int32 Capacidad = misglobales.jumper_from_tandemup;
        Int32 Conteo = 0;



        #region Constructor RegistryFromTandemUp
        public RegistryFromTandemUp()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento Click del btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview()
        {
            condicion = @"WHERE /*tandemup.RELEASE = 1 AND */tandemup.MANIFESTed = 0 AND
                          ( YEAR(tandemup.reserved_date) = YEAR(GETDATE()) AND MONTH(tandemup.reserved_date) = MONTH(GETDATE()) AND DAY(tandemup.reserved_date) = DAY(GETDATE()) )
                          ORDER BY tandemup.SEQUENCE";

            dg_tandemup.EnableHeadersVisualStyles = false;
            dg_tandemup.DataSource = conexion.ConsultaTandemUpManifest(condicion);  //getdata(fuente;
            dg_tandemup.Columns[0].Width = 25; //IDTANDEMUP
            dg_tandemup.Columns[0].Visible = false;
            dg_tandemup.Columns[1].Width = 50; //SEQUENCE
            dg_tandemup.Columns[1].Visible = false;

            dg_tandemup.Columns[2].Width = 130; //NAME
            dg_tandemup.Columns[2].Visible = true;
            dg_tandemup.Columns[3].Width = 130; //LASTNAME
            dg_tandemup.Columns[3].Visible = true;        

            dg_tandemup.Columns[4].Width = 130; //JUMP TYPE
            dg_tandemup.Columns[4].Visible = true;
        
            dg_tandemup.Columns[5].Width = 100; //RESERVED_DATE
            dg_tandemup.Columns[5].Visible = true;
            dg_tandemup.Columns[6].Width = 100; //MANIFESTED
            dg_tandemup.Columns[6].Visible = true;

            
            
            dg_tandemup.Columns[2].HeaderText = "Name";
            dg_tandemup.Columns[3].HeaderText = "Last Name";
            dg_tandemup.Columns[4].HeaderText = "Jump Type";
            dg_tandemup.Columns[5].HeaderText = "Reserved For";
            dg_tandemup.Columns[5].HeaderText = "Select";
            u.Formatodgv(dg_tandemup);
            dg_tandemup.ReadOnly = false;
    
        }
        #endregion 

        #region Inicializa Objetos
        private void InicializaObjetos()
        {
           Lbl_FlightCode.Text = misglobales.id1.ToString();
           Lbl_matriculainfo.Text = misglobales.matricula_info.ToString();
           txb_capacity.Enabled = true;
           txb_capacity.Text = Capacidad.ToString();
           txb_capacity.Enabled = false;
        }
        #endregion 


        private void RegistryFromTandemUp_Load(object sender, EventArgs e)
        {
 
            InicializaObjetos();
        }

        private void RegistryFromTandemUp_Activated(object sender, EventArgs e)
        {
            inicializagridview();
        }

        private void dg_tandemup_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Conteo < misglobales.jumper_from_tandemup)
            {
                for (int i = e.RowIndex + 1; i <= dg_tandemup.Rows.Count - 1; i++)
                {
                    dg_tandemup.Rows[i].Cells[6].ReadOnly = false;
                }
                dg_tandemup.CellMouseClick -= new DataGridViewCellMouseEventHandler(dg_tandemup_CellMouseClick);
            }
        }




        private void dg_tandemup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dg_tandemup.Rows[e.RowIndex];
            //DataGridViewCheckBoxCell cellSelecion = row.Cells[6] as DataGridViewCheckBoxCell;
            //if (Convert.ToBoolean(cellSelecion.Value))
            //{
            //    Conteo += 1;
            //    txb_capacity.Text = Convert.ToString(Capacidad - Conteo);
            //}
            //else
            //{
            //    Conteo -= 1;
            //    txb_capacity.Text = Convert.ToString(Capacidad - Conteo);
            //}

            //if (Conteo > misglobales.jumper_from_tandemup)
            //{
            //    cellSelecion.Value = false;

            //}
            //btn_registry.Focus();

        }

        private void dg_tandemup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dg_tandemup.Rows[e.RowIndex];
            DataGridViewCheckBoxCell cellSelecion = row.Cells[6] as DataGridViewCheckBoxCell;


            //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[6];
            //if (chk.Selected == true)
            //{
            //    Conteo += 1;
            //    txb_capacity.Text = Convert.ToString(Capacidad - Conteo);
            //}
            //else
            //{
            //    Conteo -= 1;
            //    txb_capacity.Text = Convert.ToString(Capacidad - Conteo);
            //}


            if (Convert.ToBoolean(cellSelecion.Value) == false)
            {
                Conteo += 1;
                txb_capacity.Text = Convert.ToString(Capacidad - Conteo);
            }
            else
            {
                Conteo -= 1;
                txb_capacity.Text = Convert.ToString(Capacidad - Conteo);
            }

            if (Conteo > misglobales.jumper_from_tandemup)
            {
                cellSelecion.Value = false;

            }
     
        }



    }
}
