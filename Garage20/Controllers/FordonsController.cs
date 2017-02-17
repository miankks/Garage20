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
using System.Globalization;
using System.Threading;

namespace Garage20.Controllers
{
    public class FordonsController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Fordons
        /*public ActionResult Index(string searchString)
        {
            var model = from m in db.Fordons
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.RegNr.Contains(searchString));
                return View(model);
            }

            return View(db.Fordons.ToList());
        }*/

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.RegNrSortParm = sortOrder == "RegNr" ? "RegNr_desc" : "RegNr";
            ViewBag.TypSortParm = sortOrder == "Typ" ? "Typ_desc" : "Typ";
            ViewBag.FärgSortParm = sortOrder == "Färg" ? "Färg_desc" : "Färg";
            ViewBag.TidSortParm = sortOrder == "Tid" ? "Tid_desc" : "Tid";
            var fordon = from f in db.Fordons
                         select f;
            //IQueryable<Fordon> fordon = db.Fordons;

            if (!String.IsNullOrEmpty(searchString))
            {
                fordon = fordon.Where(s => s.RegNr.Contains(searchString)
                                        || s.Färg.Contains(searchString)
                                        || s.Modell.Contains(searchString)
                                        || s.Märke.Contains(searchString)
                                        || s.AntalHjul.ToString().Contains(searchString)
                                        || s.Fordonstyper.Typ.Contains(searchString)
                                        || s.Tid.ToString().Contains(searchString)
                                        );
                return View(fordon);
            }

            switch (sortOrder)
            {
                case "RegNr":
                    fordon = fordon.OrderBy(f => f.RegNr);
                    break;
                case "RegNr_desc":
                    fordon = fordon.OrderByDescending(f => f.RegNr);
                    break;
                case "Typ":
                    fordon = fordon.OrderBy(f => f.Fordonstyper.Typ);
                    break;
                case "Typ_desc":
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");
                    //CultureInfo svSE = new CultureInfo("sv-SE");

                    //fordon = fordon.OrderByDescending(f => f.Typ.ToString(), StringComparer.Create(svSE, false));

                    fordon = fordon.OrderByDescending(f => f.Fordonstyper.Typ);
                    break;
                case "Färg":
                    fordon = fordon.OrderBy(f => f.Färg);
                    break;
                case "Färg_desc":
                    fordon = fordon.OrderByDescending(f => f.Färg);
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
            var findFordon = from m in db.Fordons
                             where fordon.RegNr == m.RegNr
                             select m.RegNr;
            if (findFordon.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    fordon.Tid = DateTime.Now;
                    fordon.RegNr = fordon.RegNr.ToUpper();
                    fordon.Färg = fordon.Färg.ToLower();
                    fordon.Färg = fordon.Färg.First().ToString().ToUpper() + fordon.Färg.Substring(1); //Stor första bokstav.
                    fordon.Märke = fordon.Märke.ToLower();
                    fordon.Märke = fordon.Märke.First().ToString().ToUpper() + fordon.Märke.Substring(1); //Stor första bokstav.
                    fordon.Modell = fordon.Modell.ToUpper();

                    db.Fordons.Add(fordon);
                    db.SaveChanges();
                    ViewBag.error = "";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.error = "Registreringsnumret finns redan i garaget!";
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
        public ActionResult Edit([Bind(Include = "Id,RegNr,Typ,Färg,Märke,Modell,AntalHjul,Tid")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                fordon.RegNr = fordon.RegNr.ToUpper();
                fordon.Färg = fordon.Färg.ToLower();
                fordon.Färg = fordon.Färg.First().ToString().ToUpper() + fordon.Färg.Substring(1); //Stor första bokstav.
                fordon.Märke = fordon.Märke.ToLower();
                fordon.Märke = fordon.Märke.First().ToString().ToUpper() + fordon.Märke.Substring(1); //Stor första bokstav.
                fordon.Modell = fordon.Modell.ToUpper();
                
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
            Fordon tempfordon = fordon;
            db.Fordons.Remove(fordon);
            db.SaveChanges();
            return RedirectToAction("Kvito",tempfordon);
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
        // [HttpGet]
        public ActionResult Stats()
        {
            ViewBag.bil = 0;
            ViewBag.bus = 0;
            ViewBag.Motorcykel = 0;
            ViewBag.Båt = 0;
            ViewBag.Flygplan = 0;
            ViewBag.antalFordon = 0;
            foreach (var item in db.Fordons)
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

            foreach (var item in db.Fordons)
            {
                ViewBag.TotalHjul = ViewBag.TotalHjul + item.AntalHjul;
            }
            ViewBag.TotalTid = 0;


            double TotalMinutesOfParking = 0;
            foreach (var item in db.Fordons)
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
