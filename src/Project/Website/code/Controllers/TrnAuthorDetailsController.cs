using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

namespace Sitecore.Project.Website.Controllers
{
    public class TrnAuthorDetailsController : Controller
    {
        // GET: TrnAuthorDetails
        public ActionResult Index()
        {
            //current Context
            var contextItem = Sitecore.Context.Item;

            //Create model instance + set field values
            AuthorDetails adetails = new AuthorDetails();
            adetails.AuthorName = contextItem.Fields["AuthorName"].Value;
            adetails.AuthorDesignation = contextItem.Fields["AuthorDesignation"].Value;
            adetails.AuthorImage = contextItem.Fields["AuthorImage"].Value;

            //return model instance to view
            return View(adetails);
        }
    }
}