using Microsoft.Win32;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Telerik.Windows.Controls;

namespace Baskol.Excels.Customer
{
    /// <summary>
    /// Interaction logic for wCustomerExcel.xaml
    /// </summary>
    public partial class wCustomerExcel : RadWindow
    {
        public wCustomerExcel()
        {
            InitializeComponent();
        }
        private System.Data.DataTable data;
        private List <MyDB.BusinessLayer.Models.SabtCustomer> lstcustomer;
        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            LoadingBusyIndicator.BusyContent = clsMessageBox.Load;
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => btnExcel_Click();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }


        private void btnExcel_Click()
        {
            lstcustomer = new List<MyDB.BusinessLayer.Models.SabtCustomer>();
            var quni = lstcustomer;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "xlsx Files|*.xlsx|xls Files |*.xls";
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
            {
                data = new System.Data.DataTable();
                data.TableName = "تعریف مشتری";
                data = clsExcel.InportToExcel(fileDialog.FileName, 7);
                var q = (from i in data.AsEnumerable()
                         select new MyDB.BusinessLayer.Models.SabtCustomer
                         {
                             CustomerAdress = i.Field<string>("C6"),
                             CustomerCode = int.Parse(i.Field<string>("C1")),
                             CustomerName = i.Field<string>("C2"),
                             CustomerCodeMeli = i.Field<string>("C3"),
                              CustomerDesc = i.Field<string>("C7"),
                             CustomerAccountNumber1 = i.Field<string>("C4"),
                             CustomerTel = i.Field<string>("C5"),

                         }).ToList();

                lstcustomer.AddRange(q);
            }
            dgv_loaded();

        }
        private void dgv_loaded()
        {
            Dispatcher.Invoke(() =>
            {
                dgv.AutoGenerateColumns = false;
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstcustomer;
            });
        }
        private void btnSabt_Click()
        {
            var save = (from i in lstcustomer
                        select new SabtCustomer
                        {
                            CustomerAdress = i.CustomerAdress,
                            CustomerCode = i.CustomerCode,
                            CustomerCodeMeli = i.CustomerCodeMeli,
                            CustomerDateTime = new ClsDateTime().DateTime(),
                            CustomerDesc = i.CustomerDesc,
                            CustomerName = i.CustomerName,
                            CustomerPuUser = ClsUsersLogin.User.AccountPuID,
                            CustomerTel = i.CustomerTel
                            
                        }).ToList();
            ClsDB<SabtCustomer>.BulkInsert(save);
            Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }
            private void btnSabt_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            LoadingBusyIndicator.BusyContent = clsMessageBox.Load;
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => btnSabt_Click();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }
    }
}
