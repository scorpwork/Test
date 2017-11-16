namespace Test
{
    partial class DetailGame
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.detailLabel = new System.Windows.Forms.Label();
            this.detailTable = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.playerCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accuracyCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shotsCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).BeginInit();
            this.SuspendLayout();
            // 
            // detailLabel
            // 
            this.detailLabel.AutoSize = true;
            this.detailLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailLabel.Location = new System.Drawing.Point(41, 13);
            this.detailLabel.MinimumSize = new System.Drawing.Size(0, 50);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(68, 50);
            this.detailLabel.TabIndex = 0;
            this.detailLabel.Text = "ИГРА";
            // 
            // detailTable
            // 
            this.detailTable.AllowUserToAddRows = false;
            this.detailTable.AllowUserToDeleteRows = false;
            this.detailTable.AllowUserToResizeColumns = false;
            this.detailTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.detailTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailTable.BackgroundColor = System.Drawing.Color.White;
            this.detailTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.detailTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.detailTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerCell,
            this.ratingCell,
            this.accuracyCell,
            this.shotsCell});
            this.detailTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.detailTable.EnableHeadersVisualStyles = false;
            this.detailTable.GridColor = System.Drawing.Color.Gainsboro;
            this.detailTable.Location = new System.Drawing.Point(13, 66);
            this.detailTable.MultiSelect = false;
            this.detailTable.Name = "detailTable";
            this.detailTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.detailTable.RowHeadersVisible = false;
            this.detailTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.detailTable.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailTable.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.detailTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.detailTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.detailTable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailTable.RowTemplate.Height = 50;
            this.detailTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.detailTable.Size = new System.Drawing.Size(657, 385);
            this.detailTable.TabIndex = 2;
            this.detailTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailTable_CellEndEdit);
            this.detailTable.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.detailTable_EditingControlShowing);
            this.detailTable.DoubleClick += new System.EventHandler(this.detailTable_DoubleClick);
            this.detailTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detailTable_KeyPress);
            // 
            // backButton
            // 
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = global::Test.Properties.Resources.back;
            this.backButton.Location = new System.Drawing.Point(13, 13);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(22, 23);
            this.backButton.TabIndex = 1;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // playerCell
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.playerCell.DefaultCellStyle = dataGridViewCellStyle3;
            this.playerCell.HeaderText = "Игрок";
            this.playerCell.MinimumWidth = 160;
            this.playerCell.Name = "playerCell";
            this.playerCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.playerCell.Width = 160;
            // 
            // ratingCell
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ratingCell.DefaultCellStyle = dataGridViewCellStyle4;
            this.ratingCell.HeaderText = "Рейтинг";
            this.ratingCell.MinimumWidth = 160;
            this.ratingCell.Name = "ratingCell";
            this.ratingCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ratingCell.Width = 160;
            // 
            // accuracyCell
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.accuracyCell.DefaultCellStyle = dataGridViewCellStyle5;
            this.accuracyCell.HeaderText = "Точность";
            this.accuracyCell.MinimumWidth = 160;
            this.accuracyCell.Name = "accuracyCell";
            this.accuracyCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.accuracyCell.Width = 160;
            // 
            // shotsCell
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shotsCell.DefaultCellStyle = dataGridViewCellStyle6;
            this.shotsCell.HeaderText = "Выстрелы";
            this.shotsCell.MinimumWidth = 160;
            this.shotsCell.Name = "shotsCell";
            this.shotsCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shotsCell.Width = 160;
            // 
            // DetailGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 463);
            this.Controls.Add(this.detailTable);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.detailLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetailGame";
            this.Text = "DetailGame";
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridView detailTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn accuracyCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn shotsCell;
    }
}