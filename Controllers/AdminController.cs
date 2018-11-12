using E3DBPI.Models;
using E3DBPI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace E3DBPI.Controllers
{

    [Authorize(Roles = "SuperAdmin")]

    public class AdminController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // Get the Users and their roles
        //-----------------------------------------------------------------------------------------------------------
        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_role_ViewModel()

                                  {
                                      UserID = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(usersWithRoles);
        }

        // -----------------------------------------------------------------------------------------------------------
        // Create a User
        // -----------------------------------------------------------------------------------------------------------
        public ActionResult CreateUser()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
            string username = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];
            // create a user (default for SuperAdmin)
            var user = new ApplicationUser();
            user.UserName = username;
            user.Email = email;

            var newuser = userManager.Create(user, pwd);

            return View("Index");
        }

        //-----------------------------------------------------------------------------------------------------------
        // Get the Users and their roles
        //-----------------------------------------------------------------------------------------------------------
        public ActionResult RoleManager()

        {
            //var Roles = context.Roles.ToList().Select(r => new RoleManager_ViewModel());

            //var Roles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).ToList().Select(rr => new RoleManager_ViewModel());
            //return View(roles);

            //var Roles = (new ApplicationDbContext()).Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            //new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList().Select(rr => new RoleManager_ViewModel());

            //ViewBag.Roles = RoleManager;

            ViewBag.roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList().Select(p => new RoleManager_ViewModel());
            //return View();


            return View(ViewBag.roles);


            //return View (Roles);

            //var rolelist = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList().Select(r => new RoleManager_ViewModel());
            //return View(rolelist);
        }

        // -----------------------------------------------------------------------------------------------------------
        // Create User Roles
        // -----------------------------------------------------------------------------------------------------------
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            if (!roleManager.RoleExists(rolename))
            {
                // Create the Role
                var role = new IdentityRole(rolename);
                roleManager.Create(role);
            }
            return View();
        }

        // -----------------------------------------------------------------------------------------------------------
        // Assign users to roles
        // -----------------------------------------------------------------------------------------------------------
        public ActionResult AssignRole()
        {
            ViewBag.roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string usrname = form["txtUserName"];
            string rolename = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolename);


            //userManager.AddToRole(user.Id, "SuperAdmin");

            return View("Index");
        }


    }
}