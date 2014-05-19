﻿using System;
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
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Profile/
        public ActionResult Index()
        {
            return View(db.ProfileViewModels.ToList());
            
        }

        // GET: /Profile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileViewModel profileviewmodel = db.ProfileViewModels.Find(id);
            if (profileviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(profileviewmodel);
        }

        // GET: /Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeamName")] ProfileViewModel profileviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.ProfileViewModels.Add(profileviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileviewmodel);
        }

        // GET: /Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileViewModel profileviewmodel = db.ProfileViewModels.Find(id);
            if (profileviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(profileviewmodel);
        }

        // POST: /Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,UserNameID,Money,TeamName,EngineID,DriverID,ChassisID")] ProfileViewModel profileviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileviewmodel);
        }

        // GET: /Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileViewModel profileviewmodel = db.ProfileViewModels.Find(id);
            if (profileviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(profileviewmodel);
        }

        // POST: /Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileViewModel profileviewmodel = db.ProfileViewModels.Find(id);
            db.ProfileViewModels.Remove(profileviewmodel);
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