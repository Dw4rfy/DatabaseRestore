using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;

namespace DatabaseRestore
{
    public partial class Main : Form
    {
        string backupFilePath = string.Empty;
        string backupFileName = string.Empty;
        string instanceName = string.Empty;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var scServices = ServiceController.GetServices();

            foreach (ServiceController service in scServices)
            {
                if (service.DisplayName.Contains("SQL Server ("))
                {
                    string tmpString = service.DisplayName;
                    string formattedString = tmpString.Remove(0, 12);
                    string iName = service.MachineName + "\\" + formattedString.Replace(")", "");

                    cbInstanceNames.Items.Add(iName);

                    if (cbInstanceNames.Items.Count != 0)
                        cbInstanceNames.SelectedIndex = 0;
                }
            }
            instanceName = cbInstanceNames.SelectedItem.ToString();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            ofdFindBackup.InitialDirectory = "C:\\";
            ofdFindBackup.Filter = "Backup Files (*.bak)|*.bak";

            if (ofdFindBackup.ShowDialog() == DialogResult.OK)
            {
                backupFilePath = Path.GetFullPath(ofdFindBackup.FileName);
                backupFileName = Path.GetFileNameWithoutExtension(ofdFindBackup.FileName);
                tbBackupFile.Text = backupFilePath;
            }
        }

        private void btnImporter_Click(object sender, EventArgs e)
        {
            btnImporter.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            if (tbBackupFile.Text.Length < 1 || tbRestoreAs.Text.Length < 1)
            {
                MessageBox.Show("Fyll ut database navn og velg backup fil");
                ResetToStart();
                return;
            }

            try
            {
                string restoreAs = tbRestoreAs.Text;
                instanceName = cbInstanceNames.SelectedItem.ToString();

                using (var con = CreateSqlConnection(instanceName, null))
                {
                    var logicNames = SqlHelper.FindLogicNames(con, backupFilePath);

                    if (SqlHelper.DBDoesExist(con, tbRestoreAs.Text))
                    {
                        ShowErrorMessage("Dette database navnet er allerede i bruk.");
                        return;
                    }

                    string dataFolderPath = SqlHelper.FindDataFolderPath(con);

                    var sql = $@"RESTORE DATABASE [{restoreAs}] FROM  DISK = N'{backupFilePath}' WITH  FILE = 1,  MOVE N'{logicNames[SqlHelper.LogicNameTypes.MainLogicName]}' TO N'{dataFolderPath}{tbRestoreAs.Text}.mdf',  MOVE N'{logicNames[SqlHelper.LogicNameTypes.LogLogicName]}' TO N'{dataFolderPath}{tbRestoreAs.Text}_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5";
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("It is being used by"))
                {
                    ShowErrorMessage("Data filer med det samme navnet er allerede i bruk av en annen database. \n\n Er databasen allerede importert?");
                    return;
                }
                else if (sqlEx.Message.Contains("Ingen tilgang"))
                {
                    ShowErrorMessage("Programmet klarer ikke å nå filen, legg database filen på C:\\");
                    return;
                }
                else if (sqlEx.Message.Contains("running version 13.00.4001"))
                {
                    ShowErrorMessage("Det ser ut som denne bak filen er laget på SQL versjon 2016, oppgrader til siste versjon av SQL express.");
                    return;
                }
                else
                {
                    ShowErrorMessage(sqlEx.Message + Environment.NewLine + Environment.NewLine + sqlEx.StackTrace);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace);
                return;
            }
            MessageBox.Show("Database importert", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetToStart();
        }

        private void btnCheckLoginMode_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginMode = null;
                using (var con = CreateSqlConnection(instanceName, null))
                {
                    LoginMode = SqlHelper.CheckSqlLoginMode(con);
                }
                if (LoginMode == "Mixed")
                    MessageBox.Show("SA er aktivert, du kan fint logge på med denne", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("SA er ikke aktivert, trykk på Enable SA knappen.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                {
                    ShowErrorMessage(sqlEx.Message + Environment.NewLine + Environment.NewLine + sqlEx.StackTrace);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace);
                return;
            }
        }

        private void btnMixedMode_Click(object sender, EventArgs e)
        {
            if (!new SQLLoginModeHelper().ChangeLoginMode(2))
            {
                ShowErrorMessage("Start programmet som administrator.");
                return;
            }     
            RestartServices();
        }

        private void btnEnableSA_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = CreateSqlConnection(instanceName, null))
                {
                    var sql = $@"ALTER LOGIN sa ENABLE";
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            catch (SqlException sqlEx)
            {
                {
                    ShowErrorMessage(sqlEx.Message + Environment.NewLine + Environment.NewLine + sqlEx.StackTrace);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace);
                return;
            }
        }

        private void btnSaPassord_Click(object sender, EventArgs e)
        {
            string password = "Velkommen1";
            var result = DialogResult.Cancel;

            using (var form = new prompt())
            {
                result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    password = form.ReturnValue;
                    MessageBox.Show("Passord satt");
                }
                else if (result == DialogResult.Abort)
                {
                    MessageBox.Show("Passord er satt til: Velkommen1");
                }
            }

            if (result != DialogResult.Cancel)
            {
                try
                {
                    using (var con = CreateSqlConnection(instanceName, null))
                    {
                        var sql = $"sp_password @new = \"{password}\", @loginame = \"sa\"";
                        using (var cmd = con.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            cmd.CommandTimeout = 0;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    {
                        ShowErrorMessage(sqlEx.Message + Environment.NewLine + Environment.NewLine + sqlEx.StackTrace);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace);
                    return;
                }
            }
        }

        public static SqlConnection CreateSqlConnection(string server, string database)
        {
            var destCSB = new SqlConnectionStringBuilder();
            destCSB.DataSource = server;
            if (!string.IsNullOrEmpty(database))
                destCSB.InitialCatalog = database;
            destCSB.IntegratedSecurity = true;

            var destCN = new SqlConnection(destCSB.ConnectionString);
            destCN.Open();
            return destCN;
        }

        public void ResetToStart()
        {
            Cursor.Current = Cursors.Default;
            btnImporter.Enabled = true;
        }

        public void ShowErrorMessage(string mld)
        {
            MessageBox.Show(mld, "En feil har oppstått", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResetToStart();
        }

        public void RestartServices()
        {
            var scServices = ServiceController.GetServices();

            foreach (ServiceController service in scServices)
            {
                if (service.ServiceName.Contains("MSSQL$"))
                {
                    MessageBox.Show(string.Format("Restarter Service: {0}.", service.DisplayName), "Restarter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    MessageBox.Show(string.Format("{0} er restartet.", service.DisplayName), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

