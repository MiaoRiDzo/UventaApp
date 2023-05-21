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
    /// Логика взаимодействия для objectsPage.xaml
    /// </summary>
    public partial class objectsPage : Page
    {
        mWindow mWindow;
        public objectsPage(mWindow mWindow)
        {
            InitializeComponent();
            this.mWindow = mWindow;
            dgObjects.ItemsSource = UventaArendaEntities.getContext().RentalObject.ToList();
        }

        private void btnBilds_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.tablesPage.buildsPage(mWindow));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.objectEdit(mWindow,null));

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.objectEdit(mWindow, (sender as Button).DataContext as RentalObject));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var removes = dgObjects.SelectedItems.Cast<RentalObject>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UventaArendaEntities.getContext().RentalObject.RemoveRange(removes);
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dgObjects.ItemsSource = UventaArendaEntities.getContext().Tenant.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UventaArendaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgObjects.ItemsSource = UventaArendaEntities.getContext().RentalObject.ToList();
            }
        }
    }
}
