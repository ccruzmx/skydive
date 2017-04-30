using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;



namespace SkyDiveCuautla
{
    public partial class acceso : Form
    {

        #region Variables

     
        ConectaBD Menus;
        ConectaBD Permisos = new ConectaBD();
   
        utilerias u = new utilerias();
        Image image= Image.FromFile("C:\\SkydiveCuautla\\system\\image\\Cuautla.png");

        #endregion


        public acceso()
        {
            InitializeComponent();
        }

        private void btn_acceso_Click(object sender, EventArgs e) 
        {


            try
            {

                
                Menus = new ConectaBD();

                if (Menus.ValidarCredenciales(txb_usuario.Text, txb_contraseña.Text))
                {
                    int idusuario = misglobales.usuario_idusuario;
                    if (misglobales.estatus_idestatus != 1)
                    {
                        //esta bloqueado
                        lblerrorlogin.Visible = true;
                        lblerrorlogin.Text = "User is " + misglobales.estatus_estatus + ", please contact the system administrator ";
                        misglobales.credenciales = false;
                        txb_usuario.Focus();
                    }
                    else
                    {
                        // esta activo
                        //if (Menus.RegistroLog(idusuario, "acceso", "ingreso exitoso al sistema"))
                        //{

                            misglobales.credenciales = true;

                            
                            if (misglobales._Login == 1) 
                            {
                                misglobales._Objeto = "Frm_JumperTransactionEntires"; 
                                bool lopresento = Permisos.habilitado("Frm_JumperTransactionEntires");
                                if (lopresento)
                                {

                                    Menus.RegistroLog(misglobales.usuario_idusuario, "Jumpers", "Ingreso a transacciones");
                                    Operacion.Frm_JumperTransactionEntires _Transactions = new Operacion.Frm_JumperTransactionEntires();
                                    _Transactions.Show();
                                    misglobales._Login = 0;
                                }
                            } //Abre las transacciones
                            else if (misglobales._Login == 2) 
                            {
                                misglobales._Objeto = "Padlock";
                                Menus.RegistroLog(misglobales.usuario_idusuario, "Jumpers", "Habilito Padlock");
                                bool lopresento = Permisos.habilitado("Padlock");
                                misglobales._Autoriza = lopresento; 
                            } //PADLOCK 1: Allow Transaction with no Balance
                            else if (misglobales._Login == 3)
                            {
                                misglobales._Objeto = "ChangeCharge";
                              
                                    Menus.RegistroLog(misglobales.usuario_idusuario, "TandemUp", misglobales.TandemName + " Se le cambio el Jump Price de: " + misglobales.TandemJumpPrice);
                                    bool lopresento = Permisos.habilitado("ChangeCharge");
                                    misglobales._Autoriza = lopresento;   
                                
                            }
                            else if (misglobales._Login == 4)
                            {
                                misglobales._Objeto = "ChangePriceVideo";
                                Menus.RegistroLog(misglobales.usuario_idusuario, "TandemUp", misglobales.TandemName + " Se le cambio el Precio del Video para ser modificado de: " + misglobales.TandemVideoPrice );
                                bool lopresento = Permisos.habilitado("ChangePriceVideo");
                                misglobales._Autoriza = lopresento;
                            }
                            else if (misglobales._Login == 5)
                            {
                                misglobales._Objeto = "ChangePriceHandVideo";
                                Menus.RegistroLog(misglobales.usuario_idusuario, "TandemUp", misglobales.TandemName + " Se le cambio el Precio  del Hand Video para ser modificado de:" + misglobales.TandemHandVideoPrice );
                                bool lopresento = Permisos.habilitado("ChangePriceHandVideo");
                                misglobales._Autoriza = lopresento;
                            }
                            else if (misglobales._Login == 6)
                            {
                                misglobales._Objeto = "ChangeManifest";
                                Menus.RegistroLog(misglobales.usuario_idusuario, "Manifest", " Habilitó el Campo filtro fecha para ver o modificar el manifiesto con otra fecha ");
                                bool lopresento = Permisos.habilitado("ChangeManifest");
                                misglobales._Autoriza = true; //lopresento;
                            }

                            else
                            {
                                Menus.RegistroLog(misglobales.usuario_idusuario, "acceso", "ingreso exitoso al sistema");
                            }
                            this.Close();
                            Permisos.CloseDB();

                        }
                    //    else
                    //    {
                    //        lblerrorlogin.Text = "Error con la BD, intente mas tarde";
                    //        misglobales.credenciales = false;
                    //        txb_usuario.Focus();
                    //    }
                    //}


                    
                }
                else 
                {
                    lblerrorlogin.Visible = true;
                    lblerrorlogin.Text = "Usuario o Contraseña invalidos, verifique e intente de nuevo ";
                    misglobales.credenciales = false;
                    txb_usuario.Focus();
                }

            }
            catch (Exception es)
            {
                lblerrorlogin.Visible = true;
                lblerrorlogin.Text = "Error de sistema, contacte al administrador (" + es.Message +")";
                misglobales.credenciales = false;
            }
        }

