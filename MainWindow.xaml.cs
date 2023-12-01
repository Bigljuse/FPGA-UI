using FPGA_UI.DataBases.FPGA;
using FPGA_UI.Pages;
using FPGA_UI.Pages.Authorization;
using FPGA_UI.Pages.Database_Editor;
using FPGA_UI.Pages.Default;
using System.Windows;

namespace FPGA_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FPGAManager p_fpgaManager;
        private Page_TableEditor? p_Page_TableEditor = null;
        private Page_Authorization? p_Page_Authorization = null;
        private Elements_Page? p_Elements_Page = null;

        public MainWindow()
        {
            InitializeComponent();
            //p_fpgaManager = new FPGAManager();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ShowDataBaseEditor_Click(object sender, RoutedEventArgs e)
        {
            if (p_Page_TableEditor is null)
                p_Page_TableEditor = new Page_TableEditor();

            NavigationWindow_Pages.Navigate(p_Page_TableEditor);
        }

        private void Button_ShowDataInUI_Click(object sender, RoutedEventArgs e)
        {
            if (p_Elements_Page is null)
                p_Elements_Page = new Elements_Page();

            NavigationWindow_Pages.Navigate(p_Elements_Page);
        }

        private void Button_ShowUART_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (p_Page_Authorization is null)
                p_Page_Authorization = new Page_Authorization();

            NavigationWindow_Pages.Navigate(p_Page_Authorization);
        }
    }
}
