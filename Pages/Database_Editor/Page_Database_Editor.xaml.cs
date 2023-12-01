using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Enums;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FPGA_UI.Pages.Database_Editor
{
    /// <summary>
    /// Interaction logic for Page_Database_Editor.xaml
    /// </summary>
    public partial class Page_Database_Editor : Page
    {
        private readonly FPGAManager p_fpgaManager;
        private FPGATableManager? p_fpgaTableManager;

        internal Page_Database_Editor(FPGAManager fpgaManager)
        {
            InitializeComponent();
            p_fpgaManager = fpgaManager;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_Tables.ItemsSource = Enum.GetNames(typeof(FPGATables));
        }

        private void Button_UpdateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_Tables.SelectedItem is null)
                return;

            string tableName = (string)ComboBox_Tables.SelectedItem;
            ReadOnlySpan<char> tableCharName = new(tableName.ToCharArray());
            FPGATables selectedTable = (FPGATables)Enum.Parse(typeof(FPGATables), tableCharName);

            p_fpgaTableManager = p_fpgaManager.GetTableManager(selectedTable);
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
