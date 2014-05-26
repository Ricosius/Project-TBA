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
    public class EngineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Engine/
        public ActionResult Index()
        {
            return View(db.EngineModels.ToList());
        }

        // GET: /Engine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineModel enginemodel = db.EngineModels.Find(id);
            if (enginemodel == null)
            {
                return HttpNotFound();
            }
            return View(enginemodel);
        }

        // GET: /Engine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Engine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Money")] EngineModel enginemodel)
        {
            if (ModelState.IsValid)
            {
                db.EngineModels.Add(enginemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enginemodel);
        }

        // GET: /Engine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineModel enginemodel = db.EngineModels.Find(id);
            if (enginemodel == null)
            {
                return HttpNotFound();
            }
            return View(enginemodel);
        }

        // POST: /Engine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Money")] EngineModel enginemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enginemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enginemodel);
        }

        // GET: /Engine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineModel enginemodel = db.EngineModels.Find(id);
            if (enginemodel == null)
            {
                return HttpNotFound();
            }
            return View(enginemodel);
        }

        // POST: /Engine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EngineModel enginemodel = db.EngineModels.Find(id);
            db.EngineModels.Remove(enginemodel);
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
