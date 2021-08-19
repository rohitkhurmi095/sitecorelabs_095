using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

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
            sfdetails.Name = contextItem.Fields["Name"].Value;
            sfdetails.Profile = contextItem.Fields["Profile"].Value;
            sfdetails.Experience = contextItem.Fields["Experience"].Value;
            sfdetails.Specialization = contextItem.Fields["Specialization"].Value;
            sfdetails.Profile = contextItem.Fields["Profile"].Value;
            sfdetails.Photo = contextItem.Fields["Photo"].Value;

            //return model instance to view
            return View(sfdetails);
        }
    }
}