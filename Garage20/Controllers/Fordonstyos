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
    public class FordonstypsController : Controller
    {
        private FordonContext db = new FordonContext();

        // GET: Fordonstyps
        public ActionResult Index()
        {
            return View(db.Fordonstyp.ToList());
        }

        // GET: Fordonstyps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordonstyp fordonstyp = db.Fordonstyp.Find(id);
            if (fordonstyp == null)
            {
                return HttpNotFound();
            }
            return View(fordonstyp);
        }

        // GET: Fordonstyps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fordonstyps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FordonstypId,Typ")] Fordonstyp fordonstyp)
        {
            if (ModelState.IsValid)
            {
                db.Fordonstyp.Add(fordonstyp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fordonstyp);
        }

        // GET: Fordonstyps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordonstyp fordonstyp = db.Fordonstyp.Find(id);
            if (fordonstyp == null)
            {
                return HttpNotFound();
            }
            return View(fordonstyp);
        }

        // POST: Fordonstyps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FordonstypId,Typ")] Fordonstyp fordonstyp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordonstyp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fordonstyp);
        }

        // GET: Fordonstyps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordonstyp fordonstyp = db.Fordonstyp.Find(id);
            if (fordonstyp == null)
            {
                return HttpNotFound();
            }
            return View(fordonstyp);
        }

        // POST: Fordonstyps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fordonstyp fordonstyp = db.Fordonstyp.Find(id);
            db.Fordonstyp.Remove(fordonstyp);
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
