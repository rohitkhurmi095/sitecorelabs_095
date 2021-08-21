using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

namespace Sitecore.Project.Website.Controllers
{
    //In Sitecore Instance
    //Create Comments Template + assign it in INSERT Options of Article Template
    //To Display Commemtns Section Under ArticleDetails
    //Note:using this we can create comment from sitecore instance only
    /* Article
        - comment1
        - comment2
       Article - contextItem (Current url)
       Access comment using Article(CurrentContext) - GetChildren() 
      This returns childList[] -> convert -> List using ToList() */


    public class TrnCommentsController : Controller
    {
        // GET: TrnComments
        public ActionResult Index()
        {
            //current context
            var contextItem = Sitecore.Context.Item;

            //create commentsList - get comments under Article 
            //using - GetChildren() - returns childList[] 
            //convert childList[] to List using ToList()
            var commentsList = Sitecore.Context.Item.GetChildren()
                          .Select(x => new Comment{
                              CommenterName = x.Fields["CommenterName"].Value,
                              CommenterEmail = x.Fields["CommenterEmail"].Value,
                              CommenterComments = x.Fields["CommenterComments"].Value
                          }).ToList();

            //Pass commentsList to View
            return View(commentsList);
        }
    }
}