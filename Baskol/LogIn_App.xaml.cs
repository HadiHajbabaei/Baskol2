using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Baskol
{
    /// <summary>
    /// Interaction logic for LogIn_App.xaml
    /// </summary>
    public partial class LogIn_App : RadRibbonWindow
    {
        public LogIn_App()
        {
            InitializeComponent();
        }
        private List<Account> lstAccount;
        //private List<view_Post> lstAccount;
        //private List<Dore> lstDore;
        private string content;
        private string[] arycontent;
        private Process[] targetProcess;
 
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
                // ConnectionString.myConnection = " Data Source=" + arycontent.First() + ";Initial Catalog=Sandogh;User ID=" + arycontent[1] + ";Password=" + arycontent.Last() + "";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            var q = lstAccount.Where(c => c.AccountUser == TxtUser.Text && c.AccountPassword == Crypt.MD5Hash(TxtPas.Text));
            if (q.Count() > 0)
            {
                ClsUsersLogin.User = q.First();
                this.Hide();
                new MainWindow().Show();
            }
            else
            {
                Hidden();
                txtname.Text = "نام کاربری یا رمز عبور اشتباه وارد شده است";
            }
            Cursor = Cursors.Arrow;
        }

        private void RadRibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            targetProcess = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension("Baskol.exe"));
            if (targetProcess.Length > 1)
            {
                clsMessageBox.MessageBoxSubject = "برنامه در حال اجرا می باشد";
                new WinInfo();
                Cursor = Cursors.Arrow;
                Application.Current.Shutdown();
            }

            //if (ClsUsersLogin.Crack)
            //{
            if (ConnectioDataBase())
            {
                Hidden();
                TxtUser.Focus();
            }


            //if (ValiDation.DateExpire.Date < new ClsDateTime().DateTime())
            //{
            //    clsMessageBox.MessageBoxSubject = "اعتبار نرم افزار به پایان رسیده است" + "\n" + "لطفا با مدیریت تماس بگیرید";
            //    new WinInfo().ShowDialog();
            //    Cursor = Cursors.Arrow;

            //    Application.Current.Shutdown();
            //}
            //}
            //else
            //    new crack().ShowDialog();

            TxtUser.Focus();
            Cursor = Cursors.Arrow;
        }
        private void login(string username, string password)
        {
            try
            {
                //var q = lstAccount.Where(c => c.AccountUser == username && c.AccountPassword == password);
                //if (q.Count() > 0)
                //{
                //    //ClsUsersLogin.User = q.First();
                //    //ClsUsersLogin.Dore = lstDore.First(f => f.DorePuID.ToString() == comDore.SelectedValue.ToString());
                //    //var qCompany = ClsDB<MyDB.BusinessLayer.Models.Company>.GetAll();
                //    //if (qCompany.Count > 0)
                //    //    ClsUsersLogin.Company = qCompany.First();
                //    new MainWindow().Show();
                //    // this.Close();
                //}
                //else
                //{
                //    clsMessageBox.MessageBoxSubject = "نام کاربری و رمز عبور اشتباه است";
                //    new WinInfo().ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                clsMessageBox.MessageBoxSubject = ex.Message;
                new WinInfo().ShowDialog();
            }
        }
        private void Hidden()
        {
            txtname.Text = string.Empty;
            TxtPas.Clear();
            TxtPas.Visibility = Visibility.Hidden;
            BtnEnter.Visibility = Visibility.Hidden;
        }

        private void Visible()
        {
            TxtPas.Visibility = Visibility.Visible;
            //comDore.Visibility = Visibility.Visible;
            //exit.Visibility = Visibility.Visible;
            BtnEnter.Visibility = Visibility.Visible;
        }
        private void btnname_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (TxtUser.Text == "DadePardazi")
                {
                    Visible();
                    txtname.Text = "شرکت داده پردازی";
                    TxtPas.Focus();
                }
                else
                {
                    var q = lstAccount.Where(c => c.AccountUser == TxtUser.Text);
                    if (q.Count() > 0)
                    {
                        Visible();
                        txtname.Text = q.First().AccountName + " " + q.First().AccountFamily;
                        TxtPas.Focus();
                    }
                    else
                    {
                        txtname.Text = "نام کاربری اشتباه وارد شده است";
                        Hidden();
                    }
                }
            });
        }

        private void TxtUser_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TxtPas != null && TxtPas.Visibility == Visibility.Visible)
                Hidden();
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && TxtUser.Text != string.Empty)
                btnnamek.Focus();
        }

        private void TxtPas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && TxtPas.Text != string.Empty)
                BtnEnter.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hidden();
        }
    }
} 