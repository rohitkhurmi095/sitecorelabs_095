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
    public class TrnSubjectDetailsController : Controller
    {
        // GET: TrnSubjectDetails
        public ActionResult Index()
        {
            //current context(SubjectDetails)
            var contextItem = Sitecore.Context.Item;

            //create model instance + set field values
            SubjectDetails sbdetails = new SubjectDetails();
            sbdetails.Title = new HtmlString(FieldRenderer.Render(contextItem,"Title"));
            sbdetails.Description = new HtmlString(FieldRenderer.Render(contextItem,"Description"));

            //pass model instance to view
            return View(sbdetails);
        }
    }
}