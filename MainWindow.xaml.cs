using FPGA_UI.Authorization;
using FPGA_UI.DataBases.FPGA;
using FPGA_UI.Pages;
using System.Windows;

namespace FPGA_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page_Tables? p_Page_TableEditor = null;
        private Page_Authorization? p_Page_Authorization = null;
        private Page_UART? p_Page_UART = null;
        private Elements_Page? p_Elements_Page = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Account.UserAuthorized += Account_UserAuthorized;
            Account.Authorize("Banana", "123456789");
        }

        private void Account_UserAuthorized(AccountModel accountModel)
        {
            if (accountModel.Administrator == true)
            {
                Button_ShowUART.IsEnabled = true;
                Button_ShowDataBaseEditor.IsEnabled = true;
            }
            else
            {
                Button_ShowUART.IsEnabled = false;
                Button_ShowDataBaseEditor.IsEnabled = false;
            }

            UserProfile_TopRight.UserName = Account.GetName();
        }

        private void Button_ShowDataBaseEditor_Click(object sender, RoutedEventArgs e)
        {
            if (p_Page_TableEditor is null)
                p_Page_TableEditor = new Page_Tables();

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
            if (p_Page_UART is null)
                p_Page_UART = new Page_UART();

            NavigationWindow_Pages.Navigate(p_Page_UART);
        }

        private void Button_Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (p_Page_Authorization is null)
                p_Page_Authorization = new Page_Authorization();

            NavigationWindow_Pages.Navigate(p_Page_Authorization);
        }
    }
}
