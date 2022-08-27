using Baskol.Excels.Driver;
using MyDB.BusinessLayer;
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

namespace Baskol.WinSabtDriver
{
    /// <summary>
    /// Interaction logic for WinSabtDriver.xaml
    /// </summary>
    public partial class WinSabtDriver : UserControl
    {
        public WinSabtDriver()
        {
            InitializeComponent();
        }
        private MyDB.BusinessLayer.Models.SabtDriver SabtDriver;
        int DriverPuID;
        private List<MyDB.BusinessLayer.Models.SabtDriver> lstSabtDriver;
        private List<MyDB.BusinessLayer.Models.Car> a;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lstSabtDriver = ClsDB<MyDB.BusinessLayer.Models.SabtDriver>.GetAll();
           var a = ClsDB<MyDB.BusinessLayer.Models.Car>.GetAll();
            Dispatcher.Invoke(() =>
            {
                comcar.ItemsSource = null;
                comcar.ItemsSource = a;
            });
            dgv_Loaded();
            
        }

        private void dgv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void dgv_Loaded()
        {
            lstSabtDriver = ClsDB<MyDB.BusinessLayer.Models.SabtDriver>.GetAll();
            Dispatcher.Invoke(() =>
            {
                dgv.AutoGenerateColumns = false;
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstSabtDriver;

            });
        }
        private void btnSabt_Click(object sender, RoutedEventArgs e)
        {
            if (DriverPuID == 0)
            {
                Dispatcher.Invoke(() =>
                {
                    SabtDriver = new MyDB.BusinessLayer.Models.SabtDriver()
                    {
                        DriverName = TxtDriver.Text,
                        DriverCodeMeli = Txtcodemeli.Text,
                        DriverPNumber = TxtPhoneNumber.Text,
                        DriverTagNumber = TxtTagNumber.Text,
                        DriverCode = int.Parse(TxtCodeDriver.Text),
                        CarPuID = int.Parse(comcar.SelectedValue.ToString()),
                        DriverDesc = TxtDes.Text,
                        DriverAddress = TxtAdress.Text,
                    };
                });

                ClsDB<MyDB.BusinessLayer.Models.SabtDriver>.Insert(SabtDriver);
            }
            else
            {
                SabtDriver = lstSabtDriver.First(f => f.CarPuID == SabtDriver.DriverPuID);
                SabtDriver.DriverName = TxtDriver.Text;
                SabtDriver.DriverCodeMeli = Txtcodemeli.Text;
                SabtDriver.DriverPNumber = TxtPhoneNumber.Text;
                SabtDriver.DriverTagNumber = TxtTagNumber.Text;
                SabtDriver.DriverCode = int.Parse(TxtCodeDriver.Text);
                SabtDriver.CarPuID = int.Parse(comcar.SelectedValue.ToString());
                SabtDriver.DriverDesc = TxtDes.Text;
                SabtDriver.DriverAddress = TxtAdress.Text;

                ClsDB<MyDB.BusinessLayer.Models.SabtDriver>.Update(SabtDriver);
            }
            dgv_Loaded();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TxtAdress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comUnit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            new wExcelDriver().ShowDialog();
            dgv_Loaded();
        }
    }
}
