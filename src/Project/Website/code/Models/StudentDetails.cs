using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //StudentDetails MODEL
    //----------------------
    public class StudentDetails
    {
        public HtmlString  Name{ get; set; }
        public HtmlString DOB { get; set; }
        public HtmlString Email { get; set; }
        public HtmlString PhoneNo { get; set; }
        public HtmlString Profile { get; set; }
        public HtmlString Photograph { get; set; }
    }
}