using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //Comments Model
    //---------------
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommenterEmail { get; set; }
        public string CommenterComments { get; set; }
    }
}