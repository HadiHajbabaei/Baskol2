using Baskol.Report.PrivateCalss;
using Library35.Globalization;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Baskol.Report
{
    /// <summary>
    /// Interaction logic for wReportTozin.xaml
    /// </summary>
    public partial class wReportTozin : UserControl
    {
        public wReportTozin()
        {
            InitializeComponent();
        }
        private List<ClsReport> lstclsReport;
        private List<View_TozinComplete> lstview_TozinCompletes;
        private List<ClsReport> lstPrint;
        private Stimulsoft.Report.StiReport report;
        private clsPrint print;
        private string start, end;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lstclsReport = new List<ClsReport>();
            dgv.AutoGenerateColumns = false;
            lstPrint = new List<ClsReport>();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            start = persianDateTime.ParsePersian(mskaz.Text).ToDateTime().ToString("yyyy-MM-dd");
            end = persianDateTime.ParsePersian(mskta.Text).ToDateTime().ToString("yyyy-MM-dd");
            lstview_TozinCompletes = ClsDB<View_TozinComplete>.GetAllByDate("Tozin2DateTime", start, end);

            Dispatcher.Invoke(() =>
            {
                var show = (from i in lstview_TozinCompletes

                            select new ClsReport
                            {
                                CustomerName = i.CustomerName,
                                DriverName = i.DriverName,
                                SabtMahsolName = i.SabtMahsolName,
                                Pelak=i.DriverTagNumber,
                                Tozin1Date = i.Tozin1Date != string.Empty ? i.Tozin1Date : "",
                                TozinGhabz = i.Tozin2Ghabz.Value,
                                Tozin1Time = i.Tozin1Time != string.Empty ? i.Tozin1Time : "",
                                Tozin2Time = i.Ttype == 0 ? i.Tozin2Time : "",
                                Tozin2Date = i.Ttype == 0 ? i.Tozin2Date : "",
                                VahedName = i.VahedName,
                                weight = i.Ttype == 0 ? i.Tozin1Weighte.Value > i.Tozin2Weighte.Value ? i.Tozin1Weighte.Value - i.Tozin2Weighte.Value : i.Tozin2Weighte.Value - i.Tozin1Weighte.Value : i.Tozin2Weighte.Value,
                                Tozin1Weighte = i.Tozin1Weighte.HasValue ? i.Tozin1Weighte.Value : 0,
                                Tozin2Weighte = i.Ttype == 0 ? i.Tozin2Weighte.HasValue ? i.Tozin2Weighte.Value : 0 : 0,
                                Ttype = i.Ttype.Value == 0 ? "دو توزین" : "تک توزین"
                            }).ToList();
                dgv.ItemsSource = null;
                dgv.ItemsSource = show;
                lstclsReport.AddRange(show);
            });
        }

        private void btnSabt_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnPrint_Click()
        {
            var printi = (from i in lstclsReport
                          select new ClsReport
                          {
                              CustomerName = i.CustomerName,
                              DriverName = i.DriverName,
                              SabtMahsolName = i.SabtMahsolName,
                              Tozin1Date = i.Tozin1Date,
                              Tozin1Time = i.Tozin1Time,
                              Tozin1Weighte = i.Tozin1Weighte,
                              Tozin2Date = i.Tozin2Date,
                              Tozin2Time = i.Tozin2Time,
                              Tozin2Weighte = i.Tozin2Weighte,
                              TozinGhabz = i.TozinGhabz,
                              Ttype = i.Ttype,
                              VahedName = i.VahedName,
                              weight = i.weight,
                              Pelak=i.Pelak
                          }).ToList();
            lstPrint.Clear();
            lstPrint.AddRange(printi);
            print = new clsPrint();
            report = new Stimulsoft.Report.StiReport();
            report.Load(".\\Reprte\\Tozins.mrt");
            //report.Dictionary.Variables["Date"].Value = persianDateTime.ParseEnglish(new ClsDateTime().getDateTime().Rows[0][0].ToString()).ToString("yyyy/MM/dd");
            //report.Dictionary.Variables["Company"].Value = string.IsNullOrEmpty(ClsUsersLogin.Company.CompanyName) ? "شرکت ثبت نشده است" : ClsUsersLogin.Company.CompanyName;
            //report.Dictionary.Variables.Add("Logo", MyConverter.ToImage(ClsUsersLogin.Company.CompanyLogo));

        }
        private void PrintFinish()
        {
            if (lstPrint.Count() > 0)
            {
                LoadingBusyIndicator.IsBusy = false;
                print.print<ClsReport>(report, lstPrint);
            }
            LoadingBusyIndicator.IsBusy = false;
        }
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

            clsMessageBox.MessageBoxSubject = clsMessageBox.QustionPrint;
            new WinYesOrNo().ShowDialog();
            if (clsMessageBox.Ok)
            {
                LoadingBusyIndicator.BusyContent = clsMessageBox.Print;
                LoadingBusyIndicator.IsBusy = true;
                var worker = new BackgroundWorker();
                worker.DoWork += (s, ev) => btnPrint_Click();
                worker.RunWorkerCompleted += (s, ev) => PrintFinish();
                worker.RunWorkerAsync();
            }

           
        }
    }
}
