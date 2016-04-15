using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UHN_Humber.Areas.Admin.Models
{
    public class VideoContext:DbContext
    {
        public DbSet<Video> Links { get; set; }
    }
}