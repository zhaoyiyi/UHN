using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class FAQController : Controller
    {
        UHNDBContext uc = new UHNDBContext();
        // GET: FAQ
        public ActionResult Index()
        {
            return View();
        }
    }
}