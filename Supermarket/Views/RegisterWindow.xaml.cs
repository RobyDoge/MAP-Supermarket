using Supermarket.ViewModels;
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
using System.Windows.Shapes;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        LoginVM LoginVm = new();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            if (chbIsAdmin.IsChecked == null) return;
            var type = (bool)chbIsAdmin.IsChecked ? "true" : "false";
            LoginVm.LoginInfo =[ tbUsername.Text, tbPassword.Text,type ];
            LoginVm.RegisterCommand.Execute(LoginVm.LoginInfo);
            OpenWindow();
            
            
        }

        private void btnReturnLoginClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            Close();
        }

        private void OpenWindow()
        {
            LoginVm.LoginCommand.Execute(LoginVm.LoginInfo);
            switch (LoginVm.Type[0])
            {
                case "admin":
                    AdminWindow adminWindow = new();
                    adminWindow.Show();
                    Close();
                    break;
                case "cashier":
                    CashierWindow cashierWindow = new(tbUsername.Text);
                    cashierWindow.Show();
                    Close();
                    break;
                default:
                    MessageBox.Show("Invalid username or password");
                    break;
            }
        }
        
    }
}
