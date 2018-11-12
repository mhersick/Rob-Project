using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E3DBPI.Models;
using Microsoft.AspNet.Identity;

namespace E3DBPI.Controllers
{
    public class DocumentsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Documents
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
                ViewBag.co_cName = "Administrators Only! - All ";
                var documents = db.Documents.Include(e => e.Company);
                return View(documents.ToList());
            }
            else
            {                                                              //  CompanyID passed. Show just this company
                var documents = db.Documents.Where(e => e.CompanyID == id);
                return View(documents.ToList());
            }
            //var documents = db.Documents.Include(d => d.SubProject);
            //return View(documents.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            //Extract Image File Name.
            string fileName = System.IO.Path.GetFileName(postedFile.FileName);

            //Set the Image File Path.
            string filePath = "~/Uploads/" + fileName;

            //Save the Image File in Folder.
            postedFile.SaveAs(Server.MapPath(filePath));

            //Insert the Image File details in Table.

            SiteDBEntities entities = new SiteDBEntities();
            entities.Documents.Add(new Document
            {
                DocumentTitle = fileName,
                Location = filePath
            });
            entities.SaveChanges();
            


            //if (ModelState.IsValid)
            //{
            //    db.Documents.Add(document);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}




            //FilesEntities entities = new FilesEntities();
            //entities.Files.Add(new File
            //{
            //    DocumentTitle = fileName,
            //    DocumentText = DocumentText,
            //    Path = filePath
            //});
            //entities.SaveChanges();

            //Redirect to Index Action.
            return RedirectToAction("Index");
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            ViewBag.SubProjectID = new SelectList(db.SubProjects, "SubProjectID", "SubProjectName");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentID,CompanyID,SubProjectID,DocumentTitle,DocumentText,Active")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubProjectID = new SelectList(db.SubProjects, "SubProjectID", "SubProjectName", document.SubProjectID);
            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubProjectID = new SelectList(db.SubProjects, "SubProjectID", "SubProjectName", document.SubProjectID);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentID,SubProjectID,DocumentTitle,DocumentText,Active")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubProjectID = new SelectList(db.SubProjects, "SubProjectID", "SubProjectName", document.SubProjectID);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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

        // GET: Home
        //public ActionResult UploadDocument()
        //{
        //    FilesEntities entities = new FilesEntities();
        //    return View(entities.Files.ToList());
        //}

        //[HttpPost]
        //public ActionResult UploadDocument(HttpPostedFileBase postedFile)
        //{
        //    //Extract Image File Name.
        //    string fileName = System.IO.Path.GetFileName(postedFile.FileName);

        //    //Set the Image File Path.
        //    string filePath = "~/Uploads/" + fileName;

        //    //Save the Image File in Folder.
        //    postedFile.SaveAs(Server.MapPath(filePath));

        //    //Insert the Image File details in Table.
        //    FilesEntities entities = new FilesEntities();
        //    entities.Files.Add(new File
        //    {
        //        Name = fileName,
        //        Path = filePath
        //    });
        //    entities.SaveChanges();

        //    //Redirect to Index Action.
        //    return RedirectToAction("Index");
        //}

    }
}
