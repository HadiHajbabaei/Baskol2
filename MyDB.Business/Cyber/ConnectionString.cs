using System;
using System.Collections.Generic;
using System.Text;

namespace MyDB.BusinessLayer.Cyber
{
  public  static class ConnectionString
    {
       private static string _myConnection;
       public static string myConnection
        {
            get { return _myConnection;   }
            set { _myConnection = value; }
        }
    }
}
