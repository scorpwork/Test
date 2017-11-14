using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Test
{
    class DBWork
    {
        public static SQLiteConnection dbConnect { set; get; }
        public static List<string> tablesList { get; set; }
        private String dbFileName { set; get; }
        public static SQLiteCommand sqlCmd { set; get; }

        /// <summary>
        /// Открытие соединения с базой данных
        /// </summary>
        public void Connection()
        {
            dbConnect = new SQLiteConnection();
            sqlCmd = new SQLiteCommand();
            dbFileName = "TestDB.sqlite";
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
            }
            try
            {
                dbConnect = new SQLiteConnection("Data Source=" + dbFileName + ";");
                dbConnect.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }            
        }

        /// <summary>
        /// Создание таблиц системы
        /// </summary>
        public void CreateTables()
        {
            FillTableList();
            try
            {
                sqlCmd.Connection = dbConnect;
                //tbPlayers
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbPlayers (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "name TEXT NOT NULL, rating INTEGER)";//, rating INTEGER, accuracy REAL, shots INTEGER)";
                sqlCmd.ExecuteNonQuery();
                //tbTeams
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbTeams (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "name TEXT NOT NULL)";
                sqlCmd.ExecuteNonQuery();
                //tbPlayersByTeam
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbPlayersByTeam (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idTeam INTEGER, idPlayer INTEGER, accuracy REAL, shots INTEGER)";
                sqlCmd.ExecuteNonQuery();
                //tbGames
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbGames (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "name TEXT NOT NULL, date TEXT)";
                sqlCmd.ExecuteNonQuery();
                //tbTeamsByGame
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbTeamsByGame (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idGame INTEGER, idTeam INTEGER)";
                sqlCmd.ExecuteNonQuery();
                //tbSound
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbSounds (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "name TEXT NOT NULL, url TEXT, size INTEGER)";
                sqlCmd.ExecuteNonQuery();
                //tbObjects
                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS tbObjects (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "error TEXT, idGame INTEGER, idSound, INTEGER)";
                sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Заполнение списка таблиц
        /// </summary>
        private void FillTableList()
        {
            tablesList = new List<string>();
            tablesList.Add("tbPlayers");
            tablesList.Add("tbTeams");
            tablesList.Add("tbPlayersByTeam");
            tablesList.Add("tbGames");
            tablesList.Add("tbTeamsByGame");
            tablesList.Add("tbSounds");
            tablesList.Add("tbObjects");
        }

        /// <summary>
        /// Очистка всех таблиц БД
        /// </summary>
        /// <param name="tables"></param>
        public static void ClearTables(List<string> tables)
        {
            foreach (string table in tables)
            {
                string sqlstr = "DELETE FROM " + table;                
                GetSQLCommand().CommandText = sqlstr;
                GetSQLCommand().ExecuteNonQuery();                
            }           
        }

        /// <summary>
        /// Получение подключенной команды для работы с БД
        /// </summary>
        /// <returns>Команда</returns>
        public static SQLiteCommand GetSQLCommand()
        {
            if (sqlCmd == null)
            {
                sqlCmd = new SQLiteCommand();
                sqlCmd.Connection = DBWork.dbConnect;
                return sqlCmd;
            }
            else
            {
                return sqlCmd;
            }
        }

        /// <summary>
        /// Вставка в таблицу с возвращением идентификатора нового объекта
        /// </summary>
        /// <param name="sqlstr">SQL запрос</param>
        /// <returns>идентификатор</returns>
        public static int Insert(string sqlstr)
        {
            try
            {
                GetSQLCommand().CommandText = sqlstr;
                GetSQLCommand().ExecuteNonQuery();
                GetSQLCommand().CommandText = "SELECT last_insert_rowid()";
                string id = GetSQLCommand().ExecuteScalar().ToString();
                return Convert.ToInt32(id);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Выполнение SQL запроса
        /// </summary>
        /// <param name="sqlstr">SQL запрос</param>
        /// <returns>флаг выполнения</returns>
        public static bool Exec(string sqlstr)
        {
            try
            {
                GetSQLCommand().CommandText = sqlstr;
                GetSQLCommand().ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Выборка
        /// </summary>
        /// <param name="sqlstr">SQL запрос</param>
        /// <returns>Выборка в табличном виде</returns>
        public static DataTable Select(string sqlstr)
        {
            try
            {
                DataTable dataTable = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlstr, DBWork.dbConnect);
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public DBWork()
        {}        
    }
}
