namespace Test
{
    partial class GameWidget
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
            this.gamesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gamesLabel
            // 
            this.gamesLabel.AutoSize = true;
            this.gamesLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gamesLabel.Location = new System.Drawing.Point(30, 31);
            this.gamesLabel.Name = "gamesLabel";
            this.gamesLabel.Size = new System.Drawing.Size(77, 26);
            this.gamesLabel.TabIndex = 0;
            this.gamesLabel.Text = "ИГРЫ";
            // 
            // GameWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 381);
            this.Controls.Add(this.gamesLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameWidget";
            this.Text = "GameWidget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gamesLabel;
    }
}