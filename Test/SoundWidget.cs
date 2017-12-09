using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;

namespace Test
{
    public partial class SoundWidget : Form
    {
        static private WindowsMediaPlayer wmp;
        private int currentPlayingRow { get; set; }
        public SoundWidget()
        {
            InitializeComponent();
            currentPlayingRow = -1;
            if (ObjectsContainer.GetData() != null)
            {
                PrepareSoundTable();
            }
        }

        /// <summary>
        /// Подготовка таблицы с музыкой
        /// </summary>
        private void PrepareSoundTable()
        {
            ObjectsContainer data = ObjectsContainer.GetData();
            List<string> soundFiles = Directory.GetFiles(@"download", "*.wav").ToList<string>();
            soundTable.Rows.Clear();
            int iterator = 0;
            foreach (Sound sound in data.sounds)
            {
                soundTable.Rows.Add();
                soundTable.Rows[iterator].Cells[0].Value = sound.name;
                soundTable.Rows[iterator].Cells[1].Value = GetCorrectSize(sound.size);
                soundTable.Rows[iterator].Cells[2].Value = 0;
                //SetCellIcon(iterator, 2, Properties.Resources.download_sound);
                bool findFile = false;
                foreach (string doc in soundFiles)
                {
                    string file = doc.Remove(0, doc.IndexOf("\\") + 1).ToString();
                    if (sound.name + ".wav" == file)
                    {
                        SetCellIcon(iterator, 3, Properties.Resources.play);
                        soundTable.Rows[iterator].Cells[2].Value = -1;
                        //SetCellIcon(iterator, 2, Properties.Resources.downloaded_sound);
                        soundTable.Rows[iterator].Tag = true;
                        findFile = true;
                        break;
                    }
                }
                if (!findFile)
                {
                    SetCellIcon(iterator, 3, Properties.Resources.play_disabled);
                    soundTable.Rows[iterator].Tag = false;
                }
                iterator++;
            }
        }

        /// <summary>
        /// Формирование читаемой строки размера файла
        /// </summary>
        /// <param name="size">размер файла</param>
        /// <returns>Строка с размером</returns>
        private string GetCorrectSize(int size)
        {
            int modSize = size / 1024;
            if (modSize == 0)
            {
                return size.ToString() + " b";
            }
            if (modSize > 1024)
            {
                return (modSize / 1024).ToString() + " Mb";
            }
            return modSize.ToString() + " Kb";
        }

        /// <summary>
        /// Установить Иконку для ячейки
        /// </summary>
        /// <param name="row">строка</param>
        /// <param name="col">столбец</param>
        /// <param name="bitMap">иконка</param>
        private void SetCellIcon(int row, int col, Bitmap bitMap)
        {
            Bitmap icon = bitMap;
            soundTable[col, row].Value = icon;
        }

