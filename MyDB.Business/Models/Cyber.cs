using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Cyber
    {
        public int CyberPuID { get; set; }
        public Nullable<bool> CyberSelect { get; set; }
        public string CyberServer { get; set; }
        public string CyberUsername { get; set; }
        public string CyberName { get; set; }
        public string CyberPassword { get; set; }
        public string CyberKholase { get; set; }
        public int CyberDore { get; set; }
        public Nullable<System.DateTime> CyberDateTime { get; set; }
        public int CyberPuUser { get; set; }

        public  Nullable<System.DateTime> CyberEdDateTime { get; set; }

        public int CyberEdPuUser { get; set; }

    }
}
