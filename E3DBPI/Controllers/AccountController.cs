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
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace E3DBPI.Controllers
{
    [Authorize]
    //-----------------------------------------------------------------------------------------------------------
    // The Account Model Controller.  All user account related activities are here.
    //-----------------------------------------------------------------------------------------------------------
    public class AccountController : Controller
    {
        RegisterSummaryViewModel newuser = new RegisterSummaryViewModel();

        public AccountController()
        {
            ViewBag.ServiceLevel = "Standard";                                          // Set default value
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


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

        //-----------------------------------------------------------------------------------------------------------
        // GET: /Account/Login
        //-----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
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

        //-----------------------------------------------------------------------------------------------------------
        // Verify Code - 
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // New User / Employee / Company Registration: views/Account/Register
        // Collect Username, Email and password from screen and create a new AspNetUser record in the identity db
        // Generate a userid / token pair and send an Email to the Email address entered by the user with a link so they can confirm that email address as their own
        // The new user will not be able to log into their account until they complete the email confirmation process.
        //-----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------
        // Process the page on user submit
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Session["Company"] = model.CompanyName;                                                         // save the form values for other classes
                Session["Fname"] = model.FirstName;
                Session["Lname"] = model.LastName;
                Session["Email1"] = model.Email;
                Session["Phone1"] = model.Phone1;
                Session["Uname"] = model.UserName;

                // CREATE THE ASPNETUSER ACCOUNT RECORD
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };              // get the form values
                var result = await UserManager.CreateAsync(user, model.Password);                               // call the UserManager and create the user
                if (result.Succeeded)                                                                           // If the user created successfully
                {

                    //Session["inemail"] = model.Email;
                    //Session["username"] = model.UserName;

                    // OPTIONAL Add user to default Role
                    //var RoleName = "CompanyAdmin";                                                                      // Default role for testing       
                    //result = await UserManager.AddToRoleAsync(user.Id, RoleName);                                     // call the UserManager and add this user to a Role

                    // OPTIONAL Sign the user into their account right now - NO, NOT IN THIS APP.  
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);               // Sign the user into the new account.

                    // OPTIONAL There is a generic INFO view out there that you can easily display messsages in - NO, NOT IN THIS APP.  
                    //ViewBag.Message = "Please check your Email and find the message we just sent you.  You must confirm this Email address before you can log in. Thank You!";
                    //return View("Info");                                                                              // This is a generic display page 

                    // Uncomment next line to debug locally
                    // TempData["ViewBagLink"] = callbackUrl;

                    //-----------------------------------------------------------------------------------------------------------
                    // Send an email with this link
                    //-----------------------------------------------------------------------------------------------------------
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Please Confirm your account");    // set the helper routine, passing the userID and Email Subject

                    return View("RegisterServiceLevel");                                                                // Present the Service Level selection page
              }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //-----------------------------------------------------------------------------------------------------------
        // this routine is called when a user selects a service plan in the RegisterServiceLevel View page
        // we need to take this value and update the customer record with the plan they have selected here, plus the CustomerID from earlier must be updated also
        //-----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult RegisterServiceLevel()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------
        // Process the users service level selection 
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterServiceLevel(string ServiceLevel)
        {
            if (ModelState.IsValid && !String.IsNullOrWhiteSpace(ServiceLevel))
            {
                var baseprice = double.Parse("0");
                var annprice = double.Parse("0");
                switch (ServiceLevel)                           // If you had to do custom processing based on the selected plan, this is how you do it. Doing via Jquery
                {
                    case "Standard":
                        baseprice = 0;
                        annprice = 0;
                        break;
                    case "Premium":
                        baseprice = 399.00;
                        annprice = 0;
                        break;
                    case "Professional":
                        baseprice = 799.00;
                        annprice = 0;
                        break;
                    case "Ultimate":
                        baseprice = 1299.00;
                        annprice = 0;
                        break;
                    case "UltimatePro":
                        baseprice = 1999.00;
                        annprice = 0;
                        break;
                    default:
                        baseprice = 0;
                        annprice = 0;
                        break;
                }
            }

            Session["ServiceLevel"] = ServiceLevel;                         // get the EmployeeID from the record we just created
            ViewBag.Uname = Session["Uname"].ToString();                    // set the front end vars
            ViewBag.Fname = Session["Fname"].ToString();
            ViewBag.Lname = Session["Lname"].ToString();
            ViewBag.Email1 = Session["Email1"].ToString();
            ViewBag.Phone1 = Session["Phone1"].ToString();
            ViewBag.Company = Session["Company"].ToString();
            ViewBag.ServiceLevel = Session["ServiceLevel"].ToString();

            return View("RegisterSummary");                                 //  Present the Register Summary page to the user
                    }




        //-----------------------------------------------------------------------------------------------------------
        // Display the Registration Summary
        //-----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult RegisterSummary()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------
        // The user has elected to proceed with there selections and has checked the "agree to terms" box.
        // Their membership account has been created. Here we will create their Employee and Company records in the database
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterSummary(RegisterSummaryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            //return View("RegisterCreateAccount");                                 //  Present the Register Summary page to the user



            if (ModelState.IsValid)
            {
                //-----------------------------------------------------------------------------------------------------------
                // Create a new Company Record for the Account Creator
                //-----------------------------------------------------------------------------------------------------------
                try
                {
                    SiteDBEntities dbc = new SiteDBEntities();              // create an instance of the database
                    Company cfields = new Company();                        // connect to the Company table
                    cfields.CompanyName = Session["Company"].ToString();                // set the field values to the data from the form model
                    cfields.UserName = Session["Uname"].ToString();                       // set the field values to the data from the form model
                    cfields.Phone1 = Session["Phone1"].ToString();                          // set the field values to the data from the form model
                    cfields.Email1 = Session["Email1"].ToString();                           // set the field values to the data from the form model
                    cfields.CreateDate = DateTime.Now;                      // set the field values to the data from the form model
                    cfields.ServiceLevel = Session["ServiceLevel"].ToString();              // set the field values to the data from the form model
                    cfields.BillingCycle = DateTime.Now.Day;
                    dbc.Companies.Add(cfields);                             // Create the Company record
                    dbc.SaveChanges();                                      // Commit the record to the database                                                                            //int CID = cfields.CompanyID;                          // get the CompanyID from the record we just created
                    Session["NewCID"] = cfields.CompanyID;                  // get the CompanyID from the record we just created - save to session

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving Company record. Contact system administrator.");
                    throw ex;                                               // Failed to write record
                                                                            //Log the error (uncomment dex variable name and add a line here to write a log.
                }
                //-----------------------------------------------------------------------------------------------------------
                // Create a new individual Employee Record for the Account Creator
                //-----------------------------------------------------------------------------------------------------------
                try
                {
                    SiteDBEntities dbe = new SiteDBEntities();                      // create an instance of the database
                    int NewCIDy = Int32.Parse(Session["NewCID"].ToString());        // get the new CompanyID from session (string) and convert to integer
                    Employee efields = new Employee();                              // Connect to the Employee table
                    efields.UserName = Session["Uname"].ToString();                              // get the user name from above                                                                                    //msg.UserID = test;
                    efields.FirstName = Session["Fname"].ToString();                            // get first name from the form
                    efields.LastName = Session["Lname"].ToString();                              // get last name from the form
                    efields.Email1 = Session["Email1"].ToString();                                   // get the email address from above
                    efields.Phone1 = Session["Phone1"].ToString();                                  // get the phone nuumber from the form
                    efields.CompanyID = NewCIDy;                                    // get the ID from the last created Company
                    efields.CreateDate = DateTime.Now;                              // set the create date to current time
                    efields.CompanyCreator = true;                                  // Indicate that this user/employee created the attached company record
                    dbe.Employees.Add(efields);
                    dbe.SaveChanges();
                    Session["NewEID"] = efields.EmployeeID;                         // get the EmployeeID from the record we just created

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving Employee record. Contact system administrator.");
                    throw ex;
                    //Log the error (uncomment dex variable name and add a line here to write a log.

                }
            }

            //-----------------------------------------------------------------------------------------------------------
            //  We go back into the Company record and add the EmployeeID for this user earlier (who created the account)
            //-----------------------------------------------------------------------------------------------------------
            SiteDBEntities dbc2 = new SiteDBEntities();

            int NewEIDX = Int32.Parse(Session["NewEID"].ToString());                             // get the new employee ID and convert to integer
            int NewCIDX = Int32.Parse(Session["NewCID"].ToString());        // get the new CompanyID from session (string) and convert to integer
            int EmployeeID = Int32.Parse(Session["NewEID"].ToString());                             // get the new employee ID and convert to integer



            var companytoupdate = dbc2.Companies.Find(NewCIDX);                                 // point to the correct CompanyID record

            companytoupdate.EmployeeID = NewEIDX;
            

            if (TryUpdateModel(companytoupdate, "", new string[] { "NewEIDX" }))           // test for a valid update string
            {
                try
                {
                    dbc2.Entry(companytoupdate).State = EntityState.Modified;                   // modify the record
                    dbc2.SaveChanges();                                                         // save the change
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                // we have our database records done, so we can send the email out and then send them to the confirmEmailSent page
            }               // end TryUpdateModel

            return View("ConfirmEmailSent");                                                                // Send the User to a page telling them what to do next.
            //return View("RegisterCreateAccount");                                                                // Send the User to a page telling them what to do next.

        }



        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmailSent()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Send an email with this link
            //-----------------------------------------------------------------------------------------------------------
            var user = await UserManager.FindByNameAsync(Session["Email1"].ToString());
            string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Please confirm your account");    // set the helper routine, passing the userID and Email Subject


            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult>RegisterCreateAccount(RegisterViewModel model)
        {

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };              // get the form values
            var result = await UserManager.CreateAsync(user, model.Password);                               // call the UserManager and create the user

            //-----------------------------------------------------------------------------------------------------------
            // Send an email with this link
            //-----------------------------------------------------------------------------------------------------------
            //string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");    // set the helper routine, passing the userID and Email Subject


            if (!ModelState.IsValid)
            {
                return View();
            }

            //if (ModelState.IsValid) 
            //{
            //-----------------------------------------------------------------------------------------------------------
            // Create a new Company Record for the Account Creator
            //-----------------------------------------------------------------------------------------------------------
            try
            {
                SiteDBEntities dbc = new SiteDBEntities();              // create an instance of the database
                Company cfields = new Company();                        // connect to the Company table
                cfields.CompanyName = Session["Company"].ToString();                // set the field values to the data from the form model
                cfields.UserName = Session["Uname"].ToString();                       // set the field values to the data from the form model
                cfields.Phone1 = Session["Phone1"].ToString();                          // set the field values to the data from the form model
                cfields.Email1 = Session["Email1"].ToString();                           // set the field values to the data from the form model
                cfields.CreateDate = DateTime.Now;                      // set the field values to the data from the form model
                cfields.ServiceLevel = Session["ServiceLevel"].ToString();              // set the field values to the data from the form model
                cfields.BillingCycle = DateTime.Now.Day;
                dbc.Companies.Add(cfields);                             // Create the Company record
                dbc.SaveChanges();                                      // Commit the record to the database                                                                            //int CID = cfields.CompanyID;                          // get the CompanyID from the record we just created
                Session["NewCID"] = cfields.CompanyID;                  // get the CompanyID from the record we just created - save to session

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save Company Record. Contact the system administrator.");
                throw ex;                                               // Failed to write record
            }
            //-----------------------------------------------------------------------------------------------------------
            // Create a new individual Employee Record for the Account Creator
            //-----------------------------------------------------------------------------------------------------------
            try
            {
                SiteDBEntities dbe = new SiteDBEntities();                      // create an instance of the database
                int NewCIDX = Int32.Parse(Session["NewCID"].ToString());        // get the new CompanyID from session (string) and convert to integer
                Employee efields = new Employee();                              // Connect to the Employee table
                efields.UserName = Session["Uname"].ToString();                              // get the user name from above                                                                                    //msg.UserID = test;
                efields.FirstName = Session["Fname"].ToString();                            // get first name from the form
                efields.LastName = Session["Lname"].ToString();                              // get last name from the form
                efields.Email1 = Session["Email1"].ToString();                                   // get the email address from above
                efields.Phone1 = Session["Phone1"].ToString();                                  // get the phone nuumber from the form
                efields.CompanyID = NewCIDX;                                    // get the ID from the last created Company
                efields.CreateDate = DateTime.Now;                              // set the create date to current time
                efields.CompanyCreator = true;                                  // Indicate that this user/employee created the attached company record
                dbe.Employees.Add(efields);
                dbe.SaveChanges();
                Session["NewEID"] = efields.EmployeeID;                         // get the EmployeeID from the record we just created

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save Company Record. Contact the system administrator.");
                throw ex;
            }


            //-----------------------------------------------------------------------------------------------------------
            //  We go back into the Company record and add the EmployeeID for this user earlier (who created the account)
            //-----------------------------------------------------------------------------------------------------------
            SiteDBEntities dbc2 = new SiteDBEntities();

            int NewEIDX = Int32.Parse(Session["NewEID"].ToString());                             // get the new employee ID and convert to integer
            int NewCIDY = Int32.Parse(Session["NewCID"].ToString());        // get the new CompanyID from session (string) and convert to integer

            var companytoupdate = dbc2.Companies.Find(NewCIDY);                                 // point to the correct CompanyID record
            if (TryUpdateModel(companytoupdate, "", new string[] { "NewEIDX" }))           // test for a valid update string
            {
                try
                {
                    dbc2.Entry(companytoupdate).State = EntityState.Modified;                   // modify the record
                    dbc2.SaveChanges();                                                         // save the change
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                // we have our database records done, so we can send the email out and then send them to the confirmEmailSent page

            }

                return View("ConfirmEmailSent");                                                                // Send the User to a page telling them what to do next.

        }



        //-----------------------------------------------------------------------------------------------------------
        // New Employee Registration: views/Account/RegisterEmployee
        // This class is used to create a new Membership/Identity record for an Employee that has been added to the system by a Company
        // Collect Username, Email and password from screen and create a new AspNetUser record in the identity db
        // 
        // The new user will not be able to log into their account until they complete the email confirmation process.
        //-----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult RegisterEmployee()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------
        // Process the page on user submit
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterEmployee(RegisterEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Session["EmployeeID"] = "";                                      // this value is passed to the RegisterEmployee view
                Session["Uname"] = model.UserName;                              // save the entered UserName. We have to update the Employee record with this value

                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };              // get the form values
                var result = await UserManager.CreateAsync(user, model.Password);                               // call the UserManager and create the user
                if (result.Succeeded)                                                                           // Ifi the user created successfully
                {

                    // OPTIONAL Add user to default Role
                    var RoleName = "Employee";                                                                  // Default role for testing       
                    result = await UserManager.AddToRoleAsync(user.Id, RoleName);                               // call the UserManager and add this user to a Role

                    // OPTIONAL Sign the user into their account right now - NO, NOT IN THIS APP.  
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);       // Sign the user into the new account.

                    // Uncomment next line to debug locally
                    // TempData["ViewBagLink"] = callbackUrl;

                    //-----------------------------------------------------------------------------------------------------------
                    // Send an email to the company letting them know their new employee has registered
                    // Send an email to the user thanking them for registering
                    //-----------------------------------------------------------------------------------------------------------
                    //string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");    // set the helper routine, passing the userID and Email Subject


                    //-----------------------------------------------------------------------------------------------------------
                    // Update the Employee record - Add their UserName to the Employee record that was created by the Company
                    //-----------------------------------------------------------------------------------------------------------
                    SiteDBEntities dbc2 = new SiteDBEntities();

                    int NewEID = Int32.Parse(Session["EmployeeID"].ToString());                             // get the new employee ID and convert to integer
                    var UserName = Session["Uname"].ToString();                             // get the new employee ID and convert to integer

                    var employeetoupdate = dbc2.Employees.Find(NewEID);                                 // point to the correct CompanyID record
                    if (TryUpdateModel(employeetoupdate, "", new string[] { "UserName" }))           // test for a valid update string
                    {
                        try
                        {
                            dbc2.Entry(employeetoupdate).State = EntityState.Modified;                   // modify the record
                            dbc2.SaveChanges();                                                         // save the change
                        }
                        catch (RetryLimitExceededException /* dex */)
                        {
                            //Log the error (uncomment dex variable name and add a line here to write a log.
                            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                        }
                        // we have our database records done, so we can send the email out and then send them to the confirmEmailSent page

                        return RedirectToAction("Index", "Home");                                                         // we should never get here. Send the user to the home page                                                                                                                       //return View("ConfirmEmailSent");                                             // The record updated properly.
                    }               // end TryUpdateModel


                    return View();                                                                // Present the Service Level selection page
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }









        //-----------------------------------------------------------------------------------------------------------
        // The link that is sent in the email address comfirmation email to the new users returns to this point.
        // we are comparing the userID and code in the Email that was sent against the actual user account.
        //-----------------------------------------------------------------------------------------------------------
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);                                 // call the confirm code in the UserManager
            return View(result.Succeeded ? "ConfirmEmail" : "Error");                                       // return the name of the page the user should be routed to. Good or not good
        }

        //-----------------------------------------------------------------------------------------------------------
        // On the Login page, there is a link to Forgot Password?  That what this is.
        //-----------------------------------------------------------------------------------------------------------
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }
                //-----------------------------------------------------------------------------------------------------------
                // Send an email with this link
                //-----------------------------------------------------------------------------------------------------------

                //var user = await UserManager.FindByNameAsync(Session["Email1"].ToString());
                string callbackUrlz = await SendPWresetTokenAsync(user.Id, "Reset your DBPI Password");    // set the helper routine, passing the userID and Email Subject


                //string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                //// Grab the Email template
                //var message = await MessagesController.EMailTemplate("ResetPasswordEmail");                                         // Bring in the desired Template                                                                                                                                                      //message = message.Replace("@ViewBag.fname", CultureInfo.CurrentCulture.TextInfo.ToTitleCase("HowdyDuty"));          // replace placeholder with Users First Name
                //message = message.Replace("@ViewBag.Token", callbackUrl);                                                           // replace placeholder with entered value
                //message = message.Replace("@ViewBag.ShowUrl", callbackUrl);                                                         // replace placeholder with entered value

                //await UserManager.SendEmailAsync(user.Id, "Reset your DBPI Password", message);                                 // Call the Email sending in identifyConfig.cs

                ////await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        //public async Task<ActionResult> ForgotPasswordConfirmation()
        public ActionResult ForgotPasswordConfirmation()
        {
            //var user = await UserManager.FindByNameAsync(Session["Email1"].ToString());
            //string callbackUrlz = await SendPWresetTokenAsync(user.Id, "Reset your DBPI Password");    // set the helper routine, passing the userID and Email Subject
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // This is the code to reset a users Password
        //-----------------------------------------------------------------------------------------------------------
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
            var user = await UserManager.FindByEmailAsync(model.Email);
            //Response.Write(user.Id);

            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);             // change the password
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

        //-----------------------------------------------------------------------------------------------------------
        // This is the code that will be called if you want users to be able to login using Facebook, Google...  NOT USED NOW
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // This is the code for 2-Factor Email Authorization 
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        //This is the code that will be called when logging in using Facebook, Google to login. NOT USED NOW        
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // This gets called anytime a user hits the logoff button
        //-----------------------------------------------------------------------------------------------------------
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //-----------------------------------------------------------------------------------------------------------
        //This is the code that will be called if there is an error when using Facebook, Google to login. NOT USED NOW        
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // This routine is called after a new user is created to generate an authorization token that will be emailed to the new user to confirm their Email address
        //-----------------------------------------------------------------------------------------------------------
        private async Task<string> SendPWresetTokenAsync(string userID, string subject)
        {
            //string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);                                        // generate the token
            string code = await UserManager.GeneratePasswordResetTokenAsync(userID);

            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = userID, code = code }, protocol: Request.Url.Scheme);   // pass the userid and the token code   

            var message = await MessagesController.EMailTemplate("ResetPasswordEmail");                                                                  // Bring in the desired Template
            message = message.Replace("@ViewBag.Token", callbackUrl);                                                           // replace placeholder with entered value
            message = message.Replace("@ViewBag.ShowUrl", callbackUrl);                                                         // replace placeholder with entered value

            await UserManager.SendEmailAsync(userID, "Reset your DBPI Password", message);                                 // Call the Email sending in identifyConfig.cs
            //await UserManager.SendEmailAsync(user.Id, "Reset your DBPI Password", message);                                 // Call the Email sending in identifyConfig.cs
            //await UserManager.SendEmailAsync(userID, "Confirm your DBPI account Email Address",                                 // Call the Email sending in identifyConfig.cs
                                                                                                                                //"Please confirm your account by clicking <a href=\""  + callbackUrl + "\">here</a>");                         // This will send a text based HTML message
           // message);                                                                                                           // This will send the EmailTemplate message

            return callbackUrl;
        }
        //-----------------------------------------------------------------------------------------------------------
        // This routine is called after a new user is created to generate an authorization token that will be emailed to the new user to confirm their Email address
        //-----------------------------------------------------------------------------------------------------------
        private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject)
        {
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);                                        // generate the token

            var callbackUrl = Url.Action("ConfirmEmail", "Account",                                                             // set the return page
               new { userId = userID, code = code }, protocol: Request.Url.Scheme);                                             // pass the userid and the token code   

            var message = await MessagesController.EMailTemplate("WelcomeEmail");                                                                  // Bring in the desired Template
            //message = message.Replace("@ViewBag.fname", CultureInfo.CurrentCulture.TextInfo.ToTitleCase("HowdyDuty"));          // replace placeholder with Users First Name
            message = message.Replace("@ViewBag.Token", callbackUrl);                                                           // replace placeholder with entered value
            message = message.Replace("@ViewBag.ShowUrl", callbackUrl);                                                         // replace placeholder with entered value

            await UserManager.SendEmailAsync(userID, "Please confirm your Contraxtor account Email Address",                                 // Call the Email sending in identifyConfig.cs
                //"Please confirm your account by clicking <a href=\""  + callbackUrl + "\">here</a>");                         // This will send a text based HTML message
            message);                                                                                                           // This will send the EmailTemplate message

            return callbackUrl;
        }

        #endregion


    }
}