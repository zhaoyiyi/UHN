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
    using System.Web.Mvc;
    public partial class StaffLogin
    {
        [Key]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        public string StaffFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string StaffLastName { get; set; }

        [Required(ErrorMessage = "Username Required")]
        [Remote("IsUserNameAvailable", "StaffLogin",ErrorMessage = "Username already in use")]
        public string StaffUsername { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string StaffPassword { get; set; }

        [Required(ErrorMessage = "Please Entire Staff Access Level")]
        public string StaffAccess { get; set; }
    }
}

