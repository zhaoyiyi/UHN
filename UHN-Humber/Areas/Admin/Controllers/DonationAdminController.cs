using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class DonationAdminController : Controller
    {
        // GET: Admin/DonationAdmin
        public ActionResult DonationIndex()
        {
            DonationContext db = new DonationContext();

            return View(db.Donations.ToList());
        }
    }
}