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
    public partial class Frm_PaidBy : Form
    {


        ConectaBD conexion = new ConectaBD();
        String campos, tabla, condicion, sql, _CodeJumper = "";
        Int32 PrecioTicket = 0;
        utilerias u = new utilerias();

        public Frm_PaidBy()
        {
            InitializeComponent();
        }

        #region Load de la forma frm_paidby
        private void Frm_PaidBy_Load(object sender, EventArgs e)
        {
            txb_jumper.Text = misglobales.QuienSaltaname.ToString();
            btn_applypaidby.Enabled = false;

        }
        #endregion

        #region Evento pierde foco el campo folioticket
        private void txb_ticket_LostFocus(object sender, EventArgs e)
        {

            if (txb_ticket.Text != "")
            {
                btn_applypaidby.Enabled = true;
                btn_applypaidby.Focus();
                TicketSeleccionado();
                
            }
        }
        #endregion 

        #region Metodo al seleccionar un Jumper
        private void TicketSeleccionado()
        {


            try
            {

                string sql = @"SELECT J.idjumper, J.codigo, J.NOMBRE, tbalance.jumptypecode, J.idjumpertypecode, JT.Altitud, J.Allow_PaidBy, j.Balance, Allow_Override_Padlock, 
                                  j.balance_jump, jt.codey, tbalance.folioticket, tbalance.price, tbalance.idestatus
                             FROM DBO.CT_JUMPER J INNER JOIN dbo.CT_JUMP_TYPE JT ON JT.codigo = J.idjumptypecode
                            INNER JOIN dbo.TB_TICKETS_BALANCE tbalance ON tbalance.idjumper = j.idjumper and tbalance.folioticket = '" + txb_ticket.Text + "' --and tbalance.idestatus =1";
                DataSet dsjumperselected = conexion.ConsultaUniversal(sql, " ", "CT_JUMPER");
                // if (dsjumper.Tables[0].Rows.Count > 0)
                if (dsjumperselected.Tables[0].Rows.Count > 0)
                {



                    if (dsjumperselected.Tables[0].Rows[0].ItemArray[13].ToString() == "1")
                    {
                        txb_jumper_PaidBy.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[2].ToString();
                        txb_jumptype.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[3].ToString();
                        misglobales.QuienPaga = Convert.ToInt32(dsjumperselected.Tables[0].Rows[0].ItemArray[0].ToString());
                        misglobales.QuienPaganame = txb_jumper_PaidBy.Text;
                        PrecioTicket = Convert.ToInt32(dsjumperselected.Tables[0].Rows[0].ItemArray[12].ToString()) * -1;
                        _CodeJumper = dsjumperselected.Tables[0].Rows[0].ItemArray[1].ToString();

                        //                    if (Convert.ToBoolean(dsjumper.Tables[0].Rows[0].ItemArray[8].ToString()) == true)
                        //                    {
                        //                        sql = @"select jump_type as jumptypecode
                        //                                from dbo.CT_JUMP_TYPE
                        //                                where idestatus = 1
                        //                                order by orden";
                        //                        tabla = "CT_JUMP_TYPE";
                        //                    }
                        //                    else
                        //                    {
                        //                        sql = @"SELECT distinct jumptypecode FROM dbo.TB_TICKETS_BALANCE " +
                        //                               " where idestatus = 1 and codejumper = '" + dsjumper.Tables[0].Rows[0].ItemArray[1].ToString() + "' " +
                        //                              @" union all
                        //                        select idjumptypecode
                        //                          from dbo.CT_JUMPER
                        //                         where idestatus = 1 and codigo = '" + dsjumper.Tables[0].Rows[0].ItemArray[1].ToString() + "' ";
                        //                        tabla = "TB_TICKETS_BALANCE";
                        //                    }


                        //                    //" and idjumptypecode in(select jump_type from CT_JUMP_TYPE  where len(codey)>= 1) ";

                        //                    condicion = "";
                        //                    dsbalancejump = conexion.ConsultaUniversal(sql, condicion, tabla);

                        //                    cmb_jumptype.DataSource = dsbalancejump.Tables[0].DefaultView;
                        //                    cmb_jumptype.AutoCompleteCustomSource = LoadAutoComplete(dsbalancejump, "jumptypecode");
                        //                    cmb_jumptype.AutoCompleteMode = AutoCompleteMode.Suggest;
                        //                    cmb_jumptype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        //                    cmb_jumptype.ValueMember = "jumptypecode";
                        //                    cmb_jumptype.SelectedItem = null;

                        //                    //cmb_jumptype.SelectedValue = dsjumper.Tables[0].Rows[0].ItemArray[3].ToString();
                        //                    cmb_jumptype.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[3].ToString();

                        //                    txb_Altitud.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[5].ToString();
                        //                    txb_balance.Text = dsjumperselected.Tables[0].Rows[0].ItemArray[9].ToString();
                        //                    txb_balance.Text = Convert.ToString(Convert.ToDecimal(txb_balance.Text));  //string.Format("{0:C}", Convert.ToDecimal(txb_balance.Text));
                        //                    PermiteCambioTipoSaltoEnManifiesto = Convert.ToBoolean(dsjumperselected.Tables[0].Rows[0].ItemArray[8].ToString());
                        //                    //if (PermiteCambioTipoSaltoEnManifiesto == true)
                        //                    //{
                        //                    cmb_jumptype.Enabled = true;
                        //                    //}
                        //                    conexion.CloseDB();
                        //                    btn_addjumper.Enabled = true;
                        //                    TicketValido = true;
                        //                }
                        //                else if (dsjumperselected.Tables[0].Rows[0].ItemArray[13].ToString() == "8")
                        //                {

                        //                    tabla = "TB_MANIFIESTO";
                        //                    sql = @" SELECT tbv.numerovuelo, cta.matricula, tbv.fechaabrevuelo, ctu.nombre + ' ' + ctu.paterno + ' '+ ctu.materno, cto.Nombre
                        //                                      FROM TB_MANIFIESTO tbm 
                        //                                     INNER JOIN TB_VUELOS tbv on tbv.idvuelo = tbm.idvuelo
                        //                                     INNER JOIN CT_AERONAVE cta on cta.idaeronave = tbv.idaeronave
                        //                                     INNER JOIN CT_USUARIO ctu on ctu.idusuario = tbv.idusuario
                        //                                     INNER JOIN CT_OFICINA cto on cto.idoficina = tbv.idoficina ";

                        //                    condicion = " WHERE folioticket = '" + txb_ticket.Text + "'";
                        //                    DataSet dsticketusado = conexion.ConsultaUniversal(sql, condicion, tabla);
                        //                    MessageBox.Show(" Ticket used in flight: " + dsticketusado.Tables[0].Rows[0].ItemArray[0].ToString() + " Plane: " + dsticketusado.Tables[0].Rows[0].ItemArray[1].ToString() +
                        //                        " Date: " + dsticketusado.Tables[0].Rows[0].ItemArray[2].ToString() + " on " + dsticketusado.Tables[0].Rows[0].ItemArray[4].ToString() + " Dropzone, registred in the system for : " +
                        //                         dsticketusado.Tables[0].Rows[0].ItemArray[3].ToString());
                        //                }
                        //                else
                        //                {
                        //                    tabla = "TB_MANIFIESTO";
                        //                    sql = @" Select tb.folioticket, cte.descripcion, tb.nota 
                        //                                  From dbo.TB_TICKETS_BALANCE tb
                        //                                  inner join CT_ESTATUS cte on cte.idestatus = tb.idestatus";
                        //                    condicion = " WHERE folioticket = '" + txb_ticket.Text + "'";
                        //                    DataSet dsticketusado = conexion.ConsultaUniversal(sql, condicion, tabla);
                        //                    MessageBox.Show(" The ticket " + txb_ticket.Text + " has been " + dsticketusado.Tables[0].Rows[0].ItemArray[1].ToString());

                        //                    txb_ticket.Focus();
                        //                    txb_ticket.SelectAll();
                        //                }
                    }
                    else
                    {
                        MessageBox.Show(" This ticket not exist, apply review protocol with your manager");
                        txb_ticket.Text = "";
                        //cmb_jumper.Focus();
                        //TicketValido = false;
                        txb_ticket.Focus();
                        txb_ticket.SelectAll();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Apply Paid By Button" );
            }
        }
        #endregion 

        #region Evento KeyPress del txb_ticket
        private void txb_ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "\b") //permitir teclas de control como retroceso
            {
                if (txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "C" || txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "a" || txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "e")
                {
                    txb_ticket.Text = txb_ticket.Text.Substring(0, 12);
                }
                
                btn_applypaidby.Focus();
                
                

            }



            //if (Char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "\b") //permitir teclas de control como retroceso
            //{
            //    //if (txb_ticket.Text.Substring(0, 1) == "C" )
            //    if (txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "C" || txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "a" || txb_ticket.Text.Substring((txb_ticket.Text.Length - 1), 1) == "e")
            //    {
            //        txb_ticket.Text = txb_ticket.Text.Substring(3, 12);
            //    }
            //    btn_applypaidby.Focus();
            //    //TicketSeleccionado();
            //    //btn_addjumper_Click(sender, e);

            //}
            
            
            
            ////if (Char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "\b") //permitir teclas de control como retroceso
            ////{
            ////    if (txb_ticket.Text.Substring(0, 1) == "C")
            ////    {
            ////        txb_ticket.Text = txb_ticket.Text.Substring(3, 12);
            ////    }
            ////    //btn_addjumper.Focus();
            ////    TicketSeleccionado();
            ////    //btn_addjumper_Click(sender, e);

            ////}

        }

        #endregion 

        #region Determina si es Insert or Update
        public string InserUpdate(string condicion)
        {
            DataSet ds;
            sql = @"select * from tb_manifiesto ";

            try
            {

                ds = conexion.ConsultaUniversal(sql, condicion, "tb_manifiesto");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return "insert";
                }
                else
                {
                    return "update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try consult manifiesto" + ex.Message);
                return "fail";
            }

        }
        #endregion

        #region Metodo MANIFIESTALO !!!
        private void Manifiestalo(String CodeJumper, Int32 _idjumper, Int32 Tickets, String CodeLeadger)
        {
            tabla = "TB_LEDGER";
            sql = @" SELECT * 
                       FROM TB_LEDGER ";
            condicion = @" WHERE jumper_code = '" + CodeJumper + @"' " +
                         " AND idmanifiesto = " + misglobales.id1;

            DataSet dsidleadger = conexion.ConsultaUniversal(sql, condicion, tabla);
            Int32 idleadgervar;

            if (dsidleadger.Tables[0].Rows.Count > 0)
            {
                idleadgervar = Convert.ToInt32(dsidleadger.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                idleadgervar = 0;
            }

            if (_idjumper == 1)
            { condicion = @" where idvuelo = " + misglobales.id1 + " and 1=2"; }
            else
            { condicion = @" where idvuelo = " + misglobales.id1 + " and idjumper = " + _idjumper; }


            String InUp = InserUpdate(condicion);

            if (InUp == "insert")
            {

                // obtener el jump_type cmb_jumptype.text
                tabla = "CT_JUMP_TYPE";
                sql = @" select idjumptype, codigo, jump_type, price, Altitud from dbo.CT_JUMP_TYPE ";
                condicion = " WHERE jump_type = '" + txb_jumptype.Text + "'";
                DataSet dsidjumptype = conexion.ConsultaUniversal(sql, condicion, tabla);


                //Gravar manifiesto
                tabla = "tb_manifiesto";
                campos = "idvuelo, code, idjumper, idtandem, idleadger, idjumptype, reservefor, folioticket";
                string valores = misglobales.id1 + ",'" + misglobales.PaidByMatricula + "-" + misglobales.PaidByFlightCode + "'," + misglobales.QuienSaltaid.ToString() + ", 0," +
                       idleadgervar + ", " + dsidjumptype.Tables[0].Rows[0].ItemArray[0].ToString() + ", ' PaidBy: " + txb_jumper_PaidBy.Text + "','" + txb_ticket.Text + "'";

                try
                {
                    conexion.InsertTabla(campos, tabla, valores);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try insert into manifest " + ex.Message);

                }

                //Actualiza JUMPER
                String tabla5 = "CT_JUMPER";
                String campos5 = @" fecha_ultimo_salto = getdate(), " +
                                  " total_saltos =  total_saltos +1 ";


                String condicion5 = " WHERE idjumper = " + misglobales.QuienSaltaid ;
                try
                {
                    conexion.UpdateTabla(campos5, tabla5, condicion5);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to try update balance and balance jump, please contact system administrator" + ex.Message);
                }

            }
            else if (InUp == "update")
            {
                MessageBox.Show("Jumper already exist in the manifest");
            }

            conexion.CloseDB();

        }
        #endregion 

        #region Evento click del boton Apply Paid By
        private void btn_applypaidby_Click(object sender, EventArgs e)
        {

            if (misglobales.QuienPaga != 0)
            {
                //registra el movimiento en los tb_tickets
                String _campo = "idjumper";
                if (u.SePuedeManifestar(misglobales.QuienSaltaid, _campo) == false)
                {
                    MessageBox.Show(" Already exist in the manifest ");
                    return;
                }

                campos = @"idestatus = 9, nota = ' Use for:  " + txb_jumper.Text + "  Paid by:  " + txb_jumper_PaidBy.Text + " '";
                tabla = "TB_TICKETS_BALANCE";
                condicion = " WHERE folioticket = '" + txb_ticket.Text + "'  AND idjumper =" + misglobales.QuienPaga;
                conexion.UpdateTabla(campos, tabla, condicion);

                //Se registra en el manifiesto
                Manifiestalo(_CodeJumper, misglobales.QuienSaltaid, 0, "0");

                //Se autoriza el refresh para el grid del manifiesto
                misglobales.ListoPaidBy = 1;
                this.Close();
            }
        }
        #endregion

        #region Evento click del btn_cancel
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            misglobales.ListoPaidBy = 1;
            this.Close();
        }
        #endregion

    }
}
