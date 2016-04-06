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
            var categories = from c in uc.FAQCategories
                             orderby c.FAQCategoryOrder ascending
                             select c;


            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {

            List<SelectListItem> items = new SelectList(uc.FAQCategories.OrderBy(e => e.FAQCategoryOrder),
                             "FAQCategoryOrder", "FAQCategoryOrder").ToList();

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
                FAQCategory fc = new FAQCategory();

                var numItems = uc.FAQCategories.Count();



                fc.FAQCategoryName = formCollection["FAQCategoryName"];

                if (formCollection["Categories"] == "" || formCollection["Categories"]== formCollection["maxValue"])
                {
                    fc.FAQCategoryOrder = Int32.Parse(formCollection["maxValue"]);
                }
                else
                {
                   foreach(var oldc in uc.FAQCategories)
                    {
                        if(oldc.FAQCategoryOrder >= Int32.Parse(formCollection["Categories"]))
                        {
                            oldc.FAQCategoryOrder = oldc.FAQCategoryOrder + 1;
                        }
                    }
                   fc.FAQCategoryOrder = Int32.Parse(formCollection["Categories"]);
                }

                uc.FAQCategories.Add(fc);
                uc.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            FAQCategory fc = uc.FAQCategories.Single(p => p.FAQCategoryID == id);
            return View(fc);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FAQCategory fc = uc.FAQCategories.Single(p => p.FAQCategoryID == id);



            foreach (var oldc in uc.FAQCategories)
            {
                if (oldc.FAQCategoryOrder > fc.FAQCategoryOrder)
                {
                    oldc.FAQCategoryOrder = oldc.FAQCategoryOrder - 1;
                }
            }

            uc.FAQCategories.Remove(fc);
            uc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            FAQCategory fc = uc.FAQCategories.Single(p => p.FAQCategoryID == id);


            List<SelectListItem> items = new SelectList(uc.FAQCategories
                                             .OrderBy(e => e.FAQCategoryOrder),
                            "FAQCategoryOrder", "FAQCategoryOrder").ToList();

            foreach(var item in items)
            {
                if(item.Value == fc.FAQCategoryOrder.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.Categories = items;
            ViewBag.Questions = uc.FAQQuestions.Where(q=>q.FAQQuestionCategory==id).OrderBy(q => q.FAQQuestionOrder).ToList();

            return View(fc);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            var oldindex = Int32.Parse(formCollection["oldindex"]);
            var faqid = Int32.Parse(formCollection["faqid"]);

            var newname = formCollection["FAQCategoryName"];
            var newindex = Int32.Parse(formCollection["Categories"]);


            FAQCategory fc = uc.FAQCategories.Single(p => p.FAQCategoryID == faqid);



            if (oldindex == newindex)
            {

            }
            else if (oldindex > newindex)
            {

                foreach(var item in uc.FAQCategories)
                {
                    if(item.FAQCategoryOrder >= newindex && item.FAQCategoryOrder < oldindex && item.FAQCategoryID != faqid)
                    {
                        
                        item.FAQCategoryOrder = item.FAQCategoryOrder + 1;
                    }
                }   
            }
            else
            {
                foreach (var item in uc.FAQCategories)
                {
                    if (item.FAQCategoryOrder <= newindex && item.FAQCategoryOrder > oldindex && item.FAQCategoryID != faqid)
                    {
                        item.FAQCategoryOrder = item.FAQCategoryOrder - 1;
                    }
                }
            }

            fc.FAQCategoryName = newname;
            fc.FAQCategoryOrder = newindex;


            uc.SaveChanges();

            return RedirectToAction("Index");
        }



        // Question 


        [HttpGet]
        public ActionResult CreateQuestion(int id)
        {

            List<SelectListItem> items = new SelectList(uc.FAQQuestions.Where(q => q.FAQQuestionCategory == id).OrderBy(e => e.FAQQuestionOrder), "FAQQuestionOrder", "FAQQuestionOrder").ToList();
                
               
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
                FAQQuestion fq = new FAQQuestion();

                var categoryid = Int32.Parse(formCollection["categoryid"]);

                var numItems = uc.FAQQuestions.Where(q => q.FAQQuestionCategory == categoryid).Count();


                fq.FAQQuestionCategory = categoryid;
                fq.FAQQuestionQuestion = formCollection["FAQQuestionQuestion"];
                fq.FAQQuestionAnswer = formCollection["FAQQuestionAnswer"];

                if (formCollection["Questions"] == "" || formCollection["Questions"] == formCollection["maxValue"])
                {
                    fq.FAQQuestionOrder = Int32.Parse(formCollection["maxValue"]);
                }
                else
                {
                    foreach (var oldc in uc.FAQQuestions.Where(q => q.FAQQuestionCategory == categoryid))
                    {
                        if (oldc.FAQQuestionOrder >= Int32.Parse(formCollection["Questions"]))
                        {
                            oldc.FAQQuestionOrder = oldc.FAQQuestionOrder + 1;
                        }
                    }
                    fq.FAQQuestionOrder = Int32.Parse(formCollection["Questions"]);
                }

                uc.FAQQuestions.Add(fq);
                uc.SaveChanges();
                return RedirectToAction("Edit", new { id = categoryid });
            }
            return RedirectToAction("CreateQuestion");
        }


        [HttpGet]
        public ActionResult DeleteQuestion(int id)
        {
            FAQQuestion fc = uc.FAQQuestions.Single(p => p.FAQQuestionID == id);
            return View(fc);
        }


        [HttpPost, ActionName("DeleteQuestion")]
        public ActionResult DeleteConfirmedQuestion(int id)
        {
            FAQQuestion fc = uc.FAQQuestions.Single(p => p.FAQQuestionID == id);

            var questionlist = uc.FAQQuestions.Where(q => q.FAQQuestionCategory == fc.FAQQuestionCategory);

            foreach (var oldc in questionlist)
            {
                if (oldc.FAQQuestionOrder > fc.FAQQuestionOrder)
                {
                    oldc.FAQQuestionOrder = oldc.FAQQuestionOrder - 1;
                }
            }

            uc.FAQQuestions.Remove(fc);
            uc.SaveChanges();
            return RedirectToAction("Edit", new { id=fc.FAQQuestionCategory});
        }





        [HttpGet]
        public ActionResult EditQuestion(int id)
        {

            FAQQuestion fc = uc.FAQQuestions.Single(p => p.FAQQuestionID == id);


            List<SelectListItem> items = new SelectList(uc.FAQQuestions.Where(q => q.FAQQuestionCategory == fc.FAQQuestionCategory).OrderBy(e => e.FAQQuestionOrder), "FAQQuestionOrder", "FAQQuestionOrder").ToList();

            foreach (var item in items)
            {
                if (item.Value == fc.FAQQuestionOrder.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.Questions = items;
            ViewBag.CategoryID = fc.FAQQuestionCategory;
            return View(fc);
        }

        [HttpPost]
        public ActionResult EditQuestion(FormCollection formCollection)
        {
            var oldindex = Int32.Parse(formCollection["oldindex"]);
            var faqid = Int32.Parse(formCollection["faqid"]);

            var newquestion = formCollection["FAQQuestionQuestion"];
            var newanswer = formCollection["FAQQuestionAnswer"];
            var newindex = Int32.Parse(formCollection["Questions"]);


            FAQQuestion fc = uc.FAQQuestions.Single(p => p.FAQQuestionID == faqid);



            if (oldindex == newindex)
            {

            }
            else if (oldindex > newindex)
            {

                foreach (var item in uc.FAQQuestions.Where(q=>q.FAQQuestionCategory == fc.FAQQuestionCategory))
                {
                    if (item.FAQQuestionOrder >= newindex && item.FAQQuestionOrder < oldindex && item.FAQQuestionID != faqid)
                    {

                        item.FAQQuestionOrder = item.FAQQuestionOrder + 1;
                    }
                }
            }
            else
            {
                foreach (var item in uc.FAQQuestions.Where(q => q.FAQQuestionCategory == fc.FAQQuestionCategory))
                {
                    if (item.FAQQuestionOrder <= newindex && item.FAQQuestionOrder > oldindex && item.FAQQuestionID != faqid)
                    {
                        item.FAQQuestionOrder = item.FAQQuestionOrder - 1;
                    }
                }
            }

            fc.FAQQuestionQuestion = newquestion;
            fc.FAQQuestionAnswer = newanswer;
            fc.FAQQuestionOrder = newindex;
            fc.FAQQuestionCategory = fc.FAQQuestionCategory;

            uc.SaveChanges();

            return RedirectToAction("Edit", new { id = fc.FAQQuestionCategory});
        }











    }
}