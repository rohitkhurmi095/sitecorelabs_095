using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;
using Sitecore.Publishing;
using Sitecore.SecurityModel; //Security Disabler

namespace Sitecore.Project.Website.Controllers
{
    public class TrnCommentsFormController : Controller
    {
       //=======
       // GET
       //=======
       //GET - Comments Form
       //View(Index) - Comment's Form
       //Shows Comment Form on Website
       //View for GET = Index.cshtml
       //HttpGet - action verb
       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //=====
        //POST
        //=====
        //Post function - Publsih Comments directly to webDatabase(CD)
        //Adds Comments to under Article in Sitecore instance
        //We need to create separate View for POST request 
        //So we need to pass ModelName & instance in Index(ModelName modelInstance)
        //View for POST = summary.cshtml
        //HttpPost - action verb
        [HttpPost]
        public ActionResult Index(Comment comment)
        {
            //Context Item(Article) - from WebDatabase
            //But it should come from the masterDatabase to create comments immediately
            //comments(Child) created under Article(Parent)
            var contextItem = Sitecore.Context.Item;

            //__________________________
            //COMMENTS CREATION LOGIC
            //__________________________

            //1.Get the databse to create the item
            //----------------
            var masterDB = Sitecore.Configuration.Factory.GetDatabase("master"); //to create comment
            var webDB = Sitecore.Configuration.Factory.GetDatabase("web"); //to publish comment

            //2.Get the Template from which item has to be created - using TemplateId
            //templateID of CommentTemplate:{7F93BC87-0460-43C3-8D6D-2477B30F0662}
            //----------------
            //gives commentTemplateID as object
            //used to Add comment to parentItem
            Sitecore.Data.TemplateID commentTemplateID = new Sitecore.Data.TemplateID(new Sitecore.Data.ID("{7F93BC87-0460-43C3-8D6D-2477B30F0662}"));


            //3.Get the Parent Item under which item has to be created
            //--------------------
            //contextItem = Article(Page) FROM masterDB
            //masterDB.GetItem(contextItem.ID)
            var parentItem = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Sitecore.Context.Item.ID);


            //------------------------
            //SECURITY Disabler Block
            //------------------------
            //Disables Security for SitecoreInstance
            //To allow creation from vsCode -> SitecoreInstance
            //Otherwise AccessDenied Exception(for any user)
            //As when user create comment from website(WebDB - CD) - not logged in as admin
            using (new SecurityDisabler())
            {
                //4.Create the Item
                //---------------
                //parentItem.Add(itemName,ItemID)
                //ItemId USED as ObjectType using Sitecore.Data.TemplateID 
                var createdCommentItem = Sitecore.Configuration.Factory.GetDatabase("master")
                                             .GetItem(Sitecore.Context.Item.ID)
                                             .Add(comment.CommenterName,commentTemplateID);

                //5.Update the fields in the item(using CommentModel)
                //-----------------
                //To lock the changes - use BeginEdit() & EndEdit()
                createdCommentItem.Editing.BeginEdit();
                createdCommentItem.Fields["CommenterName"].Value = comment.CommenterName;
                createdCommentItem.Fields["CommenterEmail"].Value = comment.CommenterEmail;
                createdCommentItem.Fields["CommenterComments"].Value = comment.CommenterComments;
                createdCommentItem.Editing.EndEdit();


                //6.Publish the item(on webDB) - To get instant View(on Website)
                //-------------------
                //Sitecore.Publishing.PublishOptions
                Sitecore.Publishing.PublishOptions publishOptions = new Sitecore.Publishing.PublishOptions(masterDB,webDB, PublishMode.SingleItem,createdCommentItem.Language,DateTime.Now);
                //Pass PublisherObject to Publisher
                Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);
                //PublishOptions
                publisher.Options.RootItem = createdCommentItem;
                publisher.Options.Deep = true;
                //FinalPublish
                publisher.Publish();
            }

            //Load View: on POST Request
            //To display sperate view for POST
            //Provide full path after the root
            return View("/Views/TrnCommentsForm/Summary.cshtml");
        }
    }
}