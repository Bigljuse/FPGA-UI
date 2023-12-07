using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для Page_UART.xaml
    /// </summary>
    public partial class Page_UART : Page
    {
        private readonly FPGAManager p_fpgaManager;
        private readonly FPGATableManager p_fpgaTableManager;

        private readonly Timer timer = new Timer(1500)
        {
            AutoReset = false
        };

        public Page_UART()
        {
            InitializeComponent();
            p_fpgaManager = new FPGAManager();
            DataContext = this;
            p_fpgaTableManager = p_fpgaManager.GetTableManager(DataBases.FPGA.Enums.FPGATables.UART);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Rectangle_Status.Visibility = Visibility.Hidden;
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Rectangle_Status.Visibility = Visibility.Hidden;
            UART? uart = p_fpgaTableManager.SQLSelectAllColumns().FirstOrDefault() as UART;

            if (uart is null)
                p_fpgaTableManager.SQLInsertLine(UART);
            else
                UART = uart;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p_fpgaTableManager.SQLUpdateLine(UART);
            Rectangle_Status.Visibility = Visibility.Visible;
            timer.Start();
        }
    }
}
