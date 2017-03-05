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
    public class CharacteristicsScoresController : Controller
    {
        private petermanEntities db = new petermanEntities();

        // GET: CharacteristicsScores
        public ActionResult Index()
        {
            var characteristicsScores = db.CharacteristicsScores.Include(c => c.Animal);
            return View(characteristicsScores.ToList());
        }

        // GET: CharacteristicsScores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicsScore characteristicsScore = db.CharacteristicsScores.Find(id);
            if (characteristicsScore == null)
            {
                return HttpNotFound();
            }
            return View(characteristicsScore);
        }

        // GET: CharacteristicsScores/Create
        public ActionResult Create()
        {
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species");
            return View();
        }

        // POST: CharacteristicsScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "characteristicsId,animalId,strength,stature,Capacity,dairyness,rumpAngle,rumpWidth,rearLegAngulation,foreLegAngulation,foreLegAttachment,EscutionArch,EscutionHeight,medialSuspendoryLigament,uderDepth,teatPlacement,teatDiameter,Head,ShoulderAssembly,LegsFront,LegsRear,Feet,Pastern,Back,UdderTexture,Remarks,Defects")] CharacteristicsScore characteristicsScore)
        {
            if (ModelState.IsValid)
            {
                db.CharacteristicsScores.Add(characteristicsScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", characteristicsScore.animalId);
            return View(characteristicsScore);
        }

        // GET: CharacteristicsScores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicsScore characteristicsScore = db.CharacteristicsScores.Find(id);
            if (characteristicsScore == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", characteristicsScore.animalId);
            return View(characteristicsScore);
        }

        // POST: CharacteristicsScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "characteristicsId,animalId,strength,stature,Capacity,dairyness,rumpAngle,rumpWidth,rearLegAngulation,foreLegAngulation,foreLegAttachment,EscutionArch,EscutionHeight,medialSuspendoryLigament,uderDepth,teatPlacement,teatDiameter,Head,ShoulderAssembly,LegsFront,LegsRear,Feet,Pastern,Back,UdderTexture,Remarks,Defects")] CharacteristicsScore characteristicsScore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characteristicsScore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.Animals, "animalId", "species", characteristicsScore.animalId);
            return View(characteristicsScore);
        }

        // GET: CharacteristicsScores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicsScore characteristicsScore = db.CharacteristicsScores.Find(id);
            if (characteristicsScore == null)
            {
                return HttpNotFound();
            }
            return View(characteristicsScore);
        }

        // POST: CharacteristicsScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharacteristicsScore characteristicsScore = db.CharacteristicsScores.Find(id);
            db.CharacteristicsScores.Remove(characteristicsScore);
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
