namespace Test
{
    partial class VK
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
            this.loginLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.loginTextbox = new System.Windows.Forms.TextBox();
            this.passTextbox = new System.Windows.Forms.TextBox();
            this.publicateBt = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.RichTextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.closeBt = new System.Windows.Forms.Button();
            this.checkBoxImage = new System.Windows.Forms.CheckBox();
            this.checkBoxDocs = new System.Windows.Forms.CheckBox();
            this.checkedListBoxDocs = new System.Windows.Forms.CheckedListBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.loginLabel.Location = new System.Drawing.Point(12, 9);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(50, 16);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Логин";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.passLabel.Location = new System.Drawing.Point(12, 54);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(62, 16);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "Пароль";
            // 
            // loginTextbox
            // 
            this.loginTextbox.Font = new System.Drawing.Font("Arial", 10F);
            this.loginTextbox.Location = new System.Drawing.Point(15, 28);
            this.loginTextbox.Name = "loginTextbox";
            this.loginTextbox.Size = new System.Drawing.Size(220, 23);
            this.loginTextbox.TabIndex = 2;
            this.loginTextbox.Text = "scorpwork@mail.ru";
            // 
            // passTextbox
            // 
            this.passTextbox.Font = new System.Drawing.Font("Arial", 8.25F);
            this.passTextbox.Location = new System.Drawing.Point(15, 73);
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.PasswordChar = '*';
            this.passTextbox.Size = new System.Drawing.Size(220, 20);
            this.passTextbox.TabIndex = 3;
            // 
            // publicateBt
            // 
            this.publicateBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.publicateBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.publicateBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.publicateBt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.publicateBt.ForeColor = System.Drawing.Color.White;
            this.publicateBt.Location = new System.Drawing.Point(247, 463);
            this.publicateBt.Name = "publicateBt";
            this.publicateBt.Size = new System.Drawing.Size(153, 39);
            this.publicateBt.TabIndex = 4;
            this.publicateBt.Text = "ОПУБЛИКОВАТЬ";
            this.publicateBt.UseVisualStyleBackColor = false;
            this.publicateBt.Click += new System.EventHandler(this.publicateBt_Click);
            // 
            // inputText
            // 
            this.inputText.Font = new System.Drawing.Font("Arial", 10F);
            this.inputText.Location = new System.Drawing.Point(12, 325);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(388, 132);
            this.inputText.TabIndex = 5;
            this.inputText.Text = "";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textLabel.Location = new System.Drawing.Point(12, 306);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(130, 16);
            this.textLabel.TabIndex = 6;
            this.textLabel.Text = "Текст сообщения";
            // 
            // closeBt
            // 
            this.closeBt.BackColor = System.Drawing.Color.White;
            this.closeBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.closeBt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.closeBt.Location = new System.Drawing.Point(88, 463);
            this.closeBt.Name = "closeBt";
            this.closeBt.Size = new System.Drawing.Size(153, 39);
            this.closeBt.TabIndex = 7;
            this.closeBt.Text = "ОТМЕНИТЬ";
            this.closeBt.UseVisualStyleBackColor = false;
            this.closeBt.Click += new System.EventHandler(this.closeBt_Click);
            // 
            // checkBoxImage
            // 
            this.checkBoxImage.AutoSize = true;
            this.checkBoxImage.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxImage.Location = new System.Drawing.Point(12, 155);
            this.checkBoxImage.Name = "checkBoxImage";
            this.checkBoxImage.Size = new System.Drawing.Size(220, 20);
            this.checkBoxImage.TabIndex = 8;
            this.checkBoxImage.Text = "Прикрепить снимок экрана";
            this.checkBoxImage.UseVisualStyleBackColor = true;
            // 
            // checkBoxDocs
            // 
            this.checkBoxDocs.AutoSize = true;
            this.checkBoxDocs.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxDocs.Location = new System.Drawing.Point(12, 181);
            this.checkBoxDocs.Name = "checkBoxDocs";
            this.checkBoxDocs.Size = new System.Drawing.Size(194, 20);
            this.checkBoxDocs.TabIndex = 9;
            this.checkBoxDocs.Text = "Прикрепить документы";
            this.checkBoxDocs.UseVisualStyleBackColor = true;
            this.checkBoxDocs.CheckedChanged += new System.EventHandler(this.checkBoxDocs_CheckedChanged);
            // 
            // checkedListBoxDocs
            // 
            this.checkedListBoxDocs.Font = new System.Drawing.Font("Arial", 8F);
            this.checkedListBoxDocs.FormattingEnabled = true;
            this.checkedListBoxDocs.Location = new System.Drawing.Point(12, 207);
            this.checkedListBoxDocs.Name = "checkedListBoxDocs";
            this.checkedListBoxDocs.Size = new System.Drawing.Size(385, 79);
            this.checkedListBoxDocs.TabIndex = 10;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelGroup.Location = new System.Drawing.Point(12, 96);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(55, 16);
            this.labelGroup.TabIndex = 11;
            this.labelGroup.Text = "Группа";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Font = new System.Drawing.Font("Arial", 8F);
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "scorpwork"});
            this.comboBoxGroup.Location = new System.Drawing.Point(15, 115);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(220, 22);
            this.comboBoxGroup.TabIndex = 12;
            // 
            // VK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 514);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.checkedListBoxDocs);
            this.Controls.Add(this.checkBoxDocs);
            this.Controls.Add(this.checkBoxImage);
            this.Controls.Add(this.closeBt);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.publicateBt);
            this.Controls.Add(this.passTextbox);
            this.Controls.Add(this.loginTextbox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.loginLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VK";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VK_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox loginTextbox;
        private System.Windows.Forms.TextBox passTextbox;
        private System.Windows.Forms.Button publicateBt;
        private System.Windows.Forms.RichTextBox inputText;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button closeBt;
        private System.Windows.Forms.CheckBox checkBoxImage;
        private System.Windows.Forms.CheckBox checkBoxDocs;
        private System.Windows.Forms.CheckedListBox checkedListBoxDocs;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.ComboBox comboBoxGroup;
    }
}