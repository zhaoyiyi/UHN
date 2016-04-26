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
    public class AppointmentRequestsController : Controller
    {
        private UHNDBContext db = new UHNDBContext();



        // GET: AppointmentRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientName,PatientAge,PatientSex,PatientPhone,PatientEmail,PreferredDate,Reasons")] AppointmentRequest appointmentRequest)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentRequests.Add(appointmentRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointmentRequest);
        }

    }
}
