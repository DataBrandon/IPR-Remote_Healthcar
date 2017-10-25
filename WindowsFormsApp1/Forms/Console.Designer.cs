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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BStart = new System.Windows.Forms.Button();
            this.comPorts = new System.Windows.Forms.ComboBox();
            this.Status = new System.Windows.Forms.Label();
            this.FaseLabel = new System.Windows.Forms.Label();
            this.Timerlabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.RPM_Indication_Picture = new System.Windows.Forms.PictureBox();
            this.Rpm_Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Pulse_Lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Old_Pulse_Lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Resistance_Lbl = new System.Windows.Forms.Label();
            this.Steady_State = new System.Windows.Forms.Label();
            this.VO2max_Lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Secure_Lbl = new System.Windows.Forms.Label();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NewResistence_Lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RPM_Indication_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
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
            this.Status.Location = new System.Drawing.Point(411, 61);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(74, 29);
            this.Status.TabIndex = 27;
            this.Status.Text = "Fase:";
            // 
            // FaseLabel
            // 
            this.FaseLabel.AutoSize = true;
            this.FaseLabel.Font = new System.Drawing.Font("Modern No. 20", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaseLabel.Location = new System.Drawing.Point(535, 61);
            this.FaseLabel.Name = "FaseLabel";
            this.FaseLabel.Size = new System.Drawing.Size(197, 34);
            this.FaseLabel.TabIndex = 28;
            this.FaseLabel.Text = "Warming Up";
            // 
            // Timerlabel
            // 
            this.Timerlabel.AutoSize = true;
            this.Timerlabel.Font = new System.Drawing.Font("Modern No. 20", 102F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timerlabel.Location = new System.Drawing.Point(392, 95);
            this.Timerlabel.Name = "Timerlabel";
            this.Timerlabel.Size = new System.Drawing.Size(343, 139);
            this.Timerlabel.TabIndex = 29;
            this.Timerlabel.Text = "00:00";
            // 
            // RPM_Indication_Picture
            // 
            this.RPM_Indication_Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RPM_Indication_Picture.Image = ((System.Drawing.Image)(resources.GetObject("RPM_Indication_Picture.Image")));
            this.RPM_Indication_Picture.Location = new System.Drawing.Point(26, 60);
            this.RPM_Indication_Picture.Name = "RPM_Indication_Picture";
            this.RPM_Indication_Picture.Size = new System.Drawing.Size(376, 435);
            this.RPM_Indication_Picture.TabIndex = 30;
            this.RPM_Indication_Picture.TabStop = false;
            // 
            // Rpm_Lbl
            // 
            this.Rpm_Lbl.AutoSize = true;
            this.Rpm_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rpm_Lbl.Location = new System.Drawing.Point(716, 234);
            this.Rpm_Lbl.Name = "Rpm_Lbl";
            this.Rpm_Lbl.Size = new System.Drawing.Size(75, 54);
            this.Rpm_Lbl.TabIndex = 31;
            this.Rpm_Lbl.Text = "57";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 54);
            this.label1.TabIndex = 32;
            this.label1.Text = "RPM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(417, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 54);
            this.label2.TabIndex = 34;
            this.label2.Text = "Pulse:";
            // 
            // Pulse_Lbl
            // 
            this.Pulse_Lbl.AutoSize = true;
            this.Pulse_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pulse_Lbl.Location = new System.Drawing.Point(690, 288);
            this.Pulse_Lbl.Name = "Pulse_Lbl";
            this.Pulse_Lbl.Size = new System.Drawing.Size(101, 54);
            this.Pulse_Lbl.TabIndex = 33;
            this.Pulse_Lbl.Text = "135";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(420, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 31);
            this.label3.TabIndex = 36;
            this.label3.Text = "Pulse (15 sec ago):";
            // 
            // Old_Pulse_Lbl
            // 
            this.Old_Pulse_Lbl.AutoSize = true;
            this.Old_Pulse_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Old_Pulse_Lbl.Location = new System.Drawing.Point(719, 342);
            this.Old_Pulse_Lbl.Name = "Old_Pulse_Lbl";
            this.Old_Pulse_Lbl.Size = new System.Drawing.Size(59, 31);
            this.Old_Pulse_Lbl.TabIndex = 35;
            this.Old_Pulse_Lbl.Text = "135";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(417, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 54);
            this.label5.TabIndex = 38;
            this.label5.Text = "Resistance:";
            // 
            // Resistance_Lbl
            // 
            this.Resistance_Lbl.AutoSize = true;
            this.Resistance_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resistance_Lbl.Location = new System.Drawing.Point(690, 373);
            this.Resistance_Lbl.Name = "Resistance_Lbl";
            this.Resistance_Lbl.Size = new System.Drawing.Size(101, 54);
            this.Resistance_Lbl.TabIndex = 37;
            this.Resistance_Lbl.Text = "225";
            // 
            // Steady_State
            // 
            this.Steady_State.AutoSize = true;
            this.Steady_State.BackColor = System.Drawing.Color.Lime;
            this.Steady_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Steady_State.Location = new System.Drawing.Point(461, 433);
            this.Steady_State.Name = "Steady_State";
            this.Steady_State.Size = new System.Drawing.Size(290, 54);
            this.Steady_State.TabIndex = 39;
            this.Steady_State.Text = "Steady State";
            // 
            // VO2max_Lbl
            // 
            this.VO2max_Lbl.AutoSize = true;
            this.VO2max_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VO2max_Lbl.Location = new System.Drawing.Point(700, 503);
            this.VO2max_Lbl.Name = "VO2max_Lbl";
            this.VO2max_Lbl.Size = new System.Drawing.Size(91, 54);
            this.VO2max_Lbl.TabIndex = 40;
            this.VO2max_Lbl.Text = "2.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 63);
            this.label4.TabIndex = 41;
            this.label4.Text = "VO2max";
            // 
            // Secure_Lbl
            // 
            this.Secure_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Secure_Lbl.AutoSize = true;
            this.Secure_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Secure_Lbl.Location = new System.Drawing.Point(797, 512);
            this.Secure_Lbl.Name = "Secure_Lbl";
            this.Secure_Lbl.Size = new System.Drawing.Size(118, 31);
            this.Secure_Lbl.TabIndex = 42;
            this.Secure_Lbl.Text = "(Secure)";
            this.Secure_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Chart.Legends.Add(legend2);
            this.Chart.Location = new System.Drawing.Point(16, 560);
            this.Chart.Name = "Chart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "RPM";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Pulse";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Resistance";
            this.Chart.Series.Add(series4);
            this.Chart.Series.Add(series5);
            this.Chart.Series.Add(series6);
            this.Chart.Size = new System.Drawing.Size(1048, 245);
            this.Chart.TabIndex = 43;
            this.Chart.Text = "chart1";
            // 
            // NewResistence_Lbl
            // 
            this.NewResistence_Lbl.AutoSize = true;
            this.NewResistence_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewResistence_Lbl.ForeColor = System.Drawing.Color.Red;
            this.NewResistence_Lbl.Location = new System.Drawing.Point(797, 373);
            this.NewResistence_Lbl.Name = "NewResistence_Lbl";
            this.NewResistence_Lbl.Size = new System.Drawing.Size(201, 54);
            this.NewResistence_Lbl.TabIndex = 44;
            this.NewResistence_Lbl.Text = ">>> 275";
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1101, 817);
            this.Controls.Add(this.NewResistence_Lbl);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.Secure_Lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VO2max_Lbl);
            this.Controls.Add(this.Steady_State);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Resistance_Lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Old_Pulse_Lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Pulse_Lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rpm_Lbl);
            this.Controls.Add(this.RPM_Indication_Picture);
            this.Controls.Add(this.Timerlabel);
            this.Controls.Add(this.FaseLabel);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.comPorts);
            this.Controls.Add(this.BStart);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Console";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            ((System.ComponentModel.ISupportInitialize)(this.RPM_Indication_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
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
        private System.Windows.Forms.PictureBox RPM_Indication_Picture;
        private System.Windows.Forms.Label Rpm_Lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Pulse_Lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Old_Pulse_Lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Resistance_Lbl;
        private System.Windows.Forms.Label Steady_State;
        private System.Windows.Forms.Label VO2max_Lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Secure_Lbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Label NewResistence_Lbl;
    }
}

