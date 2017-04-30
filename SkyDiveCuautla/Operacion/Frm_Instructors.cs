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
    public partial class Frm_Instructors : Form
    {
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        string campos, sql, tabla, condicion;

        #region Constructor de la forma Frm_Instructor
        public Frm_Instructors()
        {
            InitializeComponent();
        }
        #endregion 

        #region Evento click del boton Exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region CargaCampos
        public void cargacampos()
        {
            sql = @" select idjumper, nombre from dbo.CT_JUMPER ";
            tabla = "CT_JUMPER";
            condicion = " where idestatus = 1 order by nombre ";
            DataSet dsinstructor = conexion.ConsultaUniversal(sql,condicion, tabla);

            cmb_instructor.DataSource = dsinstructor.Tables[0].DefaultView;
            cmb_instructor.AutoCompleteCustomSource = LoadAutoComplete(dsinstructor, "nombre");
            cmb_instructor.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_instructor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_instructor.ValueMember = "nombre";
            cmb_instructor.SelectedItem = null;

            chk_video.Checked = false;
            chk_videomano.Checked = false;
            chk_tandem.Checked = false;
            chk_videorent.Checked = false;


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

        #region Inicializa DataGridView de Tandem Up
        private void inicializagridview()
        {
            condicion = @" WHERE CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  ORDER BY CONVERT(VARCHAR(8), REGISTERTIME, 108) asc ";

            dg_instructors.EnableHeadersVisualStyles = false;
            dg_instructors.DataSource = conexion.ConsultaInstructores(condicion);  //getdata(fuente;
            dg_instructors.Columns[0].Width = 25; //ID 
            dg_instructors.Columns[0].Visible = false;
            dg_instructors.Columns[1].Width = 25; //IDjumper 
            dg_instructors.Columns[1].Visible = false;
            dg_instructors.Columns[2].Width = 100; //sequence 
            dg_instructors.Columns[2].Visible = true;
            dg_instructors.Columns[3].Width = 200; //registertime 
            dg_instructors.Columns[3].Visible = true;
            dg_instructors.Columns[4].Width = 385; //name 
            dg_instructors.Columns[4].Visible = true;
            dg_instructors.Columns[5].Width = 100; //video 
            dg_instructors.Columns[5].Visible = true;
            dg_instructors.Columns[6].Width = 100; //Handvideo 
            dg_instructors.Columns[6].Visible = true;
            dg_instructors.Columns[7].Width = 100; //Video Rent
            dg_instructors.Columns[7].Visible = true;
            dg_instructors.Columns[8].Width = 100; //Tandem
            dg_instructors.Columns[8].Visible = true;
            dg_instructors.Columns[9].Width = 150; // Busy
            dg_instructors.Columns[9].Visible = false;
            dg_instructors.Columns[10].Width = 150; //jumps_premanifested
            dg_instructors.Columns[10].Visible = true;
            dg_instructors.Columns[11].Width = 150; //jumps_manifested 
            dg_instructors.Columns[11].Visible = true;
            dg_instructors.Columns[12].Width = 150; //jumps_rejected
            dg_instructors.Columns[12].Visible = true;
            dg_instructors.Columns[13].Width = 150; //jumps_totals
            dg_instructors.Columns[13].Visible = true;


            dg_instructors.Columns[2].HeaderText = "Seq";
            dg_instructors.Columns[3].HeaderText = "Register Time";
            dg_instructors.Columns[4].HeaderText = "Name";
            dg_instructors.Columns[5].HeaderText = "Video";
            dg_instructors.Columns[6].HeaderText = "Hand Video";
            dg_instructors.Columns[7].HeaderText = "Video Rent";
            dg_instructors.Columns[8].HeaderText = "Tandem";
            dg_instructors.Columns[9].HeaderText = "Busy";
            dg_instructors.Columns[10].HeaderText = "# Jumps pre manifested";
            dg_instructors.Columns[11].HeaderText = "# Jumps manifested";
            dg_instructors.Columns[12].HeaderText = "# Jumps rejected";
            dg_instructors.Columns[13].HeaderText = "TOTAL JUMPS";

            u.Formatodgv(dg_instructors);

        }
        #endregion

        #region Load de la forma Frm_Instructors
        private void Frm_Instructors_Load(object sender, EventArgs e)
        {

            lbl_registertime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cargacampos();
            inicializagridview();
            
        }
        #endregion 

        #region Evento click del boton Add
        private void btn_add_Click(object sender, EventArgs e)
        {
            //almacena Instructor
            if (cmb_instructor.Text != "")
            {

                try
                {
                    if (InserUpdate(condicion) == "insert")
                    {
                        if (txb_jumpsrejected.Text == "") { txb_jumpsrejected.Text = "0"; }
                        tabla = "tb_instructors_activity";
                        campos = "idjumper, sequence, registertime,  name, video, handvideo, tandem, busy, jumps_premanifested, jumps_manifested, jumps_rejected, jumps_totals, videorent";
                        sql = @"select idjumper, (select isnull(MAX(sequence)+1,1) from dbo.tb_instructors_activity with(nolock) where CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)), 
                           GETDATE(), nombre, " + Convert.ToByte(chk_video.Checked) + ", " + Convert.ToByte(chk_videomano.Checked) + ", " + Convert.ToByte(chk_tandem.Checked) + @", 0, 0, 0, "+txb_jumpsrejected.Text+@", 0, "+ Convert.ToByte(chk_videorent.Checked)+ @"
                      from dbo.CT_JUMPER 
                     where nombre = '" + cmb_instructor.Text + "'";
                        conexion.InsertTablaQry(campos, tabla, sql);


                        tabla = "tb_instructors_blackboard";
                        campos = "idjumper, registertime, name, idoficina";
                        sql = @"     select idjumper, GETDATE(), nombre, " + misglobales.oficina_id_oficina + 
                               @"      from dbo.CT_JUMPER  
                                      where nombre = '" + cmb_instructor.Text + "'";
                        conexion.InsertTablaQry(campos, tabla, sql);
                    }
                    else
                    {
                        if (txb_jumpsrejected.Text == "") { txb_jumpsrejected.Text = "0"; }
                        //update
                        tabla = "tb_instructors_activity";
                        campos = " video = " + Convert.ToByte(chk_video.Checked)  + "," +
                                 " handvideo = " + Convert.ToByte(chk_videomano.Checked) + ", " +
                                 " videorent = " + Convert.ToByte(chk_videorent.Checked) + ", " +
                                 " tandem = "  + Convert.ToByte(chk_tandem.Checked) + ", " +
                                 " jumps_rejected = " + txb_jumpsrejected.Text + ", " +
                                 " sequence = " + txb_seq.Text + "," +
                                 " jumps_totals =  jumps_premanifested	+ jumps_manifested	+" + txb_jumpsrejected.Text;
                        condicion = " where name = '" + cmb_instructor.Text +"'";
                        conexion.UpdateTabla(campos, tabla, condicion);
                        txb_seq.Visible = false;
                    }
                    cargacampos();
                    inicializagridview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try registry instructor " + ex.Message);
                }
            }
            cmb_instructor.Focus();
        }
        #endregion 

        #region evento Clik en una celda del grid dg_instructors
        private void dg_instructors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_seq.Visible = true;
            txb_seq.Text = Convert.ToString(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[2].Value);
            cmb_instructor.SelectedValue = Convert.ToString(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[4].Value);
            chk_video.Checked = Convert.ToBoolean(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[5].Value);
            chk_videomano.Checked = Convert.ToBoolean(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[6].Value);
            chk_videorent.Checked = Convert.ToBoolean(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[7].Value);
            chk_tandem.Checked = Convert.ToBoolean(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[8].Value);
            txb_jumpsrejected.Text = Convert.ToString(dg_instructors.Rows[dg_instructors.CurrentRow.Index].Cells[12].Value);
        }
        #endregion 

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            sql = @"select * from tb_instructors_activity ";
            condicion = " where name = '" + cmb_instructor.Text + "' and CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)";
            ds = conexion.ConsultaUniversal(sql, condicion, "tb_instructors_activity");

            if (ds.Tables[0].Rows.Count == 0)
            {
                return "insert";
            }
            else
            {
                return "update";
            }
        }
        #endregion

        #region Evento UserDeletedrow del grid dg_instructors
        private void dg_instructors_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            cargacampos();
            inicializagridview();
            MessageBox.Show("Record deleted successfuly");
        }
        #endregion 

        #region Evento UserDeletingRow del grid dg_instructors
        private void dg_instructors_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("are you sure delete this record ?", "Warning", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                //Borrar
                string condicion = " name = '" + cmb_instructor.Text + "' and CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) ";
                try
                {
                    conexion.BorraRegistro(condicion, "tb_instructors_activity");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try delete instructor" + ex.Message);
                }

            }
        }
        #endregion 

        #region Evento click del boton blackboard
        private void btn_blackboard_Click(object sender, EventArgs e)
        {
            Frm_Instructors_blackboard FrmRegistry = new Frm_Instructors_blackboard();
            FrmRegistry.MdiParent = MDISkyDiveCuautla.ActiveForm;
            FrmRegistry.WindowState = FormWindowState.Maximized;
            FrmRegistry.Show();
        }
        #endregion 

        #region Evento keypress del txb_jumpsrejected
        private void txb_jumpsrejected_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
        }
        #endregion


        #region Evento Checked del check box chk_videomano
        private void chk_videomano_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_videomano.Checked == true)
            //{
            //    chk_videorent.Checked = false;
            //}
            
        }
        #endregion 

        #region Evento Checked del check box chk_videorent
        private void chk_videorent_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_videorent.Checked == true)
            //{
            //    chk_videomano.Checked = false;
            //}

        }
        #endregion 






    }
}
