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
    public class DetaljerController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Detaljer
        public ActionResult Index(string sortOrder, string searchString, string alternative)
        {
            ViewBag.ÄgareSortParm = sortOrder == "Ägare" ? "Ägare_desc" : "Ägare";
            ViewBag.TypSortParm = sortOrder == "Typ" ? "Typ_desc" : "Typ";
            ViewBag.RegNrSortParm = sortOrder == "RegNr" ? "RegNr_desc" : "RegNr";
            ViewBag.FärgSortParm = sortOrder == "Färg" ? "Färg_desc" : "Färg";
            ViewBag.MärkeSortParm = sortOrder == "Märke" ? "Märke_desc" : "Märke";
            ViewBag.ModellSortParm = sortOrder == "Modell" ? "Modell_desc" : "Modell";
            ViewBag.AntalHjulSortParm = sortOrder == "AntalHjul" ? "AntalHjul_desc" : "AntalHjul";
            ViewBag.TidSortParm = sortOrder == "Tid" ? "Tid_desc" : "Tid";

            var fordon = db.Fordons.Include(f => f.Fordonstyper).Include(f => f.Medlemmar);

            ViewBag.alternative = new SelectList(new List<string>() { "Registreringsnummer", "Fordonstyp" });

            if (!String.IsNullOrEmpty(searchString))
            {
                if (!string.IsNullOrEmpty(alternative))
                {
                    if (alternative == "Registreringsnummer")
                        fordon = fordon.Where(s => s.RegNr.Contains(searchString));
                    else if (alternative == "Fordonstyp")
                        fordon = fordon.Where(s => s.Fordonstyper.Typ.Contains(searchString));
                }
            }

            switch (sortOrder)
            {
                case "RegNr":
                    fordon = fordon.OrderBy(f => f.RegNr);
                    break;
                case "RegNr_desc":
                    fordon = fordon.OrderByDescending(f => f.RegNr);
                    break;
                case "Färg":
                    fordon = fordon.OrderBy(f => f.Färg);
                    break;
                case "Färg_desc":
                    fordon = fordon.OrderByDescending(f => f.Färg);
                    break;
                case "Märke":
                    fordon = fordon.OrderBy(f => f.Märke);
                    break;
                case "Märke_desc":
                    fordon = fordon.OrderByDescending(f => f.Märke);
                    break;
                case "Modell":
                    fordon = fordon.OrderBy(f => f.Modell);
                    break;
                case "Modell_desc":
                    fordon = fordon.OrderByDescending(f => f.Modell);
                    break;
                case "Typ":
                    fordon = fordon.OrderBy(f => f.Fordonstyper.Typ);
                    break;
                case "Typ_desc":
                    fordon = fordon.OrderByDescending(f => f.Fordonstyper.Typ);
                    break;
                case "Ägare":
                   
                    fordon = fordon.OrderBy(f => f.Medlemmar.Förnamn).ThenBy(f => f.Medlemmar.Efternamn);
                    break;
                case "Ägare_desc":
                    fordon = fordon.OrderByDescending(f => f.Medlemmar.Förnamn).ThenByDescending(f => f.Medlemmar.Efternamn);
                    break;
                case "AntalHjul":
                    fordon = fordon.OrderBy(f => f.AntalHjul);
                    break;
                case "AntalHjul_desc":
                    fordon = fordon.OrderByDescending(f => f.AntalHjul);
                    break;
                case "Tid":
                    fordon = fordon.OrderBy(f => f.Tid);
                    break;
                case "Tid_desc":
                    fordon = fordon.OrderByDescending(f => f.Tid);
                    break;
                default:
                    break;
            }
            return View(fordon.ToList());
            var fordons = db.Fordons.Include(f => f.Fordonstyper).Include(f => f.Medlemmar);
            return View(fordons.ToList());
        }

        // GET: Detaljer/Details/5
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

        // GET: Detaljer/Create
        public ActionResult Create()
        {
            ViewBag.FordonstypId = new SelectList(db.Fordonstyper, "FordonstypId", "Typ");
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn");
            return View();
        }

        // POST: Detaljer/Create
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

        // GET: Detaljer/Edit/5
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

        // POST: Detaljer/Edit/5
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

        // GET: Detaljer/Delete/5
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

        // POST: Detaljer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
