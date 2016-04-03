using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Areas.Admin.Controllers
{
    public class FAQController : Controller
    {

        UHNDBContext uc = new UHNDBContext();

        // GET: Admin/FAQ
        public ActionResult Index()
        {
            var categories = from c in uc.faq_category
                             orderby c.faq_category_order ascending
                             select c;


            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {

            List<SelectListItem> items = new SelectList(uc.faq_category
                                              .OrderBy(e => e.faq_category_order),
                             "faq_category_order", "faq_category_order").ToList();

            var numItem = items.Count() + 1;

            items.Add(new SelectListItem { Text = numItem.ToString(), Value = numItem.ToString() });

            ViewBag.Categories = items;
            ViewBag.MaxValue = items.Count();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                faq_category fc = new faq_category();

                var numItems = uc.faq_category.Count();



                fc.faq_category_name = formCollection["faq_category_name"];

                if (formCollection["Categories"] == "" || formCollection["Categories"]== formCollection["maxValue"])
                {
                    fc.faq_category_order = Int32.Parse(formCollection["maxValue"]);
                }
                else
                {
                   foreach(var oldc in uc.faq_category)
                    {
                        if(oldc.faq_category_order >= Int32.Parse(formCollection["Categories"]))
                        {
                            oldc.faq_category_order = oldc.faq_category_order + 1;
                        }
                    }
                   fc.faq_category_order = Int32.Parse(formCollection["Categories"]);
                }

                uc.faq_category.Add(fc);
                uc.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            faq_category fc = uc.faq_category.Single(p => p.faq_category_id == id);
            return View(fc);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            faq_category fc = uc.faq_category.Single(p => p.faq_category_id == id);



            foreach (var oldc in uc.faq_category)
            {
                if (oldc.faq_category_order > fc.faq_category_order)
                {
                    oldc.faq_category_order = oldc.faq_category_order - 1;
                }
            }

            uc.faq_category.Remove(fc);
            uc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            faq_category fc = uc.faq_category.Single(p => p.faq_category_id == id);


            List<SelectListItem> items = new SelectList(uc.faq_category
                                             .OrderBy(e => e.faq_category_order),
                            "faq_category_order", "faq_category_order").ToList();

            foreach(var item in items)
            {
                if(item.Value == fc.faq_category_order.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.Categories = items;
            ViewBag.Questions = uc.faq_question.Where(q=>q.faq_question_category==id).OrderBy(q => q.faq_question_order).ToList();

            return View(fc);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            var oldindex = Int32.Parse(formCollection["oldindex"]);
            var faqid = Int32.Parse(formCollection["faqid"]);

            var newname = formCollection["faq_category_name"];
            var newindex = Int32.Parse(formCollection["Categories"]);


            faq_category fc = uc.faq_category.Single(p => p.faq_category_id == faqid);



            if (oldindex == newindex)
            {

            }
            else if (oldindex > newindex)
            {

                foreach(var item in uc.faq_category)
                {
                    if(item.faq_category_order >= newindex && item.faq_category_order < oldindex && item.faq_category_id != faqid)
                    {
                        
                        item.faq_category_order = item.faq_category_order + 1;
                    }
                }   
            }
            else
            {
                foreach (var item in uc.faq_category)
                {
                    if (item.faq_category_order <= newindex && item.faq_category_order > oldindex && item.faq_category_id != faqid)
                    {
                        item.faq_category_order = item.faq_category_order - 1;
                    }
                }
            }

            fc.faq_category_name = newname;
            fc.faq_category_order = newindex;


            uc.SaveChanges();

            return RedirectToAction("Index");
        }



        // Question 


        [HttpGet]
        public ActionResult CreateQuestion(int id)
        {

            List<SelectListItem> items = new SelectList(uc.faq_question.Where(q => q.faq_question_category == id).OrderBy(e => e.faq_question_order), "faq_question_order", "faq_question_order").ToList();
                
               
            var numItem = items.Count() + 1;

            items.Add(new SelectListItem { Text = numItem.ToString(), Value = numItem.ToString() });
            ViewBag.CategoryID = id;
            ViewBag.Questions = items;
            ViewBag.MaxValue = items.Count();
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                faq_question fq = new faq_question();

                var categoryid = Int32.Parse(formCollection["categoryid"]);

                var numItems = uc.faq_question.Where(q => q.faq_question_category == categoryid).Count();


                fq.faq_question_category = categoryid;
                fq.faq_question_question = formCollection["faq_question_question"];
                fq.faq_question_answer = formCollection["faq_question_answer"];

                if (formCollection["Questions"] == "" || formCollection["Questions"] == formCollection["maxValue"])
                {
                    fq.faq_question_order = Int32.Parse(formCollection["maxValue"]);
                }
                else
                {
                    foreach (var oldc in uc.faq_question.Where(q => q.faq_question_category == categoryid))
                    {
                        if (oldc.faq_question_order >= Int32.Parse(formCollection["Questions"]))
                        {
                            oldc.faq_question_order = oldc.faq_question_order + 1;
                        }
                    }
                    fq.faq_question_order = Int32.Parse(formCollection["Questions"]);
                }

                uc.faq_question.Add(fq);
                uc.SaveChanges();
                return RedirectToAction("Edit", new { id = categoryid });
            }
            return RedirectToAction("CreateQuestion");
        }


        [HttpGet]
        public ActionResult DeleteQuestion(int id)
        {
            faq_question fc = uc.faq_question.Single(p => p.faq_question_id == id);
            return View(fc);
        }


        [HttpPost, ActionName("DeleteQuestion")]
        public ActionResult DeleteConfirmedQuestion(int id)
        {
            faq_question fc = uc.faq_question.Single(p => p.faq_question_id == id);

            var questionlist = uc.faq_question.Where(q => q.faq_question_category == fc.faq_question_category);

            foreach (var oldc in questionlist)
            {
                if (oldc.faq_question_order > fc.faq_question_order)
                {
                    oldc.faq_question_order = oldc.faq_question_order - 1;
                }
            }

            uc.faq_question.Remove(fc);
            uc.SaveChanges();
            return RedirectToAction("Edit", new { id=fc.faq_question_category});
        }





        [HttpGet]
        public ActionResult EditQuestion(int id)
        {

            faq_question fc = uc.faq_question.Single(p => p.faq_question_id == id);


            List<SelectListItem> items = new SelectList(uc.faq_question.Where(q => q.faq_question_category == fc.faq_question_category).OrderBy(e => e.faq_question_order), "faq_question_order", "faq_question_order").ToList();

            foreach (var item in items)
            {
                if (item.Value == fc.faq_question_order.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.Questions = items;
            ViewBag.CategoryID = fc.faq_question_category;
            return View(fc);
        }

        [HttpPost]
        public ActionResult EditQuestion(FormCollection formCollection)
        {
            var oldindex = Int32.Parse(formCollection["oldindex"]);
            var faqid = Int32.Parse(formCollection["faqid"]);

            var newquestion = formCollection["faq_question_question"];
            var newanswer = formCollection["faq_question_question"];
            var newindex = Int32.Parse(formCollection["Questions"]);


            faq_question fc = uc.faq_question.Single(p => p.faq_question_id == faqid);



            if (oldindex == newindex)
            {

            }
            else if (oldindex > newindex)
            {

                foreach (var item in uc.faq_question.Where(q=>q.faq_question_category == fc.faq_question_category))
                {
                    if (item.faq_question_order >= newindex && item.faq_question_order < oldindex && item.faq_question_id != faqid)
                    {

                        item.faq_question_order = item.faq_question_order + 1;
                    }
                }
            }
            else
            {
                foreach (var item in uc.faq_question.Where(q => q.faq_question_category == fc.faq_question_category))
                {
                    if (item.faq_question_order <= newindex && item.faq_question_order > oldindex && item.faq_question_id != faqid)
                    {
                        item.faq_question_order = item.faq_question_order - 1;
                    }
                }
            }

            fc.faq_question_question = newquestion;
            fc.faq_question_answer = newanswer;
            fc.faq_question_order = newindex;
            fc.faq_question_category = fc.faq_question_category;

            uc.SaveChanges();

            return RedirectToAction("Edit", new { id = fc.faq_question_category});
        }











    }
}