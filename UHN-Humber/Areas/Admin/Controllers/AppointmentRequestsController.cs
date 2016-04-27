using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class AppointmentRequestsController : Controller
    {
        private UHNDBContext db = new UHNDBContext();

        // GET: Admin/AppointmentRequests
        public ActionResult Index()
        {
            var ap = from c in db.AppointmentRequests
                         orderby c.PreferredDate ascending
                         select c;

            return View(ap);
        }

        // GET: Admin/AppointmentRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentRequest appointmentRequest = db.AppointmentRequests.Find(id);
            if (appointmentRequest == null)
            {
                return HttpNotFound();
            }
            return View(appointmentRequest);
        }

       
        // GET: Admin/AppointmentRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentRequest appointmentRequest = db.AppointmentRequests.Find(id);
            if (appointmentRequest == null)
            {
                return HttpNotFound();
            }
            return View(appointmentRequest);
        }

        // POST: Admin/AppointmentRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientName,PatientAge,PatientSex,PatientPhone,PatientEmail,PreferredDate,Reasons")] AppointmentRequest appointmentRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointmentRequest);
        }

        // GET: Admin/AppointmentRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentRequest appointmentRequest = db.AppointmentRequests.Find(id);
            if (appointmentRequest == null)
            {
                return HttpNotFound();
            }
            return View(appointmentRequest);
        }

        // POST: Admin/AppointmentRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentRequest appointmentRequest = db.AppointmentRequests.Find(id);
            db.AppointmentRequests.Remove(appointmentRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
