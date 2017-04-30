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
    public partial class Frm_Instructors_blackboard : Form
    {

        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        string campos, sql, tabla, condicion;


    public Frm_Instructors_blackboard()
    {
        InitializeComponent();
    }

    private void btn_exit_Click(object sender, EventArgs e)
    {
        this.Close();
    }


    #region Inicializa DataGridView de Tandem Up
    private void inicializagridview()
    {
        condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  ORDER BY CONVERT(VARCHAR(8), REGISTERTIME, 108) asc ";

        dg_blackboard.EnableHeadersVisualStyles = false;
        dg_blackboard.DataSource = conexion.ConsultaBlackboardInstructores(condicion);  //getdata(fuente;
        dg_blackboard.Columns[0].Width = 25; //ID 
        dg_blackboard.Columns[0].Visible = false;
        dg_blackboard.Columns[1].Width = 25; //IDJUMPER
        dg_blackboard.Columns[1].Visible = false;
        dg_blackboard.Columns[2].Width = 150; //REGISTERTIME
        dg_blackboard.Columns[2].Visible = false;
        dg_blackboard.Columns[3].Width = 250; //NAME
        dg_blackboard.Columns[3].Visible = true;

        dg_blackboard.Columns[4].Width = 100; //V1
        dg_blackboard.Columns[4].Visible = true;
        dg_blackboard.Columns[5].Width = 100; //V2
        dg_blackboard.Columns[5].Visible = true;
        dg_blackboard.Columns[6].Width = 100; //V3
        dg_blackboard.Columns[6].Visible = true;
        dg_blackboard.Columns[7].Width = 100; //V4
        dg_blackboard.Columns[7].Visible = true;
        dg_blackboard.Columns[8].Width = 100; //V5
        dg_blackboard.Columns[8].Visible = true;
        dg_blackboard.Columns[9].Width = 100; //V6
        dg_blackboard.Columns[9].Visible = true;
        dg_blackboard.Columns[10].Width = 100; //V7
        dg_blackboard.Columns[10].Visible = true;
        dg_blackboard.Columns[11].Width = 100; //V8
        dg_blackboard.Columns[11].Visible = true;
        dg_blackboard.Columns[12].Width = 100; //V9
        dg_blackboard.Columns[12].Visible = true;
        dg_blackboard.Columns[13].Width = 100; //V10
        dg_blackboard.Columns[13].Visible = true;
        dg_blackboard.Columns[14].Width = 100;
        dg_blackboard.Columns[14].Visible = true;//v11
        dg_blackboard.Columns[15].Width = 100;
        dg_blackboard.Columns[15].Visible = true;//v12
        dg_blackboard.Columns[16].Width = 100;
        dg_blackboard.Columns[16].Visible = true;//v13
        dg_blackboard.Columns[17].Width = 100;
        dg_blackboard.Columns[17].Visible = true;//v14
        dg_blackboard.Columns[18].Width = 100;
        dg_blackboard.Columns[18].Visible = true;//v15
        dg_blackboard.Columns[19].Visible = false;//v16
        dg_blackboard.Columns[20].Visible = false;//v17
        dg_blackboard.Columns[21].Visible = false;//v18
        dg_blackboard.Columns[22].Visible = false;//v19
        dg_blackboard.Columns[23].Visible = false;//v20



        dg_blackboard.Columns[3].HeaderText = "INSTRUCTOR";

        
        u.Formatodgv(dg_blackboard);



    }
    #endregion

    private void Frm_Instructors_blackboard_Load(object sender, EventArgs e)
    {
        inicializagridview();
    }






    }
}
