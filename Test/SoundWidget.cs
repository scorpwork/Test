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
    public partial class SoundWidget : Form
    {
        public SoundWidget()
        {
            InitializeComponent();
            PrepareSoundTable();
        }

        /// <summary>
        /// Подготовка таблицы с музыкой
        /// </summary>
        private void PrepareSoundTable()
        {            
            ObjectsContainer data = ObjectsContainer.GetData();
            soundTable.Rows.Clear();
            int iterator = 0;
            foreach (Sound sound in data.sounds)
            {
                soundTable.Rows.Add();
                soundTable.Rows[iterator].Cells[0].Value = sound.name;
                soundTable.Rows[iterator].Cells[1].Value = GetCorrectSize(sound.size);
                SetActiveDownloadIcon(iterator,2);
                SetDisActivePlayIcon(iterator, 3);
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

        private void SetActiveDownloadIcon(int row, int col)
        {
            Bitmap icon = Properties.Resources.download_sound;
            soundTable[col,row].Value = icon;
        }

        private void SetDisActivePlayIcon(int row, int col)
        {
            Bitmap icon = Properties.Resources.play_disabled;
            soundTable[col, row].Value = icon;
        }        
    }
}
