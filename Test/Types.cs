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

        public static Player Load(int id)
        {
            Player player = new Player();
            string sqlstr = "SELECT id,name,rating,accuracy,shots FROM tbPlayers where id = " + id.ToString();
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    if (dataTable.Columns.Count == 5)
                    {
                        player.id = Convert.ToInt32(dataTable.Rows[iRow][0].ToString());
                        player.name = dataTable.Rows[iRow][1].ToString();
                        player.rating = Convert.ToInt32(dataTable.Rows[iRow][2].ToString());
                        player.accuracy = Convert.ToDouble(dataTable.Rows[iRow][3].ToString());//в доработке
                        player.shots = Convert.ToInt32(dataTable.Rows[iRow][4].ToString());
                    }
                }
            }
            return player;
        }
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

        public static Team Load(int id)
        {
            Team team = new Team();
            string sqlstr = "SELECT id,name FROM tbTeams where id = "+id.ToString();
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    if (dataTable.Columns.Count == 2)
                    {
                        team.id = Convert.ToInt32(dataTable.Rows[iRow][0].ToString());
                        team.name = dataTable.Rows[iRow][1].ToString();
                        List<Player> players = new List<Player>();
                        foreach (int playerId in Team.GetPlayersId(team.id))
                        {
                            players.Add(Player.Load(playerId));
                        }
                        team.players = players;
                    }
                }
            }
            return team;
        }

        /// <summary>
        /// Получить список идентификаторов игроков для команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Идентификаторы игроков</returns>
        private static List<int> GetPlayersId(int id)
        {
            List<int> players = new List<int>();
            string sqlstr = "SELECT idPlayer FROM tbPlayersByTeam where idTeam = " + id.ToString();
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    players.Add(Convert.ToInt32(dataTable.Rows[iRow][0].ToString()));
                }
            }
            return players;
        }
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
            string sqlstr = "INSERT INTO tbGames (name, date) VALUES ('" + name + "', '"+date+"') ";
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

        public static List<Game> Load()
        {            
            List<Game> gameList = new List<Game>();
            string sqlstr = "SELECT id,name,date FROM tbGames";
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    if (dataTable.Columns.Count == 3)
                    {
                        Game game = new Game();
                        game.id = Convert.ToInt32(dataTable.Rows[iRow][0].ToString());
                        game.name = dataTable.Rows[iRow][1].ToString();
                        game.date = dataTable.Rows[iRow][2].ToString();
                        List<Team> teams = new List<Team>();
                        foreach (int teamId in Game.GetTeamsId(game.id))
                        {
                            teams.Add(Team.Load(teamId));
                        }
                        game.teams = teams;
                        gameList.Add(game);
                    }
                }
            }
            return gameList;
        }

        /// <summary>
        /// Получить список идентификаторов команд для игры
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <returns>Идентификаторы команд</returns>
        private static List<int> GetTeamsId(int id)
        {
            List<int> teams = new List<int>();
            string sqlstr = "SELECT idTeam FROM tbTeamsByGame where idGame = "+id.ToString();
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    teams.Add(Convert.ToInt32(dataTable.Rows[iRow][0].ToString()));
                }
            }
            return teams;
        }
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
            string sqlstr = "INSERT INTO tbSounds (name, url, size) VALUES ('" + name + "', '" + url + "', " +
                "'" + size.ToString() + "')";
            this.id = DBWork.Insert(sqlstr);
        }

        public static List<Sound> Load()
        {            
            List<Sound> soundList = new List<Sound>();
            string sqlstr = "SELECT id,name,url,size FROM tbSounds";
            DataTable dataTable = DBWork.Select(sqlstr);
            if (dataTable.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dataTable.Rows.Count; iRow++)
                {
                    if (dataTable.Columns.Count == 4)
                    {
                        Sound sound = new Sound();
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
