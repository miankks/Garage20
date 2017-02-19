using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._5.DAL;
using Garage20.Models;

namespace Garage20.Controllers
{
    public class Fordons1Controller : Controller
    {
        private FordonContext db = new FordonContext();

        // GET: Fordons1
        public ActionResult Index(string searchString)
        {
            var fordon1 = from f in db.Fordon
                         select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                fordon1 = fordon1.Where(s => s.RegNr.Contains(searchString)
                                        || s.Färg.Contains(searchString)
                                        || s.Modell.Contains(searchString)
                                        || s.Märke.Contains(searchString)
                                        || s.AntalHjul.ToString().Contains(searchString)
                                        || s.Fordonstyper.Typ.Contains(searchString)
                                        || s.Tid.ToString().Contains(searchString)
                                        || s.Medlemmar.Förnamn.Contains(searchString)
                                        || s.Medlemmar.Efternamn.Contains(searchString)

                                        );
                return View(fordon1);
            }
            var fordon = db.Fordon.Include(f => f.Fordonstyper).Include(f => f.Medlemmar);
            return View(fordon.ToList());
        }

        // GET: Fordons1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordon.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // GET: Fordons1/Create
        public ActionResult Create()
        {
            ViewBag.FordonstypId = new SelectList(db.Fordonstyp, "FordonstypId", "Typ");
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn");
            return View();
        }

        // POST: Fordons1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNr,Färg,Märke,Modell,AntalHjul,Tid,MedlemsId,FordonstypId")] Fordon fordon)
        {
            //var findFordon = from m in db.Fordon
            //                 where fordon.RegNr == m.RegNr
            //                 select m.RegNr;
            //if (findFordon.Count() == 0)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        fordon.Tid = DateTime.Now;
            //        fordon.RegNr = fordon.RegNr.ToUpper();
            //        fordon.Färg = fordon.Färg.ToLower();
            //        fordon.Färg = fordon.Färg.First().ToString().ToUpper() + fordon.Färg.Substring(1); //Stor första bokstav.
            //        fordon.Märke = fordon.Märke.ToLower();
            //        fordon.Märke = fordon.Märke.First().ToString().ToUpper() + fordon.Märke.Substring(1); //Stor första bokstav.
            //        fordon.Modell = fordon.Modell.ToUpper();

            //        db.Fordon.Add(fordon);
            //        db.SaveChanges();
            //        ViewBag.error = "";
            //        return RedirectToAction("Index");
            //    }
            //}
            //else
            //{
            //    ViewBag.error = "Registreringsnumret finns redan i garaget!";
            //}
            //return View(fordon);
            if (ModelState.IsValid)
            {
                db.Fordon.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FordonstypId = new SelectList(db.Fordonstyp, "FordonstypId", "Typ", fordon.FordonstypId);
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn", fordon.MedlemsId);
            return View(fordon);
        }

        // GET: Fordons1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordon.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            ViewBag.FordonstypId = new SelectList(db.Fordonstyp, "FordonstypId", "Typ", fordon.FordonstypId);
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn", fordon.MedlemsId);
            return View(fordon);
        }

        // POST: Fordons1/Edit/5
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
            ViewBag.FordonstypId = new SelectList(db.Fordonstyp, "FordonstypId", "Typ", fordon.FordonstypId);
            ViewBag.MedlemsId = new SelectList(db.Medlemmar, "MedlemsId", "Förnamn", fordon.MedlemsId);
            return View(fordon);
        }

        // GET: Fordons1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordon.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fordon fordon = db.Fordon.Find(id);
            db.Fordon.Remove(fordon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kvito(Fordon tempfordon)
        {
            TimeSpan currenttime = (DateTime.Now - tempfordon.Tid);
            var price = currenttime.TotalHours * 60;
            ViewBag.currenttime = Convert.ToInt32(currenttime.Hours);
            ViewBag.currentminutes = Convert.ToInt32(currenttime.Minutes);
            ViewBag.price = Convert.ToInt32(price);
            return View(tempfordon);
        }
        public ActionResult Stats()
        {
            ViewBag.bil = 0;
            ViewBag.bus = 0;
            ViewBag.Motorcykel = 0;
            ViewBag.Båt = 0;
            ViewBag.Flygplan = 0;
            ViewBag.antalFordon = 0;
            foreach (var item in db.Fordon)
            {
                switch (item.Fordonstyper.Typ)
                {
                    case "Bil":
                        ViewBag.bil += 1;
                        ViewBag.antalFordon += 1;
                        break;
                    case "Buss":
                        ViewBag.bus += 1;
                        ViewBag.antalFordon += 1;
                        break;
                    case "Motorcykel":
                        ViewBag.Motorcykel += 1;
                        ViewBag.antalFordon += 1;
                        break;
                    case "Båt":
                        ViewBag.Båt += 1;
                        ViewBag.antalFordon += 1;
                        break;
                    case "Flygplan":
                        ViewBag.Flygplan += 1;
                        ViewBag.antalFordon += 1;
                        break;
                    default:
                        break;
                }

            }
            ViewBag.TotalHjul = 0;

            foreach (var item in db.Fordon)
            {
                ViewBag.TotalHjul = ViewBag.TotalHjul + item.AntalHjul;
            }
            ViewBag.TotalTid = 0;


            double TotalMinutesOfParking = 0;
            foreach (var item in db.Fordon)
            {

                TotalMinutesOfParking = Math.Round(TotalMinutesOfParking + (DateTime.Now - item.Tid).TotalMinutes);

            }
            ViewBag.count = TotalMinutesOfParking * 1;
            ViewBag.TotalTid = TotalMinutesOfParking;
            return View();
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
