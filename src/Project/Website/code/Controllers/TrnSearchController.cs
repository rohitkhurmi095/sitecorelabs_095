using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Project.Website.Models;
using Sitecore.ContentSearch; //ContentSearchManager - connect with solr index
using Sitecore.ContentSearch.SearchTypes; //SearchResultItem class

namespace Sitecore.Project.Website.Controllers
{
    //-----------
    //SEARCH PAGE
    //------------
    /*
      - create controller rendering for search
      - create a new template = searchPage
      - assign rendering on searchPage
      - Home - InsertOptions - SearchPage
      - SearchPage is assigned underHome
      - SearchPage only has searchComp(searchForm)
      - SearchResult will be dispalyed on the samePage
     */
    //SearchTerm = SearchFormModel (Model1) - GET
    //SearchResult = SearchResultTitle/SearchResultDescription(Model2) - POST
    //We have 2 models & wanted to bind on a single View 
    //Solution: Create a SearchViewModel - searchResult(model1) + SearchTerm(model2)
    //SearchViewModel contains 2 terms - Term(type=SearchTerm(model1) & Result(Type=SearchResult(model2)
    //SearchTerm = singleTerm
    //SearchResult = List<>
    //Now we can use this SearchViewModel on View 

    //--------------------
    //Solr INDEX Searching
    //---------------------
    /*Search = scanning whole website
        - if we do search directly on Databse = TimeConsuming
        localhost:8983/solr 
        cfg_web_index
        solr pannel - for debugging search issues
        Solr content search API - connect to solr + receive results 
        solr - keeps copy of database as indexes - faster to retrive data
        than traditional relational data(relational database)
        so we use solr to get information
        
        localhost:8983 
        - solr
        - cfg_web_index
        - query(SolrSearchPannel - debugging searchIssues)
        - to check if corresponding Index is available or not
            - ExecuteQuery - gives Indexes

                - q:(SOLR Indexs our SitecoreItems)
                    _templatename:Article - Template in Sitecore
                    - gives [{searchResult1},{searchResult2}....]
                        - articledescription_t:
                          articletitle_t
    */


    //-------------------------
    //IQuerable vs GetQuerable
    //-------------------------
    //Both are used for same thing - READ Only List
    /*IENUMERABLE - GETS THE DATA - returns object of type ienumerable
      GETQUERABLE - GETS THE QUERY FOR THE DATA by adding necessary where conditions
                    - doesnot retrive the data automatically
                    - query executes then corresponding data is retrived 
                     - returns object of type iquerable 
    */

     
    public class TrnSearchController : Controller
    {
        //====
        //GET
        //====
        //Index - SearchForm
        //GET SearchTerm => SearchText
        public ActionResult Index()
        {
            return View();
        }

        //=====
        //POST
        //=====
        //Index - SearchResult
        //For creating 2nd View, we need to pass modelName + modelInsttance
        //POST SearchForm => Get SearchResults
        [HttpPost]
        public ActionResult Index(SearchViewModel searchViewModelInput)
        {
            //***** Sitecore SearchContext API *****
            //_______________________
            // SEARCH Implementation 
            //_______________________
            //1.Get the searchText value - searchViewModelInput.Term.SearchText

            //2.Connect to Solr Index
            //------------------------
            //ContentSearchManager - connecting content with solr
            //Sitecore.ContentSearch.ContentSearchManager.GetIndex("sitecore_web_index");
            //ContentSearchManager.GetIndex("sitecore_web_index");
            //ContentSearch Mangaer
            //  - replaces 'cfg'_web_index with 'sitecore'_web_index
            //  - Connects our code with this index(solr)                    
            // - creates index - contentSearchObject
            //Note: index on solr: cfg_web_index
            //But cfg = sitecoreApplication prefix => cfg=sitecore
            //index = object of solr index
            ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("sitecore_web_index");

            //3.Create SearchResult List(of type SearchResultItem class)
            //---------------------------
            //Sitecore.ContentSearch.SearchTypes.SearchResultItem
            //ResultType - SearchResultItem Class
            List<SearchResultItem> result;

            //4.Create a QueryContext & DO SEARCH on that QueryContext
            //-------------  
            //Search inside this context only & close after search - using block()
            //index.CreateSearchContext() - creating a context
            //context = queryContext - search on this context-----------

            //CREATING searchContext via IProviderSearchContext using index.createSearchContext()
            using (IProviderSearchContext context = index.CreateSearchContext())
            {

                //Do SEARCH on this searchContext
                //---------
                //GetQuerable<> - generic(query any data with this) 
                //Sitecore.ContentSearch.SearchTypes
                //SearchResultItem.content - exposes the fields in the content
                //Where => Search on which template
                //Wherer => SearchTerm = searchOn which term (SearchTerm - InputParameter used as object here)
                result = context?.GetQueryable<SearchResultItem>()
                                  .Where(x => x.TemplateName == "Article")
                                  .Where(x => x.Content.Contains(searchViewModelInput.Term.SearchText))
                                  .ToList();
            }


            //5.TRANSFORM Result To send to VIEW
            //----------------------------------
            //SearchViewModel = SearchTerm + SearchResult
            //Show only title & description - article
            //articletitle_t & atticledescription_t = fields from solr
            List<SearchResult> searchResults = result.Select(x => new SearchResult
            {
                SearchResultTitle = x.Fields["articletitle_t"].ToString(),
                SearchResultDescription = x.Fields["articledescription_t"].ToString()

            }).ToList();


            //6.Fill the SearchViewModel Object Fields
            //--------------------------
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.Result = searchResults;
            searchViewModel.Term = searchViewModelInput.Term;


            //Provide Output After POST Request
            //---------------
            //Return SearchResults to View
            return View(searchViewModel);
        }
    }
}