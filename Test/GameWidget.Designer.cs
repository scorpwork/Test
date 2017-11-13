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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gamesLabel = new System.Windows.Forms.Label();
            this.gameTable = new System.Windows.Forms.DataGridView();
            this.nameCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDetailGame = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gameTable)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesLabel
            // 
            this.gamesLabel.AutoSize = true;
            this.gamesLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gamesLabel.Location = new System.Drawing.Point(30, 31);
            this.gamesLabel.MinimumSize = new System.Drawing.Size(0, 50);
            this.gamesLabel.Name = "gamesLabel";
            this.gamesLabel.Size = new System.Drawing.Size(77, 50);
            this.gamesLabel.TabIndex = 0;
            this.gamesLabel.Text = "ИГРЫ";
            // 
            // gameTable
            // 
            this.gameTable.AllowUserToAddRows = false;
            this.gameTable.AllowUserToDeleteRows = false;
            this.gameTable.AllowUserToResizeColumns = false;
            this.gameTable.AllowUserToResizeRows = false;
            this.gameTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameTable.BackgroundColor = System.Drawing.Color.White;
            this.gameTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.gameTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gameTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gameTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCell,
            this.dateCell,
            this.countCell});
            this.gameTable.EnableHeadersVisualStyles = false;
            this.gameTable.GridColor = System.Drawing.Color.Gainsboro;
            this.gameTable.Location = new System.Drawing.Point(12, 84);
            this.gameTable.MultiSelect = false;
            this.gameTable.Name = "gameTable";
            this.gameTable.ReadOnly = true;
            this.gameTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gameTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gameTable.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 10F);
            this.gameTable.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gameTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gameTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.gameTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gameTable.RowTemplate.Height = 50;
            this.gameTable.RowTemplate.ReadOnly = true;
            this.gameTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gameTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gameTable.Size = new System.Drawing.Size(875, 419);
            this.gameTable.TabIndex = 1;
            this.gameTable.DoubleClick += new System.EventHandler(this.gameTable_DoubleClick);
            // 
            // nameCell
            // 
            this.nameCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nameCell.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameCell.HeaderText = "Название игры";
            this.nameCell.MinimumWidth = 160;
            this.nameCell.Name = "nameCell";
            this.nameCell.ReadOnly = true;
            this.nameCell.Width = 160;
            // 
            // dateCell
            // 
            this.dateCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dateCell.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateCell.HeaderText = "Дата проведения";
            this.dateCell.MinimumWidth = 160;
            this.dateCell.Name = "dateCell";
            this.dateCell.ReadOnly = true;
            this.dateCell.Width = 160;
            // 
            // countCell
            // 
            this.countCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.countCell.DefaultCellStyle = dataGridViewCellStyle4;
            this.countCell.HeaderText = "Количество игроков";
            this.countCell.MinimumWidth = 160;
            this.countCell.Name = "countCell";
            this.countCell.ReadOnly = true;
            this.countCell.Width = 178;
            // 
            // panelDetailGame
            // 
            this.panelDetailGame.BackColor = System.Drawing.Color.DimGray;
            this.panelDetailGame.Location = new System.Drawing.Point(839, 31);
            this.panelDetailGame.Name = "panelDetailGame";
            this.panelDetailGame.Size = new System.Drawing.Size(36, 34);
            this.panelDetailGame.TabIndex = 2;
            this.panelDetailGame.Visible = false;
            // 
            // GameWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 515);
            this.Controls.Add(this.panelDetailGame);
            this.Controls.Add(this.gameTable);
            this.Controls.Add(this.gamesLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameWidget";
            this.Text = "GameWidget";
            ((System.ComponentModel.ISupportInitialize)(this.gameTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gamesLabel;
        private System.Windows.Forms.DataGridView gameTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCell;
        private System.Windows.Forms.Panel panelDetailGame;
    }
}