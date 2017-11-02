using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Test
{
    /// <summary>
    /// JSON класс игр
    /// </summary>
    public class Game
    {
        public string url { get; set; }
    }

    /// <summary>
    /// JSON класс музыки
    /// </summary>
    public class Sound
    {
        public string name { get; set; }
        public string url { get; set; }
        public int size { get; set; }
    }

    /// <summary>
    /// JSON контейнер
    /// </summary>
    public class DeserializeJSON
    {
        public object error { get; set; }
        public List<Game> games { get; set; }
        public List<Sound> sounds { get; set; }
    }

    class JSONParsing
    {
        public JSONParsing()
        {          
        }

        public DeserializeJSON deserializeObject { get; set; }

        /// <summary>
        /// Чтение JSON объекта
        /// </summary>
        /// <param name="urlStr">адрес объекта</param>
        /// <returns>JSON строка</returns>
        private string GetJSONString(string urlStr)
        {
            if (urlStr.Length == 0)
            {
                MessageBox.Show("Введите адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            WebClient webClient = new WebClient();
            string jsonString = "";
            try
            {
                jsonString = webClient.DownloadString(urlStr);
            }
            catch
            {
                jsonString = "";
                MessageBox.Show("Неверный адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return jsonString;
        }

        /// <summary>
        /// Десериализация JSON объекта
        /// </summary>
        /// <param name="urlStr">адрес объекта</param>
        public void DeserializeJSONObject(string urlStr)
        {
            string jsonString = GetJSONString(urlStr);
            deserializeObject = JsonConvert.DeserializeObject<DeserializeJSON>(jsonString);
        }

        /// <summary>
        /// Сохранение в БД
        /// </summary>
        public void SaveJSON()
        {
            //В разработке
        }
                
    }

}
