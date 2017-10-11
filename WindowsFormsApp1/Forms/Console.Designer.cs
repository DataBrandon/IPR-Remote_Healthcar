namespace Remote_Healtcare_Console
{
    partial class Console
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.BStart = new System.Windows.Forms.Button();
            this.comPorts = new System.Windows.Forms.ComboBox();
            this.Status = new System.Windows.Forms.Label();
            this.FaseLabel = new System.Windows.Forms.Label();
            this.Timerlabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BStart
            // 
            this.BStart.BackColor = System.Drawing.Color.DarkGray;
            this.BStart.Location = new System.Drawing.Point(26, 12);
            this.BStart.Name = "BStart";
            this.BStart.Size = new System.Drawing.Size(75, 23);
            this.BStart.TabIndex = 0;
            this.BStart.Text = "Start";
            this.BStart.UseVisualStyleBackColor = false;
            this.BStart.Click += new System.EventHandler(this.BStart_Click);
            // 
            // comPorts
            // 
            this.comPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPorts.FormattingEnabled = true;
            this.comPorts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comPorts.Items.AddRange(new object[] {
            "Simulation",
            "COM1",
            "COM2",
            "COM3"});
            this.comPorts.Location = new System.Drawing.Point(119, 12);
            this.comPorts.Name = "comPorts";
            this.comPorts.Size = new System.Drawing.Size(75, 21);
            this.comPorts.TabIndex = 26;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Modern No. 20", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(401, 174);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(74, 29);
            this.Status.TabIndex = 27;
            this.Status.Text = "Fase:";
            // 
            // FaseLabel
            // 
            this.FaseLabel.AutoSize = true;
            this.FaseLabel.Font = new System.Drawing.Font("Modern No. 20", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaseLabel.Location = new System.Drawing.Point(525, 174);
            this.FaseLabel.Name = "FaseLabel";
            this.FaseLabel.Size = new System.Drawing.Size(197, 34);
            this.FaseLabel.TabIndex = 28;
            this.FaseLabel.Text = "Warming Up";
            // 
            // Timerlabel
            // 
            this.Timerlabel.AutoSize = true;
            this.Timerlabel.Font = new System.Drawing.Font("Modern No. 20", 102F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timerlabel.Location = new System.Drawing.Point(445, 267);
            this.Timerlabel.Name = "Timerlabel";
            this.Timerlabel.Size = new System.Drawing.Size(185, 139);
            this.Timerlabel.TabIndex = 29;
            this.Timerlabel.Text = "87";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 435);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1101, 603);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Timerlabel);
            this.Controls.Add(this.FaseLabel);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.comPorts);
            this.Controls.Add(this.BStart);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Console";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BStart;
        private System.Windows.Forms.ComboBox comPorts;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label FaseLabel;
        private System.Windows.Forms.Label Timerlabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

