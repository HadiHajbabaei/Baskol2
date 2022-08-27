using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using Library35.Globalization;
using DadePardazi;

public class verify
{

    static Regex reg;
    public static bool Is_Tel(string s)
    {
        reg = new Regex("0\\d{3}-\\d{7}");
        if (reg.IsMatch(s))
            return true;
        else
            return false;
    }
    public static bool Is_Mob(string s)
    {
        reg = new Regex("09\\d{9}");
        if (reg.IsMatch(s))
            return true;
        else
            return false;
    }

    public static string ReturnNameMonth(int Month)
    {
        switch (Month)
        {
            case 1:
                return "فروردین";
            case 2:
                return "اردیبهشت";
            case 3:
                return "خرداد";
            case 4:
                return "تیر";
            case 5:
                return "مرداد";
            case 6:
                return "شهریور";
            case 7:
                return "مهر";
            case 8:
                return "آبان";
            case 9:
                return "آذر";
            case 10:
                return "دی";
            case 11:
                return "بهمن";
            case 12:
                return "اسفند";
            default:
                return "";
        }
    }
    public static persianDateTime ReturnEndDateMounth(persianDateTime StartDate)
    {
        persianDateTime st = persianDateTime.ParsePersian(StartDate.ToDateString());
        while (st.Month <= StartDate.Month && st.Year <= StartDate.Year)
            st = persianDateTime.ParseEnglish(st.ToDateTime().AddDays(1).ToString());
        return persianDateTime.ParseEnglish(st.ToDateTime().Subtract(new TimeSpan(1, 0, 0, 0, 0)).ToString());
    }
    public static bool IS_CodeMeli(string ss)
    {
        try
        {
            char[] chArray = ss.ToCharArray();
            int[] numArray = new int[chArray.Length];
            for (int i = 0; i < chArray.Length; i++)
            {
                numArray[i] = (int)char.GetNumericValue(chArray[i]);
            }
            int num2 = numArray[9];
            switch (ss)
            {
                case "0000000000":
                case "1111111111":
                case "22222222222":
                case "33333333333":
                case "4444444444":
                case "5555555555":
                case "6666666666":
                case "7777777777":
                case "8888888888":
                    MessageBox.Show("کد ملی وارد شده صحیح نمی باشد");
                    return false;

            }
            int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
            int num4 = num3 - ((num3 / 11) * 11);
            if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
            {
                //  MessageBox.Show("کد ملی صحیح می باشد");

                return true;
            }
            else
            {
                MessageBox.Show("کد ملی نامعتبر است");
                return false;
            }
        }
        catch (Exception)
        {
            MessageBox.Show("لطفا یک عدد 10 رقمی وارد کنید");
            return false;
        }
    }
    public static void IntTxT(KeyPressEventArgs e)
    {
        if ((e.KeyChar >= 48) && (e.KeyChar <= 59) || (e.KeyChar == 8))
        {
            e.Handled = false;
        }
        else
            e.Handled = true;
    }
    public static void StringTxT(KeyPressEventArgs e)
    {
        if ((e.KeyChar >= 48) && (e.KeyChar <= 59))
        {
            e.Handled = true;
        }
        else
            e.Handled = false;

    }
    public static bool CheckDate(string strdate)
    {
        persianDateTime strdate1;
        if (persianDateTime.TryParsePersian(strdate, out strdate1))
            return true;
        return false;
    }
    public static bool IsValidTime(string IsTime)
    {
        Regex checktime = new Regex(@"^(?:(?:0?[0-9]|1[0-2]):[0-5][0-9]\s?(?:(?:[Aa]|[Pp])[Mm])?|(?:1[3-9]|2[0-3]):[0-5][0-9])$");
        return checktime.IsMatch(IsTime);
    }

