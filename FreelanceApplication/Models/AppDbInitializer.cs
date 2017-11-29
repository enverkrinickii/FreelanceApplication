using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreelanceApplication.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "freelancer"};

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "enver.krinickii@gmail.com", UserName = "enver.krinickii@gmail.com", RegisterDate = DateTime.Today};
            const string password = "1650557";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }
            base.Seed(context);
        }
    }
}