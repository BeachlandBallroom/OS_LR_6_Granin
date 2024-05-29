using SharedLibrary;
using System;
using System.Windows.Forms;

namespace client
{
    static class CLientProgram
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1 || !int.TryParse(args[0], out int lifetime))
                {
                    MessageBox.Show("Invalid arguments.");
                    Logger.Log("Invalid arguments.");
                    return;
                }

                Logger.Log($"Client started with lifetime: {lifetime} seconds");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(lifetime));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Logger.Log($"Error: {ex.Message}");
            }
        }
    }
}
