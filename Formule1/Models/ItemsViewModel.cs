using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Formule1.Models
{
    public class EngineModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
    }
    public class DriverModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
    }
    public class ChassisModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
    }
}