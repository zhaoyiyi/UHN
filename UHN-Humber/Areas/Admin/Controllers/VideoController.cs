using UHN_Humber.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace UHN_Humber.Areas.Admin.Controllers
{
    public class VideoController : Controller
    {

        public ActionResult Index()
        {
            VideoContext videoContext = new VideoContext();
            List<Video> video = videoContext.Links.ToList();
            return View(video);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Video video)

        {
            VideoContext videoContext = new VideoContext();


            videoContext.Links.Add(video);
            videoContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Video video)
        {
            VideoContext videoContext = new VideoContext();
            videoContext.Entry(video).State = EntityState.Modified;

            videoContext.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            VideoContext videoContext = new VideoContext();

            Video video = videoContext.Links.Find(id);

            return View(video);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoContext videoContext = new VideoContext();

            Video video = videoContext.Links.Find(id);


            videoContext.Entry(video).State = EntityState.Deleted;
            videoContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            VideoContext videoContext = new VideoContext();
            Video video = videoContext.Links.Find(id);

            return View(video);
        }
    }
}