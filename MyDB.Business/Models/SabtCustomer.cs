using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class SabtCustomer
    {
        public long CustomerPuID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCodeMeli { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerDesc { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerAccountNumber1 { get; set; }
        public int CustomerCode { get; set; }
        public Nullable<DateTime> CustomerDateTime { get; set; }
        public Nullable<int> CustomerPuUser { get; set; }
    }
}



