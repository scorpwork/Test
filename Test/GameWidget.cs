using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class GameWidget : Form
    {
        public GameWidget()
        {
            InitializeComponent();
            if (ObjectsContainer.GetData() != null)
            {
                PrepareGameTable();
            }
        }

        /// <summary>
        /// Подготовка таблицы игр
        /// </summary>
        private void PrepareGameTable()
        {
            ObjectsContainer data = ObjectsContainer.GetData();
            gameTable.Rows.Clear();
            int iterator = 0;
            foreach (Game game in data.games)
            {
                gameTable.Rows.Add();
                gameTable.Rows[iterator].Cells[0].Value = game.name;
                gameTable.Rows[iterator].Cells[1].Value = game.date;
                gameTable.Rows[iterator].Cells[2].Value = GetPlayersCount(game).ToString();
                iterator++;
            }
        }

        /// <summary>
        /// Метод получения числа игроков
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>число игроков</returns>
        private int GetPlayersCount(Game game)
        {
            int count = 0;
            foreach (Team team in game.teams)
            {
                count += team.players.Count();
            }
            return count;
        }

        /// <summary>
        /// Обработка кнопки "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailForm_Closed(object sender, FormClosedEventArgs e)
        {
            panelDetailGame.Visible = false;
        }

        /// <summary>
        /// Детализация игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTable_DoubleClick(object sender, EventArgs e)
        {
            panelDetailGame.Dock = System.Windows.Forms.DockStyle.Fill;
            DetailGame detailForm = new DetailGame(ObjectsContainer.GetData().games[gameTable.CurrentRow.Index]);
            detailForm.TopLevel = false;
            detailForm.Parent = panelDetailGame;
            detailForm.Dock = System.Windows.Forms.DockStyle.Fill;
            detailForm.FormClosed += detailForm_Closed;
            panelDetailGame.Visible = true;
            detailForm.Show();
        }
    }
}
