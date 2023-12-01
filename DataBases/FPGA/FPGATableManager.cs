using FPGA_UI.DataBases.FPGA.Enums;
using MySqlLibrary;
using MySqlLibrary.MySql.Commands.INSERT;
using MySqlLibrary.MySql.Commands.SELECT;
using MySqlLibrary.MySql.Models;
using System;
using System.Collections.Generic;

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
            object[] arguments = columnInterface.GetPropertiesAsArguments();

            MySqlInsertInto.Execute(p_MySqlDatabaseConfiguration, p_tableName.ToString(), p_columnsNames, arguments);

            return true;
        }

        internal List<object> SQLSelectAllColumns()
        {
            string[] allColumns = new[] { "*" };

            Type tableType = FPGATablesDictionaries.GetTableType(p_tableName);
            List<object> columns = MySqlSelectColumns.Execute(p_MySqlDatabaseConfiguration, tableType, allColumns);

            return columns;
        }
    }
}
