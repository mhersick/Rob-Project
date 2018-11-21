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
    public class ItemsController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.ItemBox).Include(i => i.ItemCategory).Include(i => i.ItemBox1);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription");
            ViewBag.CategoryID = new SelectList(db.ItemCategories, "CategoryID", "CategoryName");
            ViewBag.BoxID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,VendorID,CategoryID,SKU,ItemName,ItemDescription,VendorItemID,Price1,Price2,Price3,Price4,Price5,Size,Color,InStock,Active,Featured,ItemNW,Limage,Simage,Timage,Pic01,Pic02,Pic03,WebLink,Outlet,OrderMin,OrderInc,BoxID,Views,Ranking")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription", item.ItemID);
            ViewBag.CategoryID = new SelectList(db.ItemCategories, "CategoryID", "CategoryName", item.CategoryID);
            ViewBag.BoxID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription", item.BoxID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription", item.ItemID);
            ViewBag.CategoryID = new SelectList(db.ItemCategories, "CategoryID", "CategoryName", item.CategoryID);
            ViewBag.BoxID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription", item.BoxID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,VendorID,CategoryID,SKU,ItemName,ItemDescription,VendorItemID,Price1,Price2,Price3,Price4,Price5,Size,Color,InStock,Active,Featured,ItemNW,Limage,Simage,Timage,Pic01,Pic02,Pic03,WebLink,Outlet,OrderMin,OrderInc,BoxID,Views,Ranking")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription", item.ItemID);
            ViewBag.CategoryID = new SelectList(db.ItemCategories, "CategoryID", "CategoryName", item.CategoryID);
            ViewBag.BoxID = new SelectList(db.ItemBoxes, "BoxID", "BoxDescription", item.BoxID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
