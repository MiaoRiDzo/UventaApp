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
using UventaApp.Resources.Classes;
using UventaApp.Resources.Dictionarys;

namespace UventaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        bool btnState = false;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLoign.Text) || !string.IsNullOrEmpty(tbPass.Text))
            {
                btnAuth.Content = "Войти";
                btnState = true;
            }
            else
            {
                btnAuth.Content = "Войти как гость";
                btnState = false;
            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (btnState)
            {
                AuthUser authUser = new AuthUser();
                List<User> users = UventaArendaEntities.getContext().User.ToList();
                foreach (User user in users)
                {
                    if (user.Login == tbLoign.Text)
                    {
                        authUser.Name = user.FullName;
                        authUser.Password = user.Password;
                        authUser.Role = user.Role.RoleName;
                        break;
                    }
                }
                if (authUser.Name == null) { MessageBox.Show("Не верный логин"); }
                if (authUser != null)
                {
                    if (authUser.Password == tbPass.Text)
                    {
                        mWindow win = new mWindow(authUser);
                        win.Show();
                        this.Close();
                    }
                    else if (authUser.Password != tbPass.Text) { MessageBox.Show("Не верный пароль"); }
                }
            }
        }

    }
}
