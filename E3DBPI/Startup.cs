using E3DBPI.Models;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

using System;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(E3DBPI.Startup))]
namespace E3DBPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateUserAndRoles();
        }

        // This is for setting up initial SuperAdmin role and attaching to a user after aspnet identity db is created
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // create SuperAdmin role if it does not already exist - 
            if (!roleManager.RoleExists("TestAdmin"))
            {
                // Create the Role
                var role = new IdentityRole("SuperAdmin");
                //roleManager.Create(role);

                // create Default users
                var user = new ApplicationUser();
                user.UserName = "testadmin01@dbpius.com";
                user.Email = "testadmin01@dbpius.com";
                string pwd = "TestAdmin01_pw";

                var newuser = userManager.Create(user, pwd);

                // attach the user to the role
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }
            }

        }

    }
}
