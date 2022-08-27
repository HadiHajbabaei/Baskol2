using System;
using System.Collections.Generic;

namespace MyDB.BusinessLayer.Models
{
    public partial class Camera
    {
        public int CameraPuID { get; set; }
        public string CameraURL { get; set; }
        public string CameraSelectedPath { get; set; } 
    }
}
