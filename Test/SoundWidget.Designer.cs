namespace Test
{
    partial class SoundWidget
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
            this.SoundLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SoundLabel
            // 
            this.SoundLabel.AutoSize = true;
            this.SoundLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SoundLabel.Location = new System.Drawing.Point(30, 31);
            this.SoundLabel.Name = "SoundLabel";
            this.SoundLabel.Size = new System.Drawing.Size(84, 26);
            this.SoundLabel.TabIndex = 0;
            this.SoundLabel.Text = "ЗВУКИ";
            // 
            // SoundWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 452);
            this.Controls.Add(this.SoundLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SoundWidget";
            this.Text = "SoundWidget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SoundLabel;
    }
}