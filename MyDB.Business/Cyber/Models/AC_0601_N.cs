namespace MyDB.BusinessLayer.Cyber.Models
{
    using System;

    public partial class AC_0601_N
    {
        public int DepartmentId { get; set; }
        public string DepartmentNumber { get; set; }
        public int DeptGroupId { get; set; }
        public string DepartmentName { get; set; }

        public Double asnadCreditLimit { get; set; }

        public Double asnadDebitLimit { get; set; }

        public Double CreditLimit { get; set; }

        public Double DebitLimit { get; set; }

    }
}
