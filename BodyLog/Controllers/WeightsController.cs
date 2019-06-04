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
    public class WeightsController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Weights
        public ActionResult Index()
        {
            var weights = from w in db.Weights
                select w;

            return View(weights);
        }

        // GET: Weights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weights weights = db.Weights.Find(id);
            if (weights == null)
            {
                return HttpNotFound();
            }
            return View(weights);
        }

        // GET: Weights/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Date,UserId")] Weights weights)
        {
            if (ModelState.IsValid)
            {
                weights.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                db.Weights.Add(weights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weights);
        }

        // GET: Weights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weights weights = db.Weights.Find(id);
            if (weights == null)
            {
                return HttpNotFound();
            }
            return View(weights);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
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

        // GET: Weights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weights weights = db.Weights.Find(id);
            if (weights == null)
            {
                return HttpNotFound();
            }
            return View(weights);
        }

        // POST: Weights/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weights weights = db.Weights.Find(id);
            db.Weights.Remove(weights);
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
