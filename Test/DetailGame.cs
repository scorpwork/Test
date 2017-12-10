using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Test
{
    public partial class DetailGame : Form
    {
        private Game game { get; set; }
        private bool sortASC { get; set; }

        public DetailGame(Game game)
        {
            this.game = game;
            sortASC = true;
            InitializeComponent();
            detailLabel.Text = this.game.name;
            PrepareDetailTable();
        }

        /// <summary>
        /// Кнопка "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Подготовка таблицы игроков
        /// </summary>
        private void PrepareDetailTable()
        {
            detailTable.Rows.Clear();
            int teamIterator = 0;
            System.Windows.Forms.DataGridViewCellStyle teamStyle = new System.Windows.Forms.DataGridViewCellStyle();
            teamStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            System.Windows.Forms.DataGridViewCellStyle playerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            playerStyle.Font = new System.Drawing.Font("Arial", 10F);
            foreach (Team team in this.game.teams)
            {
                detailTable.Rows.Add();
                detailTable.Rows[teamIterator].DefaultCellStyle = teamStyle;
                detailTable.Rows[teamIterator].Cells[0].Value = team.name;
                detailTable.Rows[teamIterator].Cells[0].Tag = "Team";
                detailTable.Rows[teamIterator].Tag = team;
                detailTable.Rows[teamIterator].ReadOnly = true;
                int playerIterator = 0;
                foreach (Player player in team.players)
                {
                    detailTable.Rows.Add();
                    detailTable.Rows[playerIterator+teamIterator+1].DefaultCellStyle = playerStyle;
                    detailTable.Rows[playerIterator + teamIterator + 1].Cells[0].Value = player.name;
                    detailTable.Rows[playerIterator + teamIterator + 1].Cells[1].Value = player.rating.ToString();
                    detailTable.Rows[playerIterator + teamIterator + 1].Cells[2].Value = (player.accuracy * 100).ToString()+"%";
                    detailTable.Rows[playerIterator + teamIterator + 1].Cells[3].Value = player.shots.ToString();
                    detailTable.Rows[playerIterator + teamIterator + 1].Tag = player;
                    playerIterator++;
                }
                teamIterator = teamIterator + playerIterator + 1;
            }
        }

        /// <summary>
        /// Завершение редактирования ячейки таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (detailTable.CurrentRow.Tag != null)
            {
                Player player = (Player)detailTable.CurrentRow.Tag;
                int col = detailTable.CurrentCell.ColumnIndex;
                switch (col)
                {
                    case 0:
                        SaveName(player);
                        break;
                    case 1:
                        SaveRating(player);
                        break;
                    case 2:
                        SaveAccuracy(player);
                        break;
                    case 3:
                        SaveShots(player);
                        break;
                }
            }
        }

        /// <summary>
        /// Обновление структуры данных
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <param name="what">Тип обновляемых данных</param>
        //private void UpdatePlayerData(Player player, string what)
        public static void UpdatePlayerData(Player player, string what)
        {
            foreach(Game game in ObjectsContainer.GetData().games)
            {
                foreach(Team team in game.teams)
                {
                    foreach(Player curPlayer in team.players)
                    {
                        if (curPlayer.id == player.id)
                        {
                            if (what == "name")
                            {
                                curPlayer.name = player.name;
                            }
                            if (what == "rating")
                            {
                                curPlayer.rating = player.rating;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// метод сохранения имени
        /// </summary>
        /// <param name="player">Игрок</param>
        private void SaveName(Player player)
        {
            if (detailTable.CurrentCell.Value != null)
            {
                player.name = detailTable.CurrentCell.Value.ToString();
                player.Update(player.id, "name", player.name, player.team);
                UpdatePlayerData(player,"name");
            }
        }

        /// <summary>
        /// Метод сохранения уровня
        /// </summary>
        /// <param name="player">Игрок</param>
        private void SaveRating(Player player)
        {
            if (detailTable.CurrentCell.Value != null)
            {
                player.rating = Convert.ToInt32(detailTable.CurrentCell.Value.ToString());
                player.Update(player.id, "rating", player.rating.ToString(), player.team);
                UpdatePlayerData(player, "rating");
            }
        }

        /// <summary>
        /// Метод сохранения точности
        /// </summary>
        /// <param name="player">Игрок</param>
        private void SaveAccuracy(Player player)
        {
            if (detailTable.CurrentCell.Value != null)
            {
                string acStr = detailTable.CurrentCell.Value.ToString();
                if (acStr.IndexOf("%") >= 0)
                {
                    acStr = acStr.Remove(acStr.IndexOf("%"), 1);
                }
                double accuracy = Convert.ToInt32(acStr)/100.0;
                if (accuracy > 1)
                {
                    accuracy = 1;
                }
                player.accuracy = accuracy;
                player.Update(player.id, "accuracy", player.accuracy.ToString(),player.team);
            }
        }

        /// <summary>
        /// Метод сохранения выстрелов
        /// </summary>
        /// <param name="player">Игрок</param>
        private void SaveShots(Player player)
        {
            if (detailTable.CurrentCell.Value != null)
            {
                player.shots = Convert.ToInt32(detailTable.CurrentCell.Value.ToString());
                player.Update(player.id, "shots", player.shots.ToString(), player.team);
            }
        }

        /// <summary>
        /// Обработка корректности ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Player player = (Player)detailTable.CurrentRow.Tag;
                int col = detailTable.CurrentCell.ColumnIndex;
                if (col != 0)
                {
                    KeyValidation(e);
                }
            }
            catch { }
        }

        /// <summary>
        /// Валидация ввода
        /// </summary>
        /// <param name="e"></param>
        private void KeyValidation(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработка корректности ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (detailTable.CurrentRow.Tag != null)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(detailTable_KeyPress);
            }
        }

        /// <summary>
        /// Вызов формы редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailTable_DoubleClick(object sender, EventArgs e)
        {
            if (detailTable.CurrentRow.Tag != null)
            {
                try
                {
                    Validate();
                    detailTable.Update();
                    detailTable.EndEdit();
                    Player player = (Player)detailTable.CurrentRow.Tag;
                    int col = detailTable.CurrentCell.ColumnIndex;
                    TransparentForm.Get().Show();
                    PlayerEditor editor = new PlayerEditor(player);
                    editor.FormClosed += editor_Closed;
                    editor.ShowDialog();
                }
                catch
                {}
                
            }
        }

        /// <summary>
        /// Закрытие формы редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editor_Closed(object sender, FormClosedEventArgs e)
        {
            TransparentForm.parent = this;
            TransparentForm.Get().Close();
            TransparentForm.Get().Delete();
            UpdateDetailTableRow();
            this.Activate();
        }

        /// <summary>
        /// Обновление строки таблицы
        /// </summary>
        private void UpdateDetailTableRow()
        {
            Player player = (Player)detailTable.CurrentRow.Tag;
            int index = detailTable.CurrentRow.Index;
            detailTable.Rows[index].Cells[0].Value = player.name;
            detailTable.Rows[index].Cells[1].Value = player.rating.ToString();
            detailTable.Rows[index].Cells[2].Value = (player.accuracy * 100).ToString() + "%";
            detailTable.Rows[index].Cells[3].Value = player.shots.ToString();
            detailTable.Rows[index].Tag = player;            
        }

        /// <summary>
        /// Обработчик кнопки ВК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveVK_Click(object sender, EventArgs e)
        {
            VK vk = new VK();
            //TransparentForm.parent = this;
            TransparentForm.Get().Show();
            vk.ShowDialog();
        }

        /// <summary>
        /// Обработчик кнопки PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePDF_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PDFWork pdf = new PDFWork();
            pdf.CreatePDF(game, detailTable);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Ручная сортировка строк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailTable_Click(object sender, EventArgs e)
        {
            if (detailTable.CurrentRow.Cells[0].Tag == "Team")
            {
                bool visibility;
                int rowIterator = detailTable.CurrentRow.Index + 1;
                if (detailTable.Rows[rowIterator].Visible == true)
                {
                    visibility = false;
                }
                else
                {
                    visibility = true;
                }
                HidibleTeamRows(visibility);
            }
                //Вариант сортировки по нажатии на команду
                /*if (detailTable.CurrentRow.Cells[0].Tag == "Team")
                {
                    Team team = (Team)detailTable.CurrentRow.Tag;
                    Player buf;
                    for (int iSort = 0; iSort < team.players.Count - 1; iSort++)
                    {
                        for (int jSort = 0; jSort < team.players.Count - 1; jSort++)
                        {
                            if (team.players[jSort].name.CompareTo(
                                    team.players[jSort + 1].name) == 1)
                            {
                                buf = team.players[jSort];
                                team.players[jSort] = team.players[jSort + 1];
                                team.players[jSort + 1] = buf;
                            }
                        }
                    }

                    int rowIterator = detailTable.CurrentRow.Index + 1;
                    int playerIterator = 0;
                    while (detailTable.Rows[rowIterator].Tag != null && detailTable.Rows[rowIterator].Cells[0].Tag != "Team")
                    {
                        detailTable.Rows.RemoveAt(rowIterator);
                        detailTable.Rows.Insert(rowIterator);
                        detailTable.Rows[rowIterator].Tag = team.players[playerIterator];
                        System.Windows.Forms.DataGridViewCellStyle playerStyle = new System.Windows.Forms.DataGridViewCellStyle();
                        playerStyle.Font = new System.Drawing.Font("Arial", 10F);
                        detailTable.Rows[rowIterator].DefaultCellStyle = playerStyle;
                        detailTable[0, rowIterator].Value = team.players[playerIterator].name;
                        detailTable[1, rowIterator].Value = team.players[playerIterator].rating.ToString();
                        detailTable[2, rowIterator].Value = (team.players[playerIterator].accuracy * 100).ToString() + "%"; ;
                        detailTable[3, rowIterator].Value = team.players[playerIterator].shots.ToString();
                        rowIterator++;
                        playerIterator++;
                        if (rowIterator >= detailTable.RowCount)
                        {
                            return;
                        }
                    }
                }*/
            }

        private void HidibleTeamRows(bool visible)
        {
            int rowIterator = detailTable.CurrentRow.Index + 1;
            int playerIterator = 0;
            while (detailTable.Rows[rowIterator].Tag != null && detailTable.Rows[rowIterator].Cells[0].Tag != "Team")
            {
                detailTable.Rows[rowIterator].Visible = visible;
                rowIterator++;
                playerIterator++; if (rowIterator >= detailTable.RowCount)
                {
                    return;
                }
            }
        }

        private void detailTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (detailTable.Columns[e.ColumnIndex].HeaderText == "Рейтинг")
            {
                foreach (Team team in this.game.teams)
                {
                    SortTeam(team);
                    int rowIterator = GetTeamRow(team) + 1;
                    int playerIterator = 0;
                    while (detailTable.Rows[rowIterator].Tag != null && detailTable.Rows[rowIterator].Cells[0].Tag != "Team")
                    {
                        detailTable.Rows.RemoveAt(rowIterator);
                        detailTable.Rows.Insert(rowIterator);
                        try
                        {
                            detailTable.Rows[rowIterator].Tag = team.players[playerIterator];
                        }
                        catch
                        {
                            sortASC = !sortASC;
                            return;
                        }
                        System.Windows.Forms.DataGridViewCellStyle playerStyle = new System.Windows.Forms.DataGridViewCellStyle();
                        playerStyle.Font = new System.Drawing.Font("Arial", 10F);
                        detailTable.Rows[rowIterator].DefaultCellStyle = playerStyle;
                        detailTable[0, rowIterator].Value = team.players[playerIterator].name;
                        detailTable[1, rowIterator].Value = team.players[playerIterator].rating.ToString();
                        detailTable[2, rowIterator].Value = (team.players[playerIterator].accuracy * 100).ToString() + "%"; ;
                        detailTable[3, rowIterator].Value = team.players[playerIterator].shots.ToString();
                        rowIterator++;
                        playerIterator++;
                        if (rowIterator >= detailTable.RowCount)
                        {
                            sortASC = !sortASC;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка команд
        /// </summary>
        /// <param name="team"></param>
        private void SortTeam(Team team)
        {
            Player buf;
            for (int iSort = 0; iSort < team.players.Count - 1; iSort++)
            {
                for (int jSort = 0; jSort < team.players.Count - 1; jSort++)
                {
                    if (sortASC)
                    {
                        if (team.players[jSort].rating > team.players[jSort + 1].rating)
                        {
                            buf = team.players[jSort];
                            team.players[jSort] = team.players[jSort + 1];
                            team.players[jSort + 1] = buf;
                        }
                    }
                    else
                    {
                        if (team.players[jSort].rating < team.players[jSort + 1].rating)
                        {
                            buf = team.players[jSort];
                            team.players[jSort] = team.players[jSort + 1];
                            team.players[jSort + 1] = buf;
                        }
                    }
                    
                }
            }
        }

        private int GetTeamRow(Team team)
        {
            for (int iRow = 0; iRow < detailTable.RowCount; iRow++)
            {
                if (detailTable.Rows[iRow].Tag == team)
                {
                    return iRow;
                }
            }
            return 0;
        }

        private void detailTable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex == -1)
            {                
                float posX = e.CellBounds.X;
                float posY = e.CellBounds.Y;
                Brush foreColorBrush = new SolidBrush(Color.Black);
                System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
                style.Font = new System.Drawing.Font("Arial", 10F, FontStyle.Bold);
                e.Graphics.DrawString(e.Value.ToString(), style.Font, foreColorBrush, posX, posY);
                float textWidth = TextRenderer.MeasureText(e.Value.ToString(), style.Font).Width;
                e.Graphics.DrawImage(Properties.Resources.sort, posX+textWidth, posY);
                e.Handled = true;
            }
            /*if (e.RowIndex>=0)
            {
                if (e.ColumnIndex == 0 && detailTable[e.ColumnIndex, e.RowIndex].Tag == "Team")
                {
                    System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
                    style.Font = new System.Drawing.Font("Arial", 14F, FontStyle.Bold);
                    float textHeight = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font).Height;
                    float posX = e.CellBounds.X;
                    float posY = e.CellBounds.Y + e.CellBounds.Height - 30;// - textHeight;
                    Brush foreColorBrush = new SolidBrush(Color.Black);
                    
                    e.Graphics.DrawString(e.Value.ToString(), style.Font, foreColorBrush, posX, posY);
                    float textWidth = TextRenderer.MeasureText(e.Value.ToString(), style.Font).Width;
                    e.Graphics.DrawImage(Properties.Resources.hide_show, posX + textWidth, posY);
                    e.Handled = true;
                }
            }*/
        }
    }
}
