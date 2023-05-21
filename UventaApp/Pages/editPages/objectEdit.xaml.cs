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
    /// Логика взаимодействия для objectEdit.xaml
    /// </summary>
    public partial class objectEdit : Page
    {
        mWindow mWindow;
        private RentalObject _current = new RentalObject();
        bool newIns = true;
        public objectEdit(mWindow mWindow, RentalObject rent)
        {
            InitializeComponent();
            this.mWindow = mWindow;
            if (rent != null)
            {
                _current = rent;
                newIns = false;
            }
            DataContext = _current;
            cbBuild.ItemsSource = UventaArendaEntities.getContext().Building.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (cbBuild == null) { errors.AppendLine("Не выбрано здание"); }
            if (string.IsNullOrEmpty(entNum.Text)) { errors.AppendLine("Не введен номер"); }
            if (string.IsNullOrEmpty(entArea.Text)) { errors.AppendLine("Не введена площадь"); }
            if (string.IsNullOrEmpty(entPrice.Text)) { errors.AppendLine("Не введена цена"); }
            if (errors.Length > 0) { MessageBox.Show(errors.ToString()); return; }

            Building building = cbBuild.SelectedItem as Building;
            _current.BuildingId = building.BuildingId;
            if (_current.RentalObjectId >= 0)
            {
                //if (newIns)
                //{
                //    int i = UventaArendaEntities.getContext().RentalObject.ToList().Last().RentalObjectId;
                //    _current.RentalObjectId = i + 1;
                //}

                UventaArendaEntities.getContext().RentalObject.AddOrUpdate(_current);
                try
                {
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены");
                    mWindow.mFrame.GoBack();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
