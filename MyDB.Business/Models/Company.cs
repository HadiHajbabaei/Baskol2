using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Company
    {
        public string CompanyName { get; set; }
        public string CompanyEghtesadi { get; set; }
        public string CompanyMeli { get; set; }
        public int CompanySabt { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyCodePosti { get; set; }
        public Nullable<System.DateTime> CompanyDatetime { get; set; }
        public Nullable<System.DateTime> CompanyEdDatetime { get; set; }
        public string CompanyActivity { get; set; }
        public string CompanyTel1 { get; set; }
        public string CompanyTel2 { get; set; }
        public string CompanyTel3 { get; set; }
        public string CompanyAdress { get; set; }
        public byte[] CompanyLogo { get; set; }
        public Nullable<int> CompanyPuUser { get; set; }
        public Nullable<int> CompanyPuID { get; set; }
        public Nullable<int> CompanyEdPuUser { get; set; }
    }
}
