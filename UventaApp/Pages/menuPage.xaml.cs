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

namespace UventaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для menuPage.xaml
    /// </summary>
    public partial class menuPage : Page
    {
        mWindow mWindow;
        public menuPage(mWindow _win)
        {
            mWindow = _win;
            InitializeComponent();

            //Проверка на роли
            if(mWindow.authUser.Role == "Менеджер") userButton.Visibility = Visibility.Collapsed;
            if (mWindow.authUser.Role == "Директор") { userButton.Visibility = Visibility.Collapsed; buildsButton.Visibility = Visibility.Collapsed; tenantsButton.Visibility = Visibility.Collapsed; }
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.tablesPage.usersPage(mWindow));
        }

        private void tenantsButton_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.tablesPage.tenantsPage(mWindow));
        }

        private void rentalsButton_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.tablesPage.rentsPage(mWindow));

        }

        private void buildsButton_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.tablesPage.objectsPage(mWindow));
        }
    }
}
