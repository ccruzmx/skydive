using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SkyDiveCuautla
{
    class utilerias
    {

        ConectaBD conexion = new ConectaBD();
        string sql, tabla, condicion, campos, valores;

    #region metodo carga textbox desde el grid
            public void Pasarcampo(DataGridView midgv, TextBox txb, string columna)
        {
            // especifico que campo de la fila que este seleccionada vamos a pasar al textbox

            txb.Text = midgv.Rows[midgv.CurrentRow.Index].Cells[columna].Value.ToString();

        }
    #endregion

    #region Método carga combobox desde el grid
        public void Pasarcombo(DataGridView midgv, ComboBox txb, string columna)
        {
            // especifico que campo de la fila que este seleccionada vamos a pasar al ComboBox

            txb.SelectedText = midgv.Rows[midgv.CurrentRow.Index].Cells[columna].Value.ToString();

        }
    #endregion


        #region método que determina la impresora
        public String ImpresoraSeleccionada( String ImpresoraCombo)
        {
            if (ImpresoraCombo == "Bixolon SLP-T400")
            {
                misglobales._impresora = "bixolont400";

            }
            if (ImpresoraCombo == "Bixolon SRP-350Plus")
            {
                misglobales._impresora = "bixolonsrp350plus";

            }
            if (ImpresoraCombo == "Okipos 407")
            {
                misglobales._impresora = "okipos";

            }

            return misglobales._impresora;

        }

        #endregion

        #region Redimensionamiento de imagenes
        private Image Redimensionar(Image Imagen, Int32 Ancho, Int32 Alto, Int32 resolucion)
        {
            using (Bitmap imagenBitMap = new Bitmap(Ancho, Alto, PixelFormat.Format32bppRgb))
            {
                imagenBitMap.SetResolution(resolucion, resolucion);
                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitMap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(Imagen, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Imagen.Width, Imagen.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitMap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    Imagen = Image.FromStream(imagenMemoryStream);
                }
            }
            return Imagen;
        }


        public Image Redimensionar(Image image, Int32 SizeHorizontalPercent, Int32 SizeVerticalPercent)
        {
            Int32 anchoDestino = image.Width * SizeHorizontalPercent / 100;
            Int32 altoDestino = image.Height + SizeVerticalPercent / 100;
            Int32 resolucion = Convert.ToInt32(image.HorizontalResolution);
            return this.Redimensionar(image, anchoDestino, altoDestino, resolucion);
        }

        #endregion 

        #region Metodo para calcular el Balance
        public Decimal Balance()
    {
    
    
    DataSet dsledger;
    sql = @" SELECT  jumper_code, isnull( (sum(charge)  + sum(payment*-1)) + sum(staff_payment) + sum(transfer_amt),0)  AS BALANCE
                FROM dbo.TB_LEDGER";
    tabla = "TB_LEDGER";
    condicion = @" WHERE jumper_code = '" + misglobales.jumper_code.ToString() + @"' 
                group by jumper_code";

    dsledger = conexion.ConsultaUniversal(sql, condicion, tabla);
    conexion.CloseDB();
    if (dsledger.Tables[0].Rows.Count == 0)
    {
        return 0;
    }
    else
    {
        return Convert.ToDecimal(dsledger.Tables[0].Rows[0].ItemArray[1].ToString());

    }


    }
    #endregion 

    #region Metodo para calcular el Balance en Saltos
    public Int32 BalanceSaltos()
    {
        string sql, tabla, condicion;
        ConectaBD conexion = new ConectaBD();
        DataSet dsledger;
        sql = @" SELECT isnull(COUNT(folioticket), 0)
                    FROM dbo.TB_TICKETS_BALANCE";
        tabla = "TB_TICKETS_BALANCE";
        condicion = @" WHERE idestatus = 1 AND codejumper = '" + misglobales.jumper_code.ToString() + "'";

        dsledger = conexion.ConsultaUniversal(sql, condicion, tabla);
        conexion.CloseDB();
        if (dsledger.Tables[0].Rows.Count == 0)
        {
            return 0;
        }
        else
        {
            return Convert.ToInt32(dsledger.Tables[0].Rows[0].ItemArray[0].ToString());
        }
    }
    #endregion 

    #region Formatodgv2
    public void Formatodgv2(DataGridView midgv)
    {
    midgv.Dock = DockStyle.Fill;
    midgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    midgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    midgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
    midgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    midgv.ColumnHeadersDefaultCellStyle.Font = new Font(midgv.Font, FontStyle.Bold);
    midgv.ColumnHeadersVisible = false;
    midgv.DefaultCellStyle.SelectionBackColor = Color.LightGray;
    midgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
    midgv.BorderStyle = BorderStyle.Fixed3D;
    midgv.ReadOnly = true;
    midgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    midgv.RowHeadersVisible = false;
    midgv.AllowUserToAddRows = false;
    midgv.BackgroundColor = Color.White;
  

    }
    #endregion 

    #region Formato General de los DataGridView en el Sistema
    public void Formatodgv(DataGridView midgv)
    {
        midgv.Dock = DockStyle.Fill;
        midgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        midgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        midgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
        midgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        midgv.ColumnHeadersDefaultCellStyle.Font = new Font(midgv.Font, FontStyle.Bold);
        midgv.DefaultCellStyle.SelectionBackColor = Color.Beige;
        midgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        midgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        midgv.BorderStyle = BorderStyle.Fixed3D;
        midgv.ReadOnly = true;
        midgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        midgv.RowHeadersVisible = false;
        midgv.AllowUserToAddRows = false;
    }
    #endregion

    #region Método valida correo
    public  bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn,
               @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
    }
    #endregion

    #region Método valida longitud
    public bool IsValidLength(string strIn, int maximo)
    {
        if (strIn.Length >= maximo)
        {
            return false;
        }
        return true;

    }
    #endregion

    #region Método para escape de comilla simple
    public String Parseacomilla(String campo)
    { 
            
        String str = campo.ToString();
        str = str.Replace("'", "''");

        return str;
    }
    #endregion

    #region Método para escape de comillasle
    public String ParseaEspecial(String campo)
    {

        String str = campo.ToString();
        str = str.Replace(@"""",@"");
        return str;
    }
    #endregion


    #region Método para escape de comillasle
    public String Parseacomillas(String campo)
    {

        String str = campo.ToString();
        str = str.Replace(@"""", @"\""");

        return str;
    }
    #endregion

    #region Método para escape Diagonales
    public String ParseaSlash(String campo)
    {

        String str = campo.ToString();
        str = str.Replace(@"\", @"");

        return str;
    }
    #endregion



    #region LoadAutoComplete
    public  AutoCompleteStringCollection LoadAutoComplete(DataSet ds, string campo)
    {

        AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            stringCol.Add(Convert.ToString(row[campo]));
        }
        return stringCol;
    }
    #endregion

    #region Metodo para imprimir el(los) ticket(s)
    public void ImprimeTicket1()
    {
        //SerialPort comPort = new SerialPort("COM1", 2400); // change the parameters to your printers specs.
        //comPort.Open();
        //comPort.Write("\x1B\x63\x33"); // write to your printer here
        //comPort.Close();

    }
    #endregion 

    #region Metodo para contabilizar los saltos de los Instructores
    public void ActividadInstructor(String CampoActualizar, Int32 valor, Int32 idjumper, String MasoMenos)
    {

        try
        {
            campos = "" + CampoActualizar + " = " + CampoActualizar + MasoMenos + valor;
            condicion = " Where CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  and  idjumper = " + idjumper;
            tabla = "tb_instructors_activity";
            conexion.UpdateTabla(campos, tabla, condicion);

            campos = " jumps_totals =  jumps_premanifested + jumps_manifested + jumps_rejected ";
            tabla = "tb_instructors_activity";
            condicion = " Where CONVERT(VARCHAR(26), REGISTERTIME, 23)  = CONVERT(VARCHAR(26), GETDATE(), 23)  and  idjumper = " + idjumper;
            conexion.UpdateTabla(campos, tabla, condicion);

        }
        catch (Exception ex)
        { 
        MessageBox.Show(" Error try update jumps qty for this instructor " + ex.Message);
        }
    
    }
    #endregion

    #region Aplica cargo a ledger
    public void AplicaLedger(String _code, String _jumper_code, DateTime _Updatedate  ,String _id_charge_type, Decimal _charge, String _codigo_jumptype, Decimal _transfer_amt, String _transfer_jumper_name, Decimal _payment,
         Decimal _staff_payment, String _idmanifestold, String _idmanifiesto, Int32 _manifest_line_nbr, String _id_prospect, String _name, Int32 _whoenteredid, Int32 _WhoChanged_ID,
        Int32 _WhenChanged, Int32 _BookedFromTeam, String _Team_Name, Int32 _EOD_Processed, Int32 _DateEODProcessed, Int32 _idoficina, String _nota, Int32 _idusuario)
    {
        // PREPARA QUERY PARA INSERT
        campos = @"code, jumper_code, updatedate, idchargetype, charge, codigo_jumptype, transfer_amt, transfer_jumper_name, 
                           payment, staff_payment, idmanifestold, idmanifiesto, manifest_line_nbr, id_prospect, name, whoenteredid, 
                           WhoChanged_ID, WhenChanged, BookedFromTeam, Team_Name, EOD_Processed, DateEODProcessed, idoficina, nota, idusuario";
        tabla = "TB_LEDGER";
        valores = "'" + _code + "', '" + _jumper_code + "', convert(varchar(10),'" + _Updatedate + "',23), '" + _id_charge_type + "', " + _charge + ", '" + _codigo_jumptype + "', " +
                  _transfer_amt + ", '" + _transfer_jumper_name + "', " + _payment.ToString() + ", " + _staff_payment + ", '" + _idmanifestold + "', '" + _idmanifiesto +
                  "', " + _manifest_line_nbr + ", '" + _id_prospect + "', '" + _name + "', " + _whoenteredid + ", " + _WhoChanged_ID +
                  ", " + _WhenChanged + ", " + _BookedFromTeam + ", '" + _Team_Name + "', " + _EOD_Processed + ", " + _DateEODProcessed +
                  ", " + _idoficina + ", '" + _nota + "', " + _idusuario;

        try
        {
            //se almacena la transacción (LEDGER)

            conexion.InsertTabla(campos, tabla, valores);
            //Se registra el balance en saltos
            //BalanceJumpUpdate();
            //Se actualiza el balance el pesos
            misglobales.jumper_code = _jumper_code;
            campos = " Balance = " + Balance();
            condicion = " where codigo ='" + misglobales.jumper_code + "'";
            tabla = "ct_jumper";
            conexion.UpdateTabla(campos, tabla, condicion);
            misglobales._TotalBalance = Convert.ToDecimal(Balance());

            

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error try insert new ledger record, please contact system administrator", ex.Message);

        }

    }
    #endregion 

    #region Valida Manifiesto del Jumper
    public Boolean SePuedeManifestar(Int32 idjumper, String campo)
    {

        sql = @"SELECT * FROM dbo.TB_MANIFIESTO WITH(NOLOCK)
                 WHERE TB_MANIFIESTO.IDVUELO = " + misglobales.id1 +
               "  AND " + campo + " = " + idjumper;

        DataSet dsvalida= conexion.ConsultaUniversal(sql, "","TB_MANIFIESTO");

        if (dsvalida.Tables[0].Rows.Count > 0)
        { return false; }
        else
        { return true; }
    }
    #endregion 

    #region Valida Excepciones en costo
    public Decimal JumperException(int idjumper, string jumpercode,  string jump_type_code)
    {

        tabla = "cT_jumper_exceptions";
        sql = "  select id, idjumper, jumper_code, idjumptype, jump_type_code, charge from cT_jumper_exceptions";

        if (idjumper == 0)
        {
            condicion = " where jumper_code = '" + misglobales.jumper_code + "' and jump_type_code = '" + jump_type_code + "'  ";
        }
        else
        {
            condicion = " where idjumper = " + idjumper + " and jump_type_code = '" + jump_type_code + "'  ";
        }
        try
        {
            DataSet dsexcepcion = conexion.ConsultaUniversal(sql, condicion, tabla);

            if (dsexcepcion.Tables[0].Rows.Count > 0)
            {
                // si hay excpeción en el precio
                return Convert.ToDecimal(dsexcepcion.Tables[0].Rows[0].ItemArray[5].ToString());
            }
            else
            {

                tabla = "CT_JUMP_TYPE";
                sql = "select idjumptype, jump_type, price from CT_JUMP_TYPE ";
                condicion = " where jump_type = '" + jump_type_code + "'";

                try
                {
                    DataSet dspreciolista = conexion.ConsultaUniversal(sql, condicion, tabla);

                    if (dspreciolista.Tables[0].Rows.Count > 0)
                    {
                        return Convert.ToDecimal(dspreciolista.Tables[0].Rows[0].ItemArray[2].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Warning not exist price for this jump type " + jump_type_code.ToString() + " please contact system administrator ");
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error extract price of Jump Type Catalog " + ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error try find exceptcion, contact system administrator  " + ex.Message);
        }



        return 0;
    }
    #endregion 


    }

}
