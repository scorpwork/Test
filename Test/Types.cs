using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class Player
    {
        public string name { get; set; }
        public int rating { get; set; }
        public double accuracy { get; set; }
        public int shots { get; set; }
        //virtual public void Save();
    }

    /// <summary>
    /// Команда
    /// </summary>
    public class Team
    {
        public string name { get; set; }
        public List<Player> players { get; set; }
    }

    /// <summary>
    /// JSON класс игр
    /// </summary>
    public class Game
    {
        public string url { get; set; }        
        public string name { get; set; }
        public string date { get; set; }
        public List<Team> teams { get; set; }
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
}
