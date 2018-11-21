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

    public class BlogPostsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: BlogPosts
        [Authorize(Roles = "SuperAdmin, Author")]
        public ActionResult Index()
        {
            var blogPosts = db.BlogPosts.Include(b => b.BlogCategory);
            return View(blogPosts.ToList());
        }
        // GET: BlogPosts
        public ActionResult NewsnEvents()
        {
            var blogPosts = db.BlogPosts.Include(b => b.BlogCategory);
            return View(blogPosts.ToList());
        }


        // GET: BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = "SuperAdmin, Author")]
        public ActionResult Create()
        {
            ViewBag.Post_CategoryID = new SelectList(db.BlogCategories, "Post_CategoryID", "Post_CategoryName");
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Post_CategoryID,Post_author,Post_Date,Post_Tite,Post_Content,Post_Status,Post_Deleted,Post_Active,Post_Featured,Post_Views,Post_CommentsAllowed,Post_Image1,Post_Image2,Post_Image3,Post_Banner1,Post_Article,Post_ArticleContent,Post_URL1,Post_URL2,Post_CommentsReview")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.BlogPosts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Post_CategoryID = new SelectList(db.BlogCategories, "Post_CategoryID", "Post_CategoryName", blogPost.Post_CategoryID);
            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "SuperAdmin, Author")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.Post_CategoryID = new SelectList(db.BlogCategories, "Post_CategoryID", "Post_CategoryName", blogPost.Post_CategoryID);
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Post_CategoryID,Post_author,Post_Date,Post_Tite,Post_Content,Post_Status,Post_Deleted,Post_Active,Post_Featured,Post_Views,Post_CommentsAllowed,Post_Image1,Post_Image2,Post_Image3,Post_Banner1,Post_Article,Post_ArticleContent,Post_URL1,Post_URL2,Post_CommentsReview")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Post_CategoryID = new SelectList(db.BlogCategories, "Post_CategoryID", "Post_CategoryName", blogPost.Post_CategoryID);
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "SuperAdmin, Author")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogPost);
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
