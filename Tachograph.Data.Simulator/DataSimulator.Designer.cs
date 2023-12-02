namespace TachographDataSimulator
{
    partial class DataSimulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStartSimulation = new Button();
            btnStopSimulation = new Button();
            SuspendLayout();
            // 
            // btnStartSimulation
            // 
            btnStartSimulation.Location = new Point(37, 64);
            btnStartSimulation.Name = "btnStartSimulation";
            btnStartSimulation.Size = new Size(251, 114);
            btnStartSimulation.TabIndex = 0;
            btnStartSimulation.Text = "Start Simulation";
            btnStartSimulation.UseVisualStyleBackColor = true;
            btnStartSimulation.Click += btnStartSimulation_Click;
            // 
            // btnStopSimulation
            // 
            btnStopSimulation.Location = new Point(37, 266);
            btnStopSimulation.Name = "btnStopSimulation";
            btnStopSimulation.Size = new Size(251, 114);
            btnStopSimulation.TabIndex = 1;
            btnStopSimulation.Text = "Stop Simulation";
            btnStopSimulation.UseVisualStyleBackColor = true;
            btnStopSimulation.Click += btnStopSimulation_Click;
            // 
            // DataSimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 450);
            Controls.Add(btnStopSimulation);
            Controls.Add(btnStartSimulation);
            Name = "DataSimulator";
            Text = "Data Simulator";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartSimulation;
        private Button btnStopSimulation;
    }
}