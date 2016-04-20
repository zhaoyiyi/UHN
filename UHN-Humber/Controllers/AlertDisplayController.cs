using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Areas.Admin.Models;

namespace UHN_Humber.Controllers
{
    public class AlertDisplayController : Controller
    {
        // GET: AlertDisplay
        public ActionResult Index()
        {
            AlertContext alertContext = new AlertContext();
            List<Alert> alert = alertContext.Employees.ToList();
            return View(alert);

        }
    }
}