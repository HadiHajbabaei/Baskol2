using Darayi_Sabet.Excel;
using Library35.Globalization;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Darayi_Sabet.W_darayi
{
    /// <summary>
    /// Interaction logic for WinDarayi.xaml
    /// </summary>
    public partial class WinDarayi : UserControl
    {
        public WinDarayi()
        {
            InitializeComponent();
        }
        private List<Calculate> calculates;
        private List<MyDB.BusinessLayer.Models.Category> categories;
        private List<Jamdar> jamdar;
        private List<MyDB.BusinessLayer.Models.Customer> customers;
        private List<MyDB.BusinessLayer.Models.MahalKhedmat> mahalkhedmat; 
        private List<MyDB.BusinessLayer.Models.MarkazHazine> markazHazines;
        private List<View_Darayi> Darayis;
        private List<MyDB.BusinessLayer.Models.Darayi> lstDarayi, lstInsert, lstUpdate;
        private MyDB.BusinessLayer.Models.Darayi darayi;
        private Object obj;
        private P.Class.Player player;
        private List<P.Class.Player> lstplayer, lstplayer2;
        private P.Class.Player p, p2;
        private double a, b, c;
        private void message()
        {
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
        }

        private void addPlayer()
        {
            if (Darayis.Count > 0)
            {
                var q = (from i in Darayis
                         select new
                         {
                             i.DarayiName,
                             i.DarayiCod,
                             i.DarayiPelak,
                             i.CatName,
                             i.DarayiDatetime,
                             i.DarayiDateUSE,
                             i.DarayiRaveshMohasebe,
                             i.DarayiPrice,
                             i.DarayiPriceTransfer,
                             i.DarayiOtherPrice,
                             i.DarayiEndPrice,
                             i.DarayiOmrMofid,
                             i.DarayiArzesh,
                             i.DarayiNerkhEstehlak,
                             i.DarayiEstehlakAnbashte,
                             i.CalcName,
                         }).ToList();
                lstplayer.Clear();
                foreach (var i in q)
                {
                    p = new P.Class.Player()
                    {
                        DarayiName = i.DarayiName,
                        DarayiCod = i.DarayiCod,
                        DarayiPelak = i.DarayiPelak,
                        CatName = i.CatName,
                        DarayiDatetime = i.DarayiDatetime.HasValue ? PersianDateTime.ParseEnglish(i.DarayiDatetime.Value.ToString("yyyy-MM-dd")).ToString("yyyy/MM/dd") : "---",
                        DarayiDateUSE = i.DarayiDateUSE.HasValue ? PersianDateTime.ParseEnglish(i.DarayiDateUSE.Value.ToString("yyyy-MM-dd")).ToString("yyyy/MM/dd") : "---",
                        DarayiRaveshMohasebe = i.DarayiRaveshMohasebe,
                        DarayiPrice = i.DarayiPrice,
                        DarayiPriceTransfer = i.DarayiPriceTransfer,
                        DarayiOtherPrice = i.DarayiOtherPrice,
                        DarayiEndPrice = i.DarayiEndPrice,
                        DarayiOmrMofid = i.DarayiOmrMofid,
                        DarayiArzesh = i.DarayiArzesh,
                        DarayiNerkhEstehlak = long.Parse(i.DarayiNerkhEstehlak.ToString()),
                        DarayiEstehlakAnbashte = i.DarayiEstehlakAnbashte,
                        CalcName = i.CalcName,

                    };
                    lstplayer.Add(p);
                }
            }
        }

        private void UserControl_Loaded()
        {
            lstplayer = new List<P.Class.Player>();
            calculates = ClsDB<Calculate>.GetAll();
            categories = ClsDB<MyDB.BusinessLayer.Models.Category>.GetAll();
            mahalkhedmat = ClsDB<MyDB.BusinessLayer.Models.MahalKhedmat>.GetAll();
            markazHazines = ClsDB<MyDB.BusinessLayer.Models.MarkazHazine>.GetAll();
            jamdar = ClsDB<Jamdar>.GetAll();
            lstDarayi = ClsDB<MyDB.BusinessLayer.Models.Darayi>.GetAll();
            Darayis = ClsDB<MyDB.BusinessLayer.Models.View_Darayi>.GetAll();
            customers = ClsDB<MyDB.BusinessLayer.Models.Customer>.GetAllBy("CustomerEnable", true);
            lstInsert = new List<MyDB.BusinessLayer.Models.Darayi>();
            lstUpdate = new List<MyDB.BusinessLayer.Models.Darayi>();
            Dispatcher.Invoke(() =>
            {
                comhazine.ItemsSourceProvider.ItemsSource = markazHazines;
                commahal.ItemsSourceProvider.ItemsSource = mahalkhedmat;
                comRavesh.ItemsSource = calculates;
                ComNameGroup.ItemsSourceProvider.ItemsSource = categories;
                comSeller.ItemsSourceProvider.ItemsSource = customers;
                comjamdarVahed.ItemsSourceProvider.ItemsSource = jamdar;
            });
            dgv_Loaded();
        }

        //private void CheckTime()
        //{
        //    DateTime get = new DateTime(long.Parse( TxtgetJamdar.Value.ToString()));
        //    DateTime set = new DateTime(long.Parse(TxtSetJamdar.Value.ToString()));

        //    TimeSpan dif = get - set;
        //}
        private void dgv_Loaded()
        {
            addPlayer();
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstplayer;
                
            });

        }
        private void TxtSeller_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            comSeller.CloseDropDown();
        }

        private void ComRavesh_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void save()
        {
            //if (dgv.SelectedItem == null)
            //{
                darayi = new Darayi();
                darayi.DarayiName = TxtNameDarayi.Text;
                darayi.DarayiCod = int.Parse(TxtCodDarayi.Value.ToString());
                darayi.DarayiOmrMofid = long.Parse(TxtOmrMofid.Value.ToString());
                darayi.DarayiRaveshMohasebe = int.Parse(comRavesh.SelectedValue.ToString());
            darayi.DarayiMahalKhedmat = int.Parse(commahal.SelectedValue.ToString());
            darayi.DarayiMarkazHazinePuid = int.Parse(comhazine.SelectedValue.ToString());
            darayi.DarayiDatetime = PersianDateTime.ParsePersian(TxtDateDarayi.Text).ToDateTime();
            darayi.DarayiPrice = long.Parse(TxtPrice.Value.ToString());
            //darayi.DarayiArzesh = long.Parse(TxtArzesh.Value.ToString());
            darayi.DarayiGroup = int.Parse(ComNameGroup.SelectedValue.ToString());
                darayi.DarayiPriceTransfer = long.Parse(TxtPriceTransfer.Value.ToString());
                darayi.DarayiNerkhEstehlak = long.Parse(TxtNerkhEstehlak.Value.ToString());
                darayi.DarayiDateUSE = PersianDateTime.ParsePersian(TxtDateUse.Text).ToDateTime();
                darayi.DarayiPelak = long.Parse(TxtShomarePelak.Text);
                darayi.DarayiOtherPrice = long.Parse(TxtOtherPrice.Value.ToString());
                darayi.DarayiEstehlakAnbashte = long.Parse(TxtEstehlakAnbshte.Value.ToString());
                darayi.DarayiSeller = int.Parse(comSeller.SelectedValue.ToString());
                darayi.DarayiBrand = TxtBrand.Text;
                darayi.DarayiEndPrice = int.Parse(TxtEndPrice.Text.ToString());
                darayi.DarayiColor = TxtColor.Text;
                darayi.DarayiBarkod = long.Parse(TxtBarcod.Text.ToString());
                darayi.DarayiDateMake = PersianDateTime.ParsePersian(TxtDateMake.Text).ToDateTime();
                darayi.DarayiModel = TxtModel.Text;
                darayi.DarayiJamdarVahed = int.Parse(comjamdarVahed.SelectedValue.ToString());
                darayi.DarayiDateGetJamdar = PersianDateTime.ParsePersian(TxtgetJamdar.Text).ToDateTime();
                darayi.DarayiDateSetJamdar = PersianDateTime.ParsePersian(TxtSetJamdar.Text).ToDateTime();
                darayi.DarayiDescription = TxtDescription.Text;
                lstInsert.Add(darayi);
                ClsDB<MyDB.BusinessLayer.Models.Darayi>.BulkInsert(lstInsert);
                clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSabt;
                new WinInfo().ShowDialog();
            //}
            //else
            //{

            //}
          
            dgv_Loaded();

           
        }

        private void btnForward_Click(object sender, RoutedEventArgs e) 
        {
            switch (tbcMorshedloo.SelectedIndex)
            {
                case 0:
                    if (new Checking().Grid(grdBaseInfo))
                    {
                        tbcMorshedloo.SelectedIndex = 1;
                    }
                    break;
                       
                case 1:
                    tbcMorshedloo.SelectedIndex = 2;
                    break;

                case 2:
                    if (new Checking().Grid(grdsabt))
                    {
                        btnForward.Content=null;
                        btnForward.Content = "ثبت";
                        save();
                    }
                    break;
            }
        }


        //private void KeyUp(object sender, KeyEventArgs e)
        //{



        //    if (((RadMaskedNumericInput)sender).Value == 0 && ((RadMaskedNumericInput)sender).BorderBrush == Brushes.Red)
        //        ((RadMaskedNumericInput)sender).BorderBrush = Brushes.Black;

        //}

        private void TxtDateDarayi_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void com_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comRavesh.SelectedIndex >= 0 && comRavesh.BorderBrush == Brushes.Red)
                comRavesh.BorderBrush = Brushes.Black;
            if (comRavesh.SelectedIndex == 1)
            {
                TxtOmrMofid.IsReadOnly = true;

            }
            else
            {
                TxtOmrMofid.IsReadOnly = false;
            }
            if(comRavesh.SelectedIndex == 0)
            {
                TxtNerkhEstehlak.IsReadOnly = true;
            }
            else
            {
                TxtNerkhEstehlak.IsReadOnly = false;
            }
        }

        private void comSeller_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (comSeller.SelectedIndex >= 0 && comSeller.BorderBrush == Brushes.Red)
                comSeller.BorderBrush = Brushes.Black;
        }

        private void ComNameGroup_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (ComNameGroup.SelectedIndex >= 0 && ComNameGroup.BorderBrush == Brushes.Red)
                ComNameGroup.BorderBrush = Brushes.Black;
        }

        private void TxtArzesh_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void KeyUpc(object sender, KeyEventArgs e)
        {
            if (((RadMaskedCurrencyInput)sender).Value == 0 && ((RadMaskedCurrencyInput)sender).BorderBrush == Brushes.Red)
                ((RadMaskedCurrencyInput)sender).BorderBrush = Brushes.Black;
        }

        private void KeyUpt(object sender, KeyEventArgs e)
        {
            if (((RadMaskedTextInput)sender).Value != string.Empty && ((RadMaskedTextInput)sender).BorderBrush == Brushes.Red)
                ((RadMaskedTextInput)sender).BorderBrush = Brushes.Black;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((RadWatermarkTextBox)sender).Text != string.Empty && ((RadWatermarkTextBox)sender).BorderBrush == Brushes.Red)
                ((RadWatermarkTextBox)sender).BorderBrush = Brushes.Black;
        }

        private void TxtPriceTransfer_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (TxtPriceTransfer.Value.ToString() != String.Empty)
            {
                b = long.Parse(TxtPriceTransfer.Value.ToString());
               
            }
            else
            {
                b = 0;

            }
            TxtEndPrice.Text = (TxtPrice.Value + TxtOtherPrice.Value + b).ToString();
        }

        private void TxtOtherPrice_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (TxtOtherPrice.Value.ToString() != String.Empty)
            {
              c = long.Parse(TxtOtherPrice.Value.ToString());
            }
            else
            {
               c = 0;
            }
            TxtEndPrice.Text = (TxtPrice.Value + TxtPriceTransfer.Value + c).ToString();
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TxtPrice_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TxtOtherPrice_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnexcel_Click(object sender, RoutedEventArgs e)
        {
            new wExcel().ShowDialog();
            UserControl_Loaded();
        }

        //private void btnexcel_Click(object sender, RoutedEventArgs e)
        //{
        //    new Excel().showdialoge();
        //}

        private void TxtPrice_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (TxtPrice.Value.ToString() != String.Empty)
            {
            a = long.Parse(TxtPrice.Value.ToString());
            }
            else
            {
                a = 0;
            }
            TxtEndPrice.Text = (TxtOtherPrice.Value +  TxtPriceTransfer.Value + a).ToString();

        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            if (((RadWatermarkTextBox)sender).Text != string.Empty && ((RadWatermarkTextBox)sender).BorderBrush == Brushes.Red)
                ((RadWatermarkTextBox)sender).BorderBrush = Brushes.Black;
        }

        private void ComNameGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ComNameGroup.CloseDropDown();
        }

        private void comjamdarVahed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            comjamdarVahed.CloseDropDown();
        }


        private void dgv_SelectionChanged_1(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            obj = dgv.SelectedItem;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingBusyIndicator.BusyContent = clsMessageBox.Load;
            LoadingBusyIndicator.IsBusy = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, ev) => UserControl_Loaded();
            worker.RunWorkerCompleted += (s, ev) => LoadingBusyIndicator.IsBusy = false;
            worker.RunWorkerAsync();
        }
    }
}

