namespace Test
{
    partial class Msg
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.closeBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.headerLabel.Location = new System.Drawing.Point(43, 36);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(71, 26);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "label1";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.textLabel.Location = new System.Drawing.Point(45, 95);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(46, 16);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "label2";
            // 
            // closeBt
            // 
            this.closeBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.closeBt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBt.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.closeBt.ForeColor = System.Drawing.Color.White;
            this.closeBt.Location = new System.Drawing.Point(257, 294);
            this.closeBt.Name = "closeBt";
            this.closeBt.Size = new System.Drawing.Size(102, 33);
            this.closeBt.TabIndex = 2;
            this.closeBt.Text = "закрыть";
            this.closeBt.UseVisualStyleBackColor = false;
            this.closeBt.Click += new System.EventHandler(this.closeBt_Click);
            // 
            // Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 369);
            this.Controls.Add(this.closeBt);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Msg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Msg";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Msg_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button closeBt;
    }
}