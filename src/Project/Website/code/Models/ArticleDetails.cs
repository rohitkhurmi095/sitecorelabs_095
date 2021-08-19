using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //ArticleDetails MODEL
    //----------------------
    public class ArticleDetails
    {
        public HtmlString ArticleTitle { get; set; }
        public HtmlString ArticleDescription { get; set; }
        public HtmlString ArticlePublishDate { get; set; }
        public HtmlString ArticleImage { get; set; }
    }
}