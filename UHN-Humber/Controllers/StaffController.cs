using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(StaffLogin staffLogin)
        {
            StaffContext db = new StaffContext();

            var user = db.StaffLogins.Where(u => u.StaffUsername == staffLogin.StaffUsername && u.StaffPassword == staffLogin.StaffPassword).FirstOrDefault();

            if(user != null)
            {
                Session["StaffId"] = user.StaffId.ToString();
                Session["StaffUserName"] = user.StaffUsername.ToString();
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username and/or Passowrd is incorrect");
            }
            return View();
        }
        
        public ActionResult LoggedIn()
        {
            if(Session["staffId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            if(Session["staffId"] != null)
            {
                Session.Abandon();
            }
            return RedirectToAction("Login");
        }

        public JsonResult IsUserNameAvailable(string Username)
        {
            StaffContext db = new StaffContext();

            return Json(!db.StaffLogins.Any(x => x.StaffUsername == Username),JsonRequestBehavior.AllowGet);
        }
    }
}