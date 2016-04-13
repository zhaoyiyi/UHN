using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class VolunteerAdminController : Controller
    {
        // GET: Admin/VolunteerAdmin
        public ActionResult VolunteerIndex()
        {
            VolunteerContext db = new VolunteerContext();

            return View(db.Volunteers.ToList());
        }
    }
}