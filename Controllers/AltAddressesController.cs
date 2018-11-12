using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E3DBPI.Models;

namespace E3DBPI.Controllers
{
    public class AltAddressesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: AltAddresses
        public ActionResult Index()
        {
            var altAddresses = db.AltAddresses.Include(a => a.Company);
            return View(altAddresses.ToList());
        }

        // GET: AltAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltAddress altAddress = db.AltAddresses.Find(id);
            if (altAddress == null)
            {
                return HttpNotFound();
            }
            return View(altAddress);
        }

        // GET: AltAddresses/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName");
            return View();
        }

        // POST: AltAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,CompanyID,NickName,Address1,Address2,City,State,Zip,Country,ShipPhone,ShipEmail,Notes")] AltAddress altAddress)
        {
            if (ModelState.IsValid)
            {
                db.AltAddresses.Add(altAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", altAddress.CompanyID);
            return View(altAddress);
        }

        // GET: AltAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltAddress altAddress = db.AltAddresses.Find(id);
            if (altAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", altAddress.CompanyID);
            return View(altAddress);
        }

        // POST: AltAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,CompanyID,NickName,Address1,Address2,City,State,Zip,Country,ShipPhone,ShipEmail,Notes")] AltAddress altAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "UserName", altAddress.CompanyID);
            return View(altAddress);
        }

        // GET: AltAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltAddress altAddress = db.AltAddresses.Find(id);
            if (altAddress == null)
            {
                return HttpNotFound();
            }
            return View(altAddress);
        }

        // POST: AltAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AltAddress altAddress = db.AltAddresses.Find(id);
            db.AltAddresses.Remove(altAddress);
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