    public static bool IsValidEmailAdress(string Email)
    {
        try
        {
            var mail = new System.Net.Mail.MailAddress(Email);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static void ObjectEmptyForm(Control _Control)
    {
        foreach (Control ctl in _Control.Controls)
        {
            if (ctl.GetType() == typeof(MaskedTextBox))
            {
                if (ctl.Text.Contains(":"))
                    ctl.Text = "00:00";
                else if (ctl.Text.Contains("/"))
                    ctl.Text = "";
                else ctl.Text = "";
                continue;
            }

            if (ctl.GetType() == typeof(CheckBox))
            {
                CheckBox obj = (CheckBox)ctl;
                obj.Checked = false;
                continue;
            }

            if (ctl.GetType() == typeof(TextBox))
            { ctl.Text = ""; continue; }
            if (ctl.GetType() == typeof(System.Windows.Forms.CheckBox))
            { System.Windows.Forms.CheckBox c = (System.Windows.Forms.CheckBox)ctl; c.Checked = false; continue; }

            if (ctl.Controls.Count > 0)
            { ObjectEmptyForm(ctl); }

        }

    }

    public static DataTable ConvertToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties =
           TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)

            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;
    }

    public static string ret(object s)
    {

        DateTime dtm = Convert.ToDateTime(s);
        PersianCalendar calendar = new PersianCalendar();
        DateTime ShamsiDate;
        try
        {
            ShamsiDate = new DateTime(calendar.GetYear(dtm), calendar.GetMonth(dtm), calendar.GetDayOfMonth(dtm));
            return ShamsiDate.Year.ToString() + "/" + ShamsiDate.Month + "/" + ShamsiDate.Day;
        }
        catch
        {
            ShamsiDate = new DateTime(calendar.GetYear(dtm), calendar.GetMonth(dtm), calendar.GetDayOfMonth(dtm), new PersianCalendar());
            return ShamsiDate.Year.ToString() + "/" + ShamsiDate.Month + "/" + ShamsiDate.Day;
        }
        finally
        {

        }
    }

    public static DataTable Ret_Persian_Date(DataTable inp)
    {
        foreach (DataColumn dc in inp.Columns)
            if (dc.DataType == typeof(DateTime) && dc.ColumnName != "PuLastUpdate")
            {
                foreach (DataRow dr in inp.Rows)
                {
                    dr[dc.ColumnName] = ret(dr[dc.ColumnName]);
                }
            }
        return inp;
    }

    public static string ReturnDatePersianServer()
    {
        PersianCalendar p = new PersianCalendar();
        string yy = p.GetYear(DateTime.Now).ToString();
        string mm = p.GetMonth(DateTime.Now).ToString("00");
        string dd = p.GetDayOfMonth(DateTime.Now).ToString("00");
        string str = string.Format("{0}/{1}/{2}", yy, mm, dd);
        return str;
    }
    public static bool IsDigit(string Text)
    {
        Regex regex = new Regex(@"^-*[0-9,\.]+$");

        if (regex.IsMatch(Text))
            return true;
        else
            return false;
    }
    public static bool IsText(string Text)
    {
        Regex regex = new Regex(@"^-*[0-9,\.]+$");

        if (!regex.IsMatch(Text))
            return true;
        else
            return false;
    }
    public static int ReturnDayOfWeedInt(persianDateTime date)
    {
        int Week = -1;
        switch (date.DayOfWeek.ToString())
        {
            case "Shanbeh":
                Week = 1;
                break;
            case "YekShanbeh":
                Week = 2;
                break;
            case "DoShanbeh":
                Week = 3;
                break;
            case "SeShanbeh":
                Week = 4;
                break;
            case "ChaharShanbeh":
                Week = 5;
                break;
            case "PanjShanbeh":
                Week = 6;
                break;
            case "Jomeh":
                Week = 7;
                break;
        }
        return Week;
    }
    public static string ReturnDayOfWeedString(persianDateTime date)
    {
        string Week = "";

        persianDateTime d = new persianDateTime(date.Year, date.Month, date.Day, 0, 0, 0);

        switch (d.DayOfWeek.ToString())
        {
            case "Shanbeh":
                Week = "شنبه";
                break;
            case "YekShanbeh":
                Week = "یک شنبه";
                break;
            case "DoShanbeh":
                Week = "دو شنبه";
                break;
            case "SeShanbeh":
                Week = "سه شنبه";
                break;
            case "ChaharShanbeh":
                Week = "چهار شنبه";
                break;
            case "PanjShanbeh":
                Week = "پنج شنبه";
                break;
            case "Jomeh":
                Week = "جمعه";
                break;
        }
        return Week == string.Empty ? d.DayOfWeek.ToString() : Week;
    }



}


