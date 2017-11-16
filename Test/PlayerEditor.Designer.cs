namespace Test
{
    partial class PlayerEditor
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
            this.editorlabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.shotsLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ratingTextBox = new System.Windows.Forms.TextBox();
            this.accuracyTextBox = new System.Windows.Forms.TextBox();
            this.shotsTextBox = new System.Windows.Forms.TextBox();
            this.saveBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editorlabel
            // 
            this.editorlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorlabel.AutoSize = true;
            this.editorlabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.editorlabel.Location = new System.Drawing.Point(12, 9);
            this.editorlabel.Name = "editorlabel";
            this.editorlabel.Size = new System.Drawing.Size(321, 26);
            this.editorlabel.TabIndex = 0;
            this.editorlabel.Text = "РЕДАКТИРОВАНИЕ ИГРОКА";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.nameLabel.Location = new System.Drawing.Point(14, 77);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(89, 16);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Имя игрока";
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.ratingLabel.Location = new System.Drawing.Point(14, 156);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(64, 16);
            this.ratingLabel.TabIndex = 2;
            this.ratingLabel.Text = "Рейтинг";
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.accuracyLabel.Location = new System.Drawing.Point(14, 247);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(72, 16);
            this.accuracyLabel.TabIndex = 3;
            this.accuracyLabel.Text = "Точность";
            // 
            // shotsLabel
            // 
            this.shotsLabel.AutoSize = true;
            this.shotsLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.shotsLabel.Location = new System.Drawing.Point(14, 350);
            this.shotsLabel.Name = "shotsLabel";
            this.shotsLabel.Size = new System.Drawing.Size(83, 16);
            this.shotsLabel.TabIndex = 4;
            this.shotsLabel.Text = "Выстрелы";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.nameTextBox.Location = new System.Drawing.Point(17, 96);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(270, 23);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.ratingTextBox.Location = new System.Drawing.Point(17, 175);
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.Size = new System.Drawing.Size(270, 23);
            this.ratingTextBox.TabIndex = 6;
            this.ratingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ratingTextBox_KeyPress);
            // 
            // accuracyTextBox
            // 
            this.accuracyTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.accuracyTextBox.Location = new System.Drawing.Point(17, 266);
            this.accuracyTextBox.Name = "accuracyTextBox";
            this.accuracyTextBox.Size = new System.Drawing.Size(270, 23);
            this.accuracyTextBox.TabIndex = 7;
            this.accuracyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accuracyTextBox_KeyPress);
            // 
            // shotsTextBox
            // 
            this.shotsTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.shotsTextBox.Location = new System.Drawing.Point(17, 369);
            this.shotsTextBox.Name = "shotsTextBox";
            this.shotsTextBox.Size = new System.Drawing.Size(270, 23);
            this.shotsTextBox.TabIndex = 8;
            this.shotsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shotsTextBox_KeyPress);
            // 
            // saveBt
            // 
            this.saveBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.saveBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBt.Font = new System.Drawing.Font("Arial", 10F);
            this.saveBt.ForeColor = System.Drawing.Color.White;
            this.saveBt.Location = new System.Drawing.Point(288, 423);
            this.saveBt.Name = "saveBt";
            this.saveBt.Size = new System.Drawing.Size(103, 33);
            this.saveBt.TabIndex = 9;
            this.saveBt.Text = "Сохранить";
            this.saveBt.UseVisualStyleBackColor = false;
            this.saveBt.Click += new System.EventHandler(this.saveBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cancelBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.cancelBt.Location = new System.Drawing.Point(179, 423);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(103, 33);
            this.cancelBt.TabIndex = 10;
            this.cancelBt.Text = "Отменить";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // PlayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 490);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.saveBt);
            this.Controls.Add(this.shotsTextBox);
            this.Controls.Add(this.accuracyTextBox);
            this.Controls.Add(this.ratingTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.shotsLabel);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.editorlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label editorlabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.Label shotsLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ratingTextBox;
        private System.Windows.Forms.TextBox accuracyTextBox;
        private System.Windows.Forms.TextBox shotsTextBox;
        private System.Windows.Forms.Button saveBt;
        private System.Windows.Forms.Button cancelBt;
    }
}