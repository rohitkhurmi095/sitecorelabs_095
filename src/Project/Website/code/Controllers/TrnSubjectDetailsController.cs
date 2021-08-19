using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

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
            sbdetails.Title = contextItem.Fields["Title"].Value;
            sbdetails.Description = contextItem.Fields["Description"].Value;

            //pass model instance to view
            return View(sbdetails);
        }
    }
}