using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_LoadReservations : Form
    {
        String campos, tabla, valores, sql, condicion;
        ConectaBD conexion = new ConectaBD();
        utilerias u = new utilerias();
        Int32 id = 1;
        String _fecha_salto;
        String _JumpDate;

        public Frm_LoadReservations()
        {
            InitializeComponent();
        }

        #region Evento Click del boton Exit
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region Evento click del boton browse
        private void btn_browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Add File";
            openFileDialog.Filter = "Reservation Files (*.csv)|*.csv";
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string sFilePath;
            sFilePath = openFileDialog.FileName;
            if (sFilePath == "")
                return;

            // make sure the file exists before adding
            // its path to the list of files to be
            // compressed
            if (System.IO.File.Exists(sFilePath) == false)
                return;
            else
                txb_pathfile.Text = sFilePath;
        }
        #endregion

        #region AgregarTandemUp
        //public void AddTandemUp(String nombre, String apellido, String referenciado, String JumpType, Int32 Paymet, Int32 Charge, DateTime JumpDate, String email)
        public void AddTandemUp(String nombre, String apellido, String referenciado, String JumpType, Int32 Paymet, Int32 Charge, String JumpDate, String email)
        {
            //Obtenemos el CODE
            String _code, seq;
            DataSet dscode = conexion.ConsultaUniversal("SELECT MAX(idtandemup)+"+id+" FROM dbo.TB_TANDEMUP", "", "TB_TANDEMUP");
            if (nombre == "") { nombre = "XXXX"; }
            if (dscode.Tables.Count == 0 || dscode.Tables[0].Rows[0].ItemArray[0].ToString() == "")
            {
                _code = "1-TANDEM-" + nombre.Substring(1, 2) + nombre.Substring(1, 2);
            }
            else
            {
                _code = dscode.Tables[0].Rows[0].ItemArray[0].ToString() + "-TANDEM-" + nombre.Substring(0, 2) + nombre.Substring(0, 2);
            }
            

            tabla = "TB_TANDEMUP_RESERVA";
            sql = @"SELECT MAX(sequence)+10 AS SEQ  FROM dbo.TB_TANDEMUP_RESERVA ";
            condicion = " WHERE jump_flag =  0 AND (YEAR(registertime) = YEAR(GETDATE()) AND MONTH(REGISTERTIME) = MONTH(GETDATE()) AND DAY(registertime) = DAY(GETDATE()))";

            DataSet dssequence = conexion.ConsultaUniversal(sql, condicion, tabla);
            if (dssequence.Tables.Count == 0 || dssequence.Tables[0].Rows[0].ItemArray[0].ToString() == "")
            {
                seq = "10";
            }
            else
            {
                seq = dssequence.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            


            campos = "CODE, SEQUENCE, REGISTERTIME, NAME, LASTNAME, REFERENCED_BY, JUMPTYPE, CHARGE, PAYMANT,  RELEASE,  RESERVED_DATE,  EMAIL,  JUMP_FLAG,  ID_PROSPECT, CODE_LEDGER, MANIFESTED";
            tabla = "TB_TANDEMUP_RESERVA";
            valores = "'" + u.Parseacomillas( u.ParseaSlash( _code)) + "', " + seq + ", getdate(), '" + nombre + "', '" + apellido + "', '" + referenciado +
                      "', '" + JumpType + "', " + Charge +
                      ", " + Paymet + ", 0, convert(varchar(10),'" +  JumpDate + "',103), '" + email + "', 0, '', '', 3";
            
            try
            {
                conexion.InsertTabla(campos, tabla, valores);
                id = id + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try Upload Reservations into TandemUp, " + ex.Message + " | " + campos + " | " + valores );
            }

        }
        #endregion 


        #region LeerArchivo
        public void LeerArchivo()
        {
            
            try
            {
                sql = @"GRANT SELECT, UPDATE, CONTROL, DELETE, INSERT, ALTER, REFERENCES  ON TB_TANDEMUP_RESERVA TO sdcuser WITH GRANT OPTION  
                        GRANT SELECT, UPDATE, CONTROL, DELETE, INSERT, ALTER, REFERENCES  ON TB_TANDEMUP_RESERVA TO sdcuser WITH GRANT OPTION";
                conexion.EXECquery(sql);
                conexion.CloseDB();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error query : " + ex.Message);
                return;

            }
            //sql = "uspTruncateTable 'bd_skydivecuautla', 'dbo', 'TB_TANDEMUP_RESERVA'";


            sql = "truncate table dbo.TB_TANDEMUP_RESERVA";
            condicion = "";
            tabla = "TB_TANDEMUP_RESERVA";

            try
            {
                conexion.ConsultaUniversal(sql, condicion, tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error permisions : " + ex.Message);
                return;

            }


          

            //conexion.EXECSP(sql);
            

            
            Int32 Reservas = 0, _video = 0, _Payment = 0, _Charge = 0;
            String _Nombre, _Apellido, _referencia = "", _jumptype, _email;
            //DateTime _JumpDate;
            
            Decimal TotalRegistros = 0;
            Int32 TotalBarra = 0;
            string CSVFilePathName = txb_pathfile.Text;
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { '|' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
           
            String JumpType = "TANDEM";
            
            //Primero agregamos los nombres de las columnas
            try
            {
                for (int i = 0; i < Cols; i++)
                {
                   
                    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                   
                }
                //Agregamos registro por registro
                DataRow Row;
                TotalRegistros = Lines.GetLength(0);
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    Fields = Lines[i].Split(new char[] { '|' });
                    if (Fields[0] == "")
                    { }
                    else
                    {
                        Row = dt.NewRow();
                        for (int f = 0; f < Cols; f++)
                        {
                            
                            Row[f] = u.ParseaEspecial(Fields[f]);
                        }

                        dt.Rows.Add(Row);
                        TotalBarra = TotalBarra + 1;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to read xls file " + ex.Message );
            }


            pb_UpLoad.Maximum = TotalBarra;
            pb_UpLoad.Value = 1;
            //barremos el Datatable para insertarlo en el TandemUp

            Decimal numreg = 1;
            
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pb_UpLoad.Value = Convert.ToInt32(numreg); // Convert.ToInt32(Convert.ToDecimal(numreg / TotalBarra));
                    numreg += 1;
                    //if (numreg == 704)
                    //{
                    //    MessageBox.Show("Error try process file  |  i =" + numreg);
                    //}
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                    Reservas = 1; // Convert.ToInt32(dt.Rows[i]["Personas"].ToString());
                    _Nombre = dt.Rows[i]["nombre"].ToString();
                    
                    _Nombre = u.Parseacomilla(_Nombre);
                    _Nombre = u.Parseacomillas(_Nombre);
                    _Nombre = u.ParseaSlash(_Nombre);
                    _Nombre = u.ParseaEspecial(_Nombre);

                   
                    _Apellido = dt.Rows[i]["apellido"].ToString();
                    _Apellido = u.Parseacomillas(_Apellido);
                    _Apellido = u.ParseaSlash(_Apellido);


                    if (dt.Rows[i][9].ToString() == "false") { _video = 1; } else { _video = 0; }


                   
                    if (Reservas > 1)
                    {
                        _referencia = dt.Rows[i]["nombre"].ToString() + " " + dt.Rows[i]["apellido"].ToString();
                       

                        if (dt.Rows[i]["deposito"].ToString() != "")
                        {
                            _Payment = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["deposito"].ToString()) / Reservas);
                            //MessageBox.Show("" + _Payment);
                            
                        }
                        else { _Payment = 0; }
                    }
                    else
                    {
                        _referencia = dt.Rows[i]["referencia"].ToString();  // +" " + dt.Rows[i]["apellido"].ToString();
                        
                        _referencia = u.Parseacomilla(_referencia);
                        _referencia = u.ParseaSlash(_referencia);


                        _Payment = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["deposito"].ToString()));
                    }

                    JumpType = dt.Rows[i]["desc_salto"].ToString();

                    if (JumpType != "T-JUMP")
                    {
                        JumpType = "TANDEM";
                       
                    }
                   


                    if (_video == 1) { _jumptype = JumpType + " C/VIDEO"; } else { _jumptype = JumpType; }

                    //DataSet dsjumptype = new DataSet();
                    //tabla = "CT_JUMP_TYPE"; condicion = " where jump_type = '" + _jumptype + "'";
                    //sql = " select idjumptype, jump_type, price from dbo.CT_JUMP_TYPE ";
                    //dsjumptype = conexion.ConsultaUniversal(sql, condicion, tabla);
                    //_Charge = Convert.ToInt32(Convert.ToDecimal(dsjumptype.Tables[0].Rows[0].ItemArray[2].ToString()));
                    _Charge = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["precio"].ToString()));

                    //MessageBox.Show(" " + dt.Rows[i]["fecha_salto"].ToString());

                     _fecha_salto = dt.Rows[i]["fecha_salto"].ToString();
                     _fecha_salto = u.Parseacomillas(_fecha_salto);
                     _fecha_salto = u.ParseaEspecial(_fecha_salto);


                    //_JumpDate = Convert.ToDateTime(dt.Rows[i]["fecha_salto"].ToString());
                    _JumpDate = dt.Rows[i]["fecha_salto"].ToString();
                    _JumpDate = u.Parseacomillas(_JumpDate);
                    _JumpDate = u.ParseaEspecial(_JumpDate);



                    _email = dt.Rows[i]["email"].ToString();
                   

                    _email = u.Parseacomilla(_email);
                    _email = u.Parseacomillas(_email);
                    _email = u.ParseaSlash(_email);

                    
                    //for (int a = 0; a <= Reservas; a++)
                    //{


                    AddTandemUp(_Nombre, _Apellido, _referencia, _jumptype, _Payment, _Charge, _JumpDate, _email);
                  
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try process file " + ex.Message + " |  Reference:" + _referencia + " jumpdate " + _JumpDate + " FEcha_salto " + _fecha_salto);
            }

        }
        #endregion 


        #region Evento click del boton UpLoad
        private void btn_upload_Click(object sender, EventArgs e)
        {
            pb_UpLoad.Visible = true;
            pb_UpLoad.Minimum = 0;
            pb_UpLoad.Value = 1;
            try
            {
                LeerArchivo();
                MessageBox.Show(" Load successfully " + pb_UpLoad.Value);
                pb_UpLoad.Visible = false;
                id = 1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try Upload Reservations, " + ex.Message);
            }
        }
        #endregion 

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }



    }
}
