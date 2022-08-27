namespace MyDB.BusinessLayer.Cyber.Models
{
    using System;

    public partial class AC_4101_N
    {
        public int InvHeaderId { get; set; }
        public Nullable<int> InvTyp { get; set; }
        public Nullable<int> InvNo { get; set; }
        public string InvDescription { get; set; }
        public Nullable<DateTime> InvDate { get; set; }
        public string GeneralRef { get; set; }
        public Nullable<int> RegisterRef { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> JobCostingId { get; set; }
        public Nullable<decimal> DiscPer { get; set; }
        public Nullable<bool> UpPriceFlag { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> firstissuerid { get; set; }
        public Nullable<int> lastissuerid { get; set; }
        public Nullable<bool> printed { get; set; }
        public Nullable<bool> PermanentNumber { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
    }
}
