using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace UventaApp.Pages.editPages
{
    /// <summary>
    /// Логика взаимодействия для usersEdit.xaml
    /// </summary>
    public partial class usersEdit : Page
    {
        mWindow mWindow;
        private User _current = new User();
        public usersEdit(User current, mWindow mWindow)
        {
            InitializeComponent();
            if (current != null) _current = current;
            this.mWindow = mWindow;
            DataContext = _current;
            cbRole.ItemsSource = UventaArendaEntities.getContext().Role.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(entName.Text)) errors.AppendLine("Не указано имя");
            if (string.IsNullOrEmpty(entLogin.Text)) errors.AppendLine("Не указана фамилия");
            if (string.IsNullOrEmpty(entPass.Text)) errors.AppendLine("Не указанномер телефона");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_current.UserId >= 0)
            {
                Role role = cbRole.SelectedItem as Role;
                _current.RoleId = role.RoleId;


                UventaArendaEntities.getContext().User.AddOrUpdate(_current);
                try
                {
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    mWindow.mFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.GoBack();
        }
    }
}

