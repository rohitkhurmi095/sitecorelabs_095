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
    public class TrnStaffDetailsController : Controller
    {
        // GET: TrnStaffDetails
        public ActionResult Index()
        {
            //current context
            var contextItem = Sitecore.Context.Item;

            //create model instance + set field values
            StaffDetails sfdetails = new StaffDetails();
            sfdetails.Name = new HtmlString(FieldRenderer.Render(contextItem,"Name"));
            sfdetails.Profile = new HtmlString(FieldRenderer.Render(contextItem,"Profile"));
            sfdetails.Experience = new HtmlString(FieldRenderer.Render(contextItem,"Experience"));
            sfdetails.Specialization = new HtmlString(FieldRenderer.Render(contextItem,"Specialization"));
            sfdetails.Profile = new HtmlString(FieldRenderer.Render(contextItem,"Profile"));
            sfdetails.Photo = new HtmlString(FieldRenderer.Render(contextItem,"Photo"));

            //return model instance to view
            return View(sfdetails);
        }
    }
}