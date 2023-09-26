using FPGA_UI.DataBases.FPGA;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA_UI.DataBases
{
    internal class FGPATablesConfiguration
    {
        private DataBaseConfiguration _dataBaseConfiguration;

        internal FGPATablesConfiguration(DataBaseConfiguration dataBaseConfiguration)
        {
            _dataBaseConfiguration = dataBaseConfiguration;
            if(_dataBaseConfiguration.MySqlConnection.Database.ToLower() != DataBasesNamesEnum.FPGA.ToString().ToLower())
                dataBaseConfiguration.UseDataBase(DataBasesNamesEnum.FPGA);
        }

        internal void CreateTablesIfNotExisted()
        {

        }

        private List<string> GetExistedTables()
        {
            _dataBaseConfiguration.OpenConnection();

            List<string> tablesNames = ExecuteGetDataBaseTables();

            _dataBaseConfiguration.CloseConnection();

            return tablesNames;
        }

        private void CreateMissingTables(List<FPGATablesEnum> missingTables)
        {

        }

        private void DeleteUnidentifiedTables(List<string> strings)
        {

        }

        private List<FPGATablesEnum> GetMissingTables(List<string> receivedTableNames)
        {
            List<FPGATablesEnum> missingTablesNames = new List<FPGATablesEnum>();
            string[] tablesNames = Enum.GetNames(typeof(FPGATablesEnum));
            string tableName;

            for (int counter = 0; counter < tablesNames.Length; counter++)
            {
                tableName = tablesNames[counter];

                if (receivedTableNames.Contains(tableName) == false)
                    missingTablesNames.Add((FPGATablesEnum)counter);
            }

            return missingTablesNames;
        }

        private List<string> ExecuteGetDataBaseTables()
        {
            List<string> tablesNames = new List<string>();
            MySqlCommand mySqlCommand = new MySqlCommand("show tables", _dataBaseConfiguration.MySqlConnection);
            using MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
                tablesNames.Add(mySqlDataReader.GetString(0).ToLower());

            return tablesNames;
        }
    }
}
