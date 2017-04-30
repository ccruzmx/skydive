using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BIXOLON_Sample_program
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            try
            {
                StringBuilder strVersion = new StringBuilder(256);
                if (BIXOLONSkyDiveCuautla.BXLLIB.GetDllVersion(strVersion))
                    lblDllVersion.Text = "Version " + strVersion.ToString();
                else
                    lblDllVersion.Text = "Unknown";
                strVersion = null;

                btnPrint.Enabled = GetInstalledPrinter();

                // Paper size 
                // Default 4x6 inch -> (4*25.4) x (6*25.4) mm
                double value = 4 * 25.4;
                txtP_Width.Text = value.ToString("###0.###");
                value = 6 * 25.4;
                txtP_Height.Text = value.ToString("###0.###");

                txtMargin_X.Text = "0";
                txtMargin_Y.Text = "0";

                cmbSpeed.SelectedIndex = BIXOLONSkyDiveCuautla.BXLLIB.SPEED_50;
                cmbDensity.SelectedIndex = (14 - 1);
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
            
        }

        private void btnResearch_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = GetInstalledPrinter();
        }

        private bool GetInstalledPrinter()
        {
            cmbPrtList.Items.Clear();

            
            StringBuilder strPrinters = new StringBuilder(4096);
            if (BIXOLONSkyDiveCuautla.BXLLIB.GetBIXOLON_PrinterList(strPrinters) <= 0) return false;

            char[] seps = { '^' };
            string[] strPrtList = strPrinters.ToString().Split(seps);

            for (int k = 0; k < strPrtList.Length; k++)
            {
                if(strPrtList[k].Trim().Equals("")) break;

                cmbPrtList.Items.Add(strPrtList[k]);
            }

            if (cmbPrtList.Items.Count > 0)
            {
                cmbPrtList.SelectedIndex = 0;
                return true;
            }

            return false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 
            try
            {
                if (txtP_Width.Text.Equals("") || txtP_Width.Text.Equals(".")) txtP_Width.Text = "0";
                if (txtP_Height.Text.Equals("") || txtP_Height.Text.Equals(".")) txtP_Height.Text = "0";

                if (txtMargin_X.Text.Equals("") || txtMargin_X.Text.Equals(".")) txtMargin_X.Text = "0";
                if (txtMargin_Y.Text.Equals("") || txtMargin_Y.Text.Equals(".")) txtMargin_Y.Text = "0";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
         

            string strPrinterName = cmbPrtList.Text;

            // BIXOLON SLP-770II, BIXOLON SLP-770III
            // BIXOLON SLP-D420, BIXOLON SLP-D423, BIXOLON SLP-T400, BIXOLON SLP-T403, 
            // BIXOLON SLP-TX400, BIXOLON SLP-TX403 ...
            // ...
            //strPrinterName = "\\\\192.168.100.191\\BIXOLON SRP-770III";
            if (BIXOLONSkyDiveCuautla.BXLLIB.ConnectPrinter(strPrinterName) == false)
                return;

            int MM2D = 8; // mm to dot
            // 203 DPI : 1mm = 8 dots
            // 300 DPI : 1mm = 12 dots
            MM2D = BIXOLONSkyDiveCuautla.BXLLIB.GetPrinterResolution() < 300 ? 8 : 12;

            int nPaper_Width = Convert.ToInt32(double.Parse(txtP_Width.Text)*MM2D);
            int nPaper_Height = Convert.ToInt32(double.Parse(txtP_Height.Text) * MM2D);
            int nMarginX = Convert.ToInt32(double.Parse(txtMargin_X.Text) * MM2D);
            int nMarginY = Convert.ToInt32(double.Parse(txtMargin_Y.Text) * MM2D);

            int nSpeed = cmbSpeed.SelectedIndex;
            int nDensity = Convert.ToInt32(cmbDensity.Text);

            bool bAutoCut = chkCutter.Checked;
            bool bReverseFeeding = chkRevFeeding.Checked;

            int nSensorType = BIXOLONSkyDiveCuautla.BXLLIB.GAP;
            if (rdoBmark.Checked) nSensorType = BIXOLONSkyDiveCuautla.BXLLIB.BLACKMARK;
            else if (rdoContinuous.Checked) nSensorType = BIXOLONSkyDiveCuautla.BXLLIB.CONTINUOUS;

            //	Set the label start
            BIXOLONSkyDiveCuautla.BXLLIB.StartLabel();

            //	Set Label and Printer
            //BXLLIB.SetConfigOfPrinter(BXLLIB.SPEED_50, 17, BXLLIB.TOP, false, 0, true);
            BIXOLONSkyDiveCuautla.BXLLIB.SetConfigOfPrinter(nSpeed, nDensity, BIXOLONSkyDiveCuautla.BXLLIB.TOP, bAutoCut, 0, bReverseFeeding);

            /* 
               1 Inch : 25.4mm
               1 mm   :  8 Dot in 203 DPI such as TX400, T400, D420, D220, SRP-770, SRP-770II
               1 mm   : 12 Dot in 300 DPI such as TX403, T403, D423, D223
               4 Inch : 25.4  * 4 * 8 = 812.8
               6 Inch : 25.4  * 4 * 8 = 1219.2
            */

            //BXLLIB.SetPaper(16, 16, 813, 1220, BXLLIB.GAP, 0, 16); // 4 inch (Width) * 6 inch (Hiehgt)
            BIXOLONSkyDiveCuautla.BXLLIB.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 16); // 4 inch (Width) * 6 inch (Hiehgt)            

            if (rdoDt.Checked) // Direct thermal
                BIXOLONSkyDiveCuautla.BXLLIB.PrintDirect("STd");
            else // Thermal transfer
                BIXOLONSkyDiveCuautla.BXLLIB.PrintDirect("STt");

            //	Clear Buffer of Printer
            BIXOLONSkyDiveCuautla.BXLLIB.ClearBuffer();


            // Draw BOX (Fill color is black)
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(370, 40, 760, 150, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);

            //	Draw Lines
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(18, 164, 798, 170, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(18, 410, 784, 415, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            //BXLLIB.PrintBlock(553, 170, 558, 413, BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(548, 170, 553, 413, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(18, 616, 784, 621, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(20, 781, 786, 786, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(18, 928, 784, 933, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(241, 783, 246, 932, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintBlock(486, 784, 491, 933, BIXOLONSkyDiveCuautla.BXLLIB.LINE_OVER_WRITING, 0);


            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            BIXOLONSkyDiveCuautla.BXLLIB.PrintTrueFontLib(22, 100, "Arial", 16, 0, true, true, false, "Sample Label-1");

            //Print string using Vector Font
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font selection
            //                  U: ASCII (1Byte code)
            //                  K: KS5601 (2Byte code)
            //                  B: BIG5 (2Byte code)
            //                  G: GB2312 (2Byte code)
            //                  J: Shift-JIS (2Byte code)
            // P4  : Font width (W)[dot]
            // P5  : Font height (H)[dot]
            // P6  : Right-side character spacing [dot], Plus (+)/Minus (-) option can be used. Ex) 5, +3, -10	
            // P7  : Bold
            // P8  : Reverse printing
            // P9  : Text style  (N : Normal, I : Italic)
            // P10 : Rotation (0 ~ 3)
            // P11 : Text Alignment (Optional)
            // P12 : Text string write direction
            // P13 : data to print
            // ※ : Third parameter, 'ASCII' must be set if Bixolon printer is SLP-T400, SLP-T403, SRP-770 and SRP-770II.
            //BXLLIB.PrintVectorFont(22, 65, BXLLIB.ASCII, 34, 34, "0", false, false, false, BXLLIB.ROTATE_0, BXLLIB.LEFTALIGN, BXLLIB.LEFTTORIGHT, "Sample Label-2");

            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(400, 55, BIXOLONSkyDiveCuautla.BXLLIB.ENG_48X76, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "BIXOLON");

            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 174, BIXOLONSkyDiveCuautla.BXLLIB.ENG_24X38, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "SHIP TO:");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 234, BIXOLONSkyDiveCuautla.BXLLIB.ENG_19X30, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "BIXOLON");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 280, BIXOLONSkyDiveCuautla.BXLLIB.ENG_16X25, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "7th FL, MiraeAsset Venture Tower,");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 310, BIXOLONSkyDiveCuautla.BXLLIB.ENG_16X25, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "685, Sampyeong-dong, Bundang-gu,");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 340, BIXOLONSkyDiveCuautla.BXLLIB.ENG_16X25, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "Seongnam-si, Gyeonggi-do,");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(20, 370, BIXOLONSkyDiveCuautla.BXLLIB.ENG_16X25, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "463-400, KOREA");

            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(26, 421, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "POSTAL CODE");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(503, 798, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "DESTINATION");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(42, 841, BIXOLONSkyDiveCuautla.BXLLIB.ENG_32X50, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "30 Kg");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(25, 798, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "WEIGHT:");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(259, 798, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "DELIVERY NO:");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(23, 630, BIXOLONSkyDiveCuautla.BXLLIB.ENG_12X20, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "AWB:");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(274, 841, BIXOLONSkyDiveCuautla.BXLLIB.ENG_32X50, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "425518");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(104, 627, BIXOLONSkyDiveCuautla.BXLLIB.ENG_19X30, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, false, "8741493121");
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDeviceFont(565, 841, BIXOLONSkyDiveCuautla.BXLLIB.ENG_32X50, 1, 1, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "ICN");



            //	Prints 1D Barcodes
            BIXOLONSkyDiveCuautla.BXLLIB.Print1DBarcode(69, 458, BIXOLONSkyDiveCuautla.BXLLIB.CODE39, 4, 8, 137, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "1234567890");
            BIXOLONSkyDiveCuautla.BXLLIB.Print1DBarcode(127, 662, BIXOLONSkyDiveCuautla.BXLLIB.CODE93, 4, 8, 90, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, true, "8741493121");

            //	Prints a MAXICODE 
            string Direct_MaxiCode_2DBarcode_Cmd = "B2555,180,M,0,'999,840,06810,7317,BIXOLON LABEL PRINTER'";
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDirect(Direct_MaxiCode_2DBarcode_Cmd);//

            //	Prints a PDF417 
            string Direct_PDF_2DBarcocde_Cmd = "B2200,945,P,8,8,0,0,0,1,2,14,0,'BIXOLON Label Printer, This is for test.'";
            BIXOLONSkyDiveCuautla.BXLLIB.PrintDirect(Direct_PDF_2DBarcocde_Cmd);//

            BIXOLONSkyDiveCuautla.BXLLIB.PrintCircle(10, 1055, 3, 2);


            // Prints a QRCode
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : MODEL selection (1, 2)
            //  P4 : ECC Level (1 ~ 4)
            //  P5 : Size of QRCode (1 ~ 4)
            //  P6 : Rotation (0 ~ 3)
            //  P7 : data to print
            string QRCode_data = "QRCode sample test 123";//"家裸多羅馬바 123";//가나다라마바사아자차카타파하";// "QRCode with UTF-8 Encoding";
            BIXOLONSkyDiveCuautla.BXLLIB.PrintQRCode(22, 940, BIXOLONSkyDiveCuautla.BXLLIB.QRMODEL_2, BIXOLONSkyDiveCuautla.BXLLIB.QRECCLEVEL_M, BIXOLONSkyDiveCuautla.BXLLIB.QRSIZE_4, BIXOLONSkyDiveCuautla.BXLLIB.ROTATE_0, QRCode_data);


            // Print Image
            BIXOLONSkyDiveCuautla.BXLLIB.PrintImageLib(200, 1035, "free.bmp", BIXOLONSkyDiveCuautla.BXLLIB.DITHER_1, false);
            BIXOLONSkyDiveCuautla.BXLLIB.PrintImageLib(450, 1035, "BIXOLON.bmp", BIXOLONSkyDiveCuautla.BXLLIB.DITHER_2, false);

            //	Print Command
            BIXOLONSkyDiveCuautla.BXLLIB.Prints(1, 1);

            //	Set the Label End
            BIXOLONSkyDiveCuautla.BXLLIB.EndLabel();

            //	Disconnect Printer Driver
            BIXOLONSkyDiveCuautla.BXLLIB.DisconnectPrinter();
        }


        private void txtMargin_X_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력 가능하도록...
            pInputValidateFloat(ref e, sender);
        }

        private void txtP_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력 가능하도록...
            pInputValidateFloat(ref e, sender);
        }

        private void txtP_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력 가능하도록...
            pInputValidateFloat(ref e, sender);
        }

        private void txtMargin_Y_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력 가능하도록...
            pInputValidateFloat(ref e, sender);
        }

        // 숫자 입력 처리
        private void pInputValidateDigit(ref System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.Handled = true;
            else if (e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Back) || e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Delete))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        // 숫자 입력 처리(핸들, 소숫점 포함여부) 
        private void pInputValidateFloat(ref System.Windows.Forms.KeyPressEventArgs e, object sender)
        {
            int nPreLen = 4;    // 정수부 길이
            int nPostLen = 3;   // 소수부 길이 

            //백스페이스는 그냥 허용
            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show(" You will can't print this tickets after close this window; are you sure close? ", "Warning", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }
        }

    }
}
