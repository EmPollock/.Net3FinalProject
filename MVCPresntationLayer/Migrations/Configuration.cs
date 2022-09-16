namespace MVCPresntationLayer.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCPresntationLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPresntationLayer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCPresntationLayer.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCPresntationLayer.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            const string admin = "admin@company.com";
            const string adminPassword = "P@ssw0rd";

            LogicLayer.UserManager userMgr = new LogicLayer.UserManager();
            var roles = userMgr.GetAllRoles();
            foreach(var role in roles)
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = role });
            }
            if(!roles.Contains("Island Owner")){
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Island Owner" });
            }

            if(!context.Users.Any(u => u.UserName == admin))
            {
                var user = new ApplicationUser()
                {
                    UserName = admin,
                    Email = admin,
                    CharacterName = "Adamin",
                    VillagerID = 100004
                };

                IdentityResult result = userManager.Create(user, adminPassword);
                context.SaveChanges(); // updates the database

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Island Owner");
                    context.SaveChanges();
                }
            }
        }
    }
}
