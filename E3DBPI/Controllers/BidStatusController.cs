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
    public class BidStatusController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: BidStatus
        public ActionResult Index()
        {
            return View(db.BidStatus.ToList());
        }

        // GET: BidStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidStatu bidStatu = db.BidStatus.Find(id);
            if (bidStatu == null)
            {
                return HttpNotFound();
            }
            return View(bidStatu);
        }

        // GET: BidStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BidStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidStatusID,BidStatusName,Description,Active,Deleted,Sequence")] BidStatu bidStatu)
        {
            if (ModelState.IsValid)
            {
                db.BidStatus.Add(bidStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bidStatu);
        }

        // GET: BidStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidStatu bidStatu = db.BidStatus.Find(id);
            if (bidStatu == null)
            {
                return HttpNotFound();
            }
            return View(bidStatu);
        }

        // POST: BidStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BidStatusID,BidStatusName,Description,Active,Deleted,Sequence")] BidStatu bidStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bidStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bidStatu);
        }

        // GET: BidStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidStatu bidStatu = db.BidStatus.Find(id);
            if (bidStatu == null)
            {
                return HttpNotFound();
            }
            return View(bidStatu);
        }

        // POST: BidStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BidStatu bidStatu = db.BidStatus.Find(id);
            db.BidStatus.Remove(bidStatu);
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
