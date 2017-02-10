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
    public class FordonsController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Fordons
        public ActionResult Index(string searchString)
        {
            var model = from m in db.Fordons
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.RegNr.Contains(searchString));
                return View(model);
            }

            return View(db.Fordons.ToList());
        }

        // GET: Fordons/Details/5
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

        // GET: Fordons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fordons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegNr,Typ,Färg,Märke,Modell,AntalHjul")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Fordons.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fordon);
        }

        // GET: Fordons/Edit/5
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
            return View(fordon);
        }

        // POST: Fordons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,Typ,Färg,Märke,Modell,AntalHjul")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fordon);
        }

        // GET: Fordons/Delete/5
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
            Fordon fordon = db.Fordons.Find(id);
            db.Fordons.Remove(fordon);
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
