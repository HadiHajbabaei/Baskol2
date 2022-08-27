using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class View_Factor : View_TozinComplete
    {

        public long FactorPuID { get; set; }
       
        public Nullable<int> FactorPuUSer { get; set; }
        public Nullable<System.DateTime> FactorDateTime { get; set; }
    }
}
