using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        public ActionResult VolunteerIndex()
        {
            VolunteerContext db = new VolunteerContext();

            return View(db.Volunteers.ToList());
        }

        public ActionResult VolunteerApply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VolunteerApply(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                VolunteerContext db = new VolunteerContext();
                db.Volunteers.Add(volunteer);
                db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = volunteer.VolunteerFirstName + " " + volunteer.VolunteerLastName + " " + "thank you for applying.";
            }
            return View();
        }
    }
}