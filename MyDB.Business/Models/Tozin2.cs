using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Tozin2
    {
        public Nullable<long> Tozin1PuID { get; set; }
        public long Tozin2PuID { get; set; }
    
        public Nullable<double> Tozin2Weighte { get; set; }
        public string Tozin2Time { get; set; }
        public Nullable<long> Tozin2Ghabz { get; set; }
        public string Tozin2Date { get; set; }
        public Nullable<int> Tozin2PuUser { get; set; }
        public Nullable<int> Ttype { get; set; }
        
        public Nullable<DateTime> Tozin2DateTime { get; set; }

    }
}
