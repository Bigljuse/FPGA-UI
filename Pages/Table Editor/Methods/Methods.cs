using FPGA_UI.DataBases.FPGA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA_UI.Pages
{
    public partial class Page_Table_Editor
    {
        public void SetTable(FPGATables table)
        {
            Table = table;
            UpdateTableManager();
            Button_UpdateDataGrid_Click(this, new System.Windows.RoutedEventArgs());
        }

        public void UpdateTableManager()
        {
            p_fpgaTableManager = p_fpgaManager.GetTableManager(Table);
        }
    }
}
