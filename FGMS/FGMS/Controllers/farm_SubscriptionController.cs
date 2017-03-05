using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FGMS.Models;

namespace FGMS.Controllers
{
    public class farm_SubscriptionController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: farm_Subscription
        public ActionResult Index()
        {
            var farm_Subscription = db.farm_Subscription.Include(f => f.Farm);
            return View(farm_Subscription.ToList());
        }

        // GET: farm_Subscription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            farm_Subscription farm_Subscription = db.farm_Subscription.Find(id);
            if (farm_Subscription == null)
            {
                return HttpNotFound();
            }
            return View(farm_Subscription);
        }

        // GET: farm_Subscription/Create
        public ActionResult Create()
        {
            ViewBag.farmId = new SelectList(db.Farms, "farmId", "FarmName");
            return View();
        }

        // POST: farm_Subscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subscriptionId,farmId,StartDate,EndDate")] farm_Subscription farm_Subscription)
        {
            if (ModelState.IsValid)
            {
                db.farm_Subscription.Add(farm_Subscription);
                db.SaveChanges();
                return RedirectToAction("../Payments/Create");
            }

            ViewBag.farmId = new SelectList(db.Farms, "farmId", "FarmName", farm_Subscription.farmId);
            return View(farm_Subscription);
        }

        // GET: farm_Subscription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            farm_Subscription farm_Subscription = db.farm_Subscription.Find(id);
            if (farm_Subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.farmId = new SelectList(db.Farms, "farmId", "FarmName", farm_Subscription.farmId);
            return View(farm_Subscription);
        }

        // POST: farm_Subscription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subscriptionId,farmId,StartDate,EndDate")] farm_Subscription farm_Subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farm_Subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.farmId = new SelectList(db.Farms, "farmId", "FarmName", farm_Subscription.farmId);
            return View(farm_Subscription);
        }

        // GET: farm_Subscription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            farm_Subscription farm_Subscription = db.farm_Subscription.Find(id);
            if (farm_Subscription == null)
            {
                return HttpNotFound();
            }
            return View(farm_Subscription);
        }

        // POST: farm_Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            farm_Subscription farm_Subscription = db.farm_Subscription.Find(id);
            db.farm_Subscription.Remove(farm_Subscription);
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
