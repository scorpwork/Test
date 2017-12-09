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

        public DetailGame(Game game)
        {
            this.game = game;
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
            Player player = (Player)detailTable.CurrentRow.Tag;
            int col = detailTable.CurrentCell.ColumnIndex;
            if (col!=0)
            {
                KeyValidation(e);
            }
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

        private void detailTable_Click(object sender, EventArgs e)
        {
            /*if (detailTable.CurrentRow.Cells[0].Tag == "Team")
            {
                List<DataGridViewRow> players = new List<DataGridViewRow>();
                int iterator = detailTable.CurrentRow.Index + 1;
                while (detailTable.Rows[iterator].Tag != null)
                {
                    players.Add(detailTable.Rows[iterator]);
                    iterator++;
                }
                DataGridViewRow buf;
                for (int iSort = 0; iSort < players.Count - 1; iSort++)
                {
                    for (int jSort = 0; jSort < players.Count - 1; jSort++)
                    {
                        if (players[jSort].Cells[0].Value.ToString().CompareTo(
                                players[jSort+1].Cells[0].Value.ToString()) == 1)
                        {
                            buf = players[jSort];
                            players[jSort] = players[jSort+1];
                            players[jSort + 1] = buf;
                        }
                    }
                }
                iterator = detailTable.CurrentRow.Index + 1;
                while (detailTable.Rows[iterator].Tag != null)
                {
                    detailTable.Rows[iterator].Cells[0].Value = players[iterator].Cells[0].Value;
                    detailTable.Rows[iterator].Cells[1].Value = players[iterator].Cells[1].Value;
                    detailTable.Rows[iterator].Cells[2].Value = players[iterator].Cells[2].Value;
                    detailTable.Rows[iterator].Cells[3].Value = players[iterator].Cells[3].Value;
                    iterator++;
                }
                //players.Sort(players.C);
                //detailTable.Sort(detailTable.Columns[0], ListSortDirection.Ascending);
            }*/
        }

        private void detailTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
    }
}
