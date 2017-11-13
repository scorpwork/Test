namespace Test
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainControlPanel = new System.Windows.Forms.Panel();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.panelSounds = new System.Windows.Forms.Panel();
            this.panelGames = new System.Windows.Forms.Panel();
            this.gamesRb = new System.Windows.Forms.RadioButton();
            this.downloadRb = new System.Windows.Forms.RadioButton();
            this.soundRb = new System.Windows.Forms.RadioButton();
            this.mainControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainControlPanel
            // 
            this.mainControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.mainControlPanel.Controls.Add(this.gamesRb);
            this.mainControlPanel.Controls.Add(this.downloadRb);
            this.mainControlPanel.Controls.Add(this.soundRb);
            this.mainControlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainControlPanel.Location = new System.Drawing.Point(0, 0);
            this.mainControlPanel.Name = "mainControlPanel";
            this.mainControlPanel.Size = new System.Drawing.Size(83, 482);
            this.mainControlPanel.TabIndex = 0;
            // 
            // panelDownload
            // 
            this.panelDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownload.Location = new System.Drawing.Point(83, 0);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(680, 482);
            this.panelDownload.TabIndex = 1;
            // 
            // panelSounds
            // 
            this.panelSounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSounds.Location = new System.Drawing.Point(83, 0);
            this.panelSounds.Name = "panelSounds";
            this.panelSounds.Size = new System.Drawing.Size(680, 482);
            this.panelSounds.TabIndex = 2;
            // 
            // panelGames
            // 
            this.panelGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGames.Location = new System.Drawing.Point(83, 0);
            this.panelGames.Name = "panelGames";
            this.panelGames.Size = new System.Drawing.Size(680, 482);
            this.panelGames.TabIndex = 3;
            // 
            // gamesRb
            // 
            this.gamesRb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gamesRb.Appearance = System.Windows.Forms.Appearance.Button;
            this.gamesRb.AutoSize = true;
            this.gamesRb.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gamesRb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gamesRb.FlatAppearance.BorderSize = 0;
            this.gamesRb.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.gamesRb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gamesRb.Image = global::Test.Properties.Resources.games;
            this.gamesRb.Location = new System.Drawing.Point(0, 259);
            this.gamesRb.MinimumSize = new System.Drawing.Size(83, 70);
            this.gamesRb.Name = "gamesRb";
            this.gamesRb.Size = new System.Drawing.Size(83, 70);
            this.gamesRb.TabIndex = 3;
            this.gamesRb.TabStop = true;
            this.gamesRb.UseVisualStyleBackColor = true;
            this.gamesRb.CheckedChanged += new System.EventHandler(this.gamesRb_CheckedChanged);
            // 
            // downloadRb
            // 
            this.downloadRb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.downloadRb.Appearance = System.Windows.Forms.Appearance.Button;
            this.downloadRb.AutoSize = true;
            this.downloadRb.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadRb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadRb.FlatAppearance.BorderSize = 0;
            this.downloadRb.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.downloadRb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadRb.Image = global::Test.Properties.Resources.download;
            this.downloadRb.Location = new System.Drawing.Point(0, 117);
            this.downloadRb.MinimumSize = new System.Drawing.Size(83, 70);
            this.downloadRb.Name = "downloadRb";
            this.downloadRb.Size = new System.Drawing.Size(83, 70);
            this.downloadRb.TabIndex = 1;
            this.downloadRb.TabStop = true;
            this.downloadRb.UseVisualStyleBackColor = true;
            this.downloadRb.CheckedChanged += new System.EventHandler(this.downloadRb_CheckedChanged);
            // 
            // soundRb
            // 
            this.soundRb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.soundRb.Appearance = System.Windows.Forms.Appearance.Button;
            this.soundRb.AutoSize = true;
            this.soundRb.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.soundRb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.soundRb.FlatAppearance.BorderSize = 0;
            this.soundRb.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.soundRb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundRb.Image = global::Test.Properties.Resources.sounds;
            this.soundRb.Location = new System.Drawing.Point(0, 188);
            this.soundRb.MinimumSize = new System.Drawing.Size(83, 70);
            this.soundRb.Name = "soundRb";
            this.soundRb.Size = new System.Drawing.Size(83, 70);
            this.soundRb.TabIndex = 2;
            this.soundRb.TabStop = true;
            this.soundRb.UseVisualStyleBackColor = true;
            this.soundRb.CheckedChanged += new System.EventHandler(this.soundRb_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(763, 482);
            this.Controls.Add(this.panelGames);
            this.Controls.Add(this.panelSounds);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.mainControlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainControlPanel.ResumeLayout(false);
            this.mainControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainControlPanel;
        private System.Windows.Forms.RadioButton downloadRb;
        private System.Windows.Forms.RadioButton soundRb;
        private System.Windows.Forms.RadioButton gamesRb;
        private System.Windows.Forms.Panel panelDownload;
        private System.Windows.Forms.Panel panelSounds;
        private System.Windows.Forms.Panel panelGames;
    }
}

