using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class SabtMahsol
    {
        public int SabtMahsolPuID { get; set; }
        public string SabtMahsolName { get; set; }
        public Nullable<int> SabtMahsolVahed { get; set; }
        public Nullable<int> SabtMahsolCod { get; set; }
        public Nullable<bool> SabtMahsolEnable { get; set; }
        public string SabtMahsolDescription { get; set; }
        public Nullable<int> SabtMahsolAnbar { get; set; }
        public Nullable<double> SabtMahsolPrice { get; set; }
        public Nullable<int> SabtMahsolPuUSER { get; set; }
        public Nullable<DateTime> SabtMahsolEDdatetime { get; set; }
        public Nullable<DateTime> SabtMahsoldatetime { get; set; }
        public Nullable<int> SabtMahsolEDPuUSER { get; set; }
        public string ItemCode { get; set; }
    }
}
