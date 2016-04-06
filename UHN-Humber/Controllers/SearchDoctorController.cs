using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class SearchDoctorController : Controller
    {
        private UHNDBContext db = new UHNDBContext();

        // GET: Admin/Doctors
        public ActionResult Index(string orderBy, string searchText, int? pageNumber)
        {
            IQueryable<Doctor> doctors = db.Doctors;
            string order = String.IsNullOrEmpty(orderBy) ? "id" : orderBy;

            // Search if search text is not empty
            if (!String.IsNullOrEmpty(searchText))
            {
                doctors = doctors.Where(doc => doc.Doc_first_name.Contains(searchText) || doc.Doc_last_name.Contains(searchText));
            }

            // Sort result
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

            int page = pageNumber ?? 1;
            ViewData["searchText"] = searchText;
            ViewData["orderBy"] = orderBy;
            ViewData["pageNumber"] = page;
            return View(doctors.ToPagedList(page, 5));
            //return View(doctors.ToList());
        }

        // GET: /Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }
    }
}