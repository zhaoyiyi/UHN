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
    using System.ComponentModel.DataAnnotations;

    public partial class Event1
    {
        public int EventID { get; set; }
        [Required(ErrorMessage ="Please enter the event name")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Please select the event date")]
        public Nullable<System.DateTime> EventDate { get; set; }
        [Required(ErrorMessage = "Please select the event time")]
        public string EventTime { get; set; }
        [Required(ErrorMessage = "Please enter the event location")]
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public string EventRecurred { get; set; }
    }
}