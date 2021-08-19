using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.Website.Models
{
    //StudentDetails MODEL
    //----------------------
    public class StudentDetails
    {
        public string  Name{ get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Profile { get; set; }
        public string Photograph { get; set; }
    }
}