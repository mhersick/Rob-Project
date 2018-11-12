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
    public class PaymentMethodsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: PaymentMethods
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

                var paymentmethods = db.PaymentMethods.Include(e => e.Company);
                return View(paymentmethods.ToList());
            }
            else
            {                                                              //  CompanyID passed. Show just this company
                                                                           //Company company = db.Companies.Find(id);
                var paymentmethods = db.PaymentMethods.Where(e => e.CompanyID == id);
                return View(paymentmethods.ToList());
            }
        }

        // GET: PaymentMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: PaymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentMethodID,CompanyID,PaymentType,PaymentMethodName,AccountNumber,RoutingNumber,BankName,ExpirationMonth,ExpirationYear,PayeeName,PayeeAddress,PayeeCity,PayeeState,PayeeZip,PayeeCountry,OtherInfo,CreateDate,LastActivityDate,SetAsDefault,Active,Deleted")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.PaymentMethods.Add(paymentMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", paymentMethod.CompanyID);
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", paymentMethod.CompanyID);
            return View(paymentMethod);
        }

        // POST: PaymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentMethodID,CompanyID,PaymentType,PaymentMethodName,AccountNumber,RoutingNumber,BankName,ExpirationMonth,ExpirationYear,PayeeName,PayeeAddress,PayeeCity,PayeeState,PayeeZip,PayeeCountry,OtherInfo,CreateDate,LastActivityDate,SetAsDefault,Active,Deleted")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", paymentMethod.CompanyID);
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            db.PaymentMethods.Remove(paymentMethod);
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
    }
}
