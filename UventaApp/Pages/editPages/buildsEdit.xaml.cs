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
    /// Логика взаимодействия для buildsEdit.xaml
    /// </summary>
    public partial class buildsEdit : Page
    {
        mWindow win;
        bool newIns = true;

        private Building _current = new Building();
        public buildsEdit(Building current,mWindow mWindow)
        {
            InitializeComponent();
            if (current != null) { 
                _current  = current;
                newIns = false;
            }
            win = mWindow;
            DataContext = _current;
        }

        private static int getNextBuildingId(Building current)
        {
            int id = UventaArendaEntities.getContext().Building.ToList().Last().BuildingId;
            return id+1;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(entName.Text)) errors.AppendLine("Не введено наименование");
            if (string.IsNullOrEmpty(entAddress.Text)) errors.AppendLine("Не введен адрес");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            if (_current.BuildingId >= 0)
            {
                if (newIns) _current.BuildingId = getNextBuildingId(_current);
                
                UventaArendaEntities.getContext().Building.AddOrUpdate(_current);
                try
                {
                    UventaArendaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    win.mFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.GoBack();
        }
    }
}