        private void txb_usuario_TextChanged(object sender, EventArgs e)
        {
            lblerrorlogin.Text = "";
        }

        private void acceso_Load(object sender, EventArgs e)
        {
            misglobales._sysversion = "151";
            lbl_version.Text = "Versión: 2 Build(" + misglobales._sysversion + ")";
            String ServerName = "hectorh";
            String LogoName = "logo.png";
            StreamReader objReader = new StreamReader("C:\\SkyDiveCuautla\\BaseDatos\\server.txt");
            string sLine = "";
            Int32 iLines = 1;
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    if (iLines == 1) { ServerName = sLine;}
                    if (iLines == 2) { LogoName = sLine; }
                    iLines = iLines + 1;
            }
            objReader.Close();
            misglobales.cadenaconexionSQL = "data source=" + ServerName + "; initial catalog=bd_skydivecuautla; user ID=sdcuser; password=skydive%; Trusted_Connection=False;";
            misglobales.cadenaconexionSQLmaster = "data source=" + ServerName + "; initial catalog=master; user ID=sa; password=67yhju%; Trusted_Connection=False;";
            misglobales.servername = ServerName;
            pb_logo.Image = System.Drawing.Image.FromFile("C:\\SkydiveCuautla\\system\\image\\" + LogoName+".png");
            //image = u.Redimensionar(image, 311, 69);
            //image.Save("C:\\SkydiveCuautla\\system\\image\\logo.png";
            //image.Dispose();
            //pb_logo.Size.Width = System.Drawing.Bitmap.GetPixelFormatSize(311);
            //pb_logo.Size.Height = 69;

            try
            {

                ConectaBD conexion = new ConectaBD();
                DataSet ds = new DataSet();


                ds = conexion.ConsultaUniversal(" Select valor FROM dbo.CT_PARAMETROS ", " WHERE elemento = 'SYS_VERSION' and valor = " + misglobales._sysversion, " CT_PARAMETROS ");


                if (ds.Tables[0].Rows.Count >= 1)
                {
                    btn_acceso.Enabled = true;
                    lblerrorlogin.Visible = false;
                    
                }
                else
                {
                    btn_acceso.Enabled = false;
                    lblerrorlogin.Visible = true;
                    lblerrorlogin.ForeColor = Color.Red;
                    lblerrorlogin.BackColor = Color.Yellow;
                    lblerrorlogin.Text = " Error: Please Update the Application version ";
                    

                }
                misglobales._conectando = true;
            }
            catch (Exception es)
            {
                MessageBox.Show(" ERROR: "  + es.Message);
                misglobales._conectando = false;

                



            }
            
        }

        private void lbl_version_Click(object sender, EventArgs e)
        {

        }

        private void acceso_FormClosing(object sender, FormClosingEventArgs e)
        {
         

        }

        private void acceso_Activated(object sender, EventArgs e)
        {
            if (misglobales._conectando)
            { }
            else
            { this.Close(); }

        }
    }
}
