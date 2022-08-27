using Library35.Globalization;
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

namespace Baskol.WinSabtCar
{
    /// <summary>
    /// Interaction logic for WinSabtcar.xaml
    /// </summary>
    public partial class WinSabtcar : UserControl
    {
        public WinSabtcar()
        {
            InitializeComponent();
        }

        private List<MyDB.BusinessLayer.Models.Car> lstsabtcar, lstcars;
        private List<MyDB.BusinessLayer.Models.Car> lstcar;
        private List<P.Class.Player> lstplayer;

        private MyDB.BusinessLayer.Models.Car sabtCar;
        int puid;
        private object obj;
        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void btnSave_Click()
        {
            if (puid == 0)
            {
                Dispatcher.Invoke(() =>
                {
                    sabtCar = new MyDB.BusinessLayer.Models.Car()
                    {
                        CarName = TxtCarName.Text,
                        CarDescription = TxtDes.Text,
                        CarDateTime = new ClsDateTime().DateTime(),
                        CarPuUser = ClsUsersLogin.User.AccountPuID,
                        CarEnable = true
                    };
                });

                ClsDB<MyDB.BusinessLayer.Models.Car>.Insert(sabtCar);
            }
            else
            {
                sabtCar = lstcars.First(f => f.CarPuID == sabtCar.CarPuID);

                sabtCar.CarName = TxtCarName.Text;
                sabtCar.CarDescription = TxtDes.Text;
                sabtCar.CarEnable = true;
                sabtCar.CarEdDateTime = new ClsDateTime().DateTime();
                sabtCar.CarEdPuUser = ClsUsersLogin.User.AccountPuID;

                ClsDB<MyDB.BusinessLayer.Models.Car>.Update(sabtCar);
            }

        }
        private void dgv_Loaded()
        {
            lstplayer = addPlayer();
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstplayer;

            });
        }
        private List<P.Class.Player> addPlayer()
        {
            lstcar = ClsDB<MyDB.BusinessLayer.Models.Car>.GetAll();
            if (lstcar.Count > 0)
            {
                lstplayer.Clear();
                var q = (from i in lstcar
                         select new P.Class.Player
                         {
                             CarName = i.CarName,
                             CarDescription = i.CarDescription,
                             CarDateTime = i.CarDateTime.HasValue ? persianDateTime.ParseEnglish(i.CarDateTime.Value.ToString("yyyy-MM-dd")).ToString("yyyy/MM/dd") : "---",
                         }).ToList();
                return q;
                dgv.ItemsSource = q;
            }
            return new List<P.Class.Player>();
        }

        private void UserControl_Loaded()
        {
            lstplayer = new List<P.Class.Player>();
            lstcars = ClsDB<MyDB.BusinessLayer.Models.Car>.GetAll();
            dgv_Loaded();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            LoadingBusyIndicator.BusyContent = clsMessageBox.Load;
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => UserControl_Loaded();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
        }

        private void dgv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            obj = dgv.SelectedItem;
        }

        private void dgv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            puid = ((MyDB.BusinessLayer.Models.Car)obj).CarPuID;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            clsMessageBox.MessageBoxSubject = clsMessageBox.QustionSave;

            new WinYesOrNo().ShowDialog();
            if (clsMessageBox.Ok)
            {
                LoadingBusyIndicator.BusyContent = clsMessageBox.Save;
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnSave_Click();
                worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
                worker.RunWorkerAsync();
            }
            Cursor = Cursors.Arrow;
            UserControl_Loaded();

        }

    }
}
