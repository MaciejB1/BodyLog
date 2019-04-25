﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BodyLog.Models;

namespace BodyLog.Controllers
{
    public class DishesController : Controller
    {
        private MainDB db = new MainDB();

        public ActionResult Index()
        {
            return View(db.Dishes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,Calories,Proteins,Carbohydrates,Fats")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(dishes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dishes);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Calories,Proteins,Carbohydrates,Fats")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dishes);
        }

        // GET: Dishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dishes dishes = db.Dishes.Find(id);
            db.Dishes.Remove(dishes);
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
