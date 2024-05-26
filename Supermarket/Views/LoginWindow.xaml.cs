
using System.Windows;
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginVM LoginVm = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButtonClicked(object sender, RoutedEventArgs e)
        {
            LoginVm.LoginInfo = [tbUsername.Text, tbPassword.Text];
            LoginVm.LoginCommand.Execute(LoginVm.LoginInfo);
            switch (LoginVm.Type[0])
            {
                case "admin":
                    AdminWindow adminWindow = new();
                    adminWindow.Show();
                    Close();
                    break;
                case "cashier":
                    CashierWindow cashierWindow = new();
                    cashierWindow.Show();
                    Close();
                    break;
                default:
                    MessageBox.Show("Invalid username or password");
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }
    }
}
