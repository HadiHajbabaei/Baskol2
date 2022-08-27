using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Port
    {
        public int PortPuID { get; set; }
        public string DeviceName { get; set; }
        public string DeviceLocation { get; set; } 
        public string PortNumber { get; set; }
        public Nullable<int> PortBaudrate { get; set; }
        public Nullable<int> PortStopbit { get; set; }
        public Nullable<int> PortFlowcontrol { get; set; }
        public Nullable<int> PortDatabit { get; set; }

    }
}
