using FPGA_UI.DataBases;
using FPGA_UI.DataBases.FPGA;
using FPGA_UI.DataBases.FPGA.Tables;
using MySqlLibrary;
using System.Windows;

namespace FPGA_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Change_Colour_Click(object sender, RoutedEventArgs e)
        {
            string dataBaseName = DataBasesNamesEnum.FPGA.ToString();

            MySqlDBConfiguration mySqlDBConfiguration = new MySqlDBConfiguration("server=localhost;user=root;port=3306;password=(E132450qwe)");
            //mySqlDBConfiguration.ReCreateDataBase(dataBaseName);
            mySqlDBConfiguration.UseDataBase(dataBaseName);

            FPGATablesConfiguration fPGATablesConfiguration = new FPGATablesConfiguration(mySqlDBConfiguration);
            fPGATablesConfiguration.CreateTablesIfNotExist();

            FPGATablesMethods fPGATablesMethods = new FPGATablesMethods(mySqlDBConfiguration, FPGATablesEnum.Port);
            fPGATablesMethods.InsertLine(new Port() { Device_Type = "Poka", Power_State = true });
        }
    }
}
