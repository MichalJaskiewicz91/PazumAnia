using System;
using System.Data;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace PazumAnia.DataBase
{
    class MySql
    {
        private MySqlConnection _mySqlConnection;
        private MySqlDataAdapter _mySqlDataAdapter;
        private MySqlDataReader _mySqlDataReader;
        private MySqlCommand _mySqlCommand;
        private static string _mySqlPathConnection = "datasource=localhost;port=3306;username=root;password=root";
        public void ConnectToDB()
        {
            try
            {
                _mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
