using Baskol.Cyber.PrivateClass;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Cyber.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Baskol.Cyber
{
    /// <summary>
    /// Interaction logic for wCyberSetting.xaml
    /// </summary>
    public partial class wCyberSetting : UserControl
    {
        public wCyberSetting()
        {
            InitializeComponent();
        }
        private List<MyDB.BusinessLayer.Models.Cyber> lstCyber, lstInsert, lstUpdate;
        private List<AC_UnitM> lstAC_UnitM;
        private MyDB.BusinessLayer.Models.Cyber cyber;
        private object obj;
        private int c, r, _darsad;
        private string dore;
        private bool chk;

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            obj = dgv.SelectedItem;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (dgv.Items.Count > 0)
            {
                clsMessageBox.MessageBoxSubject = clsMessageBox.QustionSave;

                new WinYesOrNo().ShowDialog();
                if (clsMessageBox.Ok)
                {
                    clsMessageBox.MessageBoxSubject = "";
                    r = 1;
                    foreach (var i in dgv.Items)
                    {
                        try
                        {
                            string.IsNullOrEmpty(((MyDB.BusinessLayer.Models.Cyber)i).CyberName);
                        }
                        catch
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(((MyDB.BusinessLayer.Models.Cyber)i).CyberName))
                            clsMessageBox.MessageBoxSubject = "سطر " + r + ": نام شرکت وارد نشده";

                        if (string.IsNullOrEmpty(((MyDB.BusinessLayer.Models.Cyber)i).CyberServer))
                        {
                            if (clsMessageBox.MessageBoxSubject.Equals(string.Empty))
                                clsMessageBox.MessageBoxSubject = "سطر " + r + ": سرور وارد نشده";
                            else
                                clsMessageBox.MessageBoxSubject = "\n " + "سطر " + r + ": سرور وارد نشده";
                        }

                        if (string.IsNullOrEmpty(((MyDB.BusinessLayer.Models.Cyber)i).CyberKholase) || ((MyDB.BusinessLayer.Models.Cyber)i).CyberKholase.Length != 4)
                        {
                            if (clsMessageBox.MessageBoxSubject.Equals(string.Empty))
                                clsMessageBox.MessageBoxSubject = "سطر " + r + ": خلاصه اشتباه وارد شده";
                            else
                                clsMessageBox.MessageBoxSubject = "\n " + "سطر " + r + ": خلاصه اشتباه وارد شده";
                        }
                        if (((MyDB.BusinessLayer.Models.Cyber)i).CyberDore == 0)
                        {
                            if (clsMessageBox.MessageBoxSubject.Equals(string.Empty))
                                clsMessageBox.MessageBoxSubject = "سطر " + r + ": دوره اشتباه وارد شده";
                            else
                                clsMessageBox.MessageBoxSubject = "\n " + "سطر " + r + ": دوره اشتباه وارد شده";
                        }
                        r++;
                    }
                    if (clsMessageBox.MessageBoxSubject.Equals(string.Empty))
                    {
                        LoadingBusyIndicator.BusyContent = clsMessageBox.Save + "\n 0%";
                        LoadingBusyIndicator.IsBusy = true;
                        var worker = new BackgroundWorker();
                        worker.DoWork += (s, ev) => btnSave_Click();
                        worker.RunWorkerCompleted += (s, ev) => btnSave_Complated();
                        worker.RunWorkerAsync();
                    }
                    else
                        new WinInfo().ShowDialog();
                }
            }
            else
            {
                clsMessageBox.MessageBoxSubject = clsMessageBox.Nothing;
                new WinInfo().ShowDialog();
            }
            Cursor = Cursors.Arrow;
        }
        private void btnSave_Complated()
        {
            dgv_Loaded();
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
        }
        private void btnSave_Click()
        {
            c = 0;
            lstInsert.Clear();
            lstUpdate.Clear();
            Dispatcher.Invoke(() =>
            {
                foreach (var i in dgv.Items)
                {
                    try
                    {
                        string.IsNullOrEmpty(((MyDB.BusinessLayer.Models.Cyber)i).CyberName);
                    }
                    catch
                    {
                        continue;
                    }
                    if (((MyDB.BusinessLayer.Models.Cyber)i).CyberPuID == 0)
                    {
                        cyber = new MyDB.BusinessLayer.Models.Cyber();
                        cyber.CyberDateTime = new ClsDateTime().DateTime();
                        cyber.CyberDore = ((MyDB.BusinessLayer.Models.Cyber)i).CyberDore;
                        cyber.CyberName = ((MyDB.BusinessLayer.Models.Cyber)i).CyberName;
                        cyber.CyberServer = ((MyDB.BusinessLayer.Models.Cyber)i).CyberServer;
                        cyber.CyberPuUser = ClsUsersLogin.User.AccountPuID;
                            cyber.CyberSelect = lstCyber.Count() == 0 ? true : false;
                        cyber.CyberKholase = ((MyDB.BusinessLayer.Models.Cyber)i).CyberKholase;
                        cyber.CyberUsername = ((MyDB.BusinessLayer.Models.Cyber)i).CyberUsername;
                        cyber.CyberPassword = Crypt.Encrypt(((MyDB.BusinessLayer.Models.Cyber)i).CyberPassword);
                        lstCyber.Add(cyber);
                        lstInsert.Add(cyber);
                    }
                    else
                    {
                        cyber = lstCyber.First(f => f.CyberPuID == ((MyDB.BusinessLayer.Models.Cyber)i).CyberPuID);
                        if (cyber.CyberName != ((MyDB.BusinessLayer.Models.Cyber)i).CyberName || cyber.CyberDore != ((MyDB.BusinessLayer.Models.Cyber)i).CyberDore || cyber.CyberServer != ((MyDB.BusinessLayer.Models.Cyber)i).CyberServer ||
                            cyber.CyberKholase != ((MyDB.BusinessLayer.Models.Cyber)i).CyberKholase || cyber.CyberUsername != ((MyDB.BusinessLayer.Models.Cyber)i).CyberUsername || cyber.CyberPassword != Crypt.Encrypt(((MyDB.BusinessLayer.Models.Cyber)i).CyberPassword)
                            || cyber.CyberDore != ((MyDB.BusinessLayer.Models.Cyber)i).CyberDore)
                        {
                            cyber.CyberEdDateTime = new ClsDateTime().DateTime();
                            cyber.CyberDore = ((MyDB.BusinessLayer.Models.Cyber)i).CyberDore;
                            cyber.CyberName = ((MyDB.BusinessLayer.Models.Cyber)i).CyberName;
                            cyber.CyberUsername = ((MyDB.BusinessLayer.Models.Cyber)i).CyberUsername;
                            cyber.CyberPassword = Crypt.Encrypt(((MyDB.BusinessLayer.Models.Cyber)i).CyberPassword);
                            cyber.CyberServer = ((MyDB.BusinessLayer.Models.Cyber)i).CyberServer;
                            cyber.CyberKholase = ((MyDB.BusinessLayer.Models.Cyber)i).CyberKholase;
                            cyber.CyberEdPuUser = ClsUsersLogin.User.AccountPuID;
                            lstUpdate.Add(cyber);
                        }
                    }
                    c++;
                    _darsad = (c * 100) / dgv.Items.Count;
                    Dispatcher.Invoke(() =>
                    {
                        LoadingBusyIndicator.BusyContent = clsMessageBox.Save + "\n"
                       + "%" + _darsad;
                    });
                }

            });

            if (lstInsert.Count > 0)
                ClsDB<MyDB.BusinessLayer.Models.Cyber>.BulkInsert(lstInsert);
            if (lstUpdate.Count > 0)
                ClsDB<MyDB.BusinessLayer.Models.Cyber>.BulkUpdate(lstUpdate);
            clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSave;
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void btnTest_Complated()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
        }
        private void btnTest_Click()
        {
            if (((MyDB.BusinessLayer.Models.Cyber)obj).CyberDore.ToString().Length == 1)
                dore = "0" + ((MyDB.BusinessLayer.Models.Cyber)obj).CyberDore;
            else
                dore = ((MyDB.BusinessLayer.Models.Cyber)obj).CyberDore.ToString();
            MyDB.BusinessLayer.Cyber.ConnectionString.myConnection = "Data Source=" + ((MyDB.BusinessLayer.Models.Cyber)obj).CyberServer + ";Initial Catalog=CY" + ((MyDB.BusinessLayer.Models.Cyber)obj).CyberKholase + dore + ";User ID=" + ((MyDB.BusinessLayer.Models.Cyber)obj).CyberUsername + ";Password=" + ((MyDB.BusinessLayer.Models.Cyber)obj).CyberPassword + ";MultipleActiveResultSets=true;";
            try
            {
                lstAC_UnitM = MyDB.BusinessLayer.Cyber.ClsDB<AC_UnitM>.GetAll();
                clsMessageBox.MessageBoxSubject = clsMessageBox.ConnectedToCyber;
            }
            catch (Exception ex)
            {
                clsMessageBox.MessageBoxSubject = clsMessageBox.ErroConnectToCyber + "\n " + ex.Message;
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (dgv.Items.Count > 0)
            {
                if (dgv.SelectedItem != null)
                {
                    LoadingBusyIndicator.BusyContent = clsMessageBox.Connection;
                    LoadingBusyIndicator.IsBusy = true;
                    var worker = new BackgroundWorker();
                    worker.DoWork += (s, ev) => btnTest_Click();
                    worker.RunWorkerCompleted += (s, ev) => btnTest_Complated();
                    worker.RunWorkerAsync();
                    Cursor = Cursors.Arrow;
                }
                else
                {
                    clsMessageBox.MessageBoxSubject = clsMessageBox.NotSelected;
                    new WinInfo().ShowDialog();
                }
            }
            else
            {
                clsMessageBox.MessageBoxSubject = clsMessageBox.Nothing;
                new WinInfo().ShowDialog();
            }
            Cursor = Cursors.Arrow;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            lstCyber.ForEach(f => f.CyberSelect = false && f.CyberPassword == Crypt.Encrypt(f.CyberPassword));
            lstCyber.First(f => f.CyberPuID == ((MyDB.BusinessLayer.Models.Cyber)obj).CyberPuID).CyberSelect = true;
            ClsDB<MyDB.BusinessLayer.Models.Cyber>.BulkInsert(lstCyber);
            dgv_Loaded();
        }

        private void txtSelected_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Contains("بل"))
                ((TextBox)sender).Foreground = Brushes.Green;
            else
                ((TextBox)sender).Foreground = Brushes.Red;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            Cursor = Cursors.Wait;
            LoadingBusyIndicator.BusyContent = clsMessageBox.Load;
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => UserControl_Loaded();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }
        private void UserControl_Loaded()
        {
            Dispatcher.Invoke(() =>
            {
                dgv.AutoGenerateColumns = false;
            });

            lstCyber = ClsDB<MyDB.BusinessLayer.Models.Cyber>.GetAll();
            lstInsert = new List<MyDB.BusinessLayer.Models.Cyber>();
            lstUpdate = new List<MyDB.BusinessLayer.Models.Cyber>();
            dgv_Loaded();
        }
        private void dgv_Loaded()
        {

            var q = (from i in lstCyber
                     select new MyDB.BusinessLayer.Models.Cyber
                     {
                         CyberDore = i.CyberDore,
                         CyberKholase = i.CyberKholase,
                         CyberName = i.CyberName,
                         CyberPassword = Crypt.Decrypt(i.CyberPassword),
                         CyberPuID = i.CyberPuID,
                         CyberSelect = i.CyberSelect.HasValue ? i.CyberSelect.Value : false,
                         CyberServer = i.CyberServer,
                         CyberUsername = i.CyberUsername

                     }).ToList();
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = q;
            });
        }
    }
}
