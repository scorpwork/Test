﻿namespace Test
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundWidget));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SoundLabel = new System.Windows.Forms.Label();
            this.soundTable = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wmpTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewProgressColumn1 = new Test.DataGridViewProgressColumn();
            this.dgMusicProgressColumn1 = new Test.DGMusicProgressColumn();
            this.downloadCol = new Test.DataGridViewProgressColumn();
            this.playCol = new Test.DGMusicProgressColumn();
            ((System.ComponentModel.ISupportInitialize)(this.soundTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SoundLabel
            // 
            this.SoundLabel.AutoSize = true;
            this.SoundLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SoundLabel.Location = new System.Drawing.Point(30, 31);
            this.SoundLabel.MinimumSize = new System.Drawing.Size(0, 50);
            this.SoundLabel.Name = "SoundLabel";
            this.SoundLabel.Size = new System.Drawing.Size(84, 50);
            this.SoundLabel.TabIndex = 0;
            this.SoundLabel.Text = "ЗВУКИ";
            // 
            // soundTable
            // 
            this.soundTable.AllowUserToAddRows = false;
            this.soundTable.AllowUserToDeleteRows = false;
            this.soundTable.AllowUserToResizeColumns = false;
            this.soundTable.AllowUserToResizeRows = false;
            this.soundTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.soundTable.BackgroundColor = System.Drawing.Color.White;
            this.soundTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soundTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.soundTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.soundTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.soundTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.soundTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.sizeCol,
            this.downloadCol,
            this.playCol});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.soundTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.soundTable.EnableHeadersVisualStyles = false;
            this.soundTable.GridColor = System.Drawing.Color.Gainsboro;
            this.soundTable.Location = new System.Drawing.Point(12, 84);
            this.soundTable.MultiSelect = false;
            this.soundTable.Name = "soundTable";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.soundTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.soundTable.RowHeadersVisible = false;
            this.soundTable.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.soundTable.RowTemplate.Height = 40;
            this.soundTable.RowTemplate.ReadOnly = true;
            this.soundTable.Size = new System.Drawing.Size(601, 356);
            this.soundTable.TabIndex = 1;
            this.soundTable.Click += new System.EventHandler(this.soundTable_Click);
            // 
            // nameCol
            // 
            this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nameCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameCol.HeaderText = "Имя файла";
            this.nameCol.MinimumWidth = 160;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 160;
            // 
            // sizeCol
            // 
            this.sizeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sizeCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.sizeCol.HeaderText = "Размер Файла";
            this.sizeCol.MinimumWidth = 160;
            this.sizeCol.Name = "sizeCol";
            this.sizeCol.ReadOnly = true;
            this.sizeCol.Width = 160;
            // 
            // wmpTimer
            // 
            this.wmpTimer.Tick += new System.EventHandler(this.wmpTimer_Tick);
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle8.NullValue")));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProgressColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewProgressColumn1.HeaderText = "Загрузка файла";
            this.dataGridViewProgressColumn1.MinimumWidth = 100;
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.ReadOnly = true;
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewProgressColumn1.Width = 142;
            // 
            // dgMusicProgressColumn1
            // 
            this.dgMusicProgressColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle9.NullValue")));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMusicProgressColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgMusicProgressColumn1.HeaderText = "Воспроизвести";
            this.dgMusicProgressColumn1.Name = "dgMusicProgressColumn1";
            this.dgMusicProgressColumn1.ReadOnly = true;
            this.dgMusicProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMusicProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgMusicProgressColumn1.Width = 141;
            // 
            // downloadCol
            // 
            this.downloadCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.downloadCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.downloadCol.HeaderText = "Загрузка файла";
            this.downloadCol.MinimumWidth = 100;
            this.downloadCol.Name = "downloadCol";
            this.downloadCol.ReadOnly = true;
            this.downloadCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.downloadCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.downloadCol.Width = 142;
            // 
            // playCol
            // 
            this.playCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.playCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.playCol.HeaderText = "Воспроизвести";
            this.playCol.Name = "playCol";
            this.playCol.ReadOnly = true;
            this.playCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.playCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.playCol.Width = 141;
            // 
            // SoundWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 452);
            this.Controls.Add(this.soundTable);
            this.Controls.Add(this.SoundLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SoundWidget";
            this.Text = "SoundWidget";
            ((System.ComponentModel.ISupportInitialize)(this.soundTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SoundLabel;
        private System.Windows.Forms.DataGridView soundTable;
        private System.Windows.Forms.Timer wmpTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeCol;
        private DataGridViewProgressColumn downloadCol;
        private DGMusicProgressColumn playCol;
        private DataGridViewProgressColumn dataGridViewProgressColumn1;
        private DGMusicProgressColumn dgMusicProgressColumn1;
    }
}