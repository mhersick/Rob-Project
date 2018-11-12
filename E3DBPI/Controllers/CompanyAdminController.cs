using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using E3DBPI.Models;
using static E3DBPI.Controllers.ManageController;

namespace E3DBPI.Controllers
{

    [Authorize(Roles = "SuperAdmin, CompanyAdmin")]

    public class CompanyAdminController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public CompanyAdminController()
        {
        }

        public CompanyAdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //-----------------------------------------------------------------------------------------------------------
        // Open the CompanyAdmin home page.
        //-----------------------------------------------------------------------------------------------------------
        // GET: /CompanyAdmin/Index
        public ActionResult Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

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
            ViewBag.add1 = eIDx.Address1;
            ViewBag.add2 = eIDx.Address2;
            ViewBag.ci = eIDx.City;
            ViewBag.st = eIDx.State;
            ViewBag.zi = eIDx.Zip;
            ViewBag.co = eIDx.Country;
            ViewBag.ph = eIDx.Phone1;
            ViewBag.em = eIDx.Email1;

            var cIDx = db.Companies.FirstOrDefault(e => e.CompanyID == eIDx.CompanyID);
            //ViewBag.cIDx = cIDx;
            ViewBag.co_cName = cIDx.CompanyName;
            ViewBag.co_add1 = cIDx.Address1;
            ViewBag.co_add2 = cIDx.Address2;
            ViewBag.co_ci = cIDx.City;
            ViewBag.co_st = cIDx.State;
            ViewBag.co_zi = cIDx.Zip;
            ViewBag.co_co = cIDx.Country;
            ViewBag.co_ph = cIDx.Phone1;
            ViewBag.co_em = cIDx.Email1;
            ViewBag.co_SL = cIDx.ServiceLevel;


            //return RedirectToAction("Index");
            return View();
        }

    }
}