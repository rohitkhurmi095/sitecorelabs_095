using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;
using Sitecore.Links;
using Sitecore.Data.Items;

namespace Sitecore.Project.Website.Controllers
{
    public class TrnBreadcrumbController : Controller
    {

        //LINQ Statement (Language Integrated Query)
        //LINQ - Reduces the line of code in C#
        //Where - Filtering Operation
        //Select - Projection Operation
        //----------------------------------------
        //Breadcrumb => ItemName/ItemUrl - upto root
        //Eg: Home/Articles/Article1 - list of ItemName/ItemUrl - List<BreadcrumbItem> 
        /*context -> sitecore-demo.local.com -> Home -> Articles -> Article1 
          contextItem = currentItem (Article1)
           - get Ancestors of currentItem - Sitecore.Context.Item.Axes.GetAncestors() - returns array[ancestors]
               - context -> sitecore-demo.local.com -> Home -> Articles
           - But we want Items below Home only
             - find StartItem(Home in siteDefination file) - Sitecore.Context.Database.GetItem(startPath)
               startPath = Sitecore.Context.Site.StartPath 
             - get the decendant of Home - Where(x => x.Axes.isDescendentOf(startItem))
          - But this will not include current contextItem
             - add current contextItem to this List[] - concat(new Item[]{Sitecore.Context.Item})
          - Display result (Project) as per Model 
            itrerate through a lis of ancestors & create a new object
            Select(x => new BreadcrumbItem{
                 ItemName = x.Name,
                 ItemUrl = LinkManager.GetDynamicUrl(x)
             })
        - convert to List[] => ToList()*/

        //NOTE:
        /*Template-> articleTemplate(TrnArticle)
              -> Inheritance(this template is inherited from standardTemplate_
                    -> Inherated from other templates(Appeararnce)
                       so, we get name of field - __Display name(to be used in code)*/


        // GET: TrnBreadcrumb
        public ActionResult Index() 
        {
            //current context
            var contextItem = Sitecore.Context.Item;

            //Home - startItem
            var startItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            //create model instance + set values 
            //List of BreadcrumbItems(NavigationItems)
            List<BreadcrumbItem> ancestors = Sitecore.Context.Item.Axes.GetAncestors()
                                             .Where(x=> x.Axes.IsDescendantOf(startItem))
                                             .Concat(new Item[] {contextItem})
                                             .Select(x => new BreadcrumbItem {
                                                 ItemName = x.Fields["__Display name"].Value == "" ? x.Name: x.Fields["__Display name"].Value,
                                                 ItemUrl = LinkManager.GetDynamicUrl(x)
                                             }).ToList();
            
            
            //return model instance to view
            return View(ancestors);
        }
    }
}