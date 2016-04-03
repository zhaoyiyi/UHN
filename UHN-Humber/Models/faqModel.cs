using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UHN_Humber.Models
{
    public class faqModel
    {
        public IQueryable<faq_category> modelOne;
        public IQueryable<faq_question> modelTwo;
    }
}