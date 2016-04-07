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
            var events = from c in uc.Event1
                             orderby c.EventDate ascending, c.EventTime
                             select c;


            return View(events);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}