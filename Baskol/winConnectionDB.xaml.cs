 
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Baskol
{
    /// <summary>
    /// Interaction logic for winConnectionDB.xaml
    /// </summary>
    public partial class winConnectionDB : RadRibbonWindow
    {
        public winConnectionDB()
        {
            InitializeComponent();
        }

        private string crpt;
        private FileStream fs;
        private string[] arycontent;

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            crpt = "";
            if (txtSQl.Text != string.Empty && txtSA.Text != string.Empty && txtPassword.Password != string.Empty)
            {
                crpt = txtSQl.Text + ";" + txtSA.Text + ";" + txtPassword.Password;
                crpt = Crypt.Encrypt(crpt);
                if (File.Exists("DB.con"))
                    File.Delete("DB.con");
                fs = File.Create("DB.con");
                Byte[] info = new UTF8Encoding(true).GetBytes(crpt);
                fs.Write(info, 0, info.Length);
                fs.Close();
                clsMessageBox.MessageBoxSubject = "اطلاعات با موفقیت ذخیره شد";
                new WinInfo().ShowDialog();
                Cursor = Cursors.Arrow;
                Close();
            }
            else
            {
                if (txtSQl.Text == string.Empty)
                    crpt = "آدرس پایگاه داده وارد نشده";
                if (txtSA.Text == string.Empty)
                {
                    if (crpt == string.Empty)
                        crpt = "نام sa وارد نشده";
                    else crpt += "\n" + "نام sa وارد نشده";
                }
                if (txtPassword.Password == string.Empty)
                {
                    if (crpt == string.Empty)
                        crpt = "رمز عبور پایگاه داده وارد نشده";
                    else crpt += "\n" + "رمز عبور پایگاه داده وارد نشده";
                }
                clsMessageBox.MessageBoxSubject = crpt;
                new WinInfo().ShowDialog();
            }
            Cursor = Cursors.Arrow;
        }

        private void RadRibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("DB.con"))
            {
                crpt = File.ReadAllText("DB.con");
                if (crpt != string.Empty)
                {
                    crpt = Crypt.Decrypt(crpt);
                    arycontent = crpt.Split(';');
                    txtSQl.Text = arycontent[0];
                    txtSA.Text = arycontent[1];
                    txtPassword.Password = arycontent[2];
                }
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtSQl_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSQl.Text != string.Empty && e.Key == Key.Enter)
                txtSA.Focus();
        }

        private void txtSA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtSA.Text != string.Empty)
                txtPassword.Focus();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtPassword.Password != string.Empty)
                btnYes.Focus();
        }
    }
}

 