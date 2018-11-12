using E3DBPI.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Hosting;
using System.IO;

namespace E3DBPI.Controllers
{
    [Authorize]
    //-----------------------------------------------------------------------------------------------------------
    // The Account Model Controller.  All user account related activities are here.
    //-----------------------------------------------------------------------------------------------------------
    public class AccountController : Controller
    {
        public AccountController()
        {
            ViewBag.ServiceLevel = "Standard";
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        //-----------------------------------------------------------------------------------------------------------
        // Get the email template that is being called and send it back to the caller - Moed to MessagesController
        //-----------------------------------------------------------------------------------------------------------
        //public static async Task<string> EMailTemplate(string template)                                                 // passed template name
        //{
        //    var templateFilePath = HostingEnvironment.MapPath("~/Content/Templates/") + template + ".cshtml";           // build the template path
        //    StreamReader objstreamreaderfile = new StreamReader(templateFilePath);                                      // Open a stremreader and grab our template
        //    var body = await objstreamreaderfile.ReadToEndAsync();                                                      // wrap the template around our message
        //    objstreamreaderfile.Close();                                                                                // close the streamreader and release
        //    return body;                                                                                                // we are done
        //}

        // View the test email page
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendEmail()
        {
            return View();
        }

        // process the Email form when the submit button is pressed
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SendEmail(SendEmailViewModel model)
        {
            var subject = "Important Message from DBPI";                                                                        // Set a Subject for the email. 
            var message = await MessagesController.EMailTemplate("WelcomeEmail");                                                                  // point to the template
            message = message.Replace("@ViewBag.fname", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.fname));          // replace placeholder with entered value
            await MessageServices.SendEmailAsync(model.Email, subject, message);                                                // Call MessageServices 
            return View("EmailSent");                                                                                           // If we came back, its a good send. Show EmailSent page.
        }


        // After the Email is sent in SendEmail class, come here
        [HttpGet]
        [AllowAnonymous]
        public ActionResult EmailSent()
        {
            return View();
        }

        static class Globals
        {
            public const String inemail = "";
            public const String infname = "";
            public const String inlname = "";
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

        //
        //-----------------------------------------------------------------------------------------------------------
        // GET: /Account/Login
        //-----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        //-----------------------------------------------------------------------------------------------------------
        // POST: /Account/Login
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account-Resend");

                    ViewBag.errorMessage = "You must have a confirmed Email Address to log on.  The confirmation token has been resent to your email account.";
                    return View("Error");
                }
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //---------------------------------------------------------------------
        // GET: /Account/Register
        //---------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //---------------------------------------------------------------------
        // New User / Employee / Company Registration: views/Account/Register
        // Collect Username, Email and password from screen and create a new AspNetUser record in the identity db
        // Generate a userid / token pair and send an Email to the Email address entered by the user with a link so they can confirm that email address as their own
        // The new user will not be able to log into their account until they complete the email confirmation process.
        //---------------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };              // get the form values
                var result = await UserManager.CreateAsync(user, model.Password);                               // call the UserManager and create the user
                if (result.Succeeded)                                                                           // Ifi the user created successfully
                {
                    var caca = User.Identity;
                    Session["inemail"] = model.Email;
                    Session["username"] = model.UserName;
                    // OPTIONAL FEATURES
                    var RoleName = "CompanyAdmin";                                                                    // Default role for testing       
                    result = await UserManager.AddToRoleAsync(user.Id, RoleName);                             // call the UserManager and add this user to a Role

                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);       // Sign the user into the new account.
                    //-----------------------------------------------------------------------------------------------------------
                    // Send an email with this link
                    //-----------------------------------------------------------------------------------------------------------
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");    // set the helper routine, passing the userID and Email Subject

                    //ViewBag.Message = "Please check your Email and find the message we just sent you.  You must confirm this Email address before you can log in. Thank You!";
                    //return View("ConfirmEmailSent");                                                                // Send the User to a page telling them what to do next.
                    return View("RegisterStep2");                                                                // Send the User to the next Step.
                    //return View("Info");                                                                          // This is a generic display page 
                    //return RedirectToAction("ConfirmEmailSent", "Account");
                    //return RedirectToAction("RegisterStep2", "Account");

