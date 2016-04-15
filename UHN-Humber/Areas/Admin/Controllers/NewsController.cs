using UHN_Humber.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            NewsContext newsContext = new NewsContext();
            List<News> news = newsContext.Content.ToList();
            return View(news);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(News news)

        {
            NewsContext newsContext = new NewsContext();


            newsContext.Content.Add(news);
            newsContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(News news)
        {
            NewsContext newsContext = new NewsContext();
            newsContext.Entry(news).State = EntityState.Modified;

            newsContext.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            NewsContext newsContext = new NewsContext();

            News news = newsContext.Content.Find(id);

            return View(news);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsContext newsContext = new NewsContext();

            News news = newsContext.Content.Find(id);


            newsContext.Entry(news).State = EntityState.Deleted;
            newsContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            NewsContext newsContext = new NewsContext();
            News news = newsContext.Content.Find(id);

            return View(news);
        }
    }
}