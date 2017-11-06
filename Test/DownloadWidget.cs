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
    public partial class DownloadWidget : Form
    {
        public DownloadWidget()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка корректности загруженного json объекта
        /// </summary>
        /// <param name="json">объект</param>
        /// <returns></returns>
        private bool CheckJSON(DeserializeJSON json)
        {
            if (json == null)
            {
                return false;
            }
            if (json.games.Count == 0 &&
                json.sounds.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Загрузка и обработка JSON объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadBt_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            statusLabel.Visible = false;
            JSONParsing json = new JSONParsing();
            json.DeserializeJSONObject(downloadTextBox.Text);            
            DeserializeJSON deserializeJSON = json.deserializeObject;            
            if (CheckJSON(deserializeJSON))
            {
                json.SaveJSON();
                statusLabel.Visible = true;
            }            
            Cursor.Current = Cursors.Default;
        }        
    }
}
