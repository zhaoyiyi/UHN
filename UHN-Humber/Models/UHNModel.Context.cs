﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UHNDBContext : DbContext
    {
        public UHNDBContext()
            : base("name=UHNDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlertTable> AlertTables { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<MenuGroup> MenuGroups { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PatientTable> PatientTables { get; set; }
        public virtual DbSet<StaffLogin> StaffLogins { get; set; }
        public virtual DbSet<VideoTable> VideoTables { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<FAQCategory> FAQCategories { get; set; }
        public virtual DbSet<FAQQuestion> FAQQuestions { get; set; }
        public virtual DbSet<Event> Events { get; set; }
    }
}
