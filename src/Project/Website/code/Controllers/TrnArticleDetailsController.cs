using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

namespace Sitecore.Project.Website.Controllers
{
    public class TrnArticleDetailsController : Controller
    {
        // GET: TrnArticleDetails
        public ActionResult Index()
        {
            //Sitecore.Context.Item = gets/sets current item
            //Sitecore.Context.Item.Fields["key"].value - to set CollectionValue
            //Current Url/context(Article)
            //Primitve DataType = contextItem
            var contextItem = Sitecore.Context.Item;

            //Create Object for class + pass set Field_Values
            //CLASS(Model) OBJECT - REFFERENTIAL DATA TYPE (Non Primitive)
            ArticleDetails article = new ArticleDetails();
            article.ArticleTitle = contextItem.Fields["ArticleTitle"].Value;
            article.ArticleDescription = contextItem.Fields["ArticleDescription"].Value;
            article.ArticlePublishDate = contextItem.Fields["ArticlePublishDate"].Value;
            article.ArticleImage = contextItem.Fields["ArticleImage"].Value;

            //return the object to View(Action)
            return View(article);
        }
    }
}