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
    public class AnimalsController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.Animal2).Include(a => a.Animal3);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.fatherId = new SelectList(db.Animals, "animalId", "species");
            ViewBag.motherId = new SelectList(db.Animals, "animalId", "species");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "animalId,species,breed,birthDate,gender,birthWeight,hornType,PatternDiscription,earType,CurrentWeight,famachaScore,numFreshenings,registrationNumber,rFIDNumber,TagNumber,scrapieNumber,leftEarTatoo,rightEarTatoo,animalName,fatherId,motherId,isDeceased")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fatherId = new SelectList(db.Animals, "animalId", "species", animal.fatherId);
            ViewBag.motherId = new SelectList(db.Animals, "animalId", "species", animal.motherId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.fatherId = new SelectList(db.Animals, "animalId", "species", animal.fatherId);
            ViewBag.motherId = new SelectList(db.Animals, "animalId", "species", animal.motherId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "animalId,species,breed,birthDate,gender,birthWeight,hornType,PatternDiscription,earType,CurrentWeight,famachaScore,numFreshenings,registrationNumber,rFIDNumber,TagNumber,scrapieNumber,leftEarTatoo,rightEarTatoo,animalName,fatherId,motherId,isDeceased")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fatherId = new SelectList(db.Animals, "animalId", "species", animal.fatherId);
            ViewBag.motherId = new SelectList(db.Animals, "animalId", "species", animal.motherId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
