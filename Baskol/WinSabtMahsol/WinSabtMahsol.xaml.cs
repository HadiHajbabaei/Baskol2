using Baskol.Excels._ُSabt_mahsol;
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

namespace Baskol.WinSabtMahsol
{
    /// <summary>
    /// Interaction logic for WinSabtMahsol.xaml
    /// </summary>
    public partial class WinSabtMahsol : UserControl
    {
        public WinSabtMahsol()
        {
            InitializeComponent();
        }
        private MyDB.BusinessLayer.Models.SabtMahsol s1;
        private List<MyDB.BusinessLayer.Models.SabtMahsol> lstinsert, lstMahsol;
        private List<MyDB.BusinessLayer.Models.View_SabtMahsol> lstsabtMahsols;
        private List<MyDB.BusinessLayer.Models.Vahed> lstVahed;
        int Pid, max;
        object obj;
        private void dgv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            obj = dgv.SelectedItem;
        }

        private void dgv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {if(obj != null)
                {
                    Pid = ((MyDB.BusinessLayer.Models.View_SabtMahsol)obj).SabtMahsolPuID;
                    Txtdescription.Text = ((MyDB.BusinessLayer.Models.View_SabtMahsol)obj).SabtMahsolDescription;
                    Txtkodmahsol.Text = ((MyDB.BusinessLayer.Models.View_SabtMahsol)obj).SabtMahsolCod.ToString();

                    TxtNameMahsol.Text = ((MyDB.BusinessLayer.Models.View_SabtMahsol)obj).SabtMahsolName.ToString();
                    ComVahed.SelectedValue = ((MyDB.BusinessLayer.Models.View_SabtMahsol)obj).VahedPuID.ToString();
                }
        
            });

        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void btnSave_Com()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
            dgv_loaded();
            Dispatcher.Invoke(() =>
            {
                Txtkodmahsol.Text = (++max).ToString();
                Txtdescription.Text = "";
                TxtNameMahsol.Text = "";

                ComVahed.SelectedIndex = 0;
            });

        }
        private void btnSave_Click()
        {
            if (Pid == 0)
            {
                Dispatcher.Invoke(() =>
                {
                    if (lstMahsol.Count(c => c.SabtMahsolCod.Equals(Txtkodmahsol.Text)) == 0)
                    {
                        s1 = new MyDB.BusinessLayer.Models.SabtMahsol();
                        s1.SabtMahsolName = TxtNameMahsol.Text;
                        s1.SabtMahsolVahed = int.Parse(ComVahed.SelectedValue.ToString());
                        s1.SabtMahsolCod = int.Parse(Txtkodmahsol.Text);
                        s1.SabtMahsolDescription = Txtdescription.Text;
                        s1.ItemCode = TxtItemCode.Text;
                        s1.SabtMahsoldatetime = new ClsDateTime().DateTime();
                        s1.SabtMahsolPuUSER = ClsUsersLogin.User.AccountPuID;
                        lstinsert.Add(s1);
                        ClsDB<MyDB.BusinessLayer.Models.SabtMahsol>.BulkInsert(lstinsert);
                        clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSave;
                    }
                    else
                        clsMessageBox.MessageBoxSubject = "کد مجصول تکراری هست";
                });

            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    s1 = lstMahsol.First(f => f.SabtMahsolPuID == Pid);
                    if (lstMahsol.Count(c => !c.SabtMahsolPuID.Equals(Pid) && c.SabtMahsolCod.Equals(Txtkodmahsol.Text)) == 0)
                    {
                        s1.SabtMahsolName = TxtNameMahsol.Text;
                        s1.SabtMahsolVahed = int.Parse(ComVahed.SelectedValue.ToString());
                        s1.SabtMahsolCod = int.Parse(Txtkodmahsol.Text);
                        s1.ItemCode = TxtItemCode.Text;
                        s1.SabtMahsolDescription = Txtdescription.Text;
                        s1.SabtMahsolEDPuUSER = ClsUsersLogin.User.AccountPuID;
                        s1.SabtMahsolEDdatetime = new ClsDateTime().DateTime();
                        ClsDB<MyDB.BusinessLayer.Models.SabtMahsol>.Update(s1);
                        clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullEdit;
                    }
                    else
                        clsMessageBox.MessageBoxSubject = "کد مجصول تکراری هست";
                });
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ComVahed.SelectedIndex >= 0 && TxtNameMahsol.Text!=string.Empty)
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
            max = ClsDB<MyDB.BusinessLayer.Models.SabtMahsol>.GetAllByMax("SabtMahsolCod");
        }

        private void btnexcel_Click(object sender, RoutedEventArgs e)
        {
            new WsabtemahsolExcel().ShowDialog();
            dgv_loaded();
        }

        private void dgv_loaded()
        {
            lstsabtMahsols = ClsDB<MyDB.BusinessLayer.Models.View_SabtMahsol>.GetAll();
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstsabtMahsols;
            });
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lstMahsol = ClsDB<MyDB.BusinessLayer.Models.SabtMahsol>.GetAll();
            dgv_loaded();
            Getmax();
            dgv.AutoGenerateColumns = false;
            lstinsert = new List<MyDB.BusinessLayer.Models.SabtMahsol>();
            lstVahed = ClsDB<MyDB.BusinessLayer.Models.Vahed>.GetAll();
            Dispatcher.Invoke(() =>
            {
                Txtkodmahsol.Text = (max + 1).ToString();
                ComVahed.ItemsSource = lstVahed;
                ComVahed.SelectedIndex = 0;
            });
        }
    }
}
