using Baskol.Update.Customer;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Cyber.Models;
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

namespace Baskol.Update
{
    /// <summary>
    /// Interaction logic for wUpdateCustomer.xaml
    /// </summary>
    public partial class wUpdateCustomer : UserControl
    {
        public wUpdateCustomer()
        {
            InitializeComponent();
        }
        private List<MyDB.BusinessLayer.Models.SabtCustomer> lstCustomer, lstInsert;
        private List<MyDB.BusinessLayer.Models.Cyber> lstCyber;
        private List<AC_0602_N> lstbCustom;
        private List<ClsCustomer> lstUpCustomer;
        private ClsCustomer Cus;
        private MyDB.BusinessLayer.Models.SabtCustomer s;
        private long _count, c, _darsad, _long;
        private int max;
        private object obj;
        private string dore, state, country, city, add, add2;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            clsMessageBox.MessageBoxSubject = clsMessageBox.QustionUpdate;
            new WinYesOrNo ().ShowDialog();
            if (clsMessageBox.Ok)
            {
                LoadingBusyIndicator.BusyContent = clsMessageBox.Update + "\n 0%";
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnSave_Click();
                worker.RunWorkerCompleted += (s, ev) => btnSave_Complated();
                worker.RunWorkerAsync();
            }
            Cursor = Cursors.Arrow;
        }
        private void btnSave_Complated()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
        }
        private void btnSave_Click()
        {
            _count = lstUpCustomer.Where(w => !w.Save).Count();
            c = 0;
            lstInsert.Clear();
            foreach (var i in lstUpCustomer.Where(w => !w.Save ))
            {
                s = new MyDB.BusinessLayer.Models.SabtCustomer()
                {
                    CustomerAdress = i.CustomerAdress,
                    CustomerDateTime = new ClsDateTime().DateTime(),
                    CustomerCode = i.CustomerCode,
                    CustomerPuUser = ClsUsersLogin.User.AccountPuID,
                    CustomerCodeMeli = i.CustomerCodeMeli,
                    CustomerDesc = i.CustomerDesc,
                    CustomerAccountNumber1 = i.CustomerAccountNumber1,
                    CustomerName = i.CustomerName,
                    CustomerTel = i.CustomerTel,
                    
                };
                c++;
                _darsad = (c * 100) / _count;

                lstInsert.Add(s); 
                Dispatcher.Invoke(() =>
                {
                    LoadingBusyIndicator.BusyContent = clsMessageBox.Update + "\n " + "%" + _darsad;
                });
                i.Save = true;
            }
            if (lstInsert.Count > 0)
                ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.BulkInsert(lstInsert);
            dgv_Loaded();
            clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullUpdate;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadingBusyIndicator.BusyContent = clsMessageBox.Load + "\n 0%";
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => btnSearch_Click();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
        }
        private void btnSearch_Click()
        {
            _count = lstbCustom.Count;
            c = 0;
            lstUpCustomer.Clear();

            foreach (var i in lstbCustom)
            {
                Cus = new ClsCustomer();
          
                Cus.CustomerAdress = add2;
                Cus.CustomerCode = ++max;
                Cus.CustomerCodeMeli = string.IsNullOrEmpty(i.MelliCode) ? "" : i.Mobile;
                Cus.CustomerDateTime = new ClsDateTime().DateTime();
                Cus.CustomerDesc = i.accprompt;
                Cus.CustomerName = i.JobName;
                Cus.CustomerAccountNumber1 = i.JobNumber;
                Cus.CustomerTel = string.IsNullOrEmpty(i.Mobile) ? "" : i.Mobile;

                if (string.IsNullOrEmpty(i.JobNumber))
                {
                    Cus.CustomerCode = -1;
                    Cus.Save = false;
                    Cus.SaveStr = "ثبت نشده";
                }
                if (lstCustomer.Count(c => c.CustomerAccountNumber1 == i.JobNumber) == 0)
                {
                    Cus.Save = false;
                    Cus.SaveStr = "ثبت نشده";
                }

                else
                {
                    Cus.SaveStr = "ثبت شده";
                    Cus.Save = true;
                }
                lstUpCustomer.Add(Cus);

                c++;
                _darsad = (c * 100) / _count;
                Dispatcher.Invoke(() =>
                {
                    LoadingBusyIndicator.BusyContent = clsMessageBox.Load + "\n " + "%" + _darsad;
                });
            }
            dgv_Loaded();
        }
 
        private void dgv_Loaded()
        {
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstUpCustomer;
            });
        }
        private void UserControl_Loaded()
        {
            lstCustomer = ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.GetAll();
            lstCyber = ClsDB<MyDB.BusinessLayer.Models.Cyber>.GetAllBy("CyberSelect",true);
            max = ClsDB<MyDB.BusinessLayer.Models.SabtCustomer>.GetAllByMax("CustomerCode");
            if (lstCyber.First().CyberDore.ToString().Length == 1)
                dore = "0" + lstCyber.First().CyberDore;
            else
                dore = lstCyber.First().CyberDore.ToString();
            MyDB.BusinessLayer.Cyber.ConnectionString.myConnection = "Data Source=" + lstCyber.First().CyberServer + ";Initial Catalog=CY" + lstCyber.First().CyberKholase + dore + ";User ID=" + lstCyber.First().CyberUsername + ";Password=" + Crypt.Decrypt(lstCyber.First().CyberPassword) + ";MultipleActiveResultSets=true;";
            lstbCustom = MyDB.BusinessLayer.Cyber.ClsDB<AC_0602_N>.GetAll();
            lstInsert = new List<MyDB.BusinessLayer.Models.SabtCustomer>();
            lstUpCustomer = new List<ClsCustomer>();
            Dispatcher.Invoke(() =>
            {
                dgv.AutoGenerateColumns = false;
            });
            
            dgv_Loaded();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => UserControl_Loaded();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
            Cursor = Cursors.Arrow;



        }
    }
}
