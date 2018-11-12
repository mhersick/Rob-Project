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
    public class ProjectCategoriesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: ProjectCategories
        public ActionResult Index()
        {
            return View(db.ProjectCategories.ToList());
        }

        // GET: ProjectCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            if (projectCategory == null)
            {
                return HttpNotFound();
            }
            return View(projectCategory);
        }

        // GET: ProjectCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectCategoryID,CategoryName,CategoryDescription,Active,Sequence,Deleted")] ProjectCategory projectCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProjectCategories.Add(projectCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectCategory);
        }

        // GET: ProjectCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            if (projectCategory == null)
            {
                return HttpNotFound();
            }
            return View(projectCategory);
        }

        // POST: ProjectCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectCategoryID,CategoryName,CategoryDescription,Active,Sequence,Deleted")] ProjectCategory projectCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectCategory);
        }

        // GET: ProjectCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            if (projectCategory == null)
            {
                return HttpNotFound();
            }
            return View(projectCategory);
        }

        // POST: ProjectCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectCategory projectCategory = db.ProjectCategories.Find(id);
            db.ProjectCategories.Remove(projectCategory);
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
