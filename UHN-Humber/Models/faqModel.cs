using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UHN_Humber.Models
{
    public class faqModel
    {
        public IQueryable<FAQCategory> modelOne;
        public IQueryable<FAQQuestion> modelTwo;
    }
}