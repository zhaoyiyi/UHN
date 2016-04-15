using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UHN_Humber.Areas.Admin.Models
{
    [Table("VideoTable")]
    public class Video
    {
        public string AdminName { get; set; }
        public string EmployeeId { get; set; }
        public string VideoNumber { get; set; }
        public string VideoLink { get; set; }
    }
}