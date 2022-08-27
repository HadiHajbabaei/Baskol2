using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Library35.Globalization;
using System.Management;
class ClsPublic
{

    public string datePersian()
    {
        PersianCalendar p = new PersianCalendar();
        string yy = p.GetYear(DateTime.Now).ToString();
        string mm = p.GetMonth(DateTime.Now).ToString("00");
        string dd = p.GetDayOfMonth(DateTime.Now).ToString("00");
        string date = string.Format("{0}/{1}/{2}", yy, mm, dd);
        return date;
    }

    public static Dictionary<bool, string> getCPUID()
    {
        Dictionary<bool, string> id = new Dictionary<bool, string>();
        try
        {
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();

            foreach (ManagementObject mo in mbsList)
            {
                id.Add(true, mo["ProcessorID"].ToString());
                break;
            }
        }
        catch (Exception ex)
        {
            id.Add(false, ex.Message);
        }
        return id;
    }

    public void EmptyObject(Control contl)
    {

        foreach (Control con in contl.Controls)
        {
            if (con.GetType() == typeof(TextBox))
                con.Text = string.Empty;
        }
    }
    public DataTable ConvertToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties =
           TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
        {
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;

    }

    DateTime ret(object s)
    {
        string ret;
        DateTime r = Convert.ToDateTime(s);
        System.Globalization.PersianCalendar ps = new System.Globalization.PersianCalendar();
        ret = ps.GetYear(r).ToString() + "/" + ps.GetMonth(r).ToString() + "/" + ps.GetDayOfMonth(r).ToString();
        return Convert.ToDateTime(ret);
    }
    public DataTable Ret_Persian_Date(DataTable inp)
    {
        DataTable ret = new DataTable();
        foreach (DataColumn dc in inp.Columns)
        {
            if (dc.DataType == typeof(DateTime))
                ret.Columns.Add(dc.ColumnName, typeof(string));
            else
                ret.Columns.Add(dc.ColumnName, dc.DataType);
        }
        foreach (DataRow r in inp.Rows)
        {
            ret.Rows.Add(r.ItemArray);
        }
        foreach (DataColumn dc in inp.Columns)
            if (dc.DataType == typeof(DateTime))
                foreach (DataRow dr in ret.Rows)
                {

                    var i = persianDateTime.ParseEnglish(dr[dc.ColumnName].ToString());
                    dr[dc.ColumnName] = (i.Year.ToString().Length == 1 ? "0" + i.Year.ToString() : i.Year.ToString())

                        + "/" +
                        (i.Month.ToString().Length == 1 ? "0" + i.Month.ToString() : i.Month.ToString())
                          + "/" +
                           (i.Day.ToString().Length == 1 ? "0" + i.Day.ToString() : i.Day.ToString());
                }
        return ret;
    }
}

