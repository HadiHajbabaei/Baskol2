using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class SabtDriver
    {
        public long DriverPuID { get; set; }
        public string DriverName { get; set; }
        public string DriverCodeMeli { get; set; }
        public string DriverPNumber { get; set; }
        public string DriverDesc { get; set; }
        public string DriverAddress { get; set; }
        public long DriverCode { get; set; }
        public Nullable<bool>  DriverEnable { get; set; }
        public Nullable<DateTime> DriverDateTime { get; set; }
        public int DriverPuUser { get; set; }
        public Nullable<DateTime> DriverEdDateTime { get; set; }
        public int DriverEdPuUser { get; set; }
        public string DriverTagNumber { get; set; }
        public int CarPuID { get; set; }
    }
}



