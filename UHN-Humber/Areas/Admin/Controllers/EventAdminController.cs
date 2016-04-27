using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class EventAdminController : Controller
    {
        UHNDBContext uc = new UHNDBContext();

        // GET: Admin/EventAdmin
        public ActionResult Index()
        {
            var events = from c in uc.Events
                         orderby c.EventDate ascending
                         select c;
            return View(events);
        }

        public ActionResult passedEvents()
        {
            var events = uc.Events.Where(b => b.EventDate < DateTime.Now).OrderBy(b=>b.EventDate);
            return View(events);
        }
        public ActionResult upcomingEvents()
        {
            var events = uc.Events.Where(b => b.EventDate >= DateTime.Now).OrderBy(b => b.EventDate);
            return View(events);
        }

        [HttpGet]
        public ActionResult Create()
        {

            var list = new List<SelectListItem>();

            list.Add(new SelectListItem { Value = "12:00 AM", Text = "12:00 AM" });
            list.Add(new SelectListItem { Value = "12:30 AM", Text = "12:30 AM" });


            for (var i = 1; i < 24; i = i + 1)
            {
                var value = "";

                if (i < 12)
                {
                    if (i < 10)
                    {
                        value = "0" + i + ":00 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = "0" + i + ":30 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }
                    else
                    {
                        value = i + ":00 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = i + ":30 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }

                }
                else if (i == 12)
                {
                    value = "12:00 PM";
                    list.Add(new SelectListItem { Value = value, Text = value });
                    value = "12:30 PM";
                    list.Add(new SelectListItem { Value = value, Text = value });
                }
                else
                {
                    var newnum = i - 12;
                    if (newnum < 10)
                    {
                        value = "0" + newnum + ":00 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = "0" + newnum + ":30 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }
                    else
                    {
                        value = newnum + ":00 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = newnum + ":30 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }

                }
            }

            SelectList sl = new SelectList(list, "Value", "Text");

            ViewBag.DdList = sl;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Event e = new Event();

                e.EventTitle = formCollection["EventTitle"];
                e.EventDate = Convert.ToDateTime(formCollection["EventDate"]);


               

                if(formCollection["EventTime"].Substring(6) == "PM")
                {
                    var hourint = Convert.ToInt32(formCollection["EventTime"].Substring(0, 2));
                    if (hourint != 12)
                    {
                        e.EventDate =
                            e.EventDate.Value.AddHours(12 + hourint);
                    }
                    else
                    {
                        e.EventDate = e.EventDate.Value.AddHours(hourint);
                    }
                }
                else
                {
                    var hourint = Convert.ToInt32(formCollection["EventTime"].Substring(0, 2));
                    if(hourint != 12)
                    {

                    e.EventDate =
                        e.EventDate.Value.AddHours(hourint);

                    }
                }

                if(formCollection["EventTime"].Substring(3,2) == "30")
                {
                    e.EventDate = e.EventDate.Value.AddMinutes(30);
                }

                e.EventTime = formCollection["EventTime"];

                e.EventLocation = formCollection["EventLocation"];
                e.EventDescription = formCollection["EventDescription"];
                e.EventRecurred = "Never"; // formCollection["EventRepeat"];

                uc.Events.Add(e);
                uc.SaveChanges();

            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Event fc = uc.Events.Single(p => p.EventID == id);
            return View(fc);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event fc = uc.Events.Single(p => p.EventID == id);

            uc.Events.Remove(fc);
            uc.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Event fc = uc.Events.Single(p => p.EventID == id);


            var list = new List<SelectListItem>();

            list.Add(new SelectListItem { Value = "12:00 AM", Text = "12:00 AM" });
            list.Add(new SelectListItem { Value = "12:30 AM", Text = "12:30 AM" });


            for (var i = 1; i < 24; i = i + 1)
            {
                var value = "";

                if (i < 12)
                {
                    if (i < 10)
                    {
                        value = "0" + i + ":00 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = "0" + i + ":30 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }
                    else
                    {
                        value = i + ":00 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = i + ":30 AM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }

                }
                else if (i == 12)
                {
                    value = "12:00 PM";
                    list.Add(new SelectListItem { Value = value, Text = value });
                    value = "12:30 PM";
                    list.Add(new SelectListItem { Value = value, Text = value });
                }
                else
                {
                    var newnum = i - 12;
                    if (newnum < 10)
                    {
                        value = "0" + newnum + ":00 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = "0" + newnum + ":30 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }
                    else
                    {
                        value = newnum + ":00 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                        value = newnum + ":30 PM";
                        list.Add(new SelectListItem { Value = value, Text = value });
                    }

                }
            }


            SelectList sl = new SelectList(list, "Value", "Text");


            ViewBag.DdList = sl;




            return View(fc);

        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
        

            if (ModelState.IsValid)
            {

                int MyInt = 30;


                if (int.TryParse(formCollection["eventid"], out MyInt))
                {
                    MyInt = int.Parse(formCollection["eventid"]);
                }


                Event e = uc.Events.Single(emp=>emp.EventID == MyInt);

                e.EventTitle = formCollection["EventTitle"];
                
                e.EventDate = Convert.ToDateTime(formCollection["EventDate"]);



                if (formCollection["EventTime"].Substring(6) == "PM")
                {
                    var hourint = Convert.ToInt32(formCollection["EventTime"].Substring(0, 2));
                    if (hourint != 12)
                    {
                        e.EventDate =
                            e.EventDate.Value.AddHours(12 + hourint);
                    }
                    else
                    {
                        e.EventDate = e.EventDate.Value.AddHours(hourint);
                    }
                }
                else
                {
                    var hourint = Convert.ToInt32(formCollection["EventTime"].Substring(0, 2));
                    if (hourint != 12)
                    {

                        e.EventDate =
                            e.EventDate.Value.AddHours(hourint);

                    }
                }

                if (formCollection["EventTime"].Substring(3, 2) == "30")
                {
                    e.EventDate = e.EventDate.Value.AddMinutes(30);
                }
      

                e.EventTime = formCollection["EventTime"];
                e.EventLocation = formCollection["EventLocation"];
                e.EventDescription = formCollection["EventDescription"];
                e.EventRecurred = "Never"; // formCollection["EventRepeat"];

                uc.Entry(e).State = System.Data.Entity.EntityState.Modified;
                uc.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}