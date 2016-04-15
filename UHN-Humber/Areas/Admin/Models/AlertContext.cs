using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UHN_Humber.Areas.Admin.Models
{
    public class AlertContext : DbContext
    {
        
        public DbSet<Alert> Employees { get; set; }

        
    }
}