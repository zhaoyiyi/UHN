//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UHN_Humber.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientTable
    {
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientEmail { get; set; }
        public Nullable<bool> ReminderEmail { get; set; }
        public string PatientPhone { get; set; }
        public Nullable<System.DateTime> BookingTime { get; set; }
        public string VisitReason { get; set; }
        public Nullable<int> DocId { get; set; }
    }
}
