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
    public class BodyController : Controller
    {
        private MainDB db = new MainDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Body body = db.Body.Find(id);
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // GET: Body
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Weight,Description")] Body body)
        {
            if (ModelState.IsValid)
            {
                db.Body.Add(body);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(body);
        }

    }
}