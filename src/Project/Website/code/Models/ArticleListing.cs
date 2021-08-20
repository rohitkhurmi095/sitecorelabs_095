using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //Article Listing Card Model
    //---------------------------
    public class ArticleListing
    {
        public string ArticleTitle { get; set; }
        public HtmlString ArticleDescription { get; set; }
        public string ArticleUrl { get; set; }
    }
}