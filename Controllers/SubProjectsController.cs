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
    public class SubProjectsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: SubProjects
        public ActionResult Index()
        {
            return View(db.SubProjects.ToList());
        }

        // GET: SubProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubProject subProject = db.SubProjects.Find(id);
            if (subProject == null)
            {
                return HttpNotFound();
            }
            return View(subProject);
        }

        // GET: SubProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubProjectID,ProjectID,SubProjectName,SubProjectDescription,SubProjectStatus,ProjectType,OpenDate,BiDOpenDate,BidCloseDate,RequiredDate,AcceptedBid,AcceptedCompany,ActionDate,Deleted,Active,Notes,Complete,CompletionDate,Dependencies")] SubProject subProject)
        {
            if (ModelState.IsValid)
            {
                db.SubProjects.Add(subProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subProject);
        }

        // GET: SubProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubProject subProject = db.SubProjects.Find(id);
            if (subProject == null)
            {
                return HttpNotFound();
            }
            return View(subProject);
        }

        // POST: SubProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubProjectID,ProjectID,SubProjectName,SubProjectDescription,SubProjectStatus,ProjectType,OpenDate,BiDOpenDate,BidCloseDate,RequiredDate,AcceptedBid,AcceptedCompany,ActionDate,Deleted,Active,Notes,Complete,CompletionDate,Dependencies")] SubProject subProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subProject);
        }

        // GET: SubProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubProject subProject = db.SubProjects.Find(id);
            if (subProject == null)
            {
                return HttpNotFound();
            }
            return View(subProject);
        }

        // POST: SubProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubProject subProject = db.SubProjects.Find(id);
            db.SubProjects.Remove(subProject);
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
