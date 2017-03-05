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
    public class HealthsController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: Healths
        public ActionResult Index()
        {
            var healths = db.Healths.Include(h => h.Animal);
            return View(healths.ToList());
        }

        // GET: Healths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health health = db.Healths.Find(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // GET: Healths/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "animalId", "species");
            return View();
        }

        // POST: Healths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "healthId,AnimalId,condition,symptoms,occurances,treatment,ImunizationId")] Health health)
        {
            if (ModelState.IsValid)
            {
                db.Healths.Add(health);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "animalId", "species", health.AnimalId);
            return View(health);
        }

        // GET: Healths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health health = db.Healths.Find(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "animalId", "species", health.AnimalId);
            return View(health);
        }

        // POST: Healths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "healthId,AnimalId,condition,symptoms,occurances,treatment,ImunizationId")] Health health)
        {
            if (ModelState.IsValid)
            {
                db.Entry(health).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "animalId", "species", health.AnimalId);
            return View(health);
        }

        // GET: Healths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health health = db.Healths.Find(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // POST: Healths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Health health = db.Healths.Find(id);
            db.Healths.Remove(health);
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
