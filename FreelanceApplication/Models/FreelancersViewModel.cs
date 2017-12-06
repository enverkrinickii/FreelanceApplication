using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelanceApplication.Models
{
    public class FreelancersViewModel
    {
        public IEnumerable<FreelanceDescription> FreelanceDescriptions { get; set; }

    }
}