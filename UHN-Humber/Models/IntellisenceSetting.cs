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
    
    public partial class IntellisenceSetting
    {
        public byte Intellisense { get; set; }
        public Nullable<int> Result_limit { get; set; }
        public Nullable<int> Debounce_Time { get; set; }
        public int id { get; set; }
        public string Disabled_fields { get; set; }
    }
}
