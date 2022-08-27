using Baskol.Factor.PrivateClass;
using Library35.Globalization;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Cyber.Models;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Numerics;

namespace Baskol.Factor
{
    /// <summary>
    /// Interaction logic for wFactor.xaml
    /// </summary>
    public partial class wFactor : UserControl
    {
        public wFactor()
        {
            InitializeComponent();
        }

        private List<ClsFactor> lstClsFactor;
        private List<View_TozinComplete> lstview_TozinCompletes;
        private List<SabtCustomer> lstSabtCustomer;
        private List<AC_3601_N> lstAC_3601_N;
        private List<AC_0101_N> lstAC_0101_N;
        private List<AC_0602_N> lstAC_0602_N;
        private List<AC_3001_N> lstAC_3001_N;
        private int invType, invNo, c, _darsad, STID, AccountId, invH;
        private string start, end;
        private string dore, date, desc;

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            start = persianDateTime.ParsePersian(mskaz.Text).ToDateTime().ToString("yyyy-MM-dd");
            end = persianDateTime.ParsePersian(mskta.Text).ToDateTime().ToString("yyyy-MM-dd");
            lstview_TozinCompletes = ClsDB<View_TozinComplete>.GetAllByNotInDate("Tozin2PuID", "Tozin2PuID", "Tozin1DateTime", start, end, "Factor");

