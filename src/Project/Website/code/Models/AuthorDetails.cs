using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //AuthorDetails MODEL
    //----------------------
    public class AuthorDetails
    {
        public HtmlString AuthorName { get; set; }
        public HtmlString AuthorDesignation { get; set; }
        public HtmlString AuthorImage { get; set; }
    }
}