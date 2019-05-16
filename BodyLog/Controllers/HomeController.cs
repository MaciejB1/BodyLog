using BodyLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult FoodDiaryView()
        {
            ViewBag.Message = "Choose an option";

            return View();
        }

        public ActionResult BodyView()
        {
            return View();
        }


    }
}