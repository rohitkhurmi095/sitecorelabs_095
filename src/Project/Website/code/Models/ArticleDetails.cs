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
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
        public string ArticlePublishDate { get; set; }
        public string ArticleImage { get; set; }
    }
}