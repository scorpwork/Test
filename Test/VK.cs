using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkNet.Model.Attachments;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace Test
{
    public partial class VK : Form
    {
        public VK()
        {
            InitializeComponent();
            FormLoad();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void FormLoad()
        {
            checkBoxImage.Checked = true;
            checkBoxDocs.Checked = true;
            List<ComboItem> items = new List<ComboItem>();
            items.Add(new ComboItem("LaserWar", 157168384));
            comboBoxGroup.DataSource = items;
            comboBoxGroup.DisplayMember = "Text";
            comboBoxGroup.ValueMember = "Value"; 
            comboBoxGroup.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик кнопки публикации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void publicateBt_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            VkApi token = Autorization();
            if (token != null)
            {
                if (checkBoxDocs.Checked == false && checkBoxImage.Checked == false && inputText.Text == "")
                {
                    Msg.Show(this, "Ошибка", "Все поля публикации не могут быть пустыми");
                }
                else
                {
                    ScreenShot();
                    SendMessage(token);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <returns></returns>
        private VkApi Autorization()
        {
            ulong applicationID = 6265926;     
            string login = loginTextbox.Text;  
            string pass = passTextbox.Text;    
            Settings scope = Settings.All;     

            var vk = new VkApi();
            try
            {
                vk.Authorize(new ApiAuthParams
                {
                    ApplicationId = applicationID,
                    Login = login,
                    Password = pass,
                    Settings = scope
                });
                return vk;
            }
            catch
            {
                Msg.Show(this, "Ошибка", "Ошибка авторизации пользователя");
                return null;
            }
        }

        /// <summary>
        /// публикация
        /// </summary>
        /// <param name="vk">токен</param>
        private void SendMessage(VkApi vk)
        {
            ComboItem comboItem = new ComboItem("", 0);
            object comboValue = comboBoxGroup.SelectedValue;
            long group = Convert.ToInt64(comboValue);
            ulong ugroup = Convert.ToUInt64(comboValue);
            var wc = new WebClient();
            List<string> responseDocs = new List<string>();
            string responseFile = "";
            //var uploadDocServer = vk.Docs.GetWallUploadServer(157168384);
            var uploadDocServer = vk.Docs.GetWallUploadServer(group);
            List<string> documents = GetDocuments();
            foreach (string doc in documents)
            {
                try
                {
                    responseDocs.Add(Encoding.ASCII.GetString(wc.UploadFile(uploadDocServer.UploadUrl,
                      @"Reports\\" + doc)));
                }
                catch { }
            }
            var uploadServer = vk.Photo.GetWallUploadServer(group);
            try
            {
                responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl,
                    @"screenshots\\publicationScreen.jpg"));
            }
            catch { }
            var albumId = uploadServer.AlbumId;
            Photo photo = new Photo { AlbumId = albumId };
            var photos = vk.Photo.SaveWallPhoto(
                responseFile,
                ugroup,
                ugroup,
                ""
            );
            List<MediaAttachment> attachments = new List<MediaAttachment>();
            if (checkBoxImage.Checked == true)
            { 
                if (photos.Count != 0)
                {
                    attachments.Add(photos[0]);
                }
            }
            int iterator = 0;
            foreach (string doc in responseDocs)
            {
                var docs = vk.Docs.Save(
                    doc,
                    documents[iterator]);
                attachments.Add(docs[0]);
                iterator++;
            }
            var post = vk.Wall.Post(
                -group,
                false,
                false,
                inputText.Text,
                attachments);
        }

        /// <summary>
        /// Получение списка выбранных документов
        /// </summary>
        /// <returns>список документов для публикации</returns>
        private List<string> GetDocuments()
        {
            List<string> documents = new List<string>();
            for (int iItem=0; iItem < checkedListBoxDocs.Items.Count; iItem++)
            {
                CheckState state = checkedListBoxDocs.GetItemCheckState(iItem);
                if (state == CheckState.Checked)
                {
                    documents.Add(checkedListBoxDocs.Items[iItem].ToString());
                }
            }
            return documents;
        }

        /// <summary>
        /// обработчик кнопки закрытия окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод снимка экрана
        /// </summary>
        private void ScreenShot()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save("screenshots\\publicationScreen.jpg");
        }

        /// <summary>
        /// Событие изменения состояния
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxDocs_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxDocs.Items.Clear();
            if (checkBoxDocs.Checked == true)
            {
                List<string> documents = Directory.GetFiles(@"Reports", "*.pdf").ToList<string>();
                int iterator = 0;
                foreach (string doc in documents)
                {
                    string value = doc.Remove(0, doc.IndexOf("\\")+1).ToString();
                    checkedListBoxDocs.Items.Add(value);
                    checkedListBoxDocs.SetItemChecked(iterator,true);
                    iterator++;
                }
            }
            else
            {
                int count = checkedListBoxDocs.Items.Count;
                if (count!=0)
                {
                    for (int iItem=0; iItem < count; iItem++)
                    {
                        checkedListBoxDocs.SetItemCheckState(iItem, CheckState.Unchecked);
                    }
                }
            }
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VK_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransparentForm.Get().Close();
            TransparentForm.Get().Delete();
            MainForm.Get().Activate();
        }
    }
    /// <summary>
    /// Обертка для выпадающего списка
    /// </summary>
    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public ComboItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
    }
}
            
/*
var send = vk.Messages.Send(new MessagesSendParams
{
    UserId = Taker,
    Message = msg
});
*/
