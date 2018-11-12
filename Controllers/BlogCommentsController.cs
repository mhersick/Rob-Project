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
    public class BlogCommentsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: BlogComments
        public ActionResult Index()
        {
            var blogComments = db.BlogComments.Include(b => b.BlogPost);
            return View(blogComments.ToList());
        }

        // GET: BlogComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // GET: BlogComments/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.BlogPosts, "PostID", "Post_author");
            return View();
        }

        // POST: BlogComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostCommentID,PostID,PostCommentAuthor,PostCommentDate,PostCommentContent,Deleted,Active,PostCommentCompanyID")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                db.BlogComments.Add(blogComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.BlogPosts, "PostID", "Post_author", blogComment.PostID);
            return View(blogComment);
        }

        // GET: BlogComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.BlogPosts, "PostID", "Post_author", blogComment.PostID);
            return View(blogComment);
        }

        // POST: BlogComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostCommentID,PostID,PostCommentAuthor,PostCommentDate,PostCommentContent,Deleted,Active,PostCommentCompanyID")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.BlogPosts, "PostID", "Post_author", blogComment.PostID);
            return View(blogComment);
        }

        // GET: BlogComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // POST: BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogComment blogComment = db.BlogComments.Find(id);
            db.BlogComments.Remove(blogComment);
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
