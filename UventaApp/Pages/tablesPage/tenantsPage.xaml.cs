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
    /// Логика взаимодействия для tenantsPage.xaml
    /// </summary>
    public partial class tenantsPage : Page
    {
        mWindow mWindow;
        public tenantsPage(mWindow mWindow)
        {
            InitializeComponent();
            this.mWindow = mWindow;
            dgTenant.ItemsSource = UventaArendaEntities.getContext().Tenant.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.tenantsEdit(mWindow, null));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.tenantsEdit(mWindow, (sender as Button).DataContext as Tenant));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UventaArendaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgTenant.ItemsSource = UventaArendaEntities.getContext().Tenant.ToList();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var removes = dgTenant.SelectedItems.Cast<Tenant>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?" , "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UventaArendaEntities.getContext().Tenant.RemoveRange(removes);
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dgTenant.ItemsSource = UventaArendaEntities.getContext().Tenant.ToList();
                }catch(Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }
    }
}
