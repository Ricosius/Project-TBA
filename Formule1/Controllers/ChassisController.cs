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
    public class ChassisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Chassis/
        public ActionResult Index()
        {
            return View(db.ChassisModels.ToList());
        }

        // GET: /Chassis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChassisModel chassismodel = db.ChassisModels.Find(id);
            if (chassismodel == null)
            {
                return HttpNotFound();
            }
            return View(chassismodel);
        }

        // GET: /Chassis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Chassis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Money")] ChassisModel chassismodel)
        {
            if (ModelState.IsValid)
            {
                db.ChassisModels.Add(chassismodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chassismodel);
        }

        // GET: /Chassis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChassisModel chassismodel = db.ChassisModels.Find(id);
            if (chassismodel == null)
            {
                return HttpNotFound();
            }
            return View(chassismodel);
        }

        // POST: /Chassis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Money")] ChassisModel chassismodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chassismodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chassismodel);
        }

        // GET: /Chassis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChassisModel chassismodel = db.ChassisModels.Find(id);
            if (chassismodel == null)
            {
                return HttpNotFound();
            }
            return View(chassismodel);
        }

        // POST: /Chassis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChassisModel chassismodel = db.ChassisModels.Find(id);
            db.ChassisModels.Remove(chassismodel);
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
