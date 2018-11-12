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
    public class MemberInfoController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: MemberInfo
        public ActionResult Index()
        {
            return View(db.MemberInfoes.ToList());
        }

        // GET: MemberInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // GET: MemberInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,CompanyID,IsCompanyOwner,FirstName,LastName,Address1,Address2,Address3,City,State,Zip,Country,Email,Phone,Notes,Active,Deleted,UserID")] MemberInfo memberInfo)
        {
            if (ModelState.IsValid)
            {
                db.MemberInfoes.Add(memberInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberInfo);
        }

        // GET: MemberInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // POST: MemberInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,CompanyID,IsCompanyOwner,FirstName,LastName,Address1,Address2,Address3,City,State,Zip,Country,Email,Phone,Notes,Active,Deleted,UserID")] MemberInfo memberInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberInfo);
        }

        // GET: MemberInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // POST: MemberInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberInfo memberInfo = db.MemberInfoes.Find(id);
            db.MemberInfoes.Remove(memberInfo);
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
