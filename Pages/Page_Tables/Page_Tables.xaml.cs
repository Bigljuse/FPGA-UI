using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Enums;
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
    /// Логика взаимодействия для Page_Tables.xaml
    /// </summary>
    public partial class Page_Tables : Page
    {
        private readonly FPGAManager p_FPGAManager;

        public Page_Tables()
        {
            InitializeComponent();
            p_FPGAManager = new FPGAManager();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Frame_Port_Loaded(object sender, RoutedEventArgs e)
        {
            SetFrameTable(Frame_Port,FPGATables.Port);
        }

        private void Frame_Device_Loaded(object sender, RoutedEventArgs e)
        {
            SetFrameTable(Frame_Device, FPGATables.Device);
        }

        private void Frame_Button_Loaded(object sender, RoutedEventArgs e)
        {
            SetFrameTable(Frame_Button, FPGATables.Button);
        }

        private void Frame_Bluetooth_Loaded(object sender, RoutedEventArgs e)
        {
            SetFrameTable(Frame_Bluetooth, FPGATables.Bluetooth);
        }

        private void Frame_Toggle_Loaded(object sender, RoutedEventArgs e)
        {
            SetFrameTable(Frame_Toggle, FPGATables.Toggle);
        }

        private void Frame_Temperature_Loaded(object sender, RoutedEventArgs e)
        {
            SetFrameTable(Frame_Temperature, FPGATables.Temperature_Module);
        }
    }
}
