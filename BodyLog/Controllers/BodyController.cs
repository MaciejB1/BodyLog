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

        public ActionResult Index(string searchString)
        {
            var body = from p in db.Body
                           select p;

            

            return View(body);
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
    }
}