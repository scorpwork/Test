using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Test
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public double accuracy { get; set; }
        public int shots { get; set; }

        public void Save()
        {
            string sqlstr = "INSERT INTO tbPlayers (name,rating,accuracy,shots) VALUES (" +
                "'" + name + "', " +
                "'" + rating.ToString() + "', " +
                "'" + accuracy.ToString() + "', " +
                "'" + shots.ToString() + "'" +
                ")";
            this.id = DBWork.Insert(sqlstr);
        }

        /*public static List<Player> Load()
        {
            В процессе разработки
        }*/
    }

    /// <summary>
    /// Команда
    /// </summary>
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Player> players { get; set; }

        public void Save()
        {
            string sqlstr = "INSERT INTO tbTeams (name) VALUES ('" + name + "') ";
            this.id = DBWork.Insert(sqlstr);

            foreach (Player player in this.players)
            {
                sqlstr = "INSERT INTO tbPlayersByTeam (idTeam,idPlayer) VALUES (" +
                "'" + this.id + "', " +
                "'" + player.id + "' " +
                ")";
                DBWork.Insert(sqlstr);
            }
        }

        /*public static List<Team> Load()
        {

        }*/
    }

    /// <summary>
    /// JSON класс игр
    /// </summary>
    public class Game
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public List<Team> teams { get; set; }
        public void Save()
        {
            string sqlstr = "INSERT INTO tbGames (name, date) VALUES ('" + name + "', "+date+"') ";
            this.id = DBWork.Insert(sqlstr);

            foreach (Team team in this.teams)
            {
                sqlstr = "INSERT INTO tbTeamsByGame (idGame, idTeam) VALUES (" +
                "'" + this.id + "', " +
                "'" + team.id + "' " +
                ")";
                DBWork.Insert(sqlstr);
            }
        }

        /*public static List<Game> Load()
        {

        }*/
    }

    /// <summary>
    /// JSON класс музыки
    /// </summary>
    public class Sound
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int size { get; set; }

        public void Save()
        {
            string sqlstr = "INSERT INTO tbSounds (name, url, size) VALUES ('" + name + "', " + url + "', " +
                "'" + size.ToString() + "')";
            this.id = DBWork.Insert(sqlstr);
        }

        public static List<Sound> Load()
        {
            Sound sound = new Sound();
            List<Sound> soundList = new List<Sound>();
            string sqlstr = "SELECT id,name,url,size FROM tbSounds";
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    if (dataTable.Columns.Count == 4)
                    {
                        sound.id = Convert.ToInt32(dataTable.Rows[iRow][0].ToString());
                        sound.name = dataTable.Rows[iRow][1].ToString();
                        sound.url = dataTable.Rows[iRow][2].ToString();
                        sound.size = Convert.ToInt32(dataTable.Rows[iRow][3].ToString());
                        soundList.Add(sound);
                    }
                }
            }
            return soundList;
        }
    }

    /// <summary>
    /// JSON контейнер
    /// </summary>
    public class ObjectsContainer//DeserializeJSON
    {
        public int id { get; set; }
        public object error { get; set; }
        public List<Game> games { get; set; }
        public List<Sound> sounds { get; set; }        
    }
}
