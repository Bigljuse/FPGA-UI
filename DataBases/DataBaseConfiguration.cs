using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA_UI.DataBases
{
    internal class DataBaseConfiguration
    {
        private readonly string s_connectionString;
        internal MySqlConnection MySqlConnection { get; private set; }

        internal DataBaseConfiguration()
        {
            s_connectionString = "server=localhost;user=root;port=3306;password=(E132450qwe)";
            MySqlConnection = new MySqlConnection(s_connectionString);
        }

        internal void OpenConnection()
        {
            if (MySqlConnection.State == System.Data.ConnectionState.Closed)
                MySqlConnection.Open();
        }

        internal void CloseConnection()
        {
            if (MySqlConnection.State != System.Data.ConnectionState.Closed)
                MySqlConnection.Close();
        }

        internal void UseDataBase(DataBasesNamesEnum dataBaseNameEnum)
        {
            CreateDataBaseIfNotExists(dataBaseNameEnum);

            OpenConnection();
            ExecuteUseDataBase(dataBaseNameEnum);
            CloseConnection();
        }

        private void CreateDataBaseIfNotExists(DataBasesNamesEnum dataBaseNameEnum)
        {
            if (IsDataBaseExists(dataBaseNameEnum) == false)
                CreateDataBase(dataBaseNameEnum);
        }

        private void ReCreateDataBase(DataBasesNamesEnum dataBaseNameEnum)
        {
            DropDataBase(dataBaseNameEnum);
            CreateDataBase(dataBaseNameEnum);
        }

        private void DropDataBase(DataBasesNamesEnum dataBaseNameEnum)
        {
            OpenConnection();
            ExecuteDropDataBase(dataBaseNameEnum);
            CloseConnection();
        }

        private void CreateDataBase(DataBasesNamesEnum dataBaseNameEnum)
        {
            OpenConnection();
            ExecuteCreateDataBase(dataBaseNameEnum);
            CloseConnection();
        }

        private bool IsDataBaseExists(DataBasesNamesEnum databaseNameEnum)
        {
            OpenConnection();

            string dataBaseName = databaseNameEnum.ToString().ToLower();           
            List<string> dataBasesNames = ExecuteGetDataBases();
            bool dataBaseExists = dataBasesNames.Contains(dataBaseName);

            CloseConnection();

            return dataBaseExists;
        }

        private void ExecuteUseDataBase(DataBasesNamesEnum databaseNameEnum)
        {
            MySqlCommand mySqlCommand = new MySqlCommand($"use {databaseNameEnum}", MySqlConnection);
            mySqlCommand.ExecuteNonQuery();
        }

        private List<string> ExecuteGetDataBases()
        {
            List<string> dataBasesNames = new List<string>();
            MySqlCommand mySqlCommand = new MySqlCommand("show databases", MySqlConnection);
            using MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
                dataBasesNames.Add(mySqlDataReader.GetString(0));

            return dataBasesNames;
        }

        private void ExecuteCreateDataBase(DataBasesNamesEnum dataBaseNameEnum)
        {
            MySqlCommand mySqlCommand = new MySqlCommand($"Create database {dataBaseNameEnum}", MySqlConnection);
            mySqlCommand.ExecuteNonQuery();
        }

        private void ExecuteDropDataBase(DataBasesNamesEnum dataBaseNameEnum)
        {
            MySqlCommand mySqlCommand = new MySqlCommand($"Drop database {dataBaseNameEnum}", MySqlConnection);
            mySqlCommand.ExecuteNonQuery();
        }

        ~DataBaseConfiguration()
        {
            if (MySqlConnection.State != System.Data.ConnectionState.Closed)
                MySqlConnection.Close();
        }
    }
}
