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
    [Authorize(Roles = "SuperAdmin")]

    public class CompaniesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------
        // GET: Companies
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

                //var company = db.Companies.Include(e => e.Active);
                //return View(company.ToList());
                return View(db.Companies.ToList());
            }
            else
            {                                                              //  CompanyID passed. Show just this company
                                                                           //Company company = db.Companies.Find(id);
                var company = db.Companies.Where(e => e.CompanyID == id);
                //return View(Company.ToList());
                return View(db.Companies.ToList());
            }
        }




        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------

        // GET: Companies/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------

        // GET: Companies/RegisterCompany
        public ActionResult RegisterCompany()
        {
            return View();
        }


        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------
        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,UserName,EmployeeID,CompanyName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,WebSite,ContractorLicense,ResaleCert,ServiceLevel,BillingCycle")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        //-----------------------------------------------------------------------------------------------------------
        // Get the data from the Company table and show it in edit view - GET: Companies/Edit
        //
        // Load the screen with the selected company record details exposed for editing
        //-----------------------------------------------------------------------------------------------------------
        public ActionResult EditCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var company = id;

            Company company = db.Companies.Find(id);                                                                // Find the company record based on the passed ID

            if (company == null)
            {
                return HttpNotFound();
            }
            // found the detail record for the company, so time to put the view model together before calling it

            // Two ways to do this:
            //ViewModels.CompanyEditViewModel companyeditViewModel = new ViewModels.CompanyEditViewModel();
            //companyeditViewModel.CompanyName = company.CompanyName;

            // OR

            ViewModels.CompanyEditViewModel companyeditViewModel = new ViewModels.CompanyEditViewModel
            {
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName,
                Address1 = company.Address1,
                Address2 = company.Address2,
                City = company.City,
                State = company.State,
                Zip = company.Zip,
                Country = company.Country,
                Email1 = company.Email1,
                Email2 = company.Email2,
                Phone1 = company.Phone1,
                Phone2 = company.Phone2,
                WebSite = company.WebSite,
                CompanyPrimaryImg = company.CompanyPrimaryImg,
                CompanySecondaryImg = company.CompanySecondaryImg,
                CompanyDescription = company.CompanyDescription,
                CompanyText = company.CompanyText,
                ArticleDescription = company.ArticleDescription,
                ArticleText = company.ArticleText,
                ResaleCertificate = company.ResaleCertificate,
                ContractorLicense = company.ContractorLicense
            };
            return View(companyeditViewModel);                                                  // send the filled-in viewmodel to the screen
        }

        //-----------------------------------------------------------------------------------------------------------
        // Save the Changes from the edit view - POST: Companies/Edit
        // The editable portion of the Company record will be on the screen from the GET.  
        // For the PUT, the user either has to save the record.  If they exit, nothing happens
        //
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //-----------------------------------------------------------------------------------------------------------
        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditCompany([Bind(Include = "CompanyID,CompanyName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,WebSite,ContractorLicense,ResaleCert,")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.Entry(company).Property("CreateDate").IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }




        //public ActionResult EditCompany(ViewModels.CompanyEditViewModel vm)      // This would use the ViewModel defined below instead of a list
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var comp = db.Companies.Find();
        //        comp.CompanyName = vm.CompanyName;
        //        comp.Address1 = vm.Address1;
        //        comp.Address2 = vm.Address2;
        //        comp.City = vm.City;
        //        comp.State = vm.State;
        //        comp.Zip = vm.Zip;
        //        comp.Country = vm.Country;
        //        comp.Phone1 = vm.Phone1;
        //        comp.Phone2 = vm.Phone2;
        //        comp.Email1 = vm.Email1;
        //        comp.Email2 = vm.Email2;
        //        comp.WebSite = vm.WebSite;
        //        comp.CompanyPrimaryImg = vm.CompanyPrimaryImg;
        //        comp.CompanySecondaryImg = vm.CompanySecondaryImg;
        //        comp.CompanyDescription = vm.CompanyDescription;
        //        comp.CompanyText = vm.CompanyText;
        //        comp.ArticleDescription = vm.ArticleDescription;
        //        comp.ArticleText = vm.ArticleText;
        //        comp.ResaleCertificate = vm.ResaleCertificate;
        //        comp.ContractorLicense = vm.ContractorLicense;

        //        //db.Entry(comp).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    //return View(company);
        //    return RedirectToAction("Index");

        //}




        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(CompanyEditViewModel company)      // This would use the ViewModel defined below instead of a list
        //public ActionResult Edit([Bind(Include = "CompanyID,UserName,EmployeeID,CompanyName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,WebSite,ServiceLevel,BillingCycle,ContractorLicense,ResaleCert,CreateID,Deleted,Active,CreateDate")] Company company)
        public ActionResult Edit([Bind(Include = "CompanyID,CompanyName,Address1,Address2,City,State,Zip,Country,Phone1,Phone2,Email1,Email2,WebSite,CompanyPrimaryImg,CompanySecondaryImg,CompanyDescription,CompanyText,ArticleDescription,ArticleText,ContractorLicense,ResaleCert,")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;                                 // Assume everything has been modified
                db.Entry(company).Property("UserName").IsModified = false;                      // Exclude certain fields from being modified
                db.Entry(company).Property("ServiceLevel").IsModified = false;
                db.Entry(company).Property("BillingCycle").IsModified = false;
                db.Entry(company).Property("CreateDate").IsModified = false;
                db.Entry(company).Property("Deleted").IsModified = false;
                db.Entry(company).Property("Active").IsModified = false;
                db.Entry(company).Property("EmployeeID").IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------
        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //-----------------------------------------------------------------------------------------------------------
        //
        //-----------------------------------------------------------------------------------------------------------
        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
        public class CompanyEditViewModelzzzzz
        {
            public int CompanyID { get; set; }
            public string CompanyName { get; set; }
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
            public string WebSite { get; set; }
            public string ContractorLicense { get; set; }
            public string ServiceLevel { get; set; }
            public Nullable<int> BillingCycle { get; set; }
            public bool Active { get; set; }
            public bool Deleted { get; set; }
            public string CompanyPrimaryImg { get; set; }
            public string CompanySecondaryImg { get; set; }
            public string CompanyDescription { get; set; }
            public string CompanyText { get; set; }
            public string ArticleDescription { get; set; }
            public string ArticleText { get; set; }
            public string ResaleCertificate { get; set; }
            public Nullable<int> EmployeeID { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
        }


    }
}
