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

namespace Baskol.Excels._ُSabt_mahsol
{
    /// <summary>
    /// Interaction logic for WsabtemahsolExcel.xaml
    /// </summary>
    public partial class WsabtemahsolExcel : RadWindow
    {
        public WsabtemahsolExcel()
        {
            InitializeComponent();
        }
        private System.Data.DataTable data;
        private List<SabtMahsol> lstsabtmahsol;
        private List<Vahed> vaheds;
        private void btnSave_Click(object sender, RoutedEventArgs e)
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

        private void btnexcel_Click(object sender, RoutedEventArgs e)
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
            lstsabtmahsol = new List<MyDB.BusinessLayer.Models.SabtMahsol>();
            var quni = lstsabtmahsol;
            var z = ClsDB<Vahed>.GetAllByMax("VahedPuID");
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "xlsx Files|*.xlsx|xls Files |*.xls";
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
            {
                data = new System.Data.DataTable();
                data.TableName = "تعریف محصول";
                data = clsExcel.InportToExcel(fileDialog.FileName, 3);
                var q = (from i in data.AsEnumerable()
                         select new MyDB.BusinessLayer.Models.SabtMahsol
                         {
                             SabtMahsolCod =int.Parse(i.Field<string>("C1")),
                             SabtMahsolName =i.Field<string>("C2"),
                             SabtMahsolDescription = i.Field<string>("C3"),
                          SabtMahsolVahed=z,

                         }).ToList();

               lstsabtmahsol.AddRange(q);
            }
            dgv_loaded();
        }
        private void dgv_loaded()
        {
            Dispatcher.Invoke(() =>
            {
                dgv.AutoGenerateColumns = false;
                dgv.ItemsSource = null;
                dgv.ItemsSource =lstsabtmahsol;
            });
        }
        private void btnSabt_Click()
        {
            
            var save = (from i in lstsabtmahsol
                        select new SabtMahsol
                        {
                            SabtMahsolCod = i.SabtMahsolCod,
                            SabtMahsolDescription =i.SabtMahsolDescription,
                            SabtMahsolName = i.SabtMahsolName,
                            SabtMahsoldatetime = new ClsDateTime().DateTime(),
                            SabtMahsolVahed=i.SabtMahsolVahed,
                            SabtMahsolPuUSER = ClsUsersLogin.User.AccountPuID,

                        }).ToList();
            ClsDB<SabtMahsol>.BulkInsert(save);
            Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }
     
    }
}
