using System;
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
    public class TrainingPlansController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: TrainingPlans
        public ActionResult Index()
        {
            return View(db.TrainingPlans.ToList());
        }

        // GET: TrainingPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingPlansModel trainingPlansModel = db.TrainingPlans.Find(id);
            if (trainingPlansModel == null)
            {
                return HttpNotFound();
            }
            return View(trainingPlansModel);
        }

        // GET: TrainingPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date_start,Date_end,Id_Activities,UserId")] TrainingPlansModel trainingPlansModel)
        {
            if (ModelState.IsValid)
            {
                db.TrainingPlans.Add(trainingPlansModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingPlansModel);
        }

        // GET: TrainingPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingPlansModel trainingPlansModel = db.TrainingPlans.Find(id);
            if (trainingPlansModel == null)
            {
                return HttpNotFound();
            }
            return View(trainingPlansModel);
        }

        // POST: TrainingPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date_start,Date_end,Id_Activities,UserId")] TrainingPlansModel trainingPlansModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingPlansModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingPlansModel);
        }

        // GET: TrainingPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingPlansModel trainingPlansModel = db.TrainingPlans.Find(id);
            if (trainingPlansModel == null)
            {
                return HttpNotFound();
            }
            return View(trainingPlansModel);
        }

        // POST: TrainingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingPlansModel trainingPlansModel = db.TrainingPlans.Find(id);
            db.TrainingPlans.Remove(trainingPlansModel);
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
