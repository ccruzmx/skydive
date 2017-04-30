using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_TandemSelection : Form
    {

        #region Zona de variables
        String condicion, campos, tabla, sql;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        #endregion 

        #region Constructor de la forma Frm_TandemSelection
        public Frm_TandemSelection()
        {
            InitializeComponent();
        }
        #endregion 

        #region Load de la forma Frm_TandemSelection
        private void Frm_TandemSelection_Load(object sender, EventArgs e)
        {
            InicializaGrid();
        }
        #endregion

        #region Inicializa Grid
        private void InicializaGrid()
        {
            misglobales.TandemSelection = 1;
            //condicion = @" WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23) and tandemup.jump_flag = 0  and tandemup.release = 1 and tandemup.manifested = 0 ORDER BY convert(int,tandemup.SEQUENCE) asc ";
            condicion = @" WHERE CONVERT(VARCHAR(26), tandemup.REGISTERTIME, 23)  = CONVERT(VARCHAR(26), '" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 23) and tandemup.jump_flag = 0  and tandemup.release = 1 and tandemup.manifested = 0 ORDER BY convert(int,tandemup.SEQUENCE) asc ";
            dg_TandemS.EnableHeadersVisualStyles = false;
            dg_TandemS.DataSource = conexion.ConsultaTandemup(condicion);  //getdata(fuente;
            dg_TandemS.Columns[0].Width = 25; //IDTANDEMUP
            dg_TandemS.Columns[0].Visible = false;
            dg_TandemS.Columns[1].Width = 50; //SEQUENCE
            dg_TandemS.Columns[1].Visible = true;
            dg_TandemS.Columns[2].Width = 130; //REGISTER TIME
            dg_TandemS.Columns[2].Visible = false;
            dg_TandemS.Columns[3].Width = 130; //NAME
            dg_TandemS.Columns[3].Visible = true;
            dg_TandemS.Columns[4].Width = 130; //LAST NAME
            dg_TandemS.Columns[4].Visible = true;
            dg_TandemS.Columns[5].Width = 130; //REFERENCED BY
            dg_TandemS.Columns[5].Visible = true;
            dg_TandemS.Columns[6].Width = 130; //JUMP TYPE
            dg_TandemS.Columns[6].Visible = true;
            dg_TandemS.Columns[7].Width = 70; //CHARGE
            dg_TandemS.Columns[7].Visible = true;
            dg_TandemS.Columns[8].Width = 70; //PAYMENT
            dg_TandemS.Columns[8].Visible = true;
            dg_TandemS.Columns[9].Width = 70; //RELEASE
            dg_TandemS.Columns[9].Visible = false;
            dg_TandemS.Columns[10].Width = 150; //RESERVED_DATE
            dg_TandemS.Columns[10].Visible = false;
            dg_TandemS.Columns[11].Width = 100; //EMAIL
            dg_TandemS.Columns[11].Visible = false;
            dg_TandemS.Columns[12].Visible = false;
            dg_TandemS.Columns[13].Visible = false;
            dg_TandemS.Columns[14].Visible = false;
            dg_TandemS.Columns[15].Visible = false;
            dg_TandemS.Columns[16].Visible = false;

            dg_TandemS.Columns[1].HeaderText = "Seq";
            dg_TandemS.Columns[3].HeaderText = "Name";
            dg_TandemS.Columns[4].HeaderText = "Last Name";
            dg_TandemS.Columns[5].HeaderText = "Referenced By";
            dg_TandemS.Columns[6].HeaderText = "Jump Type";

            u.Formatodgv(dg_TandemS);

        }
        #endregion

        #region Evento click del btn_exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region evento Cell Double clik del dg_trandemS
        private void dg_TandemS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToByte(dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[18].Value) == 1)
            {

                Int32 idtandem = Convert.ToInt32(dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[0].Value);
                sql = "select *  from dbo.TB_PRE_MANIFIESTO ";
                tabla = "TB_PRE_MANIFIESTO";
                condicion = " where idtandem = " + idtandem;
                DataSet dspremanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);


                String TablaJumpType = "CT_JUMP_TYPE";
                String sqljumptype = @" SELECT ctj.idjumptype, ctj.jump_type, ctj.[group], ctj.charge_type_description,  ctct.charge_type
                                          FROM CT_JUMP_TYPE ctj 
                                         INNER JOIN CT_CHARGE_TYPE ctct 
                                                 ON ctj.idchargetype = ctct.idchargetype 
                                                AND ctj.jump_type = '" + dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[6].Value + "'";
                DataSet dsjumptypeid = conexion.ConsultaUniversal(sqljumptype, "", TablaJumpType);


                if (dspremanifiesto.Tables[0].Rows.Count == 0)
                {

                    if (u.SePuedeManifestar(idtandem, "idtandem") == true)
                    {
                        tabla = "TB_TANDEMUP";
                        campos = @" jump_flag = 1, manifested = 2 ";
                        condicion = " WHERE idtandemup = " + idtandem;
                        try
                        {
                            conexion.UpdateTabla(campos, tabla, condicion);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error to try on flag jump for this tandemup, please contact system administrator " + ex.Message);
                        }

                        try
                        {
                            sql = " select max(idledger)+1 from tb_ledger";
                            condicion = "";
                            tabla = "tb_ledger";
                            DataSet dsidledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                            Int32 _IdLedger = Convert.ToInt32(dsidledger.Tables[0].Rows[0].ItemArray[0].ToString());


                            tabla = "tb_manifiesto";
                            campos = "idvuelo, code, idjumper, idtandem, idleadger, idjumptype, reservefor";
                            string valores = misglobales.id1 + misglobales._codetandemup + misglobales.idJumperTandem+", " + idtandem + " , " + _IdLedger + ", " + dsjumptypeid.Tables[0].Rows[0].ItemArray[0].ToString() + ", ''";
                            conexion.InsertTabla(campos, tabla, valores);

                            // Aplicar al ledger
                            
                            //sql = @" SELECT convert(varchar(6),max(SUBSTRING(code, 1,LEN(idledger)))+1) + '-MANFST' as code FROM dbo.TB_LEDGER ";
                            sql = @" SELECT convert(varchar(6),REPLACE( max(SUBSTRING(code, 1,len(idledger))), '-', '')+1) + '-MANFST' as code FROM dbo.TB_LEDGER ";
                            condicion = "";
                            tabla = "TB_LEDGER";
                            DataSet dscodeledger = conexion.ConsultaUniversal(sql, condicion, tabla);
                            String _Code = dscodeledger.Tables[0].Rows[0].ItemArray[0].ToString();

                            tabla = "TB_MANIFIESTO";
                            sql = "select idmanifiesto from DBO.TB_MANIFIESTO ";
                            
                            Int32 Longitud = misglobales._codetandemup.Length - 4;
                            String _CodeTandemUp = misglobales._codetandemup.Substring(2, Longitud);
                            condicion = " where idvuelo = " + misglobales.id1 + " and code = '" + _CodeTandemUp + "'";

                           
                            DataSet dsmanifiestoid = conexion.ConsultaUniversal(sql, condicion, tabla);

                            tabla = "TB_TANDEMUP";
                            sql = "SELECT idtandemup, code, jumptype, pricejump, convert(decimal(10,2),charge) charge, paymant, idusuario FROM dbo.TB_TANDEMUP ";
                            //condicion = "WHERE IDTANDEMUP = " + idtandem + " AND CONVERT(varchar(10),registertime, 23) = CONVERT(varchar(10),GETDATE(), 23)";
                            condicion = "WHERE IDTANDEMUP = " + idtandem + " AND CONVERT(varchar(10),registertime, 23) = CONVERT(varchar(10),'" + misglobales.FechaMovimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', 23)";
                            DataSet dscostos = conexion.ConsultaUniversal(sql, condicion, tabla);
                            Decimal _charge = Convert.ToDecimal( dscostos.Tables[0].Rows[0].ItemArray[4].ToString());
                            String _jumptype = Convert.ToString(dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[6].Value);
                            Decimal _Payment = Convert.ToDecimal(dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[13].Value);
                            String _IdManifiesto = dsmanifiestoid.Tables[0].Rows[0].ItemArray[0].ToString();
                            String _nametandem = "T-"  + Convert.ToString(dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[4].Value) + ", " + Convert.ToString(dg_TandemS.Rows[dg_TandemS.CurrentRow.Index].Cells[3].Value);
                            String _Code_Tandem = Convert.ToString(dscostos.Tables[0].Rows[0].ItemArray[1].ToString());
                            Int32 _idusuario = Convert.ToInt32(dscostos.Tables[0].Rows[0].ItemArray[6].ToString());

                            u.AplicaLedger(_Code, "9999-Tandem", misglobales._Updatedate, dsjumptypeid.Tables[0].Rows[0].ItemArray[3].ToString(), _charge, _jumptype, 0, "", _Payment, 0, "", misglobales.id1.ToString(), 0, "", _nametandem, 0, 0, 0, 0, _Code_Tandem.ToString(), 0, 0, misglobales.oficina_id_oficina, "", _idusuario);

                             misglobales.jumper_code = "9999-Tandem";
                             u.Balance();

                            //
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error try add into manifest, contact system administrator" + ex.Message);
                        }

                        InicializaGrid();
                        this.Close();
                    }
                    else { MessageBox.Show(" Already exist into manifest "); }
                }
            }
            else
            {
                MessageBox.Show(" has not been released, please go to make your payment");
            }
        }
        #endregion 

        #region Row Post Paint
        private void dg_TandemS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Font Negrita = new Font(dg_TandemS.Font, FontStyle.Bold);
            Font Normal = new Font(dg_TandemS.Font, FontStyle.Regular);

            if ((e.RowIndex) < (this.dg_TandemS.Rows.Count))
            {

                DataGridViewRow gvr = this.dg_TandemS.Rows[e.RowIndex];


                sql = "select *  from dbo.TB_PRE_MANIFIESTO ";
                tabla = "TB_PRE_MANIFIESTO";
                condicion = " where idtandem = " + Convert.ToInt32(gvr.Cells[0].Value);
                DataSet dspremanifiesto = conexion.ConsultaUniversal(sql, condicion, tabla);


                if (Convert.ToInt32(gvr.Cells[21].Value) == 1)
                {

                    gvr.DefaultCellStyle.Font = Negrita;
                    gvr.DefaultCellStyle.ForeColor = Color.Yellow;
                    gvr.DefaultCellStyle.BackColor = Color.Green;


                }
                else if (dspremanifiesto.Tables[0].Rows.Count > 0)
                {

                    gvr.DefaultCellStyle.Font = Normal;
                    gvr.DefaultCellStyle.ForeColor = Color.Black;
                    gvr.DefaultCellStyle.BackColor = Color.Gray;
                    


                }

            }
        }
        #endregion 

        private void dg_TandemS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