        /// <summary>
        /// Обработка нажатия на ячейки таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundTable_Click(object sender, EventArgs e)
        {
            if (ObjectsContainer.GetData() == null)
            {
                return;
            }
            if (soundTable.CurrentCell.ColumnIndex == 2)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DownloadSound(GetCurrentSound());
                    Cursor.Current = Cursors.Default;
                }
                catch
                { }
            }
            if (soundTable.CurrentCell.ColumnIndex == 3)
            {
                try
                {
                    bool isDownload = (bool)soundTable.CurrentRow.Tag;
                    if (isDownload)
                    {
                        if (currentPlayingRow != soundTable.CurrentRow.Index)
                        {
                            currentPlayingRow = soundTable.CurrentRow.Index;
                            PlaySoundWMP(GetCurrentSound());
                            return;
                        }

                        WMPPlayState playState = GetWMP().playState;
                        if (GetWMP().playState == WMPLib.WMPPlayState.wmppsStopped ||
                            GetWMP().playState == WMPLib.WMPPlayState.wmppsMediaEnded ||
                            GetWMP().playState == WMPLib.WMPPlayState.wmppsUndefined)
                        {
                            currentPlayingRow = soundTable.CurrentRow.Index;
                            PlaySoundWMP(GetCurrentSound());
                        }
                        if ((GetWMP().playState == WMPLib.WMPPlayState.wmppsPaused) ||
                            (GetWMP().playState == WMPLib.WMPPlayState.wmppsReady))
                        {
                            GetWMP().controls.play();
                            currentPlayingRow = soundTable.CurrentRow.Index;
                            return;
                        }
                        if ((GetWMP().playState == WMPLib.WMPPlayState.wmppsPlaying))
                        {
                            GetWMP().controls.pause();
                        }
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Получить объект выбранной композиции
        /// </summary>
        /// <returns>Объект композиции</returns>
        private Sound GetCurrentSound()
        {
            int soundNum = soundTable.CurrentRow.Index;
            return ObjectsContainer.GetData().sounds[soundNum]; ;
        }

        /// <summary>
        /// Метод загрузки 
        /// </summary>
        /// <param name="sound">Объект композиции</param>
        private void DownloadSound(Sound sound)
        {
            SetCellIcon(soundTable.CurrentRow.Index, 2, Properties.Resources.downloading_sound);
            soundTable.ClearSelection();
            this.Refresh();
            WebClient client = new WebClient();
            client.DownloadProgressChanged += OnDownloadProgressChanged;
            client.DownloadFileCompleted += OnDownloadComplete;
            client.DownloadFileAsync(new Uri(sound.url), AppDomain.CurrentDomain.BaseDirectory + "\\download\\" + sound.name + ".wav");
        }

        /// <summary>
        /// Процесс загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            int value = int.Parse(Math.Truncate(percentage).ToString());
            soundTable.Rows[soundTable.CurrentRow.Index].Cells[2].Value = value;
            soundTable.ClearSelection();
            //progressBarTemp.Value = value;
        }

        /// <summary>
        /// Завершение загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            var client = (WebClient)sender;
            client.DownloadProgressChanged -= OnDownloadProgressChanged;
            client.DownloadFileCompleted -= OnDownloadComplete;
            //progressBarTemp.Value = 0;
            SetCellIcon(soundTable.CurrentRow.Index, 3, Properties.Resources.play);
            SetCellIcon(soundTable.CurrentRow.Index, 2, Properties.Resources.downloaded_sound);
            soundTable.Rows[soundTable.CurrentRow.Index].Cells[2].Value = 100;
            soundTable.CurrentRow.Tag = true;
            soundTable.ClearSelection();
            //this.Refresh();
        }

        //Работа с потоками
        private void DownloadSoundV2(Sound sound)
        {
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(sound.url), AppDomain.CurrentDomain.BaseDirectory + "\\download\\" + sound.name + ".wav");
            });
            thread.Start();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //this.BeginInvoke((MethodInvoker)delegate 
            this.Invoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                // + e.BytesReceived + " of " + e.TotalBytesToReceive;
                //Thread.Sleep(100);
                //progressBarTemp.Value = int.Parse(Math.Truncate(percentage).ToString());
                //Thread.Sleep(100);
            });
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //this.BeginInvoke((MethodInvoker)delegate 
            this.Invoke((MethodInvoker)delegate
            {
                //progressBarTemp.Value = 0;
                SetCellIcon(soundTable.CurrentRow.Index, 3, Properties.Resources.play);
                SetCellIcon(soundTable.CurrentRow.Index, 2, Properties.Resources.downloaded_sound);
            });
        }

        /// <summary>
        /// Проигрыватель звуков
        /// </summary>
        /// <param name="sound">Объект композиции</param>
        private void PlaySound(Sound sound)
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\download\\" + sound.name + ".wav";
            soundPlayer.Play();
        }

        /// <summary>
        /// Получение объекта проигрывателя
        /// </summary>
        /// <returns></returns>
        private WindowsMediaPlayer GetWMP()
        {
            if (wmp == null)
            {
                wmp = new WindowsMediaPlayer();
            }
            return wmp;
        }

        /// <summary>
        /// Проигрыватель звуков WMP
        /// </summary>
        /// <param name="sound">Объект композиции</param>
        private void PlaySoundWMP(Sound sound)
        {
            ResetStopIcon();
            SetCellIcon(soundTable.CurrentRow.Index, 3, Properties.Resources.stop);
            wmpTimer.Start();
            GetWMP().URL = AppDomain.CurrentDomain.BaseDirectory + "\\download\\" + sound.name + ".wav";
        }

        private void ResetStopIcon()
        {
            for (int iRow = 0; iRow < soundTable.RowCount; iRow++)
            {
                if ((bool)soundTable.Rows[iRow].Tag == true)
                {
                    SetCellIcon(iRow, 3, Properties.Resources.play);
                }
                else
                {
                    SetCellIcon(iRow, 3, Properties.Resources.play_disabled);
                }
            }
        }

        /// <summary>
        /// Обработка воспроизведения
        /// </summary>
        private void WMPPlay()
        {
            WMPPlayState playState = GetWMP().playState;
            if ((GetWMP().playState == WMPLib.WMPPlayState.wmppsMediaEnded) ||
                (GetWMP().playState == WMPLib.WMPPlayState.wmppsStopped) /*||
                (GetWMP().playState == WMPLib.WMPPlayState.wmpps)*/)
            {
                wmpTimer.Stop();
                if ((bool)soundTable.CurrentRow.Tag != false)
                {
                    SetCellIcon(soundTable.CurrentRow.Index, 3, Properties.Resources.play);
                }
                soundTable.ClearSelection();
            }
        }

        /// <summary>
        /// Таймер воспроизведения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wmpTimer_Tick(object sender, EventArgs e)
        {
            WMPPlay();
        }
    }
}

