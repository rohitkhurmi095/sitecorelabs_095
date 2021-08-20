using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //Dept(single Staff/Student/Subject) - card
    //Get Entity Name/Breif - BaseInfoTemplate + Inherit in Staff/Department/Subject Templates
    //Displayed on Staff/Student/Subject ListingPage
    //-----------------------------------------------
    public class DeptListingCard
    {
        public string EntityName { get; set; }
        public HtmlString EntityBrief { get; set; }
        public string EntityUrl { get; set; }
    }
}