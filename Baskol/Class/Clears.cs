
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
class Clears
{
    private CheckBox box;
    private RadComboBox com;
    private RadWatermarkTextBox tx;
    private RadMaskedTextInput mask;
    private RadMultiColumnComboBox MultiCom;
    

    public void ClearTextBox(Grid grid)
    {
        foreach (UIElement control in grid.Children)
        {
            if (control.GetType() == typeof(RadWatermarkTextBox))
            {
                tx = (RadWatermarkTextBox)control;
                if (tx.Text.Length > 0)
                {
                    tx.Clear();
                    tx.Tag = null;
                }
            }
            else if (control.GetType() == typeof(CheckBox))
            {
                box = (CheckBox)control;
                if (box.IsChecked.Value)
                    box.IsChecked = false;
            }
            else if (control.GetType() == typeof(RadComboBox))
            {
                com = (RadComboBox)control;
                if (com.SelectedIndex > -1)
                    com.SelectedIndex = -1;
            }
            else if (control.GetType() == typeof(RadMaskedTextInput))
            {
                mask = (RadMaskedTextInput)control;
                if (mask.Value.Length > 0)
                {
                    mask.Value="";
                    tx.Tag = null;
                }
            }
            else if (control.GetType() == typeof(RadMultiColumnComboBox))
            {
                MultiCom = (RadMultiColumnComboBox)control;
                if (MultiCom.SelectedIndex > -1)
                {
                    MultiCom.SelectedIndex = -1;
                    MultiCom.SelectedItem = null;
                }
            }
        }
    }
    public void ClearTextBox(Grid grid, RadWatermarkTextBox TextBox)
    {
        foreach (UIElement control in grid.Children)
        {
            if (control.GetType() == typeof(RadWatermarkTextBox))
            {
                tx = (RadWatermarkTextBox)control;
                if (tx.Text.Length > 0 && tx.Name != TextBox.Name)
                {
                    tx.Text = "";
                    tx.Tag = null;
                }
                else if (tx.IsReadOnly == true)
                    tx.IsReadOnly = false;
            }
            else if (control.GetType() == typeof(CheckBox))
            {
                box = (CheckBox)control;
                if (box.IsChecked.Value)
                    box.IsChecked = false;


            }
        }
    }
}
