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
    public partial class Frm_Reserve_TandemUp : Form
    {

        #region Variables locales
        DataSet dsjumper, dsreserva;
        ConectaBD conexion = new ConectaBD();
        string sql, tabla, campos, condicion;
        #endregion 


        public Frm_Reserve_TandemUp()
        {
            InitializeComponent();
        }

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



        private void Frm_Reserve_TandemUp_Load(object sender, EventArgs e)
        {
            sql = @"select distinct  referenced_by as name from TB_TANDEMUP_reserva ";
            condicion = "where name + ' ' + lastname not in ( SELECT tandemup.NAME + ' '+ tandemup.LASTNAME FROM dbo.TB_TANDEMUP tandemup WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) ) order by referenced_by";
            dsjumper = conexion.ConsultaUniversal(sql, condicion, "TB_TANDEMUP_reserva");
            cmb_jumper.DataSource = dsjumper.Tables[0].DefaultView;
            cmb_jumper.AutoCompleteCustomSource = LoadAutoComplete(dsjumper, "NAME");
            cmb_jumper.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_jumper.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_jumper.ValueMember = "NAME";
            cmb_jumper.SelectedItem = null;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cmb_jumper.Text != "")
            {
                // Almacenar registros en TandemUp y borrarlos del temporal
                tabla = "TB_TANDEMUP";
                campos = "CODE, SEQUENCE, REGISTERTIME, NAME, LASTNAME, REFERENCED_BY, JUMPTYPE, pricejump, CHARGE, PAYMANT,  RELEASE,  RESERVED_DATE,  EMAIL,  JUMP_FLAG,  ID_PROSPECT, CODE_LEDGER, MANIFESTED, idusuario, idoficina, tandemweight, tandemheight ";
                sql = @"select code, isnull( (SELECT MAX(SEQUENCE)+10 FROM TB_TANDEMUP WHERE (YEAR(registertime) = YEAR(GETDATE()) AND MONTH(REGISTERTIME) = MONTH(GETDATE()) AND DAY(registertime) = DAY(GETDATE()))),10) as secuencia, 
                              getdate(), name, lastname, referenced_by, jumptype, charge, charge, paymant, release, reserved_date, email,  jump_flag, id_prospect, code_ledger,  0 manifested
                          from dbo.TB_TANDEMUP_reserva
                          where referenced_by = '" + cmb_jumper.Text + "'";
                String valores = "";
                DataSet dsreservas = conexion.ConsultaUniversal(sql, "", tabla);
                    
                try
                {
                    for (int i = 0; i < dsreservas.Tables[0].Rows.Count; i++)
                    {
                        DataSet dsregistro = conexion.ConsultaUniversal("select isnull(max(sequence) +10,10) as sequence from dbo.TB_TANDEMUP ", " where CONVERT(varchar(10),registertime,23) = CONVERT(varchar(10), getdate(),23)", "TB_TANDEMUP");
                        
                        
                        //valores = "'" + dsreservas.Tables[0].Rows[i].ItemArray[0].ToString() + "'," + dsregistro.Tables[0].Rows[0].ItemArray[0].ToString() + ", getdate(), '" + dsreservas.Tables[0].Rows[i].ItemArray[3].ToString() +
                        //    "', '" + dsreservas.Tables[0].Rows[i].ItemArray[4].ToString() + "', '" + dsreservas.Tables[0].Rows[i].ItemArray[5].ToString() + "', '" + dsreservas.Tables[0].Rows[i].ItemArray[6].ToString() + "', " +
                        //    dsreservas.Tables[0].Rows[i].ItemArray[7].ToString() + ", " + dsreservas.Tables[0].Rows[i].ItemArray[8].ToString() + ", " + dsreservas.Tables[0].Rows[i].ItemArray[9].ToString()+ ", " +
                        //    dsreservas.Tables[0].Rows[i].ItemArray[10].ToString() + ", convert(varchar(10),'" + dsreservas.Tables[0].Rows[i].ItemArray[11].ToString() + "',23) , '" + dsreservas.Tables[0].Rows[i].ItemArray[12].ToString() + "', " +
                        //    "0,  0, '" + dsreservas.Tables[0].Rows[i].ItemArray[15].ToString() + "', 0";

                        valores = "'" + dsreservas.Tables[0].Rows[i].ItemArray[0].ToString() + "'," + dsregistro.Tables[0].Rows[0].ItemArray[0].ToString() + ", getdate(), '" + dsreservas.Tables[0].Rows[i].ItemArray[3].ToString() +
                            "', '" + dsreservas.Tables[0].Rows[i].ItemArray[4].ToString() + "', '" + dsreservas.Tables[0].Rows[i].ItemArray[5].ToString() + "', '" + dsreservas.Tables[0].Rows[i].ItemArray[6].ToString() + "', " +
                            dsreservas.Tables[0].Rows[i].ItemArray[7].ToString() + ", " + dsreservas.Tables[0].Rows[i].ItemArray[8].ToString() + ", " + dsreservas.Tables[0].Rows[i].ItemArray[9].ToString()+ ", " +
                            dsreservas.Tables[0].Rows[i].ItemArray[10].ToString() + ", (select distinct reserved_date from dbo.TB_TANDEMUP_RESERVA where code = '" + dsreservas.Tables[0].Rows[i].ItemArray[0].ToString() + "'), '" + dsreservas.Tables[0].Rows[i].ItemArray[12].ToString() + "', " +
                            "0,  0, '" + dsreservas.Tables[0].Rows[i].ItemArray[15].ToString() + "', 0," + misglobales.usuario_idusuario + ", " + misglobales.oficina_id_oficina + ", 0,0";


                          
                        conexion.InsertTabla(campos, tabla, valores);
                        //conexion.InsertTablaQry(campos, tabla, sql);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try registry into tandemup " + ex.Message);
                }

                String condicion = " referenced_by = '" + cmb_jumper.Text + "'";
                tabla = "TB_TANDEMUP_reserva";
                conexion.BorraRegistro(condicion, tabla);

            }
            misglobales._Importing = 0;
            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
