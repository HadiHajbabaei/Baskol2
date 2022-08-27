
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDB.BusinessLayer
{
  public  static class ConnectionString
    {
       private static string _myConnection;
       public static string myConnection
        {
            get { return _myConnection;   }
            set { _myConnection = value; _DB = new DBEntity(); }
        }

        private static DBEntity _DB;
        public static DBEntity DB
        {
            get
            {
                return _DB;
            }
        }
    }
}
