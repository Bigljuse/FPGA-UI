using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FPGA_UI.Pages
{
    public partial class Page_Tables
    {
        private void SetFrameTable(Frame frame, FPGATables table)
        {
            Page_Table_Editor? page_table_editor = frame.Content as Page_Table_Editor;

            if (page_table_editor is null || page_table_editor.Table != table)
            {
                Page_Table_Editor page_Table_Editor = new Page_Table_Editor(p_FPGAManager);
                page_Table_Editor.SetTable(table);
                frame.Navigate(page_Table_Editor);
                return;
            }
        }
    }
}
