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
    public class TestRecordsController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: TestRecords
        public ActionResult Index()
        {
            var testRecords = db.TestRecords.Include(t => t.Health);
            return View(testRecords.ToList());
        }

        // GET: TestRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestRecord testRecord = db.TestRecords.Find(id);
            if (testRecord == null)
            {
                return HttpNotFound();
            }
            return View(testRecord);
        }

        // GET: TestRecords/Create
        public ActionResult Create()
        {
            ViewBag.healthId = new SelectList(db.Healths, "healthId", "condition");
            return View();
        }

        // POST: TestRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testId,testName,testType,ImportantInfo,TestResults,healthId")] TestRecord testRecord)
        {
            if (ModelState.IsValid)
            {
                db.TestRecords.Add(testRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.healthId = new SelectList(db.Healths, "healthId", "condition", testRecord.healthId);
            return View(testRecord);
        }

        // GET: TestRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestRecord testRecord = db.TestRecords.Find(id);
            if (testRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.healthId = new SelectList(db.Healths, "healthId", "condition", testRecord.healthId);
            return View(testRecord);
        }

        // POST: TestRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testId,testName,testType,ImportantInfo,TestResults,healthId")] TestRecord testRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.healthId = new SelectList(db.Healths, "healthId", "condition", testRecord.healthId);
            return View(testRecord);
        }

        // GET: TestRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestRecord testRecord = db.TestRecords.Find(id);
            if (testRecord == null)
            {
                return HttpNotFound();
            }
            return View(testRecord);
        }

        // POST: TestRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestRecord testRecord = db.TestRecords.Find(id);
            db.TestRecords.Remove(testRecord);
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
