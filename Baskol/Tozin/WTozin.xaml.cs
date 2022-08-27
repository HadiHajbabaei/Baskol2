﻿using Baskol.Tozin.PriavteClass;
using Class;
using Library35.Globalization;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Baskol.Tozin
{
    /// <summary>
    /// Interaction logic for WTozin.xaml
    /// </summary>
    public partial class WTozin : UserControl
    {
        public WTozin()
        {
            InitializeComponent();
        }
        private List<SabtDriver> lstsabtDrivers;
        private List<SabtMahsol> lstsabtMahsols;
        private List<SabtCustomer> lstSabtCustomer;
        private List<Port> lstports;
        private List<View_TakTozin> lstTakTozin;
        private List<View_TozinComplete> lstView_TozinComplete;
        private List<View_Tozin1> lstview_Tozins, lstview_Tozin2;
        private Tozin1 tozin1;
        private Tozin2 tozin2;
        private List<ClsPrint> lstPrint;
        private TakTozin takTozin;
        private int maxTak, max2, max;
        private Stimulsoft.Report.StiReport report;
        private clsPrint print;
        private long ghabzPid;
        private string date;
        SerialPort mySerialPort = new SerialPort();
        private object obj;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lstsabtDrivers = ClsDB<SabtDriver>.GetAllBy("DriverEnable",true);
            lstsabtMahsols = ClsDB<SabtMahsol>.GetAll();
            lstSabtCustomer = ClsDB<SabtCustomer>.GetAll();
            lstports = ClsDB<Port>.GetAll();
            date = new ClsDateTime().DateTime().ToString("yyyy-MM-dd");
            dgv.AutoGenerateColumns = false;

            Dispatcher.Invoke(() =>
            {
                ComDriver.ItemsSource = lstsabtDrivers;
                ComMahsol.ItemsSource = lstsabtMahsols;
                ComCustomer.ItemsSource = lstSabtCustomer;
                ComMahsolTak.ItemsSource = lstsabtMahsols;
                //TxtDate.Text = persianDateTime.ParseEnglish(DateTime.Now.ToShortDateString()).ToDateString();
                //TxtTime.Text = DateTime.Now.ToString("HH:mm");
                if (Chk.IsChecked.Value)
                    dgv_Loaded(true);
                else dgv_Loaded(false);
                try
                {
                    mySerialPort.PortName = "COM1";
                    mySerialPort.BaudRate = int.Parse(lstports.First().PortBaudrate.ToString());
                    mySerialPort.Handshake = Handshake.None;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.DataBits = int.Parse(lstports.First().PortDatabit.ToString());
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.Encoding = Encoding.ASCII;
                    if (!mySerialPort.IsOpen)
                        mySerialPort.Open();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); if (mySerialPort.IsOpen) mySerialPort.Close(); }
            });
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }
        private void PrintGhabz()
        {
            lstView_TozinComplete = ClsDB<View_TozinComplete>.GetAllBy("Tozin1PuID", ghabzPid);
            var print = (from i in lstView_TozinComplete
                         select new Baskol.Tozin.PriavteClass.ClsPrint
                         {
                             DriverName = i.DriverName,
                             DriverTagNumber = i.DriverTagNumber,
                             Tozin1Time = i.Tozin1Time,
                             Tozin1Date = i.Tozin1Date,
                             Tozin1Weighte = i.Tozin1Weighte.Value,
                             Tozin2Weighte = i.Tozin2Weighte.Value,
                             wheightkhales = i.Tozin1Weighte.Value > i.Tozin2Weighte ? i.Tozin1Weighte.Value - i.Tozin2Weighte.Value : i.Tozin2Weighte.Value - i.Tozin1Weighte.Value,
                             Tozin2Time = i.Tozin2Time,
                             Tozin2Date = i.Tozin2Date,
                             SabtMahsolName = i.SabtMahsolName
                         }).ToList();
            lstPrint.AddRange(print);
            report = new Stimulsoft.Report.StiReport();
            report.Load(".\\Report\\BaskolGhabz.mrt");
            report.Dictionary.Variables["Date"].Value = persianDateTime.ParseEnglish(new ClsDateTime().getDateTime().Rows[0][0].ToString()).ToString("yyyy/MM/dd");
            report.Dictionary.Variables["Company"].Value = string.IsNullOrEmpty(ClsUsersLogin.Company.CompanyName) ? "شرکت ثبت نشده است" : ClsUsersLogin.Company.CompanyName;
            report.Dictionary.Variables.Add("Logo", MyConverter.ToImage(ClsUsersLogin.Company.CompanyLogo));

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                TxtDate.Text = persianDateTime.ParseEnglish(DateTime.Now.ToShortDateString()).ToDateString();
                TxtTime.Text = DateTime.Now.ToString("HH:mm:ss");
                TxtDate2.Text = persianDateTime.ParseEnglish(DateTime.Now.ToShortDateString()).ToDateString();
                TxtTime2.Text = DateTime.Now.ToString("HH:mm:ss");
                TxtDateTak.Text = persianDateTime.ParseEnglish(DateTime.Now.ToShortDateString()).ToDateString();
                TxtTimeTak.Text = DateTime.Now.ToString("HH:mm:ss");
                if (mySerialPort.BytesToRead > 0)
                {
                    long weight = 0;
                    string input = mySerialPort.ReadExisting();
                    if (input.Length < 2 || !long.TryParse(input.Substring(2, input.Length - 2), out weight))
                    {
                        return;
                    }
                    if (weight < 0)
                        weight = 0;
                    if (tbcMorshedloo.SelectedIndex == 0)
                        TxtWeight.Text = weight.ToString();
                    else if (tbcMorshedloo.SelectedIndex == 1)
                        TxtWeight2.Text = weight.ToString();
                    else
                        TxtWeightKhalesTak.Text = weight.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
            finally
            {
                if (mySerialPort.IsOpen)
                    mySerialPort.DiscardInBuffer();
            }

        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void dgv_tozin2_loaded()
        {
            lstview_Tozin2 = ClsDB<MyDB.BusinessLayer.Models.View_Tozin1>.GetAllByNotIn("Tozin1PuID", "Tozin1PuID", "Tozin2");

            Dispatcher.Invoke(() =>
            {
                maxing();
                TxtGHabz.Text = max.ToString();
                dgvTozin2.AutoGenerateColumns = false;
                dgvTozin2.ItemsSource = null;
                dgvTozin2.ItemsSource = lstview_Tozin2;
            });
        }
        private void dgv_tozinTak_loaded()
        {
            lstTakTozin = ClsDB<MyDB.BusinessLayer.Models.View_TakTozin>.GetAll();
            Dispatcher.Invoke(() =>
            {
                maxing();
                TxtGHabzTak.Text = max.ToString();
                dgvTakTozin.AutoGenerateColumns = false;
                dgvTakTozin.ItemsSource = null;
                dgvTakTozin.ItemsSource = lstTakTozin;
                ComDriverTak.ItemsSource = lstsabtDrivers;
                ComCustomerTak.ItemsSource = lstSabtCustomer;
            });
        }
        private void dgv_Loaded(bool check)
        {
            if (check)
                lstview_Tozin2 = ClsDB<View_Tozin1>.GetAllByNotInDate("Tozin1PuID", "Tozin1PuID", "Tozin1DateTime", date, "Tozin2");
            else
                lstview_Tozin2 = ClsDB<View_Tozin1>.GetAllByNotIn("Tozin1PuID", "Tozin1PuID", "Tozin2");
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstview_Tozin2;

                dgvTozin2.ItemsSource = null;
                dgvTozin2.ItemsSource = lstview_Tozin2;
            });
        }

        private void btnSabt_Click()
        {
            Dispatcher.Invoke(() =>
            {

                tozin1 = new MyDB.BusinessLayer.Models.Tozin1()
                {
                    DriverPuID = int.Parse(ComDriver.SelectedValue.ToString()),
                    SabtMahsolPuID = int.Parse(ComMahsol.SelectedValue.ToString()),
                    Tozin1Date = TxtDate.Text.ToString(),
                    Tozin1Time = TxtTime.Text.ToString(),
                    CustomerPuID = int.Parse(ComCustomer.SelectedValue.ToString()),
                    Tozin1Weighte = double.Parse(TxtWeight.Text.ToString()),
                    Tozin1DateTime = new ClsDateTime().DateTime(),
                    Tozin1PuUser = ClsUsersLogin.User.AccountPuID,
                    Ttype = 1

                };
                ClsDB<MyDB.BusinessLayer.Models.Tozin1>.Insert(tozin1);
                clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSave;
            }); 
        }
        private void PrintFinish()
        {
            LoadingBusyIndicator.IsBusy = false;
            print.print<ClsPrint>(report, lstPrint);
        }
        private void btnSabt_Com()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
            Dispatcher.Invoke(() =>
            {
                ComDriver.SelectedIndex = -1;
                ComMahsol.SelectedIndex = -1;
                ComCustomer.SelectedIndex = -1;
                TxtWeight.Text = "";
                if (Chk.IsChecked.Value)
                    dgv_Loaded(true);
                else dgv_Loaded(false);
            });
        }

        private void btnSabt_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (ComDriver.SelectedIndex >= 0 && ComMahsol.SelectedIndex >= 0 && TxtWeight.Text != "")
            {
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnSabt_Click();
                worker.RunWorkerCompleted += (s, ev) => btnSabt_Com();
                worker.RunWorkerAsync();
            }
            else
            {
                clsMessageBox.MessageBoxSubject = "اطلاعات کامل وارد کنید";
                new WinInfo().ShowDialog();
            }
            Cursor = Cursors.Arrow;
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSabt2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnSabtTozin2_Click()
        {
            Dispatcher.Invoke(() =>
            {
                if (obj != null)
                {
                    tozin2 = new MyDB.BusinessLayer.Models.Tozin2();


                    tozin2.Tozin2Ghabz = int.Parse(TxtGHabz.Text);
                    tozin2.Tozin1PuID = ((MyDB.BusinessLayer.Models.View_Tozin1)obj).Tozin1PuID;
                    tozin2.Tozin2Time = TxtTime2.Text.ToString();
                    tozin2.Tozin2Date = TxtDate2.Text.ToString();
                    tozin2.Tozin2Weighte = double.Parse(TxtWeight2.Text.ToString());
                    tozin2.Tozin2DateTime = new ClsDateTime().DateTime();
                    tozin2.Tozin2PuUser = ClsUsersLogin.User.AccountPuID;
                    tozin2.Ttype = 1;


                    ClsDB<Tozin2>.Insert(tozin2);
                    ghabzPid = tozin2.Tozin1PuID.Value;
                    clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSave;
                }
                else
                    clsMessageBox.MessageBoxSubject = clsMessageBox.NotSelected;

            });
        }
        private void btnSabtTaki_Com()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();

            Dispatcher.Invoke(() =>
            {

                ComDriverTak.SelectedIndex = -1;
                ComMahsolTak.SelectedIndex = -1;
                ComCustomerTak.SelectedIndex = -1;
                TxtWeightKhalesTak.Text = "";
                maxing();
                TxtGHabzTak.Text = (max + 1).ToString();
            });
            dgv_tozinTak_loaded();
        }
        private void btnSabtTozin2_Com()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();

            Dispatcher.Invoke(() =>
            {

                TxtDriver1.Text = "";
                TxtMahsol.Text = "";
                TxtGHabz.Text = "";
                TxtWeight1.Text = "";
                TxtWeight2.Text = "";
                TxtCustomer.Text = "";
                TxtWeightKhales.Text = "";
                maxing();
                TxtGHabzTak.Text = max.ToString();
            });
            dgv_tozin2_loaded();

        }
        private void btnSabtTozin2_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (TxtWeight2.Text != "0")
            {
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnSabtTozin2_Click();
                worker.RunWorkerCompleted += (s, ev) => btnSabtTozin2_Com();
                worker.RunWorkerAsync();
            }
            else
            {
                clsMessageBox.MessageBoxSubject = "اطلاعات کامل وارد کنید";
                new WinInfo().ShowDialog();
            }
            Cursor = Cursors.Arrow;

        }

        private void btnNewTozin2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteTozin2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void maxing()
        {
            maxTak = ClsDB<TakTozin>.GetAllByMax("TakTozinGhabz");
            max2 = ClsDB<Tozin2>.GetAllByMax("Tozin2Ghabz");
            if (maxTak > max2)
                max = maxTak + 1;
            else
                max = max2 + 1;
        }

        private void tbcMorshedloo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Chk.IsChecked.Value)
                dgv_Loaded(true);
            else
                dgv_Loaded(false);

        }

        private void dgvTozin2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstview_Tozin2.Count() > 0)
            {
                if (obj != null)
                {
                    maxing();
                    TxtDriver1.Text = lstview_Tozin2.First(f => f.Tozin1PuID == ((MyDB.BusinessLayer.Models.View_Tozin1)obj).Tozin1PuID).DriverName;
                    TxtMahsol.Text = lstview_Tozin2.First(f => f.Tozin1PuID == ((MyDB.BusinessLayer.Models.View_Tozin1)obj).Tozin1PuID).SabtMahsolName;
                    TxtGHabz.Text = (max + 1).ToString();
                    TxtWeight1.Text = lstview_Tozin2.First(f => f.Tozin1PuID == ((MyDB.BusinessLayer.Models.View_Tozin1)obj).Tozin1PuID).Tozin1Weighte.ToString();
                    TxtCustomer.Text = lstview_Tozin2.First(f => f.Tozin1PuID == ((MyDB.BusinessLayer.Models.View_Tozin1)obj).Tozin1PuID).CustomerName;
                }

            }
        }

        private void tbcMorshedloo_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TxtWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            int a, b, c;
            if (TxtWeight1.Text != string.Empty && TxtWeight2.Text != string.Empty)
            {
                a = int.Parse(TxtWeight1.Text);
                b = int.Parse(TxtWeight2.Text);
                if (a >= b)
                    c = a - b;
                else
                    c = b - a;
                TxtWeightKhales.Text = c.ToString();
            }

        }
        private void btnSabtTaki_Click()
        {
            Dispatcher.Invoke(() =>
            {

                takTozin = new MyDB.BusinessLayer.Models.TakTozin();


                takTozin.DriverPuID = int.Parse(ComDriverTak.SelectedValue.ToString());
                takTozin.CustomerPuID = int.Parse(ComCustomerTak.SelectedValue.ToString());
                takTozin.TakTozinGhabz = TxtGHabzTak.Text != string.Empty ? int.Parse(TxtGHabzTak.Text) : max + 1;
                takTozin.TakTozinTime = TxtTime2.Text.ToString();
                takTozin.TakTozinDate = TxtDate2.Text.ToString();
                takTozin.TakTozinWeighte = TxtWeightKhalesTak.Text != string.Empty ? double.Parse(TxtWeightKhalesTak.Text.ToString()) : 0;
                takTozin.TakTozinDateTime = new ClsDateTime().DateTime();
                takTozin.TakTozinPuUser = ClsUsersLogin.User.AccountPuID;
                takTozin.SabtMahsolPuID = int.Parse(ComMahsolTak.SelectedValue.ToString());
                takTozin.Ttype = 0;


                ClsDB<TakTozin>.Insert(takTozin);
                clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSave;


            });
        }

        private void Chk_Checked()
        {
            dgv_Loaded(true);
        }

        private void Chk_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Chk_Unchecked()
        {
            dgv_Loaded(false);
        }

        private void Chk_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnSabtTaki_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSabtTozinTak_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (ComDriverTak.SelectedIndex >= 0 && TxtWeightKhalesTak.Text != "0")
            {
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnSabtTaki_Click();
                worker.RunWorkerCompleted += (s, ev) => btnSabtTaki_Com();
                worker.RunWorkerAsync();
            }
            else
            {
                clsMessageBox.MessageBoxSubject = "اطلاعات کامل وارد کنید";
                new WinInfo().ShowDialog();
            }
            Cursor = Cursors.Arrow;
        }

        private void dgvTozin2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            obj = dgvTozin2.SelectedItem;
        }
    }
}
