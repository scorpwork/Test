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
    public partial class PlayerEditor : Form
    {
        private Player player { get; set; }

        public PlayerEditor(Player editoredPlayer)
        {
            player = editoredPlayer;
            InitializeComponent();
            Load(player);
        }

        /// <summary>
        /// Обработка кнопки "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Загрузка редактируемых данных
        /// </summary>
        /// <param name="player"></param>
        private void Load(Player player)
        {
            nameTextBox.Text = player.name;
            accuracyTextBox.Text = (player.accuracy * 100).ToString()+ "%";
            ratingTextBox.Text = player.rating.ToString();
            shotsTextBox.Text = player.shots.ToString();
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {}

        private void ratingTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyValidation(e);
        }

        private void accuracyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyValidation(e);
        }

        private void shotsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyValidation(e);
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
        /// Обработка кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBt_Click(object sender, EventArgs e)
        {
            if (SaveName() && SaveRating() && SaveAccuracy() && SaveShots())
            {
                this.Close();
            }
        }

        /// <summary>
        /// Сохранение имени
        /// </summary>
        /// <returns></returns>
        private bool SaveName()
        {
            if (nameTextBox.Text != "")
            {
                player.name = nameTextBox.Text;
                player.Update(player.id, "name", player.name, player.team);
                DetailGame.UpdatePlayerData(player, "name");
            }
            else
            {
                //MessageBox.Show("Предупреждение", "Введите имя игрока");
                Msg.Show(this, "Предупреждение", "Введите имя игрока");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Сохранение рейтинга
        /// </summary>
        /// <returns></returns>
        private bool SaveRating()
        {
            if (ratingTextBox.Text != "")
            {
                player.rating = Convert.ToInt32(ratingTextBox.Text.ToString());
                player.Update(player.id, "rating", player.rating.ToString(), player.team);
                DetailGame.UpdatePlayerData(player, "rating");
            }
            else
            {
                //MessageBox.Show("Предупреждение", "Введите рейтинг игрока");
                Msg.Show(this, "Предупреждение", "Введите рейтинг игрока");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Сохранение точности
        /// </summary>
        /// <returns></returns>
        private bool SaveAccuracy()
        {
            if (accuracyTextBox.Text != "")
            {
                string acStr = accuracyTextBox.Text;
                if (acStr.IndexOf("%") >= 0)
                {
                    acStr = acStr.Remove(acStr.IndexOf("%"), 1);
                }
                double accuracy = Convert.ToInt32(acStr) / 100.0;
                if (accuracy > 1)
                {
                    accuracy = 1;
                }
                player.accuracy = accuracy;
                player.Update(player.id, "accuracy", player.accuracy.ToString(), player.team);
            }
            else
            {
                //MessageBox.Show("Предупреждение", "Введите точность игрока");
                Msg.Show(this, "Предупреждение", "Введите точность игрока");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Сохранение количества выстрелов
        /// </summary>
        /// <returns></returns>
        private bool SaveShots()
        {
            if (shotsTextBox.Text != "")
            {
                player.shots = Convert.ToInt32(shotsTextBox.Text);
                player.Update(player.id, "shots", player.shots.ToString(), player.team);
            }
            else
            {
                //MessageBox.Show("Предупреждение", "Введите количество выстрелов игрока");
                Msg.Show(this, "Предупреждение", "Введите количество выстрелов игрока");
                return false;
            }
            return true;
        }
    }
}
