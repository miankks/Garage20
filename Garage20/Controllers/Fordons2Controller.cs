using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage20.DAL;
using Garage20.Models;

namespace Garage20.Controllers
{
    public class Fordons2Controller : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Fordons2
        public ActionResult Index()
        {
            var fordons = db.Fordons.Include(f => f.Fordonstyper).Include(f => f.Medlemmar);
            return View(fordons.ToList());
        }

        // GET: Fordons2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // GET: Fordons2/Create
        public ActionResult Create()
        {
            ViewBag.FordonstypId = new SelectList(db.Fordonstyper, "FordonstypId", "Typ");
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn");
            return View();
        }

        // POST: Fordons2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNr,Färg,Märke,Modell,AntalHjul,Tid,MedlemsId,FordonstypId")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Fordons.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FordonstypId = new SelectList(db.Fordonstyper, "FordonstypId", "Typ", fordon.FordonstypId);
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn", fordon.MedlemsId);
            return View(fordon);
        }

        // GET: Fordons2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            ViewBag.FordonstypId = new SelectList(db.Fordonstyper, "FordonstypId", "Typ", fordon.FordonstypId);
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn", fordon.MedlemsId);
            return View(fordon);
        }

        // POST: Fordons2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,Färg,Märke,Modell,AntalHjul,Tid,MedlemsId,FordonstypId")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FordonstypId = new SelectList(db.Fordonstyper, "FordonstypId", "Typ", fordon.FordonstypId);
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn", fordon.MedlemsId);
            return View(fordon);
        }

        // GET: Fordons2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var fordon = db.Fordons
                .Include(f => f.Fordonstyper)
                .Include(f => f.Medlemmar)
                .SingleOrDefault(x => x.Id == id);

            //Fordon fordon = db.Fordons.Find(id);
            Fordon tempfordon = fordon;
            db.Fordons.Remove(fordon);
            db.SaveChanges();
            return RedirectToAction("Kvito", tempfordon);
        }

        public ActionResult Kvito(Fordon tempfordon)
        {
            ViewBag.FullständigtNamn = ViewBag.FullständigtNamn;
            TimeSpan currenttime = (DateTime.Now - tempfordon.Tid);
            var price = currenttime.TotalHours * 60;
            ViewBag.currenttime = Convert.ToInt32(currenttime.Hours);
            ViewBag.currentminutes = Convert.ToInt32(currenttime.Minutes);
            ViewBag.price = Convert.ToInt32(price);
            return View(tempfordon);
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
