using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Car
    {
        public int CarPuID { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; } 
        public Nullable<DateTime> CarDateTime { get; set; }
        public Nullable<bool> CarEnable { get; set; }
        public Nullable<int> CarPuUser { get; set; }
        public Nullable<DateTime> CarEdDateTime { get; set; }
        public Nullable<int> CarEdPuUser { get; set; }
    }
}
