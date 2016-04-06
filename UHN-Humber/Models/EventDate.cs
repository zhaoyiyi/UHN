using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UHN_Humber.Models
{
    public class EventDate
    {
        public int year { get; set; }
        public int month { get; set; }
        public string monthInString { get; set; }
        public int date { get; set; }
        public int dayInString { get; set; }
        public int numDays { get; set; }
        public int lastday { get; set; }
        public int incOrDec { get; set; }
    }
}