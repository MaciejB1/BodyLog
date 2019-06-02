using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BodyLog.Models;
using Microsoft.AspNet.Identity;

namespace BodyLog.Controllers
{
    public class weightController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        public ActionResult Index()
        {
            var weights = from w in db.Weight
                          select w;

            return View(weights);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weights weights = db.Weight.Find(id);
            if (weights == null)
            {
                return HttpNotFound();
            }
            return View(weights);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        
        public ActionResult Create([Bind(Include = "Id,Weight,Date,UserId")] Weights weights)
        {
            if (ModelState.IsValid)
            {
                weights.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                db.Weight.Add(weights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weights);
        }

        // GET: Weight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weights weights = db.Weight.Find(id);
            if (weights == null)
            {
                return HttpNotFound();
            }
            return View(weights);
        }


        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,Weight,Date,UserId")] Weights weights)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weights).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weights);
        }

        // GET: Weight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weights weights = db.Weight.Find(id);
            if (weights == null)
            {
                return HttpNotFound();
            }
            return View(weights);
        }

        // POST: Weight/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weights weights = db.Weight.Find(id);
            db.Weight.Remove(weights);
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
