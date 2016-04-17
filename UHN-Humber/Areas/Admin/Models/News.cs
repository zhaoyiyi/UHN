using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UHN_Humber.Areas.Admin.Models
{
    [Table("News")]
    public class News
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string NewsNumber { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
    }
}