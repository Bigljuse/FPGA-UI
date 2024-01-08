using FPGA_UI.DataBases;
using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Enums;
using FPGA_UI.DataBases.FPGA.Tables;
using MySqlLibrary.MySql.Models;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FPGA_UI.Pages
{
    /// <summary>
    /// Interaction logic for Page_Database_Editor.xaml
    /// </summary>
    public partial class Page_Table_Editor : Page
    {
        private readonly FPGAManager p_fpgaManager;
        private FPGATableManager p_fpgaTableManager;
        private List<int> p_EditedRowsId = new();
        private List<object> p_DataGridSource = new();

        private readonly Timer timer = new Timer(1500)
        {
            AutoReset = false
        };

        internal Page_Table_Editor(FPGAManager fpgaManager)
        {
            InitializeComponent();
            p_fpgaManager = fpgaManager;
            DataContext = this;
            p_fpgaTableManager = p_fpgaManager.GetTableManager(Table);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            p_fpgaManager.UseDataBase();
            p_fpgaTableManager = p_fpgaManager.GetTableManager(Table);
            Rectangle_Status.Visibility = Visibility.Hidden;
        }

        private void Button_UpdateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if (p_EditedRowsId.Count > 0)
            {
                foreach (IFPGATable line in p_DataGridSource)
                {
                    int id = Convert.ToInt32(line.GetPropertyValueByName("Id"));
                    if (p_EditedRowsId.Contains(id) == true)
                    {
                        int linesAffected = p_fpgaTableManager.SQLUpdateLine(line);
                        if (linesAffected > 0)
                            SetStatus(true);
                        else
                            SetStatus(false);
                    }
                }
            }
            p_DataGridSource = p_fpgaTableManager.SQLSelectAllColumns();
            p_EditedRowsId.Clear();
            DataGrid_Table.ItemsSource = p_DataGridSource;
        }

        private void Button_AddItem_Click(object sender, RoutedEventArgs e)
        {
            IFPGATable? table = null;

            if (Table == FPGATables.Bluetooth)
                table = new Bluetooth();
            if (Table == FPGATables.Button)
                table = new DataBases.FPGA.Tables.Button();
            if (Table == FPGATables.Device)
                table = new Device();
            if (Table == FPGATables.Port)
                table = new Port();
            if (Table == FPGATables.Temperature_Module)
                table = new Temperature_Module();
            if (Table == FPGATables.Toggle)
                table = new Toggle();
            if (Table == FPGATables.UART)
                table = new UART();

            if (table is not null)
            {
                p_fpgaTableManager.SQLInsertLine(table);
                Button_UpdateDataGrid_Click(sender, e);
            }

            SetStatus(true);
        }

        private void DataGrid_Table_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            IFPGATable item = (IFPGATable)e.Row.BindingGroup.Items[0];
            int ItemId = Convert.ToInt32(item.GetPropertyValueByName("Id"));

            if (p_EditedRowsId.Contains(ItemId) == false)
                p_EditedRowsId.Add(ItemId);
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Table.SelectedItem is null)
                return;

            IFPGATable table = (IFPGATable)DataGrid_Table.SelectedItem;
            p_fpgaTableManager.SQLDeleteLine(table);
            p_DataGridSource.Remove(table);
            Button_UpdateDataGrid_Click(sender, e);
            Rectangle_Status.Visibility = Visibility.Visible;
            timer.Start();
        }

        private void SetStatus(bool status)
        {
            if(status == true)
                Rectangle_Status.Fill = Brushes.Green;
            else
                Rectangle_Status.Fill = Brushes.Red;

            Rectangle_Status.Visibility = Visibility.Visible;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Rectangle_Status.Visibility = Visibility.Hidden;
            });
        }
    }
}
