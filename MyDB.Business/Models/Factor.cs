using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Factor
    {
        public long FactorPuID { get; set; }
        public Nullable<long> Tozin2PuID { get; set; }
        public Nullable<int> FactorPuUSer { get; set; }
        public Nullable<System.DateTime> FactorDateTime { get; set; } 
    }
}
