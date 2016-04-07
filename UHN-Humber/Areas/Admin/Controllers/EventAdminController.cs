using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class EventAdminController : Controller
    {
        UHNDBContext uc = new UHNDBContext();

        // GET: Admin/EventAdmin
        public ActionResult Index()
        {
            var events = from c in uc.Events
                             orderby c.EventDate ascending, c.EventTime
                             select c;


            return View(events);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Event fc = new Event();

                fc.EventName = formCollection["EventName"];
                DateTime dt = Convert.ToDateTime(formCollection["EventDate"]);
                fc.EventDate = dt;
                fc.EventTime = Convert.ToDecimal(formCollection["EventTime"]);
                fc.EventLocation = formCollection["EventLocation"];
                fc.EventDescription = formCollection["EventDescription"];

                uc.Events.Add(fc);
                uc.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}