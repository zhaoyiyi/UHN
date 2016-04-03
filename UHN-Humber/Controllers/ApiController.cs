using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Menu(string name)
        {
            MenuContext db = new MenuContext();
            IQueryable<Menu> menu = db.Menus;

            if (!String.IsNullOrEmpty(name))
            {
                menu = menu.Where(m => m.name == name);
            }
            return Json(menu.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Menu")]
        public JsonResult SaveMenu(string menu)
        {
            if (String.IsNullOrEmpty(menu)) return Json(new { success = false });

            MenuContext db = new MenuContext();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Menu]");
            dynamic menus = JsonConvert.DeserializeObject(menu);
            foreach (var m in menus)
            {
                Menu menuItem = new Menu();
                menuItem.name = m.name;
                menuItem.menu = JsonConvert.SerializeObject(m.menu);
                db.Menus.Add(menuItem);
            }
            db.SaveChanges();

            return Json(new { success = true});
        }
    }
}