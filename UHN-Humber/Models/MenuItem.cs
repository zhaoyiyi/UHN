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
    
    public partial class MenuItem
    {
        public int menuId { get; set; }
        public string menuName { get; set; }
        public string menuLink { get; set; }
        public Nullable<int> Parent_Id { get; set; }
    }
}
