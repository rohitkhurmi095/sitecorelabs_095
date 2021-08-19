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
    public class TrnStudentDetailsController : Controller
    {
        // GET: TrnStudentDetails
        public ActionResult Index()
        {
            //contextItem
            var contextItem = Sitecore.Context.Item;

            //create model instance + set values
            StudentDetails sdetails = new StudentDetails();
            sdetails.Name = new HtmlString(FieldRenderer.Render(contextItem,"Name"));
            sdetails.DOB = new HtmlString(FieldRenderer.Render(contextItem,"DOB"));
            sdetails.Email = new HtmlString(FieldRenderer.Render(contextItem,"Email"));
            sdetails.PhoneNo = new HtmlString(FieldRenderer.Render(contextItem,"PhoneNo"));
            sdetails.Profile = new HtmlString(FieldRenderer.Render(contextItem,"Profile"));
            sdetails.Photograph = new HtmlString(FieldRenderer.Render(contextItem,"Photograph"));

            //return model instance to view
            return View(sdetails);
        }
    }
}