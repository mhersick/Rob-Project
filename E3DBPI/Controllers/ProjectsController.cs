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
    public class ProjectsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Projects
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
                //ViewBag.cIDx = cIDx;
                ViewBag.co_cName = cIDx.CompanyName + " - ";

            Session["NewEID"] = eIDx;                  // get the CompanyID from the record we just created - save to session
            Session["NewCID"] = cIDx;                  // get the CompanyID from the record we just created - save to session

            if (id == null)                                                     // nothing passed. Show full list
            {
                ViewBag.co_cName = "Admin - All ";
                var projects = db.Projects.Include(e => e.Company);
                return View(projects.ToList());
            }
            else
            {                                                              //  CompanyID passed. Show just this company
                                                                           //Company company = db.Companies.Find(id);
                var projects = db.Projects.Where(e => e.CompanyID == id);
                return View(projects.ToList());
            }

        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {

            var userId = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();

            SiteDBEntities db = new SiteDBEntities();

            var empq = db.Employees.FirstOrDefault(e => e.UserName == userName);
            var eIDz = empq.EmployeeID;

            var eIDx = db.Employees.FirstOrDefault(e => e.EmployeeID == eIDz);
            var cIDx = db.Companies.FirstOrDefault(e => e.CompanyID == eIDx.CompanyID);
            ViewBag.co_cName = cIDx.CompanyName;
            var CompanyID = cIDx;
            ViewBag.CompanyID = cIDx.CompanyID;
            //ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyID");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.ProjectStatusID = new SelectList(db.ProjectStatus, "ProjectStatusID", "ProjectStatusName");
            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "ProjectCategoryID", "CategoryName");
            ViewBag.BidStatusID = new SelectList(db.BidStatus, "BidStatusID", "BidStatusName");

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ProjectName,ProjectDescription,ProjectStatus,ProjectCategory,OpenDate,BidOpenDate,BidCloseDate,CompanyID,Deleted,Active,Notes,Complete,CompletionDate,RequiredDate,BidStatus,AcceptedBid,AcceptedCompany,ActionDate,SiteAddress1,SiteAddress2,SiteAddressCity,SiteAddressState,SiteAddressZip,SiteAddressCountry,IsSubProject,SubProjectOf")] Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //SiteDBEntities dbp = new SiteDBEntities();              // create an instance of the database
                    //Project cfields = new Project();                        // connect to the Company table
                    //cfields.CompanyID = @ViewBag.CompanyID;                // set the field values to the data from the form model
                //db.Projects(company.CompanyID) = 5;
                    
                    //project.CompanyID = 500;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Error saving Project record. Contact system administrator.");
                    throw;                                               // Failed to write record
                                                                            //Log the error (uncomment dex variable name and add a line here to write a log.
                }

            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", project.CompanyID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectStatusID = new SelectList(db.ProjectStatus, "ProjectStatusID", "ProjectStatusName");
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", project.CompanyID);
            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "ProjectCategoryID", "CategoryName");
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ProjectName,ProjectDescription,ProjectStatus,ProjectCategory,OpenDate,BidOpenDate,BidCloseDate,CompanyID,Deleted,Active,Notes,Complete,CompletionDate,RequiredDate,BidStatus,AcceptedBid,AcceptedCompany,ActionDate,SiteAddress1,SiteAddress2,SiteAddressCity,SiteAddressState,SiteAddressZip,SiteAddressCountry,IsSubProject,SubProjectOf")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", project.CompanyID);
            ViewBag.ProjectCategoryID = new SelectList(db.ProjectCategories, "ProjectCategoryID", "CategoryName");
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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


        // GET: ProjectCalendar
        public ActionResult ProjectCalendar()
        {
            //var projects = db.Projects.Include(p => p.Company);     // limit projects shown to user's company
            //return View(projects.ToList());
            return View();
        }

        public JsonResult GetEvents()
        {
            using (SiteDBEntities db = new SiteDBEntities())
            {
                var events = db.Projects.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

    }
}


