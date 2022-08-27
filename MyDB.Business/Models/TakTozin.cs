using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class TakTozin
    {
        public long TakTozinPuID { get; set; }
        public Nullable<long> DriverPuID { get; set; }
        public Nullable<int> SabtMahsolPuID { get; set; }
        public int CustomerPuID { get; set; }
        public Nullable<long> TakTozinGhabz { get; set; }
        public Nullable<double> TakTozinWeighte { get; set; }
        public string TakTozinTime { get; set; }
        public string TakTozinDate { get; set; }
        public Nullable<int> Ttype { get; set; }
        public Nullable<int> TakTozinPuUser { get; set; }
        public Nullable<DateTime> TakTozinDateTime { get; set; }
    }
}
