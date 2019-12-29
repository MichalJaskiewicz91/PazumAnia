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
            _mySqlConnection.Open();
            //if (_mySqlConnection.State == ConnectionState.Closed)
            //{
            //    _mySqlConnection.Open();
            //}
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
