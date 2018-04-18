namespace DatabaseRestore
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tbRestoreAs = new System.Windows.Forms.TextBox();
            this.ofdFindBackup = new System.Windows.Forms.OpenFileDialog();
            this.tbBackupFile = new System.Windows.Forms.TextBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImporter = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbInstanceNames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMixedMode = new System.Windows.Forms.Button();
            this.btnCheckLoginMode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnableSA = new System.Windows.Forms.Button();
            this.btnSaPassord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRestoreAs
            // 
            this.tbRestoreAs.Location = new System.Drawing.Point(11, 101);
            this.tbRestoreAs.Name = "tbRestoreAs";
            this.tbRestoreAs.Size = new System.Drawing.Size(315, 20);
            this.tbRestoreAs.TabIndex = 1;
            // 
            // tbBackupFile
            // 
            this.tbBackupFile.Location = new System.Drawing.Point(42, 194);
            this.tbBackupFile.Name = "tbBackupFile";
            this.tbBackupFile.ReadOnly = true;
            this.tbBackupFile.Size = new System.Drawing.Size(284, 20);
            this.tbBackupFile.TabIndex = 5;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(12, 194);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(24, 20);
            this.btnChooseFile.TabIndex = 4;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Navn databasen skal restores med";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Velg .bak filen";
            // 
            // btnImporter
            // 
            this.btnImporter.Location = new System.Drawing.Point(12, 239);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(75, 23);
            this.btnImporter.TabIndex = 6;
            this.btnImporter.Text = "Importer";
            this.btnImporter.UseVisualStyleBackColor = true;
            this.btnImporter.Click += new System.EventHandler(this.btnImporter_Click);
            // 
            // cbInstanceNames
            // 
            this.cbInstanceNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInstanceNames.FormattingEnabled = true;
            this.cbInstanceNames.Location = new System.Drawing.Point(11, 146);
            this.cbInstanceNames.Name = "cbInstanceNames";
            this.cbInstanceNames.Size = new System.Drawing.Size(315, 21);
            this.cbInstanceNames.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Instans";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnMixedMode
            // 
            this.btnMixedMode.Location = new System.Drawing.Point(211, 268);
            this.btnMixedMode.Name = "btnMixedMode";
            this.btnMixedMode.Size = new System.Drawing.Size(113, 23);
            this.btnMixedMode.TabIndex = 10;
            this.btnMixedMode.Text = "Bytt til Mixed mode";
            this.btnMixedMode.UseVisualStyleBackColor = true;
            this.btnMixedMode.Click += new System.EventHandler(this.btnMixedMode_Click);
            // 
            // btnCheckLoginMode
            // 
            this.btnCheckLoginMode.Location = new System.Drawing.Point(93, 239);
            this.btnCheckLoginMode.Name = "btnCheckLoginMode";
            this.btnCheckLoginMode.Size = new System.Drawing.Size(114, 23);
            this.btnCheckLoginMode.TabIndex = 11;
            this.btnCheckLoginMode.Text = "Sjekk Mode";
            this.btnCheckLoginMode.UseVisualStyleBackColor = true;
            this.btnCheckLoginMode.Click += new System.EventHandler(this.btnCheckLoginMode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(220, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "KUN FOR 2017";
            // 
            // btnEnableSA
            // 
            this.btnEnableSA.Location = new System.Drawing.Point(11, 268);
            this.btnEnableSA.Name = "btnEnableSA";
            this.btnEnableSA.Size = new System.Drawing.Size(76, 23);
            this.btnEnableSA.TabIndex = 13;
            this.btnEnableSA.Text = "Aktiver SA";
            this.btnEnableSA.UseVisualStyleBackColor = true;
            this.btnEnableSA.Click += new System.EventHandler(this.btnEnableSA_Click);
            // 
            // btnSaPassord
            // 
            this.btnSaPassord.Location = new System.Drawing.Point(93, 268);
            this.btnSaPassord.Name = "btnSaPassord";
            this.btnSaPassord.Size = new System.Drawing.Size(114, 23);
            this.btnSaPassord.TabIndex = 14;
            this.btnSaPassord.Text = "Endre SA passord";
            this.btnSaPassord.UseVisualStyleBackColor = true;
            this.btnSaPassord.Click += new System.EventHandler(this.btnSaPassord_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 299);
            this.Controls.Add(this.btnSaPassord);
            this.Controls.Add(this.btnEnableSA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCheckLoginMode);
            this.Controls.Add(this.btnMixedMode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbInstanceNames);
            this.Controls.Add(this.btnImporter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.tbBackupFile);
            this.Controls.Add(this.tbRestoreAs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBRestore";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbRestoreAs;
        private System.Windows.Forms.OpenFileDialog ofdFindBackup;
        private System.Windows.Forms.TextBox tbBackupFile;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImporter;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbInstanceNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMixedMode;
        private System.Windows.Forms.Button btnCheckLoginMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnableSA;
        private System.Windows.Forms.Button btnSaPassord;
    }
}

