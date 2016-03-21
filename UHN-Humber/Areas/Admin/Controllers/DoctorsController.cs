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
    public class DoctorsController : Controller
    {
        private UHNDBContext db = new UHNDBContext();

        // GET: Admin/Doctors
        public ActionResult Index(string orderBy)
        {
            IOrderedQueryable<Doctor> doctors = db.Doctors;
            string order = String.IsNullOrEmpty(orderBy) ? "id" : orderBy;

            switch (order)
            {
                case "id":
                    doctors = doctors.OrderBy(d => d.DocId);
                    break;
                case "first_name":
                    doctors = doctors.OrderBy(d => d.Doc_first_name);
                    break;
                case "last_name":
                    doctors = doctors.OrderBy(d => d.Doc_last_name);
                    break;
                default:
                    Response.Write("invalid order name");
                    break;
            }
            

            return View(doctors.ToList());
        }

        // GET: Admin/Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Admin/Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocId,Doc_academic_affiliation,Doc_clinic,Doc_education_and_training,Doc_email,Doc_first_name,Doc_image,Doc_languages,Doc_last_name,Doc_middle_name,Doc_phone,Doc_program,Doc_publications,Doc_research_institute_affiliations,Doc_research_profile,Doc_specialty")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Admin/Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Admin/Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocId,Doc_academic_affiliation,Doc_clinic,Doc_education_and_training,Doc_email,Doc_first_name,Doc_image,Doc_languages,Doc_last_name,Doc_middle_name,Doc_phone,Doc_program,Doc_publications,Doc_research_institute_affiliations,Doc_research_profile,Doc_specialty")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Admin/Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Admin/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
