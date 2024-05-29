using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;  // Add this line

namespace ОС_ЛР_6_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStartClients_Click(object sender, EventArgs e)
        {
            try
            {
                int clientCount = (int)numClients.Value;
                string[] lifetimes = txtLifetimes.Text.Split(',');

                if (lifetimes.Length != clientCount)
                {
                    MessageBox.Show("Please enter lifetimes for all clients.");
                    return;
                }

                for (int i = 0; i < clientCount; i++)
                {
                    int lifetime;
                    if (lifetimes[i].Trim().ToLower() == "infinite")
                    {
                        lifetime = -1;
                    }
                    else if (!int.TryParse(lifetimes[i], out lifetime) || lifetime < 0)
                    {
                        MessageBox.Show($"Invalid lifetime for client {i + 1}.");
                        return;
                    }

                    StartClientProcess(i + 1, lifetime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Logger.Log($"An error occurred: {ex.Message}");
            }
        }

        private async void StartClientProcess(int clientId, int lifetime)
        {
            try
            {
                string clientProcessPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\megag\\source\\repos\\ОС_ЛР_6_1\\client\\obj\\Debug\\client.exe");

                if (!File.Exists(clientProcessPath))
                {
                    MessageBox.Show($"ClientProcess.exe not found at {clientProcessPath}");
                    Logger.Log($"ClientProcess.exe not found at {clientProcessPath}");
                    return;
                }

                string arguments = lifetime.ToString();
                ProcessStartInfo psi = new ProcessStartInfo(clientProcessPath)
                {
                    Arguments = arguments,
                    UseShellExecute = false
                };

                Logger.Log($"Starting Client {clientId} with arguments: {arguments}");
                Process clientProcess = new Process { StartInfo = psi };
                clientProcess.Start();

                listBoxStatus.Items.Add($"Client {clientId} started with lifetime {lifetime} seconds.");
                Logger.Log($"Client {clientId} started with lifetime {lifetime} seconds.");

                if (lifetime != -1)
                {
                    await Task.Delay(lifetime * 1000);
                    if (!clientProcess.HasExited)
                    {
                        clientProcess.Kill();
                        listBoxStatus.Items.Add($"Client {clientId} terminated after {lifetime} seconds.");
                        Logger.Log($"Client {clientId} terminated after {lifetime} seconds.");
                    }
                }
            }
            catch (Exception ex)
            {
                listBoxStatus.Items.Add($"Error with client {clientId}: {ex.Message}");
                Logger.Log($"Error with client {clientId}: {ex.Message}");
            }
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            try
            {
                string[] logFiles = Logger.GetLogFiles();
                if (logFiles.Length == 0)
                {
                    MessageBox.Show("No log files found.");
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                    openFileDialog.Filter = "Log files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string logContent = Logger.ReadLogFile(openFileDialog.FileName);
                        MessageBox.Show(logContent, "Log Content");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while viewing logs: {ex.Message}");
                Logger.Log($"An error occurred while viewing logs: {ex.Message}");
            }
        }
    }
}
