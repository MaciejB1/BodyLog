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
    public class Activities_PlansController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Activities_Plans
        public ActionResult Index()
        {
            Global_Model global = new Global_Model();

            global.Activities = db.ActivitiesModels.ToList();

            global.Activities_Plans = db.Activities_Plans.ToList();
            global.TrainingsList = db.TrainingPlansModels.Where(activities => db.Activities_Plans.ToList().Any(dp => activities.Id == dp.Id_Activities)).ToList<TrainingPlansModel>();

            return View(global);
            //return View(db.Activities_Plans.ToList());
        }

        // GET: Activities_Plans/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities_Plans activities_Plans = db.Activities_Plans.Find(id);
            if (activities_Plans == null)
            {
                return HttpNotFound();
            }
            return View(activities_Plans);
        }*/

        // GET: Activities_Plans/Create
        public ActionResult Create()
        {
            Global_Model global = new Global_Model();
            global.Activities = db.ActivitiesModels.ToList();

            return View(global);
            //return View();
        }

        // POST: Activities_Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Create([Bind(Include = "Id_ActivitiesModels,Training_Plans")] Activities_Plans activities_Plans)
        {
            if (ModelState.IsValid)
            {
                db.Activities_Plans.Add(activities_Plans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activities_Plans);
        }*/

        public ActionResult Create(Global_Model list, TrainingPlansModel training)
        {

            var selectedActivities = list.Activities.ToList<ActivitiesModels>();


            /*float calories = 0, carbo = 0, proteins = 0, fats = 0;

            foreach (Product p in selectedProducts)
            {
                calories += p.Calories * p.Volume / 100;
                carbo += p.Carbohydrates * p.Volume / 100;
                proteins += p.Proteins * p.Volume / 100;
                fats += p.Fats * p.Volume / 100;
            }

            dishes.Calories = calories;
            dishes.Carbohydrates = carbo;
            dishes.Proteins = proteins;
            dishes.Fats = fats;
            dishes.Date = System.DateTime.Now;*/
            training.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            db.TrainingPlansModels.Add(training);
            db.SaveChanges();

            int id = training.Id;



            foreach (ActivitiesModels p in selectedActivities)
            {
                Activities_Plans activities_Plans = new Activities_Plans();
                activities_Plans.Id_Training_Plans = id;

                activities_Plans.Id_Activities = p.Id;
                //activities_Plans.Time = p.;
                db.Activities_Plans.Add(activities_Plans);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Activities_Plans");
        }

        // GET: Activities_Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities_Plans activities_Plans = db.Activities_Plans.Find(id);
            if (activities_Plans == null)
            {
                return HttpNotFound();
            }
            return View(activities_Plans);
        }

        // POST: Activities_Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ActivitiesModels,Training_Plans")] Activities_Plans activities_Plans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activities_Plans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activities_Plans);
        }

        // GET: Activities_Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities_Plans activities_Plans = db.Activities_Plans.Find(id);
            if (activities_Plans == null)
            {
                return HttpNotFound();
            }
            return View(activities_Plans);
        }

        // POST: Activities_Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activities_Plans activities_Plans = db.Activities_Plans.Find(id);
            db.Activities_Plans.Remove(activities_Plans);
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
