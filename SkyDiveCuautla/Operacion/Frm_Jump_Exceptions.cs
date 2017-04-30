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
    public partial class Frm_Jump_Exceptions : Form
    {

        #region Variables
        string valores, campos, tabla, sql, condicion = "";
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        #endregion 

        public Frm_Jump_Exceptions()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        #region Inicializa grid del Jumper Exception
        private void inicializagridview()
        {
            dg_customprice.EnableHeadersVisualStyles = false;
            sql = "SELECT jump_type_code, charge FROM CT_JUMPER_EXCEPTIONS ";
            condicion = @" WHERE jumper_code = '" + misglobales.jumper_code + "'";
            tabla = "CT_JUMPER_EXCEPTIONS";
            dg_customprice.DataSource = conexion.ConsultaUniversalDT(sql, condicion, tabla);
            try
            {
                dg_customprice.Columns[0].Width = 150; //jump_type_code
                dg_customprice.Columns[0].Visible = true;
                dg_customprice.Columns[1].Width = 100; //Charge
                dg_customprice.Columns[1].Visible = true;

                dg_customprice.Columns[0].HeaderText = "Jump Type Code";
                dg_customprice.Columns[1].HeaderText = "Charge";
                u.Formatodgv(dg_customprice);
                conexion.CloseDB();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(" " + ex.Message);
            }
        }
        #endregion 

        #region Inicializa objetos
        private void InicializaObjetos()
        {
            DataSet dsjumptype;

            sql = @"select jump_type From dbo.CT_JUMP_TYPE WHERE idestatus <> 4 ORDER BY orden";
            dsjumptype = conexion.ConsultaUniversal(sql, "", "CT_JUMP_TYPE");
            cmb_jumptype.DataSource = dsjumptype.Tables[0].DefaultView;
            cmb_jumptype.AutoCompleteCustomSource = u.LoadAutoComplete(dsjumptype, "jump_type");
            cmb_jumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumptype.ValueMember = "jump_type";
            cmb_jumptype.SelectedItem = null;

            txb_price.Text = "";

        }
        #endregion 



        private void Frm_Jump_Exceptions_Load(object sender, EventArgs e)
        {
           lbl_jumpername.Text =  misglobales._name ;
            //misglobales.jumper_code;
           InicializaObjetos();
           inicializagridview();

        }

        private void dg_customprice_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("this process can not rollback, are you sure delete this record: ?", "Warning", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    //Borrar
                    condicion = " jumper_code = '" + misglobales.jumper_code + "' and jump_type_code = '" + dg_customprice.Rows[dg_customprice.CurrentRow.Index].Cells[0].Value.ToString() + "'";
                    conexion.BorraRegistro(condicion, tabla);
                    MessageBox.Show(" Exception has been deleted successfully ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Error try delete exception | " + ex.Message);
                }
            }

        }


        #region Valida campos obligatorios
        private Boolean ValidaCamposObligatorios()
        {
            bool respuesta = false;

            if (cmb_jumptype.Text.Length != 0)
            {
                respuesta = true;
            }
            else { MessageBox.Show(" PLease Select Exception Jump Type "); respuesta = false; return respuesta; }
            if (txb_price.TextLength > 0)
            {
                respuesta = true;
            }
            else { MessageBox.Show(" Price field it's needed"); respuesta = false; return respuesta; }
            

            return respuesta;


        }
        #endregion 


        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            String sql = @"SELECT * FROM dbo.CT_JUMPER_EXCEPTIONS ";
            String tabla = "CT_JUMPER";
            ds = conexion.ConsultaUniversal(sql, condicion, tabla);
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



        private void btn_save_Click(object sender, EventArgs e)
        {
            if (ValidaCamposObligatorios())  // si ya se generó el nuevo jumper exception o se consulto un jumper exception
            {


               
                    //Nuevo
                    tabla = "ct_jumper"; condicion = "";
                    sql = "select idjumper from ct_jumper where codigo = '" + misglobales.jumper_code + "'";
                    DataSet dsidjumper = conexion.ConsultaUniversal(sql, condicion, tabla);

                    tabla = "CT_JUMP_TYPE"; condicion = "";
                    sql = " select idjumptype from CT_JUMP_TYPE where jump_type = '" + cmb_jumptype.Text + "'";
                    DataSet idjumptype = conexion.ConsultaUniversal(sql, condicion, tabla);

                    String condicionespecial = " WHERE jumper_code = '" + misglobales.jumper_code + "' and jump_type_code ='" + cmb_jumptype.Text + "'";

                    if (InserUpdate(condicionespecial) == "insert")
                    {
                        try
                        {
                            tabla = "CT_JUMPER_EXCEPTIONS";
                            campos = "idjumper, jumper_code, idjumptype, jump_type_code, charge";
                            valores = dsidjumper.Tables[0].Rows[0].ItemArray[0].ToString() + ", '" + misglobales.jumper_code + "'," + idjumptype.Tables[0].Rows[0].ItemArray[0].ToString() + ", '" + cmb_jumptype.Text + "', " + txb_price.Text;
                            conexion.InsertTabla(campos, tabla, valores);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error try add exception " + ex.Message);
                        }

                    }
                    else 
                    {
                        //Update
                        campos = @" Charge =  " + txb_price.Text;
                        tabla = "CT_JUMPER_EXCEPTIONS";
                        condicion = " WHERE  jumper_code = '" + misglobales.jumper_code + "' and jump_type_code ='" + cmb_jumptype.Text + "'";

                        try
                            {
                                conexion.UpdateTabla(campos, tabla, condicion);
                                MessageBox.Show("Update successfully", "Information");
                            }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(" Error to update jumper " + ex.Message);
                                }

 
                    }


                    
                    conexion.RegistroLog(misglobales.usuario_idusuario, "jumper", "Agrego/Modifico excepción para el Jumper: " + misglobales.jumper_code + " Jumper Type: " + cmb_jumptype.Text + " Price: " + txb_price.Text);
                    MessageBox.Show("Saved successfully");
                    InicializaObjetos();
                    inicializagridview();


            }
            else
            {
                MessageBox.Show("Capture all need information before to save");
            }

        }
    }
}
