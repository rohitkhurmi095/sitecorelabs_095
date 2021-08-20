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
    /* Listing Card Component */
    //-------------------------
    //for Staffs/Students/Subjects ListingPage
    /*Eg: Staffs(Listing)
          - Staff1
          - Staff2
        - get Children under Staffs
        - Sitecore.Context.Item.GetChildren()
        - returns childList[](collection) 
        - convert this childList[] -> List using .ToList()
    */

    public class TrnListingCardController : Controller
    {
        // GET: TrnListingCard
        public ActionResult Index()
        {
            //contextItem - currentContext
            var contextItem = Sitecore.Context.Item;

            //singleListing card 
            var listingCard = Sitecore.Context.Item.GetChildren()
                              .Select(x => new DeptListingCard{
                                  EntityName = x.Fields["EntityName"].Value,
                                  EntityBrief = new HtmlString(x.Fields["EntityBrief"].Value),
                                  EntityUrl = LinkManager.GetItemUrl(x)
                              }).ToList();

            //return listingCard to View
            return View(listingCard);
        }
    }
}