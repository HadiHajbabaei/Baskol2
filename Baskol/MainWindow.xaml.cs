 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System.Diagnostics;
using System.Windows;
using Baskol.WinSabtCar;
using Baskol.Tozin;

namespace Baskol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private string content;
        private string[] arycontent;
        private Process[] targetProcess;
        private List<RadTabItem> lstControl = new List<RadTabItem>();
        private List<Account> lstAccount;
        //private List<AccountUser> lstAccountUser;
        private RadTabItem t;
        private bool _Change;


        void AddTab(UserControl ct, string Title)
        {
            if (lstControl.Count(c => c.Name == ct.Name) == 0)
            {
                t = new RadTabItem();
                t.Visibility = Visibility.Visible;
                t.CloseButtonVisibility = Visibility.Visible;
                t.VerticalAlignment = VerticalAlignment.Center;
                t.HorizontalAlignment = HorizontalAlignment.Center;
                ct.Width = t.Width;
                //ct.Height = this.Height - menu.Height;
                t.Header = Title;
                ct.Background = System.Windows.Media.Brushes.Transparent;
                t.VerticalContentAlignment = VerticalAlignment.Center;
                t.Content = ct;
                t.Name = ct.Name;
                tbControl.Background = Brushes.Transparent;
                tbControl.Items.Add(t);
                tbControl.SelectedItem = t;
                lstControl.Add(t);
            }
            else
                tbControl.SelectedItem = lstControl.First(c => c.Name == ct.Name);
        }

        private void RemveTab(RadTabItem ct)
        {
            if (lstControl.Count(c => c.Name == ct.Name) > 0)
                lstControl.Remove(ct);
        }

        private void tbControl_TabClosed(object sender, TabChangedEventArgs e)
        {
            RemveTab(e.TabItem);
        }
        private void butonclosemenu_Click(object sender, RoutedEventArgs e)
        {
            buttonopenmenu.Visibility = Visibility.Visible;
            butonclosemenu.Visibility = Visibility.Collapsed;
        }
        private void buttonopenmenu_Click(object sender, RoutedEventArgs e)
        {
            buttonopenmenu.Visibility = Visibility.Collapsed;
            butonclosemenu.Visibility = Visibility.Visible;
            //}
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //wTel fr = new wTel();
            //fr.Name = "wTel";
            //AddTab(fr, "تماس با ما");
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        private void ShowPanel(string Name)
        {
            switch (Name)
            {
                case "SabtCar":
                    WinSabtcar fr = new WinSabtcar();
                    fr.Name = "WinSabtCar";
                    AddTab(fr, "ثببت مشخصات وسیله نقلیه");
                    break;
                case "WinSabtDriver":
                    Baskol.WinSabtDriver. WinSabtDriver winSabtDriver = new Baskol.WinSabtDriver. WinSabtDriver();
                    winSabtDriver.Name = "WinSabtDriver";
                    AddTab(winSabtDriver, "ثبت مشخصات راننده ");
                    break;
                case "sabtmahsol":
                    Baskol.WinSabtMahsol.WinSabtMahsol bimes = new Baskol.WinSabtMahsol.WinSabtMahsol();
                    bimes.Name = "sabtmahsol";
                    AddTab(bimes, "ثبت محصولات");
                    break;
                case "sabtdastgah":
                    WinComPortDetails a = new WinComPortDetails();
                    a.Name = "WinComPortDetails";
                    AddTab(a, "ثبت دستگاه");
                    break;
                case "Tozin":
                    WTozin WTozin = new WTozin();
                    WTozin.Name = "Tozin";
                    AddTab(WTozin, "توزین دستگاه");
                    break;
                case "wTozinDasti":
                    Baskol.Tozin.TozinDasti.wTozinDasti wToz = new Baskol.Tozin.TozinDasti. wTozinDasti();
                    wToz.Name = "Tozin";
                    AddTab(wToz, "توزین دستی");
                    break;
                case "wCustomer":
                    wCustomer Customer = new wCustomer();
                    Customer.Name = "Customer";
                    AddTab(Customer, "تعریف مشتری");
                    break;
                case "tozin":
                    Baskol.Report. wReportTozin wReportTozin = new Baskol.Report. wReportTozin();
                    wReportTozin.Name = "wReportTozin";
                    AddTab(wReportTozin, "توزین ها");
                    break;
                case "wCameraSetting":
                    new Baskol.Camera.wCameraSetting().ShowDialog();
              
                    break;
                case "wCyberSetting":
                    Baskol.Cyber .wCyberSetting wCyberSetting = new Baskol.Cyber.wCyberSetting();
                    wCyberSetting.Name = "wCyberSetting";
                    AddTab(wCyberSetting, "ارتباط با شایگان");
                    break;
                case "wFactor":
                    Baskol.Factor. wFactor wFactor = new Baskol.Factor.wFactor();
                    wFactor.Name = "wFactor";
                    AddTab(wFactor, "فاکتور");
                    break;
                case "UpCustomer":
                    Baskol.Update .wUpdateCustomer wUpdateCustomer = new Baskol.Update.wUpdateCustomer();
                    wUpdateCustomer.Name = "wUpdateCustomer";
                    AddTab(wUpdateCustomer, "بروزرسانی مشتریان");
                    break;
                    //    case "changedarayi":
                    //        W_changedarayi.WinChangeDarayi WinChangeDarayi = new W_changedarayi.WinChangeDarayi();
                    //        WinChangeDarayi.Name = "WinChangeDarayi";
                    //        AddTab(WinChangeDarayi, "تعریف دارایی");
                    //        break;
                    //    case "Joinsha":
                    //        Darayi_Sabet.Conect_Shaygan.Win_ConectShaygan ConectShaygan = new Darayi_Sabet.Conect_Shaygan.Win_ConectShaygan();
                    //        ConectShaygan.Name = "ConectShaygan";
                    //        AddTab(ConectShaygan, "ارتباط با شایگان");
                    //        break;
                    //    case "SettingShaygan":
                    //        Darayi_Sabet.SettingShaygan.Win_SettingShaygan SettingShaygan = new Darayi_Sabet.SettingShaygan.Win_SettingShaygan();
                    //        SettingShaygan.Name = "SettingShaygan";
                    //        AddTab(SettingShaygan, "تنظبمات مالی");
                    //        break;
                    //}


            }
        }
            private void TreeView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {if(TreeView1.SelectedItem!=null)
                ShowPanel(((TreeViewItem)TreeView1.SelectedItem).Name);
            }
            private bool ConnectioDataBase()
            {
                if (File.Exists("DB.con"))
                {
                    content = File.ReadAllText("DB.con");
                    if (content == string.Empty)
                    {
                        clsMessageBox.MessageBoxSubject = "فایل اتصال به سرور خالی می باشد";
                        new WinInfo().ShowDialog();
                        new winConnectionDB().ShowDialog();
                        ConnectioDataBase();
                    }
                    content = Crypt.Decrypt(content);
                    arycontent = content.Split(';');
                    ConnectionString.myConnection = "Data Source=" + arycontent.First() + ";Initial Catalog=Baskol;User ID=" + arycontent[1] + ";Password=" + arycontent.Last() + ";MultipleActiveResultSets=true;";
                    // ConnectionString.myConnection = " Data Source=" + arycontent.First() + ";Initial Catalog=1;User ID=" + arycontent[1] + ";Password=" + arycontent.Last() + "";
                    //ConnectionString.myConnection = "data source = " + arycontent.First() + "; initial catalog = ControlGroup; persist security info = True; user id = " + arycontent[1] + "; password = " + arycontent.Last() + "; MultipleActiveResultSets = True; App = EntityFramework";
                    tiny_MyEventForTinyConnect();
                    return true;
                }
                else
                {
                    clsMessageBox.MessageBoxSubject = "فایل اتصال به سرور پیدا نشد";
                    new winConnectionDB().ShowDialog();
                }
                ConnectioDataBase();
                return false;
            }
            private void tiny_MyEventForTinyConnect()
            {
                try
                {
                    lstAccount = ClsDB<Account>.GetAllBy("AccountEnable", true);
                }
                catch (Exception ex)

                {
                    clsMessageBox.MessageBoxSubject = "عدم ارتباط با بانک اطلاعاتی" + "\n" + ex.Message;
                    new WinInfo().ShowDialog();
                    new winConnectionDB().ShowDialog();
                    ConnectioDataBase();
                }
            }

            private void RadRibbonWindow_Loaded(object sender, RoutedEventArgs e)
            {
                ConnectioDataBase();
                //Cursor = Cursors.Wait;
                //dateTime = new ClsDateTime().DateTime();


                //ipList = Dns.GetHostAddresses(Dns.GetHostName());
                //host = Dns.GetHostEntry("127.0.0.1");

                //NameUser.Text = ClsUsersLogin.User.AccountName + " " + ClsUsersLogin.User.AccountFamily;
                //txtDateLogin.Text = persianDateTime.ParseEnglish(dateTime.ToString("yyyy-MM-dd")).ToString("yyyy/MM/dd");
                //TimeLogin.Text = dateTime.ToString("HH:mm");

                //Expire.Text = persianDateTime.ParseEnglish(ValiDation.DateExpire.Date.ToString("yyyy-MM-dd")).ToString("yyyy/MM/dd");
                //systmName.Text = host.HostName;
                //IP.Text = ipList.Count() > 2 ? ipList[2].ToString() : ipList[1].ToString();
                //ClsDB<ActiveUser>.Insert(new ActiveUser()
                //{
                //    ActiveUserPuID = ClsUsersLogin.User.AccountPuID
                //});
                //lstCA = ClsDB<CA>.GetAllBy("CyberSelected", true);
                //if (lstCA.Count > 0)
                //{
                //    string dore;
                //    if (lstCA.First().CyberDore.Length == 1)
                //        dore = "0" + Crypt.Decrypt(lstCA.First().CyberDore);
                //    else
                //        dore = Crypt.Decrypt(lstCA.First().CyberDore);

                //    MyDB.BusinessLayer.Cyber.ConnectionString.myConnection = "Data Source=" + Crypt.Decrypt(lstCA.First().CyberServer) + ";Initial Catalog=CY" + Crypt.Decrypt(lstCA.First().CyberKholase) + dore + ";User ID=" + lstCA.First().CyberUsername + ";Password=" + Crypt.Decrypt(lstCA.First().CyberPassword) + ";MultipleActiveResultSets=true;";
                //}
                //else
                //{
                //    clsMessageBox.MessageBoxSubject = "تنظیمات شایگان درست نیست";
                //    new wInfo().ShowDialog();
                //    //rbSettingShygun_Click(null, null);
                //}
                //clsMessageBox.MessageBoxSubject = "قبل از هر عملیاتی از شایگان خود پشتیبانی بگیرید";
                //new wInfo().ShowDialog();

                //if (ClsUsersLogin.CrackID == 13)
                //{
                //    #region سند
                //    rbCreateSanad.IsEnabled = true;
                //    rbSortSanad.IsEnabled = false;
                //    rbRefrence.IsEnabled = false;
                //    rbMoveSanad.IsEnabled = false;
                //    rbWarningDateSanadAndCreate.IsEnabled = false;
                //    rbEmpityDelSanad.IsEnabled = false;
                //    rbDelSanad.IsEnabled = false;
                //    rbDelDetailsSanad.IsEnabled = false;
                //    #endregion
                //    #region فاکتور
                //    rbCreateFac.IsEnabled = false;
                //    rbWarningDateSanadAndFac.IsEnabled = false;
                //    rbWarningDateFacAndCreate.IsEnabled = false;
                //    rbSortFactor.IsEnabled = false;
                //    rbMoveFactor.IsEnabled = false;
                //    rbEmpityFac.IsEnabled = false;
                //    rbDelFac.IsEnabled = false;
                //    rbDelRadifFac.IsEnabled = false;
                //    #endregion
                //    #region رسید تولید
                //    rbDelControlTolid.IsEnabled = false;
                //    #endregion
                //    #region کالا
                //    rbUpdatePrice.IsEnabled = false;
                //    rbCreatGoods.IsEnabled = false;
                //    rbEditPricing.IsEnabled = false;
                //    rbConvertGoods.IsEnabled = false;
                //    rbEditClass.IsEnabled = false;
                //    rbDuplicateGoods.IsEnabled = false;
                //    #endregion
                //    #region تفصیلی شناور
                //    rbCreateGroupTafziliSh.IsEnabled = false;
                //    rbCreateTafziliSh.IsEnabled = false;
                //    rbChangeTafziliSh.IsEnabled = false;
                //    #endregion

                //}
            }
            private void RadRibbonWindow_Closed(object sender, EventArgs e)
            {
            Application.Current.Shutdown();
            }
            private void butonclosemenuDown_Click(object sender, RoutedEventArgs e)
            {
                btnDown.Visibility = Visibility.Visible;
                btnUp.Visibility = Visibility.Collapsed;
            }
            private void buttonopenmenuDown_Click(object sender, RoutedEventArgs e)
            {
                btnDown.Visibility = Visibility.Collapsed;
                btnUp.Visibility = Visibility.Visible;
            }


           
        } 
    }
