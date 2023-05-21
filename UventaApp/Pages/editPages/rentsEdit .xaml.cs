using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
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
    public partial class rentsEdit : Page
    {
        mWindow mWindow;
        private Rent _current = new Rent();
        
        public rentsEdit(mWindow mWindow, Rent _selected)
        {
            InitializeComponent();
            if(_selected != null)
            {
                _current = _selected;
            }
            this.mWindow = mWindow;
            DataContext = _current;

            cbFName.ItemsSource = UventaArendaEntities.getContext().Tenant.ToList();
            cbONum.ItemsSource = UventaArendaEntities.getContext().RentalObject.ToList();
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            mWindow.mFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err = new StringBuilder();
            //Проверка ввода данных
            if (cbFName == null) { err.AppendLine("Не выбран арендатор"); }
            if (cbONum == null) { err.AppendLine("Не выбрано помещение"); }
            if (startdate.SelectedDate ==null) { err.AppendLine("Не выбрана дата начала договора"); }
            if(enddate.SelectedDate == null) { err.AppendLine("Не выбрана дата окончания договора"); }
            if(err.Length>0)
            {
                MessageBox.Show(err.ToString());
                return;
            }


            if (_current.RentId >= 0)
            {

                _current.ContractCreationDate = DateTime.Now;
                _current.ContractStartDate = startdate.SelectedDate.Value;
                _current.ContractEndDate = enddate.SelectedDate.Value;

                Tenant tenant = (Tenant)cbFName.SelectedValue;
                _current.TenantId = tenant.TenantId;
                RentalObject building = (RentalObject)cbONum.SelectedValue;
                _current.RentalObjectId = building.RentalObjectId;

                UventaArendaEntities.getContext().Rent.AddOrUpdate(_current);
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
    }
}
