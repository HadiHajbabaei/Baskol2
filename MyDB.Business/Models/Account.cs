using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Account
    {
        public int AccountPuID { get; set; } 
        public string AccountUser { get; set; }
        public string AccountPassword { get; set; }
        public string AccountName { get; set; }
        public string AccountFamily { get; set; }
        public Nullable<bool> AccountGender { get; set; }
        public string AccountCodeMeli { get; set; }
        public Byte[] AccountImg { get; set; } 

        public string AccountTel { get; set; }

        public string AccountMobile { get; set; }

        public string AccountAddress { get; set; }

        public Nullable<bool> AccountEnable { get; set; }
        public string AccountDescription { get; set; }
        public Nullable<DateTime> AccountDateTime { get; set; }
        public Nullable<int> AccountPuUser { get; set; }
        public Nullable<DateTime> AccountEdDateTime { get; set; }
        public Nullable<int> AccountEdPuUser { get; set; }
    }
}
