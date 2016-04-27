using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class AppointmentRequestsPublicController : Controller
    {
        private UHNDBContext db = new UHNDBContext();


        public ActionResult Thankyou(int id)
        {
            AppointmentRequest ar = db.AppointmentRequests.Single(m => m.Id == id);

            return View(ar);
        }



        // GET: AppointmentRequests/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            AppointmentRequest ar = new AppointmentRequest();

            if (ModelState.IsValid)
            {


                ar.PatientName = formCollection["PatientName"];
                ar.PatientAge = Convert.ToInt32(formCollection["PatientAge"]);
                ar.PatientSex = formCollection["PatientSex"];
                ar.PatientPhone = formCollection["PatientPhone"];
                ar.PatientEmail = formCollection["PatientEmail"];
                ar.PreferredDate = Convert.ToDateTime(formCollection["PreferredDate"]);
                ar.Reasons = formCollection["Reasons"];

                db.AppointmentRequests.Add(ar);
                db.SaveChanges();
                return RedirectToAction("Thankyou", new { id = ar.Id });
            }

            return View(ar);
        }

    }
}
