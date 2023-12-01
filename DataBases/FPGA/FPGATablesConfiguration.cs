using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Enums;
using MySqlLibrary;
using MySqlLibrary.MySql.Commands.CREATE;
using MySqlLibrary.MySql.Commands.DROP;
using MySqlLibrary.MySql.Commands.SHOW;
using MySqlLibrary.MySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FPGA_UI.DataBases
{
    internal class FPGATablesConfiguration
    {
        private MySqlDatabaseConfiguration _mySqlConfiguration;

        internal FPGATablesConfiguration(MySqlDatabaseConfiguration dataBaseConfiguration)
        {
            _mySqlConfiguration = dataBaseConfiguration;
        }

        internal void CreateTablesIfNotExist()
        {
            UseFPGADataBase();

            List<string> tablesNames = GetTablesNames();
            DeleteUnidentifiedTables(tablesNames);
            CreateMissingTables(tablesNames);
        }

        private void UseFPGADataBase()
        {
            string UsedDataBaseName = _mySqlConfiguration.MySqlConnection.Database.ToLower();
            string fpgaDataBaseName = DataBasesNamesEnum.FPGA.ToString().ToLower();

            if (UsedDataBaseName != fpgaDataBaseName)
                _mySqlConfiguration.UseDataBase(DataBasesNamesEnum.FPGA.ToString());
        }

        private List<string> GetTablesNames()
        {
            List<string> tablesNames = MySqlShowTables.Execute(_mySqlConfiguration);

            return tablesNames;
        }

        private void CreateMissingTables(List<string> tablesNames)
        {
            List<FPGATables> missingTables = GetMissingTables(tablesNames);
            MySqlColumnModel[] mySqlColumnsModel;
            string tableName;

            foreach (FPGATables tableNameEnum in missingTables)
            {
                tableName = tableNameEnum.ToString();
                mySqlColumnsModel = FPGATablesDictionaries.GetTableColumns(tableNameEnum);
                MySqlCreateTable.Execute(_mySqlConfiguration, tableName, mySqlColumnsModel);
            }
        }

        private void DeleteUnidentifiedTables(List<string> tablesNames)
        {
            List<string> unidentifiedTablesNames = GetUnidentifiedTables(tablesNames);

            foreach (string unidentifedTableName in unidentifiedTablesNames)
                MySqlDropTable.Execute(_mySqlConfiguration, unidentifedTableName);
        }

        private List<string> GetUnidentifiedTables(List<string> receivedTableNames)
        {
            List<string> unidentifiedTablesNames = new List<string>();
            string[] tablesNames = Enum.GetNames(typeof(FPGATables));
            string receivedTableName;

            for (int counter = 0; counter < receivedTableNames.Count; counter++)
                tablesNames[counter] = tablesNames[counter].ToLower();

            for (int counter = 0; counter < receivedTableNames.Count; counter++)
            {
                receivedTableName = receivedTableNames[counter];

                if (tablesNames.Contains(receivedTableName) == false)
                    unidentifiedTablesNames.Add(receivedTableName);
            }

            return unidentifiedTablesNames;
        }

        private List<FPGATables> GetMissingTables(List<string> receivedTableNames)
        {
            List<FPGATables> listOfMissingTables = new();
            int lengthOfTableNamesInEnum = Enum.GetNames(typeof(FPGATables)).Length;
            FPGATables tableNameEnum;
            string tableName;

            for (int counter = 0; counter < lengthOfTableNamesInEnum; counter++)
            {
                tableNameEnum = (FPGATables)counter;
                tableName = tableNameEnum.ToString().ToLower();

                if (receivedTableNames.Contains(tableName) == false)
                    listOfMissingTables.Add(tableNameEnum);
            }

            return listOfMissingTables;
        }
    }
}
