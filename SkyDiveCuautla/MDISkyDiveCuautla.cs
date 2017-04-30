using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace SkyDiveCuautla
{
    public partial class MDISkyDiveCuautla : Form
    {

        #region Variables
        private int childFormNumber = 0;
        private DataTable dtMenus;
        private System.Reflection.Assembly Ensamblado;
        ConectaBD conexion = new ConectaBD();
        String sql, tabla, condicion;
        #endregion

        #region Constructor
        public MDISkyDiveCuautla()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos de Eventos para el Menu por definir
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion

        #region Load
        private void MDISkyDiveCuautla_Load(object sender, EventArgs e)
        {


            MDISkyDiveCuautla.ActiveForm.Text = "Skydive Management Ver 2 Build(" + misglobales._sysversion + ")";

            cmb_printer.SelectedIndex = 0;
            cmb_printer.Enabled = true;
            lbl_printer.Visible = false;
            cmb_printer.Visible = false;
            

            if (cmb_printer.Text == "Bixolon SLP-T400")
            {
                misglobales._impresora = "bixolont400";
 
            }
            if (cmb_printer.Text == "Bixolon SRP-350Plus")
            {
                misglobales._impresora = "bixolonsrp350plus";

            }
            if (cmb_printer.Text == "Okipos 407")
            {
                misglobales._impresora = "okipos";

            }


            if (misglobales.perfil_idperfil == 6)
            {
                toolStripButton1.Visible = false;
            }
            else {
                toolStripButton1.Visible = true;
            }

            tabla = "CT_Jumper";
            sql = "select idjumper, codigo, nombre from ct_jumper ";
            condicion = " where codigo = '9999-Tandem' ";

            DataSet dsidjumpertandem = conexion.ConsultaUniversal(sql, condicion, tabla);
            misglobales.idJumperTandem = Convert.ToInt32( dsidjumpertandem.Tables[0].Rows[0].ItemArray[0].ToString());
            
            try
            {

                this.BackgroundImage = new Bitmap("C:\\SkyDiveCuautla\\bg-home.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;

            }

            catch
            {

                this.BackgroundImage = null;

            }
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            //menuStrip.Items.Clear();
            ProgressBar.Visible = false;
            CargarMenus(misglobales.perfil_idperfil);
            lblusuario.Text = misglobales.usuario_autenticacion + "  |   USER: " + misglobales.usuario_nombre + " " + misglobales.usuario_paterno + "  |   OFFICE: " + misglobales.oficina_oficina + "   |   ROL: " + misglobales.perfil_perfil + " |    SERVER: " + misglobales.servername + "               ";

        }
        #endregion

        #region Método CargaMenus
        private void CargarMenus(Int32 id_Perfil)
        {
            ConectaBD OpcionesMenu = new ConectaBD();
            dtMenus = new DataTable();
            dtMenus = OpcionesMenu.MenusWindowsDelPerfil(id_Perfil);
            foreach (DataRow MenuPadre in dtMenus.Select("idobjeto=idobjetopadre", "Idobjeto ASC"))
            {
                ToolStripItem[] Menu = new ToolStripItem[1];
                Menu[0] = new ToolStripMenuItem();
                Menu[0].Name = MenuPadre["Idobjeto"].ToString();
                Menu[0].Text = MenuPadre["Descripcion"].ToString();
                Menu[0].Tag = MenuPadre["Url"].ToString();
                //Menu[0].Image = (Image)MenuPadre["IconoMenu"];
                //Averiguando si tiene Hijos o no
                if (dtMenus.Select("IdObjetoPadre=" + MenuPadre["IdObjeto"]).Length == 1)
                {
                    //Sino tiene hijos lo agrego a la barra de menu principal
                    //mnu_Principal.Items.Add((String)MenuPadre["DescripcionMenu"], null, new EventHandler(MenuItemClicked));
                    Menu[0].Click += new EventHandler(MenuItemClicked);
                    menuStrip.Items.Add(Menu[0]);
                }
                else
                {
                    //Si tiene hijos llamo a la funcion recursiva y Agrego el Item sin Evento
                    //AgregarMenuHijo(mnu_Principal.Items.Add((String)MenuPadre["DescripcionMenu"]));
                    menuStrip.Items.Add(Menu[0]);
                    AgregarMenuHijo(Menu[0]);
                }
            }
        }
        #endregion

        #region Método AgregaMenuHijo
        private void AgregarMenuHijo(ToolStripItem MenuItemPadre)
        {
            ToolStripMenuItem MenuPadre = (ToolStripMenuItem)MenuItemPadre;

            //Obtengo el ID del menu Enviado para saber si tiene hijos o no
            //int Id = (int)(dtMenus.Select("DescripcionMenu='" +MenuPadre.Text+"'")[0]["Id_Menu"]);
            string Id = MenuPadre.Name;


            //Averiguando si tiene Hijos o no
            if (dtMenus.Select("IdObjetoPadre=" + Id).Length == 0)
            {
                //Si No tiene Hijos Solo Agrego el Evento
                MenuPadre.Click += new EventHandler(MenuItemClicked);
            }
            else
            {
                //Si Aun tiene Hijos
                foreach (DataRow Menu in dtMenus.Select("IdObjetoPadre=" + Id + " AND IdObjetoPadre<>idobjeto", "idObjeto ASC"))
                {
                    ToolStripItem[] NuevoMenu = new ToolStripItem[1];
                    NuevoMenu[0] = new ToolStripMenuItem();
                    NuevoMenu[0].Name = Menu["IdObjeto"].ToString();
                    NuevoMenu[0].Text = Menu["Descripcion"].ToString();
                    NuevoMenu[0].Tag = Menu["Url"].ToString();
                    //Averiguo se es un separador
                    if (Menu["Descripcion"].ToString() == "-")
                    {
                        //MenuPadre.DropDownItems.Add((String)Menu["DescripcionMenu"]);
                        MenuPadre.DropDownItems.Add(NuevoMenu[0].Text);
                    }
                    else
                    {
                        //Obtengo el ID del Menu del foreach
                        //int IdMenu = (int)dtMenus.Select("DescripcionMenu='" + Menu["DescripcionMenu"]+"'")[0]["Id_Menu"];
                        //int IdMenu = (int)Menu["Id_Menu"];
                        //Averiguando si tiene Hijos o no
                        if (dtMenus.Select("IdObjetoPadre=" + Menu["IdObjeto"]).Length == 0)
                        {
                            //Sino tiene hijos lo agrego al Menu Padre
                            //MenuPadre.DropDownItems.Add((String)Menu["DescripcionMenu"], null, new EventHandler(MenuItemClicked));
                            NuevoMenu[0].Click += new EventHandler(MenuItemClicked);
                            MenuPadre.DropDownItems.Add(NuevoMenu[0]);
                        }
                        else
                        {
                            //Si tiene hijos llamo a la funcion recursiva y Agrego el Item sin Evento
                            //AgregarMenuHijo(MenuPadre.DropDownItems.Add((String)Menu["DescripcionMenu"]));
                            MenuPadre.DropDownItems.Add(NuevoMenu[0]);
                            AgregarMenuHijo(NuevoMenu[0]);
                        }
                    }
                }
            }
        }
        #endregion

        #region Método MenuClicked
        private void MenuItemClicked(object sender, EventArgs e)
        {
            // if the sender is a ToolStripMenuItem
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                string NombreFormulario = ((ToolStripItem)sender).Tag.ToString();
                Object ObjFrm;
                //Type tipo = default(Type);
                Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
                if (NombreFormulario == "this.Close()")
                {
                    this.Close();
                }
                else
                {
                    if (tipo == null)   
                    {
                        MessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!this.FormularioEstaAbierto(NombreFormulario))
                        {
                            ObjFrm = Activator.CreateInstance(tipo);
                            Form Formulario = (Form)ObjFrm;
                            //Catalogos.Plantilla Formulario = (Catalogos.Plantilla)ObjFrm;
                            //Formulario.Id_Perfil = id_Perfil;
                            Formulario.MdiParent = this;
                            Formulario.WindowState = FormWindowState.Maximized;
                            Formulario.Show();
                        }
                    }
                }
            }
        }
        #endregion

        #region Método FormularioAbierto
        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (this.MdiChildren.Length > 0)
            {
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    //MessageBox.Show(NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")));
                    if (this.MdiChildren[i].Name == NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")))
                    {
                        MessageBox.Show("El formulario solicitado ya se encuentra abierto");
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }
        #endregion

        #region Click en Boton online
        private void onLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBar.Visible = false;
            misglobales.usuario_autenticacion = "online";
            ProgressBar.Increment(0);
            System.Threading.Thread.Sleep(1000);
            lblusuario.Text = misglobales.usuario_autenticacion + "  |   USER: " + misglobales.usuario_nombre + " " + misglobales.usuario_paterno + "  |   OFFICE: " + misglobales.oficina_oficina + "   |   ROL: " + misglobales.perfil_perfil + " |    SERVER: " + misglobales.servername + "               ";
            //Corre ETL que envía los datos al server
            ProgressBar.Visible = true;
            ProgressBar.Increment(99);
            //ProgressBar.Visible = false;
        }
        #endregion

        #region Click en Boton offline
        private void offLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBar.Visible = false;
            misglobales.usuario_autenticacion = "offline";
            ProgressBar.Increment(0);
            System.Threading.Thread.Sleep(1000);
            lblusuario.Text = misglobales.usuario_autenticacion + "  |   USER: " + misglobales.usuario_nombre + " " + misglobales.usuario_paterno + "  |   OFFICE: " + misglobales.oficina_oficina + "   |   ROL: " + misglobales.perfil_perfil + " |    SERVER: " + misglobales.servername + "               ";
            //Corre ETL que extrae del server la información
            ProgressBar.Visible = true;
            ProgressBar.Increment(80);
            //ProgressBar.Visible = false;
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Object ObjFrm;
            Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + "Operacion.Frm_SistemaControl");
            ObjFrm = Activator.CreateInstance(tipo);
            Form Formulario = (Form)ObjFrm;
            Formulario.MdiParent = MDISkyDiveCuautla.ActiveForm;
            Formulario.WindowState = FormWindowState.Maximized;
            Formulario.Show();

        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {

        }

        private void cmb_printer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_printer.Text == "Bixolon SLP-T400")
            {
                misglobales._impresora = "bixolont400";

            }
            if (cmb_printer.Text == "Bixolon SRP-350Plus")
            {
                misglobales._impresora = "bixolonsrp350plus";

            }
            if (cmb_printer.Text == "Okipos 407")
            {
                misglobales._impresora = "okipos";

            }
        }

        private void cmb_printer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_printer.Text == "Bixolon SLP-T400")
            {
                misglobales._impresora = "bixolont400";

            }
            if (cmb_printer.Text == "Bixolon SRP-350Plus")
            {
                misglobales._impresora = "bixolonsrp350plus";

            }
            if (cmb_printer.Text == "Okipos 407")
            {
                misglobales._impresora = "okipos";

            }
        }

    }
}
