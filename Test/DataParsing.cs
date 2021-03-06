﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web;

namespace Test
{
    class JSONParsing
    {
        public JSONParsing()
        {}

        public ObjectsContainer deserializeObject { get; set; }

        /// <summary>
        /// Чтение JSON объекта
        /// </summary>
        /// <param name="urlStr">адрес объекта</param>
        /// <returns>JSON строка</returns>
        private string GetJSONString(string urlStr)
        {
            if (urlStr.Length == 0)
            {
                //MessageBox.Show("Введите адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Msg.Show(MainForm.Get(),"Ошибка","Введите адрес");                
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
            deserializeObject = JsonConvert.DeserializeObject<ObjectsContainer>(jsonString);
            DeserializeXML();
        }

        /// <summary>
        /// Разбор XML строки
        /// </summary>
        /// <param name="game">Игра</param>
        public void DeserializeGame(Game game)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string xmlStr = webClient.DownloadString(game.url);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlStr); 
            foreach (XmlNode games in xDoc.SelectNodes("/game"))
            {
                game.name = games.Attributes["name"].Value.ToString();
                game.date = games.Attributes["date"].Value.ToString();
                List<Team> teams = new List<Team>();
                foreach (XmlNode team in games.ChildNodes)
                {
                    Team myTeam = new Team();
                    List<Player> players = new List<Player>();
                    foreach (XmlNode player in team.ChildNodes)
                    {
                        Player myPlayer = new Player();
                        myPlayer.name = player.Attributes["name"].Value.ToString();
                        myPlayer.rating = Convert.ToInt32(player.Attributes["rating"].Value.ToString());
                        string accuracyStr = player.Attributes["accuracy"].Value.ToString();
                        double accuracy = double.Parse(accuracyStr, System.Globalization.CultureInfo.InvariantCulture);
                        myPlayer.accuracy = accuracy;
                        myPlayer.shots = Convert.ToInt32(player.Attributes["shots"].Value.ToString());
                        players.Add(myPlayer);
                    }
                    myTeam.name = team.Attributes["name"].Value.ToString();
                    myTeam.players = players;
                    teams.Add(myTeam);
                }
                game.teams = teams;
            }
        }
                
        /// <summary>
        /// Десериализация игр
        /// </summary>
        public void DeserializeXML()
        {
            if (deserializeObject != null)
            {
                foreach (Game game in deserializeObject.games)
                {
                    DeserializeGame(game);
                }
            }
        }

        /// <summary>
        /// Сохранение в БД
        /// </summary>
        public void SaveJSON()
        {
            DBWork.ClearTables(DBWork.tablesList);
            List<string> playerNames = new List<string>();
            foreach (Game game in deserializeObject.games)
            {
                foreach (Team team in game.teams)
                {
                    team.Save();
                    foreach (Player player in team.players)
                    {
                        player.SavePlayersByTeam(team.id.ToString(), player.Save().ToString());
                    }
                }
                game.Save();
            }
            foreach (Sound sound in deserializeObject.sounds)
            {
                sound.Save();
            }
        }
    }
}
