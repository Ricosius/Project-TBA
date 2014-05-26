using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Formule1.Models;

namespace Formule1.Controllers
{
    public class DriverController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Driver/
        public ActionResult Index()
        {
            return View(db.DriverModels.ToList());
        }

        // GET: /Driver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModel drivermodel = db.DriverModels.Find(id);
            if (drivermodel == null)
            {
                return HttpNotFound();
            }
            return View(drivermodel);
        }

        // GET: /Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Money")] DriverModel drivermodel)
        {
            if (ModelState.IsValid)
            {
                db.DriverModels.Add(drivermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drivermodel);
        }

        // GET: /Driver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModel drivermodel = db.DriverModels.Find(id);
            if (drivermodel == null)
            {
                return HttpNotFound();
            }
            return View(drivermodel);
        }

        // POST: /Driver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Money")] DriverModel drivermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drivermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drivermodel);
        }

        // GET: /Driver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModel drivermodel = db.DriverModels.Find(id);
            if (drivermodel == null)
            {
                return HttpNotFound();
            }
            return View(drivermodel);
        }

        // POST: /Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverModel drivermodel = db.DriverModels.Find(id);
            db.DriverModels.Remove(drivermodel);
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
