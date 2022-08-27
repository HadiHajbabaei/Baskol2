using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

class Checking
{

    private RadWatermarkTextBox txtBox;
    private RadComboBox combo;
    private bool check;

    #region Checking Grid
    /// <summary>
    /// تمام تکس باکس ها رو چک می کند ک خالی نباشد
    /// </summary>
    /// <param name="GridName">نام گرید</param>
    /// <param name="Check">وضعیت گرید</param>
    /// <returns></returns>
    public bool Grid(Grid GridName, bool Check)
    {
        check = true;
        foreach (UIElement control in GridName.Children)
        {
            if (control.GetType() == typeof(RadWatermarkTextBox))
            {
                txtBox = (RadWatermarkTextBox)control;
                if (txtBox.Text.Length == 0)
                    return false;
            }
            else if (control.GetType() == typeof(RadComboBox))
            {
                combo = (RadComboBox)control;
                if (combo.SelectedIndex < 0)
                    return false;
            }
        }
        return Check;
    }

    /// <summary>
    ///  تمام تکس باکس ها رو چک می کند ک خالی نباشد به جز تکس باکس وارد شده
    /// </summary>
    /// <param name="GridName">نام گرید</param>
    /// <param name="Check">وضعیت گرید</param>
    /// <param name="TextBox">نام تکس باکس</param>
    /// <returns></returns>
    public bool Grid(Grid GridName, bool Check, RadWatermarkTextBox TextBox)
    {
        foreach (UIElement control in GridName.Children)
        {
            if (control.GetType() == typeof(RadWatermarkTextBox))
            {
                txtBox = (RadWatermarkTextBox)control;
                if (txtBox.Text.Length == 0 && txtBox.Name != TextBox.Name)
                    return false;
            }
            else if (control.GetType() == typeof(RadComboBox))
            {
                combo = (RadComboBox)control;
                if (combo.SelectedIndex < 0)
                    return false;
            }
        }
        return Check;
    }
    #endregion

    public bool DigitalNumber(KeyEventArgs e)
    {
        if ((e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && (e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.Back)
            return true;
        else
            return false;
    }
    public bool Date(KeyEventArgs e)
    {
            if ((e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && (e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.Back && e.Key != Key.Oem2)
                return true;
            else
                return false;
    }
    public bool FloatNumber(KeyEventArgs e)
    {
        if ((e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && (e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.Back && e.Key != Key.Decimal)
            return true;
        else
            return false;
    }

}
