using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UHN_Humber.Areas.Admin.Models
{
        [Table("AlertTable")]
        public class Alert
        {
            public int Id { get; set; }
            public DateTime AlertDate { get; set; }
            public string AlertTitle { get; set; }
            public string AlertDescription { get; set; }
            public int EmergContact { get; set; }
        }
    }
