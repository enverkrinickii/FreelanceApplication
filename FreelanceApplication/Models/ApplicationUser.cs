using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreelanceApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            if (IsFreelanser)
            {
                FreelanceDescriptions = new List<FreelanceDescription>();
            }
        }

        public DateTime RegisterDate { get; set; }

        public bool IsFreelanser { get; set; }

        public virtual ICollection<FreelanceDescription> FreelanceDescriptions { get; set; }

    }
}