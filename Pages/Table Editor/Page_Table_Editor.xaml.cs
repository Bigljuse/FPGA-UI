using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Enums;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FPGA_UI.Pages
{
    /// <summary>
    /// Interaction logic for Page_Database_Editor.xaml
    /// </summary>
    public partial class Page_Table_Editor : Page
    {
        private readonly FPGAManager p_fpgaManager;
        private FPGATableManager p_fpgaTableManager;

        internal Page_Table_Editor(FPGAManager fpgaManager)
        {
            InitializeComponent();
            p_fpgaManager = fpgaManager;
            DataContext = this;
            p_fpgaTableManager = p_fpgaManager.GetTableManager(Table);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_UpdateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Table.ItemsSource = p_fpgaTableManager.SQLSelectAllColumns();
        }

        private void Button_AddItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_Table_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
    }
}
