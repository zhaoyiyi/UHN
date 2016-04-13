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
    public partial class Volunteer
    {
        [Key]
        public int VolunteerId { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        public string VolunteerFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string VolunteerLastName { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string VolunteerAddress { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        public string VolunteerPhone { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string VolunteerEmail { get; set; }

        [Required(ErrorMessage = "Please Describe Your Volunteer History, and Why You Would Like to Volunteer With Us")]
        [DataType(DataType.MultilineText)]
        public string VolunteerInfo { get; set; }
    }
}
