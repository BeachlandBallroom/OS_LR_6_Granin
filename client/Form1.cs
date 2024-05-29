using SharedLibrary;
using System;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private int lifetime; // Lifetime in seconds
        private Timer timer;

        public Form1(int lifetime)
        {
            InitializeComponent();
            this.lifetime = lifetime;

            if (lifetime == -1)
            {
                lblTimeRemaining.Text = "Running indefinitely.";
                Logger.Log("Client running indefinitely.");
            }
            else
            {
                lblTimeRemaining.Text = $"Time remaining: {lifetime} seconds";
                Logger.Log($"Client running for {lifetime} seconds.");
                timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (lifetime > 0)
            {
                lifetime--;
                lblTimeRemaining.Text = $"Time remaining: {lifetime} seconds";
                Logger.Log($"Time remaining: {lifetime} seconds");
            }
            else
            {
                timer.Stop();
                Logger.Log("Client shutting down.");
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Logger.Log("Client manually closed.");
            this.Close();
        }
    }
}
