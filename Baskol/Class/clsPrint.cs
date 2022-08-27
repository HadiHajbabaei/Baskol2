using Stimulsoft.Report;
using System.Collections.Generic;
class clsPrint
{
    private StiReport report;
    /// <summary>
    /// Print
    /// </summary>
    /// <typeparam name="T">Type List</typeparam>
    /// <param name="lstGetDatePrint">Item List</param>
    /// <param name="FileName">File Name or Path</param>
    public void print<T>(List<T> lstGetDatePrint, string FileName)
    {
        this.report = new StiReport();
        this.report.Load(".\\Report\\" + FileName + ".mrt");
        this.report.RegData("lstGetDatePrint", verify.ConvertToDataTable(lstGetDatePrint));
        this.report.Show();
    }

    /// <summary>
    /// Print
    /// </summary>
    /// <typeparam name="T">Type List</typeparam>
    /// <param name="report">File Report</param>
    /// <param name="lstGetDatePrint">Item List</param>
    public void print<T>(StiReport report, List<T> lstGetDatePrint)
    {
        this.report = report;
        this.report.RegData("lstGetDatePrint", verify.ConvertToDataTable(lstGetDatePrint));
        this.report.Show();
    }
}

