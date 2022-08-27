using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Activate
    {
        public long ActivatePuID { get; set; }
        public Nullable<long> ActiveCrack { get; set; }
        public string ActiveCPU { get; set; }
        public Nullable<System.DateTime> ActiveDateTime { get; set; } 
    }
}
