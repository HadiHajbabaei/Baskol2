using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskol.Update.Customer
{
    class ClsCustomer:MyDB.BusinessLayer.Models.SabtCustomer
    {
        public bool Save { get; set; }
        public string SaveStr { get; set; }
        public bool Select { get; set; }
    }
}
