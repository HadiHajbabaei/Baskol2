using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class View_Tozin1
    {
        public string DriverName { get; set; }
        public string DriverCodeMeli { get; set; }
        public string DriverPNumber { get; set; }
        public Nullable<long> DriverPuID { get; set; }
        public long CustomerPuID { get; set; }
        public string DriverDesc { get; set; }
        public string DriverAddress { get; set; }
        public Nullable<long> DriverCode { get; set; }
        public Nullable<int> Ttype { get; set; }
        public Nullable<int> SabtMahsolAnbar { get; set; }
        public Nullable<double> SabtMahsolPrice { get; set; }
        public Nullable<bool> DriverEnable { get; set; }
        public Nullable<DateTime> DriverDateTime { get; set; }
        public int DriverPuUser { get; set; }
        public Nullable<DateTime> DriverEdDateTime { get; set; }
        public int DriverEdPuUser { get; set; }
        public string DriverTagNumber { get; set; }
        public int CarPuID { get; set; }
        public Nullable<long> Tozin1PuID { get; set; }
        public int SabtMahsolPuID { get; set; }
        public string SabtMahsolName { get; set; }
        public Nullable<int> SabtMahsolVahed { get; set; }
        public Nullable<int> SabtMahsolCod { get; set; }
        public string SabtMahsolDescription { get; set; }
        public Nullable<int> SabtMahsolPuUSER { get; set; }
        public Nullable<DateTime> SabtMahsolEDdatetime { get; set; }
        public Nullable<DateTime> SabtMahsoldatetime { get; set; }
        public Nullable<int> SabtMahsolEDPuUSER { get; set; }
        public int VahedPuID { get; set; }
        public string VahedName { get; set; }
        public string Tozin1Time { get; set; }
        public Nullable<Double> Tozin1Weighte { get; set; }
        public string Tozin1Date { get; set; }
        public Nullable<int> Tozin1PuUser { get; set; }
        public Nullable<DateTime> Tozin1DateTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCodeMeli { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerDesc { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerAccountNumber1 { get; set; }
        public int CustomerCode { get; set; }
        public Nullable<DateTime> CustomerDateTime { get; set; }
        public Nullable<int> CustomerPuUser { get; set; }
        public Nullable<bool> SabtMahsolEnable { get; set; }
        public string ItemCode { get; set; }
    }
}
