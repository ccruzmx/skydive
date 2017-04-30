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
    public partial class Frm_Payment_Breakdown : Form
    {
        Decimal _Balance = 0;
        ConectaBD conexion = new ConectaBD();
        string condicion = "";
        utilerias u = new utilerias();

        #region Constructor del Frm_Payment_Breakdown
        public Frm_Payment_Breakdown()
        {
            InitializeComponent();
        }
        #endregion

        #region Evento click del btn_cancel
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            misglobales._TotalBalance = 0;
            misglobales.BreakdownOpen = false;
            this.Close();
        }
        #endregion 

        #region Evento click del btn_ok
        private void btn_ok_Click(object sender, EventArgs e)
        {
            misglobales._TotalBalance = Convert.ToDecimal(_Balance.ToString());
            misglobales._utilizandoPayment = false;
            string tabla, campos, valores, condicion;

            if (misglobales._BreakDown == 1)
            {
                tabla = "TB_BREAKDOWNTANDEM";
                condicion = " code_tandem = '" + misglobales._tandemupcode + "'";
            } else 
            {
                tabla = "TB_BREAKEDOWN";
                condicion = " code_ledger = '" + misglobales._TransaccionLedger + "'" ;
            }

            
            conexion.BorraRegistro(condicion, tabla);


            for (int i = 0; i < dg_breakdown.RowCount; i++)
            {
                if (Convert.ToDecimal(dg_breakdown.Rows[i].Cells[3].Value) != 0)
                {
                    if (misglobales._BreakDown == 1)
                    {
                        // 1= dbo.TB_BREAKDOWNTANDEM
                        tabla = "TB_BREAKDOWNTANDEM";
                        campos = "code_payment_type, payment, code_tandem, idusuario, iddropzone, updatedate";
                        valores = "'" + dg_breakdown.Rows[i].Cells[2].Value + "'," + dg_breakdown.Rows[i].Cells[3].Value + ", '"+ misglobales._tandemupcode +"', " + misglobales.usuario_idusuario + ", " + misglobales.oficina_id_oficina+ ", getdate()" ;
                    }
                    else
                    {
                        // 0 = dbo.TB_BREAKEDOWN
                        tabla = "TB_BREAKEDOWN";
                        campos = "code_ledger, code_payment_type, payment, idusuario, iddropzone, updatedate";
                        valores = "'" + misglobales._TransaccionLedger + "','" + dg_breakdown.Rows[i].Cells[2].Value + "'," + dg_breakdown.Rows[i].Cells[3].Value + ", " + misglobales.usuario_idusuario + ", " + misglobales.oficina_id_oficina + ", getdate()";
                    }

                    conexion.InsertTabla(campos, tabla, valores);
                }
            }
            misglobales.BreakdownOpen = false;
            this.Close();   
        }
        #endregion 

        #region Inicializa grid vuelos
        private void inicializagridview()
        {
            if (misglobales._BreakDown == 1)
            {
                condicion = @" and TBB.code_tandem = '" + misglobales._tandemupcode + "'   where  ctp.idestatus = 1  ORDER BY sort";
            }
            else if (misglobales._BreakDown == 0)
            {
                condicion = @" and tbb.code_ledger = '" + misglobales._TransaccionLedger + "'  where  ctp.idestatus = 1  ORDER BY sort";
            }

            
            dg_breakdown.EnableHeadersVisualStyles = false;
            dg_breakdown.DataSource = conexion.ConsultaBreakdown(condicion);
            // idpaymenttype, code, payment_type, payment
            dg_breakdown.Columns[0].Width = 10; //idpaymenttype
            dg_breakdown.Columns[0].Visible = false;
            dg_breakdown.Columns[1].Width = 10; //code
            dg_breakdown.Columns[1].Visible = false;
            dg_breakdown.Columns[2].Width = 200; //payment_type
            dg_breakdown.Columns[3].Width = 146; //payment
            dg_breakdown.Columns[2].HeaderText = "Payment Type";
            dg_breakdown.Columns[3].HeaderText = "Acount";
            u.Formatodgv(dg_breakdown);
            dg_breakdown.ReadOnly = false;
            dg_breakdown.Columns[2].ReadOnly = true;
            dg_breakdown.Columns[3].ReadOnly = false;

            Balance();

        }
        #endregion

        #region Load del Frm_Payment
        private void Frm_Payment_Breakdown_Load(object sender, EventArgs e)
        {
            txb_total.Text = "0.00";
            inicializagridview();
            misglobales._utilizandoPayment = true;
            misglobales.BreakdownOpen = true;
        }
        #endregion 

        #region Evento Cellclick del dg_breakdown
        private void dg_breakdown_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion 

        #region Evento CellMouseClick del dg_breakdown
        private void dg_breakdown_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = e.RowIndex + 1; i <= dg_breakdown.Rows.Count - 1; i++)
            {
                dg_breakdown.Rows[i].Cells[1].ReadOnly = false;
                dg_breakdown.Rows[i].Cells[0].ReadOnly = true;
            }

            dg_breakdown.CellMouseClick -= new DataGridViewCellMouseEventHandler(dg_breakdown_CellMouseClick); 
        }
        #endregion

        public void Balance()
        {
            _Balance = 0;
            for (int i = 0; i < dg_breakdown.RowCount; i++)
            {
                try
                {
                    _Balance += Convert.ToDecimal(dg_breakdown.Rows[i].Cells[3].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("currency Error: " + ex.Message);
                }

            }

            txb_total.Enabled = true;
            txb_total.Text = _Balance.ToString();
            txb_total.Enabled = false;
        }

        private void dg_breakdown_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Balance();
            //_Balance = 0;
            //for (int i = 0; i < dg_breakdown.RowCount; i++)
            //{
            //    try
            //    {
            //        _Balance += Convert.ToDecimal(dg_breakdown.Rows[i].Cells[3].Value);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("currency Error: " + ex.Message);
            //    }

            //}

            //txb_total.Enabled = true;
            //txb_total.Text = _Balance.ToString();
            //txb_total.Enabled = false;
        }

        private void Frm_Payment_Breakdown_FormClosing(object sender, FormClosingEventArgs e)
        {
            misglobales.BreakdownOpen = false;
        }


    }
}
