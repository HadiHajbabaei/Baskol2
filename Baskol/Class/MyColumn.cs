using System.Windows;
using System.Windows.Controls;

namespace Class
{
    class MyColumn : Telerik.Windows.Controls.GridViewColumn
    {
        public override FrameworkElement CreateCellElement(Telerik.Windows.Controls.GridView.GridViewCell cell, object dataItem)
        {
            TextBlock textBlock = cell.Content as TextBlock;

            if (textBlock == null)
            {
                textBlock = new TextBlock();
            }

            textBlock.Text = string.Format("{0}", this.DataControl.Items.IndexOf(dataItem) + 1);

            return textBlock;
        }
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if (args.PropertyName == "DataControl")
            {
                if (DataControl != null && this.DataControl.Items != null)
                {
                    DataControl.Items.CollectionChanged += (s, e) =>
                    {
                        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                        {
                            this.Refresh();
                        }
                    };
                }
            }
        }
    }
}
