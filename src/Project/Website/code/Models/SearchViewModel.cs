using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //MODEL3:
    //SEARCH VIEW MODEL = SearchTerm Model + SearchReslt Model
    //---------------------------------------------------------
    //SearchTerm = SingleTerm => Type SearchTerm
    //SearchResult = List of Results => Type -SearchResult
    public class SearchViewModel
    {
        public SearchTerm Term { get; set; }
        public List<SearchResult> Result{ get; set; }
    }
}