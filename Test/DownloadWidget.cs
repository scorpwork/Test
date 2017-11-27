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
        /// <returns>флаг</returns>
        private bool CheckJSON(ObjectsContainer json)
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
            Thread wait = new System.Threading.Thread(TransparentForm.Wait);
            wait.Start();
            ObjectsContainer.ClearData();
            statusLabel.Visible = false;
            JSONParsing json = new JSONParsing();
            json.DeserializeJSONObject(downloadTextBox.Text);
            ObjectsContainer deserializeJSON = json.deserializeObject;            
            if (CheckJSON(deserializeJSON))
            {
                json.SaveJSON();
                ObjectsContainer.GetData();
                ShowJsonStatistic(deserializeJSON);
                statusLabel.Visible = true;
            }
            TransparentForm.Reset();
            wait.Abort();
            wait.Join(500);
            Cursor.Current = Cursors.Default;
        }        

        private void ShowJsonStatistic(ObjectsContainer jsonObject)
        {
            string text = "Информация о загруженном объекте:\n";
            if (jsonObject.error == null)
            {
                text += "Ошибки не обнаружены\n";
            }
            else
            {
                text += "Ошибка: "+jsonObject.error.ToString()+"\n";
            }
            if (jsonObject.games.Count() != 0)
            {
                text += "Проведено игр: " + jsonObject.games.Count().ToString() + "\n";
            }
            foreach(Game game in jsonObject.games)
            {
                text += "     " + game.name+"("+game.date+"), участники: \n";
                foreach (Team team in game.teams)
                {
                    text += "           " + team.name + " в составе " +
                        ""+team.players.Count().ToString()+" игроков \n";
                }
            }
            if (jsonObject.sounds.Count()!=0)
            {
                text+="Имеются сведения о "+ jsonObject.sounds.Count().ToString()+ " композициях\n";
            }
            else
            {
                text += "Музыка отсутствует\n";
            }
                        
            statisticBox.Text = text;
        }
    }
}
