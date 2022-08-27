using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Tozin1
    {
        public long Tozin1PuID { get; set; }
        public Nullable<long> DriverPuID { get; set; }
        public Nullable<int> SabtMahsolPuID { get; set; }
        public int CustomerPuID { get; set; }
        public Nullable<double> Tozin1Weighte { get; set; }
        public string Tozin1Time { get; set; }
        public string Tozin1Date { get; set; }
        public Nullable<int> Tozin1PuUser { get; set; }
        public Nullable<int> Ttype { get; set; }
        public Nullable<DateTime> Tozin1DateTime { get; set; }
    }
}
