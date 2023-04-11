using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndWriteDatabase.Input
{
    public class RooftopACCosts
    {
        public int RooftopUnitId{ get; set; }
        public string RooftopUnitType { get; set; }
        public float Pressure { get; set; }
        public decimal Price { get; set; }
        public string UnitType { get; set; }
        public string WorkingPreference { get; set; }
    }
}
