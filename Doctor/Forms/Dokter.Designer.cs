namespace Doctor
{
    partial class Dokter
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
            this.Awaiting_Patients_Box = new System.Windows.Forms.ListBox();
            this.Log_Out_Btn = new System.Windows.Forms.Button();
            this.NewUserNamebox = new System.Windows.Forms.TextBox();
            this.NewUserPasswordBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Old_Sessions_Box = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Newuserbtn = new System.Windows.Forms.Button();
            this.RBFemale = new System.Windows.Forms.RadioButton();
            this.RBMale = new System.Windows.Forms.RadioButton();
            this.lbAge = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.NewUserAge = new System.Windows.Forms.TextBox();
            this.NewUserFull = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.searchbutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Awaiting_Patients_Box
            // 
            this.Awaiting_Patients_Box.FormattingEnabled = true;
            this.Awaiting_Patients_Box.Location = new System.Drawing.Point(12, 12);
            this.Awaiting_Patients_Box.Name = "Awaiting_Patients_Box";
            this.Awaiting_Patients_Box.Size = new System.Drawing.Size(172, 303);
            this.Awaiting_Patients_Box.TabIndex = 0;
            this.Awaiting_Patients_Box.SelectedIndexChanged += new System.EventHandler(this.Patient_Selected);
            // 
            // Log_Out_Btn
            // 
            this.Log_Out_Btn.Location = new System.Drawing.Point(12, 321);
            this.Log_Out_Btn.Name = "Log_Out_Btn";
            this.Log_Out_Btn.Size = new System.Drawing.Size(77, 36);
            this.Log_Out_Btn.TabIndex = 4;
            this.Log_Out_Btn.Text = "Log out";
            this.Log_Out_Btn.UseVisualStyleBackColor = true;
            this.Log_Out_Btn.Click += new System.EventHandler(this.Log_Out_Btn_Click);
            // 
            // NewUserNamebox
            // 
            this.NewUserNamebox.Location = new System.Drawing.Point(125, 19);
            this.NewUserNamebox.Name = "NewUserNamebox";
            this.NewUserNamebox.Size = new System.Drawing.Size(216, 20);
            this.NewUserNamebox.TabIndex = 5;
            // 
            // NewUserPasswordBox
            // 
            this.NewUserPasswordBox.Location = new System.Drawing.Point(125, 45);
            this.NewUserPasswordBox.Name = "NewUserPasswordBox";
            this.NewUserPasswordBox.Size = new System.Drawing.Size(216, 20);
            this.NewUserPasswordBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Old_Sessions_Box
            // 
            this.Old_Sessions_Box.FormattingEnabled = true;
            this.Old_Sessions_Box.Location = new System.Drawing.Point(190, 12);
            this.Old_Sessions_Box.Name = "Old_Sessions_Box";
            this.Old_Sessions_Box.Size = new System.Drawing.Size(165, 303);
            this.Old_Sessions_Box.TabIndex = 8;
            this.Old_Sessions_Box.DoubleClick += new System.EventHandler(this.Old_Session_Double_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Newuserbtn);
            this.groupBox1.Controls.Add(this.RBFemale);
            this.groupBox1.Controls.Add(this.RBMale);
            this.groupBox1.Controls.Add(this.lbAge);
            this.groupBox1.Controls.Add(this.lblFullname);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.NewUserAge);
            this.groupBox1.Controls.Add(this.NewUserFull);
            this.groupBox1.Controls.Add(this.NewUserNamebox);
            this.groupBox1.Controls.Add(this.NewUserPasswordBox);
            this.groupBox1.Location = new System.Drawing.Point(429, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 179);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Patient";
            // 
            // Newuserbtn
            // 
            this.Newuserbtn.Location = new System.Drawing.Point(266, 130);
            this.Newuserbtn.Name = "Newuserbtn";
            this.Newuserbtn.Size = new System.Drawing.Size(75, 34);
            this.Newuserbtn.TabIndex = 17;
            this.Newuserbtn.Text = "Aanmaken";
            this.Newuserbtn.UseVisualStyleBackColor = true;
            // 
            // RBFemale
            // 
            this.RBFemale.AutoSize = true;
            this.RBFemale.Location = new System.Drawing.Point(164, 134);
            this.RBFemale.Name = "RBFemale";
            this.RBFemale.Size = new System.Drawing.Size(59, 17);
            this.RBFemale.TabIndex = 16;
            this.RBFemale.TabStop = true;
            this.RBFemale.Text = "Female";
            this.RBFemale.UseVisualStyleBackColor = true;
            // 
            // RBMale
            // 
            this.RBMale.AutoSize = true;
            this.RBMale.Location = new System.Drawing.Point(79, 135);
            this.RBMale.Name = "RBMale";
            this.RBMale.Size = new System.Drawing.Size(48, 17);
            this.RBMale.TabIndex = 15;
            this.RBMale.TabStop = true;
            this.RBMale.Text = "Male";
            this.RBMale.UseVisualStyleBackColor = true;
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(63, 98);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(26, 13);
            this.lbAge.TabIndex = 14;
            this.lbAge.Text = "Age";
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Location = new System.Drawing.Point(44, 72);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(49, 13);
            this.lblFullname.TabIndex = 13;
            this.lblFullname.Text = "Fullname";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 45);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(39, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Username";
            // 
            // NewUserAge
            // 
            this.NewUserAge.Location = new System.Drawing.Point(125, 98);
            this.NewUserAge.Name = "NewUserAge";
            this.NewUserAge.Size = new System.Drawing.Size(216, 20);
            this.NewUserAge.TabIndex = 10;
            // 
            // NewUserFull
            // 
            this.NewUserFull.Location = new System.Drawing.Point(125, 72);
            this.NewUserFull.Name = "NewUserFull";
            this.NewUserFull.Size = new System.Drawing.Size(216, 20);
            this.NewUserFull.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(410, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(243, 20);
            this.textBox3.TabIndex = 10;
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(676, 12);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(98, 23);
            this.searchbutton.TabIndex = 11;
            this.searchbutton.Text = "Search Patient";
            this.searchbutton.UseVisualStyleBackColor = true;
            // 
            // Dokter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 392);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Old_Sessions_Box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Log_Out_Btn);
            this.Controls.Add(this.Awaiting_Patients_Box);
            this.Name = "Dokter";
            this.Text = "Dokter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Awaiting_Patients_Box;
        private System.Windows.Forms.Button Log_Out_Btn;
        private System.Windows.Forms.TextBox NewUserNamebox;
        private System.Windows.Forms.TextBox NewUserPasswordBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox Old_Sessions_Box;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NewUserFull;
        private System.Windows.Forms.TextBox NewUserAge;
        private System.Windows.Forms.Button Newuserbtn;
        private System.Windows.Forms.RadioButton RBFemale;
        private System.Windows.Forms.RadioButton RBMale;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button searchbutton;
    }
}

