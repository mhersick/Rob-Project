using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E3DBPI.Models;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.IO;
using Microsoft.AspNet.Identity;

namespace E3DBPI.Controllers
{
    public class MessagesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Messages
        public ActionResult Index(int? id)
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

            var cIDx = db.Companies.FirstOrDefault(e => e.CompanyID == eIDx.CompanyID);
            ViewBag.co_cName = cIDx.CompanyName + " - ";

            if (id == null)                                                     // nothing passed. Show full list
            {
                ViewBag.co_cName = "Admin - All ";
                var messages = db.Messages;
                return View(messages.ToList());
            }
            else
            {                                                              //  CompanyID passed. Show just this company
                var messages = db.Messages.Where(e => e.FromID == id);
                return View(messages.ToList());
            }

        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,FromID,ToID,ToEmail,ToFName,ToLName,ToCompany,MessageSubject,MessageText,MessageDate,ResponseDate,DBPImail,FromEmail,FromFName,FromLName,FromCompay,Deleted,DeleteDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,FromID,ToID,ToEmail,ToFName,ToLName,ToCompany,MessageSubject,MessageText,MessageDate,ResponseDate,DBPImail,FromEmail,FromFName,FromLName,FromCompay,Deleted,DeleteDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //-----------------------------------------------------------------------------------------------------------
        // Get the email template that is being called and send it back to the caller
        //-----------------------------------------------------------------------------------------------------------
        public static async Task<string> EMailTemplate(string template)                                                 // passed template name
        {
            var templateFilePath = HostingEnvironment.MapPath("~/Content/Templates/") + template + ".cshtml";           // build the template path
            StreamReader objstreamreaderfile = new StreamReader(templateFilePath);                                      // Open a stremreader and grab our template
            var body = await objstreamreaderfile.ReadToEndAsync();                                                      // wrap the template around our message
            objstreamreaderfile.Close();                                                                                // close the streamreader and release
            return body;                                                                                                // we are done
        }

    }
}
