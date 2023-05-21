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
using UventaApp.Resources.Classes;

namespace UventaApp
{
    /// <summary>
    /// Логика взаимодействия для mWindow.xaml
    /// </summary>
    public partial class mWindow : Window
    {
        public AuthUser authUser;        
        public mWindow(AuthUser _auth)
        {
            this.authUser = _auth;
            InitializeComponent();
            lbUserName.Content += authUser.Name;
            mFrame.Navigate(new Pages.menuPage(this));
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mFrame.GoBack();
            }catch { }
        }

        private void mainBtn_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new Pages.menuPage(this));
        }

        private void authBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сменить пользователя?", authUser.Name, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
