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
    public class ServicePlansController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: ServicePlans
        public ActionResult Index()
        {
            return View(db.ServicePlans.ToList());
        }

        // GET: ServicePlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePlan servicePlan = db.ServicePlans.Find(id);
            if (servicePlan == null)
            {
                return HttpNotFound();
            }
            return View(servicePlan);
        }

        // GET: ServicePlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicePlanID,ServicePlanName,ShortDescription,LongDescription,Seats,Storage,FeatureA,FeatureB,FeatureC,FeatureD,FeatureE,AddSeatCost,MontlhyCost,AnnualCost,DiscountPercent,Sequence")] ServicePlan servicePlan)
        {
            if (ModelState.IsValid)
            {
                db.ServicePlans.Add(servicePlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicePlan);
        }

        // GET: ServicePlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePlan servicePlan = db.ServicePlans.Find(id);
            if (servicePlan == null)
            {
                return HttpNotFound();
            }
            return View(servicePlan);
        }

        // POST: ServicePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicePlanID,ServicePlanName,ShortDescription,LongDescription,Seats,Storage,FeatureA,FeatureB,FeatureC,FeatureD,FeatureE,AddSeatCost,MontlhyCost,AnnualCost,DiscountPercent,Sequence")] ServicePlan servicePlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicePlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicePlan);
        }

        // GET: ServicePlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePlan servicePlan = db.ServicePlans.Find(id);
            if (servicePlan == null)
            {
                return HttpNotFound();
            }
            return View(servicePlan);
        }

        // POST: ServicePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicePlan servicePlan = db.ServicePlans.Find(id);
            db.ServicePlans.Remove(servicePlan);
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