                    // Uncomment next line to debug locally
                    // TempData["ViewBagLink"] = callbackUrl;
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStep2(RegisterStep2ViewModel model)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Create a new Company Record for the Account Creator
            //-----------------------------------------------------------------------------------------------------------
            try
            {
                SiteDBEntities dbc = new SiteDBEntities();
                Company cfields = new Company();
                cfields.CompanyName = model.CompanyName;
                cfields.Phone1 = model.Phone1;
                cfields.Email1 = Session["inemail"].ToString();
                cfields.CreateDate = DateTime.Now;

                dbc.Companies.Add(cfields);
                dbc.SaveChanges();
                //int CID = msg.CompanyID;                         // get the CompanyID from the record we just created
                Session["NewCID"] = cfields.CompanyID;                 // get the CompanyID from the record we just created
            }
            catch (Exception ex)
            {
                throw ex;                                       // Failed to write record
            }
            //-----------------------------------------------------------------------------------------------------------
            // Create an individual Employee Record for the Account Creator
            //-----------------------------------------------------------------------------------------------------------
            try
            {
                //Guid test = Guid.Parse(User.Identity.GetUserId());
                SiteDBEntities dbe = new SiteDBEntities();
                int NewCIDX = Int32.Parse(Session["NewCID"].ToString());        // get the new company ID and convert to integer
                //var caca = User.Identity.GetUserId();

                Employee efields = new Employee();                                  // set up the fields we're going to write to the employee table
                efields.UserName = Session["username"].ToString();
                //msg.UserID = test;
                efields.FirstName = model.FirstName;
                efields.LastName = model.LastName;
                efields.Email1 = Session["inemail"].ToString();
                efields.Phone1 = model.Phone1;
                efields.CompanyID = NewCIDX;                                         // get the ID from the last created Company
                efields.CreateDate = DateTime.Now;

                dbe.Employees.Add(efields);
                dbe.SaveChanges();
                Session["NewUID"] = efields.UserID;                 // get the EmployeeID from the record we just created

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //-----------------------------------------------------------------------------------------------------------
            // Update the Company record we just created with the "EmployeeID" of this newly created employee record
            //-----------------------------------------------------------------------------------------------------------
            //SiteDBEntities dbc2 = new SiteDBEntities();
            //int NewEID = Int32.Parse(Session["NewEID"].ToString());        // get the new company ID and convert to integer
            //Company efields2 = new Company();
            //efields2.EmployeeID = NewEID;
            //dbc2.Companies.;
            //dbc2.Companies.


            //return View("index");                                                                // Send the User to a page telling them what to do next.
            //return View("ConfirmEmailSent");                                                                // Send the User to a page telling them what to do next.
            //return RedirectToAction("Index", "Home");
            return View("RegisterServiceLevel");                                                                // Send the User to the next Step.


            // If we got this far, something failed, redisplay form
            //return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetServiceLevel([Bind(Include = "CompanyID,CompanyName")] Company company, string answer)
        //public ActionResult Level0([Bind(Include = "CompanyID, CompanyName")] Company company)
        {
            //SiteDBEntities dbc2 = new SiteDBEntities();
            if (ModelState.IsValid)
            {
                company.ServiceLevel = "Standard";
                ViewBag.ServiceLevel = 0;
                //Company.SaveChanges();
                //return RedirectToAction("Index");
                
            }
            //return RedirectToAction("Index", "Home");
            return View("ConfirmEmailSent");                                                                // Send the User to a page telling them what to do next.

        }

        protected void Submit0_Click(Object sender, ErrorEventArgs e)
        {
            ViewBag.ServiceLevel = 0;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "EmployeeID")] Company company)
        //{
        //    SiteDBEntities dbc2 = new SiteDBEntities();
        //    if (ModelState.IsValid)
        //    {
        //        dbc2.comp = EntityState.Modified;
        //        dbc2.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index", "Home");

        //}





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SetServiceLevel([Bind(Include = "CompanyID,CompanyName")] Company company, string answer)
        //{
        //    if (ModelState.IsValid && !String.IsNullOrWhiteSpace(answer))
        //    {
        //        switch (answer)
        //        {
        //            case "standard":
        //                //Company = DateTime.Now;
        //                company.ServiceLevel = "Standard";
        //                break;
        //            case "premium":
        //                company.ServiceLevel = "Premium";
        //                break;
        //            case "professional":
        //                company.ServiceLevel = "Professional";
        //                break;
        //            case "ultimatepro":
        //                company.ServiceLevel = "Ultimate Pro";
        //                break;
        //            default:
        //                company.ServiceLevel = "Deferred";
        //                break;
        //        }

        //        // Code to save the values for user.Username and user.AcceptedOn to permanent storage could go here.
        //    }
        //    return View(user);
        //}









        //---------------------------------------------------------------------
        // GET: /Account/RegisterServiceLevel
        //---------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult RegisterServiceLevel()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterServiceLevel(RegisterServiceLevelViewModel model)
        {


            return View();
        }

        public ActionResult Details(int txtId)
        {
            ///you can use int txtId  here 
            return View();

        }







        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);                                     // 
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";
        //private int CID;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

// This routine is called after a new user is created to generate an authorization token that will be emailed to the new user to confirm their Email address
        private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject)
        {
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);                                        // generate the token

            var callbackUrl = Url.Action("ConfirmEmail", "Account",                                                             // set the return page
               new { userId = userID, code = code }, protocol: Request.Url.Scheme);                                             // pass the userid and the token code   

            var message = await MessagesController.EMailTemplate("WelcomeEmail");                                                                  // Bring in the desired Template
            //message = message.Replace("@ViewBag.fname", CultureInfo.CurrentCulture.TextInfo.ToTitleCase("HowdyDuty"));          // replace placeholder with Users First Name
            message = message.Replace("@ViewBag.Token", callbackUrl);                                                           // replace placeholder with entered value
            message = message.Replace("@ViewBag.ShowUrl", callbackUrl);                                                         // replace placeholder with entered value

            await UserManager.SendEmailAsync(userID, "Confirm your DBPI account Email Address",                                 // Call the Email sending in identifyConfig.cs
                //"Please confirm your account by clicking <a href=\""  + callbackUrl + "\">here</a>");                         // This will send a text based HTML message
            message);                                                                                                           // This will send the EmailTemplate message

            return callbackUrl;
        }
        #endregion


    }
}