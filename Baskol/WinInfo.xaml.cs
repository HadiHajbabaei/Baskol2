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
    /// Interaction logic for WinInfo.xaml
    /// </summary>
    public partial class WinInfo : RadWindow
    {
        public WinInfo()
        {
            InitializeComponent();
        }
 
            private void RadWindow_Loaded(object sender, RoutedEventArgs e)
            {
                txtSubject.Text = clsMessageBox.MessageBoxSubject;
            }

            private void RadWindow_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter || e.Key == Key.Escape)
                    this.Close();
            }

            private void btnYes_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
        }

    }

