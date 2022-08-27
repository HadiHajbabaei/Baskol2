using System;
using System.Collections.Generic;
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

namespace Baskol
{
    /// <summary>
    /// Interaction logic for WinYesOrNo.xaml
    /// </summary>
    public partial class WinYesOrNo : RadWindow
    {
        public WinYesOrNo()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtSubject.Text = clsMessageBox.MessageBoxSubject;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            clsMessageBox.Ok = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            clsMessageBox.Ok = false;
            Close();
        }
    }
}
