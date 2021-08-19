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
    public class TrnAuthorDetailsController : Controller
    {
        // GET: TrnAuthorDetails
        public ActionResult Index()
        {
            //current Context
            var contextItem = Sitecore.Context.Item;

            //Create model instance + set field values
            AuthorDetails adetails = new AuthorDetails();
            adetails.AuthorName = new HtmlString(FieldRenderer.Render(contextItem,"AuthorName"));
            adetails.AuthorDesignation = new HtmlString(FieldRenderer.Render(contextItem,"AuthorDesignation"));
            adetails.AuthorImage = new HtmlString(FieldRenderer.Render(contextItem,"AuthorImage"));

            //return model instance to view
            return View(adetails);
        }
    }
}