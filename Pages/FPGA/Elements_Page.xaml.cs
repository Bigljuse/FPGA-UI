using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Tables;
using FPGA_UI.Elements.FPGA;
using MySqlLibrary.MySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPGA_UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для Elements_Page.xaml
    /// </summary>
    public partial class Elements_Page : Page
    {
        private readonly FPGAManager p_FPGAManager;
        private readonly FPGATableManager p_ButtonsTableManager;
        private readonly FPGATableManager p_TogglesTableManager;

        public Elements_Page()
        {
            InitializeComponent();
            DataContext = this;

            p_FPGAManager = new FPGAManager();
            p_ButtonsTableManager = p_FPGAManager.GetTableManager(DataBases.FPGA.Enums.FPGATables.Button);
            p_TogglesTableManager = p_FPGAManager.GetTableManager(DataBases.FPGA.Enums.FPGATables.Toggle);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Toggles.Clear();
            Buttons.Clear();

            List<object> buttons = p_ButtonsTableManager.SQLSelectAllColumns(5);
            List<object> toggles = p_TogglesTableManager.SQLSelectAllColumns(16);

            Toggles = ConvertObjectToTableType<Toggle>(toggles);
            Buttons = ConvertObjectToTableType<DataBases.FPGA.Tables.Button>(buttons);
        }

        private List<T> ConvertObjectToTableType<T>(List<object> lines) where T : IFPGATable
        {
            List<T> newLines = new List<T>();

            foreach(object line in lines)
            {
                newLines.Add((T)line);
            }

            return newLines;
        }
    }
}
