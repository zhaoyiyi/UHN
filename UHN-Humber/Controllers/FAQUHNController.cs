using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UHN_Humber.Models;

namespace UHN_Humber.Controllers
{
    public class FAQUHNController : Controller
    {
        UHNDBContext uc = new UHNDBContext();
        // GET: FAQ


        public ActionResult Index()
        {
            var categories = from c in uc.FAQCategories
                             orderby c.FAQCategoryOrder ascending
                             select c;


            var questions = from p in uc.FAQQuestions
                            orderby p.FAQQuestionOrder ascending
                            select p;

            var cq = new faqModel();
            cq.modelOne = categories;
            cq.modelTwo = questions;


            return View(cq);
        }

        public ActionResult displayQList(string id)
        {
            var categories = from c in uc.FAQCategories
                             orderby c.FAQCategoryOrder ascending
                             select c;


            var questions = from p in uc.FAQQuestions
                            orderby p.FAQQuestionOrder ascending
                            select p;

            var cq = new faqModel();
            cq.modelOne = categories;
            cq.modelTwo = questions;
          

            return View(cq);

        }


    }
}