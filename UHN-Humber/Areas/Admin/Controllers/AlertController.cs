using UHN_Humber.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class AlertController : Controller
    {
        //  private object AlertContext;

        //public object EntityState { get; private set; }
        public ActionResult Index()
        {
            AlertContext alertContext = new AlertContext();
            List<Alert> alert = alertContext.Employees.ToList();
            return View(alert);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alert alert)

        {
            AlertContext alertContext = new AlertContext();


            alertContext.Employees.Add(alert);
            alertContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Alert alert)
        {
            AlertContext alertContext = new AlertContext();
            alertContext.Entry(alert).State = EntityState.Modified;

            alertContext.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AlertContext alertContext = new AlertContext();

            Alert alert = alertContext.Employees.Find(id);

            return View(alert);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AlertContext alertContext = new AlertContext();

            Alert alert = alertContext.Employees.Find(id);


            alertContext.Entry(alert).State = EntityState.Deleted;
            alertContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            AlertContext alertContext = new AlertContext();
            Alert alert = alertContext.Employees.Find(id);

            return View(alert);
        }
    }
}