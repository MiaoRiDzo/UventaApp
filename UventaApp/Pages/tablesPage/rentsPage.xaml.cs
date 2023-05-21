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
    /// Логика взаимодействия для rentsPage.xaml
    /// </summary>
    public partial class rentsPage : Page
    {
        mWindow mWindow;
        public rentsPage(mWindow mWindow)
        {
            InitializeComponent();
            this.mWindow = mWindow;
            dgRent.ItemsSource = UventaArendaEntities.getContext().Rent.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.rentsEdit(mWindow, null));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var removes = dgRent.SelectedItems.Cast<Rent>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UventaArendaEntities.getContext().Rent.RemoveRange(removes);
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dgRent.ItemsSource = UventaArendaEntities.getContext().Rent.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UventaArendaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dgRent.ItemsSource = UventaArendaEntities.getContext().Rent.ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.rentsEdit(mWindow, (sender as Button).DataContext as Rent));

        }
    }
}
