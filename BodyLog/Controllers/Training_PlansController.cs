using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BodyLog.Models;

namespace BodyLog.Controllers
{
    public class Training_PlansController : Controller
    {
        private MainDB db = new MainDB();
        // GET: Training_Plans
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date_start,Date_end")] Training_PlansModel training_PlansModel)
        {
            if (ModelState.IsValid)
            {
                db.Training_PlansModels.Add(training_PlansModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(training_PlansModel);
        }
         public ActionResult AddActivities()
        {
            return View();
        }
    }
}