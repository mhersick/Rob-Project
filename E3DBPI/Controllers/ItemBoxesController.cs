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
    public class ItemBoxesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: ItemBoxes
        public ActionResult Index()
        {
            var itemBoxes = db.ItemBoxes.Include(i => i.Item);
            return View(itemBoxes.ToList());
        }

        // GET: ItemBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBox itemBox = db.ItemBoxes.Find(id);
            if (itemBox == null)
            {
                return HttpNotFound();
            }
            return View(itemBox);
        }

        // GET: ItemBoxes/Create
        public ActionResult Create()
        {
            ViewBag.BoxID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: ItemBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoxID,BoxDescription,BoxWidth,BoxLength,BoxHeight,BoxNW,BoxCF,InnerOuter,InnerBoxFor,Image,Zone01,Zone02,Zone03,Zone04,Zone05,Zone06,Zone07,Zone08,Zone09,Zone10,Zone11,Zone12,Zone13,Zone14,Zone15,RuralZone,InternationalZone,Active")] ItemBox itemBox)
        {
            if (ModelState.IsValid)
            {
                db.ItemBoxes.Add(itemBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoxID = new SelectList(db.Items, "ItemID", "ItemName", itemBox.BoxID);
            return View(itemBox);
        }

        // GET: ItemBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBox itemBox = db.ItemBoxes.Find(id);
            if (itemBox == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoxID = new SelectList(db.Items, "ItemID", "ItemName", itemBox.BoxID);
            return View(itemBox);
        }

        // POST: ItemBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoxID,BoxDescription,BoxWidth,BoxLength,BoxHeight,BoxNW,BoxCF,InnerOuter,InnerBoxFor,Image,Zone01,Zone02,Zone03,Zone04,Zone05,Zone06,Zone07,Zone08,Zone09,Zone10,Zone11,Zone12,Zone13,Zone14,Zone15,RuralZone,InternationalZone,Active")] ItemBox itemBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoxID = new SelectList(db.Items, "ItemID", "ItemName", itemBox.BoxID);
            return View(itemBox);
        }

        // GET: ItemBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemBox itemBox = db.ItemBoxes.Find(id);
            if (itemBox == null)
            {
                return HttpNotFound();
            }
            return View(itemBox);
        }

        // POST: ItemBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemBox itemBox = db.ItemBoxes.Find(id);
            db.ItemBoxes.Remove(itemBox);
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
