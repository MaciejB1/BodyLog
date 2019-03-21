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
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Product(ProductModel model)
        {
            ViewBag.Message = "Add a product";
            if (ModelState.IsValid)
            {
                int recordsCreated = ProductsProcessor.AddProduct(model.Name, model.Calories, model.IdCategory, 1);
                return RedirectToAction("Index");
            }


            return View();
        }

        public ActionResult FoodDiaryView()
        {
            ViewBag.Message = "Choose an option";

            return View();
        }

    }
}