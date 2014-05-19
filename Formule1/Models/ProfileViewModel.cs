using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Formule1.Models
{
    public class ProfileViewModel
    {
        public int ID { get; set; }
        public int UserNameID { get; set; }
        public int Money { get; set; }
        public string TeamName { get; set; }
        public int EngineID { get; set; }
        public int DriverID { get; set; }
        public int ChassisID { get; set; }
    }
}