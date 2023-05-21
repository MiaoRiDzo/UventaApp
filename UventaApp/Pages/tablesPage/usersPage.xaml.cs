using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для usersPage.xaml
    /// </summary>
    public partial class usersPage : Page
    {
        mWindow mWindow;
        public usersPage(mWindow mWindow)
        {
            InitializeComponent();
            this.mWindow = mWindow;
            dgUsers.ItemsSource = UventaArendaEntities.getContext().User.ToList();
            cbRole.ItemsSource = UventaArendaEntities.getContext().Role.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.usersEdit(null,mWindow));
        }

        private void btnRole_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.tablesPage.rolesPage(mWindow));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.Navigate(new Pages.editPages.usersEdit((sender as Button).DataContext as User, mWindow));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var removes = dgUsers.SelectedItems.Cast<User>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UventaArendaEntities.getContext().User.RemoveRange(removes);
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dgUsers.ItemsSource = UventaArendaEntities.getContext().User.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UventaArendaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dgUsers.ItemsSource = UventaArendaEntities.getContext().User.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(srUserName.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<User> list = dgUsers.ItemsSource as List<User>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = srUserName.Text; // Получаем текст из TextBox
                    List<User> filteredList = list.FindAll(user => user.FullName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    dgUsers.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                dgUsers.ItemsSource = UventaArendaEntities.getContext().User.ToList();
            }
        }

        private void srUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRole.SelectedIndex != -1)
            {
                List<User> userList = UventaArendaEntities.getContext().User.ToList();
                Role role= cbRole.SelectedItem as Role;
                userList = userList.FindAll(x => x.Role.RoleName == role.RoleName);
                dgUsers.ItemsSource = userList;
            }
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            cbRole.SelectedIndex = -1;
            srUserName.Text = string.Empty;
            dgUsers.ItemsSource = UventaArendaEntities.getContext().User.ToList();
        }
    }
}
