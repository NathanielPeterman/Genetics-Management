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
    public class DairyProductivitiesController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: DairyProductivities
        public ActionResult Index()
        {
            var dairyProductivities = db.DairyProductivities.Include(d => d.Animal);
            return View(dairyProductivities.ToList());
        }

        // GET: DairyProductivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DairyProductivity dairyProductivity = db.DairyProductivities.Find(id);
            if (dairyProductivity == null)
            {
                return HttpNotFound();
            }
            return View(dairyProductivity);
        }

        // GET: DairyProductivities/Create
        public ActionResult Create()
        {
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species");
            return View();
        }

        // POST: DairyProductivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dProductivityId,animalId,volumeProduced,dateProduced,butterFatContent,amountFeedFed")] DairyProductivity dairyProductivity)
        {
            if (ModelState.IsValid)
            {
                db.DairyProductivities.Add(dairyProductivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", dairyProductivity.animalId);
            return View(dairyProductivity);
        }

        // GET: DairyProductivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DairyProductivity dairyProductivity = db.DairyProductivities.Find(id);
            if (dairyProductivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", dairyProductivity.animalId);
            return View(dairyProductivity);
        }

        // POST: DairyProductivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dProductivityId,animalId,volumeProduced,dateProduced,butterFatContent,amountFeedFed")] DairyProductivity dairyProductivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dairyProductivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", dairyProductivity.animalId);
            return View(dairyProductivity);
        }

        // GET: DairyProductivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DairyProductivity dairyProductivity = db.DairyProductivities.Find(id);
            if (dairyProductivity == null)
            {
                return HttpNotFound();
            }
            return View(dairyProductivity);
        }

        // POST: DairyProductivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DairyProductivity dairyProductivity = db.DairyProductivities.Find(id);
            db.DairyProductivities.Remove(dairyProductivity);
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
