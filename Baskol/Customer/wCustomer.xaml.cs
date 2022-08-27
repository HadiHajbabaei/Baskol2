using Baskol.Excels.Customer;
using MyDB.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Baskol
{
    /// <summary>
    /// Interaction logic for wCustomer.xaml
    /// </summary>
    public partial class wCustomer : UserControl
    {
        public wCustomer()
        {
            InitializeComponent();
        }
        private MyDB.BusinessLayer.Models.SabtCustomer SabtCustomer;
        private List<MyDB.BusinessLayer.Models.SabtCustomer> lstinsert, lstCustomer;
        long Pid, max;
        object obj;
        private void dgv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            obj = dgv.SelectedItem;
        }

        private void dgv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Pid = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerPuID;
                TxtCusAccountNumber.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerAccountNumber1;
                TxtCusAdress.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerAdress.ToString();
                TxtCusCode.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerCode.ToString();
                TxtCuscodemeli.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerCodeMeli.ToString();
                TxtCusDes.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerDesc.ToString();
                TxtCusName.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerName.ToString();
                TxtCusTel.Text = ((MyDB.BusinessLayer.Models.SabtCustomer)obj).CustomerTel.ToString();
            });

        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void btnSave_Com()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
            Getmax();
            dgv_loaded();
            Dispatcher.Invoke(() =>
            {
                TxtCusCode.Text = (max + 1).ToString();
                TxtCusDes.Text = "";
                TxtCusName.Text = "";
                TxtCusAccountNumber.Text = "";
                TxtCusAdress.Text = "";
                TxtCuscodemeli.Text = "";
                TxtCusTel.Text = "";
            });

        }
        private void btnSave_Click()
        {
            if (Pid == 0)
            {
                Dispatcher.Invoke(() =>
                {
                    SabtCustomer = new MyDB.BusinessLayer.Models.SabtCustomer()
                    {
                        CustomerAccountNumber1 = TxtCusAccountNumber.Text,
                        CustomerAdress = TxtCusAdress.Text,
                        CustomerCode = TxtCusCode.Text != string.Empty ? int.Parse(TxtCusCode.Text) : 0,
                        CustomerCodeMeli = TxtCuscodemeli.Text,
                        CustomerDateTime = new ClsDateTime().DateTime(),
                        CustomerDesc = TxtCusDes.Text,
                        CustomerName = TxtCusName.Text,
                        CustomerPuUser = ClsUsersLogin.User.AccountPuID,
                        CustomerTel = TxtCusTel.Text
                    };
                });

                ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.Insert(SabtCustomer);
            }
            else
            {
                SabtCustomer = lstCustomer.First(f => f.CustomerPuID == SabtCustomer.CustomerPuID);
                SabtCustomer.CustomerAccountNumber1 = TxtCusAccountNumber.Text;
                SabtCustomer.CustomerAdress = TxtCusAdress.Text;
                SabtCustomer.CustomerCode = TxtCusCode.Text != string.Empty ? int.Parse(TxtCusCode.Text) : 0;
                SabtCustomer.CustomerCodeMeli = TxtCuscodemeli.Text;
                SabtCustomer.CustomerDateTime = new ClsDateTime().DateTime();
                SabtCustomer.CustomerDesc = TxtCusDes.Text;
                SabtCustomer.CustomerName = TxtCusName.Text;
                SabtCustomer.CustomerPuUser = ClsUsersLogin.User.AccountPuID;
                SabtCustomer.CustomerTel = TxtCusTel.Text;

                ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.Update(SabtCustomer);
            }
            dgv_loaded();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCusName.Text != string.Empty && TxtCusAccountNumber.Text != string.Empty && TxtCuscodemeli.Text != string.Empty)
            {
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnSave_Click();
                worker.RunWorkerCompleted += (s, ev) => btnSave_Com();
                worker.RunWorkerAsync();
            }

        }
        private void Getmax()
        {
            max = ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.GetAllByMax("CustomerCode");
        }

        private void TxtAdress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSabt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            new wCustomerExcel().ShowDialog();
            dgv_loaded();
        }

        private void dgv_loaded()
        {
            lstCustomer = ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.GetAll();
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstCustomer;
            });
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dgv_loaded();
            Getmax();
            dgv.AutoGenerateColumns = false;
            lstinsert = new List<MyDB.BusinessLayer.Models.SabtCustomer>();
            Dispatcher.Invoke(() =>
            {
                TxtCusCode.Text = (max + 1).ToString();
                TxtCusDes.Text = "";
                TxtCusName.Text = "";
                TxtCusAccountNumber.Text = "";
                TxtCusAdress.Text = "";
                TxtCuscodemeli.Text = "";
                TxtCusTel.Text = "";
            });
        }
    }
}