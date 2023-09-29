using FPGA_UI.DataBases.FPGA.Tables;
using MySqlLibrary;
using MySqlLibrary.MySql.Commands.INSERT;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FPGA_UI.DataBases.FPGA
{
    internal class FPGATablesMethods
    {
        private MySqlDBConfiguration _MySqlConfiguration;
        private FPGATablesEnum _selectedTable;
        private string[] _tableColumnsNames;

        internal FPGATablesMethods(MySqlDBConfiguration dataBaseConfiguration, FPGATablesEnum fPGATableEnum)
        {
            _MySqlConfiguration = dataBaseConfiguration;
            SetTable(fPGATableEnum);
        }

        internal void SetTable(FPGATablesEnum fPGATableEnum)
        {
            _selectedTable = fPGATableEnum;
            _tableColumnsNames = GetTableColumnsNames().ToArray();
        }

        private List<string> GetTableColumnsNames()
        {
            Type tableClassType = FPGATablesClassTypesDictionary.TablesTypesDictionary[_selectedTable];
            List<string> columnsNames = new List<string>();

            foreach (PropertyInfo propertyInfo in tableClassType.GetProperties())
                columnsNames.Add(propertyInfo.Name);

            return columnsNames;
        }

        internal bool InsertLine(IFPGATableColumn columnInterface)
        {
            object[] columnsValues = columnInterface.ToCommandArguments();

            MySqlInsertInto.Execute(_MySqlConfiguration, _selectedTable.ToString(), _tableColumnsNames, columnsValues);

            return true;
        }
    }
}
