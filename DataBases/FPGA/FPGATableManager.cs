using FPGA_UI.DataBases.FPGA.Enums;
using MySqlLibrary;
using MySqlLibrary.MySql.Commands.DELETE;
using MySqlLibrary.MySql.Commands.INSERT;
using MySqlLibrary.MySql.Commands.SELECT;
using MySqlLibrary.MySql.Commands.UPDATE;
using MySqlLibrary.MySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FPGA_UI.DataBases.FPGA
{
    internal class FPGATableManager
    {
        private readonly MySqlDatabaseConfiguration p_MySqlDatabaseConfiguration;
        private readonly FPGATables p_tableName;
        private readonly string[] p_columnsNames;

        internal FPGATableManager(MySqlDatabaseConfiguration dataBaseConfiguration, FPGATables tableName)
        {
            p_MySqlDatabaseConfiguration = dataBaseConfiguration;
            p_tableName = tableName;
            p_columnsNames = GetColumnsNames();
        }

        private string[] GetColumnsNames()
        {
            p_MySqlDatabaseConfiguration.UseDataBase("fpga");
            MySqlColumnModel[] tableColumns = FPGATablesDictionaries.GetTableColumns(p_tableName);
            string[] columnsNames = new string[tableColumns.Length];
            MySqlColumnModel tableColumn;

            for (int counter = 0; counter < tableColumns.Length; counter++)
            {
                tableColumn = tableColumns[counter];
                columnsNames[counter] = tableColumn.Name;
            }

            return columnsNames;
        }

        internal FPGATables GetCurrentTable()
        {
            return p_tableName;
        }

        internal bool SQLInsertLine(IFPGATable columnInterface)
        {
            p_MySqlDatabaseConfiguration.UseDataBase("fpga");
            object[] arguments = columnInterface.GetPropertiesAsArguments();

            MySqlInsertInto.Execute(p_MySqlDatabaseConfiguration, p_tableName.ToString(), p_columnsNames, arguments);

            return true;
        }

        internal List<object> SQLSelectAllColumns(int limit = 0)
        {
            p_MySqlDatabaseConfiguration.UseDataBase("fpga");
            string[] allColumns = new[] { "*" };

            Type tableType = FPGATablesDictionaries.GetTableType(p_tableName);
            List<object> columns = MySqlSelectColumns.Execute(p_MySqlDatabaseConfiguration, tableType, allColumns, limit);

            return columns;
        }

        internal int SQLUpdateLine(IFPGATable line)
        {
            p_MySqlDatabaseConfiguration.UseDataBase("fpga");
            object[] arguments = line.GetPropertiesAsArguments();
            Type tableType = FPGATablesDictionaries.GetTableType(p_tableName);

            int id = 0;
            object? objectId = line.GetPropertyValueByName("Id");
            id = Convert.ToInt32(objectId);

            return MySqlUpdate.Execute(p_MySqlDatabaseConfiguration, tableType, p_columnsNames, arguments, id);
        }

        internal void SQLDeleteLine(IFPGATable line)
        {
            p_MySqlDatabaseConfiguration.UseDataBase("fpga");
            int id = 0;
            object? objectId = line.GetPropertyValueByName("Id");
            id = Convert.ToInt32(objectId);

            MySqlDelete.Execute(p_MySqlDatabaseConfiguration, p_tableName.ToString(), id);
        }
    }
}
