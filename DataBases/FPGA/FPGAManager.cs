using FPGA_UI.DataBases.FPGA.Enums;
using MySqlLibrary;

namespace FPGA_UI.DataBases.FPGA
{
    internal class FPGAManager
    {
        private readonly MySqlDatabaseConfiguration p_mySqlDatabaseConfiguration;
        private readonly FPGATablesConfiguration p_fpgaTablesConfiguration;
        private FPGATableManager? p_fpgaTableManger = null;

        internal FPGAManager()
        {
            string dataBaseName = DataBasesNamesEnum.FPGA.ToString();

            p_mySqlDatabaseConfiguration = new("server=localhost;user=root;port=3306;password=(E132450qwe)");
            p_mySqlDatabaseConfiguration.UseDataBase(dataBaseName);

            p_fpgaTablesConfiguration = new(p_mySqlDatabaseConfiguration);
            p_fpgaTablesConfiguration.CreateTablesIfNotExist();
        }

        internal FPGATableManager GetTableManager(FPGATables tableName)
        {
            if (p_fpgaTableManger is null)
                p_fpgaTableManger = new(p_mySqlDatabaseConfiguration, FPGATables.Port);
            else if (p_fpgaTableManger.GetCurrentTable() == tableName)
                return p_fpgaTableManger;
            else
                p_fpgaTableManger = new(p_mySqlDatabaseConfiguration, FPGATables.Port);

            return p_fpgaTableManger;
        }
    }
}
