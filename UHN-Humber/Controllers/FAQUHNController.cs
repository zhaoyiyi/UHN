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
            var categories = from c in uc.faq_category
                             orderby c.faq_category_order ascending
                             select c;


            var questions = from p in uc.faq_question
                            orderby p.faq_question_order ascending
                            select p;

            var cq = new faqModel();
            cq.modelOne = categories;
            cq.modelTwo = questions;


            return View(cq);
        }

        public ActionResult displayQList(string id)
        {
            var categories = from c in uc.faq_category
                             orderby c.faq_category_order ascending
                             select c;


            var questions = from p in uc.faq_question
                            orderby p.faq_question_order ascending
                            select p;

            var cq = new faqModel();
            cq.modelOne = categories;
            cq.modelTwo = questions;
          

            return View(cq);

        }


    }
}