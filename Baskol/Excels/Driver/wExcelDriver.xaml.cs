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

namespace Baskol.Excels.Driver
{
    /// <summary>
    /// Interaction logic for wExcelDriver.xaml
    /// </summary>
    public partial class wExcelDriver : RadWindow
    {
        public wExcelDriver()
        {
            InitializeComponent();
        }
        private System.Data.DataTable data;
        private List<SabtDriver> lstsabtDrivers;
        private void btnExcel_Click()
        {
            lstsabtDrivers = new List<MyDB.BusinessLayer.Models.SabtDriver>();
            var quni = lstsabtDrivers;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "xlsx Files|*.xlsx|xls Files |*.xls";
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
            {
                data = new System.Data.DataTable();
                data.TableName = "تعریف راننده";
                data = clsExcel.InportToExcel(fileDialog.FileName, 7);
                var q = (from i in data.AsEnumerable()
                         select new MyDB.BusinessLayer.Models.SabtDriver
                         {
                             DriverAddress = i.Field<string>("C6"),
                             DriverCode =long.Parse( i.Field<string>("C1")),
                             DriverCodeMeli = i.Field<string>("C5"),
                             DriverName = i.Field<string>("C2"),
                             DriverDesc = i.Field<string>("C7"),
                             DriverPNumber = i.Field<string>("C4"),
                             DriverTagNumber = i.Field<string>("C3"),
                             
                         }).ToList();

                lstsabtDrivers.AddRange(q);
            }
            dgv_loaded();
        }
        private void dgv_loaded()
        {
            Dispatcher.Invoke(() =>
            {
                dgv.AutoGenerateColumns = false;
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstsabtDrivers;
            });
        }
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
        private void btnSabt_Click()
        {
            var save =( from i in lstsabtDrivers
                       select new SabtDriver
                       {
                           DriverAddress = i.DriverAddress,
                           DriverCode = i.DriverCode,
                           DriverCodeMeli = i.DriverCodeMeli,
                           DriverDateTime = new ClsDateTime().DateTime(),
                           DriverDesc = i.DriverDesc,
                           DriverEnable = true,
                           DriverName = i.DriverName,
                           DriverPNumber = i.DriverPNumber,
                           DriverPuUser = ClsUsersLogin.User.AccountPuID,
                           DriverTagNumber = i.DriverTagNumber
                       }).ToList();
            ClsDB<SabtDriver>.BulkInsert(save);
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
