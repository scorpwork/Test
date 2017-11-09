namespace Test
{
    partial class DownloadWidget
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
            this.downloadLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.downloadTextBox = new System.Windows.Forms.TextBox();
            this.lineLabel = new System.Windows.Forms.Label();
            this.downloadBt = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statisticBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadLabel.Location = new System.Drawing.Point(30, 31);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(124, 26);
            this.downloadLabel.TabIndex = 0;
            this.downloadLabel.Text = "ЗАГРУЗКА";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressLabel.Location = new System.Drawing.Point(32, 75);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(106, 17);
            this.addressLabel.TabIndex = 1;
            this.addressLabel.Text = "Адрес файла";
            // 
            // downloadTextBox
            // 
            this.downloadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.downloadTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.downloadTextBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadTextBox.Location = new System.Drawing.Point(35, 113);
            this.downloadTextBox.Name = "downloadTextBox";
            this.downloadTextBox.Size = new System.Drawing.Size(444, 16);
            this.downloadTextBox.TabIndex = 3;
            this.downloadTextBox.Text = "https://laserwar.com/testtask/get?datatype=json";
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineLabel.ForeColor = System.Drawing.Color.Blue;
            this.lineLabel.Location = new System.Drawing.Point(31, 132);
            this.lineLabel.MaximumSize = new System.Drawing.Size(0, 30);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(448, 7);
            this.lineLabel.TabIndex = 6;
            this.lineLabel.Text = "_________________________________________________________________________________" +
    "___________________________________________________________________\r\n";
            // 
            // downloadBt
            // 
            this.downloadBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.downloadBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadBt.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadBt.ForeColor = System.Drawing.Color.White;
            this.downloadBt.Location = new System.Drawing.Point(502, 107);
            this.downloadBt.Name = "downloadBt";
            this.downloadBt.Size = new System.Drawing.Size(119, 32);
            this.downloadBt.TabIndex = 7;
            this.downloadBt.Text = "ЗАГРУЗИТЬ";
            this.downloadBt.UseVisualStyleBackColor = false;
            this.downloadBt.Click += new System.EventHandler(this.downloadBt_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(647, 115);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(179, 16);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Файл успешно загружен";
            this.statusLabel.Visible = false;
            // 
            // statisticBox
            // 
            this.statisticBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticBox.BackColor = System.Drawing.Color.White;
            this.statisticBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statisticBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statisticBox.Location = new System.Drawing.Point(38, 170);
            this.statisticBox.Name = "statisticBox";
            this.statisticBox.ReadOnly = true;
            this.statisticBox.Size = new System.Drawing.Size(788, 189);
            this.statisticBox.TabIndex = 9;
            this.statisticBox.Text = "";
            // 
            // DownloadWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 385);
            this.Controls.Add(this.statisticBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.downloadBt);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.downloadTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.downloadLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DownloadWidget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox downloadTextBox;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Button downloadBt;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.RichTextBox statisticBox;
    }
}