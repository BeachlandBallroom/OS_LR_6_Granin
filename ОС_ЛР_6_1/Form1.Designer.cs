namespace ОС_ЛР_6_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartClients;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.NumericUpDown numClients;
        private System.Windows.Forms.TextBox txtLifetimes;
        private System.Windows.Forms.ListBox listBoxStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStartClients = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.numClients = new System.Windows.Forms.NumericUpDown();
            this.txtLifetimes = new System.Windows.Forms.TextBox();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numClients)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartClients
            // 
            this.btnStartClients.Location = new System.Drawing.Point(297, 64);
            this.btnStartClients.Name = "btnStartClients";
            this.btnStartClients.Size = new System.Drawing.Size(75, 23);
            this.btnStartClients.TabIndex = 0;
            this.btnStartClients.Text = "Start Clients";
            this.btnStartClients.UseVisualStyleBackColor = true;
            this.btnStartClients.Click += new System.EventHandler(this.btnStartClients_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Location = new System.Drawing.Point(297, 93);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(75, 23);
            this.btnViewLogs.TabIndex = 1;
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // numClients
            // 
            this.numClients.Location = new System.Drawing.Point(12, 12);
            this.numClients.Name = "numClients";
            this.numClients.Size = new System.Drawing.Size(120, 20);
            this.numClients.TabIndex = 2;
            // 
            // txtLifetimes
            // 
            this.txtLifetimes.Location = new System.Drawing.Point(12, 38);
            this.txtLifetimes.Name = "txtLifetimes";
            this.txtLifetimes.Size = new System.Drawing.Size(360, 20);
            this.txtLifetimes.TabIndex = 3;
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.Location = new System.Drawing.Point(12, 122);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(360, 147);
            this.listBoxStatus.TabIndex = 4;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.listBoxStatus);
            this.Controls.Add(this.txtLifetimes);
            this.Controls.Add(this.numClients);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.btnStartClients);
            this.Name = "MainForm";
            this.Text = "Server Process";
            ((System.ComponentModel.ISupportInitialize)(this.numClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
