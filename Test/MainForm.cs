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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeDB();
            LoadData();
        }

        public static ObjectsContainer LoadData()
        {
            //В разработке
            ObjectsContainer obj = new ObjectsContainer();
            List<Game> games = Game.Load();
            List<Sound> sounds = Sound.Load();
            obj.games = games;
            obj.sounds = sounds;
            return obj;
        }

        /// <summary>
        /// Инициализация БД
        /// </summary>
        private void InitializeDB()
        {
            DBWork dbWork = new DBWork();
            dbWork.Connection();
            dbWork.CreateTables();
        }

        /// <summary>
        /// Метод отображения форм
        /// </summary>
        /// <param name="showDownload">показывать форму загрузки</param>
        /// <param name="showSound">показывать форму музыки</param>
        /// <param name="showGames">показывать форму игр</param>
        private void PanelsVisible(bool showDownload, bool showSound, bool showGames)
        {
            this.panelDownload.Visible = showDownload;
            this.panelSounds.Visible = showSound;
            this.panelGames.Visible = showGames;
        }

        /// <summary>
        /// Инициализация форм
        /// </summary>
        /// <param name="form">Объект формы</param>
        /// <param name="panel">Объект панели</param>
        private void FormLoad(Form form, Panel panel)
        {
            form.TopLevel = false;
            form.Parent = panel;
            form.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Show();
        }

        /// <summary>
        /// Открытие вкладки загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadRb_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PanelsVisible(true, false, false);
            DownloadWidget downloadWidget = new DownloadWidget();
            FormLoad(downloadWidget, this.panelDownload);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Открытие вкладки музыки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundRb_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PanelsVisible(false, true, false);
            SoundWidget soundWidget = new SoundWidget();
            FormLoad(soundWidget, this.panelSounds);            
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Открытие вкладки музыки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamesRb_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PanelsVisible(false, false, true);
            GameWidget gameWidget = new GameWidget();
            FormLoad(gameWidget, this.panelGames);
            Cursor.Current = Cursors.Default;            
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Выйти из программы?", "Предупреждение", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Application.Exit();
                }                    
            }
        }
    }
}
