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
    public class ActivitiesController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: ActivitiesModels
        public ActionResult Index()
        {
            return View(db.ActivitiesModels.ToList());
        }

        // GET: ActivitiesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivitiesModels activitiesModel = db.ActivitiesModels.Find(id);
            if (activitiesModel == null)
            {
                return HttpNotFound();
            }
            return View(activitiesModel);
        }

        // GET: ActivitiesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivitiesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Time,Description,UserId")] ActivitiesModels activitiesModel)
        {
            if (ModelState.IsValid)
            {
                activitiesModel.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                db.ActivitiesModels.Add(activitiesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activitiesModel);
        }

        // GET: ActivitiesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivitiesModels activitiesModel = db.ActivitiesModels.Find(id);
            if (activitiesModel == null)
            {
                return HttpNotFound();
            }
            return View(activitiesModel);
        }

        // POST: ActivitiesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Time,Description,UserId")] ActivitiesModels activitiesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activitiesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activitiesModel);
        }

        // GET: ActivitiesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivitiesModels activitiesModel = db.ActivitiesModels.Find(id);
            if (activitiesModel == null)
            {
                return HttpNotFound();
            }
            return View(activitiesModel);
        }

        // POST: ActivitiesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivitiesModels activitiesModel = db.ActivitiesModels.Find(id);
            db.ActivitiesModels.Remove(activitiesModel);
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
