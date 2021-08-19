using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

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
            sdetails.Name = contextItem.Fields["Name"].Value;
            sdetails.DOB = contextItem.Fields["DOB"].Value;
            sdetails.Email = contextItem.Fields["Email"].Value;
            sdetails.PhoneNo = contextItem.Fields["PhoneNo"].Value;
            sdetails.Profile = contextItem.Fields["Profile"].Value;
            sdetails.Photograph = contextItem.Fields["Photograph"].Value;

            //return model instance to view
            return View(sdetails);
        }
    }
}