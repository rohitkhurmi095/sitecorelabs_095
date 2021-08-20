using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;
using Sitecore.Links;

namespace Sitecore.Project.Website.Controllers
{
    /* Articles(Listing)
        - Article1
        - Article2 
     Article = children of ArticlesListing
     Sitecore.Data.Items.Item.GetChildren()
     Sitecore.Context.Item.GetChildren()
      - returns collection type
      - convert to ChildList(colelction) to List using .ToList()
        //returns childrens under a current Item context(Articles)
        //use LINQ to iterate on collections using Select()
        //convert childList(Complete information) -> List(display- Article only Name(url),descritpion) */

    public class TrnArticlesListingController : Controller
    {
        // GET: TrnArticlesListing
        public ActionResult Index()
        {
            //contextItem
            var contextItem = Sitecore.Context.Item;

            //ListingCard Item
            var articleCard = Sitecore.Context.Item.GetChildren()
                              .Select(x => new ArticleListing
                              {
                                  ArticleTitle = x.Fields["ArticleTitle"].Value,
                                  ArticleDescription = new HtmlString(x.Fields["ArticleDescription"].Value),
                                  ArticleUrl = LinkManager.GetItemUrl(x)
                              }).ToList();

            //return articleCard to View
            return View(articleCard);
        }
    }
}