using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Donate(Donation donation)
        {
            if (ModelState.IsValid)
            { 
                DonationContext db = new DonationContext();
            db.Donations.Add(donation);
            db.SaveChanges();

            ModelState.Clear();
            ViewBag.Message = "Thank You " + donation.DonationName + " for donating to " + donation.DonationRecipient;
            }
            return View();
        }
    }
}