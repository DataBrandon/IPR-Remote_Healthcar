namespace Doctor
{
    partial class Session
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grafiek = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.patientName = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.sessionDate = new System.Windows.Forms.Label();
            this.Secure_Lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VO2max_Lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grafiek)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(285, 19);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 40;
            this.lblTime.Text = "00:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(241, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Time:";
            // 
            // grafiek
            // 
            chartArea3.Name = "ChartArea1";
            this.grafiek.ChartAreas.Add(chartArea3);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.IsDockedInsideChartArea = false;
            legend3.Name = "Legend1";
            this.grafiek.Legends.Add(legend3);
            this.grafiek.Location = new System.Drawing.Point(8, 47);
            this.grafiek.Name = "grafiek";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "Pulse";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "RPM";
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series9.Legend = "Legend1";
            series9.Name = "Resistance";
            this.grafiek.Series.Add(series7);
            this.grafiek.Series.Add(series8);
            this.grafiek.Series.Add(series9);
            this.grafiek.Size = new System.Drawing.Size(772, 372);
            this.grafiek.TabIndex = 59;
            this.grafiek.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(63, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Patient:";
            // 
            // patientName
            // 
            this.patientName.AutoSize = true;
            this.patientName.Location = new System.Drawing.Point(120, 19);
            this.patientName.Name = "patientName";
            this.patientName.Size = new System.Drawing.Size(41, 13);
            this.patientName.TabIndex = 64;
            this.patientName.Text = "label19";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(348, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 65;
            this.label19.Text = "Date:";
            // 
            // sessionDate
            // 
            this.sessionDate.AutoSize = true;
            this.sessionDate.Location = new System.Drawing.Point(392, 19);
            this.sessionDate.Name = "sessionDate";
            this.sessionDate.Size = new System.Drawing.Size(41, 13);
            this.sessionDate.TabIndex = 66;
            this.sessionDate.Text = "label20";
            // 
            // Secure_Lbl
            // 
            this.Secure_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Secure_Lbl.AutoSize = true;
            this.Secure_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Secure_Lbl.Location = new System.Drawing.Point(599, 447);
            this.Secure_Lbl.Name = "Secure_Lbl";
            this.Secure_Lbl.Size = new System.Drawing.Size(118, 31);
            this.Secure_Lbl.TabIndex = 69;
            this.Secure_Lbl.Text = "(Secure)";
            this.Secure_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 63);
            this.label4.TabIndex = 68;
            this.label4.Text = "VO2max";
            // 
            // VO2max_Lbl
            // 
            this.VO2max_Lbl.AutoSize = true;
            this.VO2max_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VO2max_Lbl.Location = new System.Drawing.Point(370, 422);
            this.VO2max_Lbl.Name = "VO2max_Lbl";
            this.VO2max_Lbl.Size = new System.Drawing.Size(129, 76);
            this.VO2max_Lbl.TabIndex = 67;
            this.VO2max_Lbl.Text = "2.5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(194, 498);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 70;
            this.label6.Text = "(ml/kg/min)";
            // 
            // Session
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 539);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Secure_Lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VO2max_Lbl);
            this.Controls.Add(this.sessionDate);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.patientName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grafiek);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label7);
            this.Name = "Session";
            this.Text = "Session";
            ((System.ComponentModel.ISupportInitialize)(this.grafiek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafiek;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label patientName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label sessionDate;
        private System.Windows.Forms.Label Secure_Lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label VO2max_Lbl;
        private System.Windows.Forms.Label label6;
    }
}