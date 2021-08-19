using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;
using Sitecore.Web.UI.WebControls;

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
            article.ArticleTitle = new HtmlString(FieldRenderer.Render(contextItem,"ArticleTitle"));
            article.ArticleDescription = new HtmlString(FieldRenderer.Render(contextItem,"ArticleDescription"));
            article.ArticlePublishDate = new HtmlString(FieldRenderer.Render(contextItem,"ArticlePublishDate"));
            article.ArticleImage = new HtmlString(FieldRenderer.Render(contextItem,"ArticleImage"));

            //return the object to View(Action)
            return View(article);
        }
    }
}