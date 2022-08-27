using System.Data;
using System;
using MyDB.BusinessLayer.Models;

namespace MyDB.BusinessLayer
{
    public class ClsDateTime
    {

        #region data Members

        DBEntity DB = new DBEntity();

        #endregion

        #region Constructor
        public ClsDateTime()
        {
        }
        #endregion

        #region DateTime
        public DataTable getDateTime()
        {
            return DB.ExecuteSqlDataSet("select GETDATE()").Tables[0];
        }

        public DateTime DateTime()
        {
            return System.DateTime.Parse(DB.ExecuteSqlString("select GETDATE()"));
        }

        public DataTable GregorianToPersian()
        {
            return DB.ExecuteSqlDataSet("select [dbo].[GregorianToPersian] ((select cast(getdate() as date)))").Tables[0];
        }

        public DataTable GregorianToPersian(string Date)
        {
            return DB.ExecuteSqlDataSet("select [dbo].[GregorianToPersian] ('" + Date + "')").Tables[0];
        }
        #endregion
    }
}
