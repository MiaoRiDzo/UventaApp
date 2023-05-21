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
    /// Логика взаимодействия для tenantsEdit.xaml
    /// </summary>
    public partial class tenantsEdit : Page
    {
        mWindow mWindow;
        private Tenant _current = new Tenant();
        
        public tenantsEdit(mWindow mWindow, Tenant _selected)
        {
            InitializeComponent();
            if(_selected != null)
            {
                _current = _selected;
            }
            this.mWindow = mWindow;
            DataContext = _current;
            cbType.ItemsSource = UventaArendaEntities.getContext().RentalType.ToList();
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //Обработка данных
            if (string.IsNullOrEmpty(entName.Text)) errors.AppendLine("Не указано имя");
            if (string.IsNullOrEmpty(entLName.Text)) errors.AppendLine("Не указана фамилия");
            if (string.IsNullOrEmpty(entPhone.Text)) errors.AppendLine("Не указанномер телефона");
            if (string.IsNullOrEmpty(entEmail.Text)) errors.AppendLine("Не указана электронная почта");
            if (string.IsNullOrEmpty(entAdress.Text)) errors.AppendLine("Не указан адрес регистрации");
            if (string.IsNullOrEmpty(entSeries.Text)) errors.AppendLine("Не указана серия паспорта");
            if (string.IsNullOrEmpty(entName.Text)) errors.AppendLine("Не указан номер паспорта");
            if (cbType.SelectedItem == null) errors.AppendLine("Не выбран тип");
            //Сообщение об ошибке
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_current.TenantId >= 0)
            {
                RentalType type = cbType.SelectedItem as RentalType;
                _current.RentalTypeId = type.RentalTypeId;

                UventaArendaEntities.getContext().Tenant.AddOrUpdate(_current);
                try
                {
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    mWindow.mFrame.NavigationService.GoBack();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }   
    }
}
