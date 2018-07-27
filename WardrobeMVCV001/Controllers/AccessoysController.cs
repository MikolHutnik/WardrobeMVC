using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVCV001;

namespace WardrobeMVCV001.Controllers
{
    public class AccessoysController : Controller
    {
        private WardrobeV001Entities db = new WardrobeV001Entities();

        // GET: Accessoys
        public ActionResult Index()
        {
            return View(db.Accessoies.ToList());
        }

        // GET: Accessoys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoy accessoy = db.Accessoies.Find(id);
            if (accessoy == null)
            {
                return HttpNotFound();
            }
            return View(accessoy);
        }

        // GET: Accessoys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accessoys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryID,Name,Photo,Type,Color,Season,Occasion")] Accessoy accessoy)
        {
            if (ModelState.IsValid)
            {
                db.Accessoies.Add(accessoy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessoy);
        }

        // GET: Accessoys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoy accessoy = db.Accessoies.Find(id);
            if (accessoy == null)
            {
                return HttpNotFound();
            }
            return View(accessoy);
        }

        // POST: Accessoys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryID,Name,Photo,Type,Color,Season,Occasion")] Accessoy accessoy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessoy);
        }

        // GET: Accessoys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoy accessoy = db.Accessoies.Find(id);
            if (accessoy == null)
            {
                return HttpNotFound();
            }
            return View(accessoy);
        }

        // POST: Accessoys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessoy accessoy = db.Accessoies.Find(id);
            db.Accessoies.Remove(accessoy);
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
