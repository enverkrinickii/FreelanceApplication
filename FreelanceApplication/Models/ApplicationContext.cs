using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreelanceApplication.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<FreelanceDescription> FreelanceDescriptions { get; set; }

        public ApplicationContext() : base("FreeDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}