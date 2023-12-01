using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA_UI.Authorization
{
    public static class Account
    {
        private static AccountModel p_CurrentAccount = new AccountModel();
        private static Dictionary<string, AccountModel> p_Accounts = new()
        {
            {"Banana", new AccountModel(){ Login = "Banana", Password="123456789", Administrator = true, Name="Banana Name" } },
            {"", new AccountModel(){ Login = "", Password="", Administrator = false, Name="Unauthorized" } },
            {"User limited", new AccountModel(){ Login = "User", Password="1", Administrator = false, Name="User limited" } }
        };

        public delegate void UserAuthorizedDelegate(AccountModel accountModel);
        public static event UserAuthorizedDelegate UserAuthorized = new((accountModel) => { });

        public delegate void AuthorizationFailedDelegate(string login);
        public static event AuthorizationFailedDelegate AuthorizationFailed = new((login) => { });

        static Account()
        {
            p_CurrentAccount = p_Accounts[""];
        }

        public static void Authorize(string login, string password)
        {
            AccountModel? accountModel;
            p_Accounts.TryGetValue(login, out accountModel);

            if (accountModel is null)
            {
                AuthorizationFailed.Invoke(login);
                return;
            }

            if (accountModel.Password == password)
            {
                p_CurrentAccount = accountModel;
                UserAuthorized.Invoke(accountModel);
                return;
            }

            AuthorizationFailed.Invoke(login);
        }

        public static string GetName()
        {
            return p_CurrentAccount.Name;
        }
    }
}
