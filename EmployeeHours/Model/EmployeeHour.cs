//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeHours.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeHour
    {
        public int Id { get; set; }
        public int Employee_Id { get; set; }
        public int Hours { get; set; }
        public double BreakTime { get; set; }
        public string Month { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
