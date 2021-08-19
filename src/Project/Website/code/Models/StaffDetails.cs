using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //StaffDetails MODEL
    //----------------------
    public class StaffDetails
    {
        public HtmlString Name { get; set; }
        public HtmlString Experience { get; set; }
        public HtmlString Profile { get; set; }
        public HtmlString Photo { get; set; }
        public HtmlString Specialization { get; set; }
    }
}