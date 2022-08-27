using System.Data;
using System.Data.OleDb; 
using Excel = Microsoft.Office.Interop.Excel;

class clsExcel
{
    public static DataTable InportToExcel(string filepath)
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
        OleDbDataAdapter da = new OleDbDataAdapter(" select * from [Sheet1$]", con);
        System.Data.DataTable dt = new System.Data.DataTable();
        da.Fill(dt);
        return dt;
    }
    public static System.Data.DataTable InportToExcel(string filePath, int column)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        DataRow dr;
        table.TableName = "Excel";
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook workbook = xlApp.Workbooks.Open(filePath);
        Excel.Worksheet worksheet = xlApp.Sheets[1];
        xlApp.Visible = false;
        Excel.Range range = worksheet.UsedRange;
        int row = range.Cells.Count / column;

        for (int i = 1; i <= column; i++)
            table.Columns.Add(CreateColumn.addColumn("C" + i, "C" + i, System.Type.GetType("System.String")));
        bool END = true;
        for (int r = 2; r <= row; r++)
        {
            dr = table.NewRow();
            for (int c = 1; c <= column;)
            {
                try
                {
                    dr["C" + c] = worksheet.Cells[r, c].Value.ToString();
                }
                catch
                {
                    END = false;
                    break;
                }
                c++;
            }
            if (!END)
                break;
            table.Rows.Add(dr);
        }
        xlApp.Quit();
        workbook = null;
        xlApp = null;
        return table;
    }
}
