using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for WinComPortDetails.xaml
    /// </summary>
    public partial class WinComPortDetails : UserControl
    {
        public WinComPortDetails()
        {
            InitializeComponent();
        }
        MyDB.BusinessLayer.Models.Port port;
        private List<Port> lstport;
        private int i ;
        int puid;
        private object obj;
        private void btnsave_Com()
        {
            LoadingBusyIndicator.IsBusy = false;
            dgv_loaded();
            new WinInfo().ShowDialog();
            Dispatcher.Invoke(() =>
            {
                TxtBaudrate.Text = "";
                TxtDatabit.Text = "";
                Txtdevicelocation.Text = "";
                Txtdevicename.Text = "";
                TxtFlowcontrol.Text = "";
                Txtportnumber.Text = "";
                TxtStopbit.Text = "";
            });

        }
        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            clsMessageBox.MessageBoxSubject = clsMessageBox.QustionSave;

            new WinYesOrNo().ShowDialog();
            if (clsMessageBox.Ok)
            {
                
                    LoadingBusyIndicator.BusyContent = clsMessageBox.Save;
                    LoadingBusyIndicator.IsBusy = true;
                    var worker = new BackgroundWorker();
                    worker.DoWork += (s, ev) => btnsave_Click();
                    worker.RunWorkerCompleted += (s, ev) => btnsave_Com();
                    worker.RunWorkerAsync();
               
                
            }
            Cursor = Cursors.Arrow;

          
        }
        private void dgv_loaded()
        {
            lstport = ClsDB<Port>.GetAll();
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstport;
                dgv.AutoGenerateColumns = false;
            });
        
        }
        private void btnsave_Click()
        {
            if (puid == 0)
            {
                Dispatcher.Invoke(() =>
                {
                    port = new MyDB.BusinessLayer.Models.Port()
                    {
                        
                        DeviceLocation  = Txtdevicelocation.Text,
                        DeviceName  = Txtdevicename.Text,
                        PortNumber = Txtportnumber.Text,
                        PortBaudrate = int.Parse(TxtBaudrate.Text),
                        PortDatabit = int.Parse(TxtDatabit.Text),
                        PortFlowcontrol = int.Parse(TxtFlowcontrol.Text),
                        PortStopbit = int.Parse(TxtStopbit.Text),
                    };
                });

                ClsDB<MyDB.BusinessLayer.Models.Port>.Insert(port);
                clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSabt;
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    port = lstport.First(f => f.PortPuID == puid);

                    port.PortBaudrate = int.Parse(TxtBaudrate.Text);
                    port.PortDatabit = int.Parse(TxtDatabit.Text);
                    port.PortFlowcontrol = int.Parse(TxtFlowcontrol.Text);
                    port.PortNumber = int.Parse(Txtportnumber.Text).ToString();
                    port.PortStopbit = int.Parse(TxtStopbit.Text);
                    port.DeviceLocation = Txtdevicelocation.Text;
                    port.DeviceName = Txtdevicename.Text;
                });
               
                ClsDB<MyDB.BusinessLayer.Models.Port>.Update(port);
                clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullEdit;
            }
        }
        private void dgv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            puid = ((MyDB.BusinessLayer.Models.Port)obj).PortPuID;
            var q = lstport.First(f => f.PortPuID == puid);
            Dispatcher.Invoke(() =>
            {
                TxtBaudrate.Text = q.PortBaudrate.Value.ToString();
                TxtDatabit.Text = q.PortDatabit.Value.ToString();
                Txtdevicelocation.Text = q.DeviceLocation.ToString();
                Txtdevicename.Text = q.DeviceName.ToString();
                TxtFlowcontrol.Text = q.PortFlowcontrol.Value.ToString();
                Txtportnumber.Text = q.PortNumber.ToString();
                TxtStopbit.Text = q.PortStopbit.Value.ToString();
                
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lstport = ClsDB<MyDB.BusinessLayer.Models.Port>.GetAll();
            dgv_loaded();
        }

        private void dgv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            obj = dgv.SelectedItem; 
        }

        private void TxtAdress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
