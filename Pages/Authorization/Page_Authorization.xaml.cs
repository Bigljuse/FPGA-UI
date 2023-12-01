using FPGA_UI.Authorization;
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
    /// Логика взаимодействия для Page_Authorization.xaml
    /// </summary>
    public partial class Page_Authorization : Page
    {
        public Page_Authorization()
        {
            InitializeComponent();

            Account.AuthorizationFailed += Account_AuthorizationFailed;
            Account.UserAuthorized += Account_UserAuthorized;
        }

        private void Button_Authorize_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text;
            string password = TextBox_Password.Text;
            Account.Authorize(login, password);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Rectangle_LoginIndicator.Visibility = Visibility.Collapsed;
            Grid_ErrorMessage.Visibility = Visibility.Collapsed;
        }

        private void Account_UserAuthorized(AccountModel accountModel)
        {
            Grid_ErrorMessage.Visibility = Visibility.Collapsed;
            Rectangle_LoginIndicator.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00DC00");
            Rectangle_LoginIndicator.Visibility = Visibility.Visible;
        }

        private void Account_AuthorizationFailed(string login)
        {
            Grid_ErrorMessage.Visibility = Visibility.Visible;
            Rectangle_LoginIndicator.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDC0000");
            Rectangle_LoginIndicator.Visibility = Visibility.Visible;
        }
    }
}
