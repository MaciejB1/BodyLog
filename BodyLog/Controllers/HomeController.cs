using BodyLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace BodyLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Foods()
        {
            var dataContext = new BodyLogDataContext();
            var foods = from m in dataContext.Foods select m;

            return View(foods);
        }

        public ActionResult AddProductForm()
        {
            return View();
        }

       [HttpGet]
       public void AddProduct()
        {
            
            
        }
        
        
        public ActionResult FoodDiaryView()
        {
            ViewBag.Message = "Choose an option";

            return View();
        }

    }
}