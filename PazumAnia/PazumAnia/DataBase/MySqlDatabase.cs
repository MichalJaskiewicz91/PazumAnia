using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PazumAnia.DataBase
{
    public class MySqlDatabase
    {
        private MySqlConnection _mySqlConnection;
        private MySqlDataAdapter _mySqlDataAdapter;
        private MySqlDataReader _mySqlDataReader;
        private MySqlCommand _mySqlCommand;

        //Constructor
        public MySqlDatabase()
        {
            _mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
        }
        // Connect to MySql database
        public void ConnectToDB()
        {
            //_mySqlConnection.Open();
            //if (_mySqlConnection.State == ConnectionState.Closed)
            //{
            //    _mySqlConnection.Open();
            //}
        }
        public void test()
        {
            MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder();
            b.Server = "localhost";
            b.Port = 3306;
            b.Database = "pazumania";
            b.UserID = "root";
            b.Password = "root";
            b.CharacterSet = "utf8";
            var connstr = b.ToString();
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            conn.Close();
        }
        // Read from DB
        public MySqlDataReader ReadFromDB(string query)
        {
            ConnectToDB();
            _mySqlCommand = new MySqlCommand(query, _mySqlConnection);
            _mySqlDataReader = _mySqlCommand.ExecuteReader();
            return _mySqlDataReader;
        }
    }
}
