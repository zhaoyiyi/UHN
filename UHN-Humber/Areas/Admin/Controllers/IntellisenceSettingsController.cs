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
    public class IntellisenceSettingsController : Controller
    {
        private UHNDBContext db = new UHNDBContext();

        // GET: Admin/IntellisenceSettings
        public ActionResult Index()
        {
            return View(db.IntellisenceSettings.ToList());
        }

        // GET: Admin/IntellisenceSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntellisenceSetting intellisenceSetting = db.IntellisenceSettings.Find(id);
            if (intellisenceSetting == null)
            {
                return HttpNotFound();
            }
            return View(intellisenceSetting);
        }

        // GET: Admin/IntellisenceSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/IntellisenceSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Intellisense,Result_limit,Debounce_Time,id")] IntellisenceSetting intellisenceSetting)
        {
            if (ModelState.IsValid)
            {
                db.IntellisenceSettings.Add(intellisenceSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(intellisenceSetting);
        }

        // GET: Admin/IntellisenceSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntellisenceSetting intellisenceSetting = db.IntellisenceSettings.Find(id);
            if (intellisenceSetting == null)
            {
                return HttpNotFound();
            }
            return View(intellisenceSetting);
        }

        // POST: Admin/IntellisenceSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Intellisense,Result_limit,Debounce_Time,id")] IntellisenceSetting intellisenceSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intellisenceSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(intellisenceSetting);
        }

        // GET: Admin/IntellisenceSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntellisenceSetting intellisenceSetting = db.IntellisenceSettings.Find(id);
            if (intellisenceSetting == null)
            {
                return HttpNotFound();
            }
            return View(intellisenceSetting);
        }

        // POST: Admin/IntellisenceSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IntellisenceSetting intellisenceSetting = db.IntellisenceSettings.Find(id);
            db.IntellisenceSettings.Remove(intellisenceSetting);
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
