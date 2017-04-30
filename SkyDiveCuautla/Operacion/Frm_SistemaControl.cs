using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SkyDiveCuautla.Operacion
{
    public partial class Frm_SistemaControl : Form
    {
        String CadenaConexion = misglobales.cadenaconexionSQLmaster;
        ConectaBD conexion = new ConectaBD();     
        String condicion;
        utilerias u = new utilerias();
        SqlCommand cmd;
        SqlConnection cnn;
        String Script;
        Thread t ;

        public Frm_SistemaControl()
        {

            InitializeComponent();
        }

        #region Evento click del btn_browse
        private void btn_browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Add File";
            openFileDialog.Filter = "Reservation Files (*.bak)|*.bak";
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

        #region Consulta ConsultaRespaldos
        public DataTable ConsultaRespaldos()
        {
            cmd = new SqlCommand();
            cnn = new SqlConnection(CadenaConexion);

            DataTable dt = new DataTable();
            String sql = @"
                            select bs.backup_set_id, bs.database_name, bs.server_name,  bs.name, bs.backup_start_date, bs.backup_finish_date,  bs.backup_size, bf.file_size,  bf.logical_name, bmf.physical_device_name
                              from msdb.dbo.backupset bs 
                             inner join msdb.dbo.backupfile bf on bf.backup_set_id = bs.backup_set_id and bf.file_type = 'D' and bf.logical_name like 'bd_skydivecuautla%'
                             inner join msdb.dbo.backupmediafamily bmf on bmf.media_set_id = bs.media_set_id
                             order by   bs.backup_start_date desc ";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        #endregion


        #region Inicializa Grid
        private void InicializaGrid()
        {


            dg_backups.EnableHeadersVisualStyles = false;
            dg_backups.DataSource = ConsultaRespaldos();  //getdata(fuente;
            dg_backups.Columns[0].Width = 10; // backup_set_id
            dg_backups.Columns[0].Visible = false;
            dg_backups.Columns[1].Width = 150; // database_name
            dg_backups.Columns[1].Visible = true;
            dg_backups.Columns[2].Width = 100; // server_name
            dg_backups.Columns[2].Visible = true;
            dg_backups.Columns[3].Width = 400; // name
            dg_backups.Columns[3].Visible = true;
            dg_backups.Columns[4].Width = 150; // backup_start_date
            dg_backups.Columns[4].Visible = true;
            dg_backups.Columns[5].Width = 150; // backup_finish_date
            dg_backups.Columns[5].Visible = true;
            dg_backups.Columns[6].Width = 150; // backup_size
            dg_backups.Columns[6].Visible = true;
            dg_backups.Columns[7].Width = 150; // file_size
            dg_backups.Columns[7].Visible = false;
            dg_backups.Columns[8].Width = 150; // logical_name
            dg_backups.Columns[8].Visible = false;
            dg_backups.Columns[9].Width = 400; // physical_device_name
            dg_backups.Columns[9].Visible = true;

            dg_backups.Columns[0].HeaderText = "backup_set_id";
            dg_backups.Columns[1].HeaderText = "database_name";
            dg_backups.Columns[2].HeaderText = "server_name";
            dg_backups.Columns[3].HeaderText = "name";
            dg_backups.Columns[4].HeaderText = "backup_start_date";
            dg_backups.Columns[5].HeaderText = "backup_finish_date";
            dg_backups.Columns[6].HeaderText = "backup_size";
            dg_backups.Columns[7].HeaderText = "file_size";
            dg_backups.Columns[8].HeaderText = "logical_name";
            dg_backups.Columns[9].HeaderText = "physical_device_name";

            u.Formatodgv(dg_backups);
            txb_server.Text = misglobales.servername;
        }
        #endregion

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


        private void Frm_SistemaControl_Load(object sender, EventArgs e)
        {
            DataSet dsoffice = conexion.ConsultaOficina("");
            cmb_office.DataSource = dsoffice.Tables[0].DefaultView;
            cmb_office.AutoCompleteCustomSource = LoadAutoComplete(dsoffice, "OFICINA");
            //cmb_office.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb_office.DisplayMember = "OFICINA";
            cmb_office.ValueMember = "ID";
            cmb_office.SelectedValue = misglobales.dropzone; // misglobales.oficina_id_oficina;
            txb_pathfile.Text = "";
            InicializaGrid();
            pb_sync.Image = Properties.Resources.ajax_loader;
        }

        #region Ejecuta script
        public void ExecScript(string script)
        {
            SqlConnection SQLConn = new SqlConnection(misglobales.cadenaconexionSQLmaster);
            SqlCommand cmd = new SqlCommand();
            Int32 RowsAffected;

            cmd.CommandText = @" " + script;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = SQLConn;

            SQLConn.Open();

            RowsAffected = cmd.ExecuteNonQuery();
            SQLConn.Close();
        }
        #endregion 


        public void procesosecundario()
        {
          //subproceso
            ExecScript(Script);
            MessageBox.Show("Process successfully");
            t.Abort();            
        }



        #region Evento click del btn_backup
        private void btn_backup_Click(object sender, EventArgs e)
        {
             t = new Thread(procesosecundario);

            pb_backup.Visible = true;
            lbl_backup.Visible = true;
            lbl_backup2.Visible = true;
            pb_backup.Image = Properties.Resources.ajax_loader;
            pb_backup.Refresh();
            

            String fecharespaldo;
            DateTime now = DateTime.Now;
            String format = "yyyyMMdd";
            fecharespaldo = now.ToString(format);

            try
            {

                Script = @" use  bd_skydivecuautla

                        ALTER DATABASE bd_skydivecuautla
                        SET RECOVERY SIMPLE
                                
                        DBCC SHRINKFILE (bd_skydivecuautla_log, 1)
                                
                        ALTER DATABASE bd_skydivecuautla
                        SET RECOVERY FULL
                                
                        BACKUP DATABASE bd_skydivecuautla
                        TO DISK = 'C:\SkyDiveCuautla\SyncDB\Dropzone_" + misglobales.oficina_oficina + "_" + fecharespaldo + @".Bak'
                            WITH FORMAT,
                                MEDIANAME = 'C_SQLServerBackups',
                                NAME = 'Full Backup of bd_skydivecuautla Dropzone " + misglobales.oficina_oficina + "_" + fecharespaldo + @"' ";
                

                    t.Start();

                    while (t.ThreadState.ToString()=="Running")
                    {
                        lbl_state.Text = t.ThreadState.ToString();
                        lbl_state.Refresh();
                        lbl_backup.Refresh();
                        lbl_backup2.Refresh();
                        pb_backup.Refresh();
                    }
                    

                    InicializaGrid();
                    pb_backup.Visible = false;
                    lbl_backup.Visible = false;
                    lbl_backup2.Visible = false;
                    lbl_state.Visible = false;
                    
                    

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try backup database, contact system administrator " + ex.Message);

            }


            try
            {
                Script = @" 
                          use master 
                          ALTER DATABASE bd_skydivecuautla_sync SET SINGLE_USER WITH ROLLBACK IMMEDIATE  ";
                ExecScript(Script);


                Script = @" 
                            RESTORE DATABASE bd_skydivecuautla_sync
                            FROM DISK = 'C:\SkyDiveCuautla\SyncDB\Dropzone_" + misglobales.oficina_oficina + "_" + fecharespaldo + @".Bak' with replace, move 'bd_skydivecuautla' to 'C:\SkyDiveCuautla\BaseDatos\bd_skydivecuautla_sync.mdf', move 'bd_skydivecuautla_log' to 'C:\SkyDiveCuautla\BaseDatos\bd_skydivecuautla_sync.ldf' ";
                ExecScript(Script);


                //poner la base de datos en multiuser
                Script = @" 
                          use master 
                          ALTER DATABASE bd_skydivecuautla_sync SET MULTI_USER  ";

                ExecScript(Script);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error try backup database sync, contact system administrator " + ex.Message);

            }





            pb_backup.Visible = false;
            lbl_backup.Visible = false;
            lbl_backup2.Visible = false;
            lbl_state.Visible = false;

        }
        #endregion

        #region Evento click del btn_updload
        private void btn_upload_Click(object sender, EventArgs e)
        {
            btn_upload.Enabled = false;
            //t = new Thread(procesosecundario);

            pb_sync.Visible = true;
            lbl_mensaje2.Visible = true;
            lbl_mensaje1.Visible = true;

            if (txb_pathfile.Text != "")
            {
                try
                {
                    //poner la base de datos en singleuser
                    
                    DialogResult resultado = MessageBox.Show("are you sure restore DataBase ?", "Warning", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {
                 

                         Script = @" 
                          use master 
                          ALTER DATABASE bd_skydivecuautla SET SINGLE_USER WITH ROLLBACK IMMEDIATE  ";
                         ExecScript(Script);     
                    //t.Start();

                         //while (t.ThreadState.ToString() == "Running")
                         //{

                         //    lbl_mensaje1.Refresh();
                         //    lbl_mensaje2.Refresh();
                         //    pb_sync.Refresh();
                         //}
                        //realizar el restore


                        Script = @" 
                            RESTORE DATABASE bd_skydivecuautla
                            FROM DISK = '" + txb_pathfile.Text + "' with replace";
                        ExecScript(Script);
                        //t.Start();

                        //while (t.ThreadState.ToString() == "Running")
                        //{

                        //    lbl_mensaje1.Refresh();
                        //    lbl_mensaje2.Refresh();
                        //    pb_sync.Refresh();
                        //}

                        //poner la base de datos en multiuser
                        Script = @" 
                          use master 
                          ALTER DATABASE bd_skydivecuautla SET MULTI_USER  ";
                        //t.Start();
                        ExecScript(Script);

                        //while (t.ThreadState.ToString() == "Running")
                        //{

                        //    lbl_mensaje1.Refresh();
                        //    lbl_mensaje2.Refresh();
                        //    pb_sync.Refresh();
                        //}


                        //eliminar usuario de la BD y crearlo de nuevo
                        Script = @" 
                          use bd_skydivecuautla 

                          EXEC sp_dropuser 'sdcuser'
                          
                          CREATE USER [sdcuser] FOR LOGIN [sdcuser]

                          ALTER USER [sdcuser] WITH DEFAULT_SCHEMA=[dbo]

                          EXEC sp_addrolemember N'db_datareader', N'sdcuser'

                          EXEC sp_addrolemember N'db_datawriter', N'sdcuser'

                          EXEC sp_addrolemember N'db_owner', N'sdcuser'

                          GRANT SELECT, INSERT, DELETE, DELETE ON dbo.TB_TANDEMUP_RESERVA TO sdcuser

                          ";
                        ExecScript(Script);    
                    //t.Start();

                        //while (t.ThreadState.ToString() == "Running")
                        //{

                        //    lbl_mensaje1.Refresh();
                        //    lbl_mensaje2.Refresh();
                        //    pb_sync.Refresh();
                        //}

                        // respetar catalogos

                        Script = @" 
                          use bd_skydivecuautla 

                            UPDATE CTJ
                            SET CTJ.PRICE = CTJS.PRICE
                            FROM [bd_skydivecuautla].DBO.CT_JUMP_TYPE CTJ
                            INNER JOIN [bd_skydivecuautla_SYNC].DBO.CT_JUMP_TYPE CTJS
                            ON CTJ.idjumptype = CTJS.idjumptype
                          ";
                        ExecScript(Script);

                        Script = @" 
                          use bd_skydivecuautla 

                            UPDATE CTJE
                            SET CTJE.charge = CTJES.charge
                            FROM [bd_skydivecuautla].DBO.CT_JUMPER_EXCEPTIONS CTJE
                            INNER JOIN [bd_skydivecuautla_SYNC].DBO.CT_JUMPER_EXCEPTIONS CTJES
                            ON CTJE.idjumper = CTJES.idjumper
                            and CTJE.idjumptype = CTJES.idjumptype
                          ";
                        ExecScript(Script);

                        Script = @" 
                          use bd_skydivecuautla 

	                        UPDATE CTU
		                           SET CTU.[contraseña] = CTU_S.[contraseña], 
			                           CTU.nombre = CTU_S.nombre, 
			                           CTU.paterno = CTU_S.paterno, 
			                           CTU.materno = CTU_S.materno, 
			                           CTU.email = CTU_S.email, 
			                           CTU.idperfil = CTU_S.idperfil, 
			                           CTU.idoficina = CTU_S.idoficina, 
			                           CTU.fecha_creacion = CTU_S.fecha_creacion, 
			                           CTU.idusuariocreador = CTU_S.idusuariocreador, 
			                           CTU.idestatus = CTU_S.idestatus, 
			                           CTU.autenticacion = CTU_S.autenticacion
		                          FROM bd_skydivecuautla.dbo.CT_USUARIO CTU
		                         INNER JOIN bd_skydivecuautla_sync.dbo.CT_USUARIO CTU_S
			                        ON CTU.usuario = CTU_S.usuario

                          ";
                        ExecScript(Script);




                        MessageBox.Show("Restore database successfully, may begin operations in " + misglobales.oficina_oficina + " dropzone");
                        //Application.Restart();
                        pb_sync.Visible = false;
                        lbl_mensaje2.Visible = false;
                        lbl_mensaje1.Visible = false;
                        txb_pathfile.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try upload database, contact system administrator" + ex.Message);
          
                }
            }
            else
            {
                MessageBox.Show("Please select file .bck  and try again");

            }
            pb_sync.Visible = false;
            lbl_mensaje2.Visible = false;
            lbl_mensaje1.Visible = false;
            btn_upload.Enabled = true;
        }
        #endregion 

        #region Evento click del btn_sincronize
        private void btn_sincronize_Click(object sender, EventArgs e)
        {
            btn_sincronize.Enabled = false;
            //t = new Thread(procesosecundario);

            String fecharespaldo;
            DateTime now = DateTime.Now;
            String format = "yyyyMMdd";
            fecharespaldo = now.ToString(format);

            pb_sync.Visible = true;
            lbl_mensaje2.Visible = true;
            lbl_mensaje1.Visible = true;
            pb_sync.Image = Properties.Resources.ajax_loader;


             if (txb_pathfile.Text != "")
            {
                try
                {
                    DialogResult resultado = MessageBox.Show("are you sure Synchronice DataBases for "  + cmb_office.SelectedValue.ToString(), "Warning", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {

                    //Restaura la base de datos a sincronizar
                    Script = @" 
                            RESTORE DATABASE bd_skydivecuautla_sync
                            FROM DISK = '" + txb_pathfile.Text + "' with replace ";
                    lbl_mensaje2.Text = "Loading Zone data";
                    ExecScript(Script);
                    //t.Start();

                    //while (t.ThreadState.ToString() == "Running")
                    //{

                    //    lbl_mensaje1.Refresh();
                    //    lbl_mensaje2.Refresh();
                    //    pb_sync.Refresh();
                    //}

                        //Ejecuta el proceso de sincronización
                    //Script = @" EXEC bd_skydivecuautla.dbo.sp_sync  " + cmb_office.SelectedValue;
                    Script = @" EXEC bd_skydivecuautla.dbo.sp_sync  ";
                        ExecScript(Script);    
                    //t.Start();

                        //while (t.ThreadState.ToString() == "Running")
                        //{

                        //    lbl_mensaje1.Refresh();
                        //    lbl_mensaje2.Refresh();
                        //    pb_sync.Refresh();
                        //}

                        //Ejecuta el proceso de preparación (return) de la BD de la zona
//Script = @" EXEC bd_skydivecuautla.dbo.sp_return_dropzone ";
//ExecScript(Script);    
                    //t.Start();

                        //while (t.ThreadState.ToString() == "Running")
                        //{

                        //    lbl_mensaje1.Refresh();
                        //    lbl_mensaje2.Refresh();
                        //    pb_sync.Refresh();
                        //}

                        //Realiza Backup de la BD de la zona para regresarla
//Script = @"                          
//BACKUP DATABASE bd_skydivecuautla_sync
//TO DISK = 'C:\SkyDiveCuautla\SyncDB\Dropzone_Prepared_" + fecharespaldo + "_" + txb_pathfile.Text.Substring(txb_pathfile.Text.Length - 11, 7) + @".Bak'
//WITH FORMAT,
//MEDIANAME = 'C_SQLServerBackups',
//NAME = 'Full Backup of bd_skydivecuautla Dropzone " + txb_pathfile.Text.Substring(txb_pathfile.Text.Length - 11, 7) + @"' ";
//ExecScript(Script);    
                    //t.Start();

                    //    while (t.ThreadState.ToString() == "Running")
                    //    {

                    //        lbl_mensaje1.Refresh();
                    //        lbl_mensaje2.Refresh();
                    //        pb_sync.Refresh();
                    //    }
                        InicializaGrid();
                        pb_sync.Visible = false;
                        lbl_mensaje2.Visible = false;
                        lbl_mensaje1.Visible = false;

                        //MessageBox.Show("Syncronization successfully!!!   Send the DataBase Dropzone_Prepared_" + fecharespaldo + "_" + txb_pathfile.Text.Substring(txb_pathfile.Text.Length - 11, 7));
                        MessageBox.Show("Syncronization successfully!!! ");
                        txb_pathfile.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error try sync database, contact system administrator " + ex.Message);
               
                }

            }
             else
             {
                 MessageBox.Show("Please select file .bck  and try again");
               
             }
             pb_sync.Visible = false;
             btn_sincronize.Enabled = true;
             lbl_mensaje2.Visible = false;
             lbl_mensaje1.Visible = false;

        }
        #endregion


        private void btn_download_Click(object sender, EventArgs e)
        {
            btn_download.Enabled = false;
            String fecharespaldo;
            DateTime now = DateTime.Now;
            String format = "yyyyMMdd";
            fecharespaldo = now.ToString(format);

            pb_sync.Visible = true;
            lbl_mensaje2.Visible = true;
            lbl_mensaje1.Visible = true;
            pb_sync.Image = Properties.Resources.ajax_loader;


            //Ejecuta el proceso de preparación (return) de la BD de la zona
            Script = @" EXEC bd_skydivecuautla.dbo.sp_return_dropzone " + cmb_office.SelectedValue;
            ExecScript(Script); 

            //Realiza Backup de la BD de la zona para regresarla
            Script = @"                          
            BACKUP DATABASE bd_skydivecuautla_sync
            TO DISK = 'C:\SkyDiveCuautla\SyncDB\Dropzone_Prepared_" + fecharespaldo + "_" + cmb_office.Text.ToString() + @".Bak'
            WITH FORMAT,
            MEDIANAME = 'C_SQLServerBackups',
            NAME = 'Full Backup of bd_skydivecuautla Dropzone " + cmb_office.Text.ToString() + @"' ";
            ExecScript(Script);

            InicializaGrid();
            pb_sync.Visible = false;
            lbl_mensaje2.Visible = false;
            lbl_mensaje1.Visible = false;

            //MessageBox.Show("Syncronization successfully!!!   Send the DataBase Dropzone_Prepared_" + fecharespaldo + "_" + txb_pathfile.Text.Substring(txb_pathfile.Text.Length - 11, 7));
            MessageBox.Show("Download DataBase " + cmb_office.Text.ToString() + " successfully!!! ");
            btn_download.Enabled = true;


        }

        private void cmb_office_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  


    }
}
