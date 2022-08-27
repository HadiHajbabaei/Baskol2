namespace MyDB.BusinessLayer.Cyber.Models
{
    using System;

    public partial class AC_0101_N
    {

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string SubscribtionCode { get; set; }
        public Nullable<int> MoinId { get; set; }
        public Nullable<int> AccountTypeId { get; set; }
        public Nullable<bool> Deptartment { get; set; }
        public Nullable<bool> CostCenter { get; set; }
        public Nullable<bool> JobCosting { get; set; }
        public Nullable<int> CurrencyDefault { get; set; }
        public Nullable<int> Hgcode { get; set; }
        public Nullable<bool> CInactive { get; set; }
        public string AccountName { get; set; }
        public Nullable<int> JobGroupId { get; set; }


    }
}
