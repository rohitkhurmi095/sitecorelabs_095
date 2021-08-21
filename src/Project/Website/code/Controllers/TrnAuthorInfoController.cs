using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;

namespace Sitecore.Project.Website.Controllers
{
    //AuthorInfo - multilist(ComplexField) 
    //Access AuthorInfo on ArticlePage
    //Create AuthorInfo - controller rendering(MVC) on ArticlePage
    //-------------------------------------------
    //Map Staff/Student as author on Article Page
    //--------------------------------------------
    //AuthorInfo: Multilist Field - Source:StaffID,StudentID


    public class TrnAuthorInfoController : Controller
    {
        // GET: TrnAuthorInfo
        public ActionResult Index()
        {
            //NOTE: ---------
            //ContextItem(Article)
            //var contextItem = Sitecore.Context.Item;.
            //AuthorInfo authors = new AuthorInfo();
            //authors.AuthorInformation = contextItem.Fields["AuthorInfo"].Value;
            //return View(authors);
            //Output:StaffID or StudentID passed as DataSource in AuthorInfo Multilist Field
            //OUTPUT: {DB3DE4DB-EA0F-4246-8C07-9197511727FD}|{50E84318-7C2E-4FDE-9B3E-B6CAE51B141D}

            //so this is not a way to access Multilist Fields(Complex Fields)
            //-----------------


            //________
            // Way 1 - traditional way
            //________
            //Note: This method is not recomended if we have many articles & we not added authorInfo component to every article
            //AuthorId will show on the articles, where authorInfo component is not added
            //contextItem - Article(Page)

            /*var contextItem = Sitecore.Context.Item;

            //Task:
            //We hava ItemID's sperated with | Symbol
            //using this we need to get the Item
            //------------------------------------
            //create list of Authors
            List<AuthorInfo> authorsList = new List<AuthorInfo>();

            //Current Field Value
            var authorInfo_String = contextItem.Fields["AuthorInfo"].Value;

            //Check if string is notNull
            if (!string.IsNullOrEmpty(authorInfo_String))
            {
                //split() string -> array of [id's] (array of authorID's)
                var authorIds_array = authorInfo_String.Split('|');

                //Iterate through array of authorId's 
                foreach (var authorId in authorIds_array)
                {   //get Item using each id
                    //Sitecore.Context.Database.GetItem(new Sitecore.Data.Id(ItemId))
                    var author_Item = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID(authorId));

                    //Assign Field to each Item - using Model(AuthorInfo)
                    //Common for both = EntityName(Base template)
                    AuthorInfo ainfo = new AuthorInfo();
                    ainfo.AuthorInformation = author_Item.Fields["EntityName"].Value;

                    //Add Author to List
                    authorsList.Add(ainfo);
                }
            }

            //Return List<authors>: multilist to View
            return View(authorsList);*/




            //______
            //Way 2 - using Multilist Field
            //______
            //Note: This method is recomended if we have multiple articles & we dont want to show articleInfo for all articles
            //AuthorInfo will display only on those Articles where it is added
            //ContextItem - currentItem(Article)
            var contextItem = Sitecore.Context.Item;

            //List of Authors
            List<AuthorInfo> authorsList = new List<AuthorInfo>();

            //MultilistField - Sitecore.Data.Fields.MulitlistFiled - type, method = GetItems()
            //returns sitecore Items[] 
            //convert Items[] -> list using .ToList()
            //Eg: authorsInfo - type = multiListField
            Sitecore.Data.Fields.MultilistField authorsInfo = contextItem.Fields["AuthorInfo"];

            //AuthorsList
            authorsList = authorsInfo.GetItems()
                                     .Select(x => new AuthorInfo{
                                         AuthorInformation = x.Fields["EntityName"].Value

                                     }).ToList();

            //Pass authorsList to View
            return View(authorsList);
        }
    }
}