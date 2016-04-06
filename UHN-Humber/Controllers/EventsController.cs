using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        [HttpGet]
        public ActionResult Index()
        {
            
            EventDate firstDay = new EventDate();

            firstDay.year = System.DateTime.Now.Year;
            firstDay.month = System.DateTime.Now.Month;
            firstDay.monthInString = System.DateTime.Now.ToString("MMMM");
            firstDay.date = System.DateTime.Now.Day;
            firstDay.numDays = System.DateTime.DaysInMonth(firstDay.year, firstDay.month);
            

            var temp = new DateTime(firstDay.year, firstDay.month, 1);

            firstDay.dayInString = (int)temp.DayOfWeek;

            var temp2 = new DateTime(firstDay.year, firstDay.month, firstDay.numDays);

            firstDay.lastday = (int)temp2.DayOfWeek;
            firstDay.incOrDec = 0;

            return View(firstDay);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {

            EventDate firstDay = new EventDate();

            firstDay.year = Int32.Parse(fc["year"]);
            firstDay.month = Int32.Parse(fc["month"]) + Int32.Parse(fc["incordec"]);

            DateTime dt = new DateTime(firstDay.year, firstDay.month, 1);


            firstDay.monthInString = dt.ToString("MMMM");
            firstDay.date = 1;
            firstDay.numDays = System.DateTime.DaysInMonth(firstDay.year, firstDay.month);

            firstDay.dayInString = (int)dt.DayOfWeek;

            var temp2 = new DateTime(firstDay.year, firstDay.month, firstDay.numDays);

            firstDay.lastday = (int)temp2.DayOfWeek;
            firstDay.incOrDec = 0;

            return View(firstDay);


        }


    }
}