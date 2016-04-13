using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class StaffLoginAdminController : Controller
    {
        // GET: Admin/StaffLoginAdmin
        public ActionResult StaffIndex()
        {
            StaffContext db = new StaffContext();

            return View(db.StaffLogins.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(StaffLogin staffLogin)
        {
            if (ModelState.IsValid)
            {
                StaffContext db = new StaffContext();

                db.StaffLogins.Add(staffLogin);
                db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = staffLogin.StaffFirstName + " " + staffLogin.StaffLastName + " successfully registered.";
            }
            return View();
        }
    }
}