using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace E3DBPI.Controllers
{
    public class RecaptchaController : Controller
    {
        // GET: Recaptcha
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormSubmit()
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = ConfigurationManager.AppSettings["e3GoogleReCaptchaDevl"];               // get email User from web.config
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";

            return View("Index");

        }

    }
}