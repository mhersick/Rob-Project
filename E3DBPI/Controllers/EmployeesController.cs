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
    public class EmployeesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Employees
        [Authorize(Roles = "SuperAdmin, CompanyAdmin")]
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

            if (id == null)                                                     // nothing passed. Show full list
            {
                ViewBag.co_cName = "Administrators Only! - All ";

                var employees = db.Employees.Include(e => e.Company);
            return View(employees.ToList());
            }
            else {                                                              //  CompanyID passed. Show just this company
                //Company company = db.Companies.Find(id);
            var employees = db.Employees.Where(e => e.CompanyID == id);
            return View(employees.ToList());
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles = "SuperAdmin, CompanyAdmin")]
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,UserName,UserID,CompanyID,Company_EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,Notes,CompanyCreator,Deleted,Active,CreateDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", employee.CompanyID);
            return View(employee);
        }


        // GET: Employees/CreateEmployee
        [Authorize(Roles = "SuperAdmin, CompanyAdmin")]
        public ActionResult CreateEmployee()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee([Bind(Include = "EmployeeID,UserName,UserID,CompanyID,Company_EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,Notes,CompanyCreator,Deleted,Active,CreateDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                //return View(employee);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", employee.CompanyID);
            return View(employee);
        }


        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", employee.CompanyID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(EmployeeEditViewModel employee)      // This would use the ViewModel defined below instead of a list
        //public ActionResult Edit([Bind(Include = "EmployeeID,CompanyID,Company_EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,Notes,Deleted,Active,UserName,CompanyCreator,CreateDate")] Employee employee)
        public ActionResult Edit([Bind(Include = "EmployeeID,CompanyID,Company_EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,Notes,Deleted,Active,UserName,CompanyCreator,CreateDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.Entry(employee).Property("UserName").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(employee).Property("CompanyID").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(employee).Property("Deleted").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(employee).Property("Active").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(employee).Property("CompanyCreator").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(employee).Property("CreateDate").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(employee).Property("UserID").IsModified = false;                      // Exclude certain fields from being modified
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", employee.CompanyID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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

        // not used right now
        public class EmployeeEditViewModel
        {
            public int EmployeeID { get; set; }
            public int CompanyID { get; set; }
            public string Company_EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string Country { get; set; }
            public string Phone1 { get; set; }
            public string Phone2 { get; set; }
            public string Email1 { get; set; }
            public string Email2 { get; set; }
            public string Notes { get; set; }
            public bool Deleted { get; set; }
            public bool Active { get; set; }
            public bool CompanyCreator { get; set; }
            public Nullable<System.Guid> UserID { get; set; }
            public string UserName { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }

        }
    }
    }
