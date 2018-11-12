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
    public class ProjectStatusController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: ProjectStatus
        public ActionResult Index()
        {
            return View(db.ProjectStatus.ToList());
        }

        // GET: ProjectStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatu projectStatu = db.ProjectStatus.Find(id);
            if (projectStatu == null)
            {
                return HttpNotFound();
            }
            return View(projectStatu);
        }

        // GET: ProjectStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectStatusID,ProjectStatus,Description,Active")] ProjectStatu projectStatu)
        {
            if (ModelState.IsValid)
            {
                db.ProjectStatus.Add(projectStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectStatu);
        }

        // GET: ProjectStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatu projectStatu = db.ProjectStatus.Find(id);
            if (projectStatu == null)
            {
                return HttpNotFound();
            }
            return View(projectStatu);
        }

        // POST: ProjectStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectStatusID,ProjectStatus,Description,Active")] ProjectStatu projectStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectStatu);
        }

        // GET: ProjectStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatu projectStatu = db.ProjectStatus.Find(id);
            if (projectStatu == null)
            {
                return HttpNotFound();
            }
            return View(projectStatu);
        }

        // POST: ProjectStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectStatu projectStatu = db.ProjectStatus.Find(id);
            db.ProjectStatus.Remove(projectStatu);
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
