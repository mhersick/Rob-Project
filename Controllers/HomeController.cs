using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E3DBPI.Models;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace E3DBPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // get the Email Template that was passed and return the message body html
        //-----------------------------------------------------------------------------------------------------------
        public static async Task<string> EMailTemplatez(string template)                                                 // passed template name
        {
            var templateFilePath = HostingEnvironment.MapPath("~/Content/Templates/") + template + ".cshtml";           // build the template path
            StreamReader objstreamreaderfile = new StreamReader(templateFilePath);                                      // Open a stremreader and grab our template
            var body = await objstreamreaderfile.ReadToEndAsync();                                                      // wrap the template around our message
            objstreamreaderfile.Close();                                                                                // close the streamreader and release
            return body;                                                                                                // we are done
        }

        // View the email page
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendEmail()
        {
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // process the Email form when the submit button is pressed - test page
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // validate Captcha response
        //-----------------------------------------------------------------------------------------------------------
        //public static CaptchaResponse ValidateCaptcha()
        //{
            //var response = Request["g-recaptcha-response"];                                             // get the g-recaptcha response from the form
            //string secretKey = ConfigurationManager.AppSettings["e3GoogleReCaptchaDevl"];               // get email User from web.config
            //var client = new WebClient();
            //var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            //return JsonConvert.DeserializeObject<CaptchaResponse>(result.ToString());
        //}

        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success
            {
                get;
                set;
            }
            [JsonProperty("error-codes")]
            public List<string> ErrorMessage
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task <ActionResult> ContactSubmit(SendContactViewModel model)
        {
            ViewBag.Message = "";                                                                       // clear the message
            var saveEmail = model.Email;                                                                // Save entered form values
            var savefname = model.fname;
            var savelname = model.lname;
            var saveCompany = model.company;
            var savephone1 = model.phone1;
            var saveCategory = model.category;
            var saveMessage = model.comment;
            //-----------------------------------------------------------------------------------------------------------
            // Validate the ReCaptcha response
            //-----------------------------------------------------------------------------------------------------------
            var response = Request["g-recaptcha-response"];                                                                         // get the g-recaptcha response from the form
            //ValidateCaptcha(response);

            string secretKey = ConfigurationManager.AppSettings["e3GoogleReCaptchaDevl"];                                           // get email User from web.config
            var client = new WebClient();                                                                                           // create the web client
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response)); // get response
            var obj = JObject.Parse(result);                                                                                        // parse the result string to obj
            var status = (bool)obj.SelectToken("success");                                                                          // read the obj SelectToken message success/fail
            var capMessage = status ? "Your Message has been sent" : "Please check the 'Im not a robot' box";
            ViewBag.Message = capMessage;
            //if (capMessage == "Your Message has been sent")                                                                           // Ifi the user created successfully
                if (status == true)
            {

                //-----------------------------------------------------------------------------------------------------------
                // If all the required fields are filled and the ReCaptcha has succeeded, then process the Email
                //-----------------------------------------------------------------------------------------------------------
                var subject = "Your Message to DBPI";                                                                               // Set a Subject for the email. 
                var message = await MessagesController.EMailTemplate("ContactConfirm");                                              // get the Email template (body)
                message = message.Replace("@ViewBag.fname", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.fname));          // replace placeholder with entered value
                message = message.Replace("@ViewBag.lname", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.lname));          // replace placeholder with entered value
                message = message.Replace("@ViewBag.company", model.company);                                                       // replace placeholder with entered value
                message = message.Replace("@ViewBag.phone1", model.phone1);                                                         // replace placeholder with entered value
                message = message.Replace("@ViewBag.Email", model.Email);                                                           // replace placeholder with entered value
                message = message.Replace("@ViewBag.comment", model.comment);                                                       // replace placeholder with entered value


                await MessageServices.SendEmailAsync(model.Email, subject, message);                                                // Call MessageServices - Send Email to user 

                // remove comment to send message back to company
                //await MessageServices.SendEmailAsync(ConfigurationManager.AppSettings["e3EmailUser"], subject, message);            // Call MessageServices - Send Email to Company

                //-----------------------------------------------------------------------------------------------------------
                // Save the form data to the database - Put this in it's own class
                //-----------------------------------------------------------------------------------------------------------
                try
                {
                    SiteDBEntities db = new SiteDBEntities();

                    Contact msg = new Contact();
                    msg.Email = model.Email;
                    msg.FirstName = model.fname;
                    msg.LastName = model.lname;
                    msg.CompanyName = model.company;
                    msg.Phone = model.phone1;
                    msg.MessageText = model.comment;
                    msg.DateTime = DateTime.Now;
                    
                    db.Contacts.Add(msg);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                model.Email = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(saveEmail);
                model.fname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(savefname);                
            }
            //return View("ContactFormSent");                                                                                 // Display a ContactFormSent page
            return View("Contact");                                                                                           // Stay on page. Display message
        }

public ActionResult SaveComment(SendContactViewModel model)
        {
            try
            {               
               SiteDBEntities db = new SiteDBEntities();

                Contact msg = new Contact();
                msg.Email = model.Email;
                msg.FirstName = model.fname;
                msg.LastName = model.lname;
                msg.CompanyName = model.company;
                msg.Phone = model.phone1;
                msg.MessageText = model.comment;
                msg.DateTime = DateTime.Now;

                db.Contacts.Add(msg);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View("Contact");                                                                                           // Stay on page. Display message
            //return RedirectToAction("Contact");

        }

    }
}