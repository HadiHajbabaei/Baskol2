using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class View_AppCrack
    {
        //App
        public int AppPuID { get; set; }
        public string AppName { get; set; }

        //Crack
        public long CrackPuID { get; set; }
        public Nullable<int> CrackUserNumber { get; set; }
        public Nullable<int> CrackCompanyName { get; set; }
        public string CrackCode { get; set; }

        //Activate
        public string ActivatePuID { get; set; }
        public string ActiveDateTime { get; set; }
    }
}