            Dispatcher.Invoke(() =>
            {
                var show = (from i in lstview_TozinCompletes

                            select new ClsFactor
                            {
                                AccountNumber = i.CustomerAccountNumber1,
                                ItemCode = i.ItemCode,
                                SabtMahsolPuID = i.SabtMahsolPuID,
                                CustomerPuID = int.Parse(i.CustomerPuID.ToString()),
                                CustomerName = i.CustomerCode + i.CustomerName,
                                DriverName = i.DriverTagNumber + i.DriverName,
                                SabtMahsolName = i.SabtMahsolCod.Value + i.SabtMahsolName,
                                Pelak = i.DriverTagNumber,
                                Tozin1Date = !i.Tozin1Date.Equals(string.Empty) ? i.Tozin1Date : "",
                                TozinGhabz = i.Tozin2Ghabz.Value,
                                Tozin1Time = !i.Tozin1Time.Equals(string.Empty) ? i.Tozin1Time : "",
                                Tozin2Time = i.Ttype == 0 ? i.Tozin2Time : "",
                                Tozin2Date = i.Ttype == 0 ? i.Tozin2Date : "",
                                VahedName = i.VahedName,
                                weight = i.Ttype == 0 ? i.Tozin1Weighte.Value > i.Tozin2Weighte.Value ? i.Tozin1Weighte.Value - i.Tozin2Weighte.Value : i.Tozin2Weighte.Value - i.Tozin1Weighte.Value : i.Tozin2Weighte.Value,
                                Tozin1Weighte = i.Tozin1Weighte.HasValue ? i.Tozin1Weighte.Value : 0,
                                Tozin2Weighte = i.Ttype == 0 ? i.Tozin2Weighte.HasValue ? i.Tozin2Weighte.Value : 0 : 0,
                                Ttype = i.Ttype.Value == 0 ? "دو توزین" : "تک توزین",
                                Anbar = i.SabtMahsolAnbar.Value,
                                refr = "",
                                des = "",
                                price = i.SabtMahsolPrice.HasValue ? i.SabtMahsolPrice.Value : 0,
                                Select = false
                            }).ToList();
                dgv.ItemsSource = null;
                dgv.ItemsSource = show;
                lstClsFactor.AddRange(show);
                dgv_loaded();
            });
        }
        private void dgv_loaded()
        {
            Dispatcher.Invoke(() =>
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = lstClsFactor;
            });
        }
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstClsFactor.Count() == lstClsFactor.Count(c => c.Select == false))
                lstClsFactor.ForEach(f => f.Select = true);
            else
                lstClsFactor.ForEach(f => f.Select = false);
            dgv_loaded();
        }

        private void ComAnbar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComAnbar.SelectedValue != null)
                STID = (int)ComAnbar.SelectedValue;
            else
                STID = 0;
        }

        private void btnDoc_Click()
        {
            c = 0;
            invNo = MyDB.BusinessLayer.Cyber.ClsDB<AC_4101_N>.GetAllByMaxInt("InvNo", "InvTyp", invType);

            date = new ClsDateTime().DateTime().ToString("yyyy-MM-dd");
            foreach (var i in dgv.Items)
            {
                try
                {
                    string.IsNullOrEmpty(((ClsFactor)i).Tozin2Weighte.ToString());
                }
                catch
                {
                    continue;
                }
                if (!((ClsFactor)i).Select)
                    continue;                    
                var q = lstAC_0602_N.Where(w => w.JobNumber == (((ClsFactor)i).AccountNumber)).ToList();
                if (q.Count() == 0)
                {
                    clsMessageBox.MessageBoxSubject = ((ClsFactor)i).CustomerName + Environment.NewLine + "تفصیلی اشتباه است";
                    new WinInfo().ShowDialog();
                    continue;
                }
                var qKala = lstAC_3001_N.Where(w => w.ItemCode.Equals(((ClsFactor)i).ItemCode));
                if (qKala.Count() == 0)
                {
                    clsMessageBox.MessageBoxSubject = ((ClsFactor)i).CustomerName + Environment.NewLine + "کد محصول شایگان اشتباه است";
                    new WinInfo().ShowDialog();
                    continue;
                }


                MyDB.BusinessLayer.Cyber.ClsDB<AC_4101_N>.ExecuteQuery(@"insert into AC_4101_N(InvTyp,InvNo,InvDescription,InvDate,CreateDate,CurrencyId,Rate,AccountId,JobCostingId,tick,
                                    firstissuerid,lastissuerid,printed)
	        values('" + invType + "','" + ++invNo + "','" + desc + "','" + date + "'," +
                    " '" + date + "','1','1','" + AccountId + "', '" + q.First().JobId + "','0','10','10','0') ");

                invH = MyDB.BusinessLayer.Cyber.ClsDB<AC_4101_N>.GetAllByMaxInt("InvHeaderId", "InvTyp", invType);

                MyDB.BusinessLayer.Cyber.ClsDB<AC_4101_N>.ExecuteQuery(@"insert into AC_4001_N(InvHeaderId,LineItemOrder,ItemId, STID,Quan,Price,Rial,CurRial, lineitemDesc) " +
                                "values(" + invH + ",'1','" + qKala.First().ItemId + "','" + STID + "', " +
                                " " + ((ClsFactor)i).weight.Value.ToString().Replace("/", ".") + "," +
                                "" + ((ClsFactor)i).price.Value.ToString().Replace("/", ".") + "," +
                                "" + BigInteger.Multiply((BigInteger)((ClsFactor)i).weight.Value, (BigInteger)((ClsFactor)i).price.Value).ToString().Replace("/", ".") + "," +
                                "" + BigInteger.Multiply((BigInteger)((ClsFactor)i).weight.Value, (BigInteger)((ClsFactor)i).price.Value).ToString().Replace("/", ".") + ",'')");

                //           MyDB.BusinessLayer.Cyber.ClsDB<AC_4101_N>.ExecuteQuery(@"declare @InvHeader as int
                //insert into AC_4101_N(InvTyp,InvNo,InvDescription,InvDate,CreateDate,CurrencyId,Rate,AccountId,JobCostingId,tick,
                //                           firstissuerid,lastissuerid,printed)
                //values('" + invType + "','" + invNo + "','" + ((ClsFactor)i).des + "','" + new ClsDateTime().DateTime().ToString("yyyy-MM-dd") + "'," +
                //       " '" + new ClsDateTime().DateTime().ToString("yyyy-MM-dd") + "','1','1','" + ComAccount.SelectedValue + "', '" + q.First().JobId + "','0','10','10','0') " +

                //       "select @InvHeader=ISNULL(max(InvHeaderId),1) from AC_4101_N " +
                //       "insert into AC_4001_N(InvHeaderId,LineItemOrder,ItemId, STID,Quan,Price,Rial,CurRial, lineitemDesc) " +
                //       "values(@InvHeader,'1025','" + qKala.First().ItemId + "','" + STID + "', " +
                //       " " + ((ClsFactor)i).weight.Value.ToString().Replace("/", ".") + "," + ((ClsFactor)i).price.ToString().Replace("/", ".") + "," + (((ClsFactor)i).price.Value * ((ClsFactor)i).weight.Value).ToString().Replace("/", ".") + "," + (((ClsFactor)i).price.Value * ((ClsFactor)i).weight.Value).ToString().Replace("/", ".") + ",'')");

                c++;
                _darsad = (c * 100) / dgv.Items.Count;
                Dispatcher.Invoke(() =>
                {
                    LoadingBusyIndicator.BusyContent = clsMessageBox.Sabt + "\n"
                   + "%" + _darsad;
                });
            }
        }
        private void btnDoc_Com()
        {
            clsMessageBox.MessageBoxSubject = clsMessageBox.SucssesfullSabt;
            lstClsFactor.Clear();
            dgv_loaded();
            LoadingBusyIndicator.IsBusy = false;
            new WinInfo().ShowDialog();
        }

        private bool chk()
        {
            //چک ها رو بنویس

            return false;
        }

        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (dgv.Items.Count > 0)
            {
                clsMessageBox.MessageBoxSubject = clsMessageBox.QustionSabt;
                new WinYesOrNo().ShowDialog();
                if (clsMessageBox.Ok)
                {
                    if (chk())
                    {
                        AccountId = (int)ComAccount.SelectedValue;
                        desc = txtDesc.Text;
                        invType = ComType.SelectedIndex == 0 ? 2 : 3;
                        LoadingBusyIndicator.BusyContent = clsMessageBox.Sabt + "\n%0";
                        LoadingBusyIndicator.IsBusy = true;
                        var worker = new BackgroundWorker();
                        worker.DoWork += (s, ev) => btnDoc_Click();
                        worker.RunWorkerCompleted += (s, ev) => btnDoc_Com();
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

        private void Chk_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Chk_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            date = persianDateTime.ParseEnglish(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
            var cyber = ClsDB<MyDB.BusinessLayer.Models.Cyber>.GetAllBy("CyberSelect", true);
            if (cyber.First().CyberDore.ToString().Length == 1)
                dore = "0" + cyber.First().CyberDore;
            else
                dore = cyber.First().CyberDore.ToString();
            MyDB.BusinessLayer.Cyber.ConnectionString.myConnection = "Data Source=" + cyber.First().CyberServer + ";Initial Catalog=CY" + cyber.First().CyberKholase + dore + ";User ID=" + cyber.First().CyberUsername + ";Password=" + Crypt.Decrypt(cyber.First().CyberPassword) + ";MultipleActiveResultSets=true;";
            lstAC_3601_N = MyDB.BusinessLayer.Cyber.ClsDB<AC_3601_N>.GetAll();
            lstAC_0101_N = MyDB.BusinessLayer.Cyber.ClsDB<AC_0101_N>.GetAll();
            lstAC_3001_N = MyDB.BusinessLayer.Cyber.ClsDB<AC_3001_N>.GetAll();
            lstSabtCustomer = ClsDB<SabtCustomer>.GetAll();
            lstAC_0602_N = MyDB.BusinessLayer.Cyber.ClsDB<AC_0602_N>.GetAll();
            var qAcc = (from i in lstAC_0101_N
                        select new
                        {
                            i.AccountId,
                            AccountNumber = i.AccountNumber + " - " + i.AccountName
                        }).ToList();
            var qAnbar = (from i in lstAC_3601_N
                          select new
                          {
                              i.STID,
                              StDesc = i.STNumber + " - " + i.StDesc
                          }).ToList();
            ComAccount.ItemsSource = qAcc;
            ComAnbar.ItemsSource = qAnbar;
            dgv.AutoGenerateColumns = false;
            lstClsFactor = new List<ClsFactor>();
        }
    }
}
