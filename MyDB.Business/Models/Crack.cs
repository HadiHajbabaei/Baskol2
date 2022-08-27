using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Crack
    {
        public long CrackPuID { get; set; }
        public Nullable<int> CrackUserNumber { get; set; } 
        public string CrackCompanyName { get; set; }
        public Nullable<int> CrackPuApp { get; set; }
        public string CrackCode { get; set; }
    }
}
