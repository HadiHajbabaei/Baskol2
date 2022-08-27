using System;
using System.Data;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls; 

    class CreateColumn
    {
        public static DataColumn addColumn(string ColumnName, string Caption,Type Type)
        {

            DataColumn column = new DataColumn()
            {
                ColumnName = ColumnName,
                Caption = Caption,
                DataType = Type

            };
            return column;
        }

        public static GridViewDataColumn addColumn(string Name, string Header, bool Visible, bool ReadOnly, Binding Binding)
        {

            GridViewDataColumn column = new GridViewDataColumn()
            {
                Name = Name,
                Header = Header,
                IsReadOnly = ReadOnly,
                IsVisible = Visible,
                DataMemberBinding = Binding
            };
            return column;
        }
        public static GridViewDataColumn addColumn(string Name, string Header, bool Visible, bool ReadOnly, Style Style, Binding Binding)
        {

            GridViewDataColumn column = new GridViewDataColumn()
            {
                Name = Name,
                Header = Header,
                IsReadOnly = ReadOnly,
                IsVisible = Visible,
                DataMemberBinding = Binding,
                CellStyle = Style,
            };
            return column;
        }
        public static GridViewDataColumn addColumn(string Name, string Header, bool Visible, bool ReadOnly, Style Style, object ToolTip, Binding Binding)
        {

            GridViewDataColumn column = new GridViewDataColumn()
            {
                Name = Name,
                Header = Header,
                IsReadOnly = ReadOnly,
                IsVisible = Visible,
                DataMemberBinding = Binding,
                CellStyle = Style,
                ToolTip= ToolTip
            };
            return column;
        }
    }

