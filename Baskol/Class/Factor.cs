using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
class Factor
{
    private Random random;

    #region Factor
    public string GetFactor(string Year)
    {
        random = new Random();
        int m;
        switch (Year.Length)
        {
            case 4:
                Year = Year.Substring(2);
                break;
        }
        return Year + random.Next(1, 999);
    }


    public long GetFactorMax(string Year, String Number)
    {
        switch (Year.Length)
        {
            case 4:
                Year = Year.Substring(2);
                break;
        }
        switch (Number.Length)
        {
            case 1:
                Number = "0000" + Number;
                break;
            case 2:
                Number = "000" + Number;
                break;
            case 3:
                Number = "00" + Number;
                break;
            case 4:
                Number = "0" + Number;
                break;
        }
        return long.Parse(Year + Number);
    }

    public long GetFactorMax(string Year, string Mounth, String Number)
    {
        switch (Year.Length)
        {
            case 4:
                Year = Year.Substring(2);
                break;
        }

        switch (Mounth.Length)
        {
            case 1:
                Mounth = "0" + Mounth;
                break;
        }
        switch (Number.Length)
        {
            case 1:
                Number = "0000" + Number;
                break;
            case 2:
                Number = "000" + Number;
                break;
            case 3:
                Number = "00" + Number;
                break;
            case 4:
                Number = "0" + Number;
                break;
        }
        return long.Parse(Year + Mounth + Number);
    }
    /// <summary>
    ///  گرفتن شماره فاکتور
    /// </summary>
    /// <param name="Year">سال</param>
    /// <param name="Mounth">ماه</param>
    /// <param name="Day">روز</param>
    /// <returns></returns>
    public string GetFactor(string Year, string Mounth)
    {
        random = new Random();

        switch (Year.Length)
        {
            case 4:
                Year = Year.Substring(2);
                break;
        }

        switch (Mounth.Length)
        {
            case 1:
                Mounth = "0" + Mounth;
                break;
        }
        return Year + Mounth + random.Next(1, 999);
    }

    /// <summary>
    /// گرفتن شماره فاکتور
    /// </summary>
    /// <param name="Year">سال</param>
    /// <param name="Mounth">ماه</param>
    /// <param name="Day">روز</param>
    /// <param name="OP">پردازش</param>
    /// <returns></returns>
    public string GetFactor(string Year, string Mounth, string OP)
    {
        random = new Random();

        switch (Year.Length)
        {
            case 4:
                Year = Year.Substring(2);
                break;
        }

        switch (Mounth.Length)
        {
            case 1:
                Mounth = "0" + Mounth;
                break;
        }
        return Year + Mounth + OP + random.Next(1, 999);
    }


    #endregion
}

