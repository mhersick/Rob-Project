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
            var userId = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();


            //-----------------------------------------------------------------------------------------------------------
            // Open the Manage home page.
            //-----------------------------------------------------------------------------------------------------------
            SiteDBEntities db = new SiteDBEntities();

            var empq = db.Employees.FirstOrDefault(e => e.UserName == userName);
            var eIDz = empq.EmployeeID;

            var eIDx = db.Employees.FirstOrDefault(e => e.EmployeeID == eIDz);
            ViewBag.eIDx = eIDx.EmployeeID;
            ViewBag.cIDx = eIDx.CompanyID;
            ViewBag.fName = eIDx.FirstName;
            ViewBag.lName = eIDx.LastName;

            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // Get the Users and their roles
        //-----------------------------------------------------------------------------------------------------------
        public ActionResult ManageUsers()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Emailconfirmed = user.EmailConfirmed,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_role_ViewModel()

                                  {
                                      UserID = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      EmailConfirmed = p.Emailconfirmed,
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
        public ActionResult ManageRoles()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }


        public ActionResult RoleDelete(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("ManageRoles");
        }        
        
        //
        // GET: /Roles/Edit/5
        public ActionResult RoleEdit(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleEdit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("ManageRoles");
            }
            catch
            {
                return View();
            }
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

            ViewBag.roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

            return View("AssignRole");
        }

        // -----------------------------------------------------------------------------------------------------------
        // UN-Assign users to roles
        // -----------------------------------------------------------------------------------------------------------
        public ActionResult UnAssignRole()
        {
            ViewBag.roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UnAssignRole(FormCollection form)
        {
            string usrname = form["txtUserName"];
            string rolename = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.RemoveFromRole(user.Id, rolename);

            ViewBag.roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

            return View("AssignRole");
        }
    }

}
