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
    public class ImunizationRecordsController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: ImunizationRecords
        public ActionResult Index()
        {
            var imunizationRecords = db.ImunizationRecords.Include(i => i.Animal).Include(i => i.Medicine);
            return View(imunizationRecords.ToList());
        }

        // GET: ImunizationRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImunizationRecord imunizationRecord = db.ImunizationRecords.Find(id);
            if (imunizationRecord == null)
            {
                return HttpNotFound();
            }
            return View(imunizationRecord);
        }

        // GET: ImunizationRecords/Create
        public ActionResult Create()
        {
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species");
            ViewBag.medicineId = new SelectList(db.Medicines, "medicineId", "medicineName");
            return View();
        }

        // POST: ImunizationRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImunizationId,animalId,medicineId,ImunizationType,booster,reasonAdministered,dosageGiven,MethodOfDelivery")] ImunizationRecord imunizationRecord)
        {
            if (ModelState.IsValid)
            {
                db.ImunizationRecords.Add(imunizationRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", imunizationRecord.animalId);
            ViewBag.medicineId = new SelectList(db.Medicines, "medicineId", "medicineName", imunizationRecord.medicineId);
            return View(imunizationRecord);
        }

        // GET: ImunizationRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImunizationRecord imunizationRecord = db.ImunizationRecords.Find(id);
            if (imunizationRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", imunizationRecord.animalId);
            ViewBag.medicineId = new SelectList(db.Medicines, "medicineId", "medicineName", imunizationRecord.medicineId);
            return View(imunizationRecord);
        }

        // POST: ImunizationRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImunizationId,animalId,medicineId,ImunizationType,booster,reasonAdministered,dosageGiven,MethodOfDelivery")] ImunizationRecord imunizationRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imunizationRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", imunizationRecord.animalId);
            ViewBag.medicineId = new SelectList(db.Medicines, "medicineId", "medicineName", imunizationRecord.medicineId);
            return View(imunizationRecord);
        }

        // GET: ImunizationRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImunizationRecord imunizationRecord = db.ImunizationRecords.Find(id);
            if (imunizationRecord == null)
            {
                return HttpNotFound();
            }
            return View(imunizationRecord);
        }

        // POST: ImunizationRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImunizationRecord imunizationRecord = db.ImunizationRecords.Find(id);
            db.ImunizationRecords.Remove(imunizationRecord);
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
