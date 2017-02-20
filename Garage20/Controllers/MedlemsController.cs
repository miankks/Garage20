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
    public class MedlemsController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Medlems
        /*public ActionResult Index()
        {
            return View(db.Medlemmar.ToList());
        }*/

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.FörnamnSortParm = sortOrder == "Förnamn" ? "Förnamn_desc" : "Förnamn";
            ViewBag.EfternamnSortParm = sortOrder == "Efternamn" ? "Efternamn_desc" : "Efternamn";
            ViewBag.EfternamnSortParm = sortOrder == "FullständigtNamn" ? "FullständigtNamn_desc" : "FullständigtNamn";
            var medlemmar = from m in db.Medlemmar
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                medlemmar = medlemmar.Where(s => s.Förnamn.Contains(searchString)
                                              || s.Efternamn.Contains(searchString));
                                              //|| s.FullständigtNamn.Where(x => x.Förnamn == (searchString ?? x.Förnamn) || x.Efternamn == (searchString ?? x.Efternamn)).ToList());

                medlemmar = medlemmar.OrderBy(m => m.Efternamn).ThenBy(m => m.Förnamn).ThenBy(m=>m.FullständigtNamn);
                return View(medlemmar);
            }

            switch (sortOrder)
            {
                case "Förnamn":
                    medlemmar = medlemmar.OrderBy(m => m.Förnamn).ThenBy(m => m.Efternamn);
                    break;
                case "Förnamn_desc":
                    medlemmar = medlemmar.OrderByDescending(m => m.Förnamn).ThenByDescending(m => m.Efternamn);
                    break;
                case "Efternamn":
                    medlemmar = medlemmar.OrderBy(m => m.Efternamn).ThenBy(m => m.Förnamn);
                    break;
                case "Efternamn_desc":
                    medlemmar = medlemmar.OrderByDescending(m => m.Efternamn).ThenByDescending(m => m.Förnamn);
                    break;
                default:
                    break;
            }

            return View(medlemmar.ToList());
        }

        // GET: Medlems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medlem medlem = db.Medlemmar.Find(id);
            if (medlem == null)
            {
                return HttpNotFound();
            }
            return View(medlem);
        }

        // GET: Medlems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medlems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedlemsId,Förnamn,Efternamn")] Medlem medlem)
        {
            if (ModelState.IsValid)
            {
                db.Medlemmar.Add(medlem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medlem);
        }

        // GET: Medlems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medlem medlem = db.Medlemmar.Find(id);
            if (medlem == null)
            {
                return HttpNotFound();
            }
            return View(medlem);
        }

        // POST: Medlems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedlemsId,Förnamn,Efternamn")] Medlem medlem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medlem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medlem);
        }

        // GET: Medlems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medlem medlem = db.Medlemmar.Find(id);
            if (medlem == null)
            {
                return HttpNotFound();
            }
            return View(medlem);
        }

        // POST: Medlems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medlem medlem = db.Medlemmar.Find(id);
            db.Medlemmar.Remove(medlem);
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
