using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models; //Model
using Sitecore.Links; //LinkManager
using Sitecore.Mvc.Presentation; //RenderingContext

namespace Sitecore.Project.Website.Controllers
{
    //Note:
    //-------
    //Sitecore.Mvc.Presentation - RenderingContext
    //Sitecore.Context.Item - currentContext Item
    //Sitecore.Mvc.Presentation.RenderingContext.Current.Context.Item - currentContext Item
    //Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item - used with DataSource
    //Eg: currentContext = CSE - use RenderingContext.Current.Context.Item
    //DataSourece added = staff1 - use RenderingContext.Current.Rendering.Item
    /* CSE(Dept)
        - Staffs
            - Staff1
        - Students
            - Student1
        - Subjects 
            - Subject1
        To display single Subject/Student/Staff under ECE(Dept) directly
        - Use DataSourece 
        - Presentation - Details - Edit - AddDataSourece

     //To add >1 dataSourece
    -------------------------
    Layouts 
        - PlaceholderSettings - Add Defination Item for trn-main Placeholder
        - Create placeholder - trn-main(placeholder key)

        Experience Editor(DepartmentPage - CSE)
        - click on any field - Add here
        - go to last option - click 
             - Add here is shown on component
             - Add 1 more rendering(component) here in this placeholder
             - Add associated content
        => 1 more dataSource gets added in the same placeholder

    Personalization(2nd icon)
    --------------------------
    - only possible with rendering context
    - context item with dataSoure
    - dataSource can be modified
   */

    public class TrnHallOfFameController : Controller
    {
        // GET: TrnHallOfFame
        public ActionResult Index()
        {
            //contextItem
            var contextItem = RenderingContext.Current.Rendering.Item;

            //Create Model instance + set field values
            var DeptListingCard = new DeptListingCard
            {
                EntityName = contextItem.Fields["EntityName"].Value,
                EntityBrief = new HtmlString(contextItem.Fields["EntityBrief"].Value),
                EntityUrl = LinkManager.GetItemUrl(contextItem)
            };

            //return model instance to view
            return View(DeptListingCard);
        }
    }
}