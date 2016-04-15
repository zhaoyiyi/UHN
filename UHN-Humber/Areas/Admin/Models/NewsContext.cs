using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UHN_Humber.Areas.Admin.Models
{
    public class NewsContext : DbContext
    {
        public DbSet<News> Content { get; set; }

        public System.Data.Entity.DbSet<UHN_Humber.Areas.Admin.Models.Alert> Alerts { get; set; }
    }
}