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

        //-----------------------------------------------------------------------------------------------------------
        // Open the Employee listing page. GET: Employees
        //-----------------------------------------------------------------------------------------------------------
        // 
        [Authorize(Roles = "SuperAdmin, CompanyAdmin")]                     // These roles can open this page
        //[Authorize(Users = "rorygod, vishalm")]                             // Additionally, you can add specific users to open this page
        public ActionResult Index(int? id)
        {
            var userId = User.Identity.GetUserId();                         // Get the authenticated users ID
            var userName = User.Identity.GetUserName();                     // Get the authenticated users UserName

            //SiteDBEntities db = new SiteDBEntities();

            var empq = db.Employees.FirstOrDefault(e => e.UserName == userName);
            var eIDz = empq.EmployeeID;

            var eIDx = db.Employees.FirstOrDefault(e => e.EmployeeID == eIDz);
            ViewBag.eIDx = eIDx.EmployeeID;
            ViewBag.cIDx = eIDx.CompanyID;
            ViewBag.fName = eIDx.FirstName;
            ViewBag.lName = eIDx.LastName;

            var cIDx = db.Companies.FirstOrDefault(e => e.CompanyID == eIDx.CompanyID);
            ViewBag.co_cName = cIDx.CompanyName + " - ";

            if (id == null)                                                     // nothing passed. Admin. Show full list
            {
                ViewBag.co_cName = "Admin - All ";

                var employees = db.Employees.Include(e => e.Company);           // Show full list
            return View(employees.ToList());
            }
            else {                                                              
                //Company company = db.Companies.Find(id);
            var employees = db.Employees.Where(e => e.CompanyID == id);         //  CompanyID passed. Show just this company
            return View(employees.ToList());
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        // Open the Employee View page. GET: Employee/Details
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // Open the Employee Create page. GET: Employee/Create
        //-----------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "SuperAdmin, CompanyAdmin")]
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName");
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // Process the Employee Create page submit. POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //-----------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------
        // This is for Companies adding new Employees
        // Open the CreateEmployee page. GET: Employee/CreateEmployee
        //-----------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "SuperAdmin, CompanyAdmin")]                                     // Control who can create Employees
        public ActionResult CreateEmployee()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName");
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------
        // Process the CreateEmployee page submit. POST: Employees/CreateEmployee. 
        // Create a new individual Employee Record for the Account Creator with the Company ID 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee([Bind(Include = "EmployeeID,UserID,UserName,CompanyID,Company_EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,Notes,Deleted,Active,CompanyCreator,CreateDate")] Employee employee)
        //public ActionResult CreateEmployee(int? CompanyID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SiteDBEntities db = new SiteDBEntities();                      // create an instance of the database
                    int NewCIDy = Int32.Parse(Session["NewCID"].ToString());        // get the new CompanyID from session (string) and convert to integer
                    Employee efields = new Employee();                              // Connect to the Employee table
                    efields.CompanyID = NewCIDy;                                    // get the ID from the last created Company
                    efields.CreateDate = DateTime.Now;                              // set the create date to current time
                    efields.CompanyCreator = false;                                  // Indicate that this user/employee created the attached company record
                    db.Employees.Add(employee);
                    //db.Employees.Add(efields);
                    db.SaveChanges();
                    Session["NewEID"] = efields.EmployeeID;                         // get the EmployeeID from the record we just created

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving Employee record. Contact system administrator.");
                    throw ex;
                    //Log the error (uncomment dex variable name and add a line here to write a log.

                }

            }

            return RedirectToAction("Index");
        }

        //    if (ModelState.IsValid)
        //    {
        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        //return View(employee);
        //return RedirectToAction("Index");
        //    }

        //    ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", employee.CompanyID);
        //return View(employee);
        //}
        //-----------------------------------------------------------------------------------------------------------
        // Open the Employee Create page. GET: Employee/CreateEmployee
        //-----------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------
        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //-----------------------------------------------------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(EmployeeEditViewModel employee)      // This would use the ViewModel defined below instead of a list

        public ActionResult Edit([Bind(Include = "EmployeeID,CompanyID,Company_EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,Notes,Deleted,Active,UserName,CompanyCreator,CreateDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;                        // Sometimes more efficient excluding fields than managing ViewModels
                db.Entry(employee).Property("UserName").IsModified = false;             // Exclude certain fields from being modified
                db.Entry(employee).Property("CompanyID").IsModified = false;            // Exclude certain fields from being modified
                db.Entry(employee).Property("Deleted").IsModified = false;              // Exclude certain fields from being modified
                db.Entry(employee).Property("Active").IsModified = false;               // Exclude certain fields from being modified
                db.Entry(employee).Property("CompanyCreator").IsModified = false;       // Exclude certain fields from being modified
                db.Entry(employee).Property("CreateDate").IsModified = false;           // Exclude certain fields from being modified
                db.Entry(employee).Property("UserID").IsModified = false;               // Exclude certain fields from being modified
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", employee.CompanyID);
            return View(employee);
        }
        //-----------------------------------------------------------------------------------------------------------
        // Open the Employee Create page. GET: Employee/CreateEmployee
        //-----------------------------------------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------------------------------------
        // Open the Employee Delete page. GET: Employee/Delete
        //-----------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------
        // 
        //-----------------------------------------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //-----------------------------------------------------------------------------------------------------------
        // not used right now
        //-----------------------------------------------------------------------------------------------------------
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
