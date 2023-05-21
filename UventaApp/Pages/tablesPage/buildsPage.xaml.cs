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
using UventaApp.Resources.Dictionarys;

namespace UventaApp.Pages.tablesPage
{
    /// <summary>
    /// Логика взаимодействия для buildsPage.xaml
    /// </summary>
    public partial class buildsPage : Page
    {
        mWindow mWindow;
        public buildsPage(mWindow mWindow)
        {
            InitializeComponent();
            this.mWindow = mWindow;
            dgUsers.ItemsSource = UventaArendaEntities.getContext().Building.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.buildsEdit((sender as Button).DataContext as Building, mWindow));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.buildsEdit(null, mWindow));
        }
    }
}
