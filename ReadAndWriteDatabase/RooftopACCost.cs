//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadAndWriteDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class RooftopACCost
    {
        public int Id { get; set; }
        public Nullable<int> RooftopUnitId { get; set; }
        public string RooftopUnitType { get; set; }
        public Nullable<double> Pressure { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string UnitType { get; set; }
        public string WorkingPreference { get; set; }
    }
}