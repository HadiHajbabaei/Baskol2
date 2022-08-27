using System;
using System.Linq;
using System.Windows.Data;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Class
{
    class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "بلی" : "خیر";
            else
                return "خیر";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "بلی" : "خیر";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public static System.Drawing.Image ToImage(byte[] img)
        {
            MemoryStream ms = new MemoryStream(img);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
    }
    class ConverterBedBes : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) == 0 ? "بدهکار" : "بستانکار";
        }

        public object Convert1(object value)
        {
            return ((int)value) == 0 ? "بدهکار" : "بستانکار";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    class ConverterToMaleOrFamel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "مرد" : "زن";
            else
                return "زن";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "مرد" : "زن";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConvertertoMidleOrFinal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "نهایی" : "میانی";
            else
                return "میانی";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "نهایی" : "میانی";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public static System.Drawing.Image ToImage(byte[] img)
        {
            MemoryStream ms = new MemoryStream(img);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
    }

    class ConverterToUpdate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "ثبت شده" : "ثبت نشده";
            else
                return "ثبت نشده";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "ثبت شده" : "ثبت نشده";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterToBuyOrSell : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "فروش" : "خرید";
            else
                return "خرید";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "فروش" : "خرید";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterActiveOrUnActive : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "فعال" : "غیرفعال";
            else
                return "غیرفعال";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "فعال" : "غیرفعال";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterMainORSubsidiary : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "اصلی" : "فرعی";
            else
                return "فرعی";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "اصلی" : "فرعی";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "نمایش" : "مخفی";
            else
                return "مخفی";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "فعال" : "غیرفعال";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterBuyType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "یارانه" : "آزاد";
            else
                return "آزاد";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "یارانه" : "آزاد";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterCordexAcc : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "تایید شد" : "تایید نشده";
            else
                return "تایید نشده";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "تایید شد" : "تایید نشده";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    class ConverterFollowAndUnFollow : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? "پیگیری شد" : "پیگیری نشده";
            else
                return "پیگیری نشده";
        }

        public object Convert1(object value)
        {
            return ((bool)value) ? "پیگیری شد" : "پیگیری نشده";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class Types
    {
        public Type Int
        {
            get
            {
                return typeof(int);
            }
        }
        public Type Long
        {
            get
            {
                return typeof(long);
            }
        }

        public Type Double
        {
            get
            {
                return typeof(Double);
            }
        }

        public Type DateTime
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public Type Bool
        {
            get
            {
                return typeof(bool);
            }
        }

        public Type String
        {
            get
            {
                return typeof(String);
            }
        }
    }
    public class ColorFridayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && (value.ToString().Trim() == "ج" || value.ToString().Contains(" ")))
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Transparent);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            throw new NotImplementedException();
        }
    }

    public class ColorMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush(Colors.LightSkyBlue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            throw new NotImplementedException();
        }
    }

}

